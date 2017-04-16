using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace projettaquin
{
    public class Colis
    {
        //ATTRIBUTS
        public int _x { get; set; }
        public int _y { get; set; }
        public int _hauteur { get; set; }
        public string _orientation { get; set; }

        //CONSTRUCTEURS
        public Colis()
        {
            _x = 0;
            _y = 0;
            _hauteur = 0;
            _orientation = "Nord";
        }
        public Colis(int x,int y,int hauteur, string orientation)
        {
            _x = x;
            _y = y;
            _hauteur = hauteur;
            _orientation = orientation;
        }

    }
}
