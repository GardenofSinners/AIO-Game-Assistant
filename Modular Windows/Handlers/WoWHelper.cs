using AIO_Game_Assistant.Modular_Windows.Games.World_of_Warcraft;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace AIO_Game_Assistant.Modular_Windows.Options
{
    public class WoWHelper
    {
        public dynamic jss = new JavaScriptSerializer(); //JSON Deserializer
        WorldofWarcraft WoW { get; }
        public string RealmURI { get; private set; } = "test";

        #region Get the Realmlist
        public Task GetRealmList()
        {
            
            if (WoW.RegionList.SelectedIndex == 0)
            {
                RealmURI = "https://us.api.battle.net/wow/realm/status?locale=en_US&apikey=647cu854qwp5tyuxvv7matdz3m9fkqzb";
                RegionMethod(RealmURI);
            }
            else if (WoW.RegionList.SelectedIndex == 1)
            {
                RealmURI = "https://eu.api.battle.net/wow/realm/status?locale=en_US&apikey=647cu854qwp5tyuxvv7matdz3m9fkqzb";
                RegionMethod(RealmURI);
            }
            else if (WoW.RegionList.SelectedIndex == 2)
            {
                RealmURI = "https://kr.api.battle.net/wow/realm/status?locale=en_US&apikey=647cu854qwp5tyuxvv7matdz3m9fkqzb";
                RegionMethod(RealmURI);
            }
            else if (WoW.RegionList.SelectedIndex == 3)
            {
                RealmURI = "https://tw.api.battle.net/wow/realm/status?locale=en_US&apikey=647cu854qwp5tyuxvv7matdz3m9fkqzb";
                RegionMethod(RealmURI);
            }
            Console.WriteLine(RealmURI);
            return Task.CompletedTask;
        }
        #endregion

        #region Region method to prevent duplication of code for getting the realmlists.
        public string[] RegionMethod(string api)
        {

            RealmURI = api;

            var realmJson = new WebClient().DownloadString(RealmURI);

            //A dictionary where all values for the deserialized JSON is stored
            var dict = jss.Deserialize<Dictionary<string, dynamic>>(realmJson);
            string[] realmNames = new string[dict["realms"].Count];

            //Runs through all the values and gets the value of "Name" for each value.
            for (int i = 0; i < dict["realms"].Count; i++)
            {
                //RealmList.Items.Add(dict["realms"][i]["name"]); //outputs the realms
                realmNames[i] = dict["realms"][i]["name"];
            }

            return realmNames;
        }
        #endregion
    }
}
