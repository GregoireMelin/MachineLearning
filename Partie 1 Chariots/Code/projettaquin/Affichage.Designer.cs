namespace projettaquin
{
    partial class Affichage
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Affichage));
            this.Colis_Position_y_LBL = new System.Windows.Forms.Label();
            this.Quitter_BTN = new System.Windows.Forms.Button();
            this.Aleatoire_BTN = new System.Windows.Forms.Button();
            this.Consigne_LBL = new System.Windows.Forms.Label();
            this.Colis_Position_LBL = new System.Windows.Forms.Label();
            this.Colis_TB = new System.Windows.Forms.TextBox();
            this.Colis_Localisation_TB = new System.Windows.Forms.TextBox();
            this.Colis_hauteur_LBL = new System.Windows.Forms.Label();
            this.Colis_Hauteur_TB = new System.Windows.Forms.TextBox();
            this.Orientation_LBL = new System.Windows.Forms.Label();
            this.Valider_BTN = new System.Windows.Forms.Button();
            this.Orientation_LIST = new System.Windows.Forms.ListBox();
            this.Details_BTN = new System.Windows.Forms.Button();
            this.Final_LBL = new System.Windows.Forms.Label();
            this.Depot_BTN = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.Nv_colis_BTN = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Colis_Position_y_LBL
            // 
            this.Colis_Position_y_LBL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Colis_Position_y_LBL.AutoSize = true;
            this.Colis_Position_y_LBL.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Colis_Position_y_LBL.Location = new System.Drawing.Point(763, 308);
            this.Colis_Position_y_LBL.Name = "Colis_Position_y_LBL";
            this.Colis_Position_y_LBL.Size = new System.Drawing.Size(100, 24);
            this.Colis_Position_y_LBL.TabIndex = 5;
            this.Colis_Position_y_LBL.Text = "Position y :";
            this.Colis_Position_y_LBL.Visible = false;
            // 
            // Quitter_BTN
            // 
            this.Quitter_BTN.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Quitter_BTN.BackColor = System.Drawing.Color.LightSkyBlue;
            this.Quitter_BTN.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Quitter_BTN.Location = new System.Drawing.Point(977, 0);
            this.Quitter_BTN.Name = "Quitter_BTN";
            this.Quitter_BTN.Size = new System.Drawing.Size(110, 64);
            this.Quitter_BTN.TabIndex = 0;
            this.Quitter_BTN.Text = "Fermer";
            this.Quitter_BTN.UseVisualStyleBackColor = false;
            this.Quitter_BTN.Click += new System.EventHandler(this.Quitter_BTN_Click);
            // 
            // Aleatoire_BTN
            // 
            this.Aleatoire_BTN.BackColor = System.Drawing.Color.LightSkyBlue;
            this.Aleatoire_BTN.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Aleatoire_BTN.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Aleatoire_BTN.Location = new System.Drawing.Point(767, 328);
            this.Aleatoire_BTN.Name = "Aleatoire_BTN";
            this.Aleatoire_BTN.Size = new System.Drawing.Size(244, 64);
            this.Aleatoire_BTN.TabIndex = 1;
            this.Aleatoire_BTN.Text = "Générer aléatoirement les chariots";
            this.Aleatoire_BTN.UseVisualStyleBackColor = false;
            this.Aleatoire_BTN.Click += new System.EventHandler(this.Aleatoire_BTN_Click);
            // 
            // Consigne_LBL
            // 
            this.Consigne_LBL.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Consigne_LBL.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Consigne_LBL.Location = new System.Drawing.Point(588, 16);
            this.Consigne_LBL.Name = "Consigne_LBL";
            this.Consigne_LBL.Size = new System.Drawing.Size(369, 203);
            this.Consigne_LBL.TabIndex = 2;
            this.Consigne_LBL.Text = resources.GetString("Consigne_LBL.Text");
            // 
            // Colis_Position_LBL
            // 
            this.Colis_Position_LBL.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Colis_Position_LBL.AutoSize = true;
            this.Colis_Position_LBL.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Colis_Position_LBL.Location = new System.Drawing.Point(762, 267);
            this.Colis_Position_LBL.Name = "Colis_Position_LBL";
            this.Colis_Position_LBL.Size = new System.Drawing.Size(101, 24);
            this.Colis_Position_LBL.TabIndex = 3;
            this.Colis_Position_LBL.Text = "Position x :";
            this.Colis_Position_LBL.Visible = false;
            // 
            // Colis_TB
            // 
            this.Colis_TB.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Colis_TB.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Colis_TB.Location = new System.Drawing.Point(896, 254);
            this.Colis_TB.Name = "Colis_TB";
            this.Colis_TB.Size = new System.Drawing.Size(168, 35);
            this.Colis_TB.TabIndex = 4;
            this.Colis_TB.Text = "4";
            this.Colis_TB.Visible = false;
            // 
            // Colis_Localisation_TB
            // 
            this.Colis_Localisation_TB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Colis_Localisation_TB.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Colis_Localisation_TB.Location = new System.Drawing.Point(896, 295);
            this.Colis_Localisation_TB.Name = "Colis_Localisation_TB";
            this.Colis_Localisation_TB.Size = new System.Drawing.Size(168, 35);
            this.Colis_Localisation_TB.TabIndex = 6;
            this.Colis_Localisation_TB.Text = "2";
            this.Colis_Localisation_TB.Visible = false;
            // 
            // Colis_hauteur_LBL
            // 
            this.Colis_hauteur_LBL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Colis_hauteur_LBL.AutoSize = true;
            this.Colis_hauteur_LBL.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Colis_hauteur_LBL.Location = new System.Drawing.Point(762, 349);
            this.Colis_hauteur_LBL.Name = "Colis_hauteur_LBL";
            this.Colis_hauteur_LBL.Size = new System.Drawing.Size(87, 24);
            this.Colis_hauteur_LBL.TabIndex = 7;
            this.Colis_hauteur_LBL.Text = "Hauteur :";
            this.Colis_hauteur_LBL.Visible = false;
            // 
            // Colis_Hauteur_TB
            // 
            this.Colis_Hauteur_TB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Colis_Hauteur_TB.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Colis_Hauteur_TB.Location = new System.Drawing.Point(896, 336);
            this.Colis_Hauteur_TB.Name = "Colis_Hauteur_TB";
            this.Colis_Hauteur_TB.Size = new System.Drawing.Size(168, 35);
            this.Colis_Hauteur_TB.TabIndex = 8;
            this.Colis_Hauteur_TB.Text = "3";
            this.Colis_Hauteur_TB.Visible = false;
            // 
            // Orientation_LBL
            // 
            this.Orientation_LBL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Orientation_LBL.AutoSize = true;
            this.Orientation_LBL.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Orientation_LBL.Location = new System.Drawing.Point(762, 383);
            this.Orientation_LBL.Name = "Orientation_LBL";
            this.Orientation_LBL.Size = new System.Drawing.Size(116, 24);
            this.Orientation_LBL.TabIndex = 9;
            this.Orientation_LBL.Text = "Orientation : ";
            this.Orientation_LBL.Visible = false;
            // 
            // Valider_BTN
            // 
            this.Valider_BTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Valider_BTN.BackColor = System.Drawing.Color.RoyalBlue;
            this.Valider_BTN.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Valider_BTN.Enabled = false;
            this.Valider_BTN.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Valider_BTN.ForeColor = System.Drawing.Color.Black;
            this.Valider_BTN.Location = new System.Drawing.Point(843, 428);
            this.Valider_BTN.Name = "Valider_BTN";
            this.Valider_BTN.Size = new System.Drawing.Size(134, 49);
            this.Valider_BTN.TabIndex = 11;
            this.Valider_BTN.Text = "Valider";
            this.Valider_BTN.UseVisualStyleBackColor = false;
            this.Valider_BTN.Visible = false;
            this.Valider_BTN.Click += new System.EventHandler(this.Valider_BTN_Click);
            // 
            // Orientation_LIST
            // 
            this.Orientation_LIST.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Orientation_LIST.FormattingEnabled = true;
            this.Orientation_LIST.Items.AddRange(new object[] {
            "Nord",
            "Sud"});
            this.Orientation_LIST.Location = new System.Drawing.Point(896, 377);
            this.Orientation_LIST.Name = "Orientation_LIST";
            this.Orientation_LIST.Size = new System.Drawing.Size(168, 30);
            this.Orientation_LIST.TabIndex = 12;
            this.Orientation_LIST.Visible = false;
            // 
            // Details_BTN
            // 
            this.Details_BTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Details_BTN.BackColor = System.Drawing.Color.RoyalBlue;
            this.Details_BTN.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Details_BTN.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Details_BTN.ForeColor = System.Drawing.Color.Black;
            this.Details_BTN.Location = new System.Drawing.Point(953, 85);
            this.Details_BTN.Name = "Details_BTN";
            this.Details_BTN.Size = new System.Drawing.Size(134, 49);
            this.Details_BTN.TabIndex = 17;
            this.Details_BTN.Text = "Détails";
            this.Details_BTN.UseVisualStyleBackColor = false;
            this.Details_BTN.Visible = false;
            this.Details_BTN.Click += new System.EventHandler(this.Details_BTN_Click_1);
            // 
            // Final_LBL
            // 
            this.Final_LBL.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Final_LBL.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Final_LBL.Location = new System.Drawing.Point(661, 204);
            this.Final_LBL.Name = "Final_LBL";
            this.Final_LBL.Size = new System.Drawing.Size(348, 60);
            this.Final_LBL.TabIndex = 23;
            this.Final_LBL.Text = "label1";
            this.Final_LBL.Visible = false;
            // 
            // Depot_BTN
            // 
            this.Depot_BTN.BackColor = System.Drawing.Color.LightSkyBlue;
            this.Depot_BTN.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Depot_BTN.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Depot_BTN.Location = new System.Drawing.Point(766, 266);
            this.Depot_BTN.Name = "Depot_BTN";
            this.Depot_BTN.Size = new System.Drawing.Size(244, 64);
            this.Depot_BTN.TabIndex = 24;
            this.Depot_BTN.Text = "Déposer le colis";
            this.Depot_BTN.UseVisualStyleBackColor = false;
            this.Depot_BTN.Visible = false;
            this.Depot_BTN.Click += new System.EventHandler(this.Depot_BTN_Click);
            // 
            // Nv_colis_BTN
            // 
            this.Nv_colis_BTN.BackColor = System.Drawing.Color.LightSkyBlue;
            this.Nv_colis_BTN.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Nv_colis_BTN.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Nv_colis_BTN.Location = new System.Drawing.Point(767, 398);
            this.Nv_colis_BTN.Name = "Nv_colis_BTN";
            this.Nv_colis_BTN.Size = new System.Drawing.Size(244, 64);
            this.Nv_colis_BTN.TabIndex = 25;
            this.Nv_colis_BTN.Text = "Faire un nouveau déplacement\r\n";
            this.Nv_colis_BTN.UseVisualStyleBackColor = false;
            this.Nv_colis_BTN.Visible = false;
            this.Nv_colis_BTN.Click += new System.EventHandler(this.Nv_colis_BTN_Click);
            // 
            // Affichage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1089, 559);
            this.Controls.Add(this.Nv_colis_BTN);
            this.Controls.Add(this.Depot_BTN);
            this.Controls.Add(this.Final_LBL);
            this.Controls.Add(this.Details_BTN);
            this.Controls.Add(this.Orientation_LIST);
            this.Controls.Add(this.Valider_BTN);
            this.Controls.Add(this.Orientation_LBL);
            this.Controls.Add(this.Colis_Hauteur_TB);
            this.Controls.Add(this.Colis_hauteur_LBL);
            this.Controls.Add(this.Colis_Localisation_TB);
            this.Controls.Add(this.Colis_Position_y_LBL);
            this.Controls.Add(this.Colis_TB);
            this.Controls.Add(this.Colis_Position_LBL);
            this.Controls.Add(this.Consigne_LBL);
            this.Controls.Add(this.Aleatoire_BTN);
            this.Controls.Add(this.Quitter_BTN);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Affichage";
            this.Text = "Affichage";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Colis_Position_y_LBL;
        private System.Windows.Forms.Button Quitter_BTN;
        private System.Windows.Forms.Button Aleatoire_BTN;
        private System.Windows.Forms.Label Consigne_LBL;
        private System.Windows.Forms.Label Colis_Position_LBL;
        private System.Windows.Forms.TextBox Colis_TB;
        private System.Windows.Forms.TextBox Colis_Localisation_TB;
        private System.Windows.Forms.Label Colis_hauteur_LBL;
        private System.Windows.Forms.TextBox Colis_Hauteur_TB;
        private System.Windows.Forms.Label Orientation_LBL;
        private System.Windows.Forms.Button Valider_BTN;
        private System.Windows.Forms.ListBox Orientation_LIST;
        private System.Windows.Forms.Button Details_BTN;
        private System.Windows.Forms.Label Final_LBL;
        private System.Windows.Forms.Button Depot_BTN;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button Nv_colis_BTN;

    }
}