using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using Un4seen.Bass;
using Un4seen.BassWasapi;

namespace ESPRGB_Client
{
    public partial class addnewProcess : Form
    {
        private float[] _fft = new float[1024];
        public int stepIndex
        {
            get { return _stepIndex; }
            set
            {
                stopTimers();
                switch (value)
                    {
                        case 0:
                            showAllProc();
                            backButton.Enabled = false;
                            procList.Visible = true;
                            animList.Visible = false;
                            finishButton.Visible = false;
                            nextButton.Visible = true;
                            break;
                        case 1:
                            backButton.Enabled = true;
                            finishButton.Visible = false;
                            nextButton.Visible = true;
                            procList.Visible = false;
                            animList.Visible = true;
                            turnOffAllParameters();
                            break;
                        case 2:
                            animList.Visible = false;                            
                            nextButton.Visible = false;
                            finishButton.Visible = true;
                            if ((string)animList.SelectedItem == "Solid Color") parametersSolidColor.Visible = true;
                            if ((string)animList.SelectedItem == "Color Cycle") parametersColorCycle.Visible = true;
                            if ((string)animList.SelectedItem == "Breathing") parametersBreathing.Visible = true;
                            if ((string)animList.SelectedItem == "Disco")
                            {
                                discoTimer.Enabled = true;
                                parametersDisco.Visible = true;
                            }
                            if ((string)animList.SelectedItem == "Solid Disco")
                            {
                                solidDiscoTimer.Enabled = true;
                                parametersSolidDisco.Visible = true;
                            }
                            if ((string)animList.SelectedItem == "Morse Code") parametersMorseCode.Visible = true;
                            if ((string)animList.SelectedItem == "Ambilight")
                            {
                                screenSampler1.liveTimer.Start();
                                parametersAmbilight.Visible = true;
                            }
                            break;
                }
                    _stepIndex = value;        
            }
        }
        private int _stepIndex;

