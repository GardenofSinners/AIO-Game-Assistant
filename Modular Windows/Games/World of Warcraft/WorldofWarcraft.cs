using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace AIO_Game_Assistant.Modular_Windows.Games.World_of_Warcraft
{
    public partial class WorldofWarcraft : Form
    {

        public WorldofWarcraft()
        {
            InitializeComponent();
            character_Profile1.Hide();
        }

        private void close_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(character_Profile1.Visible == true)
            {
                character_Profile1.Hide();
            } else
            {
                introduction.Visible = false;
                character_Profile1.Visible = true;
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
    }
}
