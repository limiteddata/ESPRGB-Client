using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Drawing.Imaging;
using System.Windows.Data;

namespace ESPRGB_Client
{
    public partial class ScreenSampler : UserControl
    {
        ToolTip screenTips = new ToolTip();
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        private int[] current_rez = new int[] { 0, 0 };

        List<Button> ScreenSliderbuttons = new List<Button>();
        public List<SelectionPanel> selectionPanels = new List<SelectionPanel>();
        Screen[] screens;
        Graphics gfx;
        public Bitmap main_bmp;
        public Bitmap image_bmp;
        public string imageFileLocation;
        
        bool captureScreen = true;

        public bool enable
        {
            get { return _enable; }
            set {
                if (this.selectedScreen != this.ScreenSliderbuttons.Count() - 1) this.liveTimer.Enabled = value;
                else this.liveTimer.Enabled = false;
                _enable = value;
            }
        }
        private bool _enable;

        public int selectedScreen
        {
            get { return _selectedScreen; }
            set
            {
                if ( value > -1 && value < ScreenSliderbuttons.Count())
                {           
                    _selectedScreen = value; 
                    if (value == ScreenSliderbuttons.Count()-1)
                    {
                        this.captureScreen = false;
                        this.screenTips.SetToolTip(this.screenPictureBox, "Double click to upload image");
                        this.screenPictureBox.DoubleClick -= uploadImage;
                        this.screenPictureBox.DoubleClick += uploadImage;
                        if (this.image_bmp != null) this.main_bmp = this.image_bmp;
                        else this.main_bmp = new Bitmap(current_rez[0], current_rez[1]);
                        this.screenPictureBox.Image = this.main_bmp;
                    }
                    else
                    {
                        this.captureScreen = true;
                        this.screenTips.RemoveAll();
                        this.screenPictureBox.DoubleClick -= uploadImage;
                        this.main_bmp = new Bitmap(screens[value].Bounds.Width, screens[value].Bounds.Height);
                    }
                    this.current_rez[0] = main_bmp.Width;
                    this.current_rez[1] = main_bmp.Height;
                    this.gfx = Graphics.FromImage(main_bmp);

                    foreach (var panel in this.selectionPanels) panel.repositionRectangle();                  
                    foreach (var btn in ScreenSliderbuttons)
                    {
                        if (btn == ScreenSliderbuttons[value]) btn.BackColor = Color.FromArgb(6, 215, 156);
                        else btn.BackColor = Color.FromArgb(98, 98, 98);
                    }
                    this.enable = this.enable;
                    this.getColor(true);
                    GC.Collect();                
                }
            }
        }
        private int _selectedScreen = -1;
        public ScreenSampler()
        {
            InitializeComponent();
            this.initScreenSlider();
            ToolTip tips = new ToolTip();
            tips.InitialDelay = 100;
            tips.SetToolTip(this.NextScreen, "Next screen");
            tips.SetToolTip(this.PrevScreen, "Previous screen");
            tips.SetToolTip(this.removeAll, "Remove all the selections");
            tips.SetToolTip(this.addnewpanel, "Add new selection");
            this.selectedScreen = 0;
            this.CreateDefaultSelections();
        }

        public event EventHandler<System.Drawing.Color> OnColorChanged;
        public event EventHandler OnScreenChanged;

        public System.Drawing.Color ScreenColor {
            get { return _ScreenColor; }
            set {
                if (_ScreenColor != value)
                {             
                    _ScreenColor = value;
                    this.colorPanel.BackColor = value;
                    this.OnColorChanged?.Invoke(this, value);
                }
            }
        }
        private System.Drawing.Color _ScreenColor;
        BitmapData srcData;
        int stride;
        IntPtr Scan0;

        void initScreenSlider()
        { 
            screens = Screen.AllScreens;
            int x = 0;
            int w = screensPanel.Width / (screens.Count()+1);
            for (int i = 0; i < screens.Count()+1; i++)
            {
                var btn = new Button();
                btn.Left = x;
                btn.BackColor = Color.FromArgb(98, 98, 98);
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 0;
                btn.Size = new Size(w, screensPanel.Height);
                btn.TabIndex = 100 + i;
                btn.Click += (sender, e) =>
                {
                    this.selectedScreen = btn.TabIndex - 100;
                    this.OnScreenChanged?.Invoke(this, null);
                };
                this.ScreenSliderbuttons.Add(btn);
                this.screensPanel.Controls.Add(btn);
                x += w;
            }
            this.screensPanel.Width = x;
        }
        public void CreateDefaultSelections()
        {
            this.createPanel("Top Left", 0, 0, 200, 100, false);
            this.createPanel("Top Right", this.screenPictureBox.Width - 200, 0, 200, 100, false);
            this.createPanel("Bottom Left", 0, this.screenPictureBox.Height - 100, 200, 100, false);
            this.createPanel("Bottom Right", this.screenPictureBox.Width - 200, this.screenPictureBox.Height - 100, 200, 100, false);
        }
        private void PrevScreen_Click(object sender, EventArgs e)
        {
            this.selectedScreen -= 1;
            this.OnScreenChanged?.Invoke(this, e);
        }
        private void NextScreen_Click(object sender, EventArgs e)
        {
            this.selectedScreen += 1;
            this.OnScreenChanged?.Invoke(this, e);
        }
        private void useLiveTimer_Tick(object sender, EventArgs e)
        {
            this.getColor();
        }
        private void getColor(bool showImage = false)
        {           
            try
            {
                if (captureScreen)
                {             
                    this.gfx.CopyFromScreen(this.screens[selectedScreen].Bounds.X, this.screens[selectedScreen].Bounds.Y, 0, 0, this.screens[selectedScreen].Bounds.Size, CopyPixelOperation.SourceCopy);
                    if (ESPRGB.windowState == FormWindowState.Normal || showImage) this.screenPictureBox.Image = this.main_bmp;
                }
                if (selectionPanels.Count > 0)
                {
                    int avgRed = 0;
                    int avgGreen = 0;
                    int avgBlue = 0;
                    
                    for (int i = 0; i < selectionPanels.Count; i++)
                    {
                        var rectangle = selectionPanels[i].rectangle;
                        int panelColor_R = 0;
                        int panelColor_G = 0;
                        int panelColor_B = 0;

                        this.srcData = main_bmp.LockBits(rectangle, ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
                        this.stride = srcData.Stride;
                        this.Scan0 = srcData.Scan0;
                         
                        unsafe
                        {
                            byte* p = (byte*)(void*)Scan0;
                            for (int y = 0; y < rectangle.Height; y++)
                            {
                                for (int x = 0; x < rectangle.Width; x++)
                                {
                                    int idx = (y * stride) + x * 4;
                                    panelColor_R += p[idx + 2];
                                    panelColor_G += p[idx + 1];
                                    panelColor_B += p[idx];
                                }
                            }
                        }
                        avgRed += panelColor_R / (rectangle.Width * rectangle.Height);
                        avgGreen += panelColor_G / (rectangle.Width * rectangle.Height);
                        avgBlue += panelColor_B / (rectangle.Width * rectangle.Height);

                        this.main_bmp.UnlockBits(srcData);
                    }
                    this.ScreenColor = Color.FromArgb(avgRed /= selectionPanels.Count, avgGreen /= selectionPanels.Count, avgBlue /= selectionPanels.Count);
                }
                else this.ScreenColor = Color.FromArgb(0, 0, 0);
            }
            catch
            {
            }
        }
        private void addnewpanel_Click(object senderb, EventArgs e)
        {
            if (selectionPanels.Count < 15)
            {
                this.createPanel("Panel " + this.selectionPanels.Count, 0, 0, 200, 100, true);
                this.OnScreenChanged?.Invoke(this, e);
            }
            else
            {
                exceptions exitMessage = new exceptions("ESPRGB-Exception", "Selections are limited to 15");
                exitMessage.StartPosition = FormStartPosition.CenterParent;
                exitMessage.ShowDialog();
            }          
        }
        public void createPanel(string text, int x, int y, int width, int height, bool selected)
        {
            var panel = new SelectionPanel(this.screenPictureBox, this.selectionPanels, this.current_rez, text, x, y, width, height, selected);
            panel.OnSelectionChanged += (sender, e) =>
            {
                this.getColor();
                this.OnScreenChanged?.Invoke(this, e);
            };
            this.selectionPanels.Add(panel);
            this.getColor();
        }
        public void removeAll_Click(object sender, EventArgs e)
        {
            this.removeAllSelections();
            this.OnScreenChanged?.Invoke(this, e);
        }
        public void removeAllSelections()
        {
            for (int i = this.selectionPanels.Count - 1; i >= 0; i--) this.selectionPanels[i].Dispose();
            this.selectionPanels.Clear();
        }
        private void screenPictureBox_Click(object sender, EventArgs e)
        {
            if (this.selectionPanels.Count > 0) this.selectionPanels[0].deselectThis();
            this.screenPictureBox.Focus();
        }
        private void uploadImage(object sender, EventArgs e)
        {
            
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Title = "Open Image";
                dlg.Filter = "Image Files (*.bmp;*.jpg;*.jpeg,*.png)|*.BMP;*.JPG;*.JPEG;*.PNG";
                if (dlg.ShowDialog() == DialogResult.OK) openImage(dlg.FileName);
            }
        }
        public void openImage(string location)
        {
            try
            {
                this.image_bmp = new Bitmap(location);
                if (this.image_bmp.Width * this.image_bmp.Height > 33177600) // 8k
                {
                    this.image_bmp.Dispose();
                    exitMessage exitMessage = new exitMessage("ESPRGB-Format device", "Image size is too large");
                    exitMessage.StartPosition = FormStartPosition.CenterParent;
                    exitMessage.ShowDialog();
                    return;
                }
                this.imageFileLocation = location;
                this.selectedScreen = this.selectedScreen;
            }
            catch
            {                
            }         
        }
        public class SelectionPanel : PictureBox
        {
            public SelectionPanel SelectedPanel
            {
                get { return _SelectedPanel; }
                set
                {
                    if (_SelectedPanel != value)
                    {
                        if (SelectedPanel != null)
                        {
                            SelectedPanel.BorderStyle = BorderStyle.None;
                            SelectedPanel.CloseEdit();
                        }
                        this.BorderStyle = BorderStyle.Fixed3D;
                        _SelectedPanel = value;
                    }
                    else
                    {
                        if (editPanel && sizeWidth.Text != "" && sizeWidth.Text != "") this.AcceptEdit(Convert.ToInt32(sizeWidth.Text), Convert.ToInt32(sizeHeight.Text));
                        else SelectedPanel.CloseEdit();
                    }
                    this.Select();
                }
            }

