namespace ESPRGB_Client
{

    partial class ESPRGB
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        /// 
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ESPRGB));
            this.Title_text = new System.Windows.Forms.Label();
            this.notifyTray = new System.Windows.Forms.NotifyIcon(this.components);
            trayContext = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTurnOffAll = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTurnOnAll = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.exitButton = new System.Windows.Forms.Button();
            this.settingsButton = new System.Windows.Forms.Button();
            this.minimizeButton = new System.Windows.Forms.Button();
            tabDevices = new Zeroit.Framework.Metro.ZeroitMetroTabControl();
            this._Add_Device = new System.Windows.Forms.TabPage();
            trayContext.SuspendLayout();
            tabDevices.SuspendLayout();
            this.SuspendLayout();
            // 
            // Title_text
            // 
            this.Title_text.AutoSize = true;
            this.Title_text.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Title_text.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(215)))), ((int)(((byte)(156)))));
            this.Title_text.Location = new System.Drawing.Point(10, 16);
            this.Title_text.Margin = new System.Windows.Forms.Padding(0);
            this.Title_text.Name = "Title_text";
            this.Title_text.Size = new System.Drawing.Size(99, 25);
            this.Title_text.TabIndex = 0;
            this.Title_text.Text = "ESPRGB";
            // 
            // notifyTray
            // 
            this.notifyTray.ContextMenuStrip = trayContext;
            this.notifyTray.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyTray.Icon")));
            this.notifyTray.Text = "ESPRGB";
            this.notifyTray.Visible = true;
            this.notifyTray.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyTray_MouseDoubleClick);
            // 
            // trayContext
            // 
            trayContext.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(32)))), ((int)(((byte)(54)))));
            trayContext.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showToolStripMenuItem,
            this.toolStripTurnOffAll,
            this.toolStripTurnOnAll,
            this.exitToolStripMenuItem});
            trayContext.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            trayContext.Name = "trayContext";
            trayContext.ShowImageMargin = false;
            trayContext.ShowItemToolTips = false;
            trayContext.Size = new System.Drawing.Size(143, 92);
            // 
            // showToolStripMenuItem
            // 
            this.showToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.showToolStripMenuItem.Name = "showToolStripMenuItem";
            this.showToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.showToolStripMenuItem.Text = "Show";
            this.showToolStripMenuItem.Click += new System.EventHandler(this.showToolStripMenuItem_Click);
            // 
            // toolStripTurnOffAll
            // 
            this.toolStripTurnOffAll.ForeColor = System.Drawing.Color.White;
            this.toolStripTurnOffAll.Name = "toolStripTurnOffAll";
            this.toolStripTurnOffAll.Size = new System.Drawing.Size(142, 22);
            this.toolStripTurnOffAll.Text = "TurnOff All Lights";
            this.toolStripTurnOffAll.Click += new System.EventHandler(this.toolStripTurnOffAll_Click);
            // 
            // toolStripTurnOnAll
            // 
            this.toolStripTurnOnAll.ForeColor = System.Drawing.Color.White;
            this.toolStripTurnOnAll.Name = "toolStripTurnOnAll";
            this.toolStripTurnOnAll.Size = new System.Drawing.Size(142, 22);
            this.toolStripTurnOnAll.Text = "TurnOn All Lights";
            this.toolStripTurnOnAll.Click += new System.EventHandler(this.toolStripTurnOnAll_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.exitToolStripMenuItem.Text = "Quit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(0, 0);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(200, 100);
            this.tabPage1.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(0, 0);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(200, 100);
            this.tabPage2.TabIndex = 0;
            // 
            // exitButton
            // 
            this.exitButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.exitButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(32)))), ((int)(((byte)(54)))));
            this.exitButton.FlatAppearance.BorderSize = 0;
            this.exitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exitButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(32)))), ((int)(((byte)(54)))));
            this.exitButton.Image = global::ESPRGB_Client.Properties.Resources.exit;
            this.exitButton.Location = new System.Drawing.Point(790, 16);
            this.exitButton.Margin = new System.Windows.Forms.Padding(0);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(24, 24);
            this.exitButton.TabIndex = 1;
            this.exitButton.TabStop = false;
            this.exitButton.UseVisualStyleBackColor = false;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // settingsButton
            // 
            this.settingsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.settingsButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(32)))), ((int)(((byte)(54)))));
            this.settingsButton.FlatAppearance.BorderSize = 0;
            this.settingsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.settingsButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(32)))), ((int)(((byte)(54)))));
            this.settingsButton.Image = global::ESPRGB_Client.Properties.Resources.settings;
            this.settingsButton.Location = new System.Drawing.Point(763, 16);
            this.settingsButton.Margin = new System.Windows.Forms.Padding(0);
            this.settingsButton.Name = "settingsButton";
            this.settingsButton.Size = new System.Drawing.Size(24, 24);
            this.settingsButton.TabIndex = 5;
            this.settingsButton.TabStop = false;
            this.settingsButton.UseVisualStyleBackColor = false;
            this.settingsButton.Click += new System.EventHandler(this.settingsButton_Click);
            // 
            // minimizeButton
            // 
            this.minimizeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.minimizeButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(32)))), ((int)(((byte)(54)))));
            this.minimizeButton.FlatAppearance.BorderSize = 0;
            this.minimizeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.minimizeButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(32)))), ((int)(((byte)(54)))));
            this.minimizeButton.Image = global::ESPRGB_Client.Properties.Resources.minimize;
            this.minimizeButton.Location = new System.Drawing.Point(738, 16);
            this.minimizeButton.Margin = new System.Windows.Forms.Padding(0);
            this.minimizeButton.Name = "minimizeButton";
            this.minimizeButton.Size = new System.Drawing.Size(24, 24);
            this.minimizeButton.TabIndex = 4;
            this.minimizeButton.TabStop = false;
            this.minimizeButton.UseVisualStyleBackColor = false;
            this.minimizeButton.Click += new System.EventHandler(this.minimizeButton_Click);
            // 
            // tabDevices
            // 
            tabDevices.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            tabDevices.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            tabDevices.AnimationSpeed = -1;
            tabDevices.Appearance = System.Windows.Forms.Appearance.Normal;
            tabDevices.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            tabDevices.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(32)))), ((int)(((byte)(54)))));
            tabDevices.Controls.Add(this._Add_Device);
            tabDevices.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            tabDevices.HasAnimation = false;
            tabDevices.HeaderForeColor = System.Drawing.Color.White;
            tabDevices.HeaderItemColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(42)))), ((int)(((byte)(71)))));
            tabDevices.HotTrack = true;
            tabDevices.HoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(42)))), ((int)(((byte)(71)))));
            tabDevices.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(42)))), ((int)(((byte)(71)))));
            tabDevices.ItemColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(32)))), ((int)(((byte)(54)))));
            tabDevices.ItemForeColor = System.Drawing.Color.White;
            tabDevices.ItemSize = new System.Drawing.Size(80, 50);
            tabDevices.Location = new System.Drawing.Point(-4, 50);
            tabDevices.Margin = new System.Windows.Forms.Padding(0);
            tabDevices.Multiline = true;
            tabDevices.Name = "tabDevices";
            tabDevices.Padding = new System.Drawing.Point(15, 10);
            tabDevices.SelectedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(215)))), ((int)(((byte)(156)))));
            tabDevices.SelectedForeColor = System.Drawing.Color.White;
            tabDevices.SelectedIndex = 0;
            tabDevices.SelectedItemColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(215)))), ((int)(((byte)(156)))));
            tabDevices.SelectedItemLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(215)))), ((int)(((byte)(156)))));
            tabDevices.SelectedItemLineWidth = 0;
            tabDevices.SelectedTabIsBold = false;
            tabDevices.Size = new System.Drawing.Size(836, 522);
            tabDevices.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            tabDevices.TabContainerColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(32)))), ((int)(((byte)(54)))));
            tabDevices.TabIndex = 7;
            // 
            // _Add_Device
            // 
            this._Add_Device.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(42)))), ((int)(((byte)(71)))));
            this._Add_Device.Location = new System.Drawing.Point(4, 4);
            this._Add_Device.Name = "_Add_Device";
            this._Add_Device.Padding = new System.Windows.Forms.Padding(3);
            this._Add_Device.Size = new System.Drawing.Size(828, 464);
            this._Add_Device.TabIndex = 0;
            this._Add_Device.Text = "Add Device";
            // 
            // ESPRGB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = false;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(32)))), ((int)(((byte)(54)))));
            this.ClientSize = new System.Drawing.Size(828, 570);
            tabDevices.Visible = false;
            this.Controls.Add(tabDevices);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.Title_text);
            this.Controls.Add(this.settingsButton);
            this.Controls.Add(this.minimizeButton);
            tabDevices.Visible = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ESPRGB";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ESPRGB";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ESPRGB_Closing);
            this.Load += new System.EventHandler(this.ESPRGB_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.window_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.window_MouseMove);
            this.Resize += new System.EventHandler(this.ESPRGB_Resize);
            trayContext.ResumeLayout(false);
            tabDevices.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.NotifyIcon notifyTray;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showToolStripMenuItem;
        private System.Windows.Forms.Button settingsButton;
        private System.Windows.Forms.Button minimizeButton;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        public System.Windows.Forms.Label Title_text;
        private System.Windows.Forms.TabPage _Add_Device;
        private System.Windows.Forms.ToolStripMenuItem toolStripTurnOffAll;
        private System.Windows.Forms.ToolStripMenuItem toolStripTurnOnAll;
        public static System.Windows.Forms.ContextMenuStrip trayContext;
        public static Zeroit.Framework.Metro.ZeroitMetroTabControl tabDevices;
    }
}


