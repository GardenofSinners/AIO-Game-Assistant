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
using System.Web.Script.Serialization;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace AIO_Game_Assistant.Modular_Windows.User_Control_Forms.Games.World_of_Warcraft
{
    public partial class Auction_House : UserControl
    {

        public dynamic jss = new JavaScriptSerializer(); //JSON Deserializer

        public Auction_House()
        {
            InitializeComponent();
            //Sets the region dropdown to US by default since it's the first in the queue.
            regionList.SelectedIndex = 0;
            getRealmList();
        }

        #region Get the Realmlist
        public void getRealmList()
        {

            if (regionList.SelectedIndex == 0)
            {
                //Grabs the data from the below string and puts it into "realmJson".
                string realmAPIURL = "https://us.api.battle.net/wow/realm/status?locale=en_US&apikey=647cu854qwp5tyuxvv7matdz3m9fkqzb";
                regionMethod(realmAPIURL);
            }
            else if (regionList.SelectedIndex == 1)
            {
                //Grabs the data from the below string and puts it into "realmJson".
                string realmAPIURL = "https://eu.api.battle.net/wow/realm/status?locale=en_US&apikey=647cu854qwp5tyuxvv7matdz3m9fkqzb";
                regionMethod(realmAPIURL);
            }
            else if (regionList.SelectedIndex == 2)
            {
                //Grabs the data from the below string and puts it into "realmJson".
                string realmAPIURL = "https://kr.api.battle.net/wow/realm/status?locale=en_US&apikey=647cu854qwp5tyuxvv7matdz3m9fkqzb";
                regionMethod(realmAPIURL);
            }
            else if (regionList.SelectedIndex == 3)
            {
                //Grabs the data from the below string and puts it into "realmJson".
                string realmAPIURL = "https://tw.api.battle.net/wow/realm/status?locale=en_US&apikey=647cu854qwp5tyuxvv7matdz3m9fkqzb";
                regionMethod(realmAPIURL);
            }
        }
        #endregion

        #region Region method to prevent duplication of code for getting the realmlists.
        public void regionMethod(string api)
        {

            string realmAPIURL = api;
            
            var realmJson = new WebClient().DownloadString(realmAPIURL);

            //A dictionary where all values for the deserialized JSON is stored
            var dict = jss.Deserialize<Dictionary<string, dynamic>>(realmJson);

            //Runs through all the values and gets the value of "Name" for each value.
            for (int i = 0; i < dict["realms"].Count; i++)
            {
                realmList.Items.Add(dict["realms"][i]["name"]); //outputs the realms
            }

        }
        #endregion

        #region On RealmList SelectedIndexChange
        private void regionList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (regionList.SelectedIndex == 0)
            {
                getRealmList();
            }
            else if (regionList.SelectedIndex == 1)
            {
                getRealmList();
            }
            else if (regionList.SelectedIndex == 2)
            {
                getRealmList();
            }
            else if (regionList.SelectedIndex == 3)
            {
                getRealmList();
            }
        }
        #endregion


        public void getAuctionData()
        {
            //string charactername = characterName.Text;
            string realm = realmList.SelectedItem.ToString();
            string region = regionList.SelectedItem.ToString();

            DialogResult result = MessageBox.Show("This may take some time to download, the program will be unresponsive in the mean time. " +
                "Are you sure you want to continue?", "Confirmation", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                
                jss.MaxJsonLength = int.MaxValue;

                string auctionAPI = "https://" + region + ".api.battle.net/wow/auction/data/" + realm + "?" + "?locale=en_US&apikey=647cu854qwp5tyuxvv7matdz3m9fkqzb";
                var realmAuctionJson = new WebClient().DownloadString(auctionAPI);
                var dict = jss.Deserialize<Dictionary<string, dynamic>>(realmAuctionJson);

                var AuctionJson = new WebClient().DownloadString(dict["files"][0]["url"]);
                var dictionary = jss.Deserialize<Dictionary<string, dynamic>>(AuctionJson);


                for (int i = 0; i < dictionary["auctions"].Count; i++)
                {
                    int itemID = dictionary["auctions"][i]["item"];
                    string owner = dictionary["auctions"][i]["owner"];
                    long bid = dictionary["auctions"][i]["bid"];
                    long buyout = dictionary["auctions"][i]["buyout"];
                    int quantity = dictionary["auctions"][i]["quantity"];
                    string timeLeft = dictionary["auctions"][i]["timeLeft"];
                    
                    this.dataGridView1.Rows.Add(itemID, owner, bid, buyout, quantity, timeLeft);
                }
            }
            else if (result == DialogResult.No)
            {
                MessageBox.Show("Operation Canceled. ", "Confirmation", MessageBoxButtons.OK);
            }
            
        }

        //public int[] WoWMoney(int m)
        //{
        //    int[] result = new int[3];
        //    int copper = m % 100;
        //    m = (m - copper) / 100;
        //    int silver = m % 100;
        //    int gold = (m - silver) / 100;
        //    result[0] = copper;
        //    result[1] = silver;
        //    result[2] = gold;
        //    return result;
        //}

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(realmList.Text))
            {
                MessageBox.Show("Realm is not selected! Go back and pick one!", "Confirmation", MessageBoxButtons.OK);
            } else
            {
                getAuctionData();
            }
            
        }


        public class Realm
        {
            public string name { get; set; }
            public string slug { get; set; }
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
        }

        public class Auctions
        {
            public List<Auction> auctions { get; set; }
        }

        public class RootObject
        {
            public Realm realm { get; set; }
            public Auctions auctions { get; set; }
        }
    }
}
