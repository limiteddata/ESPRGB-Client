using System;
using System.Drawing;
using System.Windows.Forms;

namespace ESPRGB_Client
{
    public partial class exitMessage : Form
    {
        public exitMessage(string title,string _Message)
        {
            InitializeComponent();
            this.Text = title;
            message.Text = _Message;
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

        private void yesButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Yes;
        }

        private void noButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
