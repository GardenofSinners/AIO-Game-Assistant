using System;
using System.Windows.Forms;
using AIO_Game_Assistant.Modular_Windows.Games.World_of_Warcraft;

namespace AIO_Game_Assistant
{
    public partial class MainWindow : Form
    { 
        public MainWindow()
        { 
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            using (WorldofWarcraft worldofWarcraft = new WorldofWarcraft())
            {
                Hide();
                worldofWarcraft.FormClosed += (s, args) => Show();
                worldofWarcraft.ShowDialog();
            }
        }

        private void Label1_Click(object sender, EventArgs e)
        {
            Application.Exit();
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
