using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using AIO_Game_Assistant.Modular_Windows.Options;

namespace AIO_Game_Assistant.Modular_Windows.User_Control_Forms.Games.World_of_Warcraft
{
    public partial class Guild_Profile : UserControl
    {

        private static Guild_Profile _instance;

        public static Guild_Profile Instance {
            get {
                if (_instance == null)
                    _instance = new Guild_Profile();
                return _instance;

            }
        }

        WoWHelper _WoWHelper { get; }

        public Guild_Profile()
        {
            InitializeComponent();
            GuildRegionList.SelectedIndex = 0;
        }

        private void GetGuildButton_Click(object sender, EventArgs e)
        {
            try
            {
                string realm = GuildRealmList.Text;
                string guildname = GuildName.Text;
                string region = GuildRegionList.Text;
                //string GuildUri = new WebClient().DownloadString($"https://{region}.api.battle.net/wow/guild/{realm}/{guildname}?fields=achievements%2Cchallenge&locale=en_US&apikey=647cu854qwp5tyuxvv7matdz3m9fkqzb");

                _WoWHelper.GetRealmList();
                richTextBox1.Text = _WoWHelper.RealmURI;
            }
            catch(WebException)
            {
                MessageBox.Show($"Guild \"{GuildName}\" not found.");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                richTextBox1.Text = ex.ToString();

            }
        }
    }
}
