﻿using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Web.Script.Serialization;


namespace VisualPlugin.Sample1.Handler
{
    public class WoWHelper
    {
        string apiKey = WorldofWarcraft.APIKey;

        public dynamic jss = new JavaScriptSerializer(); //JSON Deserializer
        public string RealmURI;

        public static WoWHelper _instance;

        public static WoWHelper Instance {
            get {
                if (_instance == null)
                    _instance = new WoWHelper();
                return _instance;

            }
        }

        #region Get the Realmlist
        public void GetRealmList(int index)
        {

            if (index == 0)
            {
                RealmURI = $"https://us.api.battle.net/wow/realm/status?locale=en_US&apikey={apiKey}";
            }
            else if (index == 1)
            {
                RealmURI = $"https://eu.api.battle.net/wow/realm/status?locale=en_GB&apikey={apiKey}";
            }
            else if (index == 2)
            {
                RealmURI = $"https://kr.api.battle.net/wow/realm/status?locale=ko_KR&apikey={apiKey}";
            }
            else if (index == 3)
            {
                RealmURI = $"https://tw.api.battle.net/wow/realm/status?locale=zh_TW&apikey={apiKey}";
            }
        }
        #endregion

        #region Region method to prevent duplication of code for getting the realmRelists.
        public string[] RegionMethod(string api)
        {

            RealmURI = api;

            var realmJson = new WebClient().DownloadString(RealmURI);

            JObject dictionary = JObject.Parse(realmJson);
            string[] realmNames = new string[dictionary["realms"].Count()];
            int i = 0;

            foreach (JToken realm in dictionary["realms"])
            {
                string realmname = (string)dictionary["realms"][i]["name"];
                byte[] bytes = Encoding.Default.GetBytes(realmname);
                realmname = Encoding.UTF8.GetString(bytes);
                realmNames[i] = realmname;
                i++;
            }

            return realmNames;

        }
        #endregion
    }
}
