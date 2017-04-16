using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;


namespace projettaquin
{
    public partial class Affichage : Form
    {
        Colis[] tab_colis;
        Chariot Chariot_choisi;
        int[] tab_lignes, tab_colonnes;
        int nbChariotsClick = 0, nb_colis = 0;
        // pour afficher les détails dans un autre formulaire
        List<GenericNode> chemin;
        Graph nul;
        
        

        public Affichage(int nb_chariots, int longueur, int largeur)
        {
            InitializeComponent();
            
            Emplacement initialisation = new Emplacement(0, 0, "Nord", 0);
            nul = new Graph(initialisation, initialisation);
            // la liste des chariots
            Program.tab_chariot = new Chariot[nb_chariots];
         //   Program.tab_chariot[0].Remise_a_zero();
            tab_colis = new Colis[nb_chariots];

            Program.entrepot = new Entrepot(longueur, largeur);
            Consigne_LBL.Text += "\n Etape 1 : Placer les chariots";
            // la liste des chariots
            Program.tab_chariot = new Chariot[nb_chariots];

            int ButtonWidth = 20;
            int ButtonHeight = 20;
            int Distance = 0;
            int start_x = 0;
            int start_y = 0;

            //for (int i = 0; i < entrepot.cell.GetLength(1); i++)

            for (int i = 0; i < Program.entrepot.cell.GetLength(0); i++)
            {
                for (int j = 0; j < Program.entrepot.cell.GetLength(1); j++)
                {

                    if (Program.entrepot.cell[j, i] == -1)
                    {
                        // Position du controle
                        Button tmpButton = new Button();
                        tmpButton.Top = start_x + (j * ButtonHeight + Distance);
                        tmpButton.Left = start_y + (i * ButtonWidth + Distance);
                        tmpButton.Width = ButtonWidth;
                        tmpButton.Height = ButtonHeight;
                        tmpButton.Name = i.ToString() + "." + j.ToString();

                        //Apparence du controle
                        tmpButton.BackColor = Color.Black;
                        tmpButton.FlatStyle = FlatStyle.Flat;
                        tmpButton.Enabled = false;

                        //Evenements associés au controle
                        tmpButton.Click += new EventHandler(tmpButton_Click);

                        //Ecriture du controle
                        this.Controls.Add(tmpButton);
                    }
                    else
                    {
                        // Position du controle
                        Button tmpButton = new Button();
                        tmpButton.Top = start_x + (j * ButtonHeight + Distance);
                        tmpButton.Left = start_y + (i * ButtonWidth + Distance);
                        tmpButton.Width = ButtonWidth;
                        tmpButton.Height = ButtonHeight;
                        tmpButton.Name = i.ToString() + "." + j.ToString();

                        //Apparence du controle
                        tmpButton.BackColor = Color.White;
                        tmpButton.FlatStyle = FlatStyle.Flat;

                        //Evenements associés au controle
                        tmpButton.Click += new EventHandler(tmpButton_Click);

                        //Ecriture du controle
                        this.Controls.Add(tmpButton);
                    }
                }
            }

            // on créer les possibilités pour placer un colis
            Choisir_colonne();
            Choisir_ligne();
        }

        private void Quitter_BTN_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private bool Est_un_colis(int x, int y)
        {
            bool c_un_colis = false;
            for (int k = 0; k < tab_lignes.Length; k++) { if (y == tab_lignes[k]) { c_un_colis = true; } }
            // si après avoir regardé les lignes, on remarqué que la  ligne du colis n'est pas une étagére
            // on peut d'ores et déjà dire que le colis n'est pas valable.
            if (!c_un_colis) { return (false); }
            // on remet la valeur du colis a false car il peut avoir les lignes de corrections mais pas les colonnes
            // on vérifie donc les erreurs de clics ou les agissements de personnes mal-intentionnées
            c_un_colis = false;
            for (int i = 0; i < tab_colonnes.Length; i++) { if (x == tab_colonnes[i]) { c_un_colis = true; } }
            return (c_un_colis);
        }



