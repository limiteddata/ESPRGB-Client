namespace ESPRGB_Client
{
    partial class ScreenSampler
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.NextScreen = new System.Windows.Forms.Button();
            this.PrevScreen = new System.Windows.Forms.Button();
            this.colorPanel = new System.Windows.Forms.Panel();
            this.addnewpanel = new System.Windows.Forms.Button();
            this.removeAll = new System.Windows.Forms.Button();
            this.screenPictureBox = new System.Windows.Forms.PictureBox();
            this.screensPanel = new System.Windows.Forms.Panel();
            this.liveTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.screenPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // NextScreen
            // 
            this.NextScreen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(215)))), ((int)(((byte)(156)))));
            this.NextScreen.FlatAppearance.BorderSize = 0;
            this.NextScreen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.NextScreen.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NextScreen.ForeColor = System.Drawing.Color.White;
            this.NextScreen.Location = new System.Drawing.Point(670, 0);
            this.NextScreen.Margin = new System.Windows.Forms.Padding(0);
            this.NextScreen.Name = "NextScreen";
            this.NextScreen.Size = new System.Drawing.Size(30, 360);
            this.NextScreen.TabIndex = 2;
            this.NextScreen.TabStop = false;
            this.NextScreen.Text = "⯈";
            this.NextScreen.UseVisualStyleBackColor = false;
            this.NextScreen.Click += new System.EventHandler(this.NextScreen_Click);
            // 
            // PrevScreen
            // 
            this.PrevScreen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(54)))));
            this.PrevScreen.FlatAppearance.BorderSize = 0;
            this.PrevScreen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PrevScreen.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PrevScreen.ForeColor = System.Drawing.Color.White;
            this.PrevScreen.Location = new System.Drawing.Point(0, 0);
            this.PrevScreen.Margin = new System.Windows.Forms.Padding(0);
            this.PrevScreen.Name = "PrevScreen";
            this.PrevScreen.Size = new System.Drawing.Size(30, 360);
            this.PrevScreen.TabIndex = 3;
            this.PrevScreen.TabStop = false;
            this.PrevScreen.Text = "⯇";
            this.PrevScreen.UseVisualStyleBackColor = false;
            this.PrevScreen.Click += new System.EventHandler(this.PrevScreen_Click);
            // 
            // colorPanel
            // 
            this.colorPanel.BackColor = System.Drawing.Color.Black;
            this.colorPanel.Location = new System.Drawing.Point(30, 360);
            this.colorPanel.Margin = new System.Windows.Forms.Padding(0);
            this.colorPanel.Name = "colorPanel";
            this.colorPanel.Size = new System.Drawing.Size(640, 25);
            this.colorPanel.TabIndex = 4;
            // 
            // addnewpanel
            // 
            this.addnewpanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(98)))), ((int)(((byte)(98)))));
            this.addnewpanel.FlatAppearance.BorderSize = 0;
            this.addnewpanel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addnewpanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addnewpanel.ForeColor = System.Drawing.Color.White;
            this.addnewpanel.Location = new System.Drawing.Point(670, 360);
            this.addnewpanel.Margin = new System.Windows.Forms.Padding(0);
            this.addnewpanel.Name = "addnewpanel";
            this.addnewpanel.Size = new System.Drawing.Size(30, 25);
            this.addnewpanel.TabIndex = 5;
            this.addnewpanel.TabStop = false;
            this.addnewpanel.Text = "➕";
            this.addnewpanel.UseVisualStyleBackColor = false;
            this.addnewpanel.Click += new System.EventHandler(this.addnewpanel_Click);
            // 
            // removeAll
            // 
            this.removeAll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(64)))), ((int)(((byte)(57)))));
            this.removeAll.FlatAppearance.BorderSize = 0;
            this.removeAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.removeAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.removeAll.ForeColor = System.Drawing.Color.White;
            this.removeAll.Location = new System.Drawing.Point(0, 360);
            this.removeAll.Margin = new System.Windows.Forms.Padding(0);
            this.removeAll.Name = "removeAll";
            this.removeAll.Size = new System.Drawing.Size(30, 25);
            this.removeAll.TabIndex = 6;
            this.removeAll.TabStop = false;
            this.removeAll.Text = "🗑";
            this.removeAll.UseVisualStyleBackColor = false;
            this.removeAll.Click += new System.EventHandler(this.removeAll_Click);
            // 
            // screenPictureBox
            // 
            this.screenPictureBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(32)))), ((int)(((byte)(54)))));
            this.screenPictureBox.Location = new System.Drawing.Point(30, 0);
            this.screenPictureBox.Margin = new System.Windows.Forms.Padding(0);
            this.screenPictureBox.Name = "screenPictureBox";
            this.screenPictureBox.Size = new System.Drawing.Size(640, 360);
            this.screenPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.screenPictureBox.TabIndex = 1;
            this.screenPictureBox.TabStop = false;
            this.screenPictureBox.Click += new System.EventHandler(this.screenPictureBox_Click);
            // 
            // screensPanel
            // 
            this.screensPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(42)))), ((int)(((byte)(71)))));
            this.screensPanel.Location = new System.Drawing.Point(275, 360);
            this.screensPanel.Name = "screensPanel";
            this.screensPanel.Size = new System.Drawing.Size(150, 7);
            this.screensPanel.TabIndex = 7;
            // 
            // liveTimer
            // 
            this.liveTimer.Interval = 80;
            this.liveTimer.Tick += new System.EventHandler(this.useLiveTimer_Tick);
            // 
            // ScreenSampler
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(32)))), ((int)(((byte)(54)))));
            this.Controls.Add(this.addnewpanel);
            this.Controls.Add(this.screensPanel);
            this.Controls.Add(this.removeAll);
            this.Controls.Add(this.colorPanel);
            this.Controls.Add(this.PrevScreen);
            this.Controls.Add(this.NextScreen);
            this.Controls.Add(this.screenPictureBox);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ScreenSampler";
            this.Size = new System.Drawing.Size(700, 385);
            ((System.ComponentModel.ISupportInitialize)(this.screenPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button NextScreen;
        private System.Windows.Forms.Button PrevScreen;
        private System.Windows.Forms.Panel colorPanel;
        private System.Windows.Forms.Button addnewpanel;
        private System.Windows.Forms.Button removeAll;
        public System.Windows.Forms.PictureBox screenPictureBox;
        private System.Windows.Forms.Panel screensPanel;
        public System.Windows.Forms.Timer liveTimer;
    }
}
