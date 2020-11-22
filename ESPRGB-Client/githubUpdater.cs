using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace githubUpdaterApp
{
    class githubUpdater
    {
        public event EventHandler<bool> newUpdate;
        private string _username;
        private string _repository;
        private string _tempDir;
        public string updateArchiveFileName;
        private JObject latestReleaseJson;
        public Version latestVersion;
        private HttpClient client = new HttpClient();
        private bool newUpdateAvailable
        {
            get { return _newUpdateAvailable; }
            set {
                newUpdate?.Invoke(this, value);
                _newUpdateAvailable = value;
            }
        }
        private bool _newUpdateAvailable;
        public githubUpdater(string username, string repository, string tempDir)
        {
            _username = username;
            _repository = repository;
            _tempDir = tempDir;
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
            client.DefaultRequestHeaders.Add("User-Agent", "update from github release");
        }
        public async Task<bool> checkForUpdates(Version currentVersion)
        {
            latestReleaseJson = await GetLatestReleaseJSONAsync(_username, _repository);

            latestVersion = new Version(latestReleaseJson["tag_name"].ToString().Split('v')[1]);

            if (latestVersion > currentVersion)
            {
                newUpdateAvailable = true;
                return true;
            }
            else
            {
                newUpdateAvailable = false;
                return false;
            }
        }
        public async Task<bool> downloadNewVersion()
        {
            var updateUrl = ExtractDownloadUrl(latestReleaseJson);
            updateArchiveFileName = Path.Combine(_tempDir, Path.GetFileName(updateUrl));                  
            await DownloadFile(updateUrl, updateArchiveFileName);
            return File.Exists(updateArchiveFileName);
        }

        public async Task<bool> downloadVersion(string version)
        {
            try
            {
                JObject versionJson = await GetVersionJSONAsync(_username, _repository, version);
                var updateUrl = ExtractDownloadUrl(versionJson);
                updateArchiveFileName = Path.Combine(_tempDir, Path.GetFileName(updateUrl));
                await DownloadFile(updateUrl, updateArchiveFileName);
            }
            catch
            {
                MessageBox.Show($"Cannot find the version {version}");
            }



            return File.Exists(updateArchiveFileName);
        }
        public async Task DownloadFile(string url, string destinationFileName)
        {
            using (var stream = await client.GetStreamAsync(url))
            {
                using (var file = new FileStream(destinationFileName, FileMode.Create))
                {
                    stream.CopyTo(file);
                }
            }
        }
        public bool Install()
        {
            try { 
                if (newUpdateAvailable)
                {
 
                    var process = new Process
                    {
                        StartInfo = new ProcessStartInfo
                        {
                            FileName = updateArchiveFileName,
                            WorkingDirectory = _tempDir,
                            RedirectStandardOutput = false,
                            RedirectStandardError = false,
                        }
                    };
                    process.Start();
                    return true;
                }
            return false;
            }
            catch
            {
                return false;
            }
        }
        public static string ExtractDownloadUrl(JObject json) => json["assets"][0]["browser_download_url"].ToObject<string>();

        public static Version ExtractVersion(JObject json) => new Version(json["name"].ToObject<string>());

        public async Task<JObject> GetJSONAsync(string gitHubDirectory) => JObject.Parse(await client.GetStringAsync($"https://api.github.com/{gitHubDirectory}"));

        public async Task<JObject> GetLatestReleaseJSONAsync(string user, string repository) => await GetJSONAsync($"repos/{user}/{repository}/releases/latest");
        public async Task<JObject> GetVersionJSONAsync(string user, string repository, string tag) => await GetJSONAsync($"repos/{user}/{repository}/releases/tags/{tag}");

    }
}
