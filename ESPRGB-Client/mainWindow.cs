using githubUpdaterApp;
using Microsoft.Win32;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Un4seen.Bass;
using Un4seen.BassWasapi;
using WebSocketSharp;

namespace ESPRGB_Client
{
    public partial class ESPRGB : Form
    {
        public static FileInfo fileLocation;
        public static List<appControls> _appControls = new List<appControls>();
        public static List<appControls> _syncDevices = new List<appControls>();
        private static settingsWindow settingsWindow;
        addDeviceControl addDevice;
        public static WASAPIPROC _process;
        public static FormWindowState windowState;
        public static JObject audioDevices = new JObject();
        public static JObject selectedaudioDevices = defaultAudio();
        public static Version curVersion;
        public ESPRGB()
        {
            if (System.Diagnostics.Process.GetProcessesByName(System.IO.Path.GetFileNameWithoutExtension(System.Reflection.Assembly.GetEntryAssembly().Location)).Length > 1)
            {
                exceptions exitMessage = new exceptions(0,"ESPRGB-Exception", "App is already opened!");
                exitMessage.StartPosition = FormStartPosition.CenterParent;
                exitMessage.ShowDialog();
                System.Diagnostics.Process.GetCurrentProcess().Kill();
            }
            string paths = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "ESPRGB-Client\\config.json");
            fileLocation = new FileInfo(paths);
            fileLocation.Directory.Create();
            settingsWindow = new settingsWindow();
            if (File.Exists(fileLocation.FullName))
            {
                string jsonString = File.ReadAllText(fileLocation.FullName);
                JObject loadedData = JObject.Parse(jsonString);
                if(loadedData.ContainsKey("Settings")){
                    JObject settings = (JObject)loadedData["Settings"];
                    if(settings.ContainsKey("startApp")) settingsWindow.startState.SelectedItem = (string)settings["startApp"];
                    if (settings.ContainsKey("closeButtonMinimize")) settingsWindow.exitButtonBehavior.Checked = (bool)settings["closeButtonMinimize"];
                    if (settings.ContainsKey("savedAudioDevice")) selectedaudioDevices["fullName"] = (string)settings["savedAudioDevice"];
                }
            }
            settingsWindow.StartPosition = FormStartPosition.CenterParent;
            BassNet.Registration("limiteddata09@gmail.com", "2X5291323152222");
            updateAudioDevices();
            InitializeComponent();  
            tabDevices.Visible = false;
            tabDevices.Visible = true;  
            tabDevices.TabPages.Clear();
            _process = new WASAPIPROC(Process);
            InitializeAudioDevice((string)selectedaudioDevices["fullName"]);      
            windowState = this.WindowState;
            curVersion = typeof(ESPRGB).Assembly.GetName().Version;
            settingsWindow.versionLabel.Text = curVersion.ToString();
        } 

