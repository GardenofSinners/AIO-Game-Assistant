using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Web.Script.Serialization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace VisualPlugin.Sample1.User_Controls
{

    public partial class Realm_Status : UserControl
    {
        dynamic apiKey = WorldofWarcraft.APIKey;

        public dynamic jss = new JavaScriptSerializer();
        private static Realm_Status _instance;

        public static Realm_Status Instance {
            get {
                if (_instance == null)
                    _instance = new Realm_Status();
                return _instance;

            }
        }

        public Realm_Status()
        {
            InitializeComponent();
        }

        public void GetRealms(string region)
        {
            //Grabs the data from the below string and puts it into "realmJson".
            string realmAPIURL = region;
            GetInformation(realmAPIURL);
        }

        public struct MyData
        {
            public BitmapImage Avalibility { get; set; }
            public string RealmName { set; get; }
            public string RealmType { set; get; }
            public string RealmPopulation { set; get; }
            public string RealmTimezone { set; get; }
            public string Locale { set; get; }
        }

        public void GetInformation(string realmAPIURL)
        {

            var realmJson = new WebClient().DownloadString(realmAPIURL);
            var realmStatus = jss.Deserialize<Dictionary<string, dynamic>>(realmJson);

            var test = System.AppDomain.CurrentDomain.BaseDirectory;
            string currentDirectory = System.IO.Path.GetFullPath(System.IO.Path.Combine(test, @"..\..\..\"));

            BitmapImage avaliable = new BitmapImage(new Uri($"{currentDirectory}//VisualPlugin.Sample1//External Data//Images//checkCircleGreen.png", UriKind.RelativeOrAbsolute));
            BitmapImage unavaliable = new BitmapImage(new Uri($"{currentDirectory}//VisualPlugin.Sample1//External Data//Images//xCircleRed.png", UriKind.RelativeOrAbsolute));


            //Runs through all the values and gets the value of "Name" for each value.
            for (int i = 0; i < realmStatus["realms"].Count; i++)
            {
                string realmName = realmStatus["realms"][i]["name"];
                string realmType = realmStatus["realms"][i]["type"];
                string realmPopulation = realmStatus["realms"][i]["population"];
                string realmTimezone = realmStatus["realms"][i]["timezone"];
                string locale = realmStatus["realms"][i]["locale"];


                string[] words = realmTimezone.Split('/');
                string[] locales = { "en_GB", "en_US", "pt_BR", "es_MX", "de_DE", "pt_PT", "fr_FR", "ru_RU", "es_ES", "it_IT", "ko_KR", "zh_TW" };

                byte[] bytes = Encoding.Default.GetBytes(realmName);
                realmName = Encoding.UTF8.GetString(bytes);
                bytes = Encoding.Default.GetBytes(realmPopulation);
                realmPopulation = Encoding.UTF8.GetString(bytes);
                bytes = Encoding.Default.GetBytes(locale);
                locale = Encoding.UTF8.GetString(bytes);

                //Removes the America/Europe bit before the location eg Europe/Paris, America/New_York
                if (locale == locales[1] || locale == locales[3])
                {
                    realmTimezone = words[1];
                }
                else if (locale == locales[10])
                {
                    realmTimezone = "KST";
                }
                else if (locale == locales[11])
                {
                    realmTimezone = "CST";
                }
                else
                {
                    realmTimezone = words[1];
                }

                //replaces things like en_gb, en_US with proper names eg United Kingdom / United States

                if (locale == locales[0])
                {
                    locale = "United Kingdom";
                }
                else if (locale == locales[1])
                {
                    locale = "United States";
                }
                else if (locale == locales[2])
                {
                    locale = "Brazil";

                }
                else if (locale == locales[3])
                {
                    locale = "Mexico";
                }
                else if (locale == locales[4])
                {
                    locale = "Germany";
                }
                else if (locale == locales[5])
                {
                    locale = "Portugal";
                }
                else if (locale == locales[6])
                {
                    locale = "France";
                }
                else if (locale == locales[7])
                {
                    locale = "Russia";
                }
                else if (locale == locales[8])
                {
                    locale = "Spain";
                }
                else if (locale == locales[9])
                {
                    locale = "Italy";
                }
                else if (locale == locales[10])
                {
                    locale = "대한민국";
                }
                else if (locale == locales[11])
                {
                    locale = "台灣";
                }

                if (realmStatus["realms"][i]["status"] == true)
                {
                    //this.dataGridView1.Rows.Add(avaliable, realmName, realmType, realmPopulation, realmTimzezone, locale);
                    dataGridView1.Items.Add(new MyData { Avalibility = avaliable, RealmName = realmName, RealmType = realmType, RealmPopulation = realmPopulation, RealmTimezone = realmTimezone, Locale = locale });
                }
                else
                {
                    //this.dataGridView1.Rows.Add(unavaliable, realmName, realmType, realmPopulation, realmTimzezone, locale);
                    dataGridView1.Items.Add(new MyData { Avalibility = unavaliable, RealmName = realmName, RealmType = realmType, RealmPopulation = realmPopulation, RealmTimezone = realmTimezone, Locale = locale });
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            dataGridView1.Items.Clear();
            GetRealms($"https://us.api.battle.net/wow/realm/status?locale=en_GB&apikey={apiKey}");
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            dataGridView1.Items.Clear();
            GetRealms($"https://eu.api.battle.net/wow/realm/status?locale=en_US&apikey={apiKey}");
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            dataGridView1.Items.Clear();
            GetRealms($"https://kr.api.battle.net/wow/realm/status?locale=ko_KR&apikey={apiKey}");
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            dataGridView1.Items.Clear();
            GetRealms($"https://tw.api.battle.net/wow/realm/status?locale=zh_TW&apikey={apiKey}");
        }
    }
}
