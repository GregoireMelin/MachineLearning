using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projettaquin
{
    public class Emplacement_Q3 : GenericNode
    {
        /*%%%%%%%%%%%%%  Attributs  %%%%%%%%%%%%%%%%%*/
        protected int x;
        protected int y;
        protected string orientation;
        protected int hauteurColis;
        public int attente { get; set; }
        // cet attribut permet de savoir s'il y a un chariot en attente



        /*%%%%%%%%%%%%%  Fin Attributs  %%%%%%%%%%%%%*/

        /*%%%%%%%%%%%%%  Fonctions  %%%%%%%%%%%%%%%%%*/
        //Constructeurs
        public Emplacement_Q3()
            : base()
        {
            x = 0;
            y = 0;
        }
        public Emplacement_Q3(int _x, int _y, string orientation, int hauteur)
            : base()
        {
            x = _x;
            y = _y;
            this.orientation = orientation;
            hauteurColis = hauteur;
        }
        //Accesseurs (Au cas où)
        public int GetX()
        {
            return (x);
        }

        public string Get_orientation() { return (orientation); }

        public int GetY()
        {
            return (y);
        }
        public void SetX(int _x)
        {
            x = _x;
        }

        public void SetY(int _y)
        {
            y = _y;
        }

        //Methodes
        public override bool IsEqual(GenericNode N2)
        {
            Emplacement_Q3 E1 = (Emplacement_Q3)(N2);
            return (E1.x == this.x && E1.y == this.y && E1.orientation == this.orientation);
        }

        // POUR L'override il était nécessaire de faire une autre fonction qui prennant en paramète
        // un emplacement pour la question 3 à cause de la duplication recommandée de la classe Emplacement 
        // pour la réalisation des deux questions.
        public override bool EndState(Emplacement_Q3 final)
        {
            return (this.x == final.x && this.y == final.y);
        }

        public override double GetArcCost(GenericNode N2)
        {
            Emplacement_Q3 succ = (Emplacement_Q3)N2;
            //return (1);
            if (EndState(succ))
            {
                return (4 * hauteurColis + 10);
            }
            else
            {
                if (orientation == "Nord")
                {
                    if (succ.y == this.y - 1)
                        return (1);
                    else
                        return (4);
                }
                else if (orientation == "Sud")
                {
                    if (succ.y == this.y + 1)
                        return (1);
                    else
                        return (4);
                }
                else if (orientation == "Est")
                {
                    if (succ.x == this.x + 1)
                        return (1);
                    else
                        return (4);
                }
                else if (orientation == "Ouest")
                {
                    if (succ.x == this.x - 1)
                        return (1);
                    else
                        return (4);
                }
                else
                    return (0);
            }
        }

        public override List<GenericNode> GetListSucc()
        {
            #region Initialisation
            int posx = x; int posy = y;
            //Du fait des deplacements cartesiens en deux dimensions, on a maximum 4 voisins par noeud.
            int[,] tab2 = new int[4, 2];
            List<GenericNode> lsucc = new List<GenericNode>();

            #endregion

            #region Definition des 2 voisins : 4 angles
            /*MODELISATION :
                    [0,0]  0,1     ...       [24,0]
                     1,0                        

                     ...                           ...

                                             24,23
                      [0,24]  ...     23,24 [24,24] 
                    */
            if (posx == 0 && posy == 0)
            {
                // pour le coin haut gauche [0,0]
                if (Program.entrepot.cell[1, 0] != 2) { lsucc.Add(new Emplacement_Q3(0, 1, "Sud", hauteurColis)); }
                if (Program.entrepot.cell[0, 1] != 2) { lsucc.Add(new Emplacement_Q3(1, 0, "Est", hauteurColis)); }
            }
            else if ((posx == Program.entrepot.Get_longueur_entrepot() - 1) && posy == 0)
            {
                // pour le coin du haut droit [24,0]
                if (Program.entrepot.cell[0, 23] != 2) { lsucc.Add(new Emplacement_Q3(23, 0, "Ouest", hauteurColis)); }
                if (Program.entrepot.cell[1, 24] != 2) { lsucc.Add(new Emplacement_Q3(24, 1, "Sud", hauteurColis)); }
            }
            else if (posx == 0 && posy == Program.entrepot.Get_largeur_entrepot() - 1)
            {
                // pour le coin bas gauche [0,24]
                if (Program.entrepot.cell[23, 0] != 2) { lsucc.Add(new Emplacement_Q3(0, 23, "Nord", hauteurColis)); }
                if (Program.entrepot.cell[24, 1] != 2) { lsucc.Add(new Emplacement_Q3(1, 24, "Est", hauteurColis)); }
            }
            else if ((posx == Program.entrepot.Get_longueur_entrepot() - 1) && (posy == Program.entrepot.Get_largeur_entrepot() - 1))
            {
                // pour le coin bas droit [24,24]
                if (Program.entrepot.cell[24, 23] != 2) { lsucc.Add(new Emplacement_Q3(23, 24, "Ouest", hauteurColis)); }
                if (Program.entrepot.cell[23, 24] != 2) { lsucc.Add(new Emplacement_Q3(24, 23, "Nord", hauteurColis)); }
            }
            #endregion

            #region Cas des marges hors coins : 3 voisins : contours hors coin
            /* MODELISATION :
                            ih,jh-1   [ih,jh]   ih,jh+1

                                      ih+1,jh
                   ig-1,jg                               id-1,jd 

                   [ig,jg]  ig,jg+1             id,jd-1  [id,jd]

                   ig+1,jg                               id+1,jd

                                     id-1,jb

                           ib,jb-1   [ib,jb]   ib,jb+1


                    */
            //Marge gauche 
            else if ((posy < Program.entrepot.Get_largeur_entrepot() - 1) && posy > 0 && posx == 0)
            {

                if (Program.entrepot.cell[posy + 1, posx] != 2) { lsucc.Add(new Emplacement_Q3(posx, posy + 1, "Sud", hauteurColis)); }
                if (Program.entrepot.cell[posy - 1, posx] != 2) { lsucc.Add(new Emplacement_Q3(posx, posy - 1, "Nord", hauteurColis)); }
                if (Program.entrepot.cell[posy, posx + 1] != 2) { lsucc.Add(new Emplacement_Q3(posx + 1, posy, "Est", hauteurColis)); }
            }
            //Marge droite 
            else if (posy > 0 && (posy < Program.entrepot.Get_largeur_entrepot() - 1) && (posx == Program.entrepot.Get_longueur_entrepot() - 1))
            {
                if (Program.entrepot.cell[posy, posx - 1] != 2) { lsucc.Add(new Emplacement_Q3(posx - 1, posy, "Ouest", hauteurColis)); }
                if (Program.entrepot.cell[posy + 1, posx] != 2) { lsucc.Add(new Emplacement_Q3(posx, posy + 1, "Sud", hauteurColis)); }
                if (Program.entrepot.cell[posy - 1, posx] != 2) { lsucc.Add(new Emplacement_Q3(posx, posy - 1, "Nord", hauteurColis)); }
            }
            //Marge haute
            else if (posy == 0 && posx > 0 && (posx < Program.entrepot.Get_longueur_entrepot() - 1))
            {
                if (Program.entrepot.cell[posy, posx - 1] != 2) { lsucc.Add(new Emplacement_Q3(posx - 1, posy, "Ouest", hauteurColis)); }
                if (Program.entrepot.cell[posy, posx + 1] != 2) { lsucc.Add(new Emplacement_Q3(posx + 1, posy, "Est", hauteurColis)); }
                if (Program.entrepot.cell[posy + 1, posx] != 2) { lsucc.Add(new Emplacement_Q3(posx, posy + 1, "Sud", hauteurColis)); }
            }
            //Marge basse
            else if ((posy == Program.entrepot.Get_largeur_entrepot() - 1) && posx > 0 && (posx < Program.entrepot.Get_longueur_entrepot() - 1))
            {
                if (Program.entrepot.cell[posy, posx - 1] != 2) { lsucc.Add(new Emplacement_Q3(posx - 1, posy, "Ouest", hauteurColis)); }
                if (Program.entrepot.cell[posy, posx + 1] != 2) { lsucc.Add(new Emplacement_Q3(posx + 1, posy, "Est", hauteurColis)); }
                if (Program.entrepot.cell[posy - 1, posx] != 2) { lsucc.Add(new Emplacement_Q3(posx, posy - 1, "Nord", hauteurColis)); }
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
                    lsucc.Add(new Emplacement_Q3(posx - 1, posy, "Ouest", hauteurColis));
                }
                if (Program.entrepot.cell[posy - 1, posx] != -1 && Program.entrepot.cell[posy - 1, posx] != 2)
                {
                    lsucc.Add(new Emplacement_Q3(posx, posy - 1, "Nord", hauteurColis));
                }
                if (Program.entrepot.cell[posy, posx + 1] != -1 && Program.entrepot.cell[posy, posx + 1] != 2)
                {
                    lsucc.Add(new Emplacement_Q3(posx + 1, posy, "Est", hauteurColis));
                }
                if (Program.entrepot.cell[posy + 1, posx] != -1 && Program.entrepot.cell[posy + 1, posx] != 2)
                {
                    lsucc.Add(new Emplacement_Q3(posx, posy + 1, "Sud", hauteurColis));
                }
                // on vérifie que les cases autour ne soient ni des chariots ni des étagères
            }
            #endregion
            return (lsucc);
        }

        public override void CalculeHCost(Emplacement_Q3 final)
        {
            // pour la question 1 : distance de Man
            if (this.y == final.y)
                this.HCost = HCost + (Math.Abs(x - final.x) + Math.Abs(y - final.y));
            else if (this.x == final.x)
                this.HCost = HCost + (Math.Abs(x - final.x) + Math.Abs(y - final.y)) + 9;
            else
                this.HCost = HCost + (Math.Abs(x - final.x) + Math.Abs(y - final.y)) + 6; //Le chariot se reorient et il fait un virage
            // pour la question 2 : 
        }


        public override bool EndState(Emplacement final)
        {
            return (this.x == final.GetX() && this.y == final.GetY());
        }

        public override void CalculeHCost(Emplacement final)
        {
            
        }

        public override string ToString()
        {
            return ("x = " + x + " et y = " + y);
        }

        /*%%%%%%%%%%%%%  Fin Fonctions  %%%%%%%%%%%%%*/
    }
}
