using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using VisualPlugin.Sample1.Handler;
using VisualPlugin.Sample1.User_Controls;

namespace VisualPlugin.Sample1
{

    public partial class WorldofWarcraft : Window
    {

        public static string APIKey = "";
        public static WorldofWarcraft _instance;

        public static WorldofWarcraft Instance {
            get {
                if (_instance == null)
                    _instance = new WorldofWarcraft();
                return _instance;

            }
        }

        public int Character_ProfileclickedAlready = 0;
        public int Guild_ProfileclickedAlready = 0;
        public int Realm_StatusclickedAlready = 0;
        public int Auction_HouseclickedAlready = 0;
        public int TokensclickedAlready = 0;

        public WorldofWarcraft()
        {
            InitializeComponent();
        }

        private void CharacterProfileButton_Click(object sender, RoutedEventArgs e)
        {
            if (Character_ProfileclickedAlready == 0)
            {
                InfoCanvas.Children.Add(Character_Profile.Instance);
                Character_ProfileclickedAlready++;
            }
            else
            {
                InfoCanvas.Children.Remove(Character_Profile.Instance);
                Character_ProfileclickedAlready--;
            }
        }

        private void GuildProfileButton_Click(object sender, RoutedEventArgs e)
        {
            if (Guild_ProfileclickedAlready == 0)
            {
                InfoCanvas.Children.Add(Guild_Profile.Instance);
                Guild_ProfileclickedAlready++;
            }
            else
            {
                InfoCanvas.Children.Remove(Guild_Profile.Instance);
                Guild_ProfileclickedAlready--;
            }
        }

        private void RealmStatusButton_Click(object sender, RoutedEventArgs e)
        {
            if (Realm_StatusclickedAlready == 0)
            {
                InfoCanvas.Children.Add(Realm_Status.Instance);
                Realm_StatusclickedAlready++;
            }
            else if (Auction_HouseclickedAlready == 1)
            {
                InfoCanvas.Children.Clear();
                Realm_StatusclickedAlready--;
            }
        }

        private void AHButton_Click(object sender, RoutedEventArgs e)
        {

            if (Auction_HouseclickedAlready == 0)
            {
                InfoCanvas.Children.Add(Auction_House.Instance);
                Auction_HouseclickedAlready++;
            }
            else if(Auction_HouseclickedAlready ==  1)
            {
                InfoCanvas.Children.Clear();
                Auction_HouseclickedAlready--;
            }
        }

        private void TokensButton_Click(object sender, RoutedEventArgs e)
        {
            if (TokensclickedAlready == 0)
            {
                InfoCanvas.Children.Add(Tokens.Instance);
                TokensclickedAlready++;
            }
            else if (TokensclickedAlready == 1)
            {
                InfoCanvas.Children.Clear();
                TokensclickedAlready--;
            }
        }

        public void GetRealmList()
        {
            RealmList.Items.Clear();
            WoWHelper.Instance.GetRealmList(RegionList.SelectedIndex);
            string RealmURI = WoWHelper.Instance.RealmURI;

            string[] realms = new string[WoWHelper.Instance.RegionMethod(RealmURI).Count()];
            realms = WoWHelper.Instance.RegionMethod(RealmURI);

            for (int y = 0; y < realms.Length; y++)
            {
                RealmList.Items.Add(realms[y]);
            }

        }

        private void RegionList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                WoWHelper.Instance.GetRealmList(RegionList.SelectedIndex);
                GetRealmList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private void RealmList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Need this otherwise it returns some weird result like 
            //System.Windows.Controls.ComboBoxItem: value

            var RegionItem = (ComboBoxItem)RegionList.SelectedValue;
            var selectedRegion = (string)RegionItem.Content;

            var RealmItem = RealmList.SelectedValue;
            var selectedRealm = (string)RealmItem;

            Character_Profile.Instance.Init(selectedRegion, selectedRealm); 
            Auction_House.Instance.Init(selectedRegion, selectedRealm);
            Guild_Profile.Instance.Init(selectedRegion, selectedRealm); 

            //When realm and region are selected enable the buttons.
            if (RealmList.SelectedItem != null)
            {
                CharacterProfileButton.IsEnabled = true;
                GuildProfileButton.IsEnabled = true;
                RealmStatusButton.IsEnabled = true;
                AHButton.IsEnabled = true;
                TokensButton.IsEnabled = true;
            }
        }
    }
}
