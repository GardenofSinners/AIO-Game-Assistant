using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Net;
using System.Text;
using System.Web.Script.Serialization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace VisualPlugin.Sample1.User_Controls
{

    public partial class Guild_Profile : UserControl
    {

        string apiKey = WorldofWarcraft.APIKey;

        private static Guild_Profile _instance;

        public static Guild_Profile Instance {
            get {
                if (_instance == null)
                    _instance = new Guild_Profile();
                return _instance;

            }
        }

        public struct GuildNewsData
        {
            public string ItemObtainedFrom { get; set; }
            public string CharacterNameGuild { set; get; }
            public string ItemName { set; get; }
            public string DroppedFrom { set; get; }
        }

        public struct GuildAchievementsData
        {
            public string AchievementID { get; set; }
            public string AchievementName { set; get; }
            public string AchievementDescription { set; get; }
            public string AchievementReward { set; get; }
        }

        public struct GuildMemberData
        {
            public BitmapImage CharacterSpecImage { get; set; }
            public string CharacterName { set; get; }
            public string CharacterClass { set; get; }
            public string CharacterRace { set; get; }
            public int    CharacterLevel { get; set; }
            public string CharacterSpec { set; get; }
            public string CharacterRole { set; get; }
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

        private void GetGuildButton_Click(object sender, RoutedEventArgs e)
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
            string guildNewsApi = $"https://{region}.api.battle.net/wow/guild/{realm}/{guildname}?fields=news&locale={locale}&apikey={apiKey}";
            string guildAchievementsApi = $"https://{region}.api.battle.net/wow/guild/{realm}/{guildname}?fields=achievements&locale={locale}&apikey={apiKey}";
            string guildMembersApi = $"https://{region}.api.battle.net/wow/guild/{realm}/{guildname}?fields=members&locale={locale}&apikey={apiKey}";

            if (GuildNewsCheck.IsChecked == true)
            {
                getGuildNews(guildNewsApi, guildname);
            }

            if (GuildAchievementsCheck.IsChecked == true)
            {
                getGuildAchievements(guildAchievementsApi, guildname, locale);
            }

            if (GuildMembersCheck.IsChecked == true)
            {
                getGuildMembers(guildMembersApi, guildname);
            }
        }

        private void getGuildMembers(string api, string guildname)
        {
            dataGridView3.Items.Clear();
            dataGridView3.Items.Refresh();
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
                    //this.dataGridView3.Rows.Add(null, characterName, characterClassNames[characterClass], characterRaceName[race], level, "N/A", "N/A");
                    dataGridView3.Items.Add(new GuildMemberData { CharacterSpecImage = null, CharacterName = characterName, CharacterClass = characterClassNames[characterClass], CharacterRace = characterRaceName[race], CharacterLevel = level, CharacterSpec = "N/A", CharacterRole = "N/A" });
                }
                else
                {
                    string specName = oRootObject.members[i].character.spec.name;
                    string role = oRootObject.members[i].character.spec.role;
                    string icon = oRootObject.members[i].character.spec.icon;
                    string imageUrl = $"http://wow.zamimg.com/images/wow/icons/small/{icon}.jpg";
                    BitmapImage specImageURL = new BitmapImage(new Uri(imageUrl, UriKind.RelativeOrAbsolute));
                    dataGridView3.Items.Add(new GuildMemberData { CharacterSpecImage = specImageURL, CharacterName = characterName, CharacterClass = characterClassNames[characterClass], CharacterRace = characterRaceName[race], CharacterLevel = level, CharacterSpec = specName, CharacterRole = role});
                    }

                i++;
            }
        }

        private void getGuildAchievements(string api, string guildname, string locale)
        {
            dataGridView2.Items.Clear();
            dataGridView2.Items.Refresh();
            string guildAchievementsApi = new WebClient().DownloadString(api);
            JObject guildAchievements = JObject.Parse(guildAchievementsApi);

            int i = 0;
            foreach (JToken token in guildAchievements["achievements"]["achievementsCompleted"])
            {
                JArray achievementsCompleted = (JArray)guildAchievements["achievements"]["achievementsCompleted"];

                string guildAchievementNamesApi = new WebClient().DownloadString($"https://{region}.api.battle.net/wow/achievement/{achievementsCompleted[i]}?locale={locale}&apikey={apiKey}");
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
                
                dataGridView2.Items.Add(new GuildAchievementsData { AchievementID = achievementsCompleted[i].ToString(), AchievementName = achievementName, AchievementDescription = achievementDescription, AchievementReward = rewards });
                i++;
            }
        }


        private void getGuildNews(string api, string guildname)
        {
            dataGridView1.Items.Clear();
            dataGridView1.Items.Refresh();
            var test = System.AppDomain.CurrentDomain.BaseDirectory;
            string currentDirectory = Path.GetFullPath(Path.Combine(test, @"..\..\..\"));

            dataGridView1.Items.Clear();
            string guildNewsApi = new WebClient().DownloadString(api);
            JObject guildNews = JObject.Parse(guildNewsApi);

            int i = 0;

            using (SQLiteConnection _db = new SQLiteConnection($"Data Source={currentDirectory}\\VisualPlugin.Sample1\\External Data\\wow.db;Version=3;"))
            {
                _db.Open();

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
                                        dataGridView1.Items.Add(new GuildNewsData { ItemObtainedFrom = type, CharacterNameGuild = character, ItemName = reader.GetValue(0).ToString(), DroppedFrom = "N/A" });
                                    }
                                    else
                                    {
                                        dataGridView1.Items.Add(new GuildNewsData { ItemObtainedFrom = type, CharacterNameGuild = character, ItemName = reader.GetValue(0).ToString(), DroppedFrom = context });
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
                            dataGridView1.Items.Add(new GuildNewsData { ItemObtainedFrom = type, CharacterNameGuild = character, ItemName = "N/A", DroppedFrom = "N/A" });

                        }
                        else
                        {
                            dataGridView1.Items.Add(new GuildNewsData { ItemObtainedFrom = type, CharacterNameGuild = character, ItemName = "N/A", DroppedFrom = context });
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
                                        dataGridView1.Items.Add(new GuildNewsData { ItemObtainedFrom = type, CharacterNameGuild = character, ItemName = reader.GetValue(0).ToString(), DroppedFrom = "N/A" });
                                    }
                                    else
                                    {
                                        dataGridView1.Items.Add(new GuildNewsData { ItemObtainedFrom = type, CharacterNameGuild = character, ItemName = reader.GetValue(0).ToString(), DroppedFrom = context });
                                    }
                                }
                            }
                        }
                    }

                    i++;
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
}
