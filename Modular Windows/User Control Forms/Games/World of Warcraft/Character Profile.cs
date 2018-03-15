using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Net;
using System.Web.Script.Serialization;
using System.Threading.Tasks;

namespace AIO_Game_Assistant.Modular_Windows.User_Control_Forms.Games.World_of_Warcraft
{
    public partial class Character_Profile : UserControl
    {
        public dynamic jss = new JavaScriptSerializer(); //JSON Deserializer

        public Character_Profile()
        {
            InitializeComponent();
            //Sets the region dropdown to US by default since it's the first in the queue.
            regionList.SelectedIndex = 0;
            Task.Run(GetRealmList);
        }

        #region Get the Realmlist
        public Task GetRealmList()
        {

            if (regionList.SelectedIndex == 0)
            {
                //Grabs the data from the below string and puts it into "realmJson".
                string realmAPIURL = "https://us.api.battle.net/wow/realm/status?locale=en_US&apikey=647cu854qwp5tyuxvv7matdz3m9fkqzb";
                RegionMethod(realmAPIURL);
            }
            else if (regionList.SelectedIndex == 1)
            {
                //Grabs the data from the below string and puts it into "realmJson".
                string realmAPIURL = "https://eu.api.battle.net/wow/realm/status?locale=en_US&apikey=647cu854qwp5tyuxvv7matdz3m9fkqzb";
                RegionMethod(realmAPIURL);
            }
            else if (regionList.SelectedIndex == 2)
            {
                //Grabs the data from the below string and puts it into "realmJson".
                string realmAPIURL = "https://kr.api.battle.net/wow/realm/status?locale=en_US&apikey=647cu854qwp5tyuxvv7matdz3m9fkqzb";
                RegionMethod(realmAPIURL);
            }
            else if (regionList.SelectedIndex == 3)
            {
                //Grabs the data from the below string and puts it into "realmJson".
                string realmAPIURL = "https://tw.api.battle.net/wow/realm/status?locale=en_US&apikey=647cu854qwp5tyuxvv7matdz3m9fkqzb";
                RegionMethod(realmAPIURL);
            }

            return Task.CompletedTask;
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
                realmList.Items.Add(dict["realms"][i]["name"]); //outputs the realms
            }

        }
        #endregion

