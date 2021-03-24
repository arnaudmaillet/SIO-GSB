// ------------------------------------------
// Nom du fichier : FrmAjout.cs
// Objet : Formulaire de saisie d'une nouvelle visite
// Auteur : 
// Date mise à jour : 
// ------------------------------------------

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using lesClasses;

namespace GSB
{
    public partial class FrmAjout : FrmBase
    {

        public FrmAjout()
        {
            InitializeComponent();
        }

        #region procédures événementielles

        // Au chargement du formulaire
        private void FmrSaisieVisite_Load(object sender, EventArgs e)
        {
            parametrerComposant();
            remplirdgvVisites();
        }

        //sur le clic du bouton ajouter
        private void btnAjouter_Click(object sender, EventArgs e)
        {
            ajout();
        }

        #endregion

        #region méthodes

        private void parametrerComposant() 
        {
            this.lblTitre.Text = "Enregistrer un nouveau rendez-vous";
            btnAjouter.BackColor = Color.Green;

            #region paramètrage des zones de liste
            // alimentation de la zone de liste déroulante contenant les praticiens
            cbxPraticien.DataSource = Globale.LeVisiteur.getLesPraticiens();

            // ne permettre que la selection d'une valeur dans la liste des praticiens
            cbxPraticien.DropDownStyle = ComboBoxStyle.DropDownList;

            // ne permettre que la selection d'une valeur dans la liste des motifs
            cbxMotif.DropDownStyle = ComboBoxStyle.DropDownList;

            // alimentation de la zone de liste déroulante contenant les motifs
            cbxMotif.DataSource = Globale.LesMotifs;
            cbxMotif.DisplayMember = "Libelle";

            #endregion

            #region paramétrage du composant dateTimePicker 
            // la prise de rendez vous s'effectue sur les deux mois à venir : propriétés MinDate et MaxDate
            // la valeur la plus petite (qui sera la valeur proposée par défaut) est dans 2 heures sans les minutes ou après demain 8 heure si demain est un dimanche
            // la valeur la plus grande possible est dans 60 jours à 19 heures
            dtpDate.MaxDate = DateTime.Today.AddDays(60).AddHours(19);

            DateTime dateMin = DateTime.Now.AddHours(2).AddMinutes(DateTime.Now.Minute);

            if (dateMin.Hour >= 19)
            {
                dateMin = DateTime.Today.AddDays(1).AddHours(8);
                if(dateMin.DayOfWeek == DayOfWeek.Sunday)
                {
                    dateMin = DateTime.Today.AddDays(2).AddHours(8);
                }
            }
            dtpDate.MinDate = dateMin;

            #endregion

            parametrerDgv(dgvVisites);
        }

