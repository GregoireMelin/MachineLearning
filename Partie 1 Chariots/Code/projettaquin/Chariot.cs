using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace projettaquin
{
    public class Chariot
    {
        
        // IDENTIFICATION CHARIOT
        private static int _id=0;
        private int cle;
        public string _nom { get; set; }
        // POSITION DU CHARIOT
        public int _x { get; set; } // Position X : 0- tailleEntrepot[0] -1 pour la longueur
        public int _y { get; set; } // Position Y : 0-tailleEntrepot[1] -1 pour la largeur
        public string _orientation { get; set; } // Orientation : "Nord" ou "Sud"
        public int _hauteur { get; set; }// Hauteur 

        public bool enLivraison { get; set; }
        public bool chercher_un_colis  { get; set;}

        // pour faire des rotations
        public bool rotation { get; set;}
        public int rotation_temps { get; set; }

        // pour le dépot
        public bool depot { get; set; }
        public int depot_temps { get; set; }

        

        public int Get_cle_chariot() { return (cle); }
        public void Remise_a_zero() { _id = 0; }

        // CONSTRUCTEURS
        public Chariot()
        {        
            _id++;
            cle = _id;
            _nom = "Random Chariot";
            _x = 0;
            _y = 0;
            _orientation = "n";
            _hauteur = 0;
            enLivraison = false;
            chercher_un_colis = false;
            rotation = false;
            rotation_temps = 10;
            depot = false;
            depot_temps = 0; 
        }

        public Chariot(int x,int y,string orientation,int hauteur)
        {
            _id++;
            cle = _id;
            _nom = _id.ToString();
            _x = x;
            _y = y;
            _orientation = orientation;
            _hauteur = hauteur;
            enLivraison = false;
            chercher_un_colis = false;
            rotation = false;
            rotation_temps = 10;
            depot = false;
            depot_temps = 0; 
        }

        public Chariot(int x, int y)
        {
            _id++;
            cle = _id;
            _nom = "Chariot "+_id+" BadAss";
            _x = x;
            _y = y;
            // on choisit aléatoirement l'orientation du chariot
            Random rdn = new Random();
            int aleatoire = rdn.Next(0,1);
            if (aleatoire > 0.29) { _orientation = "Nord"; }
            else { _orientation = "Sud"; }
            // par défaut la hauteur d'un chariot est à 0
            _hauteur = 0 ;
            chercher_un_colis = false;
            rotation = false;
            rotation_temps = 10;
            depot = false;
            depot_temps = 0; 
        }


        public Chariot(string nom,int x,int y,string orientation,int hauteur)
        {
            _id++;
            cle = _id;
            _nom = nom;
            _x = x;
            _y = y;
            _orientation = orientation;
            _hauteur = hauteur;
            chercher_un_colis = false;
            rotation = false;
            rotation_temps = 10;
            depot = false;
            depot_temps = 0; 
        }

        //Acesseurs
        protected void Set_cle(int code) { cle = code; }

        // FONCTIONS
        // Actions
        public void seDeplacer(int xf, int yf, string orientationf, int hauteurf)
        {
            _x = xf;
            _y = yf;
            _orientation = orientationf;
            _hauteur = hauteurf;
        }

        // Affichage
        public override string ToString()
        {
            return ("Je suis "+_nom+" à ("+_x+" ,"+_y+") avec une orientation de "+_orientation+" et une hauteur de"+_hauteur+"m.");
        }

      

    }
}
