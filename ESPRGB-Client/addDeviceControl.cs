using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json.Linq;
using WebSocketSharp;
using System.Timers;
using Tmds.MDns;
using System.Linq;

namespace ESPRGB_Client
{
    public partial class addDeviceControl : UserControl
    {
        List<Button> buttonList = new List<Button>();
        WebSocket ws;
        ServiceBrowser serviceBrowser;

        public addDeviceControl()
        {
            InitializeComponent();
        }
        private Button deviceButton(int x, int y,string name, string address)
        {
            Button newButton = new Button();
            newButton.BackColor = System.Drawing.Color.FromArgb(46, 46, 54);
            newButton.FlatAppearance.BorderSize = 0;
            newButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            newButton.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            newButton.ForeColor = System.Drawing.Color.White;
            newButton.Image = global::ESPRGB_Client.Properties.Resources.esprgb_icon_45;
            newButton.ImageAlign = System.Drawing.ContentAlignment.TopCenter;                     
            newButton.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
            newButton.Size = new System.Drawing.Size(80, 95);           
            newButton.TextAlign = ContentAlignment.BottomCenter;
            newButton.UseVisualStyleBackColor = false;
            newButton.Location = new System.Drawing.Point(x, y);
            newButton.Name = name;
            newButton.Text = name.Split('-')[1].Split('.')[0] + "\n" + address;
            newButton.DoubleClick += new EventHandler((sender, e) => saveDevice());
            newButton.Click += new EventHandler((sender, e) => ipAddress.Text = (sender as Button).Name);     
            return newButton;
        }
        private bool AddNewButtonToList(string name, string address)
        {
            foreach (var item in buttonList) if (item.Name == name) return false;
            Button newButton = null;
            if (buttonList.Count > 0)
            {
                int x = 0;
                int y = 0;
                if ( (buttonList.Count % 5) == 0)
                {
                    x = 0;
                    y = buttonList[buttonList.Count - 1].Location.Y + 105;
                }
                else
                {
                    x = buttonList[buttonList.Count - 1].Location.X + 90;
                    y = buttonList[buttonList.Count - 1].Location.Y;   
                }
                newButton = deviceButton(x, y, name, address);
            }
            else newButton = deviceButton(0, 0, name, address);              
            buttonList.Add(newButton);
            this.devicePanel.Controls.Add(newButton);
            return true;
        }
        private void clearDevices()
        {
            buttonList.Clear();          
            devicePanel.Controls.Clear();
        }
        private void connectButton__Click(object sender, EventArgs e)
        {          
            if (ipAddress.Text != "" )
            {
                status.Text = "Connecting...";
                ws = new WebSocket("ws://" + ipAddress.Text + ":81/");
                ws.OnOpen += (wssender, wse) =>
                {
                    this.Invoke(new MethodInvoker(delegate
                    {
                        status.Text = "Connected";
                        disconnectButton.Visible = true;
                        connectButton_.Visible = false;

                    }));
                };
                ws.OnClose += (wssender, wse) =>
                {
                    this.Invoke(new MethodInvoker(delegate
                    {
                        status.Text = "Can't connect";
                    }));
                };
                ws.ConnectAsync();
            }
            else
            {
                exceptions exitMessage = new exceptions("ESPRGB-Exception", "Enter ipaddress");
                exitMessage.StartPosition = FormStartPosition.CenterParent;
                exitMessage.ShowDialog();
            }                     
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            saveDevice();
        }

        private async void saveDevice()
        {
            if (ipAddress.Text == "")
            {
                exceptions exitMessage = new exceptions("ESPRGB-Exception", "Enter ipaddress");
                exitMessage.StartPosition = FormStartPosition.CenterParent;
                exitMessage.ShowDialog();
                return;
            }
            foreach (var item in ESPRGB._appControls)
            {
                if (item.ipaddress == ipAddress.Text)
                {
                    exceptions exitMessage = new exceptions("ESPRGB-Exception", "Device already exists");
                    exitMessage.StartPosition = FormStartPosition.CenterParent;
                    exitMessage.ShowDialog();
                    return;
                }
            }

            try
            {
                if (ws != null && ws.IsAlive)
                    ws.Close();
                var jsonString = "";
                using (StreamReader file = new StreamReader(ESPRGB.fileLocation.FullName, false)) jsonString = await file.ReadToEndAsync();
                var dataJson = JObject.Parse(jsonString);
                JArray items = (JArray)dataJson["Devices"];

                var newData = new JObject();

                string name;
                try
                {
                    name = (ipAddress.Text.Split('-')[1]).Split('.')[0];
                }
                catch
                {
                    name = ipAddress.Text;
                }

                newData.Add("name", name);
                newData.Add("ipaddress", ipAddress.Text);
                newData.Add("syncDevice", false);
                items.Add(newData);

                using (StreamWriter file = new StreamWriter(ESPRGB.fileLocation.FullName, false)) await file.WriteAsync(dataJson.ToString());
                ESPRGB.addThisTab(name, ipAddress.Text);
            }
            catch
            {
            }
        }

        System.Timers.Timer scanTimer;
        void startmDnsScan()
        {
            message.Text = "Searching for your esprgb devices";
            clearDevices();

            scanTimer = new System.Timers.Timer();
            scanTimer.Elapsed += scanTimer_Tick;
            scanTimer.AutoReset = false;
            scanTimer.Interval = 30000;

            string serviceType = "_esprgb._tcp";

            serviceBrowser = new ServiceBrowser();
            serviceBrowser.ServiceAdded += (object sender, ServiceAnnouncementEventArgs e) =>
            {
                message.Text = "";
                AddNewButtonToList(e.Announcement.Hostname.ToString()+".local", string.Join(", ", e.Announcement.Addresses));
            };
            serviceBrowser.StartBrowse(serviceType);
            scanTimer.Start();
        }

        private void scanTimer_Tick(object sender, EventArgs e)
        {
            scanTimer.Stop();
            serviceBrowser.StopBrowse();
            this.Invoke(new MethodInvoker(delegate
            {
                if (buttonList.Count == 0)
                {
                        message.Text = "Couldn't find any esprgb devices in your network";                                 
                }
                resScnDevice.Visible = true;
            }));
        }
        private void addDeviceControl_Load(object sender, EventArgs e)
        {

        }

        private void scnDevice_Click(object sender, EventArgs e)
        {
            scnDevice.Visible = false;
            startmDnsScan();
        }

        private void resScnDevice_Click(object sender, EventArgs e)
        {
            resScnDevice.Visible = false;
            startmDnsScan();
        }

        private void disconnectButton_Click(object sender, EventArgs e)
        {
            ws.Close();
            status.Text = "Disconnected";
            disconnectButton.Visible = false;
            connectButton_.Visible = true;
        }
    }
}
