using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Web.Script.Serialization;
using System.Net;

namespace AIO_Game_Assistant.Modular_Windows.User_Control_Forms.Games.World_of_Warcraft
{
    public partial class Realm_Status : UserControl
    {
        public dynamic jss = new JavaScriptSerializer(); //JSON Deserializer

        public Realm_Status()
        {
            InitializeComponent();
            foreach (DataGridViewColumn col in dataGridView1.Columns)
            {
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                col.HeaderCell.Style.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Pixel);
            }
            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                if (dataGridView1.Columns[i] is DataGridViewImageColumn)
                {
                    ((DataGridViewImageColumn)dataGridView1.Columns[i]).ImageLayout = DataGridViewImageCellLayout.Zoom;
                    break;
                }
            }
            dataGridView1.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        public void getRealms(string region)
        {
            //Grabs the data from the below string and puts it into "realmJson".
            string realmAPIURL = region;
            getInformation(realmAPIURL);
        }

        public void getInformation(string realmAPIURL)
        {

            var realmJson = new WebClient().DownloadString(realmAPIURL);
            var realmStatus = jss.Deserialize<Dictionary<string, dynamic>>(realmJson);

            Bitmap avaliable = new Bitmap(Properties.Resources.checkCircleGreen);
            Bitmap unavaliable = new Bitmap(Properties.Resources.xCircleRed);


            //Runs through all the values and gets the value of "Name" for each value.
            for (int i = 0; i < realmStatus["realms"].Count; i++)
            {
                string realmName       = realmStatus["realms"][i]["name"];
                string realmType       = realmStatus["realms"][i]["type"];
                string realmPopulation = realmStatus["realms"][i]["population"];
                string realmTimzezone  = realmStatus["realms"][i]["timezone"];
                string locale          = realmStatus["realms"][i]["locale"];

                string[] words = realmTimzezone.Split('/');
                string[] locales = { "en_GB", "en_US", "pt_BR", "es_MX", "de_DE", "pt_PT", "fr_FR", "ru_RU", "es_ES", "it_IT" };

                
                //Removes the America/Europe bit before the location eg Europe/Paris, America/New_York
                if (locale == locales[1] || locale == locales[3])
                {
                    realmTimzezone = words[1];

                } else {
                    realmTimzezone = words[1];
                }

                //replaces things like en_gb, en_US with proper names eg United Kingdom / United States

                if (locale == locales[0])
                {
                    locale = "United Kingdom";
                } else if (locale == locales[1])
                {
                    locale = "United States";
                } else if (locale == locales[2])
                {
                    locale = "Brazil";

                } else if (locale == locales[3])
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

                if (realmStatus["realms"][i]["status"] == true)
                {
                    this.dataGridView1.Rows.Add(avaliable, realmName, realmType, realmPopulation, realmTimzezone, locale);
                } else
                {
                    this.dataGridView1.Rows.Add(unavaliable, realmName, realmType, realmPopulation, realmTimzezone, locale);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            getRealms("https://eu.api.battle.net/wow/realm/status?locale=en_US&apikey=647cu854qwp5tyuxvv7matdz3m9fkqzb");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            getRealms("https://us.api.battle.net/wow/realm/status?locale=en_US&apikey=647cu854qwp5tyuxvv7matdz3m9fkqzb");
        }
    }
}
