using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projettaquin
{
    public class Emplacement : GenericNode
    {
        /*%%%%%%%%%%%%%  Attributs  %%%%%%%%%%%%%%%%%*/
        protected int x;
        protected int y;
        protected string orientation;

        protected int hauteur_reelle;
        protected int hauteur_attendue;

        /*%%%%%%%%%%%%%  Fin Attributs  %%%%%%%%%%%%%*/

        /*%%%%%%%%%%%%%  Fonctions  %%%%%%%%%%%%%%%%%*/
        //Constructeurs
        public Emplacement() : base()
        {
            x = 0;
            y = 0;
        }
        public Emplacement(int _x, int _y, string orientation, int hauteur) : base()
        {
            x = _x;
            y = _y;
            this.orientation = orientation;
            hauteur_attendue = hauteur;
            hauteur_reelle = 0;
        }
        //Accesseurs (Au cas où)
        public int GetX()
        {
            return (x);
        }

        public string Get_orientation() { return (orientation); }

        public int GetY() { return (y); }

        public void SetX(int _x) { x = _x; }
        public void SetY(int _y) { y = _y; }

        //Methodes
        public override bool IsEqual(GenericNode N2)
        {
            Emplacement E1 = (Emplacement)(N2);
            return (E1.x == this.x && E1.y == this.y && E1.orientation == this.orientation);
        }

        public override bool EndState(Emplacement final)
        {
            return (this.x == final.x && this.y == final.y);
        }

        public override double GetArcCost(GenericNode N2)
        {
            Emplacement succ = (Emplacement)N2;
            if (EndState(succ))
            {
                return (4 * hauteur_attendue + 10);
            }
            else
            {
                if (orientation == "Nord")
                {
                    if (succ.y == this.y - 1) { return (1); }
                    else { return (4); }
                }
                else if (orientation == "Sud")
                {
                    if (succ.y == this.y + 1) { return (1); }
                    else { return (4); }
                }
                else if (orientation == "Est")
                {
                    if (succ.x == this.x + 1) { return (1); }
                    else { return (4); }
                }
                else if (orientation == "Ouest")
                {
                    if (succ.x == this.x - 1) { return (1); }
                    else { return (4); }
                }
                else
                    return (0);
            }
        }

        public override List<GenericNode> GetListSucc()
        {
            // Initialisation
            int posx = x; int posy = y;
            //Du fait des deplacements cartesiens en deux dimensions, on a maximum 4 voisins par noeud.
            List<GenericNode> lsucc = new List<GenericNode>();


            #region Definition des 2 voisins : 4 angles
            /*MODELISATION :
                    [0,0]  0,1     ...     23,0   [24,0]
                     1,0                           24,1
                     ...                           ...
                     ...                           ...
                    0,23                          24,23
                   [0,24] 1,24     ...     23,24  [24,24] 
              */
            if (posx == 0 && posy == 0)
            {
                // pour le coin haut gauche [0,0]
                if (Program.entrepot.cell[1, 0] != 2) { lsucc.Add(new Emplacement(0, 1, "Sud", hauteur_attendue)); }
                if (Program.entrepot.cell[0, 1] != 2) { lsucc.Add(new Emplacement(1, 0, "Est", hauteur_attendue)); }
            }
            else if ((posx == Program.entrepot.Get_longueur_entrepot() - 1) && posy == 0)
            {
                // pour le coin du haut droit [24,0]
                if (Program.entrepot.cell[0, 23] != 2) { lsucc.Add(new Emplacement(23, 0, "Ouest", hauteur_attendue)); }
                if (Program.entrepot.cell[1, 24] != 2) { lsucc.Add(new Emplacement(24, 1, "Sud", hauteur_attendue)); }
            }
            else if (posx == 0 && posy == Program.entrepot.Get_largeur_entrepot() - 1)
            {
                // pour le coin bas gauche [0,24]
                if (Program.entrepot.cell[23, 0] != 2) { lsucc.Add(new Emplacement(0, 23, "Nord", hauteur_attendue)); }
                if (Program.entrepot.cell[24, 1] != 2) { lsucc.Add(new Emplacement(1, 24, "Est", hauteur_attendue)); }
            }
            else if ((posx == Program.entrepot.Get_longueur_entrepot() - 1) && (posy == Program.entrepot.Get_largeur_entrepot() - 1))
            {
                // pour le coin bas droit [24,24]
                if (Program.entrepot.cell[24, 23] != 2) { lsucc.Add(new Emplacement(23, 24, "Ouest", hauteur_attendue)); }
                if (Program.entrepot.cell[23, 24] != 2) { lsucc.Add(new Emplacement(24, 23, "Nord", hauteur_attendue)); }
            }
            #endregion

            #region Cas des marges hors coins : 3 voisins : contours hors coin
            /* MODELISATION :
                      ...     i,j-1   [i,j]   i,j+1  ...
                 
                      .              i+1,j            .
                   ig-1,jg                           a-1,b

                   [ig,jg]  ig,jg+1            a,b-1  [a,b]

                   ig+1,jg                           a+1,b

                      .              c-1,e             .

                     ...      c,e-1   [c,e]   c,e+1      ...


                    */
            //Marge gauche 
            else if ((posy < Program.entrepot.Get_largeur_entrepot() - 1) && posy > 0 && posx == 0)
            {

                if (Program.entrepot.cell[posy + 1, posx] != 2) { lsucc.Add(new Emplacement(posx, posy + 1, "Sud", hauteur_attendue)); }
                if (Program.entrepot.cell[posy - 1, posx] != 2) { lsucc.Add(new Emplacement(posx, posy - 1, "Nord", hauteur_attendue)); }
                if (Program.entrepot.cell[posy, posx + 1] != 2) { lsucc.Add(new Emplacement(posx + 1, posy, "Est", hauteur_attendue)); }
            }
            //Marge droite 
            else if (posy > 0 && (posy < Program.entrepot.Get_largeur_entrepot() - 1) && (posx == Program.entrepot.Get_longueur_entrepot() - 1))
            {
                if (Program.entrepot.cell[posy, posx - 1] != 2) { lsucc.Add(new Emplacement(posx - 1, posy, "Ouest", hauteur_attendue)); }
                if (Program.entrepot.cell[posy + 1, posx] != 2) { lsucc.Add(new Emplacement(posx, posy + 1, "Sud", hauteur_attendue)); }
                if (Program.entrepot.cell[posy - 1, posx] != 2) { lsucc.Add(new Emplacement(posx, posy - 1, "Nord", hauteur_attendue)); }
            }
            //Marge haute
            else if (posy == 0 && posx > 0 && (posx < Program.entrepot.Get_longueur_entrepot() - 1))
            {
                if (Program.entrepot.cell[posy, posx - 1] != 2) { lsucc.Add(new Emplacement(posx - 1, posy, "Ouest", hauteur_attendue)); }
                if (Program.entrepot.cell[posy, posx + 1] != 2) { lsucc.Add(new Emplacement(posx + 1, posy, "Est", hauteur_attendue)); }
                if (Program.entrepot.cell[posy + 1, posx] != 2) { lsucc.Add(new Emplacement(posx, posy + 1, "Sud", hauteur_attendue)); }
            }
            //Marge basse
            else if ((posy == Program.entrepot.Get_largeur_entrepot() - 1) && posx > 0 && (posx < Program.entrepot.Get_longueur_entrepot() - 1))
            {
                if (Program.entrepot.cell[posy, posx - 1] != 2) { lsucc.Add(new Emplacement(posx - 1, posy, "Ouest", hauteur_attendue)); }
                if (Program.entrepot.cell[posy, posx + 1] != 2) { lsucc.Add(new Emplacement(posx + 1, posy, "Est", hauteur_attendue)); }
                if (Program.entrepot.cell[posy - 1, posx] != 2) { lsucc.Add(new Emplacement(posx, posy - 1, "Nord", hauteur_attendue)); }
            }
            #endregion

            #region Autres cas : 4 voisins

            /*MODELISATION :
                              [i,j-1]

                                 |
                    [i-1,j] -- [i,j] -- [i+1,j]      VOISINS POTENTIELS POUR UNE CASE [i,j]
                                 |

                              [i,j+1]
                    */
            else
            {
                if (Program.entrepot.cell[posy, posx - 1] != -1 && Program.entrepot.cell[posy, posx - 1] != 2)
                {
                    lsucc.Add(new Emplacement(posx - 1, posy, "Ouest", hauteur_attendue));
                }
                if (Program.entrepot.cell[posy - 1, posx] != -1 && Program.entrepot.cell[posy - 1, posx] != 2)
                {
                    lsucc.Add(new Emplacement(posx, posy - 1, "Nord", hauteur_attendue));
                }
                if (Program.entrepot.cell[posy, posx + 1] != -1 && Program.entrepot.cell[posy, posx + 1] != 2)
                {
                    lsucc.Add(new Emplacement(posx + 1, posy, "Est", hauteur_attendue));
                }
                if (Program.entrepot.cell[posy + 1, posx] != -1 && Program.entrepot.cell[posy + 1, posx] != 2)
                {
                    lsucc.Add(new Emplacement(posx, posy + 1, "Sud", hauteur_attendue));
                }
                // on vérifie que les cases autour ne soient ni des chariots ni des étagères
            }
            #endregion
            return (lsucc);
        }

        public override void CalculeHCost(Emplacement final)
        {
            // distance de Manhattan
            if (this.y == final.y)
                this.HCost = HCost + (Math.Abs(x - final.x) + Math.Abs(y - final.y));
            else if (this.x == final.x)
                this.HCost = HCost + (Math.Abs(x - final.x) + Math.Abs(y - final.y)) + 9;
            else
                this.HCost = HCost + (Math.Abs(x - final.x) + Math.Abs(y - final.y)) + 6; //Le chariot se reoriente et il fait un virage
            
        }



        // pour les overrides avec l'autre classe
        public override bool EndState(Emplacement_Q3 final)
        {
            return (false);
        }

        public override void CalculeHCost(Emplacement_Q3 final)
        {
           
        }



        public override string ToString()
        {
            return ("x = " + x + " et y = " + y);
        }

        /*%%%%%%%%%%%%%  Fin Fonctions  %%%%%%%%%%%%%*/
    }
}
