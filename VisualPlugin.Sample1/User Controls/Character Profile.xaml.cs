using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using VisualPlugin.Sample1.Handler;

namespace VisualPlugin.Sample1.User_Controls
{

    public partial class Character_Profile : UserControl
    {

        string apiKey = WorldofWarcraft.APIKey;

        private static Character_Profile _instance;

        public static Character_Profile Instance {
            get {
                if (_instance == null)
                    _instance = new Character_Profile();
                return _instance;

            }
        }

        public Character_Profile()
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

        private void Button_Click(object sender, RoutedEventArgs e)
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

            string charactername = characterName.Text;
            byte[] bytes = Encoding.Default.GetBytes(characterName.Text);
            charactername = Encoding.UTF8.GetString(bytes);

            string characterAPI = $"https://{region}.api.battle.net/wow/character/{realm}/{charactername}?locale={locale}&apikey={apiKey}";
            try
            {
                string characterJson = new WebClient().DownloadString(characterAPI);

                //A dictionary where all values for the deserialized JSON is stored
                var dict = WoWHelper.Instance.jss.Deserialize<Dictionary<string, dynamic>>(characterJson);

                string thumbnailUrl = dict["thumbnail"];
                thumbnailUrl = thumbnailUrl.Substring(0, thumbnailUrl.Length - 10); //prints out {id}/{generatedImageID}-
                thumbnailUrl = $"http://render-{region}.worldofwarcraft.com/character/{thumbnailUrl}profilemain.jpg";

                // Set the stretch property.
                characterImage.Stretch = Stretch.Fill;

                // Set the StretchDirection property.
                characterImage.StretchDirection = StretchDirection.Both;
                //Sets Image
                characterImage.Source = new BitmapImage(new Uri(thumbnailUrl));
                
                UserAppearanceandGear(locale);

            }
            catch (WebException)
            {
                MessageBox.Show($"Unable to find character \"{charactername}\"");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        #region User Appearance and Gear.
        public void UserAppearanceandGear(string locale)
        {

            var test = System.AppDomain.CurrentDomain.BaseDirectory;
            string currentDirectory = System.IO.Path.GetFullPath(System.IO.Path.Combine(test, @"..\..\..\"));

            //icons are displayed in a 56x56 format
            string charactername = characterName.Text;
            byte[] bytes = Encoding.Default.GetBytes(characterName.Text);
            charactername = Encoding.UTF8.GetString(bytes);
            //얼안
            string gearAPI = $"https://{region}.api.battle.net/wow/character/{realm}/{charactername}?fields=items&locale={locale}&apikey={apiKey}";

            var gearJson = new WebClient().DownloadString(gearAPI);

            //A dictionary where all values for the deserialized JSON is stored
            var dict = WoWHelper.Instance.jss.Deserialize<Dictionary<string, dynamic>>(gearJson);

            WebClient webClient = new WebClient();

            if (gearJson.Contains("head"))
            {
                string headslot = dict["items"]["head"]["icon"];
                headSlot.Source = new BitmapImage(new Uri($"http://wow.zamimg.com/images/wow/icons/large/{headslot}.jpg"));
                headName.Content = dict["items"]["head"]["name"];
                Console.WriteLine("Head: Downloaded");

            }
            else
            {
                Console.WriteLine("Head: Item not found");
            }

            if (gearJson.Contains("neck"))
            {
                string neckslot = dict["items"]["neck"]["icon"];
                neckName.Content = dict["items"]["neck"]["name"];
                neckSlot.Source = new BitmapImage(new Uri($"http://wow.zamimg.com/images/wow/icons/large/{neckslot}.jpg"));
                Console.WriteLine("Neck: Downloaded");
            }
            else
            {
                Console.WriteLine("Neck: Item not found");
            }

            if (gearJson.Contains("shoulder"))
            {
                string shoulderslot = dict["items"]["shoulder"]["icon"];
                shoulderName.Content = dict["items"]["shoulder"]["name"];
                shoulderSlot.Source = new BitmapImage(new Uri($"http://wow.zamimg.com/images/wow/icons/large/{shoulderslot}.jpg"));
                Console.WriteLine("Shoulder: Downloaded");
            }
            else
            {
                shoulderSlot.Source = new BitmapImage(new Uri($"{currentDirectory}////VisualPlugin.Sample1//External Data//Images//Shoulders.png", UriKind.RelativeOrAbsolute));
                Console.WriteLine("Shoulder: Item not found");
            }

            if (gearJson.Contains("back"))
            {
                string cloakslot = dict["items"]["back"]["icon"];
                cloakName.Content = dict["items"]["back"]["name"];
                cloakSlot.Source = new BitmapImage(new Uri($"http://wow.zamimg.com/images/wow/icons/large/{cloakslot}.jpg"));
                Console.WriteLine("Cloak: Downloaded");
            }
            else
            {
                cloakSlot.Source = new BitmapImage(new Uri($"{currentDirectory}////VisualPlugin.Sample1//External Data//Images//Back.png", UriKind.RelativeOrAbsolute));
                Console.WriteLine("Cloak: Item not found");
            }

            if (gearJson.Contains("chest"))
            {
                string chestslot = dict["items"]["chest"]["icon"];
                chestName.Content = dict["items"]["chest"]["name"];
                chestSlot.Source = new BitmapImage(new Uri($"http://wow.zamimg.com/images/wow/icons/large/{chestslot}.jpg"));
                Console.WriteLine("Chest: Downloaded");
            }
            else
            {
                chestSlot.Source = new BitmapImage(new Uri($"{currentDirectory}////VisualPlugin.Sample1//External Data//Images//Chest.png", UriKind.RelativeOrAbsolute));
                Console.WriteLine("Chest: Item not found");
            }

            if (gearJson.Contains("shirt"))
            {
                string shirtslot = dict["items"]["shirt"]["icon"];
                shirtName.Content = dict["items"]["shirt"]["name"];
                shirtSlot.Source = new BitmapImage(new Uri($"http://wow.zamimg.com/images/wow/icons/large/{shirtslot}.jpg"));
                Console.WriteLine("Shirt: Downloaded");
            }
            else
            {
                shirtSlot.Source = new BitmapImage(new Uri($"{currentDirectory}////VisualPlugin.Sample1//External Data//Images//shirt.png", UriKind.RelativeOrAbsolute));
                Console.WriteLine("Shirt: Item not found");
            }

            if (gearJson.Contains("tabard"))
            {
                string tabardslot = dict["items"]["tabard"]["icon"];
                tabardName.Content = dict["items"]["tabard"]["name"];
                tabardSlot.Source = new BitmapImage(new Uri($"http://wow.zamimg.com/images/wow/icons/large/{tabardslot}.jpg"));
                Console.WriteLine("Tabard: Downloaded");
            }
            else
            {
                tabardSlot.Source = new BitmapImage(new Uri($"{currentDirectory}////VisualPlugin.Sample1//External Data//Images//tabard.png", UriKind.RelativeOrAbsolute));
                Console.WriteLine("Tabard: Item not found");
            }

            if (gearJson.Contains("wrist"))
            {
                string wristslot = dict["items"]["wrist"]["icon"];
                wristName.Content = dict["items"]["wrist"]["name"];
                wristSlot.Source = new BitmapImage(new Uri($"http://wow.zamimg.com/images/wow/icons/large/{wristslot}.jpg"));
                Console.WriteLine("Wrist: Downloaded");
            }
            else
            {
                wristSlot.Source = new BitmapImage(new Uri($"{currentDirectory}////VisualPlugin.Sample1//External Data//Images//Wrist.png", UriKind.RelativeOrAbsolute));
                Console.WriteLine("Wrist: Item not found");
            }

            if (gearJson.Contains("hands"))
            {
                string handsslot = dict["items"]["hands"]["icon"];
                handsName.Content = dict["items"]["hands"]["name"];
                handsSlot.Source = new BitmapImage(new Uri($"http://wow.zamimg.com/images/wow/icons/large/{handsslot}.jpg"));
                Console.WriteLine("Hands: Downloaded");
            }
            else
            {
                handsSlot.Source = new BitmapImage(new Uri($"{currentDirectory}////VisualPlugin.Sample1//External Data//Images//gloves.png", UriKind.RelativeOrAbsolute));
                Console.WriteLine("Hands: Item not found");
            }

            if (gearJson.Contains("waist"))
            {
                string waistslot = dict["items"]["waist"]["icon"];
                waistName.Content = dict["items"]["waist"]["name"];
                waistSlot.Source = new BitmapImage(new Uri($"http://wow.zamimg.com/images/wow/icons/large/{waistslot}.jpg"));
                Console.WriteLine("Waist: Downloaded");
            }
            else
            {
                waistSlot.Source = new BitmapImage(new Uri($"{currentDirectory}////VisualPlugin.Sample1//External Data//Images//Waist.png", UriKind.RelativeOrAbsolute));
                Console.WriteLine("Waist: Item not found");
            }

            if (gearJson.Contains("legs"))
            {
                string legsslot = dict["items"]["legs"]["icon"];
                legName.Content = dict["items"]["legs"]["name"];
                legSlot.Source = new BitmapImage(new Uri($"http://wow.zamimg.com/images/wow/icons/large/{legsslot}.jpg"));
                Console.WriteLine("Legs: Downloaded");
            }
            else
            {
                legSlot.Source = new BitmapImage(new Uri($"{currentDirectory}////VisualPlugin.Sample1//External Data//Images//Pants.png", UriKind.RelativeOrAbsolute));
                Console.WriteLine("Legs: Item not found");
            }

            if (gearJson.Contains("feet"))
            {
                string feetslot = dict["items"]["feet"]["icon"];
                feetName.Content = dict["items"]["feet"]["name"];
                feetSlot.Source = new BitmapImage(new Uri($"http://wow.zamimg.com/images/wow/icons/large/{feetslot}.jpg"));
                Console.WriteLine("Feet: Downloaded");
            }
            else
            {
                feetSlot.Source = new BitmapImage(new Uri($"{currentDirectory}////VisualPlugin.Sample1//External Data//Images//Feet.png", UriKind.RelativeOrAbsolute));
                Console.WriteLine("Feet: Item not found");
            }

            if (gearJson.Contains("finger1"))
            {
                string ring1slot = dict["items"]["finger1"]["icon"];
                ring1Name.Content = dict["items"]["finger1"]["name"];
                ring1Slot.Source = new BitmapImage(new Uri($"http://wow.zamimg.com/images/wow/icons/large/{ring1slot}.jpg"));
                Console.WriteLine("Ring 1: Downloaded");
            }
            else
            {
                ring1Slot.Source = new BitmapImage(new Uri($"{currentDirectory}////VisualPlugin.Sample1//External Data//Images//ring.png", UriKind.RelativeOrAbsolute));
                Console.WriteLine("Ring 1: Item not found");
            }

            if (gearJson.Contains("finger2"))
            {
                string ring2slot = dict["items"]["finger2"]["icon"];
                ring2Name.Content = dict["items"]["finger2"]["name"];
                ring2Slot.Source = new BitmapImage(new Uri($"http://wow.zamimg.com/images/wow/icons/large/{ring2slot}.jpg"));
                Console.WriteLine("Ring 2: Downloaded");
            }
            else
            {
                ring2Slot.Source = new BitmapImage(new Uri($"{currentDirectory}////VisualPlugin.Sample1//External Data//Images//ring.png", UriKind.RelativeOrAbsolute));
                Console.WriteLine("Ring 2: Item not found");
            }

            if (gearJson.Contains("trinket1"))
            {
                string trinket1slot = dict["items"]["trinket1"]["icon"];
                trinket1Name.Content = dict["items"]["trinket1"]["name"];
                trinket1Slot.Source = new BitmapImage(new Uri($"http://wow.zamimg.com/images/wow/icons/large/{trinket1slot}.jpg"));
                Console.WriteLine("Trinket 1: Downloaded");
            }
            else
            {
                trinket1Slot.Source = new BitmapImage(new Uri($"{currentDirectory}////VisualPlugin.Sample1//External Data//Images//trinket.png", UriKind.RelativeOrAbsolute));
                Console.WriteLine("Trinket 1: Item not found");
            }

            if (gearJson.Contains("trinket2"))
            {
                string trinket2slot = dict["items"]["trinket2"]["icon"];
                trinket2Name.Content = dict["items"]["trinket2"]["name"];
                trinket2Slot.Source = new BitmapImage(new Uri($"http://wow.zamimg.com/images/wow/icons/large/{trinket2slot}.jpg"));
                Console.WriteLine("Trinket 2: Downloaded");
            }
            else
            {
                trinket2Slot.Source = new BitmapImage(new Uri($"{currentDirectory}////VisualPlugin.Sample1//External Data//Images//trinket.png", UriKind.RelativeOrAbsolute));
                Console.WriteLine("Trinket 2: Item not found");
            }

            if (gearJson.Contains("mainHand"))
            {
                string mainweapon = dict["items"]["mainHand"]["icon"];
                mainWeapon.Source = new BitmapImage(new Uri($"http://wow.zamimg.com/images/wow/icons/large/{mainweapon}.jpg"));
                Console.WriteLine("Main Weapon: Downloaded");
            }
            else
            {
                mainWeapon.Source = new BitmapImage(new Uri($"{currentDirectory}////VisualPlugin.Sample1//External Data//Images//Main Hand.png", UriKind.RelativeOrAbsolute));
                Console.WriteLine("Main Weapon: Item not found");
            }

            if (gearJson.Contains("offHand"))
            {
                string offhandweapon = dict["items"]["offHand"]["icon"];
                offhandWeapon.Source = new BitmapImage(new Uri($"http://wow.zamimg.com/images/wow/icons/large/{offhandweapon}.jpg"));
                Console.WriteLine("Offhand Weapon: Downloaded");
            }
            else
            {
                offhandWeapon.Source = new BitmapImage(new Uri($"{currentDirectory}////VisualPlugin.Sample1//External Data//Images//offhand.png", UriKind.RelativeOrAbsolute));
                Console.WriteLine("Offhand Weapon: Item not found");
            }

        }

        #endregion
    }
}
