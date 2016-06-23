using System;
using System.Collections.Generic;
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
        Config conf = new Config();
        //Config.JSON.config confff = new Config.JSON.config();
        //Config.Load cLoad = new Config.Load();
        // Private
        private string path = Path.Combine(TShock.SavePath, "MoreAchievements.json");
        private bool itisON;
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

            //TrueConfigLoad(path);
            //Hooks

        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //UnHooks
                
            }
            base.Dispose(disposing);
        }
       /* private void TrueConfigLoad (string path)
        {
            // Loading to changes (Zmiennych)

        }*/
    }
}
