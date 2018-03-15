namespace AIO_Game_Assistant.Modular_Windows.User_Control_Forms.Games.World_of_Warcraft
{
    partial class Guild_Profile
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.GuildRealmList = new System.Windows.Forms.ComboBox();
            this.GuildRegionList = new System.Windows.Forms.ComboBox();
            this.GuildRegionLabel = new System.Windows.Forms.Label();
            this.GuildRealmLabel = new System.Windows.Forms.Label();
            this.GuildName = new System.Windows.Forms.TextBox();
            this.GuildNameLabel = new System.Windows.Forms.Label();
            this.GetGuildButton = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // GuildRealmList
            // 
            this.GuildRealmList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.GuildRealmList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.GuildRealmList.FormattingEnabled = true;
            this.GuildRealmList.Location = new System.Drawing.Point(362, 13);
            this.GuildRealmList.Name = "GuildRealmList";
            this.GuildRealmList.Size = new System.Drawing.Size(223, 21);
            this.GuildRealmList.Sorted = true;
            this.GuildRealmList.TabIndex = 81;
            // 
            // GuildRegionList
            // 
            this.GuildRegionList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.GuildRegionList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.GuildRegionList.FormattingEnabled = true;
            this.GuildRegionList.Items.AddRange(new object[] {
            "US",
            "EU",
            "KR",
            "TW"});
            this.GuildRegionList.Location = new System.Drawing.Point(665, 13);
            this.GuildRegionList.Name = "GuildRegionList";
            this.GuildRegionList.Size = new System.Drawing.Size(143, 21);
            this.GuildRegionList.TabIndex = 82;
            // 
            // GuildRegionLabel
            // 
            this.GuildRegionLabel.AutoSize = true;
            this.GuildRegionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.GuildRegionLabel.Location = new System.Drawing.Point(595, 13);
            this.GuildRegionLabel.Name = "GuildRegionLabel";
            this.GuildRegionLabel.Size = new System.Drawing.Size(64, 20);
            this.GuildRegionLabel.TabIndex = 83;
            this.GuildRegionLabel.Text = "Region:";
            // 
            // GuildRealmLabel
            // 
            this.GuildRealmLabel.AutoSize = true;
            this.GuildRealmLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.GuildRealmLabel.Location = new System.Drawing.Point(301, 13);
            this.GuildRealmLabel.Name = "GuildRealmLabel";
            this.GuildRealmLabel.Size = new System.Drawing.Size(59, 20);
            this.GuildRealmLabel.TabIndex = 84;
            this.GuildRealmLabel.Text = "Realm:";
            // 
            // GuildName
            // 
            this.GuildName.Location = new System.Drawing.Point(66, 13);
            this.GuildName.Name = "GuildName";
            this.GuildName.Size = new System.Drawing.Size(229, 20);
            this.GuildName.TabIndex = 85;
            // 
            // GuildNameLabel
            // 
            this.GuildNameLabel.AutoSize = true;
            this.GuildNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.GuildNameLabel.Location = new System.Drawing.Point(10, 13);
            this.GuildNameLabel.Name = "GuildNameLabel";
            this.GuildNameLabel.Size = new System.Drawing.Size(50, 20);
            this.GuildNameLabel.TabIndex = 86;
            this.GuildNameLabel.Text = "Guild:";
            // 
            // GetGuildButton
            // 
            this.GetGuildButton.Cursor = System.Windows.Forms.Cursors.Default;
            this.GetGuildButton.Location = new System.Drawing.Point(814, 13);
            this.GetGuildButton.Name = "GetGuildButton";
            this.GetGuildButton.Size = new System.Drawing.Size(153, 23);
            this.GetGuildButton.TabIndex = 87;
            this.GetGuildButton.Text = "Search Guild";
            this.GetGuildButton.UseVisualStyleBackColor = true;
            this.GetGuildButton.Click += new System.EventHandler(this.GetGuildButton_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(3, 42);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(988, 551);
            this.richTextBox1.TabIndex = 88;
            this.richTextBox1.Text = "";
            // 
            // Guild_Profile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.GetGuildButton);
            this.Controls.Add(this.GuildNameLabel);
            this.Controls.Add(this.GuildName);
            this.Controls.Add(this.GuildRealmLabel);
            this.Controls.Add(this.GuildRegionLabel);
            this.Controls.Add(this.GuildRegionList);
            this.Controls.Add(this.GuildRealmList);
            this.Name = "Guild_Profile";
            this.Size = new System.Drawing.Size(994, 596);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox GuildRealmList;
        private System.Windows.Forms.ComboBox GuildRegionList;
        private System.Windows.Forms.Label GuildRegionLabel;
        private System.Windows.Forms.Label GuildRealmLabel;
        private System.Windows.Forms.TextBox GuildName;
        private System.Windows.Forms.Label GuildNameLabel;
        private System.Windows.Forms.Button GetGuildButton;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}