        private void Choisir_ligne()
        {
            int nb_lignes = 0;
            if (Program.entrepot.Get_largeur_entrepot() % 2 == 0) { nb_lignes = (Program.entrepot.Get_largeur_entrepot() - 4) / 2; }
            else { nb_lignes = (Program.entrepot.Get_largeur_entrepot() - 3) / 2; }
            tab_lignes = new int[nb_lignes];
            tab_lignes[0] = 2;
            for (int k = 0; k < nb_lignes; k++)
            {
               // pour faire les lignes du tableau soit le y, on prend donc une étagère sur 2
                tab_lignes[k] = 2 * k + 2; 
                // on doit faire un calcul pour avoir un lien entre l'indice du tableau tab_lignes et l'indice de la ligne sur l'entrepot
                // on a un décalage de 2 car les deux premières lignes sont libres et pour avoir que les lignes paires on multiplie par 2
            }
        }

        private void Choisir_colonne()
        {
            int nb_colonnes = 0, aux = 0;
            nb_colonnes = Program.entrepot.Get_largeur_entrepot() - 7;
            // a cause des 4 colonnes sur les côtes qui sont vides dont la plateforme de livraison et des 3 rangées pour le milieu
            if (Program.entrepot.Get_largeur_entrepot() % 2 == 0) { aux = 5; }
            else { aux = 6; }
            // pour les retraits des colonnes du milieux

            tab_colonnes = new int[nb_colonnes];
            for (int k = 0; k < nb_colonnes + 5; k++)
            {
                if (k < (Program.entrepot.Get_largeur_entrepot() + 5) / 2) { tab_colonnes[k] = k + 2; }
                // si k est dans la première partie de l'entrepot
                else if (k >= 3 + (Program.entrepot.Get_largeur_entrepot() - 3) / 2) { tab_colonnes[k - aux] = k; }
            }
        }


        private void Affichage_colis()
        {
            Consigne_LBL.Visible = true;
            Consigne_LBL.Visible = true;
            Aleatoire_BTN.Visible = false;
            Aleatoire_BTN.Location = new Point(649, 490);
            Colis_Position_LBL.Visible = true;
            Colis_TB.Visible = true;
            Colis_hauteur_LBL.Visible = true;
            Colis_Hauteur_TB.Visible = true;
            Colis_Localisation_TB.Visible = true;
            Colis_Position_y_LBL.Visible = true;
            Colis_Position_LBL.Visible = true;
            Valider_BTN.Visible = true;
            Orientation_LBL.Visible = true;
            Orientation_LIST.Visible = true;
        }

        /// <summary>
        /// Cette fonction permet de faire une génération des chariots de façon aléatoire proposant aisni une alternative au placement des chariots
        /// à la main par l'utilisateur. On fait donc une génération des chariots en utilisant le nombre de chariot que l'utilisateur a précisé dans le formulaire
        /// précédent. On vérifie qu'il n'existe pas déjà un chariot sur cet emplacement. Une fois le chariot défini dans le tableau des chariots mais aussi dans l'entrepot
        /// on fait donc une apparition du chariot sur l'entrepot affiché via le bouton qui change de couleur avec une image qui indique son orientation.
        /// </summary>
        /// <entree> 
        ///     <param name="sender"> informations sur le bouton cliqué </param>
        ///     <param name="e"> informations sur l'évènement déclenché</param>
        /// </entree>
        /// <sortie> Aucune </sortie>
        private void Aleatoire_BTN_Click(object sender, EventArgs e)
        {
            // 1. on génére aléatoire les chariots
            Random rdn = new Random();
            int a;
            for (int k = 0; k < Program.tab_chariot.Length; k++)
            {
                // on génére aléatoirement les coordonnnées aléatoirement
                int coordonne_x = 0, coordonne_y = 0;
                do
                {
                    coordonne_x = rdn.Next(0, Program.entrepot.Get_longueur_entrepot());
                    coordonne_y = rdn.Next(0, Program.entrepot.Get_largeur_entrepot());
                    a = Program.entrepot.cell[coordonne_x, coordonne_y];
                }
                while (Program.entrepot.cell[coordonne_y, coordonne_x] == -1 || Program.entrepot.cell[coordonne_y, coordonne_x] == 2);
                // la position du chariot doit être dans les zones possibles de l'entrepot
                // donc pas sur les étagères
                // on place le nouveau chariot dans l'entrepot
                Program.entrepot.cell[coordonne_y, coordonne_x] = 2;
                Program.tab_chariot[k] = new Chariot(coordonne_x, coordonne_y);
                // l'orientation est aussi aléatoire et par défaut, le bras est à 0 : gérer dans le constructeur
            }

            nbChariotsClick = Program.tab_chariot.Length;
            // 2. on affiche les chariots sur le digramme
            for (int j = 0; j < Program.tab_chariot.Length; j++)
            {
                string position = Program.tab_chariot[j]._x.ToString() + "." + Program.tab_chariot[j]._y.ToString();
                // colorer le bon bouton
                Button btn = (Button)this.Controls.Find(position, true)[0];
               
                btn.Text = "" + Program.tab_chariot[j].Get_cle_chariot();
                btn.Image = Image.FromFile("../../Images/" + Program.tab_chariot[j]._orientation + ".png");
                //  btn.Image = strech; 
            }
            // on affiche les nouveaux etats des controles
            Consigne_LBL.Text = "Etape 2 : cliquez sur le chariot de votre choix sur le graphique";
            Consigne_LBL.Visible = true;
            Aleatoire_BTN.Visible = false;
            Aleatoire_BTN.Enabled = false;
            UnableBtn(true);
        }

