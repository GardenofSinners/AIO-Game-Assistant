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
            this.ChracterProfileButton = new System.Windows.Forms.Button();
            this.CloseWoW = new System.Windows.Forms.Label();
            this.Introduction = new System.Windows.Forms.Label();
            this.Panel1 = new System.Windows.Forms.Panel();
            this.TokensButton = new System.Windows.Forms.Button();
            this.RegionList = new System.Windows.Forms.ComboBox();
            this.GuildProfileButton = new System.Windows.Forms.Button();
            this.RealmStatusButton = new System.Windows.Forms.Button();
            this.AHButton = new System.Windows.Forms.Button();
            this.Panel2 = new System.Windows.Forms.Panel();
            this.Logo = new System.Windows.Forms.PictureBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.Panel1.SuspendLayout();
            this.Panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Logo)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // ChracterProfileButton
            // 
            this.ChracterProfileButton.Location = new System.Drawing.Point(1, 3);
            this.ChracterProfileButton.Name = "ChracterProfileButton";
            this.ChracterProfileButton.Size = new System.Drawing.Size(113, 48);
            this.ChracterProfileButton.TabIndex = 0;
            this.ChracterProfileButton.Text = "Character Profile";
            this.ChracterProfileButton.UseVisualStyleBackColor = true;
            this.ChracterProfileButton.Click += new System.EventHandler(this.CharacterProfileButton_Click);
            // 
            // CloseWoW
            // 
            this.CloseWoW.AutoSize = true;
            this.CloseWoW.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.CloseWoW.Location = new System.Drawing.Point(1087, -1);
            this.CloseWoW.Name = "CloseWoW";
            this.CloseWoW.Size = new System.Drawing.Size(20, 20);
            this.CloseWoW.TabIndex = 2;
            this.CloseWoW.Text = "X";
            this.CloseWoW.Click += new System.EventHandler(this.Close_Click);
            // 
            // Introduction
            // 
            this.Introduction.AutoSize = true;
            this.Introduction.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Introduction.Location = new System.Drawing.Point(31, 163);
            this.Introduction.Name = "Introduction";
            this.Introduction.Size = new System.Drawing.Size(785, 240);
            this.Introduction.TabIndex = 4;
            this.Introduction.Text = resources.GetString("Introduction.Text");
            // 
            // Panel1
            // 
            this.Panel1.Controls.Add(this.TokensButton);
            this.Panel1.Controls.Add(this.RegionList);
            this.Panel1.Controls.Add(this.GuildProfileButton);
            this.Panel1.Controls.Add(this.RealmStatusButton);
            this.Panel1.Controls.Add(this.AHButton);
            this.Panel1.Controls.Add(this.ChracterProfileButton);
            this.Panel1.Location = new System.Drawing.Point(-1, 87);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(115, 529);
            this.Panel1.TabIndex = 5;
            // 
            // TokensButton
            // 
            this.TokensButton.Location = new System.Drawing.Point(2, 223);
            this.TokensButton.Name = "TokensButton";
            this.TokensButton.Size = new System.Drawing.Size(113, 48);
            this.TokensButton.TabIndex = 76;
            this.TokensButton.Text = "Tokens";
            this.TokensButton.UseVisualStyleBackColor = true;
            this.TokensButton.Click += new System.EventHandler(this.TokensButton_Click);
            // 
            // RegionList
            // 
            this.RegionList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.RegionList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RegionList.FormattingEnabled = true;
            this.RegionList.Items.AddRange(new object[] {
            "US",
            "EU",
            "KR",
            "TW"});
            this.RegionList.Location = new System.Drawing.Point(0, 494);
            this.RegionList.Name = "RegionList";
            this.RegionList.Size = new System.Drawing.Size(112, 21);
            this.RegionList.TabIndex = 75;
            this.RegionList.SelectedIndexChanged += new System.EventHandler(this.RegionList_SelectedIndexChanged);
            // 
            // GuildProfileButton
            // 
            this.GuildProfileButton.Location = new System.Drawing.Point(1, 58);
            this.GuildProfileButton.Name = "GuildProfileButton";
            this.GuildProfileButton.Size = new System.Drawing.Size(113, 48);
            this.GuildProfileButton.TabIndex = 3;
            this.GuildProfileButton.Text = "Guild Profile";
            this.GuildProfileButton.UseVisualStyleBackColor = true;
            this.GuildProfileButton.Click += new System.EventHandler(this.GuildProfileButton_Click);
            // 
            // RealmStatusButton
            // 
            this.RealmStatusButton.Location = new System.Drawing.Point(1, 113);
            this.RealmStatusButton.Name = "RealmStatusButton";
            this.RealmStatusButton.Size = new System.Drawing.Size(113, 48);
            this.RealmStatusButton.TabIndex = 2;
            this.RealmStatusButton.Text = "Realm Status";
            this.RealmStatusButton.UseVisualStyleBackColor = true;
            this.RealmStatusButton.Click += new System.EventHandler(this.RealmSTatusButton_Click);
            // 
            // AHButton
            // 
            this.AHButton.Location = new System.Drawing.Point(1, 168);
            this.AHButton.Name = "AHButton";
            this.AHButton.Size = new System.Drawing.Size(113, 48);
            this.AHButton.TabIndex = 1;
            this.AHButton.Text = "Auction House";
            this.AHButton.UseVisualStyleBackColor = true;
            this.AHButton.Click += new System.EventHandler(this.AHButton_Click);
            // 
            // Panel2
            // 
            this.Panel2.Controls.Add(this.Logo);
            this.Panel2.Location = new System.Drawing.Point(1, -1);
            this.Panel2.Name = "Panel2";
            this.Panel2.Size = new System.Drawing.Size(113, 85);
            this.Panel2.TabIndex = 6;
            // 
            // Logo
            // 
            this.Logo.Image = ((System.Drawing.Image)(resources.GetObject("Logo.Image")));
            this.Logo.InitialImage = ((System.Drawing.Image)(resources.GetObject("Logo.InitialImage")));
            this.Logo.Location = new System.Drawing.Point(0, 0);
            this.Logo.Name = "Logo";
            this.Logo.Size = new System.Drawing.Size(110, 82);
            this.Logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Logo.TabIndex = 0;
            this.Logo.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.Introduction);
            this.panel3.Location = new System.Drawing.Point(117, 48);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(986, 568);
            this.panel3.TabIndex = 7;
            // 
            // WorldofWarcraft
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1105, 614);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.Panel2);
            this.Controls.Add(this.Panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "WorldofWarcraft";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "World of Warcraft AIO Assistant";
            this.Panel1.ResumeLayout(false);
            this.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Logo)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ChracterProfileButton;
        private System.Windows.Forms.Label CloseWoW;
        private System.Windows.Forms.Label Introduction;
        private System.Windows.Forms.Panel Panel1;
        private System.Windows.Forms.PictureBox Logo;
        private System.Windows.Forms.Panel Panel2;
        private System.Windows.Forms.Button AHButton;
        private System.Windows.Forms.Button RealmStatusButton;
        private System.Windows.Forms.Button GuildProfileButton;
        public System.Windows.Forms.ComboBox RegionList;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button TokensButton;
    }
}