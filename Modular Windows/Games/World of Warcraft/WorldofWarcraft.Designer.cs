namespace AIO_Game_Assistant.Modular_Windows.Games.World_of_Warcraft
{
    partial class WorldofWarcraft
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WorldofWarcraft));
            this.button1 = new System.Windows.Forms.Button();
            this.close = new System.Windows.Forms.Label();
            this.introduction = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.logo = new System.Windows.Forms.PictureBox();
            this.realm_Status1 = new AIO_Game_Assistant.Modular_Windows.User_Control_Forms.Games.World_of_Warcraft.Realm_Status();
            this.auction_House1 = new AIO_Game_Assistant.Modular_Windows.User_Control_Forms.Games.World_of_Warcraft.Auction_House();
            this.character_Profile1 = new AIO_Game_Assistant.Modular_Windows.User_Control_Forms.Games.World_of_Warcraft.Character_Profile();
            this.button3 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logo)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(0, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(115, 49);
            this.button1.TabIndex = 0;
            this.button1.Text = "Character Profile";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // close
            // 
            this.close.AutoSize = true;
            this.close.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.close.Location = new System.Drawing.Point(1087, -1);
            this.close.Name = "close";
            this.close.Size = new System.Drawing.Size(19, 21);
            this.close.TabIndex = 2;
            this.close.Text = "X";
            this.close.Click += new System.EventHandler(this.close_Click);
            // 
            // introduction
            // 
            this.introduction.AutoSize = true;
            this.introduction.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.introduction.Location = new System.Drawing.Point(144, 173);
            this.introduction.Name = "introduction";
            this.introduction.Size = new System.Drawing.Size(888, 252);
            this.introduction.TabIndex = 4;
            this.introduction.Text = resources.GetString("introduction.Text");
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Location = new System.Drawing.Point(-1, 87);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(115, 529);
            this.panel1.TabIndex = 5;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.logo);
            this.panel2.Location = new System.Drawing.Point(1, -1);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(113, 85);
            this.panel2.TabIndex = 6;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(0, 58);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(115, 49);
            this.button2.TabIndex = 1;
            this.button2.Text = "Auction House";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // logo
            // 
            this.logo.Image = ((System.Drawing.Image)(resources.GetObject("logo.Image")));
            this.logo.InitialImage = ((System.Drawing.Image)(resources.GetObject("logo.InitialImage")));
            this.logo.Location = new System.Drawing.Point(0, 0);
            this.logo.Name = "logo";
            this.logo.Size = new System.Drawing.Size(110, 82);
            this.logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.logo.TabIndex = 0;
            this.logo.TabStop = false;
            // 
            // realm_Status1
            // 
            this.realm_Status1.Location = new System.Drawing.Point(114, 19);
            this.realm_Status1.Name = "realm_Status1";
            this.realm_Status1.Size = new System.Drawing.Size(994, 596);
            this.realm_Status1.TabIndex = 8;
            // 
            // auction_House1
            // 
            this.auction_House1.Location = new System.Drawing.Point(114, 19);
            this.auction_House1.Name = "auction_House1";
            this.auction_House1.Size = new System.Drawing.Size(994, 596);
            this.auction_House1.TabIndex = 7;
            // 
            // character_Profile1
            // 
            this.character_Profile1.Location = new System.Drawing.Point(115, 18);
            this.character_Profile1.Name = "character_Profile1";
            this.character_Profile1.Size = new System.Drawing.Size(994, 596);
            this.character_Profile1.TabIndex = 3;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(0, 113);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(115, 49);
            this.button3.TabIndex = 2;
            this.button3.Text = "Realm Status";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // WorldofWarcraft
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1105, 614);
            this.Controls.Add(this.realm_Status1);
            this.Controls.Add(this.auction_House1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.introduction);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.close);
            this.Controls.Add(this.character_Profile1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "WorldofWarcraft";
            this.Text = "World of Warcraft AIO Assistant";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.logo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label close;
        private User_Control_Forms.Games.World_of_Warcraft.Character_Profile character_Profile1;
        private System.Windows.Forms.Label introduction;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox logo;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button2;
        private User_Control_Forms.Games.World_of_Warcraft.Auction_House auction_House1;
        private User_Control_Forms.Games.World_of_Warcraft.Realm_Status realm_Status1;
        private System.Windows.Forms.Button button3;
    }
}