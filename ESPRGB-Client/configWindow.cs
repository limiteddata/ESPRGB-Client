using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Http;
using Newtonsoft.Json.Linq;

namespace ESPRGB_Client
{
    public partial class configWindow : Form
    {

        string ipaddress = "";
        HttpClient client = new HttpClient();
        List<int> availablePins = new List<int>() {0,1,2,3,4,5,12,13,14,15,16};
        public configWindow(string ip)
        {
            InitializeComponent();
            ipaddress = ip;
        }
        private void configWindow_Shown(object sender, EventArgs e)
        {            
            getConfigasync();
        }
        async void getConfigasync()
        {
            try
            {
                var result = await client.GetAsync("http://" + ipaddress + "/returnConfigData");
                var dataJson = JObject.Parse(await result.Content.ReadAsStringAsync());
                string savedSSID = "";
                if (dataJson.ContainsKey("Initialized"))
                {
                    if ((bool)dataJson["Initialized"])
                    {

                        if (dataJson.ContainsKey("SSID"))
                        {
                            SSID.Text = (string)dataJson["SSID"];
                            savedSSID = (string)dataJson["SSID"];
                        }
                        if (dataJson.ContainsKey("PASSWORD")) PASSWORD.Text = (string)dataJson["PASSWORD"];
                        if (dataJson.ContainsKey("HOSTNAME")) HOSTNAME.Text = (string)dataJson["HOSTNAME"];
                        if (dataJson.ContainsKey("REDPIN")) REDPIN.Text = (string)dataJson["REDPIN"];
                        if (dataJson.ContainsKey("GREENPIN")) GREENPIN.Text = (string)dataJson["GREENPIN"];
                        if (dataJson.ContainsKey("BLUEPIN")) BLUEPIN.Text = (string)dataJson["BLUEPIN"];
                        if (dataJson.ContainsKey("BUZZERPIN")) BUZZERPIN.Text = (string)dataJson["BUZZERPIN"];
                        if (dataJson.ContainsKey("startStatic")) startStatic.Checked = (bool)dataJson["startStatic"];
                        if (dataJson.ContainsKey("local_IP")) local_IP.Text = (string)dataJson["local_IP"];
                        if (dataJson.ContainsKey("gateway")) gateway.Text = (string)dataJson["gateway"];
                        if (dataJson.ContainsKey("subnet")) subnet.Text = (string)dataJson["subnet"];
                        if (dataJson.ContainsKey("dns")) dns.Text = (string)dataJson["dns"];
                    }
                    checkOptions();
                }

                var wifis = await client.GetAsync("http://" + ipaddress + "/getWifi");
                var wifiJson = JObject.Parse(await wifis.Content.ReadAsStringAsync())["networks"];
                Dictionary<string, JArray> dict = new Dictionary<string, JArray>();

                for (int i = 0; i < wifiJson.Count(); i++)
                {
                    dict.Add((string)wifiJson[i][0], (JArray)wifiJson[i]);
                }
                SSID.DataSource = new BindingSource(dict, null);
                SSID.DisplayMember = "Value";
                SSID.ValueMember = "Key";
                SSID.Text = savedSSID;
            }
            catch (Exception)
            {
            }
        }
        private void SSID_SelectedIndexChanged(object sender, EventArgs e)
        {
            var item = ((KeyValuePair<string, JArray>)SSID.SelectedItem).Value;
            PASSWORD.Enabled = (bool)item[2];
        }
        private void SSID_KeyDown(object sender, KeyEventArgs e)
        {
            PASSWORD.Text = "";
        }
        Point lastPoint;
        private void messageBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }        
        private void messageBox_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }  
        private void startStatic_CheckedChanged(object sender, EventArgs e)
        {
            local_IP.Enabled = startStatic.Checked;
            gateway.Enabled = startStatic.Checked;
            subnet.Enabled = startStatic.Checked;
            dns.Enabled = startStatic.Checked;
        }
        private void sendButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(SSID.Text))
            {
                exceptions exitMessage = new exceptions("ESPRGB-Exception", "Please enter a valid SSID");
                exitMessage.StartPosition = FormStartPosition.CenterParent;
                exitMessage.ShowDialog();
                return;
            }
            if (string.IsNullOrWhiteSpace(PASSWORD.Text) && PASSWORD.Enabled)
            {
                exceptions exitMessage = new exceptions("ESPRGB-Exception", "Please enter a valid PASSWORD");
                exitMessage.StartPosition = FormStartPosition.CenterParent;
                exitMessage.ShowDialog();
                return;
            }
            if (string.IsNullOrWhiteSpace(HOSTNAME.Text))
            {
                exceptions exitMessage = new exceptions("ESPRGB-Exception", "Please enter a HOSTNAME");
                exitMessage.StartPosition = FormStartPosition.CenterParent;
                exitMessage.ShowDialog();
                return;
            }
            if (string.IsNullOrWhiteSpace(REDPIN.Text))
            {
                exceptions exitMessage = new exceptions("ESPRGB-Exception", "Please enter a REDPIN");
                exitMessage.StartPosition = FormStartPosition.CenterParent;
                exitMessage.ShowDialog();
                return;
            }
            if (string.IsNullOrWhiteSpace(GREENPIN.Text))
            {
                exceptions exitMessage = new exceptions("ESPRGB-Exception", "Please enter a GREENPIN");
                exitMessage.StartPosition = FormStartPosition.CenterParent;
                exitMessage.ShowDialog();
                return;
            }
            if (string.IsNullOrWhiteSpace(BLUEPIN.Text))
            {
                exceptions exitMessage = new exceptions("ESPRGB-Exception", "Please enter a BLUEPIN");
                exitMessage.StartPosition = FormStartPosition.CenterParent;
                exitMessage.ShowDialog();
                return;
            }
            if (string.IsNullOrWhiteSpace(local_IP.Text) && local_IP.Enabled)
            {
                exceptions exitMessage = new exceptions("ESPRGB-Exception", "Please enter a valid local IP");
                exitMessage.StartPosition = FormStartPosition.CenterParent;
                exitMessage.ShowDialog();
                return;
            }
            if (string.IsNullOrWhiteSpace(gateway.Text)&& gateway.Enabled)
            {
                exceptions exitMessage = new exceptions("ESPRGB-Exception", "Please enter a valid gateway");
                exitMessage.StartPosition = FormStartPosition.CenterParent;
                exitMessage.ShowDialog();
                return;
            }
            if (string.IsNullOrWhiteSpace(subnet.Text) && subnet.Enabled)
            {
                exceptions exitMessage = new exceptions("ESPRGB-Exception", "Please enter a valid subnet");
                exitMessage.StartPosition = FormStartPosition.CenterParent;
                exitMessage.ShowDialog();
                return;
            }
            if (string.IsNullOrWhiteSpace(dns.Text) && dns.Enabled)
            {
                exceptions exitMessage = new exceptions("ESPRGB-Exception", "Please enter a valid dns");
                exitMessage.StartPosition = FormStartPosition.CenterParent;
                exitMessage.ShowDialog();
                return;
            }
            exitMessage confirm = new exitMessage("ESPRGB-Exit", "Are you sure you want to save this config?");
            confirm.StartPosition = FormStartPosition.CenterParent;
            confirm.ShowDialog();
            if (confirm.DialogResult == DialogResult.Yes)
            {
                JObject obj =
                 new JObject(
                     new JProperty("ESP_Config",
                         new JObject(
                                new JProperty("SSID", new JValue(SSID.Text)),
                                new JProperty("PASSWORD", new JValue(PASSWORD.Text)),
                                new JProperty("HOSTNAME", new JValue(HOSTNAME.Text)),
                                new JProperty("REDPIN", new JValue(REDPIN.Text)),
                                new JProperty("GREENPIN", new JValue(GREENPIN.Text)),
                                new JProperty("BLUEPIN", new JValue(BLUEPIN.Text)),
                                new JProperty("BUZZERPIN", new JValue(BUZZERPIN.Text)))),
                     new JProperty("Network_Config",
                         new JObject(
                                new JProperty("startStatic", new JValue(startStatic.Checked)),
                                new JProperty("local_IP", new JValue(local_IP.Text)),
                                new JProperty("gateway", new JValue(gateway.Text)),
                                new JProperty("subnet", new JValue(subnet.Text)),
                                new JProperty("dns", new JValue(dns.Text)))));
                        try
                        {
                            var data = new StringContent(obj.ToString(), Encoding.UTF8, "application/json");
                            client.PostAsync("http://" + ipaddress + "/sendConfig", data);
                            this.Close();
                        }
                        catch (Exception) { }
            }
        }
        private void testButton_R_Click(object sender, EventArgs e)
        {
            testPin(REDPIN.Text);
        }
        private void testButton_G_Click(object sender, EventArgs e)
        {
            testPin(GREENPIN.Text);
        }
        private void testButton_B_Click(object sender, EventArgs e)
        {
            testPin(BLUEPIN.Text);
        }
        private void testbutton_bz_Click(object sender, EventArgs e)
        {
            testPin(BUZZERPIN.Text);
        }
        async void testPin(string pin)
        {
            try
            {
                var data = new StringContent(pin, Encoding.UTF8, "application/json");
                var response = await client.PostAsync("http://" + ipaddress + "/pinTester", data);
                pinResponse.Text = response.Content.ReadAsStringAsync().Result;
            }
            catch (Exception) { }
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void checkOptions()
        {
            List<int> usedPins = new List<int>();
            usedPins.AddRange(availablePins);
            
            REDPIN.Items.Clear();
            GREENPIN.Items.Clear();
            BLUEPIN.Items.Clear();
            BUZZERPIN.Items.Clear();

            usedPins.Remove(Convert.ToInt32(REDPIN.Text));
            usedPins.Remove(Convert.ToInt32(GREENPIN.Text));
            usedPins.Remove(Convert.ToInt32(BLUEPIN.Text));
            usedPins.Remove(Convert.ToInt32(BUZZERPIN.Text));

            foreach (var item in usedPins)
            {
                REDPIN.Items.Add(item);
                GREENPIN.Items.Add(item);
                BLUEPIN.Items.Add(item);
                BUZZERPIN.Items.Add(item);
            }
        }

        private void PIN_Click(object sender, EventArgs e)
        {
            checkOptions();
        }


    }
}