        private async void ESPRGB_Load(object sender, EventArgs e)
        {
            try
            {               
                if (!File.Exists(fileLocation.FullName))
                {
                    using (FileStream fs = File.Create(fileLocation.FullName))
                    {
                        string data = "{\n \"Settings\":{\n \"startApp\":\"Minimized\", \n \"closeButtonMinimize\": false, \n \"savedAudioDevice\": \"\" \n },\n \"Devices\":[] \n}";
                        byte[] info = new UTF8Encoding(true).GetBytes(data);
                        fs.Write(info, 0, info.Length);
                    }
                }
                else
                {
                    tabDevices.TabPages.Clear();

                    var jsonString = "";
                    using (StreamReader file = new StreamReader(ESPRGB.fileLocation.FullName, false)) jsonString = await file.ReadToEndAsync();
                    JObject loadedData = JObject.Parse(jsonString);
                    JArray items = (JArray)loadedData["Devices"];

                    for (int i = 0; i < items.Count; i++)
                    {
                        JObject device = items[i].ToObject<JObject>();

                        _appControls.Add(new appControls());
                        trayContext.Items.Insert(trayContext.Items.Count - 1, _appControls[i].trayAnimations((string)items[i]["name"]));
                        if (device.ContainsKey("ipaddress")) _appControls[i].ipaddress = (string)items[i]["ipaddress"];
                        if (device.ContainsKey("name")) _appControls[i].name = (string)items[i]["name"];
                        if (device.ContainsKey("syncDevice")) _appControls[i].sync_device = (bool)device["syncDevice"];
                        if (device.ContainsKey("colorPresets"))
                        {                            
                            _appControls[i].preset0.BackColor = System.Drawing.ColorTranslator.FromHtml((string)device["colorPresets"][0]);
                            _appControls[i].preset1.BackColor = System.Drawing.ColorTranslator.FromHtml((string)device["colorPresets"][1]);
                            _appControls[i].preset2.BackColor = System.Drawing.ColorTranslator.FromHtml((string)device["colorPresets"][2]);
                            _appControls[i].preset3.BackColor = System.Drawing.ColorTranslator.FromHtml((string)device["colorPresets"][3]);
                            _appControls[i].preset4.BackColor = System.Drawing.ColorTranslator.FromHtml((string)device["colorPresets"][4]);
                        }
                        if (device.ContainsKey("DiscoColor_1")) _appControls[i].colorslider1.color1.Color = Color.FromName((string)device["DiscoColor_1"]);
                        if (device.ContainsKey("DiscoColor_2")) _appControls[i].colorslider1.color2.Color = Color.FromName((string)device["DiscoColor_2"]);
                        if (device.ContainsKey("DiscoColor_3")) _appControls[i].colorslider1.color3.Color = Color.FromName((string)device["DiscoColor_3"]);
                        _appControls[i].colorslider1.Refresh();
                        if (device.ContainsKey("DiscoRange"))
                        {
                            _appControls[i].colorslider1.SelectedMin = (int)device["DiscoRange"][0];
                            _appControls[i].colorslider1.SelectedMax = (int)device["DiscoRange"][1];
                            _appControls[i].colorslider1.Refresh();
                        }
                        if (device.ContainsKey("DiscoSensitivity"))
                        {
                            _appControls[i].lowSensitivity.Value = (int)device["DiscoSensitivity"][0];
                            _appControls[i].midSensitivity.Value = (int)device["DiscoSensitivity"][1];
                            _appControls[i].highSensitivity.Value = (int)device["DiscoSensitivity"][2];
                        }
                        if (device.ContainsKey("DiscoBrightness"))
                        {
                            _appControls[i].lowsBrightness.Value = (int)device["DiscoBrightness"][0];
                            _appControls[i].midsBrightness.Value = (int)device["DiscoBrightness"][1];
                            _appControls[i].highsBrightness.Value = (int)device["DiscoBrightness"][2];
                        }
                        if (device.ContainsKey("SolidDiscoRange"))
                        {
                            _appControls[i].colorslider_simple.SelectedMin = (int)device["SolidDiscoRange"][0];
                            _appControls[i].colorslider_simple.SelectedMax = (int)device["SolidDiscoRange"][1];
                            _appControls[i].colorslider_simple.Refresh();
                        }
                        if (device.ContainsKey("SolidDiscoSensitivity")) _appControls[i].solidDiscoSensitivity.Value = (int)device["SolidDiscoSensitivity"];
                        if (device.ContainsKey("SolidDiscoRandom")) _appControls[i].randomColor.Checked = (bool)device["SolidDiscoRandom"];
                        if (device.ContainsKey("AmbilightImage")) _appControls[i].screenSampler.openImage((string)device["AmbilightImage"]);
                        if (device.ContainsKey("AmbilightSelections"))
                        {
                            var selections = (JArray)device["AmbilightSelections"];
                            if (selections.Count > 0)
                            {
                                _appControls[i].screenSampler.removeAllSelections();
                                foreach (var sel in selections)
                                    _appControls[i].screenSampler.createPanel((string)sel["AmbilightTitle"], (int)sel["AmbilightX"], (int)sel["AmbilightY"], (int)sel["AmbilightW"], (int)sel["AmbilightH"], false);
                            }
                        }
                        if (device.ContainsKey("AmbilightInterval"))
                        {
                            _appControls[i].ambilightSpeed.Value = (int)device["AmbilightInterval"];
                            _appControls[i].screenSampler.liveTimer.Interval = (int)device["AmbilightInterval"];
                        }
                        if (device.ContainsKey("AmbilightScreen")) _appControls[i].screenSampler.selectedScreen = (int)device["AmbilightScreen"];                       
                        if (device.ContainsKey("Schedules"))
                        {
                            _appControls[i].appScheduleList.Items = (JArray)device["Schedules"];
                            _appControls[i].appScheduleList.createAllAppItems();
                        }
                        if (device.ContainsKey("enableSchedule")) _appControls[i].enableAppSchedule.Checked = (bool)device["enableSchedule"];

                        TabPage page = new TabPage((string)items[i]["name"]);
                        page.BackColor = Color.FromArgb(255, 27, 42, 71);
                        page.Name = (string)items[i]["ipaddress"];
                        page.Controls.Add(_appControls[i]);
                        tabDevices.TabPages.Add(page);

                        _appControls[i].ConnectDevice();
                    }
                }
            }
            catch
            {
                if (File.Exists(fileLocation.FullName))
                {
                    File.Delete(fileLocation.FullName);
                    using (FileStream fs = File.Create(fileLocation.FullName))
                    {
                        byte[] info = new UTF8Encoding(true).GetBytes("{\n \"Settings\":{\n \"startApp\":\"Minimized\", \n \"closeButtonMinimize\": false,\"savedAudioDevice\": \"\" \n },\n \"Devices\":[] \n}");
                        fs.Write(info, 0, info.Length);
                    }
                }
            }
            addDevice = new addDeviceControl();
            TabPage addTab = new TabPage("Add Device");
            addTab.BackColor = Color.FromArgb(255, 27, 42, 71);
            addTab.Name = "_Add_Device";
            addTab.Text = "Add Device";
            addTab.Controls.Add(addDevice);
            tabDevices.TabPages.Add(addTab);

            tabDevices.SelectTab(0);
            
            if (settingsWindow.startState.SelectedIndex == 0)
            {
                Hide();
                this.WindowState = FormWindowState.Minimized;
                tabDevices.Visible = false;
                int old = tabDevices.SelectedIndex;
                tabDevices.SelectedIndex = old + 1;
                tabDevices.SelectedIndex = old;
                tabDevices.Visible = true;      
            }
            else
            {
                Show();
                this.WindowState = FormWindowState.Normal;
                tabDevices.Visible = false;
                int old = tabDevices.SelectedIndex;
                tabDevices.SelectedIndex = old + 1;
                tabDevices.SelectedIndex = old;
                tabDevices.Visible = true;
            }           
        }
        public static void syncLocalControls(appControls sender)
        {           
            if (sender.sync_device)
            {
                foreach (var sync in _syncDevices)
                {
                    if (sync != sender) syncObjects(sync, sender);
                }
            }
            SaveData();
        }
        private static void syncObjects(appControls obj1, appControls obj2)
        {
            obj1.colorslider_simple.SelectedMin = obj2.colorslider_simple.SelectedMin;
            obj1.colorslider_simple.SelectedMax = obj2.colorslider_simple.SelectedMax;
            obj1.colorslider1.SelectedMin = obj2.colorslider1.SelectedMin;
            obj1.colorslider1.SelectedMax = obj2.colorslider1.SelectedMax;
            obj1.colorslider1.color1.Color = obj2.colorslider1.color1.Color;
            obj1.colorslider1.color2.Color = obj2.colorslider1.color2.Color;
            obj1.colorslider1.color3.Color = obj2.colorslider1.color3.Color;
            obj1.solidDiscoSensitivity.Value = obj2.solidDiscoSensitivity.Value;
            obj1.lowSensitivity.Value = obj2.lowSensitivity.Value;
            obj1.midSensitivity.Value = obj2.midSensitivity.Value;
            obj1.highSensitivity.Value = obj2.highSensitivity.Value;
            obj1.lowsBrightness.Value = obj2.lowsBrightness.Value;
            obj1.midsBrightness.Value = obj2.midsBrightness.Value;
            obj1.highsBrightness.Value = obj2.highsBrightness.Value;
            obj1.randomColor.Checked = obj2.randomColor.Checked;
            obj1.colorslider1.Refresh();
            obj1.solidDiscoSensitivity.Refresh();
            obj1.gfxSolidDisco.Clear(Color.FromArgb(255, 21, 32, 54));
            obj1.discoGfx.Clear(Color.FromArgb(255, 21, 32, 54));
            obj1.enableAppSchedule.Checked = obj2.enableAppSchedule.Checked;
            obj1.appScheduleList.Items = obj2.appScheduleList.Items;
            obj1.appScheduleList.createAllAppItems();
            obj1.appScheduleList.selectIndex = obj2.appScheduleList.selectIndex;
            obj1.screenSampler.openImage(obj2.screenSampler.imageFileLocation);
            obj1.screenSampler.removeAllSelections();
            foreach (var sel in obj2.screenSampler.selectionPanels)
                obj1.screenSampler.createPanel(sel.label.Text, sel.Location.X, sel.Location.Y, sel.Width, sel.Height, false);
            obj1.screenSampler.selectedScreen = obj2.screenSampler.selectedScreen;
            obj1.ambilightSpeed.Value = obj2.ambilightSpeed.Value;
        }

