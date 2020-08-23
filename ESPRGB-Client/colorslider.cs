using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class colorslider : UserControl
    {
        public int Min
        {
            get { return min; }
            set { min = value; Invalidate(); }
        }
        int min = 0;
        public int Max
        {
            get { return max; }
            set { max = value; Invalidate(); }
        }
        int max = 16;
        public int SelectedMin
        {
            get { return selectedMin; }
            set
            {
                
                if (value < min) { selectedMin = min; }
                else if (value > selectedMax) { selectedMin = selectedMax; }
                else { selectedMin = value; }
                if (SelectionChanged != null)
                    SelectionChanged(this, null);
                Invalidate();
            }
        }
        int selectedMin = 4;
        public int SelectedMax
        {
            get { return selectedMax; }
            set
            {
                if (value < selectedMin) { selectedMax = selectedMin; }
                else if (value > max) { selectedMax = max; }
                else { selectedMax = value; }
                if (SelectionChanged != null)
                    SelectionChanged(this, null);
                Invalidate();
            }
        }
        int selectedMax = 12;
        public event EventHandler SelectionChanged;
        public SolidBrush color1 = new SolidBrush(Color.Red);
        public SolidBrush color2 = new SolidBrush(Color.Lime);
        public SolidBrush color3 = new SolidBrush(Color.Blue);

        public colorslider()
        {
            InitializeComponent();
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            Paint += new PaintEventHandler(SelectionRangeSlider_Paint);
            MouseDown += new MouseEventHandler(SelectionRangeSlider_MouseDown);
            MouseMove += new MouseEventHandler(SelectionRangeSlider_MouseMove);
        }

        public void SelectionRangeSlider_Paint(object sender, PaintEventArgs e)
        {
            Rectangle rectSelection1 = new Rectangle(0, 0, (selectedMin - Min) * Width / (Max - Min), Height);
            e.Graphics.FillRectangle(color1, rectSelection1);
            Rectangle rectSelection2 = new Rectangle(
                (selectedMin - Min) * Width / (Max - Min),0,
                (selectedMax - selectedMin) * Width / (Max - Min),Height);
            e.Graphics.FillRectangle(color2, rectSelection2);
            Rectangle rectSelection3 = new Rectangle((SelectedMax - Min) * Width / (Max - Min), 0, Width, Height);
            e.Graphics.FillRectangle(color3, rectSelection3);
        }
        public void SelectionRangeSlider_MouseDown(object sender, MouseEventArgs e)
        {
            int pointedValue = Min + e.X * (Max - Min) / Width;
            int distValue = Math.Abs(pointedValue );
            int distMin = Math.Abs(pointedValue - SelectedMin);
            int distMax = Math.Abs(pointedValue - SelectedMax);
            int minDist = Math.Min(distValue, Math.Min(distMin, distMax));
            if (minDist == distMin)
                movingMode = MovingMode.MovingMin;
            else
                movingMode = MovingMode.MovingMax;
            //call this to refreh the position of the selected thumb
            SelectionRangeSlider_MouseMove(sender, e);
        }
        void SelectionRangeSlider_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;
            int pointedValue = Min + e.X * (Max - Min) / Width;
            if (movingMode == MovingMode.MovingMin)
                SelectedMin = pointedValue;
            else if (movingMode == MovingMode.MovingMax)
                SelectedMax = pointedValue;
        }
        enum MovingMode {MovingMin, MovingMax}
        MovingMode movingMode;
    }
}
