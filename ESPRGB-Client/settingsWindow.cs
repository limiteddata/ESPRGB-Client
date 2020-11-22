using Microsoft.Win32;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Un4seen.Bass;
using Un4seen.BassWasapi;

namespace ESPRGB_Client
{
    public partial class settingsWindow : Form
    {
        RegistryKey startup_explorer = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\StartupApproved\\Run", true);
        RegistryKey startup_run = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Run", true);
        public settingsWindow()
        {
            InitializeComponent();
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

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void startupCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (startupCheckbox.Checked) startupCheckbox.Image = Properties.Resources.bool_1;
            else startupCheckbox.Image = Properties.Resources.bool_0;
        }
        private void startupCheckbox_Click(object sender, EventArgs e)
        {
            if (startupCheckbox.Checked)
            {
                byte[] bytearr = { 02, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00 };
                startup_explorer.SetValue("ESPRGB-Client", bytearr);
                startup_run.SetValue("ESPRGB-Client", Application.ExecutablePath);
            }
            else
            {
                startup_explorer.DeleteValue("ESPRGB-Client");
                startup_run.DeleteValue("ESPRGB-Client");
            }
        }
        private void settingsWindow_Load(object sender, EventArgs e)
        {
            var devices = ESPRGB.updateAudioDevices();
            DeviceBox.Items.Clear();
            foreach (var item in devices) DeviceBox.Items.Add(item.Key);
            DeviceBox.SelectedItem = (string)ESPRGB.selectedaudioDevices["fullName"];

            byte[] value = startup_explorer.GetValue("ESPRGB-Client") as byte[];

            if (value != null)
            {
                byte[] bytearr = { 02,00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00};
                if (value.SequenceEqual(bytearr)) startupCheckbox.Checked = true;
                else startupCheckbox.Checked = false;
            }
        }

        private void exitButtonBehavior_CheckedChanged(object sender, EventArgs e)
        {
            if (exitButtonBehavior.Checked)
                exitButtonBehavior.Image = Properties.Resources.bool_1;
            else
                exitButtonBehavior.Image = Properties.Resources.bool_0;
        }

        private void DeviceBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ESPRGB.InitializeAudioDevice((string)DeviceBox.SelectedItem);
        }


    }
}