        public static void SaveData()
        {
            try
            {
                string jsonString = File.ReadAllText(fileLocation.FullName);
                JObject loadedData = JObject.Parse(jsonString);
                loadedData["Settings"]["startApp"] = settingsWindow.startState.SelectedItem.ToString();
                loadedData["Settings"]["closeButtonMinimize"] = settingsWindow.exitButtonBehavior.Checked;
                loadedData["Settings"]["savedAudioDevice"] = selectedaudioDevices["fullName"];
                for (int i = 0; i < _appControls.Count; i++)
                {
                    JObject device = (JObject)loadedData["Devices"][i];
                    device["syncDevice"] = _appControls[i].sync_device;
                    JArray colorPresets = new JArray(ColorToHex(_appControls[i].preset0.BackColor), ColorToHex(_appControls[i].preset1.BackColor), ColorToHex(_appControls[i].preset2.BackColor), ColorToHex(_appControls[i].preset3.BackColor), ColorToHex(_appControls[i].preset4.BackColor));
                    device["colorPresets"] = colorPresets;
                    device["DiscoColor_1"] = _appControls[i].colorslider1.color1.Color.Name;
                    device["DiscoColor_2"] = _appControls[i].colorslider1.color2.Color.Name;
                    device["DiscoColor_3"] = _appControls[i].colorslider1.color3.Color.Name;
                    JArray DiscoRange = new JArray(_appControls[i].colorslider1.SelectedMin, _appControls[i].colorslider1.SelectedMax);
                    device["DiscoRange"] = DiscoRange;
                    JArray DiscoSensitivity = new JArray(_appControls[i].lowSensitivity.Value, _appControls[i].midSensitivity.Value, _appControls[i].highSensitivity.Value);
                    device["DiscoSensitivity"] = DiscoSensitivity;
                    JArray DiscoBrightness = new JArray(_appControls[i].lowsBrightness.Value, _appControls[i].midsBrightness.Value, _appControls[i].highsBrightness.Value);
                    device["DiscoBrightness"] = DiscoBrightness;
                    JArray SolidDiscoRange = new JArray(_appControls[i].colorslider_simple.SelectedMin, _appControls[i].colorslider_simple.SelectedMax);
                    device["SolidDiscoRange"] = SolidDiscoRange;
                    device["SolidDiscoSensitivity"] = _appControls[i].solidDiscoSensitivity.Value;
                    device["SolidDiscoRandom"] = _appControls[i].randomColor.Checked;
                    device["AmbilightImage"] = _appControls[i].screenSampler.imageFileLocation;
                    JArray selections = new JArray();
                    foreach (var panel in _appControls[i].screenSampler.selectionPanels)
                    {
                        var a = new JObject();
                        a["AmbilightTitle"] = panel.label.Text;
                        a["AmbilightX"] = panel.Location.X;
                        a["AmbilightY"] = panel.Location.Y;
                        a["AmbilightW"] = panel.Width;
                        a["AmbilightH"] = panel.Height;
                        selections.Add(a);
                    }
                    device["AmbilightSelections"] = selections;
                    device["AmbilightInterval"] = _appControls[i].screenSampler.liveTimer.Interval;
                    device["AmbilightScreen"] = _appControls[i].screenSampler.selectedScreen;
                    device["Schedules"] = _appControls[i].appScheduleList.Items;
                    device["enableSchedule"] = _appControls[i].enableAppSchedule.Checked;
                }
                File.WriteAllText(fileLocation.FullName, loadedData.ToString());
            }
            catch
            {
            }
        }
        public static  void addSyncDevice(appControls sender)
        {
            _syncDevices.Add(sender);
            syncAllDevices();
            if (_syncDevices[0] != null)   syncObjects(sender, _syncDevices[0]);
            SaveData();
        }
        public static void removeSyncDevice(appControls device)
        {
            _syncDevices.Remove(device);
            Thread c = new Thread(() => { if (!checkSyncDevices()) syncAllDevices();});
            c.Start();
        }
        public static async void syncAllDevices()
        {        
            if (_syncDevices[0] != null)
            {
                JObject responseBody;
                using (var client = new HttpClient())
                {
                    var result = await client.GetAsync("http://" + _syncDevices[0].ipaddress + "/syncData");
                    string resp = await result.Content.ReadAsStringAsync();
                    responseBody = JObject.Parse(resp);
                }
                foreach (var sync in _syncDevices)
                {               
                    sync.ws.Send(responseBody.ToString(Newtonsoft.Json.Formatting.None));
                    sync.ws.Send("{\"Animations\":{\"playingAnimation\":\"" + responseBody["Animations"]["playingAnimation"] + "\"}}");
                    sync.ws.Send("{\"command\":\"restartAnimation\"}");
                    sync.setControls(responseBody.ToString(Newtonsoft.Json.Formatting.None));
                }
            }         
        }
        public static bool checkSyncDevices()
        {
        try
        {
            using (var client = new HttpClient())
            {
                
                string old = null;
                for (int i = 0; i < _syncDevices.Count; i++)
                {
                    if(_syncDevices[i] != null)
                        {
                            var result = client.GetAsync("http://" + _syncDevices[i].ipaddress + "/syncData").Result;
                            if (result.IsSuccessStatusCode)
                            {
                                var responseContent = result.Content;
                                string responseString = responseContent.ReadAsStringAsync().Result;
                                if (old != null && old != "" && old != responseString)
                                {
                                    Console.WriteLine("Devices are not in sync");
                                    return false;
                                }
                                old = responseString;
                            }
                        }

                    }

                }          
                Console.WriteLine("Devices are in sync");
                
            }
            catch (Exception)
            {
            }
            return true;
        }

