namespace ESPRGB_Client
{
    partial class configWindow
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
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(configWindow));
            this.panel1 = new System.Windows.Forms.Panel();
            this.testbutton_bz = new System.Windows.Forms.Button();
            this.BUZZERPIN = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.pinResponse = new System.Windows.Forms.Label();
            this.sendButton = new System.Windows.Forms.Button();
            this.dns = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.subnet = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.gateway = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.local_IP = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.startStatic = new System.Windows.Forms.CheckBox();
            this.testButton_B = new System.Windows.Forms.Button();
            this.BLUEPIN = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.testButton_G = new System.Windows.Forms.Button();
            this.GREENPIN = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.testButton_R = new System.Windows.Forms.Button();
            this.REDPIN = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.HOSTNAME = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SSID = new System.Windows.Forms.ComboBox();
            this.PASSWORD = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.closeButton = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(42)))), ((int)(((byte)(71)))));
            this.panel1.Controls.Add(this.HOSTNAME);
            this.panel1.Controls.Add(this.dns);
            this.panel1.Controls.Add(this.subnet);
            this.panel1.Controls.Add(this.gateway);
            this.panel1.Controls.Add(this.local_IP);
            this.panel1.Controls.Add(this.PASSWORD);
            this.panel1.Controls.Add(this.testbutton_bz);
            this.panel1.Controls.Add(this.BUZZERPIN);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.pinResponse);
            this.panel1.Controls.Add(this.sendButton);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.startStatic);
            this.panel1.Controls.Add(this.testButton_B);
            this.panel1.Controls.Add(this.BLUEPIN);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.testButton_G);
            this.panel1.Controls.Add(this.GREENPIN);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.testButton_R);
            this.panel1.Controls.Add(this.REDPIN);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.SSID);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.closeButton);
            this.panel1.Location = new System.Drawing.Point(10, 10);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(356, 524);
            this.panel1.TabIndex = 1;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.messageBox_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.messageBox_MouseMove);
            // 
            // testbutton_bz
            // 
            this.testbutton_bz.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(215)))), ((int)(((byte)(156)))));
            this.testbutton_bz.FlatAppearance.BorderSize = 0;
            this.testbutton_bz.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.testbutton_bz.Font = new System.Drawing.Font("Microsoft PhagsPa", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.testbutton_bz.ForeColor = System.Drawing.Color.White;
            this.testbutton_bz.Location = new System.Drawing.Point(256, 283);
            this.testbutton_bz.Name = "testbutton_bz";
            this.testbutton_bz.Size = new System.Drawing.Size(67, 23);
            this.testbutton_bz.TabIndex = 74;
            this.testbutton_bz.Text = "TEST";
            this.testbutton_bz.UseVisualStyleBackColor = false;
            this.testbutton_bz.Click += new System.EventHandler(this.testbutton_bz_Click);
            // 
            // BUZZERPIN
            // 
            this.BUZZERPIN.BackColor = System.Drawing.Color.White;
            this.BUZZERPIN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BUZZERPIN.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BUZZERPIN.FormattingEnabled = true;
            this.BUZZERPIN.IntegralHeight = false;
            this.BUZZERPIN.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "12",
            "13",
            "14",
            "15",
            "16"});
            this.BUZZERPIN.Location = new System.Drawing.Point(165, 283);
            this.BUZZERPIN.Name = "BUZZERPIN";
            this.BUZZERPIN.Size = new System.Drawing.Size(85, 23);
            this.BUZZERPIN.TabIndex = 73;
            this.BUZZERPIN.Click += new System.EventHandler(this.PIN_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.White;
            this.label15.Location = new System.Drawing.Point(88, 283);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(72, 16);
            this.label15.TabIndex = 72;
            this.label15.Text = "Buzzer pin:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.White;
            this.label14.Location = new System.Drawing.Point(91, 162);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(58, 18);
            this.label14.TabIndex = 66;
            this.label14.Text = "esprgb-";
            // 
            // pinResponse
            // 
            this.pinResponse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.pinResponse.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pinResponse.ForeColor = System.Drawing.Color.White;
            this.pinResponse.Location = new System.Drawing.Point(91, 313);
            this.pinResponse.Name = "pinResponse";
            this.pinResponse.Size = new System.Drawing.Size(233, 16);
            this.pinResponse.TabIndex = 65;
            this.pinResponse.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // sendButton
            // 
            this.sendButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(215)))), ((int)(((byte)(156)))));
            this.sendButton.FlatAppearance.BorderSize = 0;
            this.sendButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sendButton.Font = new System.Drawing.Font("Microsoft PhagsPa", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sendButton.ForeColor = System.Drawing.Color.White;
            this.sendButton.Location = new System.Drawing.Point(155, 482);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(80, 30);
            this.sendButton.TabIndex = 71;
            this.sendButton.Text = "Send";
            this.sendButton.UseVisualStyleBackColor = false;
            this.sendButton.Click += new System.EventHandler(this.sendButton_Click);
            // 
            // dns
            // 
            this.dns.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dns.Location = new System.Drawing.Point(91, 445);
            this.dns.Name = "dns";
            this.dns.Size = new System.Drawing.Size(232, 22);
            this.dns.TabIndex = 69;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(53, 448);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(35, 16);
            this.label13.TabIndex = 63;
            this.label13.Text = "Dns:";
            // 
            // subnet
            // 
            this.subnet.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subnet.Location = new System.Drawing.Point(91, 417);
            this.subnet.Name = "subnet";
            this.subnet.Size = new System.Drawing.Size(232, 22);
            this.subnet.TabIndex = 67;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(35, 420);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 16);
            this.label12.TabIndex = 61;
            this.label12.Text = "Subnet:";
            // 
            // gateway
            // 
            this.gateway.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gateway.Location = new System.Drawing.Point(91, 387);
            this.gateway.Name = "gateway";
            this.gateway.Size = new System.Drawing.Size(232, 22);
            this.gateway.TabIndex = 65;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(24, 390);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(64, 16);
            this.label10.TabIndex = 58;
            this.label10.Text = "Gateway:";
            // 
            // local_IP
            // 
            this.local_IP.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.local_IP.Location = new System.Drawing.Point(91, 358);
            this.local_IP.Name = "local_IP";
            this.local_IP.Size = new System.Drawing.Size(232, 22);
            this.local_IP.TabIndex = 63;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(15, 162);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(73, 16);
            this.label11.TabIndex = 59;
            this.label11.Text = "Hostname:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(14, 361);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(74, 16);
            this.label9.TabIndex = 56;
            this.label9.Text = "IPAddress:";
            // 
            // startStatic
            // 
            this.startStatic.AutoSize = true;
            this.startStatic.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startStatic.ForeColor = System.Drawing.Color.White;
            this.startStatic.Location = new System.Drawing.Point(91, 332);
            this.startStatic.Name = "startStatic";
            this.startStatic.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.startStatic.Size = new System.Drawing.Size(183, 20);
            this.startStatic.TabIndex = 61;
            this.startStatic.Text = "Static ipaddress (optional)";
            this.startStatic.UseVisualStyleBackColor = true;
            this.startStatic.CheckedChanged += new System.EventHandler(this.startStatic_CheckedChanged);
            // 
            // testButton_B
            // 
            this.testButton_B.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(215)))), ((int)(((byte)(156)))));
            this.testButton_B.FlatAppearance.BorderSize = 0;
            this.testButton_B.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.testButton_B.Font = new System.Drawing.Font("Microsoft PhagsPa", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.testButton_B.ForeColor = System.Drawing.Color.White;
            this.testButton_B.Location = new System.Drawing.Point(256, 254);
            this.testButton_B.Name = "testButton_B";
            this.testButton_B.Size = new System.Drawing.Size(67, 23);
            this.testButton_B.TabIndex = 60;
            this.testButton_B.Text = "TEST";
            this.testButton_B.UseVisualStyleBackColor = false;
            this.testButton_B.Click += new System.EventHandler(this.testButton_B_Click);
            // 
            // BLUEPIN
            // 
            this.BLUEPIN.BackColor = System.Drawing.Color.White;
            this.BLUEPIN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BLUEPIN.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BLUEPIN.FormattingEnabled = true;
            this.BLUEPIN.IntegralHeight = false;
            this.BLUEPIN.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "12",
            "13",
            "14",
            "15",
            "16"});
            this.BLUEPIN.Location = new System.Drawing.Point(165, 254);
            this.BLUEPIN.Name = "BLUEPIN";
            this.BLUEPIN.Size = new System.Drawing.Size(85, 23);
            this.BLUEPIN.TabIndex = 59;
            this.BLUEPIN.Click += new System.EventHandler(this.PIN_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(88, 254);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 16);
            this.label8.TabIndex = 51;
            this.label8.Text = "Blue pin:";
            // 
            // testButton_G
            // 
            this.testButton_G.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(215)))), ((int)(((byte)(156)))));
            this.testButton_G.FlatAppearance.BorderSize = 0;
            this.testButton_G.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.testButton_G.Font = new System.Drawing.Font("Microsoft PhagsPa", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.testButton_G.ForeColor = System.Drawing.Color.White;
            this.testButton_G.Location = new System.Drawing.Point(256, 223);
            this.testButton_G.Name = "testButton_G";
            this.testButton_G.Size = new System.Drawing.Size(67, 23);
            this.testButton_G.TabIndex = 58;
            this.testButton_G.Text = "TEST";
            this.testButton_G.UseVisualStyleBackColor = false;
            this.testButton_G.Click += new System.EventHandler(this.testButton_G_Click);
            // 
            // GREENPIN
            // 
            this.GREENPIN.BackColor = System.Drawing.Color.White;
            this.GREENPIN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.GREENPIN.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GREENPIN.FormattingEnabled = true;
            this.GREENPIN.IntegralHeight = false;
            this.GREENPIN.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "12",
            "13",
            "14",
            "15",
            "16"});
            this.GREENPIN.Location = new System.Drawing.Point(165, 223);
            this.GREENPIN.Name = "GREENPIN";
            this.GREENPIN.Size = new System.Drawing.Size(85, 23);
            this.GREENPIN.TabIndex = 57;
            this.GREENPIN.Click += new System.EventHandler(this.PIN_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(88, 223);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(69, 16);
            this.label7.TabIndex = 48;
            this.label7.Text = "Green pin:";
            // 
            // testButton_R
            // 
            this.testButton_R.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(215)))), ((int)(((byte)(156)))));
            this.testButton_R.FlatAppearance.BorderSize = 0;
            this.testButton_R.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.testButton_R.Font = new System.Drawing.Font("Microsoft PhagsPa", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.testButton_R.ForeColor = System.Drawing.Color.White;
            this.testButton_R.Location = new System.Drawing.Point(256, 192);
            this.testButton_R.Name = "testButton_R";
            this.testButton_R.Size = new System.Drawing.Size(67, 23);
            this.testButton_R.TabIndex = 56;
            this.testButton_R.Text = "TEST";
            this.testButton_R.UseVisualStyleBackColor = false;
            this.testButton_R.Click += new System.EventHandler(this.testButton_R_Click);
            // 
            // REDPIN
            // 
            this.REDPIN.BackColor = System.Drawing.Color.White;
            this.REDPIN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.REDPIN.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.REDPIN.FormattingEnabled = true;
            this.REDPIN.IntegralHeight = false;
            this.REDPIN.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "12",
            "13",
            "14",
            "15",
            "16"});
            this.REDPIN.Location = new System.Drawing.Point(165, 192);
            this.REDPIN.Name = "REDPIN";
            this.REDPIN.Size = new System.Drawing.Size(85, 23);
            this.REDPIN.TabIndex = 55;
            this.REDPIN.Click += new System.EventHandler(this.PIN_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(88, 192);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 16);
            this.label6.TabIndex = 45;
            this.label6.Text = "Red pin:";
            // 
            // HOSTNAME
            // 
            this.HOSTNAME.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HOSTNAME.Location = new System.Drawing.Point(165, 161);
            this.HOSTNAME.Name = "HOSTNAME";
            this.HOSTNAME.Size = new System.Drawing.Size(158, 22);
            this.HOSTNAME.TabIndex = 54;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(152, 135);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 16);
            this.label5.TabIndex = 43;
            this.label5.Text = "Device details";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(147, 44);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 16);
            this.label4.TabIndex = 42;
            this.label4.Text = "Wifi credentials";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(46, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 16);
            this.label3.TabIndex = 41;
            this.label3.Text = "SSID:";
            // 
            // SSID
            // 
            this.SSID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.SSID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.SSID.BackColor = System.Drawing.Color.White;
            this.SSID.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SSID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SSID.FormattingEnabled = true;
            this.SSID.IntegralHeight = false;
            this.SSID.Location = new System.Drawing.Point(91, 72);
            this.SSID.Name = "SSID";
            this.SSID.Size = new System.Drawing.Size(232, 23);
            this.SSID.TabIndex = 50;
            this.SSID.SelectedIndexChanged += new System.EventHandler(this.SSID_SelectedIndexChanged);
            this.SSID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SSID_KeyDown);
            // 
            // PASSWORD
            // 
            this.PASSWORD.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PASSWORD.Location = new System.Drawing.Point(91, 106);
            this.PASSWORD.Name = "PASSWORD";
            this.PASSWORD.PasswordChar = '*';
            this.PASSWORD.Size = new System.Drawing.Size(232, 22);
            this.PASSWORD.TabIndex = 52;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(17, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 16);
            this.label2.TabIndex = 33;
            this.label2.Text = "Password:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(17, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 18);
            this.label1.TabIndex = 32;
            this.label1.Text = "Config";
            // 
            // closeButton
            // 
            this.closeButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(215)))), ((int)(((byte)(156)))));
            this.closeButton.DialogResult = System.Windows.Forms.DialogResult.No;
            this.closeButton.FlatAppearance.BorderSize = 0;
            this.closeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closeButton.Font = new System.Drawing.Font("Microsoft PhagsPa", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closeButton.ForeColor = System.Drawing.Color.White;
            this.closeButton.Location = new System.Drawing.Point(244, 482);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(80, 30);
            this.closeButton.TabIndex = 70;
            this.closeButton.Text = "Close";
            this.closeButton.UseVisualStyleBackColor = false;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // configWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(32)))), ((int)(((byte)(54)))));
            this.ClientSize = new System.Drawing.Size(375, 543);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "configWindow";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ESPRGB-Settings";
            this.Shown += new System.EventHandler(this.configWindow_Shown);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.messageBox_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.messageBox_MouseMove);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.TextBox PASSWORD;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.ComboBox SSID;
        private System.Windows.Forms.CheckBox startStatic;
        private System.Windows.Forms.Button testButton_B;
        public System.Windows.Forms.ComboBox BLUEPIN;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button testButton_G;
        public System.Windows.Forms.ComboBox GREENPIN;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button testButton_R;
        public System.Windows.Forms.ComboBox REDPIN;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox HOSTNAME;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button sendButton;
        private System.Windows.Forms.TextBox dns;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox subnet;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox gateway;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox local_IP;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label pinResponse;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button testbutton_bz;
        public System.Windows.Forms.ComboBox BUZZERPIN;
        private System.Windows.Forms.Label label15;
    }
}