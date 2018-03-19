using System;
using System.Windows.Forms;
using System.Net;
using System.Data.SQLite;
using Newtonsoft.Json.Linq;
using System.IO;

namespace AIO_Game_Assistant.Modular_Windows.User_Control_Forms.Games.World_of_Warcraft
{
    public partial class Auction_House : UserControl
    {

        private static Auction_House _instance;

        public static Auction_House Instance {
            get {
                if (_instance == null)
                    _instance = new Auction_House();
                return _instance;

            }
        }

        public Auction_House()
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

        public void GetAuctionData()
        {

            DialogResult result = MessageBox.Show("This may take some time to download, the program will be unresponsive in the mean time. " +
                "Are you sure you want to continue?", "Confirmation", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                string auctionAPI = $"https://{region}.api.battle.net/wow/auction/data/{realm}?locale=en_US&apikey=647cu854qwp5tyuxvv7matdz3m9fkqzb";
                var realmAuctionJson = new WebClient().DownloadString(auctionAPI);
                JObject dict = JObject.Parse(realmAuctionJson);
                var AuctionJson = new WebClient().DownloadString((string)dict["files"][0]["url"]);
                JObject dictionary = JObject.Parse(AuctionJson);
                using (SQLiteConnection _db = new SQLiteConnection($"Data Source={Directory.GetCurrentDirectory()}\\Modular Windows\\Games\\World of Warcraft\\External Data\\wow.db;Version=3;"))
                {
                    _db.Open();
                    int i = 0;
                    foreach (JToken token in dictionary["auctions"])
                    {
                        int itemID = (int)dictionary["auctions"][i]["item"];
                        string owner = (string)dictionary["auctions"][i]["owner"];
                        long bid = (long)dictionary["auctions"][i]["bid"];
                        long buyout = (long)dictionary["auctions"][i]["buyout"];
                        int quantity = (int)dictionary["auctions"][i]["quantity"];
                        string timeLeft = (string)dictionary["auctions"][i]["timeLeft"];

                        using(SQLiteCommand command = new SQLiteCommand($"SELECT name_enus FROM items WHERE Id={itemID}", _db))
                        {
                            using (SQLiteDataReader reader = command.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    dataGridView1.Rows.Add(reader.GetValue(0), owner, bid, buyout, quantity, timeLeft);
                                }
                            }
                        }

                        Console.WriteLine(i);
                        i++;
                    }
                    _db.Close();
                }
                
            }
            else if (result == DialogResult.No)
            {
                MessageBox.Show("Operation Canceled. ", "Confirmation", MessageBoxButtons.OK);
            }
        }

        private void SearchAHButton_Click(object sender, EventArgs e)
        {
            GetAuctionData();
        }
    }
}
