using AIO_Game_Assistant.Modular_Windows.Options;
using AIO_Game_Assistant.Modular_Windows.User_Control_Forms.Games.World_of_Warcraft;
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
        }

        private void Close_Click(object sender, EventArgs e)
        {
            Dispose();
            Close();
        }

        private void CharacterProfileButton_Click(object sender, EventArgs e)
        {
            Introduction.Visible = false;
            if (!panel3.Controls.Contains(Character_Profile.Instance))
            {
                panel3.Controls.Add(Character_Profile.Instance);
                Character_Profile.Instance.Dock = DockStyle.Fill;
                Character_Profile.Instance.BringToFront();
            }
            else
            {
                panel3.Controls.Remove(Character_Profile.Instance);
            }
        }

        private void GuildProfileButton_Click(object sender, EventArgs e)
        {
            Introduction.Visible = false;
            if (!panel3.Controls.Contains(Guild_Profile.Instance))
            {
                panel3.Controls.Add(Guild_Profile.Instance);
                Guild_Profile.Instance.Dock = DockStyle.Fill;
                Guild_Profile.Instance.BringToFront();
            }
            else
            {
                panel3.Controls.Remove(Guild_Profile.Instance);
            }
        }

        private void AHButton_Click(object sender, EventArgs e)
        {

            Introduction.Visible = false;

            if (!panel3.Controls.Contains(Auction_House.Instance))
            {
                panel3.Controls.Add(Auction_House.Instance);
                Auction_House.Instance.Dock = DockStyle.Fill;
                Auction_House.Instance.BringToFront();
            }
            else
            {
                panel3.Controls.Remove(Auction_House.Instance);
            }
        }

        private void RealmSTatusButton_Click(object sender, EventArgs e)
        {

            Introduction.Visible = false;

            if (!panel3.Controls.Contains(Realm_Status.Instance))
            {
                panel3.Controls.Add(Realm_Status.Instance);
                Realm_Status.Instance.Dock = DockStyle.Fill;
                Realm_Status.Instance.BringToFront();
            }
            else
            {
                panel3.Controls.Remove(Realm_Status.Instance);
            }
        }

        private void TokensButton_Click(object sender, EventArgs e)
        {
            Introduction.Visible = false;
            if (!panel3.Controls.Contains(Tokens.Instance))
            {
                panel3.Controls.Add(Tokens.Instance);
                Tokens.Instance.BringToFront();
            }
            else
            {
                panel3.Controls.Remove(Tokens.Instance);
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
