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
            this.GuildName = new System.Windows.Forms.TextBox();
            this.GuildNameLabel = new System.Windows.Forms.Label();
            this.GetGuildButton = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // GuildName
            // 
            this.GuildName.Location = new System.Drawing.Point(350, 15);
            this.GuildName.Name = "GuildName";
            this.GuildName.Size = new System.Drawing.Size(229, 20);
            this.GuildName.TabIndex = 85;
            // 
            // GuildNameLabel
            // 
            this.GuildNameLabel.AutoSize = true;
            this.GuildNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.GuildNameLabel.Location = new System.Drawing.Point(295, 15);
            this.GuildNameLabel.Name = "GuildNameLabel";
            this.GuildNameLabel.Size = new System.Drawing.Size(50, 20);
            this.GuildNameLabel.TabIndex = 86;
            this.GuildNameLabel.Text = "Guild:";
            // 
            // GetGuildButton
            // 
            this.GetGuildButton.Cursor = System.Windows.Forms.Cursors.Default;
            this.GetGuildButton.Location = new System.Drawing.Point(590, 15);
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
            this.Name = "Guild_Profile";
            this.Size = new System.Drawing.Size(994, 596);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox GuildName;
        private System.Windows.Forms.Label GuildNameLabel;
        private System.Windows.Forms.Button GetGuildButton;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}
