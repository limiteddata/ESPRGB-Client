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

        public string savedDevice = "";
        public settingsWindow()
        {
            InitializeComponent();
            setAudioDevices();
        }
        void setAudioDevices()
        {
            DeviceBox.Items.Clear();
            var defaultDev = getDefaultDevice();
            var OutDevices = getOutputDevices();
            int findDev = DeviceBox.FindString(savedDevice);
            for (int i = 0; i < OutDevices.Count; i++)
            {
                DeviceBox.Items.Add(OutDevices[i]);
                if (OutDevices[i].Split('-')[1] == defaultDev && findDev == -1) DeviceBox.SelectedIndex = i;
            }         
            if (savedDevice != "" && findDev != -1) DeviceBox.SelectedIndex = findDev;
        }
        public List<string> getOutputDevices()
        {
            var devlist = new List<string>();
            BASS_WASAPI_DEVICEINFO info = new BASS_WASAPI_DEVICEINFO();
            for (int n = 0; BassWasapi.BASS_WASAPI_GetDeviceInfo(n, info); n++)
            {
                if (info.IsEnabled && info.IsLoopback) devlist.Add(string.Format("{0}-{1}", n, info.name));
            }
            return devlist;
        }
        public string getDefaultDevice()
        {
            string defaultDevice = "";
            BASS_WASAPI_DEVICEINFO info = new BASS_WASAPI_DEVICEINFO();
            for (int n = 0; BassWasapi.BASS_WASAPI_GetDeviceInfo(n, info); n++)
            {
                if (info.IsEnabled && info.IsDefault && !info.IsInput) defaultDevice = info.name;
            }
            return defaultDevice;
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
            byte[] value = startup_explorer.GetValue("ESPRGB-Client") as byte[];

            if (value != null)
            {
                byte[] bytearr = { 02,00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00};
                if (value.SequenceEqual(bytearr)) startupCheckbox.Checked = true;
                else startupCheckbox.Checked = false;
            }
            
        }

        private void startState_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (File.Exists(ESPRGB.fileLocation.FullName))
            {
                string jsonString = File.ReadAllText(ESPRGB.fileLocation.FullName);
                var dataJson = JObject.Parse(jsonString);
                dataJson["Settings"]["startApp"] = startState.SelectedItem.ToString();
                File.WriteAllText(ESPRGB.fileLocation.FullName, dataJson.ToString());
            }
        }

        private void exitButtonBehavior_CheckedChanged(object sender, EventArgs e)
        {
            if (File.Exists(ESPRGB.fileLocation.FullName))
            {
                if (exitButtonBehavior.Checked)
                    exitButtonBehavior.Image = Properties.Resources.bool_1;
                else
                    exitButtonBehavior.Image = Properties.Resources.bool_0;

                string jsonString = File.ReadAllText(ESPRGB.fileLocation.FullName);
                var dataJson = JObject.Parse(jsonString);
                dataJson["Settings"]["closeButtonMinimize"] = exitButtonBehavior.Checked;
                File.WriteAllText(ESPRGB.fileLocation.FullName, dataJson.ToString());
            }
        }

        private void DeviceBox_DropDown(object sender, EventArgs e)
        {
            setAudioDevices();
        }

        private void DeviceBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            BassWasapi.BASS_WASAPI_Stop(true);
            BassWasapi.BASS_WASAPI_Free();
            Bass.BASS_Free();

            try
            {
                Bass.BASS_Init(0, 44100, BASSInit.BASS_DEVICE_DEFAULT, IntPtr.Zero);
                BassWasapi.BASS_WASAPI_Init(Convert.ToInt32(DeviceBox.SelectedItem.ToString().Split('-')[0]), 0, 0, BASSWASAPIInit.BASS_WASAPI_BUFFER, 1f, 0.05f, ESPRGB._process, IntPtr.Zero);
                BassWasapi.BASS_WASAPI_Start();
                if (File.Exists(ESPRGB.fileLocation.FullName))
                {
                    string jsonString = File.ReadAllText(ESPRGB.fileLocation.FullName);
                    var dataJson = JObject.Parse(jsonString);
                    dataJson["Settings"]["savedAudioDevice"] = (string)DeviceBox.SelectedItem;
                    File.WriteAllText(ESPRGB.fileLocation.FullName, dataJson.ToString());
                }
            }
            catch 
            {
            }

        }


    }
}
