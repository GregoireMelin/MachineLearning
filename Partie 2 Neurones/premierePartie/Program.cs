using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace premierePartie
{
    class Program
    {
        //Methodes
        public static int calculeSortie(double entree1, double entree2, double[] poids)
        {
            //Calcul de la somme ponderee
            double somme = entree1 * poids[0] + entree2 * poids[1] + 1 * poids[2];

            //Seuillage
            return (somme >= 0) ? 1 : 0; //Si somme superieure a 1, Sortie Calculee recoit 1 sinon elle recoit 0
            //Definition seuil
        }
        public static bool condition(int[] sortiesCalculees, int[] sortieDonnees)
        {
            bool verif = true;
            for (int i=0; i < sortieDonnees.Length; i++)
            {
                if (sortieDonnees[i] != sortiesCalculees[i])
                    verif = false;
            }
            return (verif);
        }
        static void Main(string[] args)
        {
            //Donnees fournies
            double[,] entrees = new double[,] { { 36.1, 17 }, { 41.1, 16.5 }, { 47.9, 18 }, { 47, 18.5 }, { 49.8, 22 }, { 48.5, 21 }, { 47.8, 11.7 }, { 55.5, 16.4 }, { 62.0, 13.0 }, { 64.1, 22 }, { 64.3, 18.5 }, { 65.3, 21 } };
            int[] sorties = new int[] { 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1 };

            //Initialisation des poids aleatoire
            Random r = new Random(4); 
            double[] poids = { r.NextDouble(), r.NextDouble(), r.NextDouble() };

            //Instanciation des parametres 
            int iteration = 0;
            int iterMax = 200;
            int[] sortieCalc = new int[sorties.Length];
            int ErreursTotales = 0;

            //Boucle d'apprentissage
            while (!condition(sortieCalc,sorties) && iteration<iterMax) 
            {
                //Nouvelle iteration
                int erreurGlobale = 0;
                iteration++;
                Console.WriteLine("\n \n ________iteration {0}___________________________________________________________________________", iteration);
                for (int i = 0; i < sorties.Length; i++)
                {
                    Console.WriteLine("\n ############ Poids en debut de boucle ############");
                    Console.WriteLine("W1= {0}", poids[0]);
                    Console.WriteLine("W2= {0}", poids[1]);
                    Console.WriteLine("W3= {0}", poids[2]);

                    //Calcul de la sortie par somme ponderee+seuillage
                    int sortieCalculee = calculeSortie(entrees[i, 0], entrees[i, 1], poids);
                    Console.WriteLine("Sortie = {0}", sortieCalculee);
                    sortieCalc[i] = sortieCalculee;
                    //Difference entre la sortie donnee et la sortie calculee
                    // 0 - 0 =   OK : même sortie
                    // 1 - 1 =   OK : même sortie
                    // 0 - 1 =   Erreur : Sortie differente 
                    // 1 - 0 =   Erreur : Sortie differente
                    //Modification des poids en fonction du resultat
                    if(sortieCalculee==1 && sorties[i]==0)
                    {
                        poids[0] -= entrees[i,0];
                        poids[1] -= entrees[i, 1];
                        poids[2] -= 1;
                        erreurGlobale++;
                    }
                    if (sortieCalculee == 0 && sorties[i] == 1)
                    {
                        poids[0] += entrees[i, 0];
                        poids[1] += entrees[i, 1];
                        poids[2] += 1;
                        erreurGlobale++;
                    }
                    //Affichage
                    Console.WriteLine("\n ########## Actualisation du poids ##############");
                    Console.WriteLine(" W1= {0}", poids[0]);
                    Console.WriteLine("W2= {0}", poids[1]);
                    Console.WriteLine("W3= {0}", poids[2]);

                    //Affichage
                    Console.WriteLine("Nombre d'erreurs actuels : {0}", erreurGlobale);
                }
                condition(sortieCalc, sorties);
                ErreursTotales += erreurGlobale;
            }
            Console.WriteLine("Resultats: ");
            Console.WriteLine("W1 = {0}",poids[0]);
            Console.WriteLine("W2 = {0}", poids[1]);
            Console.WriteLine("W3 = {0}", poids[2]);
            Console.WriteLine("Nombre d'iteration : {0}", iteration);
            Console.WriteLine("Nombre erreur assignation totale : {0}", ErreursTotales);
            Console.ReadLine();
            Console.ReadKey();
        }
    }
}
                
