using System;
using System.Windows.Forms;
using System.Net;
using Newtonsoft.Json.Linq;
using System.Text;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Web.Script.Serialization;
using System.Drawing;
using System.IO;
using System.Data.SQLite;

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

        private void GetGuildButton_Click_1(object sender, EventArgs e)
        {
            string locale = "";
            if (region == "US")
            {
                locale = "en_US";
            }
            else if (region == "EU")
            {
                locale = "en_GB";
            }
            else if (region == "KR")
            {
                locale = "ko_KR";
            }
            else
            {
                locale = "zh_TW";
            }

            string guildname = GuildName.Text;
            string guildNewsApi = $"https://{region}.api.battle.net/wow/guild/{realm}/{guildname}?fields=news&locale={locale}&apikey=647cu854qwp5tyuxvv7matdz3m9fkqzb";
            string guildAchievementsApi = $"https://{region}.api.battle.net/wow/guild/{realm}/{guildname}?fields=achievements&locale={locale}&apikey=647cu854qwp5tyuxvv7matdz3m9fkqzb";
            string guildMembersApi = $"https://{region}.api.battle.net/wow/guild/{realm}/{guildname}?fields=members&locale={locale}&apikey=647cu854qwp5tyuxvv7matdz3m9fkqzb";

            if (GuildNewsCheck.Checked)
            {
                getGuildNews(guildNewsApi, guildname);
            }

            if (GuildAchievementsCheck.Checked)
            {
                getGuildAchievements(guildAchievementsApi, guildname, locale);
            }

            if (GuildMembersCheck.Checked)
            {
                getGuildMembers(guildMembersApi, guildname);
            }    
        }

        private void getGuildMembers(string api, string guildname)
        {
            dataGridView1.Rows.Clear();
            string guildMembersApi = new WebClient().DownloadString(api);
            JObject guildMembers = JObject.Parse(guildMembersApi);

            JavaScriptSerializer oJS = new JavaScriptSerializer();
            RootObject oRootObject = new RootObject();
            oRootObject = oJS.Deserialize<RootObject>(guildMembersApi);

            int i = 0;
            foreach (JToken token in guildMembers["members"])
            {
                //string specIcon = (string)guildMembers["members"][i]["character"]["spec"]["icon"];
                string characterName = (string)guildMembers["members"][i]["character"]["name"];
                int characterClass = (int)guildMembers["members"][i]["character"]["class"];
                int race = (int)guildMembers["members"][i]["character"]["race"];
                int level = (int)guildMembers["members"][i]["character"]["level"];

                string[] characterClassNames = { "", "Warrior", "Paladin", "Hunter", "Rogue", "Priest", "Death Knight", "Shaman", "Mage", "Warlock", "Monk", "Druid", "Demon Hunter" };
                string[] characterRaceName = new string[40];
                characterRaceName[1] = "Human";
                characterRaceName[2] = "Orc";
                characterRaceName[3] = "Dwarf";
                characterRaceName[4] = "Night Elf";
                characterRaceName[5] = "Undead";
                characterRaceName[6] = "Tauren";
                characterRaceName[7] = "Gnome";
                characterRaceName[8] = "Troll";
                characterRaceName[9] = "Goblin";
                characterRaceName[10] = "Blood Elf";
                characterRaceName[11] = "Draenei";
                characterRaceName[22] = "Worgen";
                characterRaceName[24] = "Pandaren";
                characterRaceName[25] = "Pandaren";
                characterRaceName[26] = "Pandaren";
                characterRaceName[27] = "Nightborne";
                characterRaceName[28] = "Highmountain Tauren";
                characterRaceName[29] = "Void Elf";
                characterRaceName[30] = "Lightforged Draenei";

                byte[] bytes = Encoding.Default.GetBytes(characterName);
                characterName = Encoding.UTF8.GetString(bytes);

                if (oRootObject.members[i].character.spec == null)
                {
                    this.dataGridView3.Rows.Add(null, characterName, characterClassNames[characterClass], characterRaceName[race], level, "N/A", "N/A"); 
                } else
                {
                    string specName = oRootObject.members[i].character.spec.name;
                    string role = oRootObject.members[i].character.spec.role;
                    string icon = oRootObject.members[i].character.spec.icon;
                    string imageUrl = $"http://wow.zamimg.com/images/wow/icons/small/{icon}.jpg";
                    this.dataGridView3.Rows.Add(GetImageFromUrl(imageUrl), characterName, characterClassNames[characterClass], characterRaceName[race], level, specName, role);
                }

                i++;
            }
        }
        
        private void getGuildAchievements(string api, string guildname, string locale)
        {
            dataGridView1.Rows.Clear();
            string guildAchievementsApi = new WebClient().DownloadString(api);
            JObject guildAchievements = JObject.Parse(guildAchievementsApi);

            int i = 0;
            foreach (JToken token in guildAchievements["achievements"]["achievementsCompleted"])
            {
                JArray achievementsCompleted = (JArray)guildAchievements["achievements"]["achievementsCompleted"];

                string guildAchievementNamesApi = new WebClient().DownloadString($"https://{region}.api.battle.net/wow/achievement/{achievementsCompleted[i]}?locale={locale}&apikey=647cu854qwp5tyuxvv7matdz3m9fkqzb");
                JObject guildAchievementNames = JObject.Parse(guildAchievementNamesApi);

                string achievementName = (string)guildAchievementNames["title"];
                string achievementDescription = (string)guildAchievementNames["description"];
                string rewards = (string)guildAchievementNames["reward"];

                //title
                byte[] bytes = Encoding.Default.GetBytes(achievementName);
                achievementName = Encoding.UTF8.GetString(bytes);

                //Description
                bytes = Encoding.Default.GetBytes(achievementDescription);
                achievementDescription = Encoding.UTF8.GetString(bytes);

                if (rewards != null)
                {
                    //Rewards
                    bytes = Encoding.Default.GetBytes(rewards);
                    rewards = Encoding.UTF8.GetString(bytes);
                }
                

                this.dataGridView2.Rows.Add(achievementsCompleted[i], achievementName, achievementDescription, rewards);

                i++;
            }
        }

        private void getGuildNews(string api, string guildname)
        {
            dataGridView1.Rows.Clear();
            string guildNewsApi = new WebClient().DownloadString(api);
            JObject guildNews = JObject.Parse(guildNewsApi);

            using (SQLiteConnection _db = new SQLiteConnection($"Data Source={Directory.GetCurrentDirectory()}\\Modular Windows\\Games\\World of Warcraft\\External Data\\wow.db;Version=3;"))
            {
                _db.Open();
                int i = 0;

                foreach (JToken token in guildNews["news"])
                {
                    string type = (string)guildNews["news"][i]["type"];
                    string character = (string)guildNews["news"][i]["character"];
                    byte[] bytes = Encoding.Default.GetBytes(character);
                    character = Encoding.UTF8.GetString(bytes);
                    
                    string context = (string)guildNews["news"][i]["context"];

                    if (type == "itemLoot")
                    {
                        type = "Looted Item";
                        long itemId = (long)guildNews["news"][i]["itemId"];
                        using (SQLiteCommand command = new SQLiteCommand($"SELECT name_enus FROM items WHERE Id={itemId}", _db))
                        {
                            using (SQLiteDataReader reader = command.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    if (context == null)
                                    {
                                        this.dataGridView1.Rows.Add(type, character, reader.GetValue(0), "N/A");
                                    }
                                    else
                                    {
                                        this.dataGridView1.Rows.Add(type, character, reader.GetValue(0), context);
                                    }
                                }
                            }
                        }
                    }
                    else if (type == "playerAchievement")
                    {
                        type = "Achievement Item";
                        if (context == null)
                        {
                            this.dataGridView1.Rows.Add(type, character, "N/A", "N/A");
                        }
                        else
                        {
                            this.dataGridView1.Rows.Add(type, character, "N/A", context);
                        }
                    }
                    else if (type == "itemPurchase")
                    {
                        type = "Purchased Item";
                        long itemId = (long)guildNews["news"][i]["itemId"];
                        using (SQLiteCommand command = new SQLiteCommand($"SELECT name_enus FROM items WHERE Id={itemId}", _db))
                        {
                            using (SQLiteDataReader reader = command.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    if (context == null)
                                    {
                                        this.dataGridView1.Rows.Add(type, character, reader.GetValue(0), "N/A");
                                    }
                                    else
                                    {
                                        this.dataGridView1.Rows.Add(type, character, reader.GetValue(0), context);
                                    }
                                }
                            }
                        }
                    }
                    i++;
                }
            }
        }

        // below method will download the image from given url
        public static Image GetImageFromUrl(string url)
        {
            HttpWebRequest httpWebRequest = (HttpWebRequest)HttpWebRequest.Create(url);

            using (HttpWebResponse httpWebReponse = (HttpWebResponse)httpWebRequest.GetResponse())
            {
                using (Stream stream = httpWebReponse.GetResponseStream())
                {
                    return Image.FromStream(stream);
                }
            }
        }

        private void GuildNewsCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (!GuildNewsCheck.Checked)
            {
                label1.Visible = false;
                dataGridView1.Visible = false;
            }
            else
            {
                label4.Visible = false;
                label1.Visible = true;
                dataGridView1.Visible = true;
            }
        }

        private void GuildAchievementsCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (!GuildAchievementsCheck.Checked)
            {
                label2.Visible = false;
                dataGridView2.Visible = false;
            }
            else
            {
                label4.Visible = false;
                label2.Visible = true;
                dataGridView2.Visible = true;
            }
        }

        private void GuildMembersCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (!GuildMembersCheck.Checked)
            {
                label3.Visible = false;
                dataGridView3.Visible = false;
            }
            else
            {
                label4.Visible = false;
                label3.Visible = true;
                dataGridView3.Visible = true;
            }
        }
    }

    public class Spec
    {
        public string name { get; set; }
        public string role { get; set; }
        public string backgroundImage { get; set; }
        public string icon { get; set; }
        public string description { get; set; }
        public int order { get; set; }
    }

    public class Character
    {
        public Spec spec { get; set; }
    }

    public class Member
    {
        public Character character { get; set; }
    }


    public class RootObject
    {
        public List<Member> members { get; set; }
    }
}
