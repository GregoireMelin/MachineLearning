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
    public partial class Question_3 : Form
    {
        Colis[] tab_colis;
        int[] tab_lignes, tab_colonnes;
        int [][] repartition;
        int nbChariotsClick = 0 , id_colis_choisi;
        // pour afficher les détails dans un autre formulaire
        List<GenericNode> chemin;
        Graph nul;
        Chariot_prioritaire Chariot_p;
        Colis Colis_choisi; 

  

        public Question_3(int nb_chariots, int longueur, int largeur)
        {
            InitializeComponent();
            repartition = new int[nb_chariots][];
            Emplacement initialisation = new Emplacement(0, 0, "Nord", 0);
            // il faut donner une valeur par défaut à nul car sinon VS nous dit
            // qu'il ne prendra aucune valeur car il n'est pas instancié au début
            nul = new Graph(initialisation, initialisation);
            // la liste des chariots
            Program.tab_chariot = new Chariot[nb_chariots];
            tab_colis = new Colis[nb_chariots];

            Program.entrepot = new Entrepot(longueur, largeur);
            Consigne_LBL.Text = " Etape 1 : Cliquer sur le chariot prioritaire";
            // la liste des chariots
            Program.tab_chariot = new Chariot[nb_chariots];

            int ButtonWidth = 20;
            int ButtonHeight = 20;
            int Distance = 0;
            int start_x = 0;
            int start_y = 0;

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
                        tmpButton.Enabled = true;

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
                        tmpButton.Enabled = true;
                        //Evenements associés au controle
                        tmpButton.Click += new EventHandler(tmpButton_Click);
                        //Ecriture du controle
                        this.Controls.Add(tmpButton);
                    }
                }
            }
            // tous les chariots doivent être placés sur la colonne 1
            Random rdn = new Random();
            // les chariots ne doivent pas se supperposer
            for (int j = 0; j < Program.tab_chariot.Length; j++)
            {
                Program.tab_chariot[j] = new Chariot(0, j, "Est", 0);
                // un chariot est prêt à l'emploi donc orienté à l'est dès le début
                string positionDep = Program.tab_chariot[j]._x.ToString() + "." + Program.tab_chariot[j]._y.ToString();
                Button btn = (Button)this.Controls.Find(positionDep, true)[0];
                btn.Text = "" + Program.tab_chariot[j].Get_cle_chariot();
                btn.BackColor = Color.Silver;
                btn.Enabled = true;
                btn.Refresh();
                // on met le nouveau chariot dans le tableau
                Program.entrepot.cell[j, 0] = 2;
            }

            // on remplit tous les colis à aller chercher
            for (int k = 0; k < tab_colis.Length; k++)
            {

                tab_colis[k] = Faire_colis(rdn, k);
                string position = tab_colis[k]._x + "." + tab_colis[k]._y;
                Button btn = (Button)this.Controls.Find(position, true)[0];
                btn.BackColor = Color.Green;
                btn.Enabled = true;
                // dans l'orientation : on prend la premiere lettre de l'orientation du colis donc N pour Nord et S pour Sud
                // on prend donc la premiere lettre donc la lettre à l'indice 0 sur une durée de 1 lettre
                btn.Text = tab_colis[k]._orientation.Substring(0, 1);
                btn.Refresh();

            }


            
        }

        private void Quitter_BTN_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

      
        /// <summary>
        /// Cette fonction permet donc de vérifier si le clic de l'utilisateur sur une case de l'entrepot a bien été fait sur un colis existant. Dans cette fonction, on ne vérifie donc que les coordonnées
        /// du colis sont bien égales à un des colis contenant dans le tableau de colis. Cette fonction est utilisé comme fonction test dans une boucle if qui colore le bouton sélectionné en jaune si
        /// le bouton cliqué est bien un colis existant. Quand cette fonction renvoie false dans la boucle if, le clic de l'utilsateur n'est pas pris en compte et donc il doit refaire un nouveau clic pour
        /// toujours choisir le colis pour le chariot prioritaire.
        /// cette fonction renvoie un true si le bouton cliqué est bien un colis et false dans le cas contraire.
        /// </summary>
        /// <entree>
        ///     <param name="x"> entier correspondant à la position x du colis dans notre entrepot, le x correspond à l'axe des abscisses donné par l'utilisateur </param>
        ///     <param name="y"> y est en entier qui correspond à la position le long de l'axe des ordonnées donné par l'utilisateur </param>
        /// </entree>
        /// <returns>Booléen qui indique false si les positions ne correspondent pas un emplacement de colis et true dans le cas contraire</returns>
        private bool Est_bien_un_colis(int x, int y)
        {
            for (int k = 0; k < tab_colis.Length; k++)
            {
                if (y == tab_colis[k]._y && x == tab_colis[k]._x) { return (true); } 
                // le colis est bien dans la liste
            }
            return (false);
        }

        private void tmpButton_Click(object sender, EventArgs e)
        {
            // Expression regulière pour récuperer la position d'un chariot avec le nom du bouton
            Regex re = new Regex(@"([0-9]*)\.([0-9]*)");
           
            
            Button btn = (Button)sender;
            String sourcestring = btn.Name;
            // Retrouver le bouton et le changer de couleur puis le bloquer
            MatchCollection mc = re.Matches(sourcestring);

            // 1. lors du premier clic après la génération du formulaire, l'utilisateur doit choisir un chariot qui sera le chariot prioritaire
            // on ne comptabilise le clic uniquement si la personne a bien cliqué un chariot
            if (nbChariotsClick == 0  && Program.entrepot.cell[int.Parse(mc[0].Groups[2].Value), int.Parse(mc[0].Groups[1].Value)] ==2 )
            {
                // on choisit le chariot prioritaire
                Chariot_p = new Chariot_prioritaire( int.Parse(btn.Text) , int.Parse(mc[0].Groups[1].Value), int.Parse(mc[0].Groups[2].Value), "Est",0) ;
                btn.BackColor = Color.Gold;
                btn.Refresh();
                // on augmente la valeur du clic que si la personne a bien choisi un chariot
                nbChariotsClick++;
                Consigne_LBL.Text = " Etape 2 : Choissisez un colis parmi ceux indiqués";
            }
            //2. après le choix du clic, on choisit un colis qui sera attribué au chariot désigné avant
                // dans ce cas la on ne comptabilise aussi le clic uniquement si la case cliquée est bien un chariot.
            else if (nbChariotsClick == 1 && Est_bien_un_colis(int.Parse(mc[0].Groups[1].Value), int.Parse(mc[0].Groups[2].Value)))
            { 
                // on choisit le colis du chariot prioritaire
                btn.BackColor = Color.Gold;
                btn.Refresh();
                // si la personne place mal son colis, on ne doit pas compte ce clic
                nbChariotsClick++;
                Aleatoire_BTN.Visible = true;
                // On utilise les informations du bouton cliqué pour refaire et retrouver le colis
                // on retrouver le colis via une autre fonction selon le principe de séparation des tâches
                string orientation = "";
                if ( btn.Text == "N") { orientation ="Nord";}
                else { orientation ="Sud";}
                Colis_choisi = Retrouver_colis_clique( int.Parse(mc[0].Groups[1].Value), int.Parse(mc[0].Groups[2].Value), orientation);
                repartition[0] = new int[] { Chariot_p.Get_cle_chariot()-1, Retrouver_indice_colis_clique( Colis_choisi) };
                id_colis_choisi = Retrouver_indice_colis_clique(Colis_choisi);
            }
        }

        private Colis Retrouver_colis_clique(int x, int y, string orientation)
        {
            for (int k = 0; k < tab_colis.Length; k++) 
            {
                if (tab_colis[k]._y == y && tab_colis[k]._x == x && tab_colis[k]._orientation == orientation) { return (tab_colis[k]); }
            }
            // le bouton cliqué n'est pas un colis : par défaut
            return(null);
        }

        private int Retrouver_indice_colis_clique( Colis colis)
        {
            for (int k = 0; k < tab_colis.Length; k++)
            {
                if (tab_colis[k]._y == colis._y && tab_colis[k]._x == colis._x && tab_colis[k]._orientation == colis._orientation) { return (k); }
            }
            // le bouton cliqué n'est pas un colis : par défaut
            return(-1);
        }

        /// <summary>
        /// Cette fonction permet de placer les chariots le long de la premiere colonne lorsque la personne souhaite commencer
        /// à visualiser le déplacement de tous les chariots. Les paramètres sont les paramètres habituels de gestion des evemenemts. Cette fonction
        /// ne renvoie aucun paramètre.
        /// </summary>
        /// <entree>
        ///     <param name="sender"> information sur le bouton cliqué </param>
        ///     <param name="e"> information sur l'évenement </param>
        /// </entree>
        /// <sortie> aucune </sortie>
        private void Aleatoire_BTN_Click(object sender, EventArgs e)
        {
            // 2. on affiche les chariots sur le diagramme
            Aleatoire_BTN.Visible = false;

            // réparition simple des colis
            // le colis que devait initialement récupére le chariot choisi
            Colis temp1 = tab_colis[Chariot_p.Get_cle_chariot() - 1];
            tab_colis[id_colis_choisi] = temp1;
            tab_colis[Chariot_p.Get_cle_chariot() - 1] = Colis_choisi;

            // on répartie les colis
            Repartition_colis_chariots();
            Affichage_des_objectifs();
            Jouer();
            // on lance tous les déplacements
        }

        /// <summary>
        /// Cette fonction est utilisé comme condition dans la fonction Jouer(). Elle permet de savoir si tous les chariots sont bien rentrés
        /// à la plateforme, après avoir pris le colis sur les étagères et donc d'indiquer la fin de l'algorithme. Elle passe en revue tous les 
        /// chariots du plateau et de regarder leur status enLivraison. Elle renvoie donc vrai si tous les chariots sont revenus à la plateforme
        /// et false dans tous les autres cas.
        /// </summary>
        /// <entre> pas d'entrés</entre>
        /// <returns> elle renvoie un booléen utilisé dans une condition while. </returns>
        private bool Retour_plateforme()
        {
            bool arrive = true;
            for (int k = 0; k < Program.tab_chariot.Length; k++)
            {
                if ( Program.tab_chariot[k].enLivraison == false) { return(false); }
                // si le chariot sélectionné n'est pas encore arrivé à la plateforme de livraison donc enLivraison = false
                // on indique que le chariot n'est pas encore retourné à la plateforme. Si un chariot n'est pas revenu à la plateforme, on renvoie false;
            }
            return(arrive);
            // si aucun des chariots n'est pas encore revenu à la plateforme de livraison, c'est que tous les chariots sont revenus et donc on renvoie
            // true. Dans la fonction Jouer() qui utilise la fonction Retour_plateforme() comme fonction test dans sa boucle while()
        }

        private void Jouer()
        {
            // cette fonction est la fonction principale qui gére tous les déplacements des chariots du départ de tous à l'arrivée de tous à la plateforme
            // tant que tous les chariots ne sont pas revenus à la première ligne
            while (!Retour_plateforme())
            {
                for (int k = 0; k < Program.tab_chariot.Length; k++)
                {
                    // on passe en revue tout les chariots a chaque nouvelle série dans le while
                    // on recalcule le chemin à chaque instant pour qu'il tienne compte du chemin des autres chariots et ne pas avoir de colision ou de
                    // fusion entre les différents chariots qui roulent dans l'entrepot.
                    // pour les autres chariots
                    // partie 1 : QUAND LE CHARIOT SE DEPLACE
                   if (!Program.tab_chariot[k].enLivraison && !Program.tab_chariot[k].depot && !Program.tab_chariot[k].rotation)
                    {
                        // si le chariot se déplace : on considère deux choix soit c'est le chariot prioritaire : celui qui ne tient pas compte des autres chariots pour son 
                        // propre déplacement soit c'est un chariot secondaire qui lui tient compte des autres chariots dans l'entrepot dans son propre déplacement.
                       if (Program.tab_chariot[k].Get_cle_chariot() == Chariot_p.Get_cle_chariot())
                        {
                            Deplacement_prioritaire();
                            // on fait une comparaison sur les identifiants des chariots pour trouver si le chariot qui est en train de passer (Program.tab_chariot[k] ) est
                            // le chariot prioritaire ou non
                        }
                       else
                        { 
                            Deplacement_chariot(k);
                            // si ce n'est pas le chariot prioritaire, on utilise une autre fonction car les deux types de chariots ont des déplacements différents.
                        }

                    }
                    // PARTIE 2 : QUAND LE CHARIOT EST EN ROTATION 3 SECONDES
                    else if (Program.tab_chariot[k].rotation && !Program.tab_chariot[k].enLivraison)
                    {
                        Program.tab_chariot[k].rotation_temps++;
                        if (Program.tab_chariot[k].rotation_temps == 2) { Program.tab_chariot[k].rotation = false; }
                        // on augmente le temps que le chariot passe en rotation
                        // quand le chariot a atteint ses trois secondes en rotation, on considère qu'il n'est plus en rotation et peut donc faire un déplacement normal la prochaine fois
                        // la condition est à 2 car on fait démarrer la rotation à 0 : on a donc bien les 3 secondes de rotation
                    }
                    // PARTIE 3 : QUAND LE CHARIOT EST EN TRAIN DE PRENDRE LE COLIS 10 SECONDES
                    else if (Program.tab_chariot[k].depot && !Program.tab_chariot[k].enLivraison)
                    {
                        Program.tab_chariot[k].depot_temps++;
                        if (Program.tab_chariot[k].depot_temps == 9 + 4 * tab_colis[k]._hauteur) { Program.tab_chariot[k].depot = false; }
                        //même raisonnement que pour la rotation
                    }
                    // on ralenti le système sur une seconde
                    System.Threading.Thread.Sleep(100);
                }
            } // fin du while
        }

        private void Deplacement_prioritaire()
        {
            //1. on calcule son trajet
            // la position de départ : leur position actuelle
            Emplacement ptsDepart = new Emplacement(Program.tab_chariot[Chariot_p.Get_cle_chariot() - 1]._x, Program.tab_chariot[Chariot_p.Get_cle_chariot() - 1]._y, Program.tab_chariot[Chariot_p.Get_cle_chariot() - 1]._orientation, Program.tab_chariot[Chariot_p.Get_cle_chariot() - 1]._hauteur);

            // la position de fin : calculé via le colis
            // quand la personne a choisi les caractéristiques de son colis
            Emplacement arrivee = new Emplacement();
            // si le colis est au nord, alors le chariot doit se placer sur la case en dessus soit -1 dans la matrice

            // si la position finale est la position sur la plateforme car le chariot a déjà pris son colis
            if (Program.tab_chariot[Chariot_p.Get_cle_chariot() - 1].chercher_un_colis)
            {
                #region Si  le chariot a pris son colis et doit revenir à  la plateforme
                // le chariot doit revenir à sa plateforme
                arrivee.SetX(0);
                int c = 0;
                double cout = 600, coutmin = 500;
                for (int kk = 0; kk < Program.entrepot.Get_largeur_entrepot(); kk++)
                {
                    if (Program.entrepot.cell[kk, 0] != 2)
                    {
                        arrivee.SetY(kk);
                        nul = new Graph(arrivee, ptsDepart);
                        chemin = nul.RechercheSolutionAEtoile();
                        if (chemin.Count > 0)
                        {
                            cout = chemin[chemin.Count() - 1].GetGCost();
                        }
                        if (cout < coutmin)
                        {
                            coutmin = cout;
                            c = kk;
                        }
                    }
                }
                arrivee.SetY(c);
                #endregion
            }
            else
            {
                if (tab_colis[Chariot_p.Get_cle_chariot() - 1]._orientation == "Nord") { arrivee.SetY(tab_colis[Chariot_p.Get_cle_chariot() - 1]._y - 1); }
                else { arrivee.SetY(tab_colis[ Chariot_p.Get_cle_chariot() - 1]._y + 1); }
                // la position en x ne change pas
                arrivee.SetX(tab_colis[Chariot_p.Get_cle_chariot() - 1]._x);
            }

            Graph trouver = new Graph(arrivee, ptsDepart);
            chemin = trouver.RechercheSolutionAEtoile();

            // CHOIX 1 : quand le chariot est à l'emplacement final pour prendre le colis
            if (Program.tab_chariot[Chariot_p.Get_cle_chariot() - 1]._x == tab_colis[Chariot_p.Get_cle_chariot() - 1]._x && (Program.tab_chariot[Chariot_p.Get_cle_chariot() - 1]._y - 1 == tab_colis[Chariot_p.Get_cle_chariot() - 1]._y || Program.tab_chariot[Chariot_p.Get_cle_chariot() - 1]._y + 1 == tab_colis[Chariot_p.Get_cle_chariot() - 1]._y) && !Program.tab_chariot[Chariot_p.Get_cle_chariot() - 1].chercher_un_colis)
            {
                #region Prendre le colis
                // on est arrivé au bout du chemin 1
                Program.tab_chariot[Chariot_p.Get_cle_chariot() - 1].chercher_un_colis = true;
                Program.tab_chariot[Chariot_p.Get_cle_chariot() - 1].depot = true;
                Program.tab_chariot[Chariot_p.Get_cle_chariot() - 1].depot_temps = 0;

                string positionArr = tab_colis[Chariot_p.Get_cle_chariot() - 1]._x + "." + tab_colis[Chariot_p.Get_cle_chariot() - 1]._y;
                Button btn_7 = (Button)this.Controls.Find(positionArr, true)[0];
                //   btn_4.Image = Image.FromFile("../../Images/" + arrivee.Get_orientation() + ".png");
                btn_7.BackColor = Color.Purple;
                btn_7.Text = "X";
                btn_7.Refresh();

                // pour le chariot qui récupère le colis
                string position = Program.tab_chariot[Chariot_p.Get_cle_chariot() - 1]._x + "." + Program.tab_chariot[Chariot_p.Get_cle_chariot() - 1]._y;
                Button btn_6 = (Button)this.Controls.Find(position, true)[0];
                //   btn_4.Image = Image.FromFile("../../Images/" + arrivee.Get_orientation() + ".png");
                btn_6.BackColor = Color.DarkGreen;
                btn_6.Text = "*";
                btn_6.Refresh();
                #endregion
            }
            // CHOIX 2 : quand le chariot est revenu à la livraison
            else if (Program.tab_chariot[Chariot_p.Get_cle_chariot() - 1].chercher_un_colis && Program.tab_chariot[Chariot_p.Get_cle_chariot() - 1]._x == 0)
            {
                // le chariot a donc pris son colis et est revenu sur la plateforme de livraison
                Program.tab_chariot[Chariot_p.Get_cle_chariot() - 1].enLivraison = true;
                // pour le chariot qui récupère le colis
                string position = Program.tab_chariot[Chariot_p.Get_cle_chariot() - 1]._x + "." + Program.tab_chariot[Chariot_p.Get_cle_chariot() - 1]._y;
                Button btn_5 = (Button)this.Controls.Find(position, true)[0];
                btn_5.BackColor = Color.DarkGreen;
                btn_5.Text = "§";
                btn_5.Refresh();

            }
            // CHOIX 3 : quand il se déplace classiquement
            else if (chemin.Count > 1)
            {
                #region Deplacement d'un chariot vers une autre case
                //On clean la position de depart
                string positionDep = ptsDepart.GetX().ToString() + "." + ptsDepart.GetY().ToString();
                Button btn_3 = (Button)this.Controls.Find(positionDep, true)[0];
                btn_3.BackColor = Color.White;
                btn_3.Text = "";
                btn_3.Refresh();

                //On colore la position d'arrivee
                string positionArr = ((Emplacement)chemin[1]).GetX().ToString() + "." + ((Emplacement)chemin[1]).GetY().ToString();
                Button btn_4 = (Button)this.Controls.Find(positionArr, true)[0];

                // si la nouvelle case necessite un changement de direction
                if (ptsDepart.GetArcCost((Emplacement)chemin[1]) == 4 && Chariot_p.rotation_temps != 0)
                {
                    Program.tab_chariot[Chariot_p.Get_cle_chariot() - 1].rotation = true;
                    Program.tab_chariot[Chariot_p.Get_cle_chariot() - 1].rotation_temps = 0;
                    btn_3.BackColor = Color.DarkGreen;
                    btn_3.Text = Chariot_p.Get_cle_chariot().ToString();
                    btn_3.Refresh();
                    Program.tab_chariot[Chariot_p.Get_cle_chariot() - 1]._orientation = ((Emplacement)chemin[1]).Get_orientation();
                }
                else
                {
                    if (Program.tab_chariot[Chariot_p.Get_cle_chariot() - 1].chercher_un_colis) { btn_4.BackColor = Color.DarkGreen; }
                    else { btn_4.BackColor = Color.DarkGreen; }
                    btn_4.Text = Program.tab_chariot[Chariot_p.Get_cle_chariot() - 1].Get_cle_chariot().ToString();
                    btn_4.Refresh();

                    // on enregistre les changements
                    Program.entrepot.cell[Program.tab_chariot[Chariot_p.Get_cle_chariot() - 1]._y, Chariot_p._x] = 0;
                    Program.tab_chariot[Chariot_p.Get_cle_chariot() - 1]._x = ((Emplacement)chemin[1]).GetX();
                    Program.tab_chariot[Chariot_p.Get_cle_chariot() - 1]._y = ((Emplacement)chemin[1]).GetY();
                    Program.tab_chariot[Chariot_p.Get_cle_chariot() - 1]._orientation = ((Emplacement)chemin[1]).Get_orientation();
                    Program.tab_chariot[Chariot_p.Get_cle_chariot() - 1]._hauteur = 0;
                    Program.entrepot.cell[((Emplacement)chemin[1]).GetY(), ((Emplacement)chemin[1]).GetX()] = 2;
                }
                #endregion
            }

        }

        /// <summary>
        ///  Cette fonction permet de faire une répartition entre les chariots et les colis de facon à ce qu'un colis soit pris par le chariot qui est plus proche de lui
        ///  dans le cas ou le chariot est déjà pris on fait une affectation random sur les chariots non pris à ce moment la. On remplit donc le tableau repartition[][] qui est un 
        ///  tableau de tableaux contenant les numéris des chariots ou numéros des colis qui leur sont associés.
        /// </summary>
        /// <entree> aucune </entree>
        /// <sortie> aucune </sortie>
        private void Repartition_colis_chariots()
        {

            int[,] tab_colis_rep = new int[Program.tab_chariot.Length,2];
            int[,] tab_chariot_rep = new int[Program.tab_chariot.Length,2];

            // creation des tableaux
            
            for (int kk = 0 ; kk < Program.tab_chariot.Length ; kk++)
            {
                tab_colis_rep[kk,0] = kk ;
                tab_colis_rep[kk,1]=0;
                tab_chariot_rep[kk,0] = kk ;
                tab_chariot_rep[kk, 1] = 0;
            }
            // prise en comtpe des colis et chariot choisi
            tab_chariot_rep[repartition[0][0], 1] = 1;
            tab_colis_rep[repartition[0][1], 1] = 1;
            int i = 0, index = 0;
            Random Rdn = new Random();
            // le compteur k set pour les chariots et le compteur i pour les colis
            for (int k =0 ; k < tab_colis.Length -1; k++)
            {
                if (tab_colis[k] != Colis_choisi)
                {
                    #region Affectation
                    repartition[i + 1] = new int[2];
                    // on choisit le chariot
                    index = ChariotProche(tab_colis[k]);
                    // on choisit le colis
                    if (tab_chariot_rep[index, 0] == 1)
                    {
                        // ce chariot est déjà utilise on fait donc une affectation random
                        do { index = Rdn.Next(0, Program.tab_chariot.Length - 1); }
                        while (tab_chariot_rep[index, 0] == 1);
                    }

                    // on sauvegarde dans le tableau de répartition
                    repartition[i + 1][1] = k;
                    repartition[i + 1][0] = index;
                    // on sauvegarde les changements dans les tableaux d'affectation
                    tab_chariot_rep[index, 1] = 1;
                    tab_colis_rep[k, 1] = 1;
                    // on incrémente les compteurs
                    i +=1;
                    #endregion
                }
                
            } // fin du for


            // on cherche ou le tableau n'a pas de valeurs
            // on trouve le rang
            int indice = 0;
            for (int k = 0; k < tab_colis.Length; k++)
            {
                if (repartition[k] == null) 
                { 
                    indice = k;
                    repartition[k] = new int[2];
                }
            }


            //  il doit y a avoir un elemeent qui n'a pas été iniitialisé
            // on trouve le colis manquant : on cherche dans le colis qui n'a pas été attribuée
            bool appartient = false;
            for (int k = 0; k < tab_colis.Length; k++)
            {
                appartient = Element_dans_tab(k, repartition);
                if (!appartient) { repartition[indice][1] = k; }
            }
            // on trouve le chariot manquant
            for (int k = 0; k < Program.tab_chariot.Length; k++)
            {
                appartient = Element_dans_tab(Program.tab_chariot[k].Get_cle_chariot()-1 , repartition);
                if (!appartient) { repartition[indice][1] = k; }
            }

        }
        
        

        private bool Element_dans_tab( int indice , int[][] tab )
        {
            for (int k = 0; k < tab.Length; k++)
            {
                if (tab[k][0] == indice && tab[k][1] !=1) { return (true); }
            }
            return (false);
        }


        /// <summary>
        /// Cette fonction utilisé permet de créer un colis de façon aléatoire en utilisant des nombres aléatoires pour les différents paramètres et caractéristiques
        /// d'un colis. Elle renvoie donc le colis qui vient d'être fait. On crée des colis en vérifiant que le nouveau colis n'existe pas déjà dans le tableau de colis
        /// via une autre fonction test. L'orientation d'un colis ne peut être que le Nord ou le Sud pour que le chariot puisse ensuite venir le chercher.
        /// </summary>
        /// <entree>
        /// <   param name="rdn"> Nombre Random qui doit venir des niveaux supérieurs du programme pour avoir des chiffres différents à chaque itération </param>
        ///     <param name="compteur"> le compteur entier k est en paraètres car on doit le donner à une des fonction utilisée dans le code pour assurer l'abscende
        ///         des erreurs quand on essaie d'accèder à un colis qui n'a pas encore été crée.</param>
        ///     </entree>
        /// <returns> On renvoie le colis qui vient d'être crée par cette fonction </returns>
        private Colis Faire_colis(Random rdn, int compteur)
        {
            Colis colis_cree = new Colis();
            do
            {
                rdn = new Random();
                string orientation = "";
                int aleatoire = 2 * rdn.Next();
                if (aleatoire <= 1) { orientation = "Sud"; }
                else  { orientation = "Nord"; }
                colis_cree = new Colis(Choisir_colonne(rdn), Choisir_ligne(rdn), rdn.Next(0, 10), orientation);
            } while (Doublon(colis_cree, compteur));
             return (colis_cree);
        }

        private int Choisir_ligne(Random rdn)
        {
            int nb_lignes = 0;
            if ( Program.entrepot.Get_largeur_entrepot()%2 == 0 ) { nb_lignes = (Program.entrepot.Get_largeur_entrepot()-4 ) /2 ;}
            else { nb_lignes =  (Program.entrepot.Get_largeur_entrepot() - 3  )/ 2 ; }
            tab_lignes = new int[nb_lignes];
            tab_lignes[0] = 2;
            for (int k = 0 ; k < nb_lignes ; k++)
            {
                tab_lignes[k] = 2*k+2;
            }
            rdn = new Random();
          // pour un entrepot de 25 : tab_lignes = new int[] { 2, 4, 6, 8, 10, 12, 14, 16, 18, 20, 22 };
            return (tab_lignes[rdn.Next(0, nb_lignes-1)]);
        }

        private int Choisir_colonne(Random rdn)
        {
            int nb_colonnes = 0, aux =0;
            nb_colonnes = Program.entrepot.Get_largeur_entrepot() - 7;
            // a cause des 4 colonnes sur les côtes qui sont vides dont la plateforme de livraison et des 3 rangées pour le milieu
            if (Program.entrepot.Get_largeur_entrepot() % 2 == 0)   {   aux = 5; }
            else   {  aux = 6;  }
            // pour les retraits des colonnes du milieux
            
            tab_colonnes = new int[nb_colonnes];
            for (int k = 0; k < nb_colonnes+5; k++)
            {
                if (k < (Program.entrepot.Get_largeur_entrepot() +5) / 2) { tab_colonnes[k] = k + 2; }
                // si k est dans la première partie de l'entrepot
                else if (k >= 3+ (Program.entrepot.Get_largeur_entrepot() - 3) / 2) { tab_colonnes[k-aux] = k; }
            }
            rdn = new Random();
          // pour un entrepot de taille de 25 par 25 on devrait donc avoir : tab_colonnes = new int[] {2,3,4,5,6,7,8,9,14,15,16,17,18,19,20,21,22};
            return (tab_colonnes[rdn.Next(0, nb_colonnes-1)]);
        }

        /// <summary>
        /// Cette fonction est utilisée lorsque l'on souhaite faire un nouveau colis. Comme les 15 colis
        /// doivent être distincts, on doit donc vérifier à chaque colis que le colis nouvellement créé 
        /// n'existe pas déjà. On doit donc chercher un colis dans un tableau de colis
        /// </summary>
        /// <entree>
        ///     <param name="nouveau"> Nouveau colis qui vient d'être fait aléaoiterement </param>
        ///     <param name="compteur"> le compte int permet de savoir jusqu'à quelque point est rempli le tableau
        ///     ppour ne pas avoir des comparaisons avec des objets vides et eviter les exceptions et les erreurs </param>
        /// </entree>
        /// <returns> Cette fonction étant une fonction test, elle renvoie donc un boléen avec true si le colis existe 
        /// déjà dans le tableau ou false dans le cas contraire. </returns>
        private bool Doublon(Colis nouveau, int compteur)
        {
            for (int k = 0; k < compteur; k++)
            {
                if (tab_colis[k]._x == nouveau._x && tab_colis[k]._y == nouveau._y) { return (true); }
            }
            return (false);
        }

        /// <summary>
        ///  Cette fonction permet de faire un affichage des caractèristiques des colis comme leur position ou leur hauteur mais également
        ///  indique l'identifiant du chariot qui doit venir les chercher. De cette facon, on peut controler que les chariots aillent au bon 
        ///  endroit sur l'entrepot mais aussi bien au Nord ou au Sud pour prendre correctement le colis. Avec la hauteur, on peut controler
        ///  la bonne attente du chariot lorsqu'il prend le colis soit 4*hauteur_colis + 10. 2*hauteur_colis pour monter son bras à hauteur du
        ///  colis et deux autres fois pour rescendre son breas (calcul confirmé par le professeur).
        /// </summary>
        /// <entree> Pas d'entrée </entree>
        /// <sortie> Pas de sortie : affichage uniquement </sortie>
        private void Affichage_des_objectifs()
        {
            for (int k = 0; k < tab_colis.Length; k++)
            {
                Colis_LBL.Text += "Le colis " + (k+1) + " est (" + tab_colis[k]._x + "," + tab_colis[k]._y + ") à "+tab_colis[k]._hauteur+"m pour le chariot "+k +"\n";
            }
        }
    
        private void Deplacement_chariot(int k)
        {
            
            //1. on calcule leur trajet
            // la position de départ : leur position actuelle
            Emplacement ptsDepart = new Emplacement(Program.tab_chariot[k]._x, Program.tab_chariot[k]._y, Program.tab_chariot[k]._orientation, Program.tab_chariot[k]._hauteur);

            // la position de fin : calculé via le colis
            // quand la personne a choisi les caractéristiques de son colis
            Emplacement arrivee = new Emplacement();
            // si le colis est au nord, alors le chariot doit se placer sur la case en dessus soit -1 dans la matrice
            if (Program.tab_chariot[k].chercher_un_colis)
            {
                #region Si  le chariot a pris son colis et doit revenir à  la plateforme
                // le chariot doit revenir à sa plateforme
                arrivee.SetX(0);
                int c = 0;
                double cout = 600, coutmin = 500;
                for (int kk = 0; kk < Program.entrepot.Get_largeur_entrepot(); kk++)
                {
                    if (Program.entrepot.cell[kk, 0] != 2)
                    {
                        arrivee.SetY(kk);
                        nul = new Graph(arrivee, ptsDepart);
                        chemin = nul.RechercheSolutionAEtoile();
                        if (chemin.Count > 0)
                        {
                            cout = chemin[chemin.Count() - 1].GetGCost();
                        }
                        if (cout < coutmin)
                        {
                            coutmin = cout;
                            c = kk;
                        }
                    }
                }
                arrivee.SetY(c);
                #endregion
            }
            else
            {
                if (tab_colis[k]._orientation == "Nord") { arrivee.SetY(tab_colis[k]._y - 1); }
                else { arrivee.SetY(tab_colis[k]._y + 1); }
                // la position en x ne change pas
                arrivee.SetX(tab_colis[k]._x);
            }

            Graph trouver = new Graph(arrivee, ptsDepart);
            chemin = trouver.RechercheSolutionAEtoile();

            // CHOIX 1 : quand le chariot est à l'emplacement final pour prendre le colis
            if (Program.tab_chariot[k]._x == tab_colis[k]._x && (Program.tab_chariot[k]._y - 1 == tab_colis[k]._y || Program.tab_chariot[k]._y + 1 == tab_colis[k]._y) && !Program.tab_chariot[k].chercher_un_colis)
            {
                #region Prendre le colis
                // on est arrivé au bout du chemin 1
                Program.tab_chariot[k].chercher_un_colis = true;
                Program.tab_chariot[k].depot = true;
                Program.tab_chariot[k].depot_temps = 0;

                string positionArr = tab_colis[k]._x + "." + tab_colis[k]._y;
                Button btn_7 = (Button)this.Controls.Find(positionArr, true)[0];
                //   btn_4.Image = Image.FromFile("../../Images/" + arrivee.Get_orientation() + ".png");
                btn_7.BackColor = Color.Purple;
                btn_7.Text = "X";
                btn_7.Refresh();

                // pour le chariot qui récupère le colis
                string position = Program.tab_chariot[k]._x + "." + Program.tab_chariot[k]._y;
                Button btn_6 = (Button)this.Controls.Find(position, true)[0];
                //   btn_4.Image = Image.FromFile("../../Images/" + arrivee.Get_orientation() + ".png");
                btn_6.BackColor = Color.Yellow;
                btn_6.Text = "*";
                btn_6.Refresh();
                #endregion
            }
            // CHOIX 2 : quand le chariot est revenu à la livraison
            else if (Program.tab_chariot[k].chercher_un_colis && Program.tab_chariot[k]._x == 0)
            {
                // le chariot a donc pris son colis et est revenu sur la plateforme de livraison
                Program.tab_chariot[k].enLivraison = true;
                // pour le chariot qui récupère le colis
                string position = Program.tab_chariot[k]._x + "." + Program.tab_chariot[k]._y;
                Button btn_5 = (Button)this.Controls.Find(position, true)[0];
                btn_5.BackColor = Color.Orange;
                btn_5.Text = "§";
                btn_5.Refresh();

            }
            // CHOIX 3 : quand il se déplace classiquement
            else if (chemin.Count > 1)
            {
                #region Deplacement d'un chariot vers une autre case
                //On clean la position de depart
                string positionDep = ptsDepart.GetX().ToString() + "." + ptsDepart.GetY().ToString();
                Button btn_3 = (Button)this.Controls.Find(positionDep, true)[0];
                btn_3.BackColor = Color.White;
                btn_3.Text = "";
                btn_3.Refresh();

                //On colore la position d'arrivee
                string positionArr = ((Emplacement)chemin[1]).GetX().ToString() + "." + ((Emplacement)chemin[1]).GetY().ToString();
                Button btn_4 = (Button)this.Controls.Find(positionArr, true)[0];

                // si la nouvelle case necessite un changement de direction
                if (ptsDepart.GetArcCost((Emplacement)chemin[1]) == 4 && Program.tab_chariot[k].rotation_temps != 0) 
                {
                    Program.tab_chariot[k].rotation = true;
                    Program.tab_chariot[k].rotation_temps = 0;
                    btn_3.BackColor = Color.Pink;
                    btn_3.Text = Program.tab_chariot[k].Get_cle_chariot().ToString();
                    btn_3.Refresh();
                    Program.tab_chariot[k]._orientation = ((Emplacement)chemin[1]).Get_orientation();
                }
                else
                {
                    if (Program.tab_chariot[k].chercher_un_colis) { btn_4.BackColor = Color.Blue; }
                    else { btn_4.BackColor = Color.Red; }
                    btn_4.Text = Program.tab_chariot[k].Get_cle_chariot().ToString();
                    btn_4.Refresh();

                    // on enregistre les changements
                    Program.entrepot.cell[Program.tab_chariot[k]._y, Program.tab_chariot[k]._x] = 0;
                    Program.tab_chariot[k]._x = ((Emplacement)chemin[1]).GetX();
                    Program.tab_chariot[k]._y = ((Emplacement)chemin[1]).GetY();
                    Program.tab_chariot[k]._orientation = ((Emplacement)chemin[1]).Get_orientation();
                    Program.tab_chariot[k]._hauteur = 0;
                    Program.entrepot.cell[((Emplacement)chemin[1]).GetY(), ((Emplacement)chemin[1]).GetX()] = 2;
               }
                #endregion
            }

           
        }
    

        private int ChariotProche(Colis colis)
        {
            // initialisation du chariot que l'on teste : ici le premier du tableau
            Chariot chariot_choisit = Program.tab_chariot[0];
            // on met un cout par défaut très grand
            double cost = 1000000;
            Emplacement empColis = new Emplacement(colis._x, colis._y, colis._orientation, colis._hauteur);
            // on passe en revue tous les chariots du tableau pour voir quel chariot est le plus proche du colis.
            foreach (Chariot chariot in Program.tab_chariot)
            {
                if (!chariot.enLivraison)
                {
                    Emplacement empChariot = new Emplacement(chariot._x, chariot._y, chariot._orientation, 0);

                    // Calcul du cout théorique du déplacement
                    empChariot.CalculeHCost(empColis);

                    // Comparaison
                    if (empChariot.Estimation() < cost)
                    {
                        chariot_choisit = chariot;
                        cost = empChariot.Estimation();
                    }
                }
            }
            return (chariot_choisit.Get_cle_chariot()-1);
        }

      
    }
}