        /// <summary>
        /// Cette fonction survient après le clic de l'utilisateur sur le bouton "Valider". L'utilisateur vient de choisir les caractéristiques de son colis.
        /// Suite à cette validation, on vérifie l'emplacement du colis pour voir si cet emplacement est bien valide : que le colis est bien sur une étagère.
        /// Si les informations saisies ne sont pas valides comme : un emplacement hors des cases noires ou une hauteur supérieure à 10m, on informe l'utilisateur
        /// dans une message box de son erreur. Les paramètres du colis proposés par défaut donne bien sur une étagère.
        /// Si l'emplacement est correct, on calcule l'emplacement de fin du chariot en fonction des caractèristique du colis.
        /// Elle prend les paramètres habituels des gestionnnaires d'évènement et n'a pas de sortie.
        /// </summary>
        /// <entree>
        ///     <param name="sender"> informations sur le bouton cliqué </param>
        ///     <param name="e"> informations sur l'evenement </param>
        /// </entree>
        /// <sortie> aucune </sortie>
        private void Valider_BTN_Click(object sender, EventArgs e)
        {
            if (Est_un_colis(int.Parse(Colis_TB.Text), int.Parse(Colis_Localisation_TB.Text)) && int.Parse(Colis_Hauteur_TB.Text)<11  )
            {
                //1.l'emplacement du début
                Emplacement depart = new Emplacement(Chariot_choisi._x, Chariot_choisi._y, Chariot_choisi._orientation, int.Parse(Colis_Hauteur_TB.Text));
                string position = Chariot_choisi._x + "." + Chariot_choisi._y;
                Program.entrepot.cell[Chariot_choisi._y, Chariot_choisi._x] = 0;
                // colorer le bon bouton
                Button btn = (Button)this.Controls.Find(position, true)[0];
                btn.BackColor = Color.Blue;

                // quand la personne a choisi les caractéristiques de son colis
                string orientation = "";
                try { orientation = Orientation_LIST.SelectedItem.ToString(); }
                catch { orientation = "Nord"; }
                tab_colis[nb_colis] = new Colis(int.Parse(Colis_TB.Text), int.Parse(Colis_Localisation_TB.Text), int.Parse(Colis_Hauteur_TB.Text), orientation);

                // colorer le colis
                string position_2 = int.Parse(Colis_TB.Text) + "." + int.Parse(Colis_Localisation_TB.Text);
                Button btn_2 = (Button)this.Controls.Find(position_2, true)[0];
                btn_2.BackColor = Color.Green;
                if (orientation == "Nord") { btn_2.Text = "N"; }
                else { btn_2.Text = "S"; }
                btn_2.Refresh();

                // 2.trouver l'emplacement d'arrivée
                // en fonction de l'orientation du colis, l'emplacement n'est pas le même
                Emplacement arrivee = new Emplacement();

                // si le colis est au nord, alors le chariot doit se placer sur la case en dessus soit -1 dans la matrice
                if (tab_colis[nb_colis]._orientation == "Nord") { arrivee.SetY(tab_colis[nb_colis]._y - 1); }
                else { arrivee.SetY(tab_colis[nb_colis]._y + 1); }
                // la position en x ne change pas
                arrivee.SetX(tab_colis[nb_colis]._x);

                // on fait appel à la fonction pour nous trouver
                nul = new Graph(arrivee, depart);
                chemin = nul.RechercheSolutionAEtoile();

                // on enleve les controles lors du remplissage du colis
                Valider_BTN.Visible = false;
                Orientation_LBL.Visible = false;
                Orientation_LIST.Visible = false;
                Colis_hauteur_LBL.Visible = false;
                Colis_Hauteur_TB.Visible = false;
                Colis_Localisation_TB.Visible = false;
                Colis_Position_LBL.Visible = false;
                Colis_Position_y_LBL.Visible = false;
                Colis_TB.Visible = false;
                Details_BTN.Visible = true;

                Consigne_LBL.Text = "Etape 5 : Evaluer le chemin";
                Final_LBL.Visible = true;
                // si le chemin est null, c'est qu'il n'y a pas de solution pour que le colis puise être pris par le chariot
                if (chemin.Count == 0)
                {
                    Final_LBL.Text = "Pas de solution possible pour ce chemin";
                    Final_LBL.Visible = true;
                    Nv_colis_BTN.Visible = true;
                }
                else
                {
                    Deplacement_chariots();
                    //  le bouton du début est en bleu foncé alors que le chariot est en bleu clair
                    btn.BackColor = Color.Blue;
                    double cout = ((Emplacement)chemin[chemin.Count - 1]).GetGCost();
                }
                // s'il n'y a pas de solution, on n'affiche pas le calcul du retour à la plateforme.
                if (chemin.Count > 0) { Depot_BTN.Visible = true; }

                UnableChariots();
            }
            else
            {
                // si l'utilisateur a mal choisi l'emplacement de son colis
                string message = "La position du colis ne correspond pas à la disposition de l'entrepot : il doit être sur une étagère et à une hauteur inférieure ou égal à 10.";
                string caption = "Error Detected in Input";
                DialogResult result = MessageBox.Show(message, caption);
            }
        }


