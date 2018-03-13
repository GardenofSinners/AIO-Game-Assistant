using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AIO_Game_Assistant.Modular_Windows.Games.World_of_Warcraft;

namespace AIO_Game_Assistant
{
    public partial class Form1 : Form
    { 
        public Form1()
        { 
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (WorldofWarcraft worldofWarcraft = new WorldofWarcraft())
            {
                worldofWarcraft.ShowDialog();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
