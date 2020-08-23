namespace ESPRGB_Client
{
    partial class addDeviceControl
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
            this.ipAddress = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.connectButton_ = new System.Windows.Forms.Button();
            this.scnDevice = new System.Windows.Forms.Button();
            this.resScnDevice = new System.Windows.Forms.Button();
            this.devicePanel = new System.Windows.Forms.Panel();
            this.status = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.saveButton = new System.Windows.Forms.Button();
            this.disconnectButton = new System.Windows.Forms.Button();
            this.message = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ipAddress
            // 
            this.ipAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ipAddress.Location = new System.Drawing.Point(45, 38);
            this.ipAddress.Name = "ipAddress";
            this.ipAddress.Size = new System.Drawing.Size(229, 24);
            this.ipAddress.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(32)))), ((int)(((byte)(54)))));
            this.panel1.Controls.Add(this.ipAddress);
            this.panel1.Controls.Add(this.connectButton_);
            this.panel1.Controls.Add(this.scnDevice);
            this.panel1.Controls.Add(this.resScnDevice);
            this.panel1.Controls.Add(this.devicePanel);
            this.panel1.Controls.Add(this.status);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.saveButton);
            this.panel1.Controls.Add(this.disconnectButton);
            this.panel1.Location = new System.Drawing.Point(150, 92);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(530, 338);
            this.panel1.TabIndex = 0;
            // 
            // connectButton_
            // 
            this.connectButton_.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(54)))));
            this.connectButton_.FlatAppearance.BorderSize = 0;
            this.connectButton_.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.connectButton_.Font = new System.Drawing.Font("Microsoft PhagsPa", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.connectButton_.ForeColor = System.Drawing.Color.White;
            this.connectButton_.Location = new System.Drawing.Point(315, 35);
            this.connectButton_.Name = "connectButton_";
            this.connectButton_.Size = new System.Drawing.Size(80, 30);
            this.connectButton_.TabIndex = 2;
            this.connectButton_.Text = "Connect";
            this.connectButton_.UseVisualStyleBackColor = false;
            this.connectButton_.Click += new System.EventHandler(this.connectButton__Click);
            // 
            // scnDevice
            // 
            this.scnDevice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(32)))), ((int)(((byte)(54)))));
            this.scnDevice.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.scnDevice.FlatAppearance.BorderSize = 0;
            this.scnDevice.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.scnDevice.Image = global::ESPRGB_Client.Properties.Resources.search;
            this.scnDevice.Location = new System.Drawing.Point(280, 37);
            this.scnDevice.Name = "scnDevice";
            this.scnDevice.Size = new System.Drawing.Size(25, 25);
            this.scnDevice.TabIndex = 4;
            this.scnDevice.UseVisualStyleBackColor = false;
            this.scnDevice.Click += new System.EventHandler(this.scnDevice_Click);
            // 
            // resScnDevice
            // 
            this.resScnDevice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(32)))), ((int)(((byte)(54)))));
            this.resScnDevice.BackgroundImage = global::ESPRGB_Client.Properties.Resources.refresh;
            this.resScnDevice.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.resScnDevice.FlatAppearance.BorderSize = 0;
            this.resScnDevice.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.resScnDevice.Location = new System.Drawing.Point(280, 37);
            this.resScnDevice.Margin = new System.Windows.Forms.Padding(0);
            this.resScnDevice.Name = "resScnDevice";
            this.resScnDevice.Size = new System.Drawing.Size(25, 25);
            this.resScnDevice.TabIndex = 12;
            this.resScnDevice.UseVisualStyleBackColor = false;
            this.resScnDevice.Visible = false;
            this.resScnDevice.Click += new System.EventHandler(this.resScnDevice_Click);
            // 
            // devicePanel
            // 
            this.devicePanel.AutoScroll = true;
            this.devicePanel.BackColor = System.Drawing.Color.Transparent;
            this.devicePanel.Location = new System.Drawing.Point(45, 80);
            this.devicePanel.Name = "devicePanel";
            this.devicePanel.Size = new System.Drawing.Size(465, 230);
            this.devicePanel.TabIndex = 11;
            // 
            // status
            // 
            this.status.AutoSize = true;
            this.status.ForeColor = System.Drawing.Color.White;
            this.status.Location = new System.Drawing.Point(201, 18);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(0, 13);
            this.status.TabIndex = 20;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(42, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 16);
            this.label2.TabIndex = 7;
            this.label2.Text = "IPAddress";
            // 
            // saveButton
            // 
            this.saveButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(215)))), ((int)(((byte)(156)))));
            this.saveButton.FlatAppearance.BorderSize = 0;
            this.saveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveButton.Font = new System.Drawing.Font("Microsoft PhagsPa", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveButton.ForeColor = System.Drawing.Color.White;
            this.saveButton.Location = new System.Drawing.Point(405, 35);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(80, 30);
            this.saveButton.TabIndex = 3;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = false;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // disconnectButton
            // 
            this.disconnectButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(54)))));
            this.disconnectButton.FlatAppearance.BorderSize = 0;
            this.disconnectButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.disconnectButton.Font = new System.Drawing.Font("Microsoft PhagsPa", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.disconnectButton.ForeColor = System.Drawing.Color.White;
            this.disconnectButton.Location = new System.Drawing.Point(315, 35);
            this.disconnectButton.Name = "disconnectButton";
            this.disconnectButton.Size = new System.Drawing.Size(80, 30);
            this.disconnectButton.TabIndex = 21;
            this.disconnectButton.Text = "Disconnect";
            this.disconnectButton.UseVisualStyleBackColor = false;
            this.disconnectButton.Visible = false;
            this.disconnectButton.Click += new System.EventHandler(this.disconnectButton_Click);
            // 
            // message
            // 
            this.message.AutoSize = true;
            this.message.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(32)))), ((int)(((byte)(54)))));
            this.message.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.message.ForeColor = System.Drawing.Color.White;
            this.message.Location = new System.Drawing.Point(192, 172);
            this.message.Margin = new System.Windows.Forms.Padding(0);
            this.message.Name = "message";
            this.message.Size = new System.Drawing.Size(232, 16);
            this.message.TabIndex = 10;
            this.message.Text = "Scan your network for esprgb devices";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(215)))), ((int)(((byte)(156)))));
            this.label1.Location = new System.Drawing.Point(326, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(178, 25);
            this.label1.TabIndex = 8;
            this.label1.Text = "Add new device";
            // 
            // addDeviceControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(42)))), ((int)(((byte)(71)))));
            this.Controls.Add(this.message);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "addDeviceControl";
            this.Size = new System.Drawing.Size(830, 470);
            this.Load += new System.EventHandler(this.addDeviceControl_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox ipAddress;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button connectButton_;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label status;
        private System.Windows.Forms.Label message;
        private System.Windows.Forms.Panel devicePanel;
        private System.Windows.Forms.Button scnDevice;
        private System.Windows.Forms.Button resScnDevice;
        private System.Windows.Forms.Button disconnectButton;
    }
}
