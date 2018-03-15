using AIO_Game_Assistant.Modular_Windows.Options;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AIO_Game_Assistant.Modular_Windows.Games.World_of_Warcraft
{
    public partial class WorldofWarcraft : Form
    {
        WoWHelper W = new WoWHelper();
        WoWHelper _WoWHelper { get; }

        public WorldofWarcraft()
        {
            InitializeComponent();
            //RegionList.SelectedIndex = 0;

            //Hide components
            CharacterProfile.Hide();
            GuildProfile.Hide();
            AuctionHouse.Hide();
            RealmStatus.Hide();

            //Send to back
            CharacterProfile.SendToBack();
            GuildProfile.SendToBack();
            AuctionHouse.SendToBack();
            RealmStatus.SendToBack();
        }

        private void Close_Click(object sender, EventArgs e)
        {
            Dispose();
            Close();
        }

        private void CharacterProfileButton_Click(object sender, EventArgs e)
        {
            Introduction.Visible = false;
            if (CharacterProfile.Visible == true)
            {
                CharacterProfile.Hide();
                CharacterProfile.SendToBack();
                GuildProfile.Hide();
                GuildProfile.SendToBack();
                AuctionHouse.Hide();
                AuctionHouse.SendToBack();
                RealmStatus.Hide();
                RealmStatus.SendToBack();

            } else {
                AuctionHouse.Hide();
                RealmStatus.Hide();
                CharacterProfile.BringToFront();
                CharacterProfile.Show();
            }     
        }

        private void GuildProfileButton_Click(object sender, EventArgs e)
        {
            Introduction.Visible = false;
            if (GuildProfile.Visible == true)
            {
                CharacterProfile.Hide();
                CharacterProfile.SendToBack();
                GuildProfile.Hide();
                GuildProfile.SendToBack();
                AuctionHouse.Hide();
                AuctionHouse.SendToBack();
                RealmStatus.Hide();
                RealmStatus.SendToBack();

            }
            else
            {
                AuctionHouse.Hide();
                RealmStatus.Hide();
                CharacterProfile.Hide();
                GuildProfile.BringToFront();
                GuildProfile.Show();
            }
        }

        private void AHButton_Click(object sender, EventArgs e)
        {

            Introduction.Visible = false;

            if (AuctionHouse.Visible == true)
            {
                CharacterProfile.Hide();
                CharacterProfile.SendToBack();
                GuildProfile.Hide();
                GuildProfile.SendToBack();
                AuctionHouse.Hide();
                AuctionHouse.SendToBack();
                RealmStatus.Hide();
            }
            else
            {
                CharacterProfile.Hide();
                RealmStatus.Hide();
                AuctionHouse.BringToFront();
                AuctionHouse.Show();
            }
        }

        private void RealmSTatusButton_Click(object sender, EventArgs e)
        {

            Introduction.Visible = false;

            if (RealmStatus.Visible == true)
            {
                CharacterProfile.Hide();
                CharacterProfile.SendToBack();
                GuildProfile.Hide();
                GuildProfile.SendToBack();
                AuctionHouse.Hide();
                AuctionHouse.SendToBack();
                RealmStatus.Hide();
                RealmStatus.SendToBack();
            }
            else
            {
                CharacterProfile.Hide();
                GuildProfile.Hide();
                AuctionHouse.Hide();
                RealmStatus.BringToFront();
                RealmStatus.Show();
            }
        }

        //Allows the form to be dragged
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case 0x84:
                    base.WndProc(ref m);
                    if ((int)m.Result == 0x1)
                        m.Result = (IntPtr)0x2;
                    return;
            }

            base.WndProc(ref m);
        }

        private void RegionList_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //Task.Run(_WoWHelper.GetRealmList);
                Task.Run(W.GetRealmList);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
