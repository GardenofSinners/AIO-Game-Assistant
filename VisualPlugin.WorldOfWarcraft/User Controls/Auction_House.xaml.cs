using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Net;
using System.Windows;
using System.Windows.Controls;

namespace VisualPlugin.Sample1.User_Controls
{

    public partial class Auction_House : UserControl
    {

        dynamic apiKey = WorldofWarcraft.APIKey;
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

        public struct MyData
        {
            public string ItemName { set; get; }
            public string Owner { set; get; }
            public long Bid { set; get; }
            public long Buyout { set; get; }
            public int Quantity { set; get; }
            public string TimeLeft { set; get; }
        }

        public void GetAuctionData()
        {

            if (MessageBox.Show("This may take some time to download, the program will be unresponsive in the mean time. " +
                "Are you sure you want to continue?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {

                var test = System.AppDomain.CurrentDomain.BaseDirectory;
                string currentDirectory = Path.GetFullPath(Path.Combine(test, @"..\..\..\"));

                string auctionAPI = $"https://{region}.api.battle.net/wow/auction/data/{realm}?locale=en_US&apikey={apiKey}";
                var realmAuctionJson = new WebClient().DownloadString(auctionAPI);
                JObject dict = JObject.Parse(realmAuctionJson);
                var AuctionJson = new WebClient().DownloadString((string)dict["files"][0]["url"]);
                JObject dictionary = JObject.Parse(AuctionJson);
                using (SQLiteConnection _db = new SQLiteConnection($"Data Source={currentDirectory}\\VisualPlugin.Sample1\\External Data\\wow.db;Version=3;"))
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

                        using (SQLiteCommand command = new SQLiteCommand($"SELECT name_enus FROM items WHERE Id={itemID}", _db))
                        {
                            using (SQLiteDataReader reader = command.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    //dataGridView1.Items.Add(reader.GetValue(0), owner, bid, buyout, quantity, timeLeft);
                                    string str = reader[0].ToString();
                                    dataGridView1.Items.Add(new MyData { ItemName = str, Owner = owner, Bid = bid, Buyout=buyout, Quantity=quantity, TimeLeft= timeLeft });
                                }
                            }
                        }
                        i++;
                    }
                    _db.Close();
                }

            }
            else
            {
                MessageBox.Show("Operation Canceled. ", "Confirmation", MessageBoxButton.OK);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            GetAuctionData();
        }
    }

    public class Realm
    {
        public string name { get; set; }
        public string slug { get; set; }
    }

    public class BonusList
    {
        public int bonusListId { get; set; }
    }

    public class Auction
    {
        public int auc { get; set; }
        public int item { get; set; }
        public string owner { get; set; }
        public string ownerRealm { get; set; }
        public int bid { get; set; }
        public int buyout { get; set; }
        public int quantity { get; set; }
        public string timeLeft { get; set; }
        public int rand { get; set; }
        public int seed { get; set; }
        public int context { get; set; }
        public List<BonusList> bonusLists { get; set; }
    }

    public class RootObject
    {
        public List<Realm> realms { get; set; }
        public List<Auction> auctions { get; set; }
    }
}
