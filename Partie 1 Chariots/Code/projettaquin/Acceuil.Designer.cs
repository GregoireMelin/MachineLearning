namespace projettaquin
{
    partial class Acceuil
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Acceuil));
            this.Q_2_BTN = new System.Windows.Forms.Button();
            this.Chariot_LBL = new System.Windows.Forms.Label();
            this.Chariot_TB = new System.Windows.Forms.TextBox();
            this.Titre_LBL = new System.Windows.Forms.Label();
            this.Longueur_TB = new System.Windows.Forms.TextBox();
            this.Longueur_LBL = new System.Windows.Forms.Label();
            this.Largeur_TB = new System.Windows.Forms.TextBox();
            this.Largueur_LBL = new System.Windows.Forms.Label();
            this.Q_3_BTN = new System.Windows.Forms.Button();
            this.Explication_3_LBL = new System.Windows.Forms.Label();
            this.Explication_2_LBL = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Q_2_BTN
            // 
            this.Q_2_BTN.BackColor = System.Drawing.Color.RoyalBlue;
            this.Q_2_BTN.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Q_2_BTN.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Q_2_BTN.ForeColor = System.Drawing.Color.Black;
            this.Q_2_BTN.Location = new System.Drawing.Point(470, 430);
            this.Q_2_BTN.Name = "Q_2_BTN";
            this.Q_2_BTN.Size = new System.Drawing.Size(134, 53);
            this.Q_2_BTN.TabIndex = 0;
            this.Q_2_BTN.Text = "Question 2";
            this.Q_2_BTN.UseVisualStyleBackColor = false;
            this.Q_2_BTN.Click += new System.EventHandler(this.Valider_BTN_Click);
            // 
            // Chariot_LBL
            // 
            this.Chariot_LBL.AutoSize = true;
            this.Chariot_LBL.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Chariot_LBL.Location = new System.Drawing.Point(90, 193);
            this.Chariot_LBL.Name = "Chariot_LBL";
            this.Chariot_LBL.Size = new System.Drawing.Size(184, 23);
            this.Chariot_LBL.TabIndex = 1;
            this.Chariot_LBL.Text = "Nombre de chariots :";
            // 
            // Chariot_TB
            // 
            this.Chariot_TB.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Chariot_TB.Location = new System.Drawing.Point(333, 190);
            this.Chariot_TB.Name = "Chariot_TB";
            this.Chariot_TB.Size = new System.Drawing.Size(168, 32);
            this.Chariot_TB.TabIndex = 2;
            this.Chariot_TB.Text = "15";
            // 
            // Titre_LBL
            // 
            this.Titre_LBL.BackColor = System.Drawing.SystemColors.Control;
            this.Titre_LBL.Font = new System.Drawing.Font("Castellar", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Titre_LBL.ForeColor = System.Drawing.Color.RoyalBlue;
            this.Titre_LBL.Location = new System.Drawing.Point(32, 10);
            this.Titre_LBL.Name = "Titre_LBL";
            this.Titre_LBL.Size = new System.Drawing.Size(630, 132);
            this.Titre_LBL.TabIndex = 3;
            this.Titre_LBL.Text = "Team\'arie avec Alexandre et Grégo\r\n";
            this.Titre_LBL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Longueur_TB
            // 
            this.Longueur_TB.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Longueur_TB.Location = new System.Drawing.Point(332, 253);
            this.Longueur_TB.Name = "Longueur_TB";
            this.Longueur_TB.Size = new System.Drawing.Size(169, 32);
            this.Longueur_TB.TabIndex = 5;
            this.Longueur_TB.Text = "25";
            // 
            // Longueur_LBL
            // 
            this.Longueur_LBL.AutoSize = true;
            this.Longueur_LBL.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Longueur_LBL.Location = new System.Drawing.Point(53, 252);
            this.Longueur_LBL.Name = "Longueur_LBL";
            this.Longueur_LBL.Size = new System.Drawing.Size(209, 23);
            this.Longueur_LBL.TabIndex = 4;
            this.Longueur_LBL.Text = "Longueur de l\'entrepot :";
            // 
            // Largeur_TB
            // 
            this.Largeur_TB.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Largeur_TB.Location = new System.Drawing.Point(333, 306);
            this.Largeur_TB.Name = "Largeur_TB";
            this.Largeur_TB.Size = new System.Drawing.Size(168, 32);
            this.Largeur_TB.TabIndex = 7;
            this.Largeur_TB.Text = "25";
            // 
            // Largueur_LBL
            // 
            this.Largueur_LBL.AutoSize = true;
            this.Largueur_LBL.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Largueur_LBL.Location = new System.Drawing.Point(80, 309);
            this.Largueur_LBL.Name = "Largueur_LBL";
            this.Largueur_LBL.Size = new System.Drawing.Size(193, 23);
            this.Largueur_LBL.TabIndex = 6;
            this.Largueur_LBL.Text = "Largeur de l\'entrepot :";
            // 
            // Q_3_BTN
            // 
            this.Q_3_BTN.BackColor = System.Drawing.Color.RoyalBlue;
            this.Q_3_BTN.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Q_3_BTN.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Q_3_BTN.ForeColor = System.Drawing.Color.Black;
            this.Q_3_BTN.Location = new System.Drawing.Point(30, 430);
            this.Q_3_BTN.Name = "Q_3_BTN";
            this.Q_3_BTN.Size = new System.Drawing.Size(134, 53);
            this.Q_3_BTN.TabIndex = 8;
            this.Q_3_BTN.Text = "Question 3";
            this.Q_3_BTN.UseVisualStyleBackColor = false;
            this.Q_3_BTN.Click += new System.EventHandler(this.Valider_BTN_Click);
            // 
            // Explication_3_LBL
            // 
            this.Explication_3_LBL.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Explication_3_LBL.Location = new System.Drawing.Point(408, 486);
            this.Explication_3_LBL.Name = "Explication_3_LBL";
            this.Explication_3_LBL.Size = new System.Drawing.Size(283, 128);
            this.Explication_3_LBL.TabIndex = 9;
            this.Explication_3_LBL.Text = "Dans cette question, les chariots bougent les uns après les autres.";
            // 
            // Explication_2_LBL
            // 
            this.Explication_2_LBL.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Explication_2_LBL.Location = new System.Drawing.Point(2, 486);
            this.Explication_2_LBL.Name = "Explication_2_LBL";
            this.Explication_2_LBL.Size = new System.Drawing.Size(327, 115);
            this.Explication_2_LBL.TabIndex = 10;
            this.Explication_2_LBL.Text = "Dans cette question, les chariots peuvent tous bouger en même temps.";
            // 
            // Acceuil
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(691, 611);
            this.Controls.Add(this.Explication_2_LBL);
            this.Controls.Add(this.Explication_3_LBL);
            this.Controls.Add(this.Q_3_BTN);
            this.Controls.Add(this.Largeur_TB);
            this.Controls.Add(this.Largueur_LBL);
            this.Controls.Add(this.Longueur_TB);
            this.Controls.Add(this.Longueur_LBL);
            this.Controls.Add(this.Titre_LBL);
            this.Controls.Add(this.Chariot_TB);
            this.Controls.Add(this.Chariot_LBL);
            this.Controls.Add(this.Q_2_BTN);
            this.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Acceuil";
            this.Text = "Initialisation";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Q_2_BTN;
        private System.Windows.Forms.Label Chariot_LBL;
        private System.Windows.Forms.TextBox Chariot_TB;
        private System.Windows.Forms.Label Titre_LBL;
        private System.Windows.Forms.TextBox Longueur_TB;
        private System.Windows.Forms.Label Longueur_LBL;
        private System.Windows.Forms.TextBox Largeur_TB;
        private System.Windows.Forms.Label Largueur_LBL;
        private System.Windows.Forms.Button Q_3_BTN;
        private System.Windows.Forms.Label Explication_3_LBL;
        private System.Windows.Forms.Label Explication_2_LBL;


    }
}

