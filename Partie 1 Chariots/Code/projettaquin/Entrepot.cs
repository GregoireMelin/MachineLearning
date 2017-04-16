using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace projettaquin
{
    public class Entrepot
    {
        private int[] tailleEntrepot = new int[2];
        public int[,] cell { get; private set; }

        public int Get_longueur_entrepot()  { return(tailleEntrepot[0]);}
        public int Get_largeur_entrepot() { return (tailleEntrepot[1]); }

        public Entrepot(int lignes, int colonnes)
        {
            tailleEntrepot[0] = lignes;
            tailleEntrepot[1] = colonnes;
            //Remplissage plan entrepot
            cell = new int[tailleEntrepot[0], tailleEntrepot[1]];

            for (int i = 0; i < tailleEntrepot[1]; i++)
            {
                for (int j = 0; j < tailleEntrepot[0]; j++)
                {
                    if ((i == 0) || (i == 1) || (i == tailleEntrepot[0] - 1) || (i == tailleEntrepot[0] - 2) || (j == 0) || (j == 1) || (j == tailleEntrepot[1] - 1) || (j == tailleEntrepot[1] - 2))
                        cell[i, j] = 0;
                    else if (i % 2 == 0)
                    {
                        if (((j > 1) && (j < tailleEntrepot[1] / 2 - 1)) || ((j > tailleEntrepot[1] / 2 + 1) && (j < tailleEntrepot[1] - 2)))
                            cell[i, j] = -1;
                        else
                            cell[i, j] = 0;
                    }
                    else
                        cell[i, j] = 0;
                }
            }
        }

    }
}
