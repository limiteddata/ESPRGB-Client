namespace ESPRGB_Client
{
    partial class settingsWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(settingsWindow));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.DeviceBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.exitButtonBehavior = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.startState = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.startupCheckbox = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.closeButton = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(42)))), ((int)(((byte)(71)))));
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.DeviceBox);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.exitButtonBehavior);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.startState);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.startupCheckbox);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.closeButton);
            this.panel1.Location = new System.Drawing.Point(10, 10);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(380, 230);
            this.panel1.TabIndex = 0;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.messageBox_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.messageBox_MouseMove);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(49, 138);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 18);
            this.label5.TabIndex = 40;
            this.label5.Text = "Audio output";
            // 
            // DeviceBox
            // 
            this.DeviceBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DeviceBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DeviceBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeviceBox.FormattingEnabled = true;
            this.DeviceBox.IntegralHeight = false;
            this.DeviceBox.Location = new System.Drawing.Point(158, 137);
            this.DeviceBox.Name = "DeviceBox";
            this.DeviceBox.Size = new System.Drawing.Size(174, 23);
            this.DeviceBox.TabIndex = 39;
            this.DeviceBox.DropDown += new System.EventHandler(this.DeviceBox_DropDown);
            this.DeviceBox.SelectionChangeCommitted += new System.EventHandler(this.DeviceBox_SelectionChangeCommitted);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(49, 70);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(203, 18);
            this.label4.TabIndex = 38;
            this.label4.Text = "Close button should minimize";
            // 
            // exitButtonBehavior
            // 
            this.exitButtonBehavior.Appearance = System.Windows.Forms.Appearance.Button;
            this.exitButtonBehavior.AutoSize = true;
            this.exitButtonBehavior.BackColor = System.Drawing.Color.Transparent;
            this.exitButtonBehavior.FlatAppearance.BorderSize = 0;
            this.exitButtonBehavior.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(42)))), ((int)(((byte)(71)))));
            this.exitButtonBehavior.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(42)))), ((int)(((byte)(71)))));
            this.exitButtonBehavior.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(42)))), ((int)(((byte)(71)))));
            this.exitButtonBehavior.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exitButtonBehavior.Font = new System.Drawing.Font("Microsoft Sans Serif", 1F);
            this.exitButtonBehavior.ForeColor = System.Drawing.Color.Transparent;
            this.exitButtonBehavior.Image = global::ESPRGB_Client.Properties.Resources.bool_0;
            this.exitButtonBehavior.Location = new System.Drawing.Point(258, 66);
            this.exitButtonBehavior.Margin = new System.Windows.Forms.Padding(0);
            this.exitButtonBehavior.Name = "exitButtonBehavior";
            this.exitButtonBehavior.Size = new System.Drawing.Size(26, 26);
            this.exitButtonBehavior.TabIndex = 37;
            this.exitButtonBehavior.TabStop = false;
            this.exitButtonBehavior.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.exitButtonBehavior.UseVisualStyleBackColor = false;
            this.exitButtonBehavior.CheckedChanged += new System.EventHandler(this.exitButtonBehavior_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(49, 106);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(162, 18);
            this.label3.TabIndex = 36;
            this.label3.Text = "Open app automatically";
            // 
            // startState
            // 
            this.startState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.startState.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.startState.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startState.FormattingEnabled = true;
            this.startState.IntegralHeight = false;
            this.startState.Items.AddRange(new object[] {
            "Minimized",
            "Normal"});
            this.startState.Location = new System.Drawing.Point(222, 105);
            this.startState.Name = "startState";
            this.startState.Size = new System.Drawing.Size(110, 23);
            this.startState.TabIndex = 35;
            this.startState.SelectedIndexChanged += new System.EventHandler(this.startState_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(197, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 18);
            this.label2.TabIndex = 34;
            this.label2.Text = "Startup";
            // 
            // startupCheckbox
            // 
            this.startupCheckbox.Appearance = System.Windows.Forms.Appearance.Button;
            this.startupCheckbox.AutoSize = true;
            this.startupCheckbox.BackColor = System.Drawing.Color.Transparent;
            this.startupCheckbox.FlatAppearance.BorderSize = 0;
            this.startupCheckbox.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(42)))), ((int)(((byte)(71)))));
            this.startupCheckbox.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(42)))), ((int)(((byte)(71)))));
            this.startupCheckbox.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(42)))), ((int)(((byte)(71)))));
            this.startupCheckbox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.startupCheckbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 1F);
            this.startupCheckbox.ForeColor = System.Drawing.Color.Transparent;
            this.startupCheckbox.Image = global::ESPRGB_Client.Properties.Resources.bool_0;
            this.startupCheckbox.Location = new System.Drawing.Point(258, 37);
            this.startupCheckbox.Margin = new System.Windows.Forms.Padding(0);
            this.startupCheckbox.Name = "startupCheckbox";
            this.startupCheckbox.Size = new System.Drawing.Size(26, 26);
            this.startupCheckbox.TabIndex = 33;
            this.startupCheckbox.TabStop = false;
            this.startupCheckbox.UseVisualStyleBackColor = false;
            this.startupCheckbox.CheckedChanged += new System.EventHandler(this.startupCheckbox_CheckedChanged);
            this.startupCheckbox.Click += new System.EventHandler(this.startupCheckbox_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(17, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 18);
            this.label1.TabIndex = 32;
            this.label1.Text = "Settings";
            // 
            // closeButton
            // 
            this.closeButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(215)))), ((int)(((byte)(156)))));
            this.closeButton.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.closeButton.FlatAppearance.BorderSize = 0;
            this.closeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closeButton.Font = new System.Drawing.Font("Microsoft PhagsPa", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closeButton.ForeColor = System.Drawing.Color.White;
            this.closeButton.Location = new System.Drawing.Point(150, 178);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(80, 30);
            this.closeButton.TabIndex = 5;
            this.closeButton.Text = "Close";
            this.closeButton.UseVisualStyleBackColor = false;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // settingsWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(32)))), ((int)(((byte)(54)))));
            this.ClientSize = new System.Drawing.Size(400, 250);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "settingsWindow";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ESPRGB-Settings";
            this.Load += new System.EventHandler(this.settingsWindow_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.CheckBox startupCheckbox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.ComboBox startState;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.CheckBox exitButtonBehavior;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.ComboBox DeviceBox;
    }
}