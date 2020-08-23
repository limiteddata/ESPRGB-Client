using System;
using System.Drawing;
using System.Windows.Forms;

namespace ESPRGB_Client
{
    public partial class exceptions : Form
    {
        public exceptions(string title,string _Message,float fontSize = 12)
        {
            InitializeComponent();
            this.Text = title;
            message.Font = new Font("Microsoft Sans Serif", fontSize, FontStyle.Regular, GraphicsUnit.Point, 0);
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
            this.DialogResult = DialogResult.OK;
        }

        private void noButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