        private void Deplacement_chariots()
        {
            if (chemin.Count() > 0) 
            { 
                Final_LBL.Text = "Une solution a été trouvée";
                double cout = ((Emplacement)chemin[chemin.Count - 1]).GetGCost();
                Final_LBL.Text += " avec un cout de " + cout + " secondes";
            }
            else { Final_LBL.Text = "Pas de solution"; }

            for (int k = 0; k < chemin.Count() - 1; k++)
             {
                 if (k != chemin.Count() - 1)
                 {
                     System.Threading.Thread.Sleep((int)chemin[k].GetArcCost(chemin[k + 1]) * 100);

                     // todo : ne pas supprimer le premier avec k
                     //On clean la position de depart
                     Emplacement ptsDepart = (Emplacement)chemin[k];
                     string positionDep = ptsDepart.GetX().ToString() + "." + ptsDepart.GetY().ToString();
                     Button btn_3 = (Button)this.Controls.Find(positionDep, true)[0];
                     btn_3.Image = null;
                     btn_3.BackColor = Color.Gold ;
                     btn_3.Text = null;
                     btn_3.Refresh();

                     //On colore la position d'arrivee
                     Emplacement ptsArrivee = (Emplacement)chemin[k + 1];
                     string positionArr = ptsArrivee.GetX().ToString() + "." + ptsArrivee.GetY().ToString();
                     Button btn_4 = (Button)this.Controls.Find(positionArr, true)[0];
                     btn_4.Image = Image.FromFile("../../Images/"+ ptsArrivee.Get_orientation() +".png");
                     btn_4.Text = Chariot_choisi.Get_cle_chariot().ToString();
                     btn_4.Refresh();
                 }
                
             }
        }

