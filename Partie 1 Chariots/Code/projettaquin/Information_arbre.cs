using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace projettaquin
{
    public partial class Information_arbre : Form
    {
        public Information_arbre(List<GenericNode> chemin , Graph nul, Chariot chariot_choisi )
        {
            InitializeComponent();
            Affichage_Arbre_TV.Visible = true;
            Chemin_LIST.Visible = true;

            if (chemin.Count == 0)
            {
                Ouvert_LBL.Text = " ... ";
                Fermes_LBL.Text = "...";
                Final_LBL.Text = "Pas de solution";
            }
            else
            {
                Final_LBL.Text = "Une solution a été trouvée";
                foreach (GenericNode N in chemin)
                {
                    Chemin_LIST.Items.Add(N);
                }
                Ouvert_LBL.Text = "Nb noeuds des ouverts : " + nul.CountInOpenList().ToString();
                Fermes_LBL.Text = "Nb noeuds des fermés : " + nul.CountInClosedList().ToString();
                nul.GetSearchTree(Affichage_Arbre_TV);
            }
        }

        private void Valider_BTN_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
