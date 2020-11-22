namespace ESPRGB_Client
{
    partial class firmwareUpdater
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(firmwareUpdater));
            this.label1 = new System.Windows.Forms.Label();
            this.ipaddressText = new System.Windows.Forms.Label();
            this.infoText = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.progress = new Zeroit.Framework.Metro.ZeroitMetroProgressbar();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(21, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Updating:";
            // 
            // ipaddressText
            // 
            this.ipaddressText.AutoSize = true;
            this.ipaddressText.ForeColor = System.Drawing.Color.White;
            this.ipaddressText.Location = new System.Drawing.Point(88, 24);
            this.ipaddressText.Name = "ipaddressText";
            this.ipaddressText.Size = new System.Drawing.Size(52, 13);
            this.ipaddressText.TabIndex = 1;
            this.ipaddressText.Text = "ipaddress";
            // 
            // infoText
            // 
            this.infoText.ForeColor = System.Drawing.Color.White;
            this.infoText.Location = new System.Drawing.Point(21, 85);
            this.infoText.Name = "infoText";
            this.infoText.Size = new System.Drawing.Size(347, 323);
            this.infoText.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(42)))), ((int)(((byte)(71)))));
            this.panel1.Controls.Add(this.progress);
            this.panel1.Controls.Add(this.infoText);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.ipaddressText);
            this.panel1.Location = new System.Drawing.Point(10, 10);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(400, 420);
            this.panel1.TabIndex = 5;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            // 
            // progress
            // 
            this.progress.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.progress.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(98)))), ((int)(((byte)(98)))));
            this.progress.DefaultColor = System.Drawing.Color.White;
            this.progress.GradientColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(98)))), ((int)(((byte)(163)))));
            this.progress.Location = new System.Drawing.Point(24, 48);
            this.progress.Name = "progress";
            this.progress.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(215)))), ((int)(((byte)(156)))));
            this.progress.RoundingArc = 25;
            this.progress.Size = new System.Drawing.Size(344, 25);
            this.progress.SpecialSymbol = "%";
            this.progress.TabIndex = 5;
            this.progress.Text = "progress";
            this.progress.UseGradient = false;
            this.progress.Value = 0;
            // 
            // firmwareUpdater
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(32)))), ((int)(((byte)(54)))));
            this.ClientSize = new System.Drawing.Size(420, 440);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "firmwareUpdater";
            this.Text = "Firmware Updater";
            this.Load += new System.EventHandler(this.firmwareUpdater_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label ipaddressText;
        private System.Windows.Forms.Label infoText;
        private System.Windows.Forms.Panel panel1;
        private Zeroit.Framework.Metro.ZeroitMetroProgressbar progress;
    }
}