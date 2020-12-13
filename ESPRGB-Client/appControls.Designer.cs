using System;
using WebSocketSharp;

namespace ESPRGB_Client
{

    partial class appControls
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
            this.brightnessSlide = new Zeroit.Framework.Metro.ZeroitMetroTrackbar();
            this.preset3 = new System.Windows.Forms.Panel();
            this.preset2 = new System.Windows.Forms.Panel();
            this.preset4 = new System.Windows.Forms.Panel();
            this.preset1 = new System.Windows.Forms.Panel();
            this.preset0 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.ColorCycleSpeed = new Zeroit.Framework.Metro.ZeroitMetroTrackbar();
            this.ColorCycleSpeedText = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.breathingSpeed = new Zeroit.Framework.Metro.ZeroitMetroTrackbar();
            this.breathingSpeedText = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.statusLabel = new System.Windows.Forms.Label();
            this.discoTimer = new System.Windows.Forms.Timer(this.components);
            this.presetTip = new System.Windows.Forms.ToolTip(this.components);
            this.ambilightSpeed = new Zeroit.Framework.Metro.ZeroitMetroTrackbar();
            this.colorslider1 = new WindowsFormsApp2.colorslider();
            this.colorslider_simple = new ESPRGB_Client.colorslider_simple();
            this.tabctrl = new Zeroit.Framework.Metro.ZeroitMetroTabControl();
            this._SolidColor = new System.Windows.Forms.TabPage();
            this.powerButton = new System.Windows.Forms.CheckBox();
            this.colorWheel = new Cyotek.Windows.Forms.ColorWheel();
            this._Color_Cycle = new System.Windows.Forms.TabPage();
            this.startColorCycle = new System.Windows.Forms.CheckBox();
            this._Breathing = new System.Windows.Forms.TabPage();
            this.colorBreathing = new Cyotek.Windows.Forms.ColorWheel();
            this.br_clearColorlist = new System.Windows.Forms.Button();
            this.br_removeLastColor = new System.Windows.Forms.Button();
            this.br_addCurrentColor = new System.Windows.Forms.Button();
            this.useColorList = new System.Windows.Forms.CheckBox();
            this.colorListResult = new ESPRGB_Client.breathingSlider();
            this.startBreathing = new System.Windows.Forms.CheckBox();
            this._Disco = new System.Windows.Forms.TabPage();
            this.startDisco = new System.Windows.Forms.CheckBox();
            this.label15 = new System.Windows.Forms.Label();
            this.highsBrightness = new Zeroit.Framework.Metro.ZeroitMetroTrackbar();
            this.label14 = new System.Windows.Forms.Label();
            this.midsBrightness = new Zeroit.Framework.Metro.ZeroitMetroTrackbar();
            this.label13 = new System.Windows.Forms.Label();
            this.lowsBrightness = new Zeroit.Framework.Metro.ZeroitMetroTrackbar();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.highSensitivity = new Zeroit.Framework.Metro.ZeroitMetroTrackbar();
            this.midSensitivity = new Zeroit.Framework.Metro.ZeroitMetroTrackbar();
            this.lowSensitivity = new Zeroit.Framework.Metro.ZeroitMetroTrackbar();
            this.selectionColor = new System.Windows.Forms.ComboBox();
            this.sel_black = new System.Windows.Forms.Button();
            this.sel_blue = new System.Windows.Forms.Button();
            this.sel_green = new System.Windows.Forms.Button();
            this.sel_red = new System.Windows.Forms.Button();
            this.ResultColor = new System.Windows.Forms.PictureBox();
            this.pictureBoxTop = new System.Windows.Forms.PictureBox();
            this._SolidDisco = new System.Windows.Forms.TabPage();
            this.colorWheel_SolidDisco = new Cyotek.Windows.Forms.ColorWheel();
            this.randomColor = new System.Windows.Forms.CheckBox();
            this.label11 = new System.Windows.Forms.Label();
            this.solidDiscoSensitivity = new Zeroit.Framework.Metro.ZeroitMetroTrackbar();
            this.startSolidDisco = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SolidDiscoVisualizer = new System.Windows.Forms.PictureBox();
            this._MorseCode = new System.Windows.Forms.TabPage();
            this.morseColor = new Cyotek.Windows.Forms.ColorWheel();
            this.useBuzzer = new System.Windows.Forms.CheckBox();
            this.unitTime = new Zeroit.Framework.Metro.ZeroitMetroTrackbar();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.encodedMsgResult = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.morsePlainText = new System.Windows.Forms.TextBox();
            this.startMorseCode = new System.Windows.Forms.CheckBox();
            this.label12 = new System.Windows.Forms.Label();
            this._Ambilight = new System.Windows.Forms.TabPage();
            this.screenSampler = new ESPRGB_Client.ScreenSampler();
            this.startAmbilight = new System.Windows.Forms.CheckBox();
            this.label21 = new System.Windows.Forms.Label();
            this._Schedule = new System.Windows.Forms.TabPage();
            this.timeScheduleList = new WindowsFormsApp2.scheduleList();
            this.label24 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.enableTimeSchedule = new Zeroit.Framework.Metro.ZeroitMetroSwitch();
            this.addNewTimeSchedule = new System.Windows.Forms.Button();
            this.label22 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.enableAppSchedule = new Zeroit.Framework.Metro.ZeroitMetroSwitch();
            this.addNewAppSchedule = new System.Windows.Forms.Button();
            this.label19 = new System.Windows.Forms.Label();
            this.appScheduleList = new WindowsFormsApp2.scheduleList();
            this._Other = new System.Windows.Forms.TabPage();
            this.removeDevice = new System.Windows.Forms.Button();
            this.espVersion = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.powerConectedButton = new System.Windows.Forms.Button();
            this.restartButton = new System.Windows.Forms.Button();
            this.configButton = new System.Windows.Forms.Button();
            this.syncButton = new System.Windows.Forms.Button();
            this.removeUserConfig = new System.Windows.Forms.Button();
            this.formatButton = new System.Windows.Forms.Button();
            this.connectButton = new System.Windows.Forms.Button();
            this.solidDiscoTimer = new System.Windows.Forms.Timer(this.components);
            this.textBoxTimer = new System.Windows.Forms.Timer(this.components);
            this.wifiImageBox = new System.Windows.Forms.PictureBox();
            this.tabctrl.SuspendLayout();
            this._SolidColor.SuspendLayout();
            this._Color_Cycle.SuspendLayout();
            this._Breathing.SuspendLayout();
            this._Disco.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ResultColor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTop)).BeginInit();
            this._SolidDisco.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SolidDiscoVisualizer)).BeginInit();
            this._MorseCode.SuspendLayout();
            this._Ambilight.SuspendLayout();
            this._Schedule.SuspendLayout();
            this._Other.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.wifiImageBox)).BeginInit();
            this.SuspendLayout();
            // 
            // brightnessSlide
            // 
            this.brightnessSlide.BackColor = System.Drawing.Color.Transparent;
            this.brightnessSlide.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.brightnessSlide.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(98)))), ((int)(((byte)(98)))));
            this.brightnessSlide.GradientColor = System.Drawing.Color.Transparent;
            this.brightnessSlide.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(215)))), ((int)(((byte)(156)))));
            this.brightnessSlide.LeftColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(215)))), ((int)(((byte)(156)))));
            this.brightnessSlide.Location = new System.Drawing.Point(210, 381);
            this.brightnessSlide.Name = "brightnessSlide";
            this.brightnessSlide.RailWidth = 20;
            this.brightnessSlide.RegionColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(215)))), ((int)(((byte)(156)))));
            this.brightnessSlide.RightColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.brightnessSlide.Size = new System.Drawing.Size(310, 23);
            this.brightnessSlide.SliderColor = System.Drawing.Color.White;
            this.brightnessSlide.SliderWidth = 20;
            this.brightnessSlide.TabIndex = 27;
            this.brightnessSlide.TabStop = false;
            this.brightnessSlide.UseGradient = false;
            this.brightnessSlide.Value = 0;
            this.brightnessSlide.Scroll += new Zeroit.Framework.Metro.ZeroitMetroTrackbar.ScrollEventHandler(this.brightnessSlide_Scroll);
            // 
            // preset3
            // 
            this.preset3.BackColor = System.Drawing.Color.White;
            this.preset3.Location = new System.Drawing.Point(405, 414);
            this.preset3.Name = "preset3";
            this.preset3.Size = new System.Drawing.Size(50, 20);
            this.preset3.TabIndex = 19;
            this.preset3.Tag = "3";
            this.presetTip.SetToolTip(this.preset3, "Right click to save current color.");
            this.preset3.MouseClick += new System.Windows.Forms.MouseEventHandler(this.setPreset);
            // 
            // preset2
            // 
            this.preset2.BackColor = System.Drawing.Color.White;
            this.preset2.Location = new System.Drawing.Point(340, 414);
            this.preset2.Name = "preset2";
            this.preset2.Size = new System.Drawing.Size(50, 20);
            this.preset2.TabIndex = 19;
            this.preset2.Tag = "2";
            this.presetTip.SetToolTip(this.preset2, "Right click to save current color.");
            this.preset2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.setPreset);
            // 
            // preset4
            // 
            this.preset4.BackColor = System.Drawing.Color.White;
            this.preset4.Location = new System.Drawing.Point(470, 414);
            this.preset4.Name = "preset4";
            this.preset4.Size = new System.Drawing.Size(50, 20);
            this.preset4.TabIndex = 18;
            this.preset4.Tag = "4";
            this.presetTip.SetToolTip(this.preset4, "Right click to save current color.");
            this.preset4.MouseClick += new System.Windows.Forms.MouseEventHandler(this.setPreset);
            // 
            // preset1
            // 
            this.preset1.BackColor = System.Drawing.Color.White;
            this.preset1.Location = new System.Drawing.Point(275, 414);
            this.preset1.Name = "preset1";
            this.preset1.Size = new System.Drawing.Size(50, 20);
            this.preset1.TabIndex = 17;
            this.preset1.Tag = "1";
            this.presetTip.SetToolTip(this.preset1, "Right click to save current color.");
            this.preset1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.setPreset);
            // 
            // preset0
            // 
            this.preset0.BackColor = System.Drawing.Color.White;
            this.preset0.Location = new System.Drawing.Point(210, 414);
            this.preset0.Name = "preset0";
            this.preset0.Size = new System.Drawing.Size(50, 20);
            this.preset0.TabIndex = 16;
            this.preset0.Tag = "0";
            this.presetTip.SetToolTip(this.preset0, "Right click to save current color.");
            this.preset0.MouseClick += new System.Windows.Forms.MouseEventHandler(this.setPreset);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(7, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 20);
            this.label2.TabIndex = 15;
            this.label2.Tag = "DontDisable";
            this.label2.Text = "Solid Color";
            // 
            // ColorCycleSpeed
            // 
            this.ColorCycleSpeed.BackColor = System.Drawing.Color.Transparent;
            this.ColorCycleSpeed.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ColorCycleSpeed.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(98)))), ((int)(((byte)(98)))));
            this.ColorCycleSpeed.GradientColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(215)))), ((int)(((byte)(215)))));
            this.ColorCycleSpeed.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(215)))), ((int)(((byte)(156)))));
            this.ColorCycleSpeed.LeftColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(215)))), ((int)(((byte)(156)))));
            this.ColorCycleSpeed.Location = new System.Drawing.Point(49, 73);
            this.ColorCycleSpeed.Maximum = 200;
            this.ColorCycleSpeed.Minimum = 1;
            this.ColorCycleSpeed.Name = "ColorCycleSpeed";
            this.ColorCycleSpeed.RailWidth = 20;
            this.ColorCycleSpeed.RegionColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(215)))), ((int)(((byte)(156)))));
            this.ColorCycleSpeed.RightColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.ColorCycleSpeed.Size = new System.Drawing.Size(603, 23);
            this.ColorCycleSpeed.SliderColor = System.Drawing.Color.White;
            this.ColorCycleSpeed.SliderWidth = 20;
            this.ColorCycleSpeed.TabIndex = 26;
            this.ColorCycleSpeed.TabStop = false;
            this.ColorCycleSpeed.Value = 1;
            this.ColorCycleSpeed.Scroll += new Zeroit.Framework.Metro.ZeroitMetroTrackbar.ScrollEventHandler(this.ColorCycleSpeed_Scroll);
            // 
            // ColorCycleSpeedText
            // 
            this.ColorCycleSpeedText.AutoSize = true;
            this.ColorCycleSpeedText.ForeColor = System.Drawing.Color.White;
            this.ColorCycleSpeedText.Location = new System.Drawing.Point(639, 99);
            this.ColorCycleSpeedText.Name = "ColorCycleSpeedText";
            this.ColorCycleSpeedText.Size = new System.Drawing.Size(13, 15);
            this.ColorCycleSpeedText.TabIndex = 19;
            this.ColorCycleSpeedText.Text = "1";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(594, 99);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 15);
            this.label6.TabIndex = 18;
            this.label6.Text = "Speed:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(10, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 20);
            this.label3.TabIndex = 16;
            this.label3.Tag = "DontDisable";
            this.label3.Text = "Color cycle";
            // 
            // breathingSpeed
            // 
            this.breathingSpeed.BackColor = System.Drawing.Color.Transparent;
            this.breathingSpeed.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.breathingSpeed.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(98)))), ((int)(((byte)(98)))));
            this.breathingSpeed.GradientColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(215)))), ((int)(((byte)(215)))));
            this.breathingSpeed.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(215)))), ((int)(((byte)(156)))));
            this.breathingSpeed.LeftColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(215)))), ((int)(((byte)(156)))));
            this.breathingSpeed.Location = new System.Drawing.Point(49, 73);
            this.breathingSpeed.Maximum = 200;
            this.breathingSpeed.Minimum = 1;
            this.breathingSpeed.Name = "breathingSpeed";
            this.breathingSpeed.RailWidth = 20;
            this.breathingSpeed.RegionColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(215)))), ((int)(((byte)(156)))));
            this.breathingSpeed.RightColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.breathingSpeed.Size = new System.Drawing.Size(603, 23);
            this.breathingSpeed.SliderColor = System.Drawing.Color.White;
            this.breathingSpeed.SliderWidth = 20;
            this.breathingSpeed.TabIndex = 25;
            this.breathingSpeed.TabStop = false;
            this.breathingSpeed.Value = 1;
            this.breathingSpeed.Scroll += new Zeroit.Framework.Metro.ZeroitMetroTrackbar.ScrollEventHandler(this.breathingSpeed_Scroll);
            // 
            // breathingSpeedText
            // 
            this.breathingSpeedText.AutoSize = true;
            this.breathingSpeedText.ForeColor = System.Drawing.Color.White;
            this.breathingSpeedText.Location = new System.Drawing.Point(639, 99);
            this.breathingSpeedText.Name = "breathingSpeedText";
            this.breathingSpeedText.Size = new System.Drawing.Size(13, 15);
            this.breathingSpeedText.TabIndex = 23;
            this.breathingSpeedText.Text = "1";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(594, 99);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(42, 15);
            this.label8.TabIndex = 22;
            this.label8.Text = "Speed:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(10, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 20);
            this.label4.TabIndex = 17;
            this.label4.Tag = "DontDisable";
            this.label4.Text = "Breathing";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(10, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 20);
            this.label5.TabIndex = 17;
            this.label5.Tag = "DontDisable";
            this.label5.Text = "Disco";
            // 
            // statusLabel
            // 
            this.statusLabel.ForeColor = System.Drawing.Color.White;
            this.statusLabel.Location = new System.Drawing.Point(7, 421);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(85, 45);
            this.statusLabel.TabIndex = 25;
            this.statusLabel.Text = "Status";
            this.statusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // discoTimer
            // 
            this.discoTimer.Interval = 10;
            this.discoTimer.Tick += new System.EventHandler(this.discoTimer_Tick);
            // 
            // ambilightSpeed
            // 
            this.ambilightSpeed.BackColor = System.Drawing.Color.Transparent;
            this.ambilightSpeed.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ambilightSpeed.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(98)))), ((int)(((byte)(98)))));
            this.ambilightSpeed.GradientColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(215)))), ((int)(((byte)(215)))));
            this.ambilightSpeed.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(215)))), ((int)(((byte)(156)))));
            this.ambilightSpeed.LeftColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(215)))), ((int)(((byte)(156)))));
            this.ambilightSpeed.Location = new System.Drawing.Point(14, 431);
            this.ambilightSpeed.Maximum = 1200;
            this.ambilightSpeed.Minimum = 1;
            this.ambilightSpeed.Name = "ambilightSpeed";
            this.ambilightSpeed.RailWidth = 20;
            this.ambilightSpeed.RegionColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(215)))), ((int)(((byte)(156)))));
            this.ambilightSpeed.RightColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.ambilightSpeed.Size = new System.Drawing.Size(588, 23);
            this.ambilightSpeed.SliderColor = System.Drawing.Color.White;
            this.ambilightSpeed.SliderWidth = 20;
            this.ambilightSpeed.TabIndex = 28;
            this.ambilightSpeed.TabStop = false;
            this.presetTip.SetToolTip(this.ambilightSpeed, "Image refresh interval");
            this.ambilightSpeed.Value = 80;
            this.ambilightSpeed.Scroll += new Zeroit.Framework.Metro.ZeroitMetroTrackbar.ScrollEventHandler(this.ambilightSpeed_Scroll);
            this.ambilightSpeed.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ambilightSpeed_MouseUp);
            // 
            // colorslider1
            // 
            this.colorslider1.Location = new System.Drawing.Point(150, 208);
            this.colorslider1.Max = 16;
            this.colorslider1.Min = 0;
            this.colorslider1.Name = "colorslider1";
            this.colorslider1.SelectedMax = 12;
            this.colorslider1.SelectedMin = 4;
            this.colorslider1.Size = new System.Drawing.Size(404, 20);
            this.colorslider1.TabIndex = 54;
            this.colorslider1.TabStop = false;
            this.presetTip.SetToolTip(this.colorslider1, "Drag to resize the selection");
            this.colorslider1.SelectionChanged += new System.EventHandler(this.colorslider1_SelectionChanged);
            this.colorslider1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.colorslider1_MouseDown);
            this.colorslider1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.colorslider1_MouseUp);
            // 
            // colorslider_simple
            // 
            this.colorslider_simple.Location = new System.Drawing.Point(150, 204);
            this.colorslider_simple.Max = 16;
            this.colorslider_simple.Min = 0;
            this.colorslider_simple.Name = "colorslider_simple";
            this.colorslider_simple.SelectedMax = 4;
            this.colorslider_simple.SelectedMin = 0;
            this.colorslider_simple.Size = new System.Drawing.Size(405, 20);
            this.colorslider_simple.TabIndex = 33;
            this.colorslider_simple.TabStop = false;
            this.presetTip.SetToolTip(this.colorslider_simple, "Drag to resize the selection");
            this.colorslider_simple.SelectionChanged += new System.EventHandler(this.colorslider_simple_SelectionChanged);
            this.colorslider_simple.MouseDown += new System.Windows.Forms.MouseEventHandler(this.colorslider_simple_MouseDown);
            this.colorslider_simple.MouseUp += new System.Windows.Forms.MouseEventHandler(this.colorslider_simple_MouseUp);
            // 
            // tabctrl
            // 
            this.tabctrl.AnimationSpeed = 1;
            this.tabctrl.Appearance = System.Windows.Forms.Appearance.Normal;
            this.tabctrl.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.tabctrl.BorderColor = System.Drawing.Color.Empty;
            this.tabctrl.Controls.Add(this._SolidColor);
            this.tabctrl.Controls.Add(this._Color_Cycle);
            this.tabctrl.Controls.Add(this._Breathing);
            this.tabctrl.Controls.Add(this._Disco);
            this.tabctrl.Controls.Add(this._SolidDisco);
            this.tabctrl.Controls.Add(this._MorseCode);
            this.tabctrl.Controls.Add(this._Ambilight);
            this.tabctrl.Controls.Add(this._Schedule);
            this.tabctrl.Controls.Add(this._Other);
            this.tabctrl.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tabctrl.ForeColor = System.Drawing.Color.Black;
            this.tabctrl.HasAnimation = false;
            this.tabctrl.HeaderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(115)))), ((int)(((byte)(124)))));
            this.tabctrl.HeaderItemColor = System.Drawing.Color.White;
            this.tabctrl.HotTrack = true;
            this.tabctrl.HoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(215)))), ((int)(((byte)(156)))));
            this.tabctrl.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(215)))), ((int)(((byte)(156)))));
            this.tabctrl.ImageWidth = 10;
            this.tabctrl.ItemColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(42)))), ((int)(((byte)(71)))));
            this.tabctrl.ItemForeColor = System.Drawing.Color.White;
            this.tabctrl.ItemSize = new System.Drawing.Size(43, 95);
            this.tabctrl.Location = new System.Drawing.Point(-2, 0);
            this.tabctrl.Margin = new System.Windows.Forms.Padding(0);
            this.tabctrl.Multiline = true;
            this.tabctrl.Name = "tabctrl";
            this.tabctrl.Padding = new System.Drawing.Point(0, 0);
            this.tabctrl.SelectedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(215)))), ((int)(((byte)(156)))));
            this.tabctrl.SelectedForeColor = System.Drawing.Color.White;
            this.tabctrl.SelectedIndex = 0;
            this.tabctrl.SelectedItemColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(215)))), ((int)(((byte)(156)))));
            this.tabctrl.SelectedItemLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(215)))), ((int)(((byte)(156)))));
            this.tabctrl.SelectedItemLineWidth = 0;
            this.tabctrl.Size = new System.Drawing.Size(832, 470);
            this.tabctrl.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabctrl.TabContainerColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(42)))), ((int)(((byte)(71)))));
            this.tabctrl.TabIndex = 4;
            this.tabctrl.Tag = "";
            this.tabctrl.DoubleClick += new System.EventHandler(this.tabctrl_DoubleClick);
            // 
            // _SolidColor
            // 
            this._SolidColor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(42)))), ((int)(((byte)(71)))));
            this._SolidColor.Controls.Add(this.powerButton);
            this._SolidColor.Controls.Add(this.colorWheel);
            this._SolidColor.Controls.Add(this.preset3);
            this._SolidColor.Controls.Add(this.brightnessSlide);
            this._SolidColor.Controls.Add(this.preset2);
            this._SolidColor.Controls.Add(this.preset4);
            this._SolidColor.Controls.Add(this.label2);
            this._SolidColor.Controls.Add(this.preset1);
            this._SolidColor.Controls.Add(this.preset0);
            this._SolidColor.Location = new System.Drawing.Point(99, 4);
            this._SolidColor.Margin = new System.Windows.Forms.Padding(0);
            this._SolidColor.Name = "_SolidColor";
            this._SolidColor.Size = new System.Drawing.Size(729, 462);
            this._SolidColor.TabIndex = 0;
            this._SolidColor.Text = "Solid Color";
            // 
            // powerButton
            // 
            this.powerButton.Appearance = System.Windows.Forms.Appearance.Button;
            this.powerButton.AutoSize = true;
            this.powerButton.BackColor = System.Drawing.Color.Transparent;
            this.powerButton.FlatAppearance.BorderSize = 0;
            this.powerButton.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(42)))), ((int)(((byte)(71)))));
            this.powerButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(42)))), ((int)(((byte)(71)))));
            this.powerButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(42)))), ((int)(((byte)(71)))));
            this.powerButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.powerButton.ForeColor = System.Drawing.Color.Transparent;
            this.powerButton.Image = global::ESPRGB_Client.Properties.Resources.power_0;
            this.powerButton.Location = new System.Drawing.Point(471, 318);
            this.powerButton.Margin = new System.Windows.Forms.Padding(0);
            this.powerButton.Name = "powerButton";
            this.powerButton.Size = new System.Drawing.Size(47, 47);
            this.powerButton.TabIndex = 14;
            this.powerButton.TabStop = false;
            this.powerButton.UseVisualStyleBackColor = false;
            this.powerButton.CheckedChanged += new System.EventHandler(this.powerButton_CheckedChanged);
            this.powerButton.Click += new System.EventHandler(this.powerButton_Click);
            // 
            // colorWheel
            // 
            this.colorWheel.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.colorWheel.ColorStep = 1;
            this.colorWheel.Location = new System.Drawing.Point(210, 59);
            this.colorWheel.Name = "colorWheel";
            this.colorWheel.Size = new System.Drawing.Size(310, 306);
            this.colorWheel.TabIndex = 0;
            this.colorWheel.TabStop = false;
            this.colorWheel.ColorChanged += new System.EventHandler(this.colorWheel1_ColorChanged);
            this.colorWheel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.colorWheel_MouseDown);
            this.colorWheel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.colorWheel_MouseUp);
            // 
            // _Color_Cycle
            // 
            this._Color_Cycle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(42)))), ((int)(((byte)(71)))));
            this._Color_Cycle.Controls.Add(this.ColorCycleSpeedText);
            this._Color_Cycle.Controls.Add(this.label6);
            this._Color_Cycle.Controls.Add(this.ColorCycleSpeed);
            this._Color_Cycle.Controls.Add(this.label3);
            this._Color_Cycle.Controls.Add(this.startColorCycle);
            this._Color_Cycle.Location = new System.Drawing.Point(99, 4);
            this._Color_Cycle.Margin = new System.Windows.Forms.Padding(0);
            this._Color_Cycle.Name = "_Color_Cycle";
            this._Color_Cycle.Size = new System.Drawing.Size(729, 462);
            this._Color_Cycle.TabIndex = 1;
            this._Color_Cycle.Text = "Color Cycle";
            this._Color_Cycle.Click += new System.EventHandler(this._Color_Cycle_Click);
            // 
            // startColorCycle
            // 
            this.startColorCycle.Appearance = System.Windows.Forms.Appearance.Button;
            this.startColorCycle.AutoSize = true;
            this.startColorCycle.BackColor = System.Drawing.Color.Transparent;
            this.startColorCycle.FlatAppearance.BorderSize = 0;
            this.startColorCycle.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(42)))), ((int)(((byte)(71)))));
            this.startColorCycle.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(42)))), ((int)(((byte)(71)))));
            this.startColorCycle.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(42)))), ((int)(((byte)(71)))));
            this.startColorCycle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.startColorCycle.ForeColor = System.Drawing.Color.Transparent;
            this.startColorCycle.Image = global::ESPRGB_Client.Properties.Resources.bool_0;
            this.startColorCycle.Location = new System.Drawing.Point(655, 70);
            this.startColorCycle.Name = "startColorCycle";
            this.startColorCycle.Size = new System.Drawing.Size(26, 26);
            this.startColorCycle.TabIndex = 20;
            this.startColorCycle.TabStop = false;
            this.startColorCycle.UseVisualStyleBackColor = false;
            this.startColorCycle.CheckedChanged += new System.EventHandler(this.startColorCycle_CheckedChanged);
            this.startColorCycle.Click += new System.EventHandler(this.startColorCycle_Click);
            // 
            // _Breathing
            // 
            this._Breathing.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(42)))), ((int)(((byte)(71)))));
            this._Breathing.Controls.Add(this.colorBreathing);
            this._Breathing.Controls.Add(this.br_clearColorlist);
            this._Breathing.Controls.Add(this.br_removeLastColor);
            this._Breathing.Controls.Add(this.br_addCurrentColor);
            this._Breathing.Controls.Add(this.useColorList);
            this._Breathing.Controls.Add(this.breathingSpeedText);
            this._Breathing.Controls.Add(this.label8);
            this._Breathing.Controls.Add(this.breathingSpeed);
            this._Breathing.Controls.Add(this.label4);
            this._Breathing.Controls.Add(this.colorListResult);
            this._Breathing.Controls.Add(this.startBreathing);
            this._Breathing.Location = new System.Drawing.Point(99, 4);
            this._Breathing.Margin = new System.Windows.Forms.Padding(0);
            this._Breathing.Name = "_Breathing";
            this._Breathing.Size = new System.Drawing.Size(729, 462);
            this._Breathing.TabIndex = 2;
            this._Breathing.Text = "Breathing";
            // 
            // colorBreathing
            // 
            this.colorBreathing.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.colorBreathing.ColorStep = 1;
            this.colorBreathing.Location = new System.Drawing.Point(261, 160);
            this.colorBreathing.Name = "colorBreathing";
            this.colorBreathing.Size = new System.Drawing.Size(207, 207);
            this.colorBreathing.TabIndex = 34;
            this.colorBreathing.TabStop = false;
            this.colorBreathing.ColorChanged += new System.EventHandler(this.breathing_colorWheel_ColorChanged);
            this.colorBreathing.MouseDown += new System.Windows.Forms.MouseEventHandler(this.breathing_colorWheel_MouseDown);
            this.colorBreathing.MouseUp += new System.Windows.Forms.MouseEventHandler(this.breathing_colorWheel_MouseUp);
            // 
            // br_clearColorlist
            // 
            this.br_clearColorlist.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.br_clearColorlist.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.br_clearColorlist.FlatAppearance.BorderSize = 0;
            this.br_clearColorlist.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.br_clearColorlist.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.br_clearColorlist.ForeColor = System.Drawing.Color.White;
            this.br_clearColorlist.Location = new System.Drawing.Point(611, 160);
            this.br_clearColorlist.Margin = new System.Windows.Forms.Padding(0);
            this.br_clearColorlist.Name = "br_clearColorlist";
            this.br_clearColorlist.Size = new System.Drawing.Size(25, 25);
            this.br_clearColorlist.TabIndex = 32;
            this.br_clearColorlist.TabStop = false;
            this.br_clearColorlist.Text = "C";
            this.br_clearColorlist.UseMnemonic = false;
            this.br_clearColorlist.UseVisualStyleBackColor = false;
            this.br_clearColorlist.Click += new System.EventHandler(this.br_clearColorlist_Click);
            // 
            // br_removeLastColor
            // 
            this.br_removeLastColor.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.br_removeLastColor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(57)))), ((int)(((byte)(43)))));
            this.br_removeLastColor.FlatAppearance.BorderSize = 0;
            this.br_removeLastColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.br_removeLastColor.Font = new System.Drawing.Font("Segoe UI Black", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.br_removeLastColor.ForeColor = System.Drawing.Color.White;
            this.br_removeLastColor.Location = new System.Drawing.Point(576, 160);
            this.br_removeLastColor.Margin = new System.Windows.Forms.Padding(0);
            this.br_removeLastColor.Name = "br_removeLastColor";
            this.br_removeLastColor.Size = new System.Drawing.Size(25, 25);
            this.br_removeLastColor.TabIndex = 31;
            this.br_removeLastColor.TabStop = false;
            this.br_removeLastColor.Text = "-";
            this.br_removeLastColor.UseMnemonic = false;
            this.br_removeLastColor.UseVisualStyleBackColor = false;
            this.br_removeLastColor.Click += new System.EventHandler(this.br_removeLastColor_Click);
            // 
            // br_addCurrentColor
            // 
            this.br_addCurrentColor.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.br_addCurrentColor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(215)))), ((int)(((byte)(156)))));
            this.br_addCurrentColor.FlatAppearance.BorderSize = 0;
            this.br_addCurrentColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.br_addCurrentColor.Font = new System.Drawing.Font("Segoe UI Black", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.br_addCurrentColor.ForeColor = System.Drawing.Color.White;
            this.br_addCurrentColor.Location = new System.Drawing.Point(541, 160);
            this.br_addCurrentColor.Margin = new System.Windows.Forms.Padding(0);
            this.br_addCurrentColor.Name = "br_addCurrentColor";
            this.br_addCurrentColor.Size = new System.Drawing.Size(25, 25);
            this.br_addCurrentColor.TabIndex = 30;
            this.br_addCurrentColor.TabStop = false;
            this.br_addCurrentColor.Text = "+";
            this.br_addCurrentColor.UseMnemonic = false;
            this.br_addCurrentColor.UseVisualStyleBackColor = false;
            this.br_addCurrentColor.Click += new System.EventHandler(this.br_addCurrentColor_Click);
            // 
            // useColorList
            // 
            this.useColorList.AutoSize = true;
            this.useColorList.ForeColor = System.Drawing.Color.White;
            this.useColorList.Location = new System.Drawing.Point(490, 98);
            this.useColorList.Name = "useColorList";
            this.useColorList.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.useColorList.Size = new System.Drawing.Size(98, 19);
            this.useColorList.TabIndex = 28;
            this.useColorList.TabStop = false;
            this.useColorList.Text = "Use Color List";
            this.useColorList.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.useColorList.UseVisualStyleBackColor = true;
            this.useColorList.Click += new System.EventHandler(this.useColorList_Click);
            // 
            // colorListResult
            // 
            this.colorListResult.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(32)))), ((int)(((byte)(54)))));
            this.colorListResult.Location = new System.Drawing.Point(49, 124);
            this.colorListResult.Name = "colorListResult";
            this.colorListResult.Size = new System.Drawing.Size(603, 30);
            this.colorListResult.TabIndex = 33;
            this.colorListResult.TabStop = false;
            // 
            // startBreathing
            // 
            this.startBreathing.Appearance = System.Windows.Forms.Appearance.Button;
            this.startBreathing.AutoSize = true;
            this.startBreathing.BackColor = System.Drawing.Color.Transparent;
            this.startBreathing.FlatAppearance.BorderSize = 0;
            this.startBreathing.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(42)))), ((int)(((byte)(71)))));
            this.startBreathing.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(42)))), ((int)(((byte)(71)))));
            this.startBreathing.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(42)))), ((int)(((byte)(71)))));
            this.startBreathing.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.startBreathing.ForeColor = System.Drawing.Color.Transparent;
            this.startBreathing.Image = global::ESPRGB_Client.Properties.Resources.bool_0;
            this.startBreathing.Location = new System.Drawing.Point(655, 70);
            this.startBreathing.Name = "startBreathing";
            this.startBreathing.Size = new System.Drawing.Size(26, 26);
            this.startBreathing.TabIndex = 24;
            this.startBreathing.TabStop = false;
            this.startBreathing.UseVisualStyleBackColor = false;
            this.startBreathing.CheckedChanged += new System.EventHandler(this.startBreathing_CheckedChanged);
            this.startBreathing.Click += new System.EventHandler(this.startBreathing_Click);
            // 
            // _Disco
            // 
            this._Disco.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(42)))), ((int)(((byte)(71)))));
            this._Disco.Controls.Add(this.startDisco);
            this._Disco.Controls.Add(this.label15);
            this._Disco.Controls.Add(this.highsBrightness);
            this._Disco.Controls.Add(this.label14);
            this._Disco.Controls.Add(this.midsBrightness);
            this._Disco.Controls.Add(this.label13);
            this._Disco.Controls.Add(this.lowsBrightness);
            this._Disco.Controls.Add(this.label10);
            this._Disco.Controls.Add(this.label9);
            this._Disco.Controls.Add(this.label7);
            this._Disco.Controls.Add(this.highSensitivity);
            this._Disco.Controls.Add(this.midSensitivity);
            this._Disco.Controls.Add(this.lowSensitivity);
            this._Disco.Controls.Add(this.selectionColor);
            this._Disco.Controls.Add(this.sel_black);
            this._Disco.Controls.Add(this.sel_blue);
            this._Disco.Controls.Add(this.sel_green);
            this._Disco.Controls.Add(this.sel_red);
            this._Disco.Controls.Add(this.label5);
            this._Disco.Controls.Add(this.ResultColor);
            this._Disco.Controls.Add(this.pictureBoxTop);
            this._Disco.Controls.Add(this.colorslider1);
            this._Disco.Location = new System.Drawing.Point(99, 4);
            this._Disco.Margin = new System.Windows.Forms.Padding(0);
            this._Disco.Name = "_Disco";
            this._Disco.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this._Disco.Size = new System.Drawing.Size(729, 462);
            this._Disco.TabIndex = 3;
            this._Disco.Text = "Disco";
            // 
            // startDisco
            // 
            this.startDisco.AutoSize = true;
            this.startDisco.ForeColor = System.Drawing.Color.White;
            this.startDisco.Location = new System.Drawing.Point(473, 270);
            this.startDisco.Name = "startDisco";
            this.startDisco.Size = new System.Drawing.Size(82, 19);
            this.startDisco.TabIndex = 70;
            this.startDisco.Text = "Start Disco";
            this.startDisco.UseVisualStyleBackColor = true;
            this.startDisco.CheckedChanged += new System.EventHandler(this.startDisco_CheckedChanged);
            this.startDisco.Click += new System.EventHandler(this.startDisco_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.White;
            this.label15.Location = new System.Drawing.Point(436, 349);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(106, 17);
            this.label15.TabIndex = 67;
            this.label15.Text = "Highs brightness";
            // 
            // highsBrightness
            // 
            this.highsBrightness.BackColor = System.Drawing.Color.Transparent;
            this.highsBrightness.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.highsBrightness.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(98)))), ((int)(((byte)(98)))));
            this.highsBrightness.GradientColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(215)))), ((int)(((byte)(215)))));
            this.highsBrightness.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(215)))), ((int)(((byte)(156)))));
            this.highsBrightness.LeftColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(215)))), ((int)(((byte)(156)))));
            this.highsBrightness.Location = new System.Drawing.Point(423, 370);
            this.highsBrightness.Name = "highsBrightness";
            this.highsBrightness.RailWidth = 20;
            this.highsBrightness.RegionColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(215)))), ((int)(((byte)(156)))));
            this.highsBrightness.RightColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.highsBrightness.Size = new System.Drawing.Size(130, 16);
            this.highsBrightness.SliderColor = System.Drawing.Color.White;
            this.highsBrightness.TabIndex = 66;
            this.highsBrightness.TabStop = false;
            this.highsBrightness.Value = 100;
            this.highsBrightness.Scroll += new Zeroit.Framework.Metro.ZeroitMetroTrackbar.ScrollEventHandler(this.highsBrightness_Scroll);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.White;
            this.label14.Location = new System.Drawing.Point(300, 350);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(102, 17);
            this.label14.TabIndex = 65;
            this.label14.Text = "Mids brightness";
            // 
            // midsBrightness
            // 
            this.midsBrightness.BackColor = System.Drawing.Color.Transparent;
            this.midsBrightness.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.midsBrightness.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(98)))), ((int)(((byte)(98)))));
            this.midsBrightness.GradientColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(215)))), ((int)(((byte)(215)))));
            this.midsBrightness.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(215)))), ((int)(((byte)(156)))));
            this.midsBrightness.LeftColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(215)))), ((int)(((byte)(156)))));
            this.midsBrightness.Location = new System.Drawing.Point(287, 370);
            this.midsBrightness.Name = "midsBrightness";
            this.midsBrightness.RailWidth = 20;
            this.midsBrightness.RegionColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(215)))), ((int)(((byte)(156)))));
            this.midsBrightness.RightColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.midsBrightness.Size = new System.Drawing.Size(130, 16);
            this.midsBrightness.SliderColor = System.Drawing.Color.White;
            this.midsBrightness.TabIndex = 64;
            this.midsBrightness.TabStop = false;
            this.midsBrightness.Value = 100;
            this.midsBrightness.Scroll += new Zeroit.Framework.Metro.ZeroitMetroTrackbar.ScrollEventHandler(this.midsBrightness_Scroll);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(164, 349);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(102, 17);
            this.label13.TabIndex = 63;
            this.label13.Text = "Lows brightness";
            // 
            // lowsBrightness
            // 
            this.lowsBrightness.BackColor = System.Drawing.Color.Transparent;
            this.lowsBrightness.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.lowsBrightness.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(98)))), ((int)(((byte)(98)))));
            this.lowsBrightness.GradientColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(215)))), ((int)(((byte)(215)))));
            this.lowsBrightness.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(215)))), ((int)(((byte)(156)))));
            this.lowsBrightness.LeftColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(215)))), ((int)(((byte)(156)))));
            this.lowsBrightness.Location = new System.Drawing.Point(150, 370);
            this.lowsBrightness.Name = "lowsBrightness";
            this.lowsBrightness.RailWidth = 20;
            this.lowsBrightness.RegionColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(215)))), ((int)(((byte)(156)))));
            this.lowsBrightness.RightColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.lowsBrightness.Size = new System.Drawing.Size(130, 16);
            this.lowsBrightness.SliderColor = System.Drawing.Color.White;
            this.lowsBrightness.TabIndex = 62;
            this.lowsBrightness.TabStop = false;
            this.lowsBrightness.Value = 100;
            this.lowsBrightness.Scroll += new Zeroit.Framework.Metro.ZeroitMetroTrackbar.ScrollEventHandler(this.lowsBrightness_Scroll);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(306, 302);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(96, 17);
            this.label10.TabIndex = 61;
            this.label10.Text = "Mids sensitivity";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(438, 300);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(100, 17);
            this.label9.TabIndex = 60;
            this.label9.Text = "Highs sensitivity";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(169, 300);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(96, 17);
            this.label7.TabIndex = 59;
            this.label7.Text = "Lows sensitivity";
            // 
            // highSensitivity
            // 
            this.highSensitivity.BackColor = System.Drawing.Color.Transparent;
            this.highSensitivity.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.highSensitivity.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(98)))), ((int)(((byte)(98)))));
            this.highSensitivity.GradientColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(215)))), ((int)(((byte)(215)))));
            this.highSensitivity.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(215)))), ((int)(((byte)(156)))));
            this.highSensitivity.LeftColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(215)))), ((int)(((byte)(156)))));
            this.highSensitivity.Location = new System.Drawing.Point(423, 322);
            this.highSensitivity.Maximum = 255;
            this.highSensitivity.Name = "highSensitivity";
            this.highSensitivity.RailWidth = 20;
            this.highSensitivity.RegionColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(215)))), ((int)(((byte)(156)))));
            this.highSensitivity.RightColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.highSensitivity.Size = new System.Drawing.Size(130, 16);
            this.highSensitivity.SliderColor = System.Drawing.Color.White;
            this.highSensitivity.TabIndex = 58;
            this.highSensitivity.TabStop = false;
            this.highSensitivity.Value = 25;
            this.highSensitivity.Scroll += new Zeroit.Framework.Metro.ZeroitMetroTrackbar.ScrollEventHandler(this.discoSensitivity);
            // 
            // midSensitivity
            // 
            this.midSensitivity.BackColor = System.Drawing.Color.Transparent;
            this.midSensitivity.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.midSensitivity.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(98)))), ((int)(((byte)(98)))));
            this.midSensitivity.GradientColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(215)))), ((int)(((byte)(215)))));
            this.midSensitivity.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(215)))), ((int)(((byte)(156)))));
            this.midSensitivity.LeftColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(215)))), ((int)(((byte)(156)))));
            this.midSensitivity.Location = new System.Drawing.Point(287, 322);
            this.midSensitivity.Maximum = 255;
            this.midSensitivity.Name = "midSensitivity";
            this.midSensitivity.RailWidth = 20;
            this.midSensitivity.RegionColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(215)))), ((int)(((byte)(156)))));
            this.midSensitivity.RightColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.midSensitivity.Size = new System.Drawing.Size(130, 16);
            this.midSensitivity.SliderColor = System.Drawing.Color.White;
            this.midSensitivity.TabIndex = 57;
            this.midSensitivity.TabStop = false;
            this.midSensitivity.Value = 5;
            this.midSensitivity.Scroll += new Zeroit.Framework.Metro.ZeroitMetroTrackbar.ScrollEventHandler(this.discoSensitivity);
            // 
            // lowSensitivity
            // 
            this.lowSensitivity.BackColor = System.Drawing.Color.Transparent;
            this.lowSensitivity.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.lowSensitivity.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(98)))), ((int)(((byte)(98)))));
            this.lowSensitivity.GradientColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(215)))), ((int)(((byte)(215)))));
            this.lowSensitivity.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(215)))), ((int)(((byte)(156)))));
            this.lowSensitivity.LeftColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(215)))), ((int)(((byte)(156)))));
            this.lowSensitivity.Location = new System.Drawing.Point(150, 322);
            this.lowSensitivity.Maximum = 255;
            this.lowSensitivity.Name = "lowSensitivity";
            this.lowSensitivity.RailWidth = 20;
            this.lowSensitivity.RegionColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(215)))), ((int)(((byte)(156)))));
            this.lowSensitivity.RightColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.lowSensitivity.Size = new System.Drawing.Size(130, 16);
            this.lowSensitivity.SliderColor = System.Drawing.Color.White;
            this.lowSensitivity.TabIndex = 56;
            this.lowSensitivity.TabStop = false;
            this.lowSensitivity.Value = 160;
            this.lowSensitivity.Scroll += new Zeroit.Framework.Metro.ZeroitMetroTrackbar.ScrollEventHandler(this.discoSensitivity);
            // 
            // selectionColor
            // 
            this.selectionColor.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.selectionColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.selectionColor.Items.AddRange(new object[] {
            "Lows",
            "Mids",
            "Highs"});
            this.selectionColor.Location = new System.Drawing.Point(150, 266);
            this.selectionColor.Name = "selectionColor";
            this.selectionColor.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.selectionColor.Size = new System.Drawing.Size(122, 23);
            this.selectionColor.TabIndex = 55;
            this.selectionColor.TabStop = false;
            // 
            // sel_black
            // 
            this.sel_black.BackColor = System.Drawing.Color.Black;
            this.sel_black.FlatAppearance.BorderSize = 0;
            this.sel_black.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sel_black.ForeColor = System.Drawing.Color.White;
            this.sel_black.Location = new System.Drawing.Point(384, 266);
            this.sel_black.Name = "sel_black";
            this.sel_black.Size = new System.Drawing.Size(33, 25);
            this.sel_black.TabIndex = 45;
            this.sel_black.TabStop = false;
            this.sel_black.Text = "No";
            this.sel_black.UseVisualStyleBackColor = false;
            this.sel_black.Click += new System.EventHandler(this.sel_Click);
            // 
            // sel_blue
            // 
            this.sel_blue.BackColor = System.Drawing.Color.Blue;
            this.sel_blue.FlatAppearance.BorderSize = 0;
            this.sel_blue.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sel_blue.ForeColor = System.Drawing.Color.White;
            this.sel_blue.Location = new System.Drawing.Point(349, 266);
            this.sel_blue.Name = "sel_blue";
            this.sel_blue.Size = new System.Drawing.Size(25, 25);
            this.sel_blue.TabIndex = 37;
            this.sel_blue.TabStop = false;
            this.sel_blue.Text = "B";
            this.sel_blue.UseVisualStyleBackColor = false;
            this.sel_blue.Click += new System.EventHandler(this.sel_Click);
            // 
            // sel_green
            // 
            this.sel_green.BackColor = System.Drawing.Color.Lime;
            this.sel_green.FlatAppearance.BorderSize = 0;
            this.sel_green.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sel_green.ForeColor = System.Drawing.Color.White;
            this.sel_green.Location = new System.Drawing.Point(314, 266);
            this.sel_green.Name = "sel_green";
            this.sel_green.Size = new System.Drawing.Size(25, 25);
            this.sel_green.TabIndex = 36;
            this.sel_green.TabStop = false;
            this.sel_green.Text = "G";
            this.sel_green.UseVisualStyleBackColor = false;
            this.sel_green.Click += new System.EventHandler(this.sel_Click);
            // 
            // sel_red
            // 
            this.sel_red.BackColor = System.Drawing.Color.Red;
            this.sel_red.FlatAppearance.BorderSize = 0;
            this.sel_red.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sel_red.ForeColor = System.Drawing.Color.White;
            this.sel_red.Location = new System.Drawing.Point(279, 266);
            this.sel_red.Name = "sel_red";
            this.sel_red.Size = new System.Drawing.Size(25, 25);
            this.sel_red.TabIndex = 35;
            this.sel_red.TabStop = false;
            this.sel_red.Text = "R";
            this.sel_red.UseVisualStyleBackColor = false;
            this.sel_red.Click += new System.EventHandler(this.sel_Click);
            // 
            // ResultColor
            // 
            this.ResultColor.Location = new System.Drawing.Point(150, 235);
            this.ResultColor.Name = "ResultColor";
            this.ResultColor.Size = new System.Drawing.Size(404, 20);
            this.ResultColor.TabIndex = 44;
            this.ResultColor.TabStop = false;
            // 
            // pictureBoxTop
            // 
            this.pictureBoxTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(32)))), ((int)(((byte)(54)))));
            this.pictureBoxTop.Location = new System.Drawing.Point(150, 74);
            this.pictureBoxTop.Name = "pictureBoxTop";
            this.pictureBoxTop.Size = new System.Drawing.Size(405, 127);
            this.pictureBoxTop.TabIndex = 30;
            this.pictureBoxTop.TabStop = false;
            // 
            // _SolidDisco
            // 
            this._SolidDisco.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(42)))), ((int)(((byte)(71)))));
            this._SolidDisco.Controls.Add(this.colorWheel_SolidDisco);
            this._SolidDisco.Controls.Add(this.randomColor);
            this._SolidDisco.Controls.Add(this.label11);
            this._SolidDisco.Controls.Add(this.solidDiscoSensitivity);
            this._SolidDisco.Controls.Add(this.startSolidDisco);
            this._SolidDisco.Controls.Add(this.label1);
            this._SolidDisco.Controls.Add(this.colorslider_simple);
            this._SolidDisco.Controls.Add(this.SolidDiscoVisualizer);
            this._SolidDisco.Location = new System.Drawing.Point(99, 4);
            this._SolidDisco.Margin = new System.Windows.Forms.Padding(0);
            this._SolidDisco.Name = "_SolidDisco";
            this._SolidDisco.Size = new System.Drawing.Size(729, 462);
            this._SolidDisco.TabIndex = 5;
            this._SolidDisco.Text = "Solid Disco";
            // 
            // colorWheel_SolidDisco
            // 
            this.colorWheel_SolidDisco.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.colorWheel_SolidDisco.ColorStep = 1;
            this.colorWheel_SolidDisco.Location = new System.Drawing.Point(253, 232);
            this.colorWheel_SolidDisco.Name = "colorWheel_SolidDisco";
            this.colorWheel_SolidDisco.Size = new System.Drawing.Size(170, 170);
            this.colorWheel_SolidDisco.TabIndex = 63;
            this.colorWheel_SolidDisco.TabStop = false;
            this.colorWheel_SolidDisco.ColorChanged += new System.EventHandler(this.colorWheel_SolidDisco_ColorChanged);
            this.colorWheel_SolidDisco.MouseDown += new System.Windows.Forms.MouseEventHandler(this.colorWheel_SolidDisco_MouseDown);
            this.colorWheel_SolidDisco.MouseUp += new System.Windows.Forms.MouseEventHandler(this.colorWheel_SolidDisco_MouseUp);
            // 
            // randomColor
            // 
            this.randomColor.AutoSize = true;
            this.randomColor.ForeColor = System.Drawing.Color.White;
            this.randomColor.Location = new System.Drawing.Point(452, 260);
            this.randomColor.Name = "randomColor";
            this.randomColor.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.randomColor.Size = new System.Drawing.Size(103, 19);
            this.randomColor.TabIndex = 62;
            this.randomColor.TabStop = false;
            this.randomColor.Text = "Random Color";
            this.randomColor.UseVisualStyleBackColor = true;
            this.randomColor.Click += new System.EventHandler(this.randomColor_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(491, 284);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(64, 17);
            this.label11.TabIndex = 61;
            this.label11.Text = "Sensitivity";
            // 
            // solidDiscoSensitivity
            // 
            this.solidDiscoSensitivity.BackColor = System.Drawing.Color.Transparent;
            this.solidDiscoSensitivity.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.solidDiscoSensitivity.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(98)))), ((int)(((byte)(98)))));
            this.solidDiscoSensitivity.GradientColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(215)))), ((int)(((byte)(215)))));
            this.solidDiscoSensitivity.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(215)))), ((int)(((byte)(156)))));
            this.solidDiscoSensitivity.LeftColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(215)))), ((int)(((byte)(156)))));
            this.solidDiscoSensitivity.Location = new System.Drawing.Point(444, 305);
            this.solidDiscoSensitivity.Maximum = 255;
            this.solidDiscoSensitivity.Name = "solidDiscoSensitivity";
            this.solidDiscoSensitivity.RailWidth = 20;
            this.solidDiscoSensitivity.RegionColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(215)))), ((int)(((byte)(156)))));
            this.solidDiscoSensitivity.RightColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.solidDiscoSensitivity.Size = new System.Drawing.Size(111, 16);
            this.solidDiscoSensitivity.SliderColor = System.Drawing.Color.White;
            this.solidDiscoSensitivity.TabIndex = 60;
            this.solidDiscoSensitivity.TabStop = false;
            this.solidDiscoSensitivity.Value = 10;
            this.solidDiscoSensitivity.Scroll += new Zeroit.Framework.Metro.ZeroitMetroTrackbar.ScrollEventHandler(this.solidDiscoSensitivity_Scroll);
            // 
            // startSolidDisco
            // 
            this.startSolidDisco.AutoSize = true;
            this.startSolidDisco.ForeColor = System.Drawing.Color.White;
            this.startSolidDisco.Location = new System.Drawing.Point(444, 233);
            this.startSolidDisco.Name = "startSolidDisco";
            this.startSolidDisco.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.startSolidDisco.Size = new System.Drawing.Size(111, 19);
            this.startSolidDisco.TabIndex = 34;
            this.startSolidDisco.TabStop = false;
            this.startSolidDisco.Text = "Start Solid Disco";
            this.startSolidDisco.UseVisualStyleBackColor = true;
            this.startSolidDisco.CheckedChanged += new System.EventHandler(this.startSolidDisco_CheckedChanged);
            this.startSolidDisco.Click += new System.EventHandler(this.startSolidDisco_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(10, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 20);
            this.label1.TabIndex = 18;
            this.label1.Tag = "DontDisable";
            this.label1.Text = "Solid Disco";
            // 
            // SolidDiscoVisualizer
            // 
            this.SolidDiscoVisualizer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(32)))), ((int)(((byte)(54)))));
            this.SolidDiscoVisualizer.Location = new System.Drawing.Point(150, 69);
            this.SolidDiscoVisualizer.Name = "SolidDiscoVisualizer";
            this.SolidDiscoVisualizer.Size = new System.Drawing.Size(405, 127);
            this.SolidDiscoVisualizer.TabIndex = 31;
            this.SolidDiscoVisualizer.TabStop = false;
            // 
            // _MorseCode
            // 
            this._MorseCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(42)))), ((int)(((byte)(71)))));
            this._MorseCode.Controls.Add(this.morseColor);
            this._MorseCode.Controls.Add(this.useBuzzer);
            this._MorseCode.Controls.Add(this.unitTime);
            this._MorseCode.Controls.Add(this.label18);
            this._MorseCode.Controls.Add(this.label17);
            this._MorseCode.Controls.Add(this.encodedMsgResult);
            this._MorseCode.Controls.Add(this.label16);
            this._MorseCode.Controls.Add(this.morsePlainText);
            this._MorseCode.Controls.Add(this.startMorseCode);
            this._MorseCode.Controls.Add(this.label12);
            this._MorseCode.Location = new System.Drawing.Point(99, 4);
            this._MorseCode.Margin = new System.Windows.Forms.Padding(0);
            this._MorseCode.Name = "_MorseCode";
            this._MorseCode.Size = new System.Drawing.Size(729, 462);
            this._MorseCode.TabIndex = 6;
            this._MorseCode.Text = "Morse Code";
            // 
            // morseColor
            // 
            this.morseColor.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.morseColor.ColorStep = 1;
            this.morseColor.Location = new System.Drawing.Point(456, 112);
            this.morseColor.Name = "morseColor";
            this.morseColor.Size = new System.Drawing.Size(198, 198);
            this.morseColor.TabIndex = 66;
            this.morseColor.TabStop = false;
            this.morseColor.ColorChanged += new System.EventHandler(this.morseColor_ColorChanged);
            this.morseColor.MouseDown += new System.Windows.Forms.MouseEventHandler(this.morseColor_MouseDown);
            this.morseColor.MouseUp += new System.Windows.Forms.MouseEventHandler(this.morseColor_MouseUp);
            // 
            // useBuzzer
            // 
            this.useBuzzer.AutoSize = true;
            this.useBuzzer.ForeColor = System.Drawing.Color.White;
            this.useBuzzer.Location = new System.Drawing.Point(248, 295);
            this.useBuzzer.Name = "useBuzzer";
            this.useBuzzer.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.useBuzzer.Size = new System.Drawing.Size(82, 19);
            this.useBuzzer.TabIndex = 65;
            this.useBuzzer.TabStop = false;
            this.useBuzzer.Text = "Use buzzer";
            this.useBuzzer.UseVisualStyleBackColor = true;
            this.useBuzzer.Click += new System.EventHandler(this.useBuzzer_Click);
            // 
            // unitTime
            // 
            this.unitTime.BackColor = System.Drawing.Color.Transparent;
            this.unitTime.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.unitTime.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(98)))), ((int)(((byte)(98)))));
            this.unitTime.GradientColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(215)))), ((int)(((byte)(215)))));
            this.unitTime.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(215)))), ((int)(((byte)(156)))));
            this.unitTime.LeftColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(215)))), ((int)(((byte)(156)))));
            this.unitTime.Location = new System.Drawing.Point(132, 294);
            this.unitTime.Maximum = 550;
            this.unitTime.Minimum = 35;
            this.unitTime.Name = "unitTime";
            this.unitTime.RailWidth = 20;
            this.unitTime.RegionColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(215)))), ((int)(((byte)(156)))));
            this.unitTime.RightColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.unitTime.Size = new System.Drawing.Size(110, 16);
            this.unitTime.SliderColor = System.Drawing.Color.White;
            this.unitTime.TabIndex = 64;
            this.unitTime.TabStop = false;
            this.unitTime.Value = 35;
            this.unitTime.MouseUp += new System.Windows.Forms.MouseEventHandler(this.unitTime_MouseUp);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.Color.White;
            this.label18.Location = new System.Drawing.Point(80, 294);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(45, 17);
            this.label18.TabIndex = 63;
            this.label18.Text = "Speed";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.White;
            this.label17.Location = new System.Drawing.Point(79, 187);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(132, 20);
            this.label17.TabIndex = 39;
            this.label17.Tag = "DontDisable";
            this.label17.Text = "Encoded message:";
            // 
            // encodedMsgResult
            // 
            this.encodedMsgResult.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(32)))), ((int)(((byte)(54)))));
            this.encodedMsgResult.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.encodedMsgResult.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.encodedMsgResult.ForeColor = System.Drawing.Color.White;
            this.encodedMsgResult.Location = new System.Drawing.Point(83, 212);
            this.encodedMsgResult.Margin = new System.Windows.Forms.Padding(0);
            this.encodedMsgResult.MaxLength = 200;
            this.encodedMsgResult.Multiline = true;
            this.encodedMsgResult.Name = "encodedMsgResult";
            this.encodedMsgResult.ReadOnly = true;
            this.encodedMsgResult.Size = new System.Drawing.Size(370, 70);
            this.encodedMsgResult.TabIndex = 38;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.White;
            this.label16.Location = new System.Drawing.Point(79, 87);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(106, 20);
            this.label16.TabIndex = 37;
            this.label16.Tag = "DontDisable";
            this.label16.Text = "Plain message:";
            // 
            // morsePlainText
            // 
            this.morsePlainText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(32)))), ((int)(((byte)(54)))));
            this.morsePlainText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.morsePlainText.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.morsePlainText.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.morsePlainText.ForeColor = System.Drawing.Color.White;
            this.morsePlainText.Location = new System.Drawing.Point(83, 112);
            this.morsePlainText.Margin = new System.Windows.Forms.Padding(0);
            this.morsePlainText.MaxLength = 75;
            this.morsePlainText.Multiline = true;
            this.morsePlainText.Name = "morsePlainText";
            this.morsePlainText.Size = new System.Drawing.Size(370, 70);
            this.morsePlainText.TabIndex = 36;
            this.morsePlainText.KeyUp += new System.Windows.Forms.KeyEventHandler(this.morsePlainText_KeyUp);
            // 
            // startMorseCode
            // 
            this.startMorseCode.AutoSize = true;
            this.startMorseCode.ForeColor = System.Drawing.Color.White;
            this.startMorseCode.Location = new System.Drawing.Point(336, 295);
            this.startMorseCode.Name = "startMorseCode";
            this.startMorseCode.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.startMorseCode.Size = new System.Drawing.Size(117, 19);
            this.startMorseCode.TabIndex = 35;
            this.startMorseCode.TabStop = false;
            this.startMorseCode.Text = "Start Morse Code";
            this.startMorseCode.UseVisualStyleBackColor = true;
            this.startMorseCode.Click += new System.EventHandler(this.startMorseCode_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(10, 10);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(89, 20);
            this.label12.TabIndex = 16;
            this.label12.Tag = "DontDisable";
            this.label12.Text = "Morse Code";
            // 
            // _Ambilight
            // 
            this._Ambilight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(42)))), ((int)(((byte)(71)))));
            this._Ambilight.Controls.Add(this.screenSampler);
            this._Ambilight.Controls.Add(this.startAmbilight);
            this._Ambilight.Controls.Add(this.ambilightSpeed);
            this._Ambilight.Controls.Add(this.label21);
            this._Ambilight.Location = new System.Drawing.Point(99, 4);
            this._Ambilight.Margin = new System.Windows.Forms.Padding(0);
            this._Ambilight.Name = "_Ambilight";
            this._Ambilight.Size = new System.Drawing.Size(729, 462);
            this._Ambilight.TabIndex = 7;
            this._Ambilight.Text = "Ambilight";
            // 
            // screenSampler
            // 
            this.screenSampler.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(32)))), ((int)(((byte)(54)))));
            this.screenSampler.enable = false;
            this.screenSampler.Location = new System.Drawing.Point(14, 38);
            this.screenSampler.Margin = new System.Windows.Forms.Padding(0);
            this.screenSampler.Name = "screenSampler";
            this.screenSampler.ScreenColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(47)))), ((int)(((byte)(52)))));
            this.screenSampler.selectedScreen = 0;
            this.screenSampler.Size = new System.Drawing.Size(700, 385);
            this.screenSampler.TabIndex = 37;
            this.screenSampler.OnColorChanged += new System.EventHandler<System.Drawing.Color>(this.screenSampler_OnColorChanged);
            this.screenSampler.OnScreenChanged += new System.EventHandler(this.screenSampler_OnScreenChanged);
            // 
            // startAmbilight
            // 
            this.startAmbilight.AutoSize = true;
            this.startAmbilight.ForeColor = System.Drawing.Color.White;
            this.startAmbilight.Location = new System.Drawing.Point(608, 433);
            this.startAmbilight.Name = "startAmbilight";
            this.startAmbilight.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.startAmbilight.Size = new System.Drawing.Size(106, 19);
            this.startAmbilight.TabIndex = 36;
            this.startAmbilight.TabStop = false;
            this.startAmbilight.Text = "Start Ambilight";
            this.startAmbilight.UseVisualStyleBackColor = true;
            this.startAmbilight.CheckedChanged += new System.EventHandler(this.startAmbilight_CheckedChanged);
            this.startAmbilight.Click += new System.EventHandler(this.startAmbilight_Click);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.Color.White;
            this.label21.Location = new System.Drawing.Point(10, 10);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(75, 20);
            this.label21.TabIndex = 18;
            this.label21.Tag = "DontDisable";
            this.label21.Text = "Ambilight";
            // 
            // _Schedule
            // 
            this._Schedule.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(42)))), ((int)(((byte)(71)))));
            this._Schedule.Controls.Add(this.timeScheduleList);
            this._Schedule.Controls.Add(this.label24);
            this._Schedule.Controls.Add(this.label23);
            this._Schedule.Controls.Add(this.enableTimeSchedule);
            this._Schedule.Controls.Add(this.addNewTimeSchedule);
            this._Schedule.Controls.Add(this.label22);
            this._Schedule.Controls.Add(this.label20);
            this._Schedule.Controls.Add(this.enableAppSchedule);
            this._Schedule.Controls.Add(this.addNewAppSchedule);
            this._Schedule.Controls.Add(this.label19);
            this._Schedule.Controls.Add(this.appScheduleList);
            this._Schedule.Location = new System.Drawing.Point(99, 4);
            this._Schedule.Margin = new System.Windows.Forms.Padding(0);
            this._Schedule.Name = "_Schedule";
            this._Schedule.Size = new System.Drawing.Size(729, 462);
            this._Schedule.TabIndex = 7;
            this._Schedule.Tag = "NotAnimationTab";
            this._Schedule.Text = "Schedule";
            // 
            // timeScheduleList
            // 
            this.timeScheduleList.AutoScroll = true;
            this.timeScheduleList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(32)))), ((int)(((byte)(54)))));
            this.timeScheduleList.Location = new System.Drawing.Point(80, 55);
            this.timeScheduleList.Margin = new System.Windows.Forms.Padding(0);
            this.timeScheduleList.Name = "timeScheduleList";
            this.timeScheduleList.selectIndex = -1;
            this.timeScheduleList.Size = new System.Drawing.Size(480, 180);
            this.timeScheduleList.TabIndex = 31;
            this.timeScheduleList.timeScheduleRemoved += new System.EventHandler<Newtonsoft.Json.Linq.JObject>(this.timeScheduleList_timeScheduleRemoved);
            this.timeScheduleList.timeScheduleEdit += new System.EventHandler<Newtonsoft.Json.Linq.JObject>(this.timeScheduleList_timeScheduleEdit);
            this.timeScheduleList.timeScheduleEnable += new System.EventHandler<Newtonsoft.Json.Linq.JObject>(this.timeScheduleList_timeScheduleEnable);
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.ForeColor = System.Drawing.Color.White;
            this.label24.Location = new System.Drawing.Point(76, 243);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(102, 20);
            this.label24.TabIndex = 30;
            this.label24.Tag = "DontDisable";
            this.label24.Text = "App schedule:";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.ForeColor = System.Drawing.Color.White;
            this.label23.Location = new System.Drawing.Point(574, 167);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(42, 15);
            this.label23.TabIndex = 29;
            this.label23.Tag = "DontDisable";
            this.label23.Text = "Enable";
            // 
            // enableTimeSchedule
            // 
            this.enableTimeSchedule.BackColor = System.Drawing.Color.Transparent;
            this.enableTimeSchedule.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.enableTimeSchedule.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(98)))), ((int)(((byte)(98)))));
            this.enableTimeSchedule.CheckColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(98)))), ((int)(((byte)(98)))));
            this.enableTimeSchedule.DefaultColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(215)))), ((int)(((byte)(156)))));
            this.enableTimeSchedule.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.enableTimeSchedule.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(98)))), ((int)(((byte)(98)))));
            this.enableTimeSchedule.Location = new System.Drawing.Point(618, 164);
            this.enableTimeSchedule.Name = "enableTimeSchedule";
            this.enableTimeSchedule.Size = new System.Drawing.Size(41, 23);
            this.enableTimeSchedule.SwitchColor = System.Drawing.Color.White;
            this.enableTimeSchedule.TabIndex = 28;
            this.enableTimeSchedule.CheckedChanged += new Zeroit.Framework.Metro.ZeroitMetroSwitch.CheckedChangedEventHandler(this.enableTimeSchedule_CheckedChanged);
            this.enableTimeSchedule.MouseDown += new System.Windows.Forms.MouseEventHandler(this.enableTimeSchedule_MouseDown);
            this.enableTimeSchedule.MouseUp += new System.Windows.Forms.MouseEventHandler(this.enableTimeSchedule_MouseUp);
            // 
            // addNewTimeSchedule
            // 
            this.addNewTimeSchedule.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(215)))), ((int)(((byte)(156)))));
            this.addNewTimeSchedule.FlatAppearance.BorderSize = 0;
            this.addNewTimeSchedule.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addNewTimeSchedule.ForeColor = System.Drawing.Color.White;
            this.addNewTimeSchedule.Location = new System.Drawing.Point(580, 195);
            this.addNewTimeSchedule.Name = "addNewTimeSchedule";
            this.addNewTimeSchedule.Size = new System.Drawing.Size(80, 40);
            this.addNewTimeSchedule.TabIndex = 26;
            this.addNewTimeSchedule.Text = "ADD NEW";
            this.addNewTimeSchedule.UseVisualStyleBackColor = false;
            this.addNewTimeSchedule.Click += new System.EventHandler(this.addNewTimeSchedule_Click);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.ForeColor = System.Drawing.Color.White;
            this.label22.Location = new System.Drawing.Point(76, 34);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(107, 20);
            this.label22.TabIndex = 25;
            this.label22.Tag = "DontDisable";
            this.label22.Text = "Time schedule:";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.ForeColor = System.Drawing.Color.White;
            this.label20.Location = new System.Drawing.Point(574, 375);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(42, 15);
            this.label20.TabIndex = 24;
            this.label20.Tag = "DontDisable";
            this.label20.Text = "Enable";
            // 
            // enableAppSchedule
            // 
            this.enableAppSchedule.BackColor = System.Drawing.Color.Transparent;
            this.enableAppSchedule.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.enableAppSchedule.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(98)))), ((int)(((byte)(98)))));
            this.enableAppSchedule.CheckColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(98)))), ((int)(((byte)(98)))));
            this.enableAppSchedule.DefaultColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(215)))), ((int)(((byte)(156)))));
            this.enableAppSchedule.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.enableAppSchedule.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(98)))), ((int)(((byte)(98)))));
            this.enableAppSchedule.Location = new System.Drawing.Point(618, 373);
            this.enableAppSchedule.Name = "enableAppSchedule";
            this.enableAppSchedule.Size = new System.Drawing.Size(41, 23);
            this.enableAppSchedule.SwitchColor = System.Drawing.Color.White;
            this.enableAppSchedule.TabIndex = 23;
            this.enableAppSchedule.CheckedChanged += new Zeroit.Framework.Metro.ZeroitMetroSwitch.CheckedChangedEventHandler(this.enableSchedule_CheckedChanged);
            this.enableAppSchedule.MouseDown += new System.Windows.Forms.MouseEventHandler(this.enableSchedule_MouseDown);
            this.enableAppSchedule.MouseUp += new System.Windows.Forms.MouseEventHandler(this.enableSchedule_MouseUp);
            // 
            // addNewAppSchedule
            // 
            this.addNewAppSchedule.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(215)))), ((int)(((byte)(156)))));
            this.addNewAppSchedule.FlatAppearance.BorderSize = 0;
            this.addNewAppSchedule.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addNewAppSchedule.ForeColor = System.Drawing.Color.White;
            this.addNewAppSchedule.Location = new System.Drawing.Point(580, 404);
            this.addNewAppSchedule.Name = "addNewAppSchedule";
            this.addNewAppSchedule.Size = new System.Drawing.Size(80, 40);
            this.addNewAppSchedule.TabIndex = 18;
            this.addNewAppSchedule.Text = "ADD NEW";
            this.addNewAppSchedule.UseVisualStyleBackColor = false;
            this.addNewAppSchedule.Click += new System.EventHandler(this.addNewAppSchedule_Click);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.Color.White;
            this.label19.Location = new System.Drawing.Point(7, 7);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(69, 20);
            this.label19.TabIndex = 17;
            this.label19.Tag = "DontDisable";
            this.label19.Text = "Schedule";
            // 
            // appScheduleList
            // 
            this.appScheduleList.AutoScroll = true;
            this.appScheduleList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(32)))), ((int)(((byte)(54)))));
            this.appScheduleList.Location = new System.Drawing.Point(80, 264);
            this.appScheduleList.Margin = new System.Windows.Forms.Padding(0);
            this.appScheduleList.Name = "appScheduleList";
            this.appScheduleList.selectIndex = -1;
            this.appScheduleList.Size = new System.Drawing.Size(480, 180);
            this.appScheduleList.TabIndex = 22;
            this.appScheduleList.SelectChanged += new System.EventHandler(this.scheduleList_SelectChanged);
            this.appScheduleList.OrderChanged += new System.EventHandler(this.scheduleList_OrderChanged);
            this.appScheduleList.appScheduleEdit += new System.EventHandler<Newtonsoft.Json.Linq.JObject>(this.appScheduleList_appScheduleEdit);
            // 
            // _Other
            // 
            this._Other.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(42)))), ((int)(((byte)(71)))));
            this._Other.Controls.Add(this.removeDevice);
            this._Other.Controls.Add(this.espVersion);
            this._Other.Controls.Add(this.label25);
            this._Other.Controls.Add(this.powerConectedButton);
            this._Other.Controls.Add(this.restartButton);
            this._Other.Controls.Add(this.configButton);
            this._Other.Controls.Add(this.syncButton);
            this._Other.Controls.Add(this.removeUserConfig);
            this._Other.Controls.Add(this.formatButton);
            this._Other.Controls.Add(this.connectButton);
            this._Other.Location = new System.Drawing.Point(99, 4);
            this._Other.Margin = new System.Windows.Forms.Padding(0);
            this._Other.Name = "_Other";
            this._Other.Size = new System.Drawing.Size(729, 462);
            this._Other.TabIndex = 4;
            this._Other.Tag = "NotAnimationTab";
            this._Other.Text = "Other";
            // 
            // removeDevice
            // 
            this.removeDevice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(54)))));
            this.removeDevice.FlatAppearance.BorderSize = 0;
            this.removeDevice.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.removeDevice.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.removeDevice.ForeColor = System.Drawing.Color.White;
            this.removeDevice.Image = global::ESPRGB_Client.Properties.Resources.remove;
            this.removeDevice.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.removeDevice.Location = new System.Drawing.Point(25, 145);
            this.removeDevice.Name = "removeDevice";
            this.removeDevice.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.removeDevice.Size = new System.Drawing.Size(80, 95);
            this.removeDevice.TabIndex = 18;
            this.removeDevice.Tag = "DontDisable";
            this.removeDevice.Text = "\r\n\r\n\r\nRemove\r\nDevice\r\n";
            this.removeDevice.UseVisualStyleBackColor = false;
            this.removeDevice.Click += new System.EventHandler(this.removeDevice_Click);
            // 
            // espVersion
            // 
            this.espVersion.AutoSize = true;
            this.espVersion.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.espVersion.ForeColor = System.Drawing.Color.White;
            this.espVersion.Location = new System.Drawing.Point(660, 430);
            this.espVersion.Name = "espVersion";
            this.espVersion.Size = new System.Drawing.Size(45, 17);
            this.espVersion.TabIndex = 17;
            this.espVersion.Tag = "DontDisable";
            this.espVersion.Text = "0.0.0.0";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.ForeColor = System.Drawing.Color.White;
            this.label25.Location = new System.Drawing.Point(551, 430);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(103, 17);
            this.label25.TabIndex = 16;
            this.label25.Tag = "DontDisable";
            this.label25.Text = "ESPRGB Version:";
            // 
            // powerConectedButton
            // 
            this.powerConectedButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(54)))));
            this.powerConectedButton.FlatAppearance.BorderSize = 0;
            this.powerConectedButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.powerConectedButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.powerConectedButton.ForeColor = System.Drawing.Color.White;
            this.powerConectedButton.Image = global::ESPRGB_Client.Properties.Resources.power_0;
            this.powerConectedButton.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.powerConectedButton.Location = new System.Drawing.Point(225, 25);
            this.powerConectedButton.Name = "powerConectedButton";
            this.powerConectedButton.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.powerConectedButton.Size = new System.Drawing.Size(80, 95);
            this.powerConectedButton.TabIndex = 3;
            this.powerConectedButton.Text = "\r\n\r\n\r\nPower if\r\nconnected";
            this.powerConectedButton.UseVisualStyleBackColor = false;
            this.powerConectedButton.Click += new System.EventHandler(this.PowerIfConnected_Click);
            // 
            // restartButton
            // 
            this.restartButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(54)))));
            this.restartButton.FlatAppearance.BorderSize = 0;
            this.restartButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.restartButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.restartButton.ForeColor = System.Drawing.Color.White;
            this.restartButton.Image = global::ESPRGB_Client.Properties.Resources.refresh;
            this.restartButton.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.restartButton.Location = new System.Drawing.Point(325, 25);
            this.restartButton.Name = "restartButton";
            this.restartButton.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.restartButton.Size = new System.Drawing.Size(80, 95);
            this.restartButton.TabIndex = 4;
            this.restartButton.Text = "\r\n\r\n\r\nRestart\nDevice\r\n";
            this.restartButton.UseVisualStyleBackColor = false;
            this.restartButton.Click += new System.EventHandler(this.restartButton_Click);
            // 
            // configButton
            // 
            this.configButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(54)))));
            this.configButton.FlatAppearance.BorderSize = 0;
            this.configButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.configButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.configButton.ForeColor = System.Drawing.Color.White;
            this.configButton.Image = global::ESPRGB_Client.Properties.Resources.config;
            this.configButton.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.configButton.Location = new System.Drawing.Point(425, 25);
            this.configButton.Name = "configButton";
            this.configButton.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.configButton.Size = new System.Drawing.Size(80, 95);
            this.configButton.TabIndex = 5;
            this.configButton.Text = "\r\n\r\nConfig";
            this.configButton.UseVisualStyleBackColor = false;
            this.configButton.Click += new System.EventHandler(this.configButton_Click);
            // 
            // syncButton
            // 
            this.syncButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(54)))));
            this.syncButton.FlatAppearance.BorderSize = 0;
            this.syncButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.syncButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.syncButton.ForeColor = System.Drawing.Color.White;
            this.syncButton.Image = global::ESPRGB_Client.Properties.Resources.sync_0;
            this.syncButton.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.syncButton.Location = new System.Drawing.Point(125, 25);
            this.syncButton.Name = "syncButton";
            this.syncButton.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.syncButton.Size = new System.Drawing.Size(80, 95);
            this.syncButton.TabIndex = 2;
            this.syncButton.Text = "\r\n\r\n\r\nSync Device";
            this.syncButton.UseVisualStyleBackColor = false;
            this.syncButton.Click += new System.EventHandler(this.syncButton_Click);
            // 
            // removeUserConfig
            // 
            this.removeUserConfig.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(54)))));
            this.removeUserConfig.FlatAppearance.BorderSize = 0;
            this.removeUserConfig.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.removeUserConfig.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.removeUserConfig.ForeColor = System.Drawing.Color.White;
            this.removeUserConfig.Image = global::ESPRGB_Client.Properties.Resources.userConfig;
            this.removeUserConfig.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.removeUserConfig.Location = new System.Drawing.Point(625, 25);
            this.removeUserConfig.Name = "removeUserConfig";
            this.removeUserConfig.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.removeUserConfig.Size = new System.Drawing.Size(80, 95);
            this.removeUserConfig.TabIndex = 7;
            this.removeUserConfig.Tag = "DontDisable";
            this.removeUserConfig.Text = "\r\n\r\n\rRemove User Data";
            this.removeUserConfig.UseVisualStyleBackColor = false;
            this.removeUserConfig.Click += new System.EventHandler(this.removeUserData_Click);
            // 
            // formatButton
            // 
            this.formatButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(54)))));
            this.formatButton.FlatAppearance.BorderSize = 0;
            this.formatButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.formatButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.formatButton.ForeColor = System.Drawing.Color.White;
            this.formatButton.Image = global::ESPRGB_Client.Properties.Resources.format;
            this.formatButton.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.formatButton.Location = new System.Drawing.Point(525, 25);
            this.formatButton.Name = "formatButton";
            this.formatButton.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.formatButton.Size = new System.Drawing.Size(80, 95);
            this.formatButton.TabIndex = 6;
            this.formatButton.Text = "\r\n\r\n\r\nFormat\r\nDevice\r\n";
            this.formatButton.UseVisualStyleBackColor = false;
            this.formatButton.Click += new System.EventHandler(this.formatButton_Click);
            // 
            // connectButton
            // 
            this.connectButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(54)))));
            this.connectButton.FlatAppearance.BorderSize = 0;
            this.connectButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.connectButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.connectButton.ForeColor = System.Drawing.Color.White;
            this.connectButton.Image = global::ESPRGB_Client.Properties.Resources.wifi_white;
            this.connectButton.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.connectButton.Location = new System.Drawing.Point(25, 25);
            this.connectButton.Name = "connectButton";
            this.connectButton.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.connectButton.Size = new System.Drawing.Size(80, 95);
            this.connectButton.TabIndex = 1;
            this.connectButton.Tag = "DontDisable";
            this.connectButton.Text = "\r\n\r\n\r\nConnect\r\n\r\n";
            this.connectButton.UseVisualStyleBackColor = false;
            this.connectButton.Click += new System.EventHandler(this.connectButton_Click);
            // 
            // solidDiscoTimer
            // 
            this.solidDiscoTimer.Interval = 10;
            this.solidDiscoTimer.Tick += new System.EventHandler(this.solidDiscoTimer_Tick);
            // 
            // textBoxTimer
            // 
            this.textBoxTimer.Interval = 700;
            this.textBoxTimer.Tick += new System.EventHandler(this.textBoxTimer_Tick);
            // 
            // wifiImageBox
            // 
            this.wifiImageBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.wifiImageBox.Location = new System.Drawing.Point(33, 393);
            this.wifiImageBox.Name = "wifiImageBox";
            this.wifiImageBox.Size = new System.Drawing.Size(31, 26);
            this.wifiImageBox.TabIndex = 28;
            this.wifiImageBox.TabStop = false;
            // 
            // appControls
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(42)))), ((int)(((byte)(71)))));
            this.Controls.Add(this.wifiImageBox);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.tabctrl);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "appControls";
            this.Size = new System.Drawing.Size(832, 472);
            this.Load += new System.EventHandler(this.appControls_Load);
            this.tabctrl.ResumeLayout(false);
            this._SolidColor.ResumeLayout(false);
            this._SolidColor.PerformLayout();
            this._Color_Cycle.ResumeLayout(false);
            this._Color_Cycle.PerformLayout();
            this._Breathing.ResumeLayout(false);
            this._Breathing.PerformLayout();
            this._Disco.ResumeLayout(false);
            this._Disco.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ResultColor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTop)).EndInit();
            this._SolidDisco.ResumeLayout(false);
            this._SolidDisco.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SolidDiscoVisualizer)).EndInit();
            this._MorseCode.ResumeLayout(false);
            this._MorseCode.PerformLayout();
            this._Ambilight.ResumeLayout(false);
            this._Ambilight.PerformLayout();
            this._Schedule.ResumeLayout(false);
            this._Schedule.PerformLayout();
            this._Other.ResumeLayout(false);
            this._Other.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.wifiImageBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label ColorCycleSpeedText;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.CheckBox powerButton;
        public System.Windows.Forms.CheckBox startColorCycle;
        public System.Windows.Forms.CheckBox startBreathing;
        public System.Windows.Forms.Label breathingSpeedText;
        public System.Windows.Forms.Label label8;
        public System.Windows.Forms.Timer discoTimer;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.ToolTip presetTip;
        public Zeroit.Framework.Metro.ZeroitMetroTrackbar breathingSpeed;
        public Zeroit.Framework.Metro.ZeroitMetroTrackbar ColorCycleSpeed;
        public Zeroit.Framework.Metro.ZeroitMetroTrackbar brightnessSlide;
        private System.Windows.Forms.TabPage _SolidColor;
        private System.Windows.Forms.TabPage _Color_Cycle;
        private System.Windows.Forms.TabPage _Breathing;
        private System.Windows.Forms.TabPage _Disco;
        private System.Windows.Forms.TabPage _Other;
        private System.Windows.Forms.Button removeUserConfig;
        private System.Windows.Forms.Button formatButton;
        private System.Windows.Forms.Button connectButton;
        private Zeroit.Framework.Metro.ZeroitMetroTabControl tabctrl;
        public System.Windows.Forms.Panel preset0;
        public System.Windows.Forms.Panel preset3;
        public System.Windows.Forms.Panel preset2;
        public System.Windows.Forms.Panel preset4;
        public System.Windows.Forms.Panel preset1;
        private System.Windows.Forms.PictureBox pictureBoxTop;
        private System.Windows.Forms.Button sel_blue;
        private System.Windows.Forms.Button sel_green;
        private System.Windows.Forms.Button sel_red;
        private System.Windows.Forms.PictureBox ResultColor;
        private System.Windows.Forms.Button sel_black;
        private System.Windows.Forms.ComboBox selectionColor;
        public WindowsFormsApp2.colorslider colorslider1;
        private System.Windows.Forms.TabPage _SolidDisco;
        private System.Windows.Forms.PictureBox SolidDiscoVisualizer;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.CheckBox startSolidDisco;
        public System.Windows.Forms.Timer solidDiscoTimer;
        public colorslider_simple colorslider_simple;
        public Zeroit.Framework.Metro.ZeroitMetroTrackbar highSensitivity;
        public Zeroit.Framework.Metro.ZeroitMetroTrackbar midSensitivity;
        public Zeroit.Framework.Metro.ZeroitMetroTrackbar lowSensitivity;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;
        public Zeroit.Framework.Metro.ZeroitMetroTrackbar solidDiscoSensitivity;
        public System.Windows.Forms.CheckBox randomColor;
        private System.Windows.Forms.Label label15;
        public Zeroit.Framework.Metro.ZeroitMetroTrackbar highsBrightness;
        private System.Windows.Forms.Label label14;
        public Zeroit.Framework.Metro.ZeroitMetroTrackbar midsBrightness;
        private System.Windows.Forms.Label label13;
        public Zeroit.Framework.Metro.ZeroitMetroTrackbar lowsBrightness;
        private System.Windows.Forms.Button syncButton;
        private System.Windows.Forms.Button configButton;
        private System.Windows.Forms.PictureBox wifiImageBox;
        private System.Windows.Forms.CheckBox useColorList;
        private System.Windows.Forms.Button br_clearColorlist;
        private System.Windows.Forms.Button br_removeLastColor;
        private System.Windows.Forms.Button br_addCurrentColor;
        private System.Windows.Forms.Button restartButton;
        public breathingSlider colorListResult;
        private System.Windows.Forms.TabPage _MorseCode;
        public System.Windows.Forms.TextBox morsePlainText;
        public System.Windows.Forms.CheckBox startMorseCode;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        public System.Windows.Forms.TextBox encodedMsgResult;
        private System.Windows.Forms.Label label18;
        public Zeroit.Framework.Metro.ZeroitMetroTrackbar unitTime;
        public System.Windows.Forms.CheckBox useBuzzer;
        private System.Windows.Forms.Timer textBoxTimer;
        public Cyotek.Windows.Forms.ColorWheel colorWheel;
        public Cyotek.Windows.Forms.ColorWheel colorBreathing;
        public Cyotek.Windows.Forms.ColorWheel colorWheel_SolidDisco;
        public Cyotek.Windows.Forms.ColorWheel morseColor;
        private System.Windows.Forms.TabPage _Ambilight;
        private System.Windows.Forms.TabPage _Schedule;
        private System.Windows.Forms.Button addNewAppSchedule;
        private System.Windows.Forms.Label label19;
        public WindowsFormsApp2.scheduleList appScheduleList;
        private System.Windows.Forms.Label label20;
        public Zeroit.Framework.Metro.ZeroitMetroSwitch enableAppSchedule;
        private System.Windows.Forms.Button powerConectedButton;
        private System.Windows.Forms.Label label21;
        public Zeroit.Framework.Metro.ZeroitMetroTrackbar ambilightSpeed;
        public System.Windows.Forms.CheckBox startAmbilight;
        public ScreenSampler screenSampler;
        private System.Windows.Forms.CheckBox startDisco;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label23;
        public Zeroit.Framework.Metro.ZeroitMetroSwitch enableTimeSchedule;
        private System.Windows.Forms.Button addNewTimeSchedule;
        private System.Windows.Forms.Label label22;
        private WindowsFormsApp2.scheduleList timeScheduleList;
        private System.Windows.Forms.Label espVersion;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Button removeDevice;
    }
}