        JArray usedItems = new JArray();
        public JObject result = new JObject();
        public addnewProcess(JArray items,JObject animParameters = null)
        {
            InitializeComponent();
            usedItems = items;
            stepIndex = 0;
            screenSampler1.CreateDefaultSelections();
            if (animParameters != null)
            {
                if (animParameters.ContainsKey("SolidColor"))
                {
                    JObject SolidColor = animParameters["SolidColor"].ToObject<JObject>();
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
                if (animParameters.ContainsKey("ColorCycle"))
                {
                    JObject ColorCycle = animParameters["ColorCycle"].ToObject<JObject>();
                    if (ColorCycle.ContainsKey("ColorCycleSpeed"))
                    {
                        ColorCycleSpeed.Value = (int)ColorCycle["ColorCycleSpeed"];
                        ColorCycleSpeedText.Text = (string)ColorCycle["ColorCycleSpeed"];
                    }
                }
                if (animParameters.ContainsKey("Breathing"))
                {
                    JObject Breathing = animParameters["Breathing"].ToObject<JObject>();
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
                        if (colArray.Count > 0)
                        {
                            foreach (JArray item in colArray)
                            {
                                if (item.Count == 3) col.Add(Color.FromArgb(255, (int)item[0] / 4, (int)item[1] / 4, (int)item[2] / 4));
                            }
                            colorListResult.addListColor(col);
                        }
                    }
                    if (Breathing.ContainsKey("addColortoList"))
                    {
                        if (colorListResult.colorList.Count < 25)
                        {
                            colorListResult.addColor(Color.FromArgb(255, (int)Breathing["addColortoList"][0] / 4, (int)Breathing["addColortoList"][1] / 4, (int)Breathing["addColortoList"][2] / 4));
                        }
                        else
                        {
                            exceptions exitMessage = new exceptions("ESPRGB-Exception", "25 colors limit");
                            exitMessage.StartPosition = FormStartPosition.CenterParent;
                            exitMessage.ShowDialog();
                        }
                    }
                    if (Breathing.ContainsKey("removeLastfromList"))
                    {
                        colorListResult.removeLastColor();
                    }
                    if (Breathing.ContainsKey("clearColorList"))
                    {
                        colorListResult.clearAll();
                    }
                    if (Breathing.ContainsKey("useColorList")) useColorList.Checked = (bool)Breathing["useColorList"];
                }
                if (animParameters.ContainsKey("Disco"))
                {
                    JObject Disco = animParameters["Disco"].ToObject<JObject>();
                    if (Disco.ContainsKey("DiscoColor_1")) colorslider1.color1.Color = Color.FromName((string)Disco["DiscoColor_1"]);
                    if (Disco.ContainsKey("DiscoColor_2")) colorslider1.color2.Color = Color.FromName((string)Disco["DiscoColor_2"]);
                    if (Disco.ContainsKey("DiscoColor_3")) colorslider1.color3.Color = Color.FromName((string)Disco["DiscoColor_3"]);
                    colorslider1.Refresh();
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
                    if (Disco.ContainsKey("DiscoBrightness"))
                    {
                        lowsBrightness.Value = (int)Disco["DiscoBrightness"][0];
                        midsBrightness.Value = (int)Disco["DiscoBrightness"][1];
                        highsBrightness.Value = (int)Disco["DiscoBrightness"][2];
                    }
                }
                if (animParameters.ContainsKey("SolidDisco"))
                {
                    JObject SolidDisco = animParameters["SolidDisco"].ToObject<JObject>();
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
                }
                if (animParameters.ContainsKey("MorseCode"))
                {

                    JObject MorseCode = animParameters["MorseCode"].ToObject<JObject>();
                    if (MorseCode.ContainsKey("useBuzzer")) useBuzzer.Checked = (bool)MorseCode["useBuzzer"];
                    if (MorseCode.ContainsKey("colorMorseCode")) morseColor.Color = Color.FromArgb(255, (int)MorseCode["colorMorseCode"][0] / 4, (int)MorseCode["colorMorseCode"][1] / 4, (int)MorseCode["colorMorseCode"][2] / 4);
                    if (MorseCode.ContainsKey("unitTimeMorseCode")) unitTime.Value = (int)MorseCode["unitTimeMorseCode"];
                    if (MorseCode.ContainsKey("encodedMorseCode"))
                    {
                        morsePlainText.Text = decodeMessage((string)MorseCode["encodedMorseCode"]);
                        encodedMsgResult.Text = (string)MorseCode["encodedMorseCode"];
                    }
                }
                if (animParameters.ContainsKey("Ambilight"))
                {
                    JObject Ambilight = animParameters["Ambilight"].ToObject<JObject>();                  
                    if (Ambilight.ContainsKey("AmbilightImage")) screenSampler1.openImage((string)Ambilight["AmbilightImage"]);
                    if (Ambilight.ContainsKey("AmbilightSelections"))
                    {
                        var selections = (JArray)Ambilight["AmbilightSelections"];
                        if (selections.Count > 0)
                        {
                            screenSampler1.removeAllSelections();
                            foreach (var sel in selections)
                                screenSampler1.createPanel((string)sel["AmbilightTitle"], (int)sel["AmbilightX"], (int)sel["AmbilightY"], (int)sel["AmbilightW"], (int)sel["AmbilightH"], false);
                        }
                    }
                    if (Ambilight.ContainsKey("AmbilightInterval"))
                    {
                        ambilightSpeed.Value = (int)Ambilight["AmbilightInterval"];
                        screenSampler1.liveTimer.Interval = (int)Ambilight["AmbilightInterval"];
                    }
                    if (Ambilight.ContainsKey("AmbilightScreen")) screenSampler1.selectedScreen = (int)Ambilight["AmbilightScreen"];
                }
            }
        }
        void turnOffAllParameters()
        {
            parametersSolidColor.Visible = false;
            parametersColorCycle.Visible = false;
            parametersBreathing.Visible = false;
            parametersDisco.Visible = false;
            parametersSolidDisco.Visible = false;
            parametersMorseCode.Visible = false;
            parametersAmbilight.Visible = false;
        }
        void showAllProc()
        {
            procList.Items.Clear();
            var cp = Process.GetCurrentProcess();           
            var p = Process.GetProcesses();
            List<string> usedApps = new List<string>();
            for (int i = 0; i < usedItems.Count; i++) usedApps.Add((string)usedItems[i]["appName"]);
            if(!usedApps.Contains("DEFAULT APP")) procList.Items.Add("DEFAULT APP");
            for (int i = 0; i < p.Length; i++)
            {
                if (p[i].MainWindowTitle.Length > 0 && !usedApps.Contains(p[i].ProcessName) && p[i].ProcessName != cp.ProcessName) procList.Items.Add(p[i].ProcessName);          
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
        private void closeButton_Click(object sender, EventArgs e)
        {
            stopTimers();
            this.Dispose();
        }
        private void nextButton_Click(object sender, EventArgs e)
        {
            if (stepIndex == 0 && procList.SelectedIndex == -1)
            {
                exceptions exitMessage = new exceptions("ESPRGB-Exception", "Please select an app!");
                exitMessage.StartPosition = FormStartPosition.CenterParent;
                exitMessage.ShowDialog();
                return;
            }
            stepIndex += 1;
        }
        private void backButton_Click(object sender, EventArgs e)
        {
            stepIndex -= 1;
        } 
        private void finishButton_Click(object sender, EventArgs e)
        {
            stopTimers();
            if (stepIndex == 1 && animList.SelectedIndex == -1)
            {
                exceptions exitMessage = new exceptions("ESPRGB-Exception", "Please select an animation!");
                exitMessage.StartPosition = FormStartPosition.CenterParent;
                exitMessage.ShowDialog();
                return;
            }
            this.DialogResult = DialogResult.OK;

            result["machineName"] = Environment.MachineName;
            result["appName"] = procList.SelectedItem.ToString();
            result["animName"] = animList.SelectedItem.ToString();
            var parameters = new JObject();
            if ((string)animList.SelectedItem == "Solid Color")
            {
                var solidColor = new JObject();             
                var color = new JArray(colorWheel.Color.R*4, colorWheel.Color.G*4, colorWheel.Color.B*4);
                solidColor["Color"] = color;
                solidColor["Brightness"] = (float)brightnessSlide.Value/100;
                parameters["SolidColor"] = solidColor;
            }
            if ((string) animList.SelectedItem == "Color Cycle")
            {
                var ColorCycle = new JObject();
                ColorCycle["ColorCycleSpeed"] = ColorCycleSpeed.Value;
                parameters["ColorCycle"] = ColorCycle;
            }
            if ((string)animList.SelectedItem == "Breathing")
            {
                var Breathing = new JObject();
                Breathing["breathingSpeed"] = breathingSpeed.Value;
                var color = new JArray(colorBreathing.Color.R * 4, colorBreathing.Color.G * 4, colorBreathing.Color.B * 4);
                Breathing["staticColorBreathing"] = color; 
                var colorListBreathing = new JArray();
                foreach (var item in colorListResult.colorList) colorListBreathing.Add(new JArray(item.R*4, item.G*4, item.B*4));               
                Breathing["colorListBreathing"] = colorListBreathing;
                Breathing["useColorList"] = useColorList.Checked;
                parameters["Breathing"] = Breathing;
            }
            if ((string)animList.SelectedItem == "Disco")
            {
                var Disco = new JObject();
                Disco["DiscoColor_1"] = colorslider1.color1.Color.Name;
                Disco["DiscoColor_2"] = colorslider1.color2.Color.Name;
                Disco["DiscoColor_3"] = colorslider1.color3.Color.Name;
                JArray DiscoRange = new JArray(colorslider1.SelectedMin, colorslider1.SelectedMax);
                Disco["DiscoRange"] = DiscoRange;
                JArray DiscoSensitivity = new JArray(lowSensitivity.Value, midSensitivity.Value, highSensitivity.Value);
                Disco["DiscoSensitivity"] = DiscoSensitivity;
                JArray DiscoBrightness = new JArray(lowsBrightness.Value, midsBrightness.Value, highsBrightness.Value);
                Disco["DiscoBrightness"] = DiscoBrightness;
                parameters["Disco"] = Disco;
            }
            if ((string)animList.SelectedItem == "Solid Disco") {
                var SolidDisco = new JObject();
                var color = new JArray(colorWheel_SolidDisco.Color.R * 4, colorWheel_SolidDisco.Color.G * 4, colorWheel_SolidDisco.Color.B * 4);
                SolidDisco["colorSolidDisco"] = color;
                SolidDisco["SolidDiscoRandom"] = randomColor.Checked;
                var range = new JArray(colorslider_simple.SelectedMin,colorslider_simple.SelectedMax);
                SolidDisco["SolidDiscoRange"] = range;
                parameters["SolidDisco"] = SolidDisco;
            }
            if ((string)animList.SelectedItem == "Morse Code")
            {
                var MorseCode = new JObject();
                var color = new JArray(morseColor.Color.R * 4, morseColor.Color.G * 4, morseColor.Color.B * 4);
                MorseCode["colorMorseCode"] = color;
                MorseCode["encodedMorseCode"] = encodedMsgResult.Text;
                MorseCode["unitTimeMorseCode"] = unitTime.Value;
                MorseCode["useBuzzer"] = useBuzzer.Checked;
                parameters["MorseCode"] = MorseCode;
            }
            if ((string)animList.SelectedItem == "Ambilight")
            {
                var Ambilight = new JObject();              
                JArray selections = new JArray();
                foreach (var panel in screenSampler1.selectionPanels)
                {
                    var a = new JObject();
                    a["AmbilightTitle"] = panel.label.Text;
                    a["AmbilightX"] = panel.Location.X;
                    a["AmbilightY"] = panel.Location.Y;
                    a["AmbilightW"] = panel.Width;
                    a["AmbilightH"] = panel.Height;
                    selections.Add(a);
                }
                Ambilight["AmbilightSelections"] = selections;
                Ambilight["AmbilightImage"] = screenSampler1.imageFileLocation;
                Ambilight["AmbilightInterval"] = screenSampler1.liveTimer.Interval;
                Ambilight["AmbilightScreen"] = screenSampler1.selectedScreen;
                parameters["Ambilight"] = Ambilight;
            }
            result["parameters"] = parameters;
            result["enabled"] = true;
            this.Dispose();
        }
        private void ColorCycleSpeed_Scroll(object sender, Zeroit.Framework.Metro.ZeroitMetroTrackbar.TrackbarEventArgs e)
        {
            ColorCycleSpeedText.Text = ColorCycleSpeed.Value.ToString();
        }
        private void breathingSpeed_Scroll(object sender, Zeroit.Framework.Metro.ZeroitMetroTrackbar.TrackbarEventArgs e)
        {
            breathingSpeedText.Text = breathingSpeed.Value.ToString();
        }
        private void brightnessSlide_Scroll(object sender, Zeroit.Framework.Metro.ZeroitMetroTrackbar.TrackbarEventArgs e)
        {
            float brightness = ((float)brightnessSlide.Value / 100.0f);
            Color newColor = Color.FromArgb(255, (int)(colorWheel.Color.R * brightness), (int)(colorWheel.Color.G * brightness), (int)(colorWheel.Color.B * brightness));
            brightnessSlide.GradientColor = newColor;
            brightnessSlide.LeftColor = newColor;
            brightnessSlide.RegionColor = newColor;
            brightnessSlide.BackColor = newColor;
            brightnessSlide.Update();
        }

        private void colorWheel_ColorChanged(object sender, EventArgs e)
        {
            float brightness = ((float)brightnessSlide.Value / 100.0f);
            Color newColor = Color.FromArgb(255, (int)(colorWheel.Color.R * brightness), (int)(colorWheel.Color.G * brightness), (int)(colorWheel.Color.B * brightness));
            brightnessSlide.RegionColor = newColor;
            brightnessSlide.LeftColor = newColor;
            brightnessSlide.GradientColor = newColor;
            brightnessSlide.BackColor = newColor;
            brightnessSlide.Update();
        }
        private void br_addCurrentColor_Click(object sender, EventArgs e)
        {
            if (colorListResult.colorList.Count < 25) colorListResult.addColor(colorBreathing.Color);
            else
            {
                exceptions exitMessage = new exceptions("ESPRGB-Exception", "25 colors limit");
                exitMessage.StartPosition = FormStartPosition.CenterParent;
                exitMessage.ShowDialog();
            }
        }
        private void br_removeLastColor_Click(object sender, EventArgs e)
        {
            colorListResult.removeLastColor();
        }
        private void br_clearColorlist_Click(object sender, EventArgs e)
        {
            colorListResult.clearAll();;
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

        private void morsePlainText_KeyUp(object sender, KeyEventArgs e)
        {
            encodedMsgResult.Text = encodeMessage(morsePlainText.Text);
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
            colorslider1.Refresh();
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

        private void discoTimer_Tick(object sender, EventArgs e)
        {
            discoGfx.Clear(Color.FromArgb(255, 21, 32, 54));
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
            }

            avgLow = avgLow > 0 ? (int)((avgLow / colorslider1.SelectedMin) * ((float)lowsBrightness.Value / 100.0f)) : 0;
            avgMid = avgMid > 0 ? (int)((avgMid / (colorslider1.SelectedMax - colorslider1.SelectedMin)) * ((float)midsBrightness.Value / 100.0f)) : 0;
            avgHigh = avgHigh > 0 ? (int)((avgHigh / (colorslider1.Max - colorslider1.SelectedMax)) * ((float)highsBrightness.Value / 100.0f)) : 0;

            pictureBoxTop.Image = bmp;

            int[] finalc = CombineColors(ColortoList(avgLow, colorslider1.color1.Color), ColortoList(avgMid, colorslider1.color2.Color), ColortoList(avgHigh, colorslider1.color3.Color));


            ResultColor.BackColor = Color.FromArgb(255, finalc[0], finalc[1], finalc[2]);
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
        private void solidDiscoTimer_Tick(object sender, EventArgs e)
        {
            gfxSolidDisco.Clear(Color.FromArgb(255, 21, 32, 54));
            BassWasapi.BASS_WASAPI_GetData(_fft, (int)BASSData.BASS_DATA_FFT2048); //get channel fft data

            int y = 0;
            int b0 = 0;
            int posX = 15;

            for (int x = 0; x < 16; x++)
            {
                float peak = 0;
                int b1 = (int)Math.Pow(2, x * 10.0 / (16 - 1));

                if (b1 > 1023) b1 = 1023;
                if (b1 <= b0) b1 = b0 + 1;
                for (; b0 < b1; b0++) if (peak < _fft[1 + b0]) peak = _fft[1 + b0];
                y = (int)(Math.Sqrt(peak) * 3 * 255 - 4);
                if (y > 255) y = 255;
                if (y < 0) y = 0;
                //draw lines
                if (x >= colorslider_simple.SelectedMin && x < colorslider_simple.SelectedMax)
                {
                    penSolidDisco.Color = colorslider_simple.color.Color;
                }
                else penSolidDisco.Color = Color.Black;

                gfxSolidDisco.DrawLine(penSolidDisco, new Point(posX, bmpSolidDisco.Height), new Point(posX, bmpSolidDisco.Height - (y / 2)));
                posX += 25;
            }
            SolidDiscoVisualizer.Image = bmpSolidDisco;            
        }

        private void addnewProcess_Load(object sender, EventArgs e)
        {
            initializeSolidDiscoVisualizer();
            InitializeBitmapAndGraphics();
        }

        private void colorWheel_SolidDisco_ColorChanged(object sender, EventArgs e)
        {
            colorslider_simple.color = new SolidBrush(colorWheel_SolidDisco.HslColor);
            colorslider_simple.Refresh();
        }
        private void stopTimers()
        {
            discoTimer.Enabled = false;
            solidDiscoTimer.Enabled = false;
            screenSampler1.liveTimer.Stop();
        }
    }
}
