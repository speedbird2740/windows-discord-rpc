using System.Threading;

namespace windows_discord_rpc
{
    class Program
    {
        static void Main()
        {
            // Dictionary<string, bool> configIO = new json("data\\config.json").loadconfig();

            // Console.WriteLine("Loaded Config");

            new Discord("871503813784272936").setpresence();
            
            while (true)
            {
                Thread.Sleep(1000);
            }
        }
    }
}