        #region On RealmList SelectedIndexChange
        private void RegionList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (regionList.SelectedIndex == 0)
            {
                GetRealmList();
            }
            else if (regionList.SelectedIndex == 1)
            {
                GetRealmList();
            }
            else if (regionList.SelectedIndex == 2)
            {
                GetRealmList();
            }
            else if (regionList.SelectedIndex == 3)
            {
                GetRealmList();
            }
        }
        #endregion

        #region Get User Gear, Appearance, Race etc.
        private void SearchCharacterButton_Click(object sender, EventArgs e)
        {
            string charactername = characterName.Text;
            string realm = realmList.SelectedItem.ToString();
            string region = regionList.SelectedItem.ToString();

            string characterAPI = "https://" + region + ".api.battle.net/wow/character/" + realm + "/" + charactername + "?locale=en_US&apikey=647cu854qwp5tyuxvv7matdz3m9fkqzb";
            
            try
            {
                string characterJson = new WebClient().DownloadString(characterAPI);

                //A dictionary where all values for the deserialized JSON is stored
                var dict = jss.Deserialize<Dictionary<string, dynamic>>(characterJson);

                string thumbnailUrl = dict["thumbnail"];

                thumbnailUrl = thumbnailUrl.Substring(0, thumbnailUrl.Length - 10); //prints out {id}/{generatedImageID}-

                thumbnailUrl = "http://render-" + region + ".worldofwarcraft.com/character/" + thumbnailUrl + "profilemain.jpg";

                pictureBox1.Load(thumbnailUrl);
                UserAppearanceandGear();
            }
            catch(WebException)
            {
                MessageBox.Show($"Unable to find character \"{charactername}\"");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }

        }

        public void UserAppearanceandGear()
        {

            //icons are displayed in a 56x56 format
            string charactername = characterName.Text;
            string realm = realmList.SelectedItem.ToString();
            string region = regionList.SelectedItem.ToString();
            string gearAPI = $"https://{region}.api.battle.net/wow/character/{realm}/{charactername}?fields=items&locale=en_US&apikey=647cu854qwp5tyuxvv7matdz3m9fkqzb";

            var gearJson = new WebClient().DownloadString(gearAPI);

            //A dictionary where all values for the deserialized JSON is stored
            var dict = jss.Deserialize<Dictionary<string, dynamic>>(gearJson);

            WebClient webClient = new WebClient();

            if (gearJson.Contains("head"))
            {
                string headslot = dict["items"]["head"]["icon"];
                headSlot.Load($"http://wow.zamimg.com/images/wow/icons/large/{headslot}.jpg");
                headName.Text = dict["items"]["head"]["name"];
                Console.WriteLine("Head: Downloaded");

            }
            else
            {
                Console.WriteLine("Head: Item not found");
            }

            if (gearJson.Contains("neck"))
            {
                string neckslot = dict["items"]["neck"]["icon"];
                neckName.Text = dict["items"]["neck"]["name"];
                neckSlot.Load($"http://wow.zamimg.com/images/wow/icons/large/{neckslot}.jpg");
                Console.WriteLine("Neck: Downloaded");
            }
            else
            {
                Console.WriteLine("Neck: Item not found");
            }

            if (gearJson.Contains("shoulder"))
            {
                string shoulderslot = dict["items"]["shoulder"]["icon"];
                shoulderName.Text = dict["items"]["shoulder"]["name"];
                shoulderSlot.Load($"http://wow.zamimg.com/images/wow/icons/large/{shoulderslot}.jpg");
                Console.WriteLine("Shoulder: Downloaded");
            }
            else
            {
                shoulderSlot.Image = Properties.Resources.Shoulders;
                Console.WriteLine("Shoulder: Item not found");
            }

            if (gearJson.Contains("back"))
            {
                string cloakslot = dict["items"]["back"]["icon"];
                cloakName.Text = dict["items"]["back"]["name"];
                cloakSlot.Load($"http://wow.zamimg.com/images/wow/icons/large/{cloakslot}.jpg");
                Console.WriteLine("Cloak: Downloaded");
            }
            else
            {
                cloakSlot.Image = Properties.Resources.Back;
                Console.WriteLine("Cloak: Item not found");
            }

            if (gearJson.Contains("chest"))
            {
                string chestslot = dict["items"]["chest"]["icon"];
                chestName.Text = dict["items"]["chest"]["name"];
                chestSlot.Load($"http://wow.zamimg.com/images/wow/icons/large/{chestslot}.jpg");
                Console.WriteLine("Chest: Downloaded");
            }
            else
            {
                chestSlot.Image = Properties.Resources.Chest;
                Console.WriteLine("Chest: Item not found");
            }

            if (gearJson.Contains("shirt"))
            {
                string shirtslot = dict["items"]["shirt"]["icon"];
                shirtName.Text = dict["items"]["shirt"]["name"];
                shirtSlot.Load($"http://wow.zamimg.com/images/wow/icons/large/{shirtslot}.jpg");
                Console.WriteLine("Shirt: Downloaded");
            }
            else
            {
                shirtSlot.Image = Properties.Resources.shirt;
                Console.WriteLine("Shirt: Item not found");
            }

            if (gearJson.Contains("tabard"))
            {
                string tabardslot = dict["items"]["tabard"]["icon"];
                tabardName.Text = dict["items"]["tabard"]["name"];
                tabardSlot.Load($"http://wow.zamimg.com/images/wow/icons/large/{tabardslot}.jpg");
                Console.WriteLine("Tabard: Downloaded");
            }
            else
            {
                tabardSlot.Image = Properties.Resources.tabard;
                Console.WriteLine("Tabard: Item not found");
            }

            if (gearJson.Contains("wrist"))
            {
                string wristslot = dict["items"]["wrist"]["icon"];
                wristName.Text = dict["items"]["wrist"]["name"];
                wristSlot.Load($"http://wow.zamimg.com/images/wow/icons/large/{wristslot}.jpg");
                Console.WriteLine("Wrist: Downloaded");
            }
            else
            {
                wristSlot.Image = Properties.Resources.Wrist;
                Console.WriteLine("Wrist: Item not found");
            }

            if (gearJson.Contains("hands"))
            {
                string handsslot = dict["items"]["hands"]["icon"];
                handsName.Text = dict["items"]["hands"]["name"];
                handsSlot.Load($"http://wow.zamimg.com/images/wow/icons/large/{handsslot}.jpg");
                Console.WriteLine("Hands: Downloaded");
            }
            else
            {
                handsSlot.Image = Properties.Resources.gloves;
                Console.WriteLine("Hands: Item not found");
            }

            if (gearJson.Contains("waist"))
            {
                string waistslot = dict["items"]["waist"]["icon"];
                waistName.Text = dict["items"]["waist"]["name"];
                waistSlot.Load($"http://wow.zamimg.com/images/wow/icons/large/{waistslot}.jpg");
                Console.WriteLine("Waist: Downloaded");
            }
            else
            {
                waistSlot.Image = Properties.Resources.Waist;
                Console.WriteLine("Waist: Item not found");
            }

            if (gearJson.Contains("legs"))
            {
                string legsslot = dict["items"]["legs"]["icon"];
                legName.Text = dict["items"]["legs"]["name"];
                legsSlot.Load($"http://wow.zamimg.com/images/wow/icons/large/{legsslot}.jpg");
                Console.WriteLine("Legs: Downloaded");
            }
            else
            {
                legsSlot.Image = Properties.Resources.Pants;
                Console.WriteLine("Legs: Item not found");
            }

            if (gearJson.Contains("feet"))
            {
                string feetslot = dict["items"]["feet"]["icon"];
                feetName.Text = dict["items"]["feet"]["name"];
                feetSlot.Load($"http://wow.zamimg.com/images/wow/icons/large/{feetslot}.jpg");
                Console.WriteLine("Feet: Downloaded");
            }
            else
            {
                feetSlot.Image = Properties.Resources.Feet;
                Console.WriteLine("Feet: Item not found");
            }

            if (gearJson.Contains("finger1"))
            {
                string ring1slot = dict["items"]["finger1"]["icon"];
                ring1Name.Text = dict["items"]["finger1"]["name"];
                ring1Slot.Load($"http://wow.zamimg.com/images/wow/icons/large/{ring1slot}.jpg");
                Console.WriteLine("Ring 1: Downloaded");
            }
            else
            {
                ring1Slot.Image = Properties.Resources.ring;
                Console.WriteLine("Ring 1: Item not found");
            }

            if (gearJson.Contains("finger2"))
            {
                string ring2slot = dict["items"]["finger2"]["icon"];
                ring2Name.Text = dict["items"]["finger2"]["name"];
                ring2Slot.Load($"http://wow.zamimg.com/images/wow/icons/large/{ring2slot}.jpg");
                Console.WriteLine("Ring 2: Downloaded");
            }
            else
            {
                ring2Slot.Image = Properties.Resources.ring;
                Console.WriteLine("Ring 2: Item not found");
            }

            if (gearJson.Contains("trinket1"))
            {
                string trinket1slot = dict["items"]["trinket1"]["icon"];
                trinket1Name.Text = dict["items"]["trinket1"]["name"];
                trinket1Slot.Load($"http://wow.zamimg.com/images/wow/icons/large/{trinket1slot}.jpg");
                Console.WriteLine("Trinket 1: Downloaded");
            }
            else
            {
                trinket1Slot.Image = Properties.Resources.trinket;
                Console.WriteLine("Trinket 1: Item not found");
            }

            if (gearJson.Contains("trinket2"))
            {
                string trinket2slot = dict["items"]["trinket2"]["icon"];
                trinket2Name.Text = dict["items"]["trinket2"]["name"];
                trinket2Slot.Load($"http://wow.zamimg.com/images/wow/icons/large/{trinket2slot}.jpg");
                Console.WriteLine("Trinket 2: Downloaded");
            }
            else
            {
                trinket2Slot.Image = Properties.Resources.trinket;
                Console.WriteLine("Trinket 2: Item not found");
            }

            if (gearJson.Contains("mainHand"))
            {
                string mainweapon = dict["items"]["mainHand"]["icon"];
                //mainhandName.Text = dict["items"]["mainHand"]["name"];
                mainWeapon.Load($"http://wow.zamimg.com/images/wow/icons/large/{mainweapon}.jpg");
                Console.WriteLine("Main Weapon: Downloaded");
            }
            else
            {
                mainWeapon.Image = Properties.Resources.Main_Hand;
                Console.WriteLine("Main Weapon: Item not found");
            }

            if (gearJson.Contains("offHand"))
            {
                string offhandweapon = dict["items"]["offHand"]["icon"];
                //offhandName.Text = dict["items"]["offHand"]["name"];
                offhandWeapon.Load($"http://wow.zamimg.com/images/wow/icons/large/{offhandweapon}.jpg");
                Console.WriteLine("Offhand Weapon: Downloaded");
            }
            else
            {
                //offhandName.Visible = false;
                offhandWeapon.Image = Properties.Resources.Off_Hand;
                Console.WriteLine("Offhand Weapon: Item not found");
            }

        }

        #endregion
    }
}
