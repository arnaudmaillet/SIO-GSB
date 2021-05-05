// ------------------------------------------
// Nom du fichier : FrmModifierRDV.cs
// Objet : Formulaire de modification des visites
// Auteur : M. Verghote
// Date mise à jour : 18/03/2021
// ------------------------------------------

using System;
using System.Drawing;
using System.Windows.Forms;
using lesClasses;
using System.Collections.Generic;

namespace GSB
{
    public partial class FrmModifierRDV : FrmBase
    {
        private MessageBoxButtons buttons;
        public FrmModifierRDV()
        {
            InitializeComponent();
        }

        #region procédures événementielles

        // Au chargement du formulaire
        private void FrmModifierRDV_Load(object sender, EventArgs e)
        {
            parametrerComposant(); 
            remplirdgvRDV();
            afficher();
        }

        //sur le clic du bouton ajouter
        private void btnModifier_Click(object sender, EventArgs e)
        {
            modifier();
            remplirdgvRDV();
        }

        private void dgvrRDV_SelectionChanged(object sender, EventArgs e)
        {
            afficher();
        }

        private void dgvRDV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 6)
            {
                Visite unRDV = (Visite)dgvRDV[0, e.RowIndex].Value;

                buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show("Êtes vous sûr de vouloir supprimer le rendez-vous de " + unRDV.LePraticien.NomPrenom + " programmé le " + unRDV.DateEtHeure.ToLongDateString() +" ?", "Suppression", buttons);
                if (result == DialogResult.Yes)
                {
                    // Suppression de la visite dans la base de donnée
                    if (Passerelle.supprimerRendezVous(unRDV.Id, out string message) == false)
                    {
                        MessageBox.Show(message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        // Suppression de la ligne
                        dgvRDV.Rows.RemoveAt(e.RowIndex);

                        // Suppression de la visite dans la collection lesVisites
                        Globale.LeVisiteur.supprimerVisite(unRDV);

                        MessageBox.Show("Rendez-vous supprimé");
                    };
                }
            }
        }

        #endregion

        #region méthodes
        private void parametrerComposant()
        {
            lblTitre.Text = "Modification des Rendez-vous";
            lblDgvTitre.Text = "Selectionner la visite afin de modifier la date du rendez-vous";
            lblAffichage.Text = "";
            btnModifier.Text = "Modifier";

            #region paramétrage du composant dateTimePicker 
            // la prise de rendez vous s'effectue sur les deux mois à venir : propriétés MinDate et MaxDate
            // la valeur la plus petite (qui sera la valeur proposée par défaut) est dans 2 heures sans les minutes ou après demain 8 heure si demain est un dimanche
            // la valeur la plus grande possible est dans 60 jours à 19 heures
            dtpDate.MaxDate = DateTime.Today.AddDays(60).AddHours(19);

            DateTime dateMin = DateTime.Now.AddHours(2).AddMinutes(DateTime.Now.Minute);

            if (dateMin.Hour >= 19)
            {
                dateMin = DateTime.Today.AddDays(1).AddHours(8);
                if (dateMin.DayOfWeek == DayOfWeek.Sunday)
                {
                    dateMin = DateTime.Today.AddDays(2).AddHours(8);
                }
            }
            dtpDate.MinDate = dateMin;
            #endregion
            parametrerDgv(dgvRDV);
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
            unDgv.Width = 800;

            // Dimensionner la hauteur du DataGridview en fonction du nombre de lignes
            // à faire ici si le composant n'est pas dynamique

            // Nombre de colonne sans compter les colonnes ajoutées par la méthode Add
            unDgv.ColumnCount = 6;

            // faut-il ajuster automatiquement la taille des colonnes à leur contenu (commenter la ligne si non)
            // unDgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            // faut-il ajuster automatiquement la taille des colonnes par un ajustement proportionnel à la largeur totale (commenter la ligne si non)
            // unDgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // description de chaque colonne  [partie à personnaliser] : visibilité, largeur, alignement cellule et entête si ellene correspond pas à la valeur par défaut

            unDgv.Columns[0].Visible = false;

            unDgv.Columns[1].HeaderText = "programmée le";
            unDgv.Columns[1].Name = "Date";
            unDgv.Columns[1].Width = 200;
            unDgv.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            unDgv.Columns[2].HeaderText = "à";
            unDgv.Columns[2].Name = "Heure";
            unDgv.Columns[2].Width = 50;
            unDgv.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            unDgv.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            unDgv.Columns[3].HeaderText = "sur";
            unDgv.Columns[3].Name = "Lieu";
            unDgv.Columns[3].Width = 170;
            unDgv.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            unDgv.Columns[4].HeaderText = "chez";
            unDgv.Columns[4].Name = "Praticien";
            unDgv.Columns[4].Width = 200;
            unDgv.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            DataGridViewImageColumn uneColonne = new DataGridViewImageColumn();
            uneColonne.Image = new Bitmap("supprimer.png");
            unDgv.Columns.Add(uneColonne);
            unDgv.Columns[5].Width = 30;
            unDgv.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            
            // faut-il désactiver le tri sur toutes les colonnes ? (commenter les lignes si non)
            for (int i = 0; i < unDgv.ColumnCount; i++)
                unDgv.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;

            #endregion
        }


        // remplir le datagridview dgvVisites
        private void remplirdgvRDV()
        {

            List<Visite> lesRDVs = Globale.LeVisiteur.getLesRendezVous();

            // vider le datagridView
            dgvRDV.Rows.Clear();

            // Parcourir ces visites pour les ajouter dans le datagridview
            foreach (Visite unRDV in lesRDVs)
            {
                dgvRDV.Rows.Add(
                    unRDV,
                    unRDV.DateEtHeure.ToShortDateString(), 
                    unRDV.DateEtHeure.ToShortTimeString(), 
                    unRDV.LePraticien.Ville, 
                    unRDV.LePraticien.NomPrenom);
            }

            // adapter la hauteur du datagridView
            if (dgvRDV.Height > 800) dgvRDV.Height = 800;
        }

        // Afficher le rendez-vous sélectionnée dans le datagridview

        private void afficher()
        {
            if (dgvRDV.SelectedRows.Count == 0)
            {
                lblAffichage.Text = "Veuillez selectionner un rendez-vous dans la liste de gauche";
                btnModifier.Visible = false;
            } else
            {
                Visite unRDV = (Visite)dgvRDV.SelectedRows[0].Cells[0].Value;
                lblAffichage.Text = "Le rendez-vous chez " + unRDV.LePraticien.Nom + " prévu initialement le " + unRDV.DateEtHeure + " est remi au ";
                btnModifier.Visible = true;
            }
        }

        private void modifier()
        {
            // Initialisation de l'objet unRDV
            Visite unRDV = (Visite)dgvRDV.SelectedRows[0].Cells[0].Value;

            // Requete Passerelle
            if (Passerelle.modifierRendezVous(unRDV.Id, dtpDate.Value, out string message) == true)
            {
                MessageBox.Show("Rendez-vous Modifié");
            }
            else 
            {
                MessageBox.Show(message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            };

            
        }

    }
    #endregion
}