        public static void broadcastTxT(appControls sender, string payload,bool syncControls)
        {
            for (int i = 0; i < _syncDevices.Count; i++)
            {
                if (_syncDevices[i].connAlive)
                {
                    _syncDevices[i].ws.SendAsync(payload, null);
                    if (syncControls && sender != _syncDevices[i]) _syncDevices[i].setControls(payload);                 
                }
            }           
        }

        public static async void removeThisTab(appControls ap)
        {
            try
            {                       
                int selected = tabDevices.SelectedIndex;
                var jsonString = "";
                using (StreamReader file = new StreamReader(ESPRGB.fileLocation.FullName, false)) jsonString = await file.ReadToEndAsync();
                var dataJson = JObject.Parse(jsonString);
                JArray items = (JArray)dataJson["Devices"];
                items.Remove(items[selected]);
                using (StreamWriter file = new StreamWriter(ESPRGB.fileLocation.FullName, false)) await file.WriteAsync(dataJson.ToString());            
                tabDevices.TabPages.RemoveAt(selected);
                _appControls.Remove(ap);
                trayContext.Items.RemoveAt(selected+3);
                ap.Dispose();
            }
            catch
            {
            }
        }
        public static void addThisTab(string name, string ipaddress)
        {
            try
            {
                appControls controls = new appControls();
                trayContext.Items.Insert(trayContext.Items.Count - 1, controls.trayAnimations(name));
                controls.ipaddress = ipaddress;
                controls.ConnectDevice();
                _appControls.Add(controls);               

                TabPage page = new TabPage(name);            
                page.Controls.Add(controls);

                tabDevices.Visible = false;
                tabDevices.TabPages.Insert(tabDevices.TabCount-1,page);
                tabDevices.SelectTab(page);           
                tabDevices.Visible = true;              
            }
            catch
            {
            }
        }

