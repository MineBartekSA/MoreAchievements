using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TShockAPI;
using Newtonsoft.Json;
using System.Data;

namespace MoreAchievements
{
    class Config
    {
        // Load class
        public class Load
        {
            private int CCI;
            private int CCII;
            private bool ok = true;
            private bool WTF = false;
            public void ConfigLoad (string path)
            {
                //Checking for config file
                bool ifconfig =  File.Exists(path + "MoreAchievements.json");
                if (!ifconfig)
                {
                    TShock.Log.Error("Can't locate config file!");
                    TShock.Log.Info("Creating one");
                    bool CC = ConfigCreate(ifconfig, path);
                    if (CC)
                    {
                        if(CCII == 1)
                        {
                            TShock.Log.Info("Ok i try to load it!");
                        }
                        TShock.Log.Info("Creating finished!");
                        TShock.Log.Info("Loading config!");
                    }
                }
                //Loading config

            }

            bool ConfigCreate (bool ifconfig, string path)
            {
                if (ifconfig)
                {
                    if (CCI == 1)
                    {
                        TShock.Log.Error("What? Again? There is a bug! Config file exist! Ech just Load it!");
                        CCII = 1;
                        return ok;
                    }
                    TShock.Log.Error("What? Config file exist you must check again!");
                    CCI = 1;
                    return WTF;
                }
                //Creating config
                File.Create(path + "MoreAchievements.json");
                //Adding to config

                //Dodać!

                return ok;
            }

            public void ConfigReCreate()
            {

            }
        }
        // End of Load
        // JSON Class PRIVATE
        public class JSON
        {
            public class config
            {
                public bool isON { get; set; }
                // Tu następne pujedyńcze linie configu!
            }
            class Achievements
            {

            }
        }
    }
}
