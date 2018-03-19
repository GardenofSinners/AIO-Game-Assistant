using System;
using System.Windows.Forms;
using System.Net;
using Newtonsoft.Json.Linq;

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

        public Guild_Profile()
        {
            InitializeComponent();
        }

        private string region;
        private string realm;
        public void Init(string WoWRegion, string WoWRealm)
        {
            region = WoWRegion;
            realm = WoWRealm;
        }

        private void GetGuildButton_Click(object sender, EventArgs e)
        {
            try
            {
                string guildname = GuildName.Text;
                string GuildUri = new WebClient().DownloadString($"https://{region}.api.battle.net/wow/guild/{realm}/{guildname}?fields=achievements%2Cchallenge&locale=en_US&apikey=647cu854qwp5tyuxvv7matdz3m9fkqzb");

                JObject data = JObject.Parse(GuildUri);

                

                richTextBox1.Text = $"Realm: {(string)data["realm"]} \nName: {(string)data["name"]}";
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
