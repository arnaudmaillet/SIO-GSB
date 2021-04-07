// ------------------------------------------
// Nom du fichier : FrmConsultation.cs
// Objet : Formulaire de consultation de l'ensemble des visites
// Auteur : M. Verghote
// Date mise à jour : 09/03/2021
// ------------------------------------------

using System;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;
using lesClasses;
using System.Collections.Generic;


namespace GSB
{
    public partial class FrmConsultation : FrmBase
    {

        public FrmConsultation()
        {
            InitializeComponent();
        }

        #region procédures événementielles

        private void FrmConsultation_Load(object sender, EventArgs e)
        {
            parametrerComposant();
            remplirDgvVisites();
        }

        // Sur la sélection d'un rendez-vous dans le datagridview on affiche le détail de ce rendez-vous dans la partie droite.
        private void dgvVisites_SelectionChanged(object sender, EventArgs e)
        {
            afficher();
        }

        #endregion

        #region méthodes

        // Mise en forme des composants utilisés 
        private void parametrerComposant()
        {
            this.lblTitre.Text = "Consultation des visites";
             
            #region paramétrage dgvEchantillon

            // le composant n'est pas accessible
            dgvEchantillons.Enabled = false;

            // Police de caractères
            dgvEchantillons.DefaultCellStyle.Font = new Font("Georgia", 11);

            // hauteur des lignes
            dgvEchantillons.RowTemplate.Height = 30;

            // bordure au niveau du contour du datagridview
            dgvEchantillons.BorderStyle = BorderStyle.FixedSingle;

            // pas de bordure au niveau du contour des cellules
            dgvEchantillons.CellBorderStyle = DataGridViewCellBorderStyle.None;

            // pas de différence sur la ligne sélectionnée
            dgvEchantillons.RowsDefaultCellStyle.SelectionBackColor = System.Drawing.Color.White;
            dgvEchantillons.RowsDefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;

            // la ligne d'entête n'est pas visible
            dgvEchantillons.ColumnHeadersVisible = false;

            // La colonne d'entête n'est pas visible
            dgvEchantillons.RowHeadersVisible = false;


            // définition des colonnes : idMedicament et quantité 
            dgvEchantillons.ColumnCount = 2;
            dgvEchantillons.Width = 180;

            // mise en forme des colonnes

            dgvEchantillons.Columns[0].Name = "Medicament";
            dgvEchantillons.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvEchantillons.Columns[0].Width = 100;

            dgvEchantillons.Columns[1].Name = "Quantité";
            dgvEchantillons.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvEchantillons.Columns[1].Width = 75;

            #endregion

            parametrerDgv(dgvVisites);
        }

        private void parametrerDgv(DataGridView unDgv)
        {
            #region paramètrage concernant le datagridview dans son ensemble



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
            style.BackColor = Color.Gray;
            style.ForeColor = Color.Black;
            style.SelectionBackColor = Color.WhiteSmoke;    // même couleur que backColor pour ne pas mettre en évidence la colonne sélectionnée
            style.SelectionForeColor = Color.Black;
            style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            style.Font = new Font("Georgia", 12, FontStyle.Bold);
                       

            // hauteur 
            unDgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
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
            unDgv.RowsDefaultCellStyle.SelectionBackColor = System.Drawing.Color.Lavender;
            
            // couleur du texte
            unDgv.RowsDefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;

            #endregion

            #region paramètrage des colonnes

            // Largeur : à contrôler avec la largeur des colonnes si elle est définie
            unDgv.Width = 473;

            // Nombre de colonne sans compter les colonnes ajoutées par la méthode Add
            unDgv.ColumnCount = 4;

            // faut-il ajuster automatiquement la taille des colonnes à leur contenu (commenter la ligne si non)
            // unDgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            // faut-il ajuster automatiquement la taille des colonnes par un ajustement proportionnel à la largeur totale (commenter la ligne si non)
            unDgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

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
            unDgv.Columns[3].Width = 200;
            unDgv.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            // faut-il désactiver le tri sur toutes les colonnes ? (commenter les lignes si non)
            for (int i = 0; i < unDgv.ColumnCount; i++)
                unDgv.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;

            #endregion
			
			// Dimensionner la hauteur du DataGridview en fonction du nombre de lignes
            unDgv.Height = Globale.LeVisiteur.getNbVisite() * (unDgv.RowTemplate.Height) + unDgv.ColumnHeadersHeight + 10;

        }

        // alimenter le datagridview à partir de la collection de visite du visiteur
        private void remplirDgvVisites()
        {
            foreach (Visite uneVisite in Globale.LeVisiteur.getLesVisites())
                dgvVisites.Rows.Add(
                        uneVisite, 
                        uneVisite.DateEtHeure.ToShortDateString(),
                        uneVisite.DateEtHeure.ToShortTimeString(),
                        Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(uneVisite.LePraticien.Ville.ToLower())
                    ) ;
        }

        // Afficher la visite sélectionnée dans le datagridview
        private void afficher()
        {
            Visite uneVisite = (Visite)dgvVisites.SelectedRows[0].Cells[0].Value;
            lblPraticien.Text = uneVisite.LePraticien.NomPrenom;
            lblEmail.Text = uneVisite.LePraticien.Email;
            lblRue.Text = uneVisite.LePraticien.Rue;
            lblTelephone.Text = uneVisite.LePraticien.Telephone;
            lblMotif.Text = uneVisite.LeMotif.Libelle;
            lblSpecialite.Text = uneVisite.LePraticien.Specialite is null ? null : uneVisite.LePraticien.Specialite.Libelle;
            lblType.Text = uneVisite.LePraticien.Type.Libelle;
            lblBilan.Text = uneVisite.Bilan;


            //vider la liste
            lstMedicament.Items.Clear();

            // alimentation des medicaments présentés
            if (uneVisite.PremierMedicament != null)
            {
                lstMedicament.Items.Add(uneVisite.PremierMedicament.Nom);
                if (uneVisite.SecondMedicament != null)
                {
                    lstMedicament.Items.Add(uneVisite.SecondMedicament.Nom);
                }
            }

            dgvEchantillons.Rows.Clear();
            SortedDictionary<Medicament, int> lesEchantillons = uneVisite.getLesEchantillons();
            foreach (Medicament unMedicament in uneVisite.getLesEchantillons().Keys)
            {
                dgvEchantillons.Rows.Add(unMedicament.Nom, lesEchantillons[unMedicament]);       
            }
        }
        #endregion
    }
}
