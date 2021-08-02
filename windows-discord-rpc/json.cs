using System;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace windows_discord_rpc
{
    public class json
    {
        public string path;
        public json(string filepath)
        {
            path = filepath;
        }
        public bool saveconfig(Dictionary<string, bool> data)
        {
            TextWriter writer = null;
            try
            {
                var json = JsonConvert.SerializeObject(data);

                writer = new StreamWriter(path, false);
                writer.Write(json);
                writer.Close();

                return true;
            }
            catch
            {
                if (writer is not null)
                {
                    writer.Close();
                }

                return false;
            }
        }
        public Dictionary<string, bool> loadconfig()
        {
            StreamReader reader = new StreamReader(path);
            var config = JsonConvert.DeserializeObject(reader.ReadToEnd());
            reader.Close();

            return (Dictionary<string, bool>)config;
        }
    }
}
