using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace projettaquin
{
    class Chariot_prioritaire : Chariot
    {

        //pour un chariot prioraitre QUESTION 3 : mémoriser les chemins
        public List<GenericNode> chemin { get; set; }
        private int compteur ;

        public void Avancer_chemin() { compteur++; }
        public int Get_compteur() {return(compteur);}

        // CONSTRUCTEURS
        // utilisation du contrusteur de la classe mère
        public Chariot_prioritaire(int cle, int x,int y,string orientation,int hauteur): base (x,y,orientation,hauteur)
        {
            _nom = ""+cle;
            Set_cle(cle);
            chemin = null;
            compteur = 0;
        }

       



        // Affichage
        public override string ToString()
        {
            return ("Je suis "+_nom+" à ("+_x+" ,"+_y+") avec une orientation de "+_orientation+" et une hauteur de"+_hauteur+"m.");
        }

    }
}