        private void tmpButton_Click(object sender, EventArgs e)
        {
            // Expression regulière pour récuperer la position d'un chariot avec le nom du bouton
            Regex re = new Regex(@"([0-9]*)\.([0-9]*)");
            String sourcestring;

            // Retrouver le bouton et le changer de couleur puis le bloquer
            Button btn = (Button)sender;

            if (nbChariotsClick < Program.tab_chariot.Length - 1)
            {
                
                btn.Enabled = false;
                Aleatoire_BTN.Visible = false;
                // Recuperer les coordonnées du bouton et ajouter le chariot correspondant
                sourcestring = btn.Name;

                MatchCollection mc = re.Matches(sourcestring);

                // Création des chariots
                foreach (Match match in mc)
                {
                    Program.tab_chariot[nbChariotsClick] = new Chariot(int.Parse(match.Groups[1].Value), int.Parse(match.Groups[2].Value));
                    Program.entrepot.cell[int.Parse(match.Groups[2].Value), int.Parse(match.Groups[1].Value)] = 2;
                    btn.Text = "" + Program.tab_chariot[nbChariotsClick].Get_cle_chariot();
                }
                btn.Image = btn.Image = Image.FromFile("../../Images/" + Program.tab_chariot[nbChariotsClick]._orientation + ".png");
                Consigne_LBL.Visible = true;
                // car les indices sont décalées de 1, il faut donc mettre un -1 pour avoir un affichage correct
                Consigne_LBL.Text = "Etape 1 : Veuillez placer les " + (Program.tab_chariot.Length - nbChariotsClick -1) + " restants";
                nbChariotsClick++;
            }
            else if (nbChariotsClick == Program.tab_chariot.Length - 1)
            {
                /* Création du dernier chariot */
                
                btn.Enabled = false;

                sourcestring = btn.Name;

                MatchCollection mc = re.Matches(sourcestring);

                // Création des chariots
                foreach (Match match in mc)
                {
                    Program.tab_chariot[nbChariotsClick] = new Chariot(int.Parse(match.Groups[1].Value), int.Parse(match.Groups[2].Value));
                    btn.Text = "" + Program.tab_chariot[nbChariotsClick].Get_cle_chariot();
                    Program.entrepot.cell[int.Parse(match.Groups[2].Value), int.Parse(match.Groups[1].Value)] = 2;
                }
                
                btn.Image = btn.Image = Image.FromFile("../../Images/" + Program.tab_chariot[nbChariotsClick]._orientation + ".png");
                Consigne_LBL.Visible = true;
                Consigne_LBL.Text = "Etape 2 : Veuillez choisir un chariot en cliquant sur son emplacement dans le graphique";
                UnableBtn(false);
                nbChariotsClick++;
            }
            else if (nbChariotsClick == Program.tab_chariot.Length && btn.Image != null)
            {
                Chariot_choisi = Program.tab_chariot[int.Parse(btn.Text) - 1];
                Valider_BTN.Enabled = true;
                Affichage_colis();
                //on affiche la 4ième étape
                Consigne_LBL.Text = "Etape 3 : Définir un colis";
                UnableBtn(false);
            }
        }

        private void Etape2(bool une_fois)
        {

            //Affichage des chariots créés
            Consigne_LBL.Text = "Etape suivante : Veuillez choisir un chariot en cliquant sur son emplacement dans le graphique"; 
            // Affichage des contrôles de l'etape 2
            Affichage_colis();
        }

        private void UnableBtn(bool continuer_choix)
        {
            for (int i = 0; i < Program.entrepot.cell.GetLength(0); i++)
            {
                for (int j = 0; j < Program.entrepot.cell.GetLength(1); j++)
                {
                    string name = i.ToString() + "." + j.ToString();
                    Button btn = (Button)this.Controls.Find(name, true)[0];

                    if (btn.Image == null && continuer_choix)
                        btn.Enabled = false;
                    else if (btn.Image != null && !continuer_choix) { btn.Enabled = true; }
                    else if (btn.Image == null && !continuer_choix) { btn.Enabled = false; }
                    btn.Refresh();
                }
            }
        }

        private void Revenir_a_plateforme_livraison()
        {
            // le départ est l'endroit ou est resté le chariot
            Emplacement depart = (Emplacement)chemin[chemin.Count() - 1];
            string position = depart.GetX() + "." + depart.GetY();
            // colorer le bon bouton
            Button btn = (Button)this.Controls.Find(position, true)[0];
            btn.BackColor = Color.Blue;
            Program.entrepot.cell[depart.GetY(), depart.GetX()] = 0;
            // 2.trouver l'emplacement d'arrivée
            Emplacement arrivee = new Emplacement();
            // si le colis est au nord, alors le chariot doit se placer sur la case en dessus soit -1 dans la matrice
            arrivee.SetX(0);
            int  c = 0;
            double cout = 500, coutmin = 500;
            for (int k = 0; k < Program.entrepot.Get_largeur_entrepot() ; k++)
            {
                if (Program.entrepot.cell[k,0]  != 2)
                {
                    arrivee.SetY(k);
                    nul = new Graph(arrivee, depart);
                    chemin = nul.RechercheSolutionAEtoile();
                    if (chemin.Count > 0)
                    {
                        cout = chemin[chemin.Count() - 1].GetGCost();
                    }
                    if (cout < coutmin)
                    {
                        coutmin = cout;
                        c = k;
                    }
                }
            }
            arrivee.SetY(c);

            // on fait appel à la fonction pour nous trouver
            nul = new Graph(arrivee, depart);
            chemin = nul.RechercheSolutionAEtoile();
            // colorer le chemin de retour
            Deplacement_chariots();
            Program.entrepot.cell[c, 0] = 2;
            Nv_colis_BTN.Visible = true;
            // on met le bouton du début en blanc
            btn.BackColor = Color.White;

            UnableChariots();
        }

        /// <summary>
        ///  Cette fonction est un gestionnaire d'évènements suite au clic sur le bouton "Détails". Elle permet d'ouvrir une nouvelle fenêtre qui contient les informations sur
        ///  le chemin que vient de suivre le chariot. On ouvre une fenêtre de fàçon modale. Elle prend en paramètres les paramètres habituels des gestionnaires d'évènements.
        ///  Elle ne renvoie aucun paramètres.
        /// </summary>
        /// <entre>
        ///     <param name="sender"> informations sur le bouton cliqué </param>
        ///     <param name="e"> informations sur l'évènement produit </param>
        /// </entre>
        /// <sortie> aucune </sortie>
        private void Details_BTN_Click_1(object sender, EventArgs e)
        {
            Information_arbre detail = new Information_arbre(chemin, nul, Chariot_choisi);
            detail.ShowDialog();
        }


        private void Depot_BTN_Click(object sender, EventArgs e)
        {
            Revenir_a_plateforme_livraison();
            Depot_BTN.Visible = false;
        }

        private void UnableChariots()
        {
            foreach (Chariot chariot in Program.tab_chariot)
            {
                string name = chariot._x.ToString() + "." + chariot._y.ToString();
                Button btn = (Button)this.Controls.Find(name, true)[0];
                btn.Enabled = false;
            }
        }

        private void EnableChariots()
        {
            foreach (Chariot chariot in Program.tab_chariot)
            {
                string name = chariot._x.ToString() + "." + chariot._y.ToString();
                Button btn = (Button)this.Controls.Find(name, true)[0];
                btn.Enabled = true;
            }
        }


        /// <summary>
        /// Cette fonction permet de faire une décoloration sur les cases du tableau qui ont été colorées à la suite 
        /// du déplacemnt d'un des chariots. On efface le chemin du précédent. Elle ne prend aucun paramètre et ne renvoie pas de paramètres.
        /// </summary>
        /// <entree> Pas d'entrée</entree>
        /// <sortie> aucune </sortie>
        private void Decoloration()
        {
            for (int i = 0; i < Program.entrepot.cell.GetLength(0); i++)
            {
                for (int j = 0; j < Program.entrepot.cell.GetLength(1); j++)
                {
                    // on fait redevenir la case blanche
                    string name = i.ToString() + "." + j.ToString();
                    Button btn = (Button)this.Controls.Find(name, true)[0];
                    // on cherche les cases qui sont colorées mais qui ne contiennent rien donc une valeur de 0
                    if (btn.BackColor == Color.Gold || btn.BackColor == Color.Blue) { btn.BackColor = Color.White; }
                    btn.Refresh();
                }
            }
        }


        private void Nv_colis_BTN_Click(object sender, EventArgs e)
        {
            nb_colis++;
            if (nb_colis < tab_colis.Length)
            {
                // la personne souhaite donc continuer le déplacement des chariots
                Nv_colis_BTN.Visible = false;
                Decoloration();
                // tous les boutons rouges peuvent être de nouveau cliqués
                Final_LBL.Text = "";
                Consigne_LBL.Text = "Etape suivante : choissisez un chariot pour le déplacement";
            }
            else 
            {
                Consigne_LBL.Text = " Fin des déplacements";
                Final_LBL.Text = "";
            }

            EnableChariots();
        }
    }
}