            private static SelectionPanel _SelectedPanel;
            public System.Drawing.Rectangle rectangle;
            public Label label = new Label();
            private Button editButton = new Button();
            private Button removeButton = new Button();
            private TextBox editText = new TextBox();
            private NumericUpDown sizeWidth = new NumericUpDown();
            private NumericUpDown sizeHeight = new NumericUpDown();
            private Label widthLabel = new Label();
            private Label heightLabel = new Label();
            private PictureBox _parentBox;
            private int[] _screenRes;
            private List<SelectionPanel> _panelList;
            public event EventHandler OnSelectionChanged;
            private const int resize_grip = 10;
            private Point resize_Point = new Point();
            public SelectionPanel(PictureBox parentBox,List<SelectionPanel> panelList, int[] screenRes, string text, int x, int y, int width, int height, bool selected)
            {               
                // Objs Properties 
                {
                    this._parentBox = parentBox;
                    this._screenRes = screenRes;
                    this._panelList = panelList;
                    // panel 
                    this.Cursor = Cursors.SizeAll;
                    this.BackColor = System.Drawing.Color.FromArgb(150, 6, 215, 156);
                    this.Size = new Size(width, height);
                    this.ForeColor = System.Drawing.Color.White;
                    this.Location = new System.Drawing.Point(x, y);
                    this.TabStop = false;
                    this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
                    this.SetStyle(ControlStyles.ResizeRedraw, true);
                    ToolTip tt = new ToolTip();
                    tt.AutomaticDelay = 2000;
                    tt.SetToolTip(this, "You can use Delete Escape Enter keys");
                    if (selected) SelectedPanel = this;
                    // rectangle
                    this.rectangle = new System.Drawing.Rectangle();   
                    // text
                    this.label.Location = new System.Drawing.Point(10, 10);
                    this.label.AutoSize = true;
                    this.label.TextAlign = ContentAlignment.MiddleCenter;
                    this.label.BackColor = System.Drawing.Color.FromArgb(0);
                    this.label.ForeColor = System.Drawing.Color.Black;
                    this.label.Text = text;
                    this.label.TabStop = false;
                    this.Controls.Add(this.label);
                    // edit text
                    this.editText.Location = new System.Drawing.Point(10, 10);
                    this.editText.Visible = false;
                    this.editText.BorderStyle = BorderStyle.Fixed3D;
                    this.editText.Font = new Font("Microsoft Sans Serif", 9F);
                    this.editText.Text = text;
                    this.editText.MaxLength = 24;
                    this.editText.TabStop = false;
                    this.Controls.Add(this.editText);
                    // edit button
                    this.editButton.Text = "✎";
                    this.editButton.Cursor = Cursors.Default;
                    this.editButton.FlatStyle = FlatStyle.Flat;
                    this.editButton.Font = new Font("Times New Roman", 8F);
                    this.editButton.TextAlign = System.Drawing.ContentAlignment.TopLeft;
                    this.editButton.ForeColor = System.Drawing.Color.Black;
                    this.editButton.Size = new Size(20, 20);
                    this.editButton.FlatAppearance.BorderSize = 0;
                    this.editButton.Padding = new Padding(0);
                    this.editButton.Margin = new Padding(0);
                    this.editButton.TabStop = false;
                    this.Controls.Add(this.editButton);
                    // remove button
                    this.removeButton.Text = "✕";
                    this.removeButton.Cursor = Cursors.Default;
                    this.removeButton.FlatStyle = FlatStyle.Flat;
                    this.removeButton.Font = new Font("Times New Roman", 8F);
                    this.removeButton.TextAlign = System.Drawing.ContentAlignment.TopLeft;
                    this.removeButton.ForeColor = System.Drawing.Color.Black;
                    this.removeButton.Size = new Size(20, 20);
                    this.removeButton.FlatAppearance.BorderSize = 0;
                    this.removeButton.Padding = new Padding(0);
                    this.removeButton.Margin = new Padding(0);
                    this.removeButton.TabStop = false;
                    this.Controls.Add(this.removeButton);
                    // widthLabel            
                    this.widthLabel.AutoSize = true;
                    this.widthLabel.Visible = false;
                    this.widthLabel.BackColor = System.Drawing.Color.FromArgb(0);
                    this.widthLabel.ForeColor = System.Drawing.Color.Black;
                    this.widthLabel.Text = "Width";
                    this.widthLabel.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
                    this.widthLabel.TabStop = false;
                    this.Controls.Add(this.widthLabel);
                    // sizeWidth
                    this.sizeWidth.Visible = false;
                    this.sizeWidth.BorderStyle = BorderStyle.Fixed3D;
                    this.sizeWidth.Font = new Font("Microsoft Sans Serif", 9F);
                    this.sizeWidth.Minimum = resize_grip;
                    this.sizeWidth.Maximum = _parentBox.Width;
                    this.sizeWidth.Value = this.Width;
                    this.sizeWidth.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
                    this.sizeWidth.TabStop = false;
                    this.Controls.Add(this.sizeWidth);
                    // heightLabel            
                    this.heightLabel.AutoSize = true;
                    this.heightLabel.Visible = false;
                    this.heightLabel.BackColor = System.Drawing.Color.FromArgb(0);
                    this.heightLabel.ForeColor = System.Drawing.Color.Black;
                    this.heightLabel.Text = "Height";
                    this.heightLabel.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
                    this.heightLabel.TabStop = false;
                    this.Controls.Add(this.heightLabel);
                    // sizeHeight
                    this.sizeHeight.Visible = false;
                    this.sizeHeight.BorderStyle = BorderStyle.Fixed3D;
                    this.sizeHeight.Font = new Font("Microsoft Sans Serif", 9F);
                    this.sizeHeight.Minimum = resize_grip;
                    this.sizeHeight.Maximum = _parentBox.Height;
                    this.sizeHeight.Value = this.Height;
                    this.sizeHeight.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
                    this.sizeHeight.TabStop = false;
                    this.Controls.Add(this.sizeHeight);
                    this.repositonButton();
                    this.repositionRectangle();
                }
                this.MouseMove += (sender, e) =>
                {
                    if (e.Button == MouseButtons.Left)
                    {
                        ReleaseCapture();
                        SendMessage(this.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
                        this.moveSelection();
                        this.OnSelectionChanged?.Invoke(this, null);
                    }
                };
                this.MouseDown += (sender, e) => SelectedPanel = this;

                this.editButton.Click += (sender, e) =>
                {
                    SelectedPanel = this;
                    this.editPanel = true;
                    this.Focus();
                };
                this.PreviewKeyDown += (sender,e) => {
                    switch (e.KeyCode)
                    {
                        case Keys.Down:
                        case Keys.Up:
                        case Keys.Left:
                        case Keys.Right:
                            e.IsInputKey = true;
                            break;
                    }
                };
                this.KeyDown += this.checkKeys;
                this.KeyUp += (sender,e) => this.OnSelectionChanged?.Invoke(this, null);
                this.editText.KeyDown += new KeyEventHandler(this.checkKeys);
                this.sizeWidth.KeyDown += new KeyEventHandler(this.checkKeys);
                this.sizeHeight.KeyDown += new KeyEventHandler(this.checkKeys);
                this.removeButton.Click += (sender, e) => this.deleteThis();
                _parentBox.Controls.Add(this);
            }
            protected override void OnPaint(PaintEventArgs e)
            {
                ControlPaint.DrawSizeGrip(e.Graphics, this.BackColor, new Rectangle(this.Width - resize_grip, this.Height - resize_grip, resize_grip, resize_grip));
            }
            protected override void WndProc(ref Message m)
            {
                if (m.Msg == 0x232)
                {
                    this.AcceptEdit(this.Width,this.Height);
                    return;
                }
                if (m.Msg == 0x84)
                {
                    this.resize_Point = new Point(m.LParam.ToInt32());
                    this.resize_Point = this.PointToClient(resize_Point);

                    if (resize_Point.X >= this.Width - resize_grip && resize_Point.Y >= this.Height - resize_grip)
                    {
                        m.Result = (IntPtr)17;
                        return;
                    }
                }
                
                base.WndProc(ref m);
            }

            private void checkKeys(object sender, KeyEventArgs e)
            {
                if (e.KeyCode == Keys.Delete) { if (SelectedPanel != null) SelectedPanel.deleteThis(); }
                if (e.KeyCode == Keys.Escape) SelectedPanel.CloseEdit();
                if (e.KeyCode == Keys.Enter)
                {
                    if (editPanel && sizeWidth.Text != "" && sizeWidth.Text != "") SelectedPanel.AcceptEdit(Convert.ToInt32(sizeWidth.Text), Convert.ToInt32(sizeHeight.Text));
                    else SelectedPanel.CloseEdit();
                }
                if (e.KeyCode == Keys.Up) this.Top -= 1;
                if (e.KeyCode == Keys.Down) this.Top += 1;
                if (e.KeyCode == Keys.Left) this.Left -= 1;
                if (e.KeyCode == Keys.Right) this.Left += 1;              
                this.moveSelection();
            }
            private void moveSelection()
            {
                if (this.Location.X < 0) this.Left = 0;
                if (this.Location.Y < 0) this.Top = 0;
                if (this.Location.X > _parentBox.Width - this.Width) this.Left = _parentBox.Width - this.Width;
                if (this.Location.Y > _parentBox.Height - this.Height) this.Top = _parentBox.Height - this.Height;
                this.repositionRectangle();
            }
            private bool editPanel
            {
                get { return _editPanel; }
                set
                {
                    this.editText.Text = this.label.Text;
                    this.sizeWidth.Text = this.Width.ToString();
                    this.sizeHeight.Text = this.Height.ToString();
                    this.editButton.Visible = !value;
                    this.removeButton.Visible = !value;
                    this.label.Visible = !value;
                    this.editText.Visible = value;
                    this.sizeWidth.Visible = value;
                    this.sizeHeight.Visible = value;
                    this.widthLabel.Visible = value;
                    this.heightLabel.Visible = value;
                    if(!value) this.repositonButton();
                    _editPanel = value;
                }
            }
            private bool _editPanel;
            public void AcceptEdit(int w, int h)
            {
                label.Text = editText.Text;
                if ((w >= sizeWidth.Minimum && w <= _parentBox.Width) && (h >= sizeHeight.Minimum && h <= _parentBox.Height))
                {
                    this.Width = w;
                    this.Height = h;
                }
                else
                {
                    this.Width = (int)sizeWidth.Minimum;
                    this.Height = (int)sizeHeight.Minimum;
                }
                this.CloseEdit();
                this.moveSelection();
                this.OnSelectionChanged?.Invoke(this, null);
            }
            public void CloseEdit()
            {
                this.editPanel = false;
                this.Select();
            }
            private void repositonButton()
            {
                if ( this.Width * this.Height < 6500)
                {
                    this.editButton.Visible = false;
                    this.removeButton.Visible = false;
                    this.label.Visible = false; this.editButton.Visible = false;
                    this.removeButton.Visible = false;
                    this.label.Visible = false;
                }
                else
                {
                    this.label.Font = new Font("Microsoft Sans Serif", 10F);
                    this.editText.Size = new Size(140, 20);
                    this.sizeWidth.Size = new Size(50, 20);
                    this.sizeHeight.Size = new Size(50, 20);
                    this.sizeWidth.Location = new System.Drawing.Point(10, this.Height - 30);
                    this.sizeHeight.Location = new System.Drawing.Point(65, this.Height - 30);
                    this.heightLabel.Location = new System.Drawing.Point(65, this.Height - 44);
                    this.heightLabel.Font = new Font("Microsoft Sans Serif", 8F);
                    this.widthLabel.Location = new System.Drawing.Point(10, this.Height - 44);
                    this.widthLabel.Font = new Font("Microsoft Sans Serif", 8F);
                    this.removeButton.Location = new System.Drawing.Point(this.label.Width + this.editButton.Width + 10, 10);
                    this.editButton.Location = new System.Drawing.Point(this.label.Width + 10, 10);
                    this.editButton.Visible = true;
                    this.removeButton.Visible = true;
                    this.label.Visible = true;
                }

            }
            public void repositionRectangle()
            {
                float _w = (float)_screenRes[0] / (float)_parentBox.Width;
                float _h = (float)_screenRes[1] / (float)_parentBox.Height;
                int w = (int)(_w * (float)this.Width);
                int h = (int)(_h * (float)this.Height);
                if (w < 1) w = 1;
                if (h < 1) h = 1;
                this.rectangle.X = (int)(_w * (float)this.Location.X);
                this.rectangle.Y = (int)(_h * (float)this.Location.Y);
                this.rectangle.Size = new Size(w, h);
            }
            public void deleteThis()
            {
                _panelList.Remove(this);
                this.OnSelectionChanged?.Invoke(this, null);
                this.Dispose();
            }
            public void deselectThis()
            {
                if (_SelectedPanel != null)
                {
                    if (editPanel && sizeWidth.Text != "" && sizeWidth.Text != "") this.AcceptEdit(Convert.ToInt32(sizeWidth.Text), Convert.ToInt32(sizeHeight.Text));
                    else SelectedPanel.CloseEdit();
                    _SelectedPanel.BorderStyle = BorderStyle.None;
                    _SelectedPanel = null;
                }
            }
        }
    }
}
