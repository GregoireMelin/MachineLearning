namespace projettaquin
{
    partial class Question_3
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Question_3));
            this.Final_LBL = new System.Windows.Forms.Label();
            this.Consigne_LBL = new System.Windows.Forms.Label();
            this.Aleatoire_BTN = new System.Windows.Forms.Button();
            this.Quitter_BTN = new System.Windows.Forms.Button();
            this.Colis_LBL = new System.Windows.Forms.Label();
            this.Legende_PB = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.Legende_PB)).BeginInit();
            this.SuspendLayout();
            // 
            // Final_LBL
            // 
            this.Final_LBL.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Final_LBL.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Final_LBL.Location = new System.Drawing.Point(642, 97);
            this.Final_LBL.Name = "Final_LBL";
            this.Final_LBL.Size = new System.Drawing.Size(348, 72);
            this.Final_LBL.TabIndex = 38;
            this.Final_LBL.Text = "label1";
            this.Final_LBL.Visible = false;
            // 
            // Consigne_LBL
            // 
            this.Consigne_LBL.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Consigne_LBL.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Consigne_LBL.Location = new System.Drawing.Point(631, 12);
            this.Consigne_LBL.Name = "Consigne_LBL";
            this.Consigne_LBL.Size = new System.Drawing.Size(383, 88);
            this.Consigne_LBL.TabIndex = 27;
            this.Consigne_LBL.Text = "Etape 1 : Veuillez cliquer sur un chariot pour en faire le prioritaire :";
            // 
            // Aleatoire_BTN
            // 
            this.Aleatoire_BTN.BackColor = System.Drawing.Color.LightSkyBlue;
            this.Aleatoire_BTN.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Aleatoire_BTN.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Aleatoire_BTN.Location = new System.Drawing.Point(973, 464);
            this.Aleatoire_BTN.Name = "Aleatoire_BTN";
            this.Aleatoire_BTN.Size = new System.Drawing.Size(187, 64);
            this.Aleatoire_BTN.TabIndex = 26;
            this.Aleatoire_BTN.Text = "Commencer !";
            this.Aleatoire_BTN.UseVisualStyleBackColor = false;
            this.Aleatoire_BTN.Visible = false;
            this.Aleatoire_BTN.Click += new System.EventHandler(this.Aleatoire_BTN_Click);
            // 
            // Quitter_BTN
            // 
            this.Quitter_BTN.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Quitter_BTN.BackColor = System.Drawing.Color.LightSkyBlue;
            this.Quitter_BTN.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Quitter_BTN.Location = new System.Drawing.Point(1038, 1);
            this.Quitter_BTN.Name = "Quitter_BTN";
            this.Quitter_BTN.Size = new System.Drawing.Size(110, 64);
            this.Quitter_BTN.TabIndex = 25;
            this.Quitter_BTN.Text = "Fermer";
            this.Quitter_BTN.UseVisualStyleBackColor = false;
            this.Quitter_BTN.Click += new System.EventHandler(this.Quitter_BTN_Click);
            // 
            // Colis_LBL
            // 
            this.Colis_LBL.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Colis_LBL.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Colis_LBL.Location = new System.Drawing.Point(632, 79);
            this.Colis_LBL.Name = "Colis_LBL";
            this.Colis_LBL.Size = new System.Drawing.Size(466, 365);
            this.Colis_LBL.TabIndex = 43;
            // 
            // Legende_PB
            // 
            this.Legende_PB.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Legende_PB.Image = ((System.Drawing.Image)(resources.GetObject("Legende_PB.Image")));
            this.Legende_PB.Location = new System.Drawing.Point(666, 447);
            this.Legende_PB.Name = "Legende_PB";
            this.Legende_PB.Size = new System.Drawing.Size(290, 117);
            this.Legende_PB.TabIndex = 44;
            this.Legende_PB.TabStop = false;
            // 
            // Question_3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1160, 576);
            this.Controls.Add(this.Legende_PB);
            this.Controls.Add(this.Aleatoire_BTN);
            this.Controls.Add(this.Colis_LBL);
            this.Controls.Add(this.Final_LBL);
            this.Controls.Add(this.Consigne_LBL);
            this.Controls.Add(this.Quitter_BTN);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Question_3";
            this.Text = "Question_3";
            ((System.ComponentModel.ISupportInitialize)(this.Legende_PB)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label Final_LBL;
        private System.Windows.Forms.Label Consigne_LBL;
        private System.Windows.Forms.Button Aleatoire_BTN;
        private System.Windows.Forms.Button Quitter_BTN;
        private System.Windows.Forms.Label Colis_LBL;
        private System.Windows.Forms.PictureBox Legende_PB;
    }
}