using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Partie_3___Non_supervisé
{
    public partial class Form1 : Form
    {
        static List<Observation> lobs = new List<Observation>();
        static public Random random;
        private Graphics g;	// Objet graphique plac� en global
        private Bitmap bmp;
        private Pen pen;		// Crayon plac� en global
        private int nbcol;      // nb de colonnes de la carte de Kohonen
        private int nblignes;   // nb de lignes de la carte

        CarteSOM SOM;
        static public List<Classe> listclasses = new List<Classe>();

        public Form1()
        {
            InitializeComponent();
            random = new Random();
            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage( pictureBox1.Image);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            nbcol = Convert.ToInt32(textBox1.Text);
            nblignes = Convert.ToInt32(textBox2.Text);
            bmp = (Bitmap)pictureBox1.Image;
            pen = new Pen(Color.White, 1);
            g.FillRectangle(pen.Brush, 0, 0, bmp.Width, bmp.Height);

            // Ouverture du fichier
            StreamReader reader = new StreamReader("..//..//datasetclassif.txt");

            // Creation des donnees
            List<List<double>> lve = new List<List<double>>();
            
            lobs.Clear();

            for (int i=0; i<3000; i++)
            {
                double x = 0, y = 0;
                List<double> vect = new List<double>();
                // On lit les lignes 3 par 3 pour créer les couples de données
                for (int j = 0; j < 3; j++)
                {
                    string line = reader.ReadLine();

                    if (j == 1)
                        x = double.Parse(line);
                    else if (j == 2)
                        y = double.Parse(line);
                }
                vect.Add(x);
                vect.Add(y);
                lve.Add(vect);
                lobs.Add( new Observation(x, y));
            }

            for (int i = 0; i < 3000; i++)
            {
                int k = random.Next(lve.Count);
                lobs.Add(new Observation(lve[k][0], lve[k][1]));
                lve.RemoveAt(k);
            }
                 

            // Creation de la carte SOM
            SOM = new CarteSOM(nbcol, nblignes, 2, bmp.Width);

            AfficheDonnees();
            AfficheCarteSOM();
            pictureBox1.Refresh();
        }

        public void AfficheDonnees()
        {
            for (int i = 0; i < lobs.Count; i++)
            {
                bmp.SetPixel(Convert.ToInt32(lobs[i].Getx()), Convert.ToInt32(lobs[i].Gety()), Color.Black);
            }
        }

        private void AfficheCarteSOM()
        {
           
            int x, y;

            pen.Color = Color.Blue;
            for (int i = 0; i < nbcol; i++)
                for (int j = 0; j < nblignes; j++)
                {
                    x = Convert.ToInt32(SOM.GetNeurone(i,j).GetPoids(0));
                    y = Convert.ToInt32(SOM.GetNeurone(i,j).GetPoids(1));
                    g.DrawEllipse(pen, x - 2, y - 2, 4, 4);
                }
            pictureBox1.Refresh();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            for (int i = 0; i < int.Parse(nbIter.Text); i++)
            {
                SOM.AlgoKohonen(lobs, Convert.ToDouble(textBox3.Text));
            }
            pen.Color = Color.White;
            g.FillRectangle(pen.Brush, 0, 0, bmp.Width, bmp.Height);
            AfficheDonnees();
            AfficheCarteSOM();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            listclasses.Clear();
            // Regroupement pour obtenir 2 classes
            SOM.regroupement(lobs, 6);
            pen.Color = Color.White;
            g.FillRectangle(pen.Brush, 0, 0, bmp.Width, bmp.Height);
            

            // pour chaque x,y de l'image
               // créer lobservation x,y
              // Pour chaque neurone neur de chaque classe k, trouver le gagnant
                 // cad trouver le neurone qui minimise neur.calculerreur ( obs)
                 // Colorer en fct de la classe

            List<Color> couleurs = new List<Color> { Color.Blue, Color.Red, Color.Green, Color.Orange, Color.DeepPink, Color.Purple };

            for (int i = 0; i < bmp.Width; i++)
            {
                for (int j = 0; j < bmp.Height; j++)
                {
                    Observation obs = new Observation(i, j);
                    int indexClasse = 0;
                    Neurone neurChoisit = listclasses[0].GetNeurones()[0];
                    for (int k = 0; k < listclasses.Count; k++)
                    {
                        foreach (Neurone neur in listclasses[k].GetNeurones())
                        {
                            if (neur.CalculeErreur(obs) < neurChoisit.CalculeErreur(obs))
                            {
                                indexClasse = k;
                                neurChoisit = neur;
                            }
                        }
                    }

                    bmp.SetPixel(i,j, couleurs[indexClasse]);
                }
            }
             

            // Affichage final des 6 classes
            int x, y;
            pen.Color = Color.Blue;
            foreach (Neurone n in listclasses[0].GetNeurones())
                {
                    x = Convert.ToInt32(n.GetPoids(0));
                    y = Convert.ToInt32(n.GetPoids(1));
                    g.DrawEllipse(pen, x - 2, y - 2, 4, 4);
                }

            pen.Color = Color.Red;
            foreach (Neurone n in listclasses[1].GetNeurones())
                {
                    x = Convert.ToInt32(n.GetPoids(0));
                    y = Convert.ToInt32(n.GetPoids(1));
                    g.DrawEllipse(pen, x - 2, y - 2, 4, 4);
                }

            pen.Color = Color.Green;
            foreach (Neurone n in listclasses[2].GetNeurones())
            {
                x = Convert.ToInt32(n.GetPoids(0));
                y = Convert.ToInt32(n.GetPoids(1));
                g.DrawEllipse(pen, x - 2, y - 2, 4, 4);
            }

            pen.Color = Color.Orange;
            foreach (Neurone n in listclasses[3].GetNeurones())
            {
                x = Convert.ToInt32(n.GetPoids(0));
                y = Convert.ToInt32(n.GetPoids(1));
                g.DrawEllipse(pen, x - 2, y - 2, 4, 4);
            }

            pen.Color = Color.DeepPink;
            foreach (Neurone n in listclasses[4].GetNeurones())
            {
                x = Convert.ToInt32(n.GetPoids(0));
                y = Convert.ToInt32(n.GetPoids(1));
                g.DrawEllipse(pen, x - 2, y - 2, 4, 4);
            }

            pen.Color = Color.Purple;
            foreach (Neurone n in listclasses[5].GetNeurones())
            {
                x = Convert.ToInt32(n.GetPoids(0));
                y = Convert.ToInt32(n.GetPoids(1));
                g.DrawEllipse(pen, x - 2, y - 2, 4, 4);
            }

            AfficheDonnees();

            pictureBox1.Refresh();  
        }

       
    }
}