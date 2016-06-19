using System;
using System.Collections.Generic;
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
        Config.Load cLoad = new Config.Load();
        private string path = TShock.SavePath;
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
            cLoad.ConfigLoad(path);
            TrueConfigLoad(path);
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
        private void TrueConfigLoad (string path)
        {
            // Loading to changes (Zmiennych)

        }
    }
}
