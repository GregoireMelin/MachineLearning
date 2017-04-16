using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projettaquin
{
    public partial class Acceuil : Form
    {
        

        
        public Acceuil()
        {
            InitializeComponent();
            
        }

       

        private void Valider_BTN_Click(object sender, EventArgs e)
        {
            // prendre les informations données par l'utilisateur
          
            // pour le nombre de chariots
            int nb_chariots = 0 ;
            try { nb_chariots = Convert.ToInt32(Chariot_TB.Text); }
            catch { nb_chariots = 5 ;}
            // pour la largeur de l'entrepot
            int largeur = 0 ;
            try { largeur = Convert.ToInt32(Largeur_TB.Text); }
            catch { largeur = 25 ;}
            // pour la longeur
            int longueur = 0 ;
            try { longueur = Convert.ToInt32(Largeur_TB.Text); }
            catch { longueur = 25 ;}

            Form suivant;
            if ( ((Button)sender).Name == "Q_2_BTN")
            {// les chariots sont statiques
                suivant = new Affichage(nb_chariots, longueur, largeur);
            }
            else 
            {  // les chariots ne sont pas statiques
                if (nb_chariots > largeur) { nb_chariots = largeur; }
                suivant = new Question_3(nb_chariots, longueur, largeur);
            }
            suivant.ShowDialog();
        }

 



    }
}
