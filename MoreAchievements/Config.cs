using System;
using System.IO;
using TShockAPI;
using Newtonsoft.Json;
using System.Data;

namespace MoreAchievements
{
    public class Config
    {
        public bool enable { get; set; }
        public DataSet achSet { get; set; }

        public static Config loadProcedure(string path)
        {
            bool isit = File.Exists(path);
            if (isit)
            {
                TShock.Log.Info("Config file found!");
                var JSON = load(path);
                return (JSON);
            }
            else
            {
                TShock.Log.Error("Config file not found!");
                var JSON = create(path);
                return (JSON);
            }
        }

        public static Config load(string path)
        {
            StreamReader sr = new StreamReader(File.Open(path, FileMode.Open));
            var JSON = JsonConvert.DeserializeObject<Config>(sr.ReadToEnd());
            return (JSON);
        }

        public static Config create(string path)
        {
            Config cd = new Config
            {
                enable = true,
                achSet = new DataSet("Achievements")
            };
            DataTable tAch = new DataTable("Achievements");
            DataColumn en = new DataColumn("Enable", typeof(bool));
            DataColumn na = new DataColumn("Name", typeof(string));
            DataColumn tp = new DataColumn("Type", typeof(string));
            DataColumn op = new DataColumn("Options", typeof(string));
            tAch.Columns.Add(en);
            tAch.Columns.Add(na);
            tAch.Columns.Add(tp);
            tAch.Columns.Add(op);
            cd.achSet.Tables.Add(tAch);

            DataRow dR = tAch.NewRow();
            dR["Enable"] = true;
            dR["Name"] = "First dirt!";
            dR["Type"] = "Dig";
            dR["Options"] = "Dirt";
            tAch.Rows.Add(dR);

            cd.achSet.AcceptChanges();

            File.WriteAllText(path, JsonConvert.SerializeObject(cd, Formatting.Indented));

            StreamReader sr = new StreamReader(File.Open(path, FileMode.Open));
            var JSON = JsonConvert.DeserializeObject<Config>(sr.ReadToEnd());
            return (JSON);
        }
    }
    
    /*public static class configDetiles
    {
        public bool enable { get; set; }
        public DataSet achSet { get; set; }
    }*/
}