        Point lastPoint;
        private void window_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }
        private void window_MouseMove(object sender, MouseEventArgs e)
        { 
            if (e.Button == MouseButtons.Left)   {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }
        private void toolStripTurnOffAll_Click(object sender, EventArgs e)
        {
            foreach (var item in _appControls)
            {
                if (item.connAlive)
                {
                    item.powerButton.Checked = false;
                    item.ws.SendAsync("{\"Animations\":{\"playingAnimation\":\"Power Off\"}}", null);
                }
            }
        }
        private void toolStripTurnOnAll_Click(object sender, EventArgs e)
        {
            foreach (var item in _appControls)
            {
                if (item.connAlive)
                {
                    item.powerButton.Checked = true;
                    item.ws.SendAsync("{\"Animations\":{\"playingAnimation\":\"Power On\"}}", null);
                }
            }
        }
        private void exitButton_Click(object sender, EventArgs e)
        {
            if (settingsWindow.exitButtonBehavior.Checked)
            {
                Hide();
                WindowState = FormWindowState.Minimized;
                tabDevices.Visible = false;
                int old = tabDevices.SelectedIndex;
                tabDevices.SelectedIndex = old + 1;
                tabDevices.SelectedIndex = old;
                tabDevices.Visible = true;
            }
            else
            {
                exceptions exitMessage = new exceptions(1,"ESPRGB-Exit", "Are you sure you want to close?");
                exitMessage.StartPosition = FormStartPosition.CenterParent;
                exitMessage.ShowDialog();
                if (exitMessage.DialogResult == DialogResult.Yes) Application.Exit();
            }
        }
        private static string ColorToHex(Color color)
        {
            return ColorTranslator.ToHtml(Color.FromArgb(color.ToArgb()));
        }
        private void minimizeButton_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void notifyTray_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button.ToString() == "Left")
            {
                tabDevices.Visible = false;
                int old = tabDevices.SelectedIndex;
                tabDevices.SelectedIndex = old + 1;
                tabDevices.SelectedIndex = old;
                tabDevices.Visible = true;

                this.Show();
                this.WindowState = FormWindowState.Normal;
                TopMost = true;   
                this.BringToFront();
                this.Focus();
                TopMost = false;

            }
        }
        bool showUpdate = false;
        private void ESPRGB_Resize(object sender, EventArgs e)
        {
            windowState = this.WindowState;
            if (this.WindowState == FormWindowState.Minimized && !settingsWindow.exitButtonBehavior.Checked)
            {
                Hide();
                tabDevices.Visible = false;
                int old = tabDevices.SelectedIndex;
                tabDevices.SelectedIndex = old + 1;
                tabDevices.SelectedIndex = old;
                tabDevices.Visible = true;
            }
            else
            {
                tabDevices.Visible = false;
                int old = tabDevices.SelectedIndex;
                tabDevices.SelectedIndex = old + 1;
                tabDevices.SelectedIndex = old;
                tabDevices.Visible = true;

                if (showUpdate == false)
                {
                    checkForUpdates();
                    showUpdate = true;
                }
            }
        }
        public void checkForUpdates()
        {
            try
            {
                Thread updateChecker = new Thread(() => {
                    githubUpdater updater = new githubUpdater("limiteddata", "ESPRGB-Client", Path.GetTempPath());
                    Task<bool> newUpdate = updater.checkForUpdates(curVersion);
                    if (newUpdate.Result)
                    {
                        exceptions updateMessage = new exceptions(1, "ESPRGB-Update", "Version " + updater.latestVersion.ToString() + " is available.\n Do you want to update?");
                        updateMessage.StartPosition = FormStartPosition.CenterParent;
                        updateMessage.ShowDialog();
                        if (updateMessage.DialogResult == DialogResult.Yes)
                        {
                            Task<bool> download = updater.downloadNewVersionFromExtension("msi");
                            if (download.Result)
                            {
                                exceptions msg = new exceptions(0, "ESPRGB-Update", "Finished downloading. Continue installing the new version");
                                msg.StartPosition = FormStartPosition.CenterParent;
                                msg.ShowDialog();
                                if (msg.DialogResult == DialogResult.OK)
                                {
                                    if (updater.Install()) this.Invoke((MethodInvoker)delegate { Application.Exit(); });
                                }
                            }
                        }
                    }
                });
                updateChecker.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }

        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void showToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(this.WindowState == FormWindowState.Minimized)
            {
                this.Show();
                this.WindowState = FormWindowState.Normal;
                
                tabDevices.Visible = false;
                int old = tabDevices.SelectedIndex;
                tabDevices.SelectedIndex = old+1;
                tabDevices.SelectedIndex = old;
                tabDevices.Visible = true;
            }
        }
        private int Process(IntPtr buffer, int length, IntPtr user)
        {
            return length;
        }
        public static void InitializeAudioDevice(string device)
        {
            try
            {
                if (audioDevices.ContainsKey(device)) selectedaudioDevices = (JObject)audioDevices[device];
                else selectedaudioDevices = defaultAudio();
                BassWasapi.BASS_WASAPI_Stop(true);
                BassWasapi.BASS_WASAPI_Free();
                Bass.BASS_Free();

                Bass.BASS_Init(0, 44100, BASSInit.BASS_DEVICE_DEFAULT, IntPtr.Zero);
                BassWasapi.BASS_WASAPI_Init((int)selectedaudioDevices["id"], 0, 0, BASSWASAPIInit.BASS_WASAPI_BUFFER, 1f, 0.05f, ESPRGB._process, IntPtr.Zero);
                BassWasapi.BASS_WASAPI_Start();
            }
            catch
            {
                selectedaudioDevices = defaultAudio();
                BassWasapi.BASS_WASAPI_Stop(true);
                BassWasapi.BASS_WASAPI_Free();
                Bass.BASS_Free();

                Bass.BASS_Init(0, 44100, BASSInit.BASS_DEVICE_DEFAULT, IntPtr.Zero);
                BassWasapi.BASS_WASAPI_Init((int)selectedaudioDevices["id"], 0, 0, BASSWASAPIInit.BASS_WASAPI_BUFFER, 1f, 0.05f, ESPRGB._process, IntPtr.Zero);
                BassWasapi.BASS_WASAPI_Start();
            }
        }
        static JObject _defaultAudio;
        private static JObject defaultAudio()
        {
            _defaultAudio = new JObject();
            _defaultAudio["id"] = -3;
            _defaultAudio["fullName"] = "Default";
            _defaultAudio["firstName"] = "Default";
            _defaultAudio["secondName"] = "Default";
            _defaultAudio["isDefault"] = true;
            return _defaultAudio;
        }
        public static JObject updateAudioDevices()
        {
            audioDevices.RemoveAll();
            audioDevices.Add("Default", defaultAudio());
            BASS_WASAPI_DEVICEINFO item = new BASS_WASAPI_DEVICEINFO();
            for (int n = 0; BassWasapi.BASS_WASAPI_GetDeviceInfo(n, item); n++)
            {
                if (item.IsEnabled && item.IsLoopback)
                {
                    var device = item.name.Split('(');
                    JObject deviceJson = new JObject();
                    deviceJson["id"] = n;
                    deviceJson["fullName"] = item.name;
                    deviceJson["firstName"] = device[0];
                    deviceJson["secondName"] = device[1].Remove(device[1].Length - 1, 1);
                    deviceJson["isDefault"] = item.IsDefault;
                    audioDevices.Add(item.name, deviceJson);
                }
            }
            return audioDevices;
        }
        private void settingsButton_Click(object sender, EventArgs e)
        {
            settingsWindow.ShowDialog();
        }
        private void ESPRGB_Closing(object sender, FormClosingEventArgs e)
        {
            this.Show();
            SaveData();
        }
    }
    
}
