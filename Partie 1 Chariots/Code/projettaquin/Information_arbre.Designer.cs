namespace projettaquin
{
    partial class Information_arbre
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
            this.Affichage_Arbre_TV = new System.Windows.Forms.TreeView();
            this.Chemin_LIST = new System.Windows.Forms.ListBox();
            this.Valider_BTN = new System.Windows.Forms.Button();
            this.Fermes_LBL = new System.Windows.Forms.Label();
            this.Ouvert_LBL = new System.Windows.Forms.Label();
            this.Final_LBL = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Affichage_Arbre_TV
            // 
            this.Affichage_Arbre_TV.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Affichage_Arbre_TV.Location = new System.Drawing.Point(359, 53);
            this.Affichage_Arbre_TV.Name = "Affichage_Arbre_TV";
            this.Affichage_Arbre_TV.Size = new System.Drawing.Size(235, 238);
            this.Affichage_Arbre_TV.TabIndex = 19;
            // 
            // Chemin_LIST
            // 
            this.Chemin_LIST.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Chemin_LIST.FormattingEnabled = true;
            this.Chemin_LIST.Location = new System.Drawing.Point(676, 53);
            this.Chemin_LIST.Name = "Chemin_LIST";
            this.Chemin_LIST.Size = new System.Drawing.Size(252, 238);
            this.Chemin_LIST.TabIndex = 18;
            // 
            // Valider_BTN
            // 
            this.Valider_BTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Valider_BTN.BackColor = System.Drawing.Color.RoyalBlue;
            this.Valider_BTN.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Valider_BTN.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Valider_BTN.ForeColor = System.Drawing.Color.Black;
            this.Valider_BTN.Location = new System.Drawing.Point(965, 286);
            this.Valider_BTN.Name = "Valider_BTN";
            this.Valider_BTN.Size = new System.Drawing.Size(134, 49);
            this.Valider_BTN.TabIndex = 20;
            this.Valider_BTN.Text = "Fermer";
            this.Valider_BTN.UseVisualStyleBackColor = false;
            this.Valider_BTN.Click += new System.EventHandler(this.Valider_BTN_Click);
            // 
            // Fermes_LBL
            // 
            this.Fermes_LBL.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Fermes_LBL.AutoSize = true;
            this.Fermes_LBL.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Fermes_LBL.Location = new System.Drawing.Point(8, 195);
            this.Fermes_LBL.Name = "Fermes_LBL";
            this.Fermes_LBL.Size = new System.Drawing.Size(75, 24);
            this.Fermes_LBL.TabIndex = 24;
            this.Fermes_LBL.Text = "Fermes";
            // 
            // Ouvert_LBL
            // 
            this.Ouvert_LBL.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Ouvert_LBL.AutoSize = true;
            this.Ouvert_LBL.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Ouvert_LBL.Location = new System.Drawing.Point(23, 103);
            this.Ouvert_LBL.Name = "Ouvert_LBL";
            this.Ouvert_LBL.Size = new System.Drawing.Size(60, 24);
            this.Ouvert_LBL.TabIndex = 23;
            this.Ouvert_LBL.Text = "label1";
            // 
            // Final_LBL
            // 
            this.Final_LBL.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Final_LBL.AutoSize = true;
            this.Final_LBL.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Final_LBL.Location = new System.Drawing.Point(23, 37);
            this.Final_LBL.Name = "Final_LBL";
            this.Final_LBL.Size = new System.Drawing.Size(60, 24);
            this.Final_LBL.TabIndex = 22;
            this.Final_LBL.Text = "label1";
            // 
            // Information_arbre
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1144, 360);
            this.Controls.Add(this.Fermes_LBL);
            this.Controls.Add(this.Ouvert_LBL);
            this.Controls.Add(this.Final_LBL);
            this.Controls.Add(this.Valider_BTN);
            this.Controls.Add(this.Affichage_Arbre_TV);
            this.Controls.Add(this.Chemin_LIST);
            this.Name = "Information_arbre";
            this.Text = "Information_arbre";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView Affichage_Arbre_TV;
        private System.Windows.Forms.ListBox Chemin_LIST;
        private System.Windows.Forms.Button Valider_BTN;
        private System.Windows.Forms.Label Fermes_LBL;
        private System.Windows.Forms.Label Ouvert_LBL;
        private System.Windows.Forms.Label Final_LBL;
    }
}