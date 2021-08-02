using System;
using System.Management;
using DiscordRPC;
using DiscordRPC.Logging;

namespace windows_discord_rpc
{
    public class Discord
    {
        private string app_id;

        public Discord(string id)
        {
            Convert.ToInt64(id); // Check if ID is int
            app_id = id;
        }

        public void setpresence()
        {
            // Get system information

            string[] manufacturer = new string[1];
            var OSversion = "Windows " + Environment.OSVersion.Version.Major.ToString();
            SelectQuery query = new SelectQuery(@"Select * from Win32_ComputerSystem");

            using (ManagementObjectSearcher searcher = new ManagementObjectSearcher(query))
            {
                foreach (ManagementObject process in searcher.Get())
                {
                    process.Get();
                    manufacturer[0] = (string)process["Manufacturer"];
                    break;
                }
            }

            DiscordRpcClient client = new DiscordRpcClient(app_id);

            client.Logger = new ConsoleLogger() { Level = LogLevel.Warning };

            client.Initialize();
            client.SetPresence(new RichPresence()
            {
                Details = manufacturer[0],
                State = OSversion,
                Assets = new Assets()
                {
                    LargeImageKey = "image_large",
                    LargeImageText = "Howfindthis",
                    SmallImageKey = "image_small"
                }
            });
        }
    }
}
