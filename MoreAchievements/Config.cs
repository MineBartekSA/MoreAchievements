using System;
using System.IO;
using TShockAPI;
using Newtonsoft.Json;


namespace MoreAchievements
{
    public class Config
    {
        public bool MyBool1 = false;
        public bool MyBool2 = false;

        public static Config Read(string path)
        {

            if (!File.Exists(path))

            {

                Config config = new Config();

                File.WriteAllText(path, JsonConvert.SerializeObject(config, Formatting.Indented));

                return config;

            }

            return JsonConvert.DeserializeObject<Config>(File.ReadAllText(path));
        }
        public void Write(string path)
        {
            using (var fs = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.Write))
            {
                Write(fs);
            }
        }

        public void Write(Stream stream)
        {
            var str = JsonConvert.SerializeObject(this, Formatting.Indented);
            using (var sw = new StreamWriter(stream))
            {
                sw.Write(str);
            }
        }

        public static Action<ConfigFile> ConfigRead;

        internal static string ConfigPath { get { return Path.Combine(TShock.SavePath, "PLUGIN.json"); } }

        public static void SetupConfig()
        {
            try
            {
                if (File.Exists(ConfigPath))
                    MoreAchievements.Config = Read(ConfigPath);
                /* Add all the missing config properties in the json file */

                Config.Write(ConfigPath);
            }
            catch (Exception ex)
            {
                TShock.Log.ConsoleError("Config Exception: Error in config file");
                TShock.Log.Error(ex.ToString());
            }
        }
    }
}
