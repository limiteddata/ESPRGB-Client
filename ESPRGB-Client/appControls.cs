using System;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json.Linq;
using WebSocketSharp;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using Un4seen.BassWasapi;
using Un4seen.Bass;
using System.Threading;
using System.Net.Http;
using Cyotek.Windows.Forms;
using System.Diagnostics;
using System.Threading.Tasks;

namespace ESPRGB_Client
{
    public partial class appControls : UserControl
    {
        public WebSocket ws;
        public bool connAlive;
        public string ipaddress;
        public string name;
        public System.Timers.Timer reconnectTimer;
        public System.Timers.Timer rssiTimer;
        public System.Timers.Timer scheduleTimer;

        int timeout;
        private float[] _fft = new float[1024];
        int[] spectrum = new int[16];

        public bool sync_device
        {
            get { return _sync_device; }
            set
            {
                if (_sync_device != value)
                {
                    if (value)
                    {
                        syncButton.Image = Properties.Resources.sync_1;
                        syncButton.ForeColor = Color.FromArgb(6, 215, 156);
                    }
                    else
                    {
                        syncButton.Image = Properties.Resources.sync_0;
                        syncButton.ForeColor = Color.White;
                    }
                    stripSync.Checked = value;
                    _sync_device = value;
                }
            }
        }
        private bool _sync_device;
        public bool powerConected
        {
            get { return _powerConected; }
            set
            {
                if (_powerConected != value)
                {
                    if (value)
                    {
                        powerConectedButton.Image = Properties.Resources.power_1;
                        powerConectedButton.ForeColor = Color.FromArgb(6, 215, 156);
                    }
                    else
                    {
                        powerConectedButton.Image = Properties.Resources.power_0;
                        powerConectedButton.ForeColor = Color.White;
                    }

                    _powerConected = value;

                    string data = "{\"Animations\":{\"powerConected\":" + value.ToString().ToLower() + "}}";
                    if (sync_device) ESPRGB.broadcastTxT(this, data, true);
                    else ws.SendAsync(data, null);
                }
            }
        }
        private bool _powerConected;
        public appControls()
        {
            InitializeComponent();
            tabctrl.Visible = false;
            tabctrl.Visible = true;

            reconnectTimer = new System.Timers.Timer();
            reconnectTimer.Elapsed += reconnect_Tick;
            reconnectTimer.Interval = 1000;

            rssiTimer = new System.Timers.Timer();
            rssiTimer.Interval = 10000;
            rssiTimer.Elapsed += rssiTimer_Tick;

            scheduleTimer = new System.Timers.Timer();
            scheduleTimer.Interval = 3000;
            scheduleTimer.Elapsed += schTimer_Tick;

            selectionColor.SelectedIndex = 0;

            InitializeBitmapAndGraphics();
            initializeSolidDiscoVisualizer();

        }
        private void appControls_Load(object sender, EventArgs e)
        {
            Disposed += OnDispose;
        }
        int index;
        private void OnDispose(object sender, EventArgs e)
        {
            ws.CloseAsync(CloseStatusCode.Away);
            reconnectTimer.Dispose();
            rssiTimer.Dispose();
            scheduleTimer.Dispose();
        }
        private void reconnect_Tick(object sender, EventArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                if (index > 0)
                {
                    index--;
                    statusLabel.Text = "Reconnecting in " + index + " sec";
                }
                else
                {
                    reconnectTimer.Enabled = false;
                    ConnectDevice();
                }
            });
        }
        void enableControls(bool enable)
        {
            foreach (TabPage page in tabctrl.TabPages)
            {
                foreach (Control ctrl in page.Controls)
                {
                    if ((string)ctrl.Tag != "DontDisable") ctrl.Enabled = enable;
                }
            }
            stripSolidColor.Enabled = enable;
            stripColorCycle.Enabled = enable;
            stripBreathing.Enabled = enable;
            stripDisco.Enabled = enable;
            stripSolidDisco.Enabled = enable;
            stripMorseCode.Enabled = enable;
            stripSync.Enabled = enable;
            discoGfx.Clear(Color.FromArgb(255, 21, 32, 54));
            gfxSolidDisco.Clear(Color.FromArgb(255, 21, 32, 54));
            ResultColor.BackColor = Color.Black;
        }
        public async Task ConnectDevice()
        {
            reconnectTimer.Enabled = false;
            statusLabel.Text = "Connecting...";
            try
            {
                using (var client = new HttpClient())
                {
                    var result = await client.GetAsync($"http://{ipaddress}/getVersion");
                    var responseBody = JObject.Parse(await result.Content.ReadAsStringAsync());
                    if (responseBody.ContainsKey("ESPRGB_VERSION"))
                    {
                        var esp_vers = new Version((string)responseBody["ESPRGB_VERSION"]);
                        espVersion.Text = (string)responseBody["ESPRGB_VERSION"];

                        Version curr = typeof(ESPRGB).Assembly.GetName().Version;
                        if (curr != esp_vers)
                        {
                            exceptions msg = new exceptions(1, "ESPRGB-FirmwareUpdate", "ESPRGB Version is not compatible with the client.\n Want to update to " + curr.ToString() + " ?", 10);
                            msg.StartPosition = FormStartPosition.CenterParent;
                            msg.ShowDialog();

                            if (msg.DialogResult == DialogResult.Yes)
                            {
                                firmwareUpdater fu = new firmwareUpdater(ipaddress, curr.ToString());
                                fu.StartPosition = FormStartPosition.CenterParent;
                                fu.ShowDialog();


                            }
                        }
                    }
                }
            }
            catch (System.Net.Http.HttpRequestException e)
            {
                statusLabel.Text = "Can't resolve ipaddress";
                await Task.Delay(2000);
                reconnectTimer.Enabled = true;
                timeout++;
                switch (timeout)
                {
                    case 1:
                        index = 3;
                        break;
                    case 2:
                        index = 15;
                        break;
                    case 3:
                        index = 30;
                        break;
                    case 4:
                        index = 60;
                        break;
                    default:
                        index = 60;
                        break;
                }
                return;
            }
            catch (Exception e)
            {
                statusLabel.Text = "Can't find version";
                return;
            }
            ws = new WebSocket("ws://" + ipaddress + ":81/");

            ws.OnOpen += (senders, es) =>
            {
                if (sync_device)
                {
                    ESPRGB._syncDevices.Add(this);
                    Thread c = new Thread(() => { if (!ESPRGB.checkSyncDevices()) ESPRGB.syncAllDevices(); });
                    c.Start();
                }
                this.Invoke((MethodInvoker)delegate
                {
                    reconnectTimer.Enabled = false;
                    rssiTimer.Start();
                    timeout = 0;
                    connAlive = true;
                    statusLabel.Text = "Connected";
                    connectButton.ForeColor = Color.FromArgb(6, 215, 156);
                    connectButton.Image = Properties.Resources.wifi_green;
                    connectButton.Text = "\n \n Disconnect";
                    enableControls(true);
                    if (enableAppSchedule.Checked) scheduleTimer.Start();
                });
                string data = "{\"command\":\"restartAnimation\"}";
                if (sync_device) ESPRGB.broadcastTxT(this, data, false);
                else ws.SendAsync(data, null);

            };
            ws.OnMessage += (ids, messages) =>
            {
                setControls(messages.Data);
            };
            ws.OnClose += (senders, es) =>
            {
                if (sync_device) ESPRGB._syncDevices.Remove(this);
                this.Invoke((MethodInvoker)delegate
                {
                    connAlive = false;
                    rssiTimer.Stop();
                    discoTimer.Enabled = false;
                    solidDiscoTimer.Enabled = false;
                    scheduleTimer.Stop();
                    wifiImageBox.Image = null;
                    this.statusLabel.Text = "Disconnected";
                    connectButton.Image = Properties.Resources.wifi_white;
                    connectButton.ForeColor = Color.White;
                    this.connectButton.Text = "\n \n Connect";
                    enableControls(false);
                });
                if (!es.WasClean && es.Code == (ushort)CloseStatusCode.Abnormal)
                {
                    reconnectTimer.Enabled = true;
                    timeout++;
                    switch (timeout)
                    {
                        case 1:
                            index = 3;
                            break;
                        case 2:
                            index = 15;
                            break;
                        case 3:
                            index = 30;
                            break;
                        case 4:
                            index = 60;
                            break;
                        default:
                            index = 60;
                            break;
                    }
                }
            };

            ws.OnError += (sender, es) =>
            {
                if (sync_device) ESPRGB._syncDevices.Remove(this);
                this.Invoke((MethodInvoker)delegate
                {
                    connAlive = false;
                    rssiTimer.Stop();
                    discoTimer.Enabled = false;
                    solidDiscoTimer.Enabled = false;
                    scheduleTimer.Stop();
                    wifiImageBox.Image = null;
                    this.statusLabel.Text = "Disconnected";
                    connectButton.Image = Properties.Resources.wifi_white;
                    connectButton.ForeColor = Color.White;
                    this.connectButton.Text = "\n \n Connect";
                    enableControls(false);
                });
                reconnectTimer.Enabled = true;
                index = 15;          
            };
            ws.WaitTime = TimeSpan.FromSeconds(3);
            ws.ConnectAsync();
            if (!connAlive)
                enableControls(false);
        }
        private void tabctrl_DoubleClick(object sender, EventArgs e)
        {
            if ((string)tabctrl.SelectedTab.Tag != "NotAnimationTab") selectAnimation(tabctrl.SelectedTab.Text);
        }

        public string savedControls;
        public void selectAnimation(string animation, string parameters = null)
        {
            JObject SendData = new JObject();

            if (parameters != null)
            {
                setControls(parameters);
                SendData = JObject.Parse(parameters);
            }
            string data = "{\"Animations\":{\"playingAnimation\":\"" + animation + "\"}}";
            SendData.Merge(JObject.Parse(data));
            if (sync_device) ESPRGB.broadcastTxT(this, SendData.ToString(Newtonsoft.Json.Formatting.None), true);
            else ws.SendAsync(SendData.ToString(Newtonsoft.Json.Formatting.None), null);
        }
        public string playingAnimation
        {
            get { return _playingAnimation; }
            set
            {
                stripSolidColor.Checked = false;
                stripColorCycle.Checked = false;
                stripBreathing.Checked = false;
                stripDisco.Checked = false;
                stripSolidDisco.Checked = false;
                stripMorseCode.Checked = false;
                stripSolidColor.Checked = false;
                startColorCycle.Checked = false;
                startBreathing.Checked = false;
                startDisco.Checked = false;
                startSolidDisco.Checked = false;
                stripSolidDisco.Checked = false;
                startMorseCode.Checked = false;
                stripMorseCode.Checked = false;
                startAmbilight.Checked = false;
                stripAmbilight.Checked = false;
                switch (value)
                {
                    case "Solid Color":
                        stripSolidColor.Checked = true;
                        break;
                    case "Color Cycle":
                        stripColorCycle.Checked = true;
                        startColorCycle.Checked = true;
                        break;
                    case "Breathing":
                        stripBreathing.Checked = true;
                        startBreathing.Checked = true;
                        break;
                    case "Disco":
                        stripDisco.Checked = true;
                        startDisco.Checked = true;
                        break;
                    case "Solid Disco":
                        stripSolidDisco.Checked = true;
                        startSolidDisco.Checked = true;
                        break;
                    case "Morse Code":
                        stripMorseCode.Checked = true;
                        startMorseCode.Checked = true;
                        break;
                    case "Ambilight":
                        startAmbilight.Checked = true;
                        stripAmbilight.Checked = true;
                        break;
                }
                statusLabel.Text = "Playing: \n" + value;
                _playingAnimation = value;
            }
        }
        private string _playingAnimation;
        public ToolStripMenuItem stripSolidColor, stripColorCycle, stripBreathing, stripDisco, stripSolidDisco, stripMorseCode, stripAmbilight, stripSync;
        public ToolStripMenuItem trayAnimations(string name)
        {
            var deviceOptions = new ToolStripMenuItem(name);
            deviceOptions.BackColor = Color.FromArgb(255, 21, 32, 54);
            deviceOptions.ForeColor = Color.White;
            deviceOptions.DisplayStyle = ToolStripItemDisplayStyle.Text;
            stripSolidColor = new ToolStripMenuItem("Solid Color");
            stripSolidColor.Checked = true;
            stripSolidColor.Click += (sx, ex) => selectAnimation("Solid Color");
            stripSolidColor.ForeColor = Color.White;
            stripSolidColor.BackColor = Color.FromArgb(255, 21, 32, 54);
            stripColorCycle = new ToolStripMenuItem("Color Cycle");
            stripColorCycle.Click += (sx, ex) => selectAnimation("Color Cycle");
            stripColorCycle.ForeColor = Color.White;
            stripColorCycle.BackColor = Color.FromArgb(255, 21, 32, 54);
            stripBreathing = new ToolStripMenuItem("Breathing");
            stripBreathing.Click += (sx, ex) => selectAnimation("Breathing");
            stripBreathing.ForeColor = Color.White;
            stripBreathing.BackColor = Color.FromArgb(255, 21, 32, 54);
            stripDisco = new ToolStripMenuItem("Disco");
            stripDisco.Click += (sx, ex) => selectAnimation("Disco");
            stripDisco.ForeColor = Color.White;
            stripDisco.BackColor = Color.FromArgb(255, 21, 32, 54);
            stripSolidDisco = new ToolStripMenuItem("Solid Disco");
            stripSolidDisco.Click += (sx, ex) => selectAnimation("Solid Disco");
            stripSolidDisco.ForeColor = Color.White;
            stripSolidDisco.BackColor = Color.FromArgb(255, 21, 32, 54);
            stripMorseCode = new ToolStripMenuItem("Morse Code");
            stripMorseCode.Click += (sx, ex) => selectAnimation("Morse Code");
            stripMorseCode.ForeColor = Color.White;
            stripMorseCode.BackColor = Color.FromArgb(255, 21, 32, 54);
            stripAmbilight = new ToolStripMenuItem("Ambilight");
            stripAmbilight.Click += (sx, ex) => selectAnimation("Ambilight");
            stripAmbilight.ForeColor = Color.White;
            stripAmbilight.BackColor = Color.FromArgb(255, 21, 32, 54);
            stripSync = new ToolStripMenuItem("Sync Device");
            stripSync.Click += (sx, ex) => syncButton_Click(null, null);
            stripSync.ForeColor = Color.White;
            stripSync.BackColor = Color.FromArgb(255, 21, 32, 54);
            deviceOptions.DropDownItems.AddRange(new ToolStripItem[] { stripSolidColor, stripColorCycle, stripBreathing, stripDisco, stripSolidDisco, stripMorseCode, stripAmbilight, stripSync });

            return deviceOptions;
        }
        public void setControls(string msg)
        {
            var json = JObject.Parse(msg);
            if (json.ContainsKey("Animations")) json = json["Animations"].ToObject<JObject>();

            this.Invoke((MethodInvoker)delegate
            {
                if (json.ContainsKey("parameters"))
                {
                    var param = json["parameters"].ToObject<JObject>();
                    if (param.ContainsKey("SolidColor"))
                    {
                        JObject SolidColor = param["SolidColor"].ToObject<JObject>();
                        if (SolidColor.ContainsKey("Color"))
                        {
                            Color newColor = Color.FromArgb(255, (int)SolidColor["Color"][0] / 4, (int)SolidColor["Color"][1] / 4, (int)SolidColor["Color"][2] / 4);
                            colorWheel.Color = newColor;
                            brightnessSlide.RegionColor = newColor;
                            brightnessSlide.LeftColor = newColor;
                            brightnessSlide.GradientColor = newColor;
                            brightnessSlide.Update();
                        }
                        if (SolidColor.ContainsKey("Brightness"))
                        {
                            float brightness = (float)SolidColor["Brightness"];
                            brightnessSlide.Value = (int)(brightness * 100);
                            Color newColor = Color.FromArgb(255, (int)(colorWheel.Color.R * brightness), (int)(colorWheel.Color.G * brightness), (int)(colorWheel.Color.B * brightness));
                            brightnessSlide.LeftColor = newColor;
                            brightnessSlide.RegionColor = newColor;
                            brightnessSlide.GradientColor = newColor;
                            brightnessSlide.Update();
                        }
                    }
                    if (param.ContainsKey("ColorCycle"))
                    {
                        JObject ColorCycle = param["ColorCycle"].ToObject<JObject>();
                        if (ColorCycle.ContainsKey("ColorCycleSpeed"))
                        {
                            ColorCycleSpeed.Value = (int)ColorCycle["ColorCycleSpeed"];
                            ColorCycleSpeedText.Text = (string)ColorCycle["ColorCycleSpeed"];
                        }
                    }
                        if (param.ContainsKey("Breathing"))
                        {
                            JObject Breathing = param["Breathing"].ToObject<JObject>();
                            if (Breathing.ContainsKey("breathingSpeed"))
                            {
                                breathingSpeed.Value = (int)Breathing["breathingSpeed"];
                                breathingSpeedText.Text = (string)Breathing["breathingSpeed"];
                            }
                            if (Breathing.ContainsKey("staticColorBreathing")) colorBreathing.Color = Color.FromArgb(255, (int)Breathing["staticColorBreathing"][0] / 4, (int)Breathing["staticColorBreathing"][1] / 4, (int)Breathing["staticColorBreathing"][2] / 4);

                            if (Breathing.ContainsKey("colorListBreathing"))
                            {
                                List<Color> col = new List<Color>();
                                JArray colArray = (JArray)Breathing["colorListBreathing"];
                                colorListResult.clearAll();
                                if (colArray.Count > 0)
                                {
                                    foreach (JArray item in colArray)
                                    {
                                        if (item.Count == 3) col.Add(Color.FromArgb(255, (int)item[0] / 4, (int)item[1] / 4, (int)item[2] / 4));
                                    }
                                    colorListResult.addListColor(col);
                                }
                            }
                            if (Breathing.ContainsKey("useColorList")) useColorList.Checked = (bool)Breathing["useColorList"];
                        }

                        if (param.ContainsKey("MorseCode"))
                        {
                            JObject MorseCode = param["MorseCode"].ToObject<JObject>();
                            if (MorseCode.ContainsKey("useBuzzer")) useBuzzer.Checked = (bool)MorseCode["useBuzzer"];
                            if (MorseCode.ContainsKey("colorMorseCode")) morseColor.Color = Color.FromArgb(255, (int)MorseCode["colorMorseCode"][0] / 4, (int)MorseCode["colorMorseCode"][1] / 4, (int)MorseCode["colorMorseCode"][2] / 4);
                            if (MorseCode.ContainsKey("unitTimeMorseCode")) unitTime.Value = (int)MorseCode["unitTimeMorseCode"];
                            if (MorseCode.ContainsKey("encodedMorseCode"))
                            {
                                morsePlainText.Text = decodeMessage((string)MorseCode["encodedMorseCode"]);
                                encodedMsgResult.Text = (string)MorseCode["encodedMorseCode"];
                            }
                            if (MorseCode.ContainsKey("startMorseCode")) startMorseCode.Checked = (bool)MorseCode["startMorseCode"];
                        }
                        if (param.ContainsKey("Disco"))
                        {
                            JObject Disco = param["Disco"].ToObject<JObject>();

                            if (Disco.ContainsKey("DiscoColors"))
                            {
                                colorslider1.color1.Color = Color.FromArgb(255, (int)Disco["DiscoColors"][0][0], (int)Disco["DiscoColors"][0][1], (int)Disco["DiscoColors"][0][2]);
                                colorslider1.color2.Color = Color.FromArgb(255, (int)Disco["DiscoColors"][1][0], (int)Disco["DiscoColors"][1][1], (int)Disco["DiscoColors"][1][2]);
                                colorslider1.color3.Color = Color.FromArgb(255, (int)Disco["DiscoColors"][2][0], (int)Disco["DiscoColors"][2][1], (int)Disco["DiscoColors"][2][2]);
                                colorslider1.Refresh();
                            }
                            if (Disco.ContainsKey("DiscoRange"))
                            {
                                colorslider1.SelectedMin = (int)Disco["DiscoRange"][0];
                                colorslider1.SelectedMax = (int)Disco["DiscoRange"][1];
                                colorslider1.Refresh();
                            }
                            if (Disco.ContainsKey("DiscoSensitivity"))
                            {
                                lowSensitivity.Value = (int)Disco["DiscoSensitivity"][0];
                                midSensitivity.Value = (int)Disco["DiscoSensitivity"][1];
                                highSensitivity.Value = (int)Disco["DiscoSensitivity"][2];
                            }

                            if (Disco.ContainsKey("DiscoLowsBrightness")) lowsBrightness.Value = (int)Disco["DiscoLowsBrightness"];
                            if (Disco.ContainsKey("DiscoMidsBrightness")) midsBrightness.Value = (int)Disco["DiscoMidsBrightness"];
                            if (Disco.ContainsKey("DiscoHighsBrightness")) highsBrightness.Value = (int)Disco["DiscoHighsBrightness"];
                            if (Disco.ContainsKey("DiscoAudioDevice"))
                            {
                                ESPRGB.InitializeAudioDevice((string)Disco["DiscoAudioDevice"]);
                            }
                        }
                        if (param.ContainsKey("SolidDisco"))
                        {
                            JObject SolidDisco = param["SolidDisco"].ToObject<JObject>();
                            if (SolidDisco.ContainsKey("colorSolidDisco"))
                            {
                                colorWheel_SolidDisco.Color = Color.FromArgb((int)SolidDisco["colorSolidDisco"][0] / 4, (int)SolidDisco["colorSolidDisco"][1] / 4, (int)SolidDisco["colorSolidDisco"][2] / 4);
                                colorslider_simple.color.Color = Color.FromArgb((int)SolidDisco["colorSolidDisco"][0] / 4, (int)SolidDisco["colorSolidDisco"][1] / 4, (int)SolidDisco["colorSolidDisco"][2] / 4);
                                colorslider_simple.Refresh();
                            }
                            if (SolidDisco.ContainsKey("SolidDiscoRandom")) randomColor.Checked = (bool)SolidDisco["SolidDiscoRandom"];
                            if (SolidDisco.ContainsKey("SolidDiscoRange"))
                            {
                                colorslider_simple.SelectedMin = (int)SolidDisco["SolidDiscoRange"][0];
                                colorslider_simple.SelectedMax = (int)SolidDisco["SolidDiscoRange"][1];
                                colorslider_simple.Refresh();
                            }
                            if (SolidDisco.ContainsKey("SolidDiscoAudioDevice"))
                            {
                                ESPRGB.InitializeAudioDevice((string)SolidDisco["SolidDiscoAudioDevice"]);
                            }
                        }
                        if (param.ContainsKey("Ambilight"))
                        {
                            JObject Ambilight = param["Ambilight"].ToObject<JObject>();
                            if (Ambilight.ContainsKey("AmbilightImage")) screenSampler.openImage((string)Ambilight["AmbilightImage"]);
                            if (Ambilight.ContainsKey("AmbilightSelections"))
                            {
                                var selections = (JArray)Ambilight["AmbilightSelections"];
                                if (selections.Count > 0)
                                {
                                    screenSampler.removeAllSelections();
                                    foreach (var sel in selections)
                                        screenSampler.createPanel((string)sel["AmbilightTitle"], (int)sel["AmbilightX"], (int)sel["AmbilightY"], (int)sel["AmbilightW"], (int)sel["AmbilightH"], false);
                                }
                                else screenSampler.CreateDefaultSelections();
                            }
                            if (Ambilight.ContainsKey("AmbilightScreen")) screenSampler.selectedScreen = (int)Ambilight["AmbilightScreen"];
                        }
                    }

                if (json.ContainsKey("Schedules"))
                {
                    JObject Schedules = json["Schedules"].ToObject<JObject>();
                    if (Schedules.ContainsKey("enableScheduler"))
                    {
                        enableTimeSchedule.Checked = (bool)json["Schedules"]["enableScheduler"];
                        enableTimeSchedule.Refresh();
                    }
                    if (Schedules.ContainsKey("timeSchedule"))
                    {
                        timeScheduleList.Items = (JArray)json["Schedules"]["timeSchedule"];
                        timeScheduleList.createAllTimeItems();
                    }
                }
                if (json.ContainsKey("playingAnimation")) playingAnimation = (string)json["playingAnimation"];
                if (json.ContainsKey("powerConected")) powerConected = (bool)json["powerConected"];
                if (json.ContainsKey("PowerState")) powerButton.Checked = (bool)json["PowerState"];

            });
        }
        private void setPreset(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                colorWheel.Color = (sender as Panel).BackColor;
                brightnessSlide.RegionColor = (sender as Panel).BackColor;
                brightnessSlide.LeftColor = (sender as Panel).BackColor;
                brightnessSlide.GradientColor = (sender as Panel).BackColor;
                brightnessSlide.Update();
                string p = "{\"Animations\":{\"parameters\":{\"SolidColor\":{\"Color\":[" + (sender as Panel).BackColor.R * 4 + "," + (sender as Panel).BackColor.G * 4 + "," + (sender as Panel).BackColor.B * 4 + "]}}}}";
                selectAnimation("SolidColor", p);
            }
            else if (e.Button == MouseButtons.Right)
            {
                (sender as Panel).BackColor = colorWheel.Color;
                colorWheel.Color = (sender as Panel).BackColor;
            }
        }
        private void formatButton_Click(object sender, EventArgs e)
        {
            exceptions exitMessage = new exceptions(1,"ESPRGB-Format device", "You want to format this device?");
            exitMessage.StartPosition = FormStartPosition.CenterParent;
            exitMessage.ShowDialog();
            if (exitMessage.DialogResult == DialogResult.Yes)
            {
                string format_data = "{\"command\":\"formatDevice\"}";
                ws.SendAsync(format_data, null);
                ESPRGB.removeThisTab(this);
            }
        }
        private void removeDevice_Click(object sender, EventArgs e)
        {
            exceptions exitMessage = new exceptions(1,"ESPRGB-Remove device", "You want to remove this device?");
            exitMessage.StartPosition = FormStartPosition.CenterParent;
            exitMessage.ShowDialog();
            if (exitMessage.DialogResult == DialogResult.Yes)
            {
                ESPRGB.removeSyncDevice(this);
                ESPRGB.removeThisTab(this);
            }

        }

        bool colorWheel1_changed = false;
        private void colorWheel_MouseDown(object sender, MouseEventArgs e)
        {
            colorWheel1_changed = true;
        }
        private void colorWheel_MouseUp(object sender, MouseEventArgs e)
        {
            colorWheel1_changed = false;
        }
        private void colorWheel1_ColorChanged(object sender, EventArgs e)
        {
            if (colorWheel1_changed)
            {
                float brightness = ((float)brightnessSlide.Value / 100.0f);
                Color newColor = Color.FromArgb(255, (int)(colorWheel.Color.R * brightness), (int)(colorWheel.Color.G * brightness), (int)(colorWheel.Color.B * brightness));
                brightnessSlide.RegionColor = newColor;
                brightnessSlide.LeftColor = newColor;
                brightnessSlide.GradientColor = newColor;
                brightnessSlide.Update();

                string data = "{\"Animations\":{\"parameters\":{\"SolidColor\":{\"Color\":[" + colorWheel.Color.R * 4 + "," + colorWheel.Color.G * 4 + "," + colorWheel.Color.B * 4 + "]}}}}";

                selectAnimation("Solid Color", data);
            }
        }
        private void brightnessSlide_Scroll(object sender, Zeroit.Framework.Metro.ZeroitMetroTrackbar.TrackbarEventArgs e)
        {
            float brightness = ((float)brightnessSlide.Value / 100.0f);
            Color newColor = Color.FromArgb(255, (int)(colorWheel.Color.R * brightness), (int)(colorWheel.Color.G * brightness), (int)(colorWheel.Color.B * brightness));
            powerButton.Checked = true;
            brightnessSlide.GradientColor = newColor;
            brightnessSlide.LeftColor = newColor;
            brightnessSlide.RegionColor = newColor;
            brightnessSlide.Update();
            string data = "{\"Animations\":{\"parameters\":{\"SolidColor\":{\"Brightness\":" + brightness + "}}}}";
            selectAnimation("Solid Color", data);
        }
        private void powerButton_CheckedChanged(object sender, EventArgs e)
        {
            if (powerButton.Checked) powerButton.Image = Properties.Resources.power_1;
            else powerButton.Image = Properties.Resources.power_0;
        }
        private void powerButton_Click(object sender, EventArgs e)
        {
            if (powerButton.Checked) selectAnimation("Power On");
            else selectAnimation("Power Off");
        }
        private void startColorCycle_CheckedChanged(object sender, EventArgs e)
        {
            if (startColorCycle.Checked)
                startColorCycle.Image = Properties.Resources.bool_1;
            else
                startColorCycle.Image = Properties.Resources.bool_0;
        }
        private void startColorCycle_Click(object sender, EventArgs e)
        {
            if (startColorCycle.Checked) selectAnimation("Color Cycle");
            else selectAnimation("Solid Color");
        }
        private void ColorCycleSpeed_Scroll(object sender, Zeroit.Framework.Metro.ZeroitMetroTrackbar.TrackbarEventArgs e)
        {
            ColorCycleSpeedText.Text = ColorCycleSpeed.Value.ToString();
            string data = "{\"Animations\":{\"parameters\":{\"ColorCycle\":{\"ColorCycleSpeed\":" + ColorCycleSpeed.Value + "}}}}";
            if (sync_device) ESPRGB.broadcastTxT(this, data, true);
            else ws.SendAsync(data, null);
        }
        private void breathingSpeed_Scroll(object sender, Zeroit.Framework.Metro.ZeroitMetroTrackbar.TrackbarEventArgs e)
        {
            breathingSpeedText.Text = breathingSpeed.Value.ToString();
            string data = "{\"Animations\":{\"parameters\":{\"Breathing\":{\"breathingSpeed\":" + breathingSpeed.Value + "}}}}";
            if (sync_device) ESPRGB.broadcastTxT(this, data, true);
            else ws.SendAsync(data, null);
        }
        private void startBreathing_Click(object sender, EventArgs e)
        {
            if (startBreathing.Checked) selectAnimation("Breathing");
            else selectAnimation("Solid Color");
        }
        bool breathing_colorWheel_changed = false;
        private void startBreathing_CheckedChanged(object sender, EventArgs e)
        {
            if (startBreathing.Checked)
                startBreathing.Image = Properties.Resources.bool_1;
            else
                startBreathing.Image = Properties.Resources.bool_0;
        }
        private void breathing_colorWheel_MouseDown(object sender, MouseEventArgs e)
        {
            breathing_colorWheel_changed = true;
        }
        private void breathing_colorWheel_MouseUp(object sender, MouseEventArgs e)
        {
            breathing_colorWheel_changed = false;
        }
        private void breathing_colorWheel_ColorChanged(object sender, EventArgs e)
        {
            if (breathing_colorWheel_changed)
            {
                string data = "{\"Animations\":{\"parameters\":{\"Breathing\":{\"staticColorBreathing\":[" + colorBreathing.Color.R * 4 + "," + colorBreathing.Color.G * 4 + "," + colorBreathing.Color.B * 4 + "]}}}}";
                if (sync_device) ESPRGB.broadcastTxT(this, data, true);
                else ws.SendAsync(data, null);
            }
        }
        private Bitmap bmp;
        public Graphics discoGfx;
        private void InitializeBitmapAndGraphics()
        {
            bmp = new Bitmap(pictureBoxTop.Width, pictureBoxTop.Height);
            discoGfx = Graphics.FromImage(bmp);
            discoGfx.Clear(Color.FromArgb(255, 21, 32, 54));
            pictureBoxTop.Image = bmp;
        }
        Pen pen = new Pen(Color.White, 20);

        int audiotimeout;

        private void discoTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                discoGfx.Clear(Color.FromArgb(255, 21, 32, 54));
                if (!powerButton.Checked) return;
                BassWasapi.BASS_WASAPI_GetData(_fft, (int)BASSData.BASS_DATA_FFT2048); //get channel fft data

                int y;
                int b0 = 0;
                int posX = 15;
                int avgLow = 0, avgMid = 0, avgHigh = 0;

                for (int x = 0; x < 16; x++)
                {
                    float peak = 0;
                    int b1 = (int)Math.Pow(2, x * 10.0 / (16 - 1));

                    if (b1 > 1023) b1 = 1023;
                    if (b1 <= b0) b1 = b0 + 1;
                    for (; b0 < b1; b0++)
                    {
                        if (peak < _fft[1 + b0]) peak = _fft[1 + b0];
                    }
                    y = (int)(Math.Sqrt(peak) * 3 * 255 - 4);
                    y = (y + spectrum[x]) / 2;
                    if (y > 255) y = 255;
                    if (y < 0) y = 0;
                    //draw lines
                    if (x < colorslider1.SelectedMin)
                    {
                        pen.Color = colorslider1.color1.Color;
                        if (y > lowSensitivity.Value) avgLow += y;
                    }
                    if (x >= colorslider1.SelectedMin && x < colorslider1.SelectedMax)
                    {
                        pen.Color = colorslider1.color2.Color;
                        if (y > midSensitivity.Value) avgMid += y;
                    }
                    if (x >= colorslider1.SelectedMax)
                    {
                        pen.Color = colorslider1.color3.Color;
                        if (y > highSensitivity.Value) avgHigh += y;
                    }
                    discoGfx.DrawLine(pen, new Point(posX, bmp.Height), new Point(posX, bmp.Height - (y / 2)));
                    posX += 25;
                    spectrum[x] = y;
                }

                avgLow = avgLow > 0 ? (int)((avgLow / colorslider1.SelectedMin) * ((float)lowsBrightness.Value / 100.0f)) : 0;
                avgMid = avgMid > 0 ? (int)((avgMid / (colorslider1.SelectedMax - colorslider1.SelectedMin)) * ((float)midsBrightness.Value / 100.0f)) : 0;
                avgHigh = avgHigh > 0 ? (int)((avgHigh / (colorslider1.Max - colorslider1.SelectedMax)) * ((float)highsBrightness.Value / 100.0f)) : 0;

                pictureBoxTop.Image = bmp;

                int[] finalc = CombineColors(ColortoList(avgLow, colorslider1.color1.Color), ColortoList(avgMid, colorslider1.color2.Color), ColortoList(avgHigh, colorslider1.color3.Color));


                ResultColor.BackColor = Color.FromArgb(255, finalc[0], finalc[1], finalc[2]);

                if (finalc[0] == 0 && finalc[1] == 0 && finalc[2] == 0) audiotimeout++;
                else audiotimeout = 0;
                if (audiotimeout > 6000) audiotimeout = 0;
                if (audiotimeout < 200)
                {
                    string data = "{\"Animations\":{\"parameters\":{\"Disco\":{\"colorDisco\":[" + finalc[0] * 4 + "," + finalc[1] * 4 + "," + finalc[2] * 4 + "]}}}}";
                    if (sync_device)
                    {
                        if (this == ESPRGB._syncDevices[0]) ESPRGB.broadcastTxT(this, data, false);
                    }
                    else ws.SendAsync(data, null);
                }
            }
            catch
            {
            }
        }
        public int[] ColortoList(int value, Color c)
        {
            int[] color = new int[3];
            color[0] = c.R > 0 ? value : 0;
            color[1] = c.G > 0 ? value : 0;
            color[2] = c.B > 0 ? value : 0;

            return color;
        }
        public int[] CombineColors(int[] c1, int[] c2, int[] c3)
        {
            int[] combinedColor = new int[3];
            int x = 0;
            for (int i = 0; i < 3; i++)
            {
                if (c1[i] > 0) x++;
                if (c2[i] > 0) x++;
                if (c3[i] > 0) x++;
                int sum = c1[i] + c2[i] + c3[i];
                combinedColor[i] = sum > 0 ? sum / x : 0;
                x = 0;
            }
            return combinedColor;
        }
        private void startDisco_Click(object sender, EventArgs e)
        {
            InitializeBitmapAndGraphics();
            if (startDisco.Checked) selectAnimation("Disco");
            else selectAnimation("Solid Color");
        }

        private void connectButton_Click(object sender, EventArgs e)
        {
            if (connAlive)
                ws.CloseAsync();
            else
            {
                if (ws == null) ConnectDevice();
                else
                {
                    if (ws.ReadyState == WebSocketState.Closed && ws.ReadyState != WebSocketState.Connecting) ConnectDevice();
                }              
            }             
        }

        private void sel_Click(object sender, EventArgs e)
        {
            switch (selectionColor.SelectedIndex)
            {
                case 0:
                    colorslider1.color1 = new SolidBrush((sender as Button).BackColor);
                    break;
                case 1:
                    colorslider1.color2 = new SolidBrush((sender as Button).BackColor);
                    break;
                case 2:
                    colorslider1.color3 = new SolidBrush((sender as Button).BackColor);
                    break;
            }
            ESPRGB.syncLocalControls(this);
            colorslider1.Refresh();
        }
        bool colorslider1_click = false;
        private void colorslider1_MouseDown(object sender, MouseEventArgs e)
        {
            colorslider1_click = true;
        }
        private void colorslider1_MouseUp(object sender, MouseEventArgs e)
        {
            colorslider1_click = false;
        }
        private void colorslider1_SelectionChanged(object sender, EventArgs e)
        {
            if (colorslider1_click) ESPRGB.syncLocalControls(this);
        }
        private void startDisco_CheckedChanged(object sender, EventArgs e)
        {
            discoTimer.Enabled = startDisco.Checked;
        }
        private void startSolidDisco_Click(object sender, EventArgs e)
        {
            initializeSolidDiscoVisualizer();
            if (startSolidDisco.Checked) selectAnimation("Solid Disco");
            else selectAnimation("Solid Color");
        }
        private void startSolidDisco_CheckedChanged(object sender, EventArgs e)
        {
            solidDiscoTimer.Enabled = startSolidDisco.Checked;
        }
        private Bitmap bmpSolidDisco;
        public Graphics gfxSolidDisco;
        private void initializeSolidDiscoVisualizer()
        {
            bmpSolidDisco = new Bitmap(SolidDiscoVisualizer.Width, SolidDiscoVisualizer.Height);
            gfxSolidDisco = Graphics.FromImage(bmpSolidDisco);
            gfxSolidDisco.Clear(Color.FromArgb(255, 21, 32, 54));
            SolidDiscoVisualizer.Image = bmpSolidDisco;
        }
        Pen penSolidDisco = new Pen(Color.Black, 20);
        int solidDiscoTimeout;
        bool changed = false;
        Random rnd = new Random();
        private void solidDiscoTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                gfxSolidDisco.Clear(Color.FromArgb(255, 21, 32, 54));
                if (!powerButton.Checked) return;
                BassWasapi.BASS_WASAPI_GetData(_fft, (int)BASSData.BASS_DATA_FFT2048); //get channel fft data

                int y = 0;
                int b0 = 0;
                int posX = 15;
                float avg = 0;

                for (int x = 0; x < 16; x++)
                {
                    float peak = 0;
                    int b1 = (int)Math.Pow(2, x * 10.0 / (16 - 1));

                    if (b1 > 1023) b1 = 1023;
                    if (b1 <= b0) b1 = b0 + 1;
                    for (; b0 < b1; b0++) if (peak < _fft[1 + b0]) peak = _fft[1 + b0];
                    y = (int)(Math.Sqrt(peak) * 3 * 255 - 4);
                    y = (y + spectrum[x]) / 2;
                    if (y > 255) y = 255;
                    if (y < 0) y = 0;
                    //draw lines
                    if (x >= colorslider_simple.SelectedMin && x < colorslider_simple.SelectedMax)
                    {
                        penSolidDisco.Color = colorslider_simple.color.Color;
                        if (y > solidDiscoSensitivity.Value) avg += y;

                    }
                    else penSolidDisco.Color = Color.Black;

                    gfxSolidDisco.DrawLine(penSolidDisco, new Point(posX, bmpSolidDisco.Height), new Point(posX, bmpSolidDisco.Height - (y / 2)));
                    posX += 25;
                    spectrum[x] = y;
                }
                SolidDiscoVisualizer.Image = bmpSolidDisco;
                if (sync_device && this != ESPRGB._syncDevices[0]) return;


                avg = avg > 0 ? (avg / (colorslider_simple.SelectedMax - colorslider_simple.SelectedMin)) : 0;
                if (avg == 0) solidDiscoTimeout++;
                else solidDiscoTimeout = 0;
                if (solidDiscoTimeout > 60000) solidDiscoTimeout = 0;
                if (solidDiscoTimeout < 200)
                {
                    if (avg <= 235) changed = false;
                    if (randomColor.Checked && avg >= 255 && changed == false)
                    {
                        HslColor hslColor = new HslColor(rnd.Next(0, 359), 1, 0.5);
                        colorWheel_SolidDisco.HslColor = hslColor;
                        Color col = hslColor.ToRgbColor();

                        colorslider_simple.color = new SolidBrush(hslColor);
                        colorslider_simple.Refresh();

                        string color = "{\"Animations\":{\"parameters\":{\"SolidDisco\":{\"colorSolidDisco\":[" + col.R * 4 + "," + col.G * 4 + "," + col.B * 4 + "]}}}}";
                        if (sync_device) ESPRGB.broadcastTxT(this, color, true);
                        else ws.SendAsync(color, null);
                        changed = true;
                    }
                    string data = "{\"Animations\":{\"parameters\":{\"SolidDisco\":{\"pulseSolidDisco\":" + avg / 255 + "}}}}";
                    if (sync_device) ESPRGB.broadcastTxT(this, data, false);
                    else ws.SendAsync(data, null);
                }
            }
            catch
            {
            }
        }
        bool solidDisco_colorWheel_changed = false;
        private void colorWheel_SolidDisco_MouseDown(object sender, MouseEventArgs e)
        {
            solidDisco_colorWheel_changed = true;
        }
        private void colorWheel_SolidDisco_MouseUp(object sender, MouseEventArgs e)
        {
            solidDisco_colorWheel_changed = false;
        }
        private void colorWheel_SolidDisco_ColorChanged(object sender, EventArgs e)
        {

            if (solidDisco_colorWheel_changed)
            {
                colorslider_simple.color = new SolidBrush(colorWheel_SolidDisco.HslColor);
                colorslider_simple.Refresh();

                string data = "{\"Animations\":{\"parameters\":{\"SolidDisco\":{\"colorSolidDisco\":[" + colorWheel_SolidDisco.Color.R * 4 + "," + colorWheel_SolidDisco.Color.G * 4 + "," + colorWheel_SolidDisco.Color.B * 4 + "]}}}}";
                if (sync_device) ESPRGB.broadcastTxT(this, data, true);
                else ws.SendAsync(data, null);
            }
        }
        bool colorslider_simple_click = false;
        private void colorslider_simple_MouseDown(object sender, MouseEventArgs e)
        {
            colorslider_simple_click = true;
        }
        private void colorslider_simple_MouseUp(object sender, MouseEventArgs e)
        {
            colorslider_simple_click = false;
        }
        private void colorslider_simple_SelectionChanged(object sender, EventArgs e)
        {
            if (colorslider_simple_click) ESPRGB.syncLocalControls(this);
        }
        private void discoSensitivity(object sender, Zeroit.Framework.Metro.ZeroitMetroTrackbar.TrackbarEventArgs e)
        {
            ESPRGB.syncLocalControls(this);
        }
        private void solidDiscoSensitivity_Scroll(object sender, Zeroit.Framework.Metro.ZeroitMetroTrackbar.TrackbarEventArgs e)
        {
            ESPRGB.syncLocalControls(this);
        }
        private void randomBeat_Scroll(object sender, Zeroit.Framework.Metro.ZeroitMetroTrackbar.TrackbarEventArgs e)
        {
            ESPRGB.syncLocalControls(this);
        }
        private void randomColor_Click(object sender, EventArgs e)
        {
            ESPRGB.syncLocalControls(this);
        }
        private void lowsBrightness_Scroll(object sender, Zeroit.Framework.Metro.ZeroitMetroTrackbar.TrackbarEventArgs e)
        {
            ESPRGB.syncLocalControls(this);
        }
        private void midsBrightness_Scroll(object sender, Zeroit.Framework.Metro.ZeroitMetroTrackbar.TrackbarEventArgs e)
        {
            ESPRGB.syncLocalControls(this);
        }
        private void highsBrightness_Scroll(object sender, Zeroit.Framework.Metro.ZeroitMetroTrackbar.TrackbarEventArgs e)
        {
            ESPRGB.syncLocalControls(this);
        }
        private void syncButton_Click(object sender, EventArgs e)
        {
            sync_device = !sync_device;
            if (sync_device) ESPRGB.addSyncDevice(this);
            else ESPRGB.removeSyncDevice(this);
        }
        private void configButton_Click(object sender, EventArgs e)
        {
            configWindow settingsWindow = new configWindow(ipaddress);
            settingsWindow.StartPosition = FormStartPosition.CenterParent;
            settingsWindow.ShowDialog();
        }
        private async void rssiTimer_Tick(object sender, EventArgs e)
        {
            ws.Ping();
            try
            {
                using (var client = new HttpClient())
                {
                    var result = await client.GetAsync("http://" + ipaddress + "/getSignalStrenght");
                    var responseBody = JObject.Parse(await result.Content.ReadAsStringAsync());
                    if (responseBody.ContainsKey("RSSI"))
                    {
                        int power = (int)responseBody["RSSI"];
                        if (power >= -50) wifiImageBox.Image = Properties.Resources.wifi_1;
                        else if (power < -50 && power >= -60) wifiImageBox.Image = Properties.Resources.wifi_2;
                        else if (power < -60 && power >= -70) wifiImageBox.Image = Properties.Resources.wifi_3;
                        else if (power < -70) wifiImageBox.Image = Properties.Resources.wifi_4;
                    }
                }
            }
            catch (Exception)
            {
            }
        }
        private void useColorList_Click(object sender, EventArgs e)
        {
            string data = "{\"Animations\":{\"parameters\":{\"Breathing\":{\"useColorList\":" + useColorList.Checked.ToString().ToLower() + "}}}}";
            if (sync_device) ESPRGB.broadcastTxT(this, data, true);
            else ws.SendAsync(data, null);
        }
        private void br_addCurrentColor_Click(object sender, EventArgs e)
        {
            if (colorListResult.colorList.Count < 25)
            {
                string data = "{\"Animations\":{\"parameters\":{\"Breathing\":{\"addColortoList\":[" + colorBreathing.Color.R * 4 + "," + colorBreathing.Color.G * 4 + "," + colorBreathing.Color.B * 4 + "]}}}}";
                if (sync_device) ESPRGB.broadcastTxT(this, data, true);
                else ws.SendAsync(data, null);
            }
            else
            {
                exceptions exitMessage = new exceptions(0,"ESPRGB-Exception", "25 colors limit");
                exitMessage.StartPosition = FormStartPosition.CenterParent;
                exitMessage.ShowDialog();
            }

        }
        private void br_removeLastColor_Click(object sender, EventArgs e)
        {
            string data = "{\"Animations\":{\"parameters\":{\"Breathing\":{\"removeLastfromList\":true}}}}";
            if (sync_device) ESPRGB.broadcastTxT(this, data, true);
            else ws.SendAsync(data, null);
        }
        private void br_clearColorlist_Click(object sender, EventArgs e)
        {
            string data = "{\"Animations\":{\"parameters\":{\"Breathing\":{\"clearColorList\":true}}}}";
            if (sync_device) ESPRGB.broadcastTxT(this, data, true);
            else ws.SendAsync(data, null);
        }
        private async void restartButton_Click(object sender, EventArgs e)
        {
            exceptions exitMessage = new exceptions(1,"ESPRGB-Format device", "You want to restart this device?");
            exitMessage.StartPosition = FormStartPosition.CenterParent;
            exitMessage.ShowDialog();
            if (exitMessage.DialogResult == DialogResult.Yes)
            {
                using (var client = new HttpClient())
                {
                    try
                    {
                        ws.Close();
                        var result = await client.GetAsync("http://" + ipaddress + "/restartESP");
                        if (result.IsSuccessStatusCode)
                        {
                            ConnectDevice();
                        }
                    }
                    catch (Exception)
                    {
                    }
                }

            }
        }

        List<string> alphabet = new List<string> { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", "1", "2", "3", "4", "5", "6", "7", "8", "9", "0", "!", "@", "&", "(", ")", "-", "_", "=", "+", ".", ",", "/", "?", ";", ":", "\"", "\'" };
        List<string> morse = new List<string> { ".-", "-...", "-.-.", "-..", ".", "..-.", "--.", "....", "..", ".---", "-.-", ".-..", "--", "-.", "---", ".--.", "--.-", ".-.", "...", "-", "..-", "...-", ".--", "-..-", "-.--", "--..", ".----", "..---", "...--", "....-", "-....", "--...", "---..", "----.", "-----", "-.-.--", ".--.-.", ".....", ".-...", "-.--.", "-.--.-", "-....-", "..--.-", "-...-", ".-.-.", ".-.-.-", "--..--", "-..-.", "..--..", "-.-.-.", "---...", ".----.", ".-..-." };
        public string encodeMessage(string message)
        {
            string encoded = "";
            var words = message.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < words.Length; i++)
            {
                var characters = words[i].ToCharArray();

                for (int j = 0; j < characters.Length; j++)
                {
                    if (alphabet.Contains(characters[j].ToString()))
                    {
                        encoded += morse[alphabet.IndexOf(characters[j].ToString())];
                        if (j + 1 != characters.Length) encoded += "*";
                    }
                }
                if (i + 1 != words.Length) encoded += "|";
            }
            return encoded;
        }
        public string decodeMessage(string message)
        {
            string decoded = "";

            var encodedWords = message.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < encodedWords.Length; i++)
            {
                var ch = encodedWords[i].Split(new char[] { '*' }, StringSplitOptions.RemoveEmptyEntries);
                for (int j = 0; j < ch.Length; j++)
                {
                    if (morse.Contains(ch[j])) decoded += alphabet[morse.IndexOf(ch[j])];
                }
                if (i + 1 != encodedWords.Length) decoded += " ";
            }

            return decoded;
        }
        bool morsecolorChanged = false;
        private void morseColor_MouseDown(object sender, MouseEventArgs e)
        {
            morsecolorChanged = true;
        }
        private void morseColor_MouseUp(object sender, MouseEventArgs e)
        {
            morsecolorChanged = false;
        }
        private void morseColor_ColorChanged(object sender, EventArgs e)
        {
            if (morsecolorChanged)
            {
                string data = "{\"Animations\":{\"parameters\":{\"MorseCode\":{\"colorMorseCode\":[" + morseColor.Color.R * 4 + "," + morseColor.Color.G * 4 + "," + morseColor.Color.B * 4 + "]}}}}";
                if (sync_device) ESPRGB.broadcastTxT(this, data, true);
                else ws.SendAsync(data, null);
            }
        }
        private void morsePlainText_KeyUp(object sender, KeyEventArgs e)
        {
            encodedMsgResult.Text = encodeMessage(morsePlainText.Text);
            textBoxTimer.Stop();
            textBoxTimer.Start();
        }

        private void startMorseCode_Click(object sender, EventArgs e)
        {
            if (startMorseCode.Checked) selectAnimation("Morse Code");
            else selectAnimation("Solid Color");
        }
        private void useBuzzer_Click(object sender, EventArgs e)
        {
            string data = "{\"Animations\":{\"parameters\":{\"MorseCode\":{\"useBuzzer\":" + useBuzzer.Checked.ToString().ToLower() + "}}}}";
            if (sync_device) ESPRGB.broadcastTxT(this, data, true);
            else ws.SendAsync(data, null);
        }

        private void textBoxTimer_Tick(object sender, EventArgs e)
        {
            textBoxTimer.Stop();
            string data = "{\"Animations\":{\"parameters\":{\"MorseCode\":{\"encodedMorseCode\": \"" + encodedMsgResult.Text + "\"}}}}";
            if (sync_device) ESPRGB.broadcastTxT(this, data, true);
            else ws.SendAsync(data, null);
        }
        private void unitTime_MouseUp(object sender, MouseEventArgs e)
        {
            string data = "{\"Animations\":{\"parameters\":{\"MorseCode\":{\"unitTimeMorseCode\": " + unitTime.Value + "}}}}";
            if (sync_device) ESPRGB.broadcastTxT(this, data, true);
            else ws.SendAsync(data, null);
        }

        private void scheduleList_SelectChanged(object sender, EventArgs e)
        {
            if (sync_device && ESPRGB._syncDevices.Any() && this != ESPRGB._syncDevices[0])
            {
                return;
            }
            if (scheduleTimer.Enabled && appScheduleList.selectedItem != null)
            {
                string par = "{\"Animations\":{\"parameters\":" + appScheduleList.selectedItem["parameters"].ToString(Newtonsoft.Json.Formatting.None) + "}}";
                selectAnimation((string)appScheduleList.selectedItem["playingAnimation"], par);
                ESPRGB.syncLocalControls(this);
            }
        }
        private void schTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                if (appScheduleList.Items.Count == 0 || (sync_device && ESPRGB._syncDevices.Any() && this != ESPRGB._syncDevices[0]))
                {
                    return;
                }
                for (int i = 0; i < appScheduleList.Items.Count; i++)
                {
                    if ((bool)appScheduleList.Items[i]["enable"] != false)
                    {
                        if ((string)appScheduleList.Items[i]["appName"] == "DEFAULT APP")
                        {
                            appScheduleList.selectIndex = i;
                            return;
                        }
                        using (var proc = Process.GetProcessesByName((string)appScheduleList.Items[i]["appName"]).FirstOrDefault())
                        {
                            if (proc != null)
                            {
                                appScheduleList.selectIndex = i;
                                proc.Close();
                                return;
                            }
                        }
                    }
                }
            }
            catch
            {
            }
        }
        private void addNewAppSchedule_Click(object sender, EventArgs e)
        {
            newScheduleWindow sw = new newScheduleWindow(0,appScheduleList.Items);
            sw.StartPosition = FormStartPosition.CenterParent;
            var res = sw.ShowDialog();

            if (res == DialogResult.OK)
            {
                if (!appScheduleList.Items.Contains(sw.result))
                {
                    appScheduleList.Items.Add(sw.result);
                    appScheduleList.createAllAppItems();
                    ESPRGB.syncLocalControls(this);
                }
            }
        }
        private void PowerIfConnected_Click(object sender, EventArgs e)
        {
            powerConected = !powerConected;
        }
        private void scheduleList_OrderChanged(object sender, EventArgs e)
        {
            ESPRGB.syncLocalControls(this);
        }
        bool enableScheduleClick = false;
        private void enableSchedule_MouseDown(object sender, MouseEventArgs e)
        {
            enableScheduleClick = true;
        }
        private void enableSchedule_MouseUp(object sender, MouseEventArgs e)
        {
            enableScheduleClick = false;
        }

        private void addNewTimeSchedule_Click(object sender, EventArgs e)
        {
            if (timeScheduleList.Items.Count < 10)
            {
                newScheduleWindow sw = new newScheduleWindow(1);
                sw.StartPosition = FormStartPosition.CenterParent;
                var res = sw.ShowDialog();

                if (res == DialogResult.OK)
                {
                    string data = "{\"Animations\":{\"Schedules\":{\"newTimeSchedule\":" + sw.result.ToString(Newtonsoft.Json.Formatting.None) + "}}}";
                    if (sync_device) ESPRGB.broadcastTxT(this, data, true);
                    else ws.SendAsync(data, null);
                }
            }
            else
            {
                exceptions exitMessage = new exceptions(0,"ESPRGB-Format device", "10 schedules limit");
                exitMessage.StartPosition = FormStartPosition.CenterParent;
                exitMessage.ShowDialog();
            }
        }

        private void timeScheduleList_timeScheduleRemoved(object sender, JObject e)
        {
            string data = "{\"Animations\":{\"Schedules\":{\"removeTimeSchedule\":{\"Timestamp\":" + e["Timestamp"] + "}}}}";
            if (sync_device) ESPRGB.broadcastTxT(this, data, true);
            else ws.SendAsync(data, null);
        }
        bool enableTimeScheduleClick = false;
        private void enableTimeSchedule_MouseDown(object sender, MouseEventArgs e)
        {
            enableTimeScheduleClick = true;
        }

        private void enableTimeSchedule_MouseUp(object sender, MouseEventArgs e)
        {
            enableTimeScheduleClick = false;
        }

        private void enableTimeSchedule_CheckedChanged(object sender, EventArgs e)
        {
            if (enableTimeScheduleClick)
            {               
                string data = "{\"Animations\":{\"Schedules\":{\"enableScheduler\":" + enableTimeSchedule.Checked.ToString().ToLower() + "}}}";
                if (sync_device) ESPRGB.broadcastTxT(this, data, true);
                else ws.SendAsync(data, null);
            }
        }

        private void timeScheduleList_timeScheduleEnable(object sender, JObject e)
        {
            JObject editJson = new JObject();
            JObject obj = new JObject();
            obj["oldTimestamp"] = e["Timestamp"];
            JObject newData = new JObject();
            newData["enable"] = e["enable"];
            obj["newData"] = newData;
            editJson["editTimeSchedule"] = obj;
            string data = "{\"Animations\":{\"Schedules\":"+editJson.ToString(Newtonsoft.Json.Formatting.None)+"}}";
            if (sync_device) ESPRGB.broadcastTxT(this, data, true);
            else ws.SendAsync(data, null);
        }

        private void timeScheduleList_timeScheduleEdit(object sender, JObject e)
        {
            newScheduleWindow sw = new newScheduleWindow(1,e);
            sw.StartPosition = FormStartPosition.CenterParent;
            var res = sw.ShowDialog();

            if (res == DialogResult.OK)
            {
                JObject editJson = new JObject();
                JObject obj = new JObject();
                obj["oldTimestamp"] = e["Timestamp"];
                obj["newData"] = sw.result;
                editJson["editTimeSchedule"] = obj;
                string data = "{\"Animations\":{\"Schedules\":" + editJson.ToString(Newtonsoft.Json.Formatting.None) + "}}";
                if (sync_device) ESPRGB.broadcastTxT(this, data, true);
                else ws.SendAsync(data, null);
            }
        }

        private void appScheduleList_appScheduleEdit(object sender, JObject e)
        {
            newScheduleWindow sw = new newScheduleWindow(0, e,appScheduleList.Items);
            sw.StartPosition = FormStartPosition.CenterParent;
            var res = sw.ShowDialog();

            if (res == DialogResult.OK)
            {
                for (int i = 0; i < appScheduleList.Items.Count(); i++)
                {
                    if (appScheduleList.Items[i] == e)
                    {
                        appScheduleList.Items[i] = sw.result;
                        appScheduleList.createAllAppItems();
                        break;
                    }
                }
            }
        }

        private async void removeUserData_Click(object sender, EventArgs e)
        {
            exceptions removeUserData = new exceptions(1, "ESPRGB-Format device", "You want to remove all the user data from this device?");
            removeUserData.StartPosition = FormStartPosition.CenterParent;
            removeUserData.ShowDialog();
            if (removeUserData.DialogResult == DialogResult.Yes)
            {
                using (var client = new HttpClient())
                {
                   await client.GetAsync("http://" + ipaddress + "/removeUserData");
                }
            }
        }

        private void enableSchedule_CheckedChanged(object sender, EventArgs e)
        {
            scheduleTimer.Enabled = enableAppSchedule.Checked;
            if (enableScheduleClick)
            {
                if (!enableAppSchedule.Checked) appScheduleList.selectIndex = -1;
                ESPRGB.syncLocalControls(this);
            }
        }
        private void ambilightSpeed_Scroll(object sender, Zeroit.Framework.Metro.ZeroitMetroTrackbar.TrackbarEventArgs e)
        {
            screenSampler.liveTimer.Interval = ambilightSpeed.Value;
        }
        private void startAmbilight_CheckedChanged(object sender, EventArgs e)
        {
            if (sync_device)
            {
                if (ESPRGB._syncDevices[0] != null && (this == ESPRGB._syncDevices[0])) screenSampler.enable = startAmbilight.Checked;
            }
            else screenSampler.enable = startAmbilight.Checked;
            if (screenSampler.enable)
            {
                string data = "{\"Animations\":{\"parameters\":{\"Ambilight\":{\"AmbilightColor\":[" + screenSampler.ScreenColor.R * 4 + "," + screenSampler.ScreenColor.G * 4 + "," + screenSampler.ScreenColor.B * 4 + "]}}}}";
                if (sync_device) ESPRGB.broadcastTxT(this, data, true);
                else ws.SendAsync(data, null);
            }
        }
        private void startAmbilight_Click(object sender, EventArgs e)
        {
            if (startAmbilight.Checked) selectAnimation("Ambilight");
            else selectAnimation("Solid Color");
        }
        private void screenSampler_OnColorChanged(object sender, Color e)
        {
            if (screenSampler.enable && ws != null)
            {
                string data = "{\"Animations\":{\"parameters\":{\"Ambilight\":{\"AmbilightColor\":[" + e.R * 4 + "," + e.G * 4 + "," + e.B * 4 + "]}}}}";
                if (sync_device) ESPRGB.broadcastTxT(this, data, true);
                else ws.SendAsync(data, null);
            }
        }
        private void screenSampler_OnScreenChanged(object sender, EventArgs e)
        {
            ESPRGB.syncLocalControls(this);
        }
        private void ambilightSpeed_MouseUp(object sender, MouseEventArgs e)
        {
            ESPRGB.syncLocalControls(this);
        }
    }
}
