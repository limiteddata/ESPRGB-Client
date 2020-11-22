using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using githubUpdaterApp;
using System.IO.Compression;
using ESPOTAFLASHER;
using System.IO;

namespace ESPRGB_Client
{
    public partial class firmwareUpdater : Form
    {
        private string _ipaddress;
        private string _version;
        public firmwareUpdater(string ipaddress, string version)
        {
            InitializeComponent();
            _ipaddress = ipaddress;
            _version = version;
        }

        private async void firmwareUpdater_Load(object sender, EventArgs e)
        {
            ipaddressText.Text = _ipaddress;
            infoText.Text = "";

            string firmwarePath = Path.GetTempPath() + $"firmware_{_version}.bin";
            githubUpdater updater = new githubUpdater("limiteddata", "ESPRGB-8266", Path.GetTempPath());
            infoText.Text += $"Downloading firmware version {_version}.\n";
            var download = await updater.downloadVersion(_version);         
            if (download)
            {
                infoText.Text += "Finished downloading firmware \n";
                infoText.Text += "Unziping the archive\n";
                if (File.Exists(firmwarePath)) File.Delete(firmwarePath);
                ZipFile.ExtractToDirectory(updater.updateArchiveFileName, Path.GetTempPath());            
                progress.Value = 0;

                ESPOTA ota = new ESPOTA(_ipaddress, firmwarePath);
                progress.Maximum = ota.content_size;
                ota.progressEvent += (senderx, ex) =>
                {
                    progress.Value = ex;
                    progress.Refresh();
                };
                ota.messageEvent += (senderx, ex) =>
                {
                    infoText.Text += ex + "\n";
                    infoText.Refresh();
                };
                if (ota.Update())
                {                  
                    exceptions msg = new exceptions(0, "ESPRGB-FirmwareUpdate", "Firmware updated successfully!");
                    msg.StartPosition = FormStartPosition.CenterParent;
                    msg.ShowDialog();
                }
                else
                {
                    exceptions msg = new exceptions(0, "ESPRGB-FirmwareUpdate", "Failed to upload the firmware!");
                    msg.StartPosition = FormStartPosition.CenterParent;
                    msg.ShowDialog();
                }
                File.Delete(updater.updateArchiveFileName);
                File.Delete(Path.GetTempPath() + $"firmware_{_version}.bin");
                this.Close();
            }
            else
            {
                this.Close();
            }
        }
        Point lastPoint;
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }     
    }
}