        private void parametrerDgv(DataGridView unDgv)
        {
            #region paramètrage concernant le datagridview dans son ensemble

            // Accessibilité (doit être sur true si on veut pouvoir utiliser les barres de défilement)
            unDgv.Enabled = true;

            // style de bordure
            unDgv.BorderStyle = BorderStyle.FixedSingle;

            // couleur de fond 
            unDgv.BackgroundColor = Color.White;

            // couleur de texte  
            unDgv.ForeColor = Color.Black;

            // police de caractères par défaut
            unDgv.DefaultCellStyle.Font = new Font("Georgia", 11);

            // mode de sélection dans le composant : FullRowSelect, CellSelect ...
            unDgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // sélection multiple 
            unDgv.MultiSelect = false;

            // l'utilisateur peut-il ajouter ou supprimer des lignes ?
            unDgv.AllowUserToDeleteRows = false;
            unDgv.AllowUserToAddRows = false;

            // L'utilisateur peut-il modifier le contenu des cellules ou est-elle réservée à la programmation ?
            unDgv.EditMode = DataGridViewEditMode.EditProgrammatically;

            // l'utilisateur peut-il redimensionner les colonnes et les lignes ?
            unDgv.AllowUserToResizeColumns = false;
            unDgv.AllowUserToResizeRows = false;

            // l'utilisateur peut-il modifier l'ordre des colonnes ?
            unDgv.AllowUserToOrderColumns = false;

            // le composant accepte t'il le 'déposer' dans un Glisser - Déposer ?
            unDgv.AllowDrop = false;


            #endregion

            #region paramètrage concernant la ligne d'entête (les entêtes de chaque colonnes)

            // visibilité
            unDgv.ColumnHeadersVisible = true;

            // bordure
            unDgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;

            // style  [à adapter] (ici : noir sur fond transparent sans mise en évidence de la sélection)
            unDgv.EnableHeadersVisualStyles = false;
            DataGridViewCellStyle style = unDgv.ColumnHeadersDefaultCellStyle;
            style.BackColor = Color.WhiteSmoke;
            style.ForeColor = Color.Black;
            style.SelectionBackColor = Color.WhiteSmoke;    // même couleur que backColor pour ne pas mettre en évidence la colonne sélectionnée
            style.SelectionForeColor = Color.Black;
            style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            style.Font = new Font("Georgia", 12, FontStyle.Bold);


            // hauteur 
            unDgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            unDgv.ColumnHeadersHeight = 40;

            #endregion

            #region paramètrage concernant l'entête de ligne (la colonne d'entête ou le sélecteur)

            // visible 
            unDgv.RowHeadersVisible = false;

            // style de bordure  
            unDgv.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;


            #endregion

            #region paramètrage au niveau des lignes

            // Hauteur 
            unDgv.RowTemplate.Height = 30;

            #endregion

            #region paramètrage au niveau des cellules

            // style de bordure 
            unDgv.CellBorderStyle = DataGridViewCellBorderStyle.None;

            // couleur de fond, ne pas utiliser transparent car la couleur de la ligne sélectionnée restera après sélection
            unDgv.RowsDefaultCellStyle.BackColor = Color.White;

            // Couleur alternative appliquée une ligne sur deux
            // unDgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(255, 238, 238, 238);

            #endregion

            #region paramètrage au niveau de la zone sélectionnée

            // couleur de fond mettre la même que les cellules si on ne veut pas mettre la zone en évidence 
            unDgv.RowsDefaultCellStyle.SelectionBackColor = System.Drawing.Color.White;

            // couleur du texte
            unDgv.RowsDefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;

            #endregion

            #region paramètrage des colonnes

            // Largeur : à contrôler avec la largeur des colonnes si elle est définie
            unDgv.Width = 700;

            // Dimensionner la hauteur du DataGridview en fonction du nombre de lignes
            // à faire ici si le composant n'est pas dynamique

            // Nombre de colonne sans compter les colonnes ajoutées par la méthode Add
            unDgv.ColumnCount = 4;

            // faut-il ajuster automatiquement la taille des colonnes à leur contenu (commenter la ligne si non)
            // unDgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            // faut-il ajuster automatiquement la taille des colonnes par un ajustement proportionnel à la largeur totale (commenter la ligne si non)
            // unDgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // description de chaque colonne  [partie à personnaliser] : visibilité, largeur, alignement cellule et entête si ellene correspond pas à la valeur par défaut
            unDgv.Columns[0].HeaderText = "programmée le";
            unDgv.Columns[0].Name = "Date";
            unDgv.Columns[0].Width = 200;
            unDgv.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            unDgv.Columns[1].HeaderText = "à";
            unDgv.Columns[1].Name = "Heure";
            unDgv.Columns[1].Width = 50;
            unDgv.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            unDgv.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            unDgv.Columns[2].HeaderText = "sur";
            unDgv.Columns[2].Name = "Lieu";
            unDgv.Columns[2].Width = 200;
            unDgv.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            unDgv.Columns[3].HeaderText = "chez";
            unDgv.Columns[3].Name = "Praticien";
            unDgv.Columns[3].Width = 250;
            unDgv.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            // faut-il désactiver le tri sur toutes les colonnes ? (commenter les lignes si non)
            for (int i = 0; i < unDgv.ColumnCount; i++)
                unDgv.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;

            #endregion
        }

        // remplir le datagridview dgvVisites
        private void remplirdgvVisites()
        {
            // récupérer les rendez-vous
            List<Visite> lesRendezVous = Globale.LeVisiteur.getLesRendezVous();

            // vider le datagridView
            dgvVisites.Rows.Clear();
           
            // Parcourir ces visites pour les ajouter dans le datagridview
         foreach(Visite uneVisite in lesRendezVous)
            {
                dgvVisites.Rows.Add(uneVisite.DateEtHeure.ToShortDateString(), uneVisite.DateEtHeure.ToShortTimeString(),uneVisite.LePraticien.Ville, uneVisite.LePraticien.NomPrenom);
            }
            
            // adapter la hauteur du datagridView
            

            if (dgvVisites.Height > 800) dgvVisites.Height = 800;

        }

        // enregistrement dans la base de données si aucune erreur retournée par le Sgbdr
        private void ajout()
        {
            if(cbxPraticien.SelectedItem is null || cbxMotif.SelectedItem is null)
            {
                MessageBox.Show("Vous devez selectionner un praticien et un motif existant");
            } else
            {
                // récupération du praticien
                Praticien unPraticien = (Praticien)cbxPraticien.SelectedItem;
                // récupération du motif
                Motif unMotif = (Motif)cbxMotif.SelectedItem;

                DateTime uneDate = dtpDate.Value;

                // ajout dans la base de données

                int idVisite = Passerelle.ajouterRendezVous(unPraticien.Id, unMotif.Id, uneDate, out string message);
                if (idVisite == 0)
                {
                    MessageBox.Show(message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    // Création de l'objet visite
                    Visite uneVisite = new Visite(idVisite, unPraticien, unMotif, uneDate, Globale.LeVisiteur);

                    // Maj DgvVisite
                    remplirdgvVisites();
                    modifierRendezVous.Enabled = true;

                    // Afficher msg de confirmation
                    MessageBox.Show("Rendez-vous enregistré", "Ajout", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                // en cas d'erreur afficher le message retourné 
                // sinon 
                //   créer un objet visite
                //   ajouter la visite en mémoire 
                //   recharger le datagridview afin qu'il intègre ce nouveau rendez-vous
                //    réactiver l'option du menu permettant la modification d'un rendez-vous (elle pouvait être désactivée si le visiteur n'avait pas encore de rendez-vous
            }
        }
        #endregion
    }
}

