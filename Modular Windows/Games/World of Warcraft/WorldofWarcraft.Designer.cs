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
            this.logo = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.character_Profile1 = new AIO_Game_Assistant.Modular_Windows.User_Control_Forms.Games.World_of_Warcraft.Character_Profile();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logo)).BeginInit();
            this.panel2.SuspendLayout();
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
            this.panel1.Controls.Add(this.button1);
            this.panel1.Location = new System.Drawing.Point(-1, 87);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(115, 529);
            this.panel1.TabIndex = 5;
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
            // panel2
            // 
            this.panel2.Controls.Add(this.logo);
            this.panel2.Location = new System.Drawing.Point(1, -1);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(113, 85);
            this.panel2.TabIndex = 6;
            // 
            // character_Profile1
            // 
            this.character_Profile1.Location = new System.Drawing.Point(115, 18);
            this.character_Profile1.Name = "character_Profile1";
            this.character_Profile1.Size = new System.Drawing.Size(994, 596);
            this.character_Profile1.TabIndex = 3;
            // 
            // WorldofWarcraft
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1105, 614);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.introduction);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.close);
            this.Controls.Add(this.character_Profile1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "WorldofWarcraft";
            this.Text = "World of Warcraft AIO Assistant";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.logo)).EndInit();
            this.panel2.ResumeLayout(false);
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
    }
}