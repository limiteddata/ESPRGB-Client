using System;
using System.Drawing;
using System.Windows.Forms;

namespace ESPRGB_Client
{
    public partial class exceptions : Form
    {
        
        public exceptions(int type,string title,string _Message,float fontSize = 12)
        {
            InitializeComponent();
            this.Text = title;
            message.Font = new Font("Microsoft Sans Serif", fontSize, FontStyle.Regular, GraphicsUnit.Point, 0);
            message.Text = _Message;
            switch (type)
            {
                case 0:
                    createYesButton();
                    break;
                case 1:
                    createYesNo();
                    break;
            }
        }

        private void messageBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }
        Point lastPoint;
        private void messageBox_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void createYesButton()
        {
            this.SuspendLayout();
            this.panel1.SuspendLayout();
            Button yesButton = new Button();
            yesButton.BackColor = Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(215)))), ((int)(((byte)(156)))));
            yesButton.DialogResult = DialogResult.OK;
            yesButton.FlatAppearance.BorderSize = 0;
            yesButton.FlatStyle = FlatStyle.Flat;
            yesButton.Font = new Font("Microsoft PhagsPa", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            yesButton.ForeColor = Color.White;
            yesButton.Location = new Point(108, 70);
            yesButton.Name = "yesButton";
            yesButton.Size = new System.Drawing.Size(85, 30);
            yesButton.Text = "OK";
            yesButton.UseVisualStyleBackColor = false;
            yesButton.TabIndex = 4;
            yesButton.Click += new System.EventHandler((senderx,ex)=> {
                this.DialogResult = DialogResult.OK;
            });
            this.panel1.Controls.Add(yesButton);

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void createYesNo()
        {
            this.SuspendLayout();
            Button yesButton = new Button();
            Button noButton = new Button();

            yesButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(215)))), ((int)(((byte)(156)))));
            yesButton.DialogResult = System.Windows.Forms.DialogResult.Yes;
            yesButton.FlatAppearance.BorderSize = 0;
            yesButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            yesButton.Font = new System.Drawing.Font("Microsoft PhagsPa", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            yesButton.ForeColor = System.Drawing.Color.White;
            yesButton.Location = new System.Drawing.Point(37, 70);
            yesButton.Name = "yesButton";
            yesButton.Size = new System.Drawing.Size(85, 30);
            yesButton.TabIndex = 4;
            yesButton.Text = "&Yes";
            yesButton.UseVisualStyleBackColor = false;
            yesButton.Click += new System.EventHandler((senderx, ex) =>{
                this.DialogResult = DialogResult.Yes;
            });
            // 
            // noButton
            // 
            noButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(54)))));
            noButton.DialogResult = System.Windows.Forms.DialogResult.No;
            noButton.FlatAppearance.BorderSize = 0;
            noButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            noButton.Font = new System.Drawing.Font("Microsoft PhagsPa", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            noButton.ForeColor = System.Drawing.Color.White;
            noButton.Location = new System.Drawing.Point(181, 70);
            noButton.Name = "noButton";
            noButton.Size = new System.Drawing.Size(85, 30);
            noButton.TabIndex = 3;
            noButton.Text = "No";
            noButton.UseVisualStyleBackColor = false;
            noButton.Click += new System.EventHandler((senderx, ex) => {
                this.DialogResult = DialogResult.No;
            });
            

            this.panel1.Controls.Add(yesButton);
            this.panel1.Controls.Add(noButton);

            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
