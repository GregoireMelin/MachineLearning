using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Partie_3
{
    public partial class Affichage : Form
    {
        
        Bitmap representation = new Bitmap(800,800);

        Reseau reseau;
        List<List<double>> lvecteursentrees;
        List<double> lsortiesdesirees;

        public Affichage(List<List<double>> lvecteursentrees, List<double> lsortiesdesirees, Reseau reseau)
        {
            InitializeComponent();
            this.lvecteursentrees = lvecteursentrees;
            this.lsortiesdesirees = lsortiesdesirees;
            this.reseau = reseau;

            representation = ZonesApprentissage(representation);
            representation = AfficherTemoin(representation, this.lvecteursentrees, this.lsortiesdesirees);
            pictureBox1.Image = representation;
        }

        private Bitmap AfficherTemoin(Bitmap bmp, List<List<double>> lvecteursentrees, List<double> lsortiesdesirees)
        {
            foreach (List<double> vectEntree in lvecteursentrees)
            {
                int index = lvecteursentrees.IndexOf(vectEntree);

                if (lsortiesdesirees[index] == 0.2)
                    bmp.SetPixel((int)(vectEntree[0]*800.0), (int)(vectEntree[1]*800.0), Color.White);
                else
                    bmp.SetPixel((int)(vectEntree[0] * 800.0), (int)(vectEntree[1] * 800.0), Color.Black);
            }

            return bmp;
        }

        private Bitmap ZonesApprentissage(Bitmap bmp)
        {
            List<List<double>> entrees = new List<List<double>>();
            List<double> sortie = new List<double>();
            

            //On parcours les pixels de la bitmap et on les traites
            for (int x = 0; x < bmp.Width; x++)
            {
                for (int y = 0; y < bmp.Height; y++)
                {
                    List<double> vect = new List<double>();
                    vect.Add(x/800.0);
                    vect.Add(y/800.0);

                    entrees.Add(vect);
                }
            }

            sortie = reseau.ResultatsEnSortie(entrees);

            double erreur = 0.0;
            int indice =0;
            for (int x = 0; x < bmp.Width; x++)
            {
                for (int y = 0; y < bmp.Height; y++)
                {

                    if (sortie[indice] < 0.5)
                    {
                        bmp.SetPixel(x, y, Color.Blue);
                        erreur += Math.Abs(0.2 - sortie[indice]);
                    }
                    else
                    {
                        bmp.SetPixel(x, y, Color.Yellow);
                        erreur += Math.Abs(0.8 - sortie[indice]);
                    }
                    indice++;
                }
            }

            erreur /= Convert.ToDouble(indice);
            Erreur.Text = erreur.ToString();
            return bmp;
        }
    }
}
