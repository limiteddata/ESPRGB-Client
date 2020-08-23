using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ESPRGB_Client
{
    public partial class breathingSlider : UserControl
    {
        public List<Color> colorList = new List<Color>();
        private Bitmap bmp;
        private Graphics gfx;
        public breathingSlider()
        {
            InitializeComponent();

            initializeSolidDiscoVisualizer();
        }
        private void initializeSolidDiscoVisualizer()
        {
            bmp = new Bitmap(pictureColor.Width, pictureColor.Height);
            gfx = Graphics.FromImage(bmp);
            gfx.Clear(Color.FromArgb(255, 21, 32, 54));
            pictureColor.Image = bmp;
        }
        public void addListColor(List<Color> addedlistColor)
        {
            colorList.Clear();
            colorList = addedlistColor;
            gfx.Clear(Color.Transparent);
            drawColors();
        }
        public void addColor(Color addedColor)
        {
            colorList.Add(addedColor);
            gfx.Clear(Color.Transparent);
            drawColors();
        }
        public void removeLastColor()
        {
            if (colorList.Count > 0) { 
                colorList.RemoveAt(colorList.Count - 1);
                gfx.Clear(Color.Transparent);
                drawColors();
            }
        }
        public void clearAll()
        {
            colorList.Clear();
            gfx.Clear(Color.FromArgb(255, 21, 32, 54));
            drawColors();
        }
        Pen pen = new Pen(Color.FromArgb(46, 46, 54), 1.5f);
        void drawColors()
        {
            float x = 0;
            float w = (float)this.Width / colorList.Count;
            foreach (var color in colorList)
            {
                gfx.FillRectangle(new SolidBrush(color), new RectangleF(x, 0, w, this.Height));
                gfx.DrawRectangle(pen, x, 0, w, this.Height);
                x += w;
            }
            pictureColor.Image = bmp;
        }
    }
}
