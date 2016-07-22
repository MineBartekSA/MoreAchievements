using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using TerrariaApi.Server;
using TShockAPI;

namespace MoreAchievements
{
    [ApiVersion(1, 23)]
    public class MoreAchievements : TerrariaPlugin
    {
        // Changes (Zmienne)
        public bool Enable;
        // Private
        private string path = Path.Combine(TShock.SavePath, "MoreAchievements.json");
        private static Config conf;
        // End of this
        // Changes (Zmienne) of types
        public bool Dig;
        public bool KM;
        // End of this
        //Init
        public override Version Version
        {
            get { return new Version("1.0"); } // Pamiętać by zmienić w kilku miejscach
        }
        public override string Name
        {
            get { return "MoreAchievements"; }
        }
        public override string Author
        {
            get { return "MineBartekSA"; }
        }
        public override string Description
        {
            get { return "Add more Achievements"; }
        }

        public MoreAchievements(Main game) : base(game)
        {
            //Nothing!
        }
        public override void Initialize()
        {
            //Configs
            conf = Config.loadProcedure(path);
            TShock.Log.Info("Is " + conf.enable);
            Enable = conf.enable;
            if (Enable)
            {
                DataTable dt = conf.achSet.Tables["Achievements"];
                foreach (DataRow row in dt.Rows)
                {
                    TShock.Log.Info("Loaded " + row["name"]);
                }
                foreach (DataRow row in dt.Rows)
                {
                    if (Enable)
                        TSG((string)row["type"]);
                }
            }

            //Hooks
            ServerApi.Hooks.NetGetData.Register(this, OnGetData);
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //UnHooks
                ServerApi.Hooks.NetGetData.Register(this, OnGetData);
            }
            base.Dispose(disposing);
        }

        //Voids
        public void OnGetData(GetDataEventArgs args)
        {
            if (!Enable)
                return;


        }

        //Type, set, go!
        public void TSG (string type)
        {
            if(type == "Dig")
            {
                goto Dig;
            }
            else if (type == "KillMonster")
            {
                goto KM;
            }
            else
            {
                goto OHNO;
            }
        Dig:
            {
                TShock.Log.Info("Enabling Dig type");
                Dig = true;
                return;
            }
        KM:
            {
                TShock.Log.Info("Enabling KillMonster type");
                KM = true;
                return;
            }
        OHNO:
            {
                Enable = false;
                TShock.Log.Error("This '" + type + "' type is invald! Disabling!");
                Console.WriteLine("Hey what is '" + type + "'? This type is invald! I'm going off!");
                return;
            }
        }
    }
}