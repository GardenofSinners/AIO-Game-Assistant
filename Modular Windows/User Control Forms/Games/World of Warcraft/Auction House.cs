﻿using System;
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
            RegionList.SelectedIndex = 0;
            GetRealmList();
        }

        #region Get the Realmlist
        public void GetRealmList()
        {
            if (RegionList.SelectedIndex == 0)
            {
                //Grabs the data from the below string and puts it into "realmJson".
                string realmAPIURL = "https://us.api.battle.net/wow/realm/status?locale=en_US&apikey=647cu854qwp5tyuxvv7matdz3m9fkqzb";
                RegionMethod(realmAPIURL);
            }
            else if (RegionList.SelectedIndex == 1)
            {
                //Grabs the data from the below string and puts it into "realmJson".
                string realmAPIURL = "https://eu.api.battle.net/wow/realm/status?locale=en_US&apikey=647cu854qwp5tyuxvv7matdz3m9fkqzb";
                RegionMethod(realmAPIURL);
            }
            else if (RegionList.SelectedIndex == 2)
            {
                //Grabs the data from the below string and puts it into "realmJson".
                string realmAPIURL = "https://kr.api.battle.net/wow/realm/status?locale=en_US&apikey=647cu854qwp5tyuxvv7matdz3m9fkqzb";
                RegionMethod(realmAPIURL);
            }
            else if (RegionList.SelectedIndex == 3)
            {
                //Grabs the data from the below string and puts it into "realmJson".
                string realmAPIURL = "https://tw.api.battle.net/wow/realm/status?locale=en_US&apikey=647cu854qwp5tyuxvv7matdz3m9fkqzb";
                RegionMethod(realmAPIURL);
            }
        }
        #endregion

        #region Region method to prevent duplication of code for getting the realmlists.
        public void RegionMethod(string api)
        {

            string realmAPIURL = api;
            
            var realmJson = new WebClient().DownloadString(realmAPIURL);

            //A dictionary where all values for the deserialized JSON is stored
            var dict = jss.Deserialize<Dictionary<string, dynamic>>(realmJson);

            //Runs through all the values and gets the value of "Name" for each value.
            for (int i = 0; i < dict["realms"].Count; i++)
            {
                RealmList.Items.Add(dict["realms"][i]["name"]); //outputs the realms
            }

        }
        #endregion

        #region On RealmList SelectedIndexChange
        private void RegionList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (RegionList.SelectedIndex == 0)
            {
                GetRealmList();
            }
            else if (RegionList.SelectedIndex == 1)
            {
                GetRealmList();
            }
            else if (RegionList.SelectedIndex == 2)
            {
                GetRealmList();
            }
            else if (RegionList.SelectedIndex == 3)
            {
                GetRealmList();
            }
        }
        #endregion


        public void GetAuctionData()
        {
            //string charactername = characterName.Text;
            string realm = RealmList.SelectedItem.ToString();
            string region = RegionList.SelectedItem.ToString();

            DialogResult result = MessageBox.Show("This may take some time to download, the program will be unresponsive in the mean time. " +
                "Are you sure you want to continue?", "Confirmation", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                
                jss.MaxJsonLength = int.MaxValue;

                string auctionAPI = $"https://{region}.api.battle.net/wow/auction/data/{realm}?locale=en_US&apikey=647cu854qwp5tyuxvv7matdz3m9fkqzb";
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

        private void SearchAHButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(RealmList.Text))
            {
                MessageBox.Show("Realm is not selected! Go back and pick one!", "Confirmation", MessageBoxButtons.OK);
            } else
            {
                GetAuctionData();
            }
            
        }


        public class Realm
        {
            public string Name { get; set; }
            public string Slug { get; set; }
        }

        public class Auction
        {
            public int Auc { get; set; }
            public int Item { get; set; }
            public string Owner { get; set; }
            public string OwnerRealm { get; set; }
            public int Bid { get; set; }
            public int Buyout { get; set; }
            public int Quantity { get; set; }
            public string TimeLeft { get; set; }
            public int Rand { get; set; }
            public int Seed { get; set; }
            public int Context { get; set; }
        }

        public class Auctions
        {
            public List<Auction> AuctionsList { get; set; }
        }

        public class RootObject
        {
            public Realm Realm { get; set; }
            public Auctions Auctions { get; set; }
        }
    }
}
