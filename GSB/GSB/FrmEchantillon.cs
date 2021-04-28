using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using lesClasses;

namespace GSB
{
    public partial class FrmEchantillon : FrmBase
    {
        public FrmEchantillon()
        {
            InitializeComponent();
        }

        #region procédures événementielles
        private void FrmEchantillon_Load(object sender, EventArgs e)
        {
            parametrerComposant();
            parametrerDgv(dgvEchantillons);
            remplirDgvEchantillon();
        }
        #endregion

        #region méthodes
        private void parametrerComposant()
        {
            this.lblTitre.Text = "Liste des Echantillons";
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
            unDgv.Width = 800;

            // Nombre de colonne sans compter les colonnes ajoutées par la méthode Add
            unDgv.ColumnCount = 6;

            // faut-il ajuster automatiquement la taille des colonnes à leur contenu (commenter la ligne si non)
            // unDgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            // faut-il ajuster automatiquement la taille des colonnes par un ajustement proportionnel à la largeur totale (commenter la ligne si non)
            unDgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // description de chaque colonne  [partie à personnaliser] : visibilité, largeur, alignement cellule et entête si ellene correspond pas à la valeur par défaut
            unDgv.Columns[0].Visible = false;

            unDgv.Columns[1].HeaderText = "Médicament";
            unDgv.Columns[1].Name = "Medicament";
            unDgv.Columns[1].Width = 150;
            unDgv.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            unDgv.Columns[2].HeaderText = "Total";
            unDgv.Columns[2].Name = "Total";
            unDgv.Columns[2].Width = 50;
            unDgv.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            unDgv.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            unDgv.Columns[3].HeaderText = "Distribué le";
            unDgv.Columns[3].Name = "Date";
            unDgv.Columns[3].Width = 150;
            unDgv.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            unDgv.Columns[4].HeaderText = "Chez";
            unDgv.Columns[4].Name = "Praticien";
            unDgv.Columns[4].Width = 100;
            unDgv.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            unDgv.Columns[5].HeaderText = "Quantité";
            unDgv.Columns[5].Name = "Qte";
            unDgv.Columns[5].Width = 100;
            unDgv.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            // faut-il désactiver le tri sur toutes les colonnes ? (commenter les lignes si non)
            for (int i = 0; i < unDgv.ColumnCount; i++)
                unDgv.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;

            #endregion

            // Dimensionner la hauteur du DataGridview en fonction du nombre de lignes
            unDgv.Height = Globale.LesMedicaments.Count * (unDgv.RowTemplate.Height) + unDgv.ColumnHeadersHeight + 10;

        }

        private void remplirDgvEchantillon()
        {
            // Dictionnaire lesMedicaments = [<Medicament, total> , ...] contenant tout les médicaments (clé unique) + le total par médicaments
            SortedDictionary<Medicament, int> lesMedicaments = new SortedDictionary<Medicament, int>();
            Visite currentVisite = null;


            foreach (Visite uneVisite in Globale.LeVisiteur.getLesVisites())
            {
                // Dictionnaire lesEchantillons contenant les echantillons pour une visite close
                SortedDictionary<Medicament, int> lesEchantillons = uneVisite.getLesEchantillons();
                currentVisite = uneVisite;

                foreach (KeyValuePair<Medicament, int> unEchantillon in lesEchantillons)
                {
                    // Si unEchantillon est déjà présent dans lesMedicaments => on supprime la ligne de l'echantillon et on rajoute la clé en ajoutant la valeur (qte) avec la précendante sinon on ajoute la clé + valeur dans lesMedicaments
                    if (lesMedicaments.ContainsKey(unEchantillon.Key))
                    {
                        int lastValue = lesMedicaments[unEchantillon.Key];
                        lesMedicaments.Remove(unEchantillon.Key);
                        lesMedicaments.Add(unEchantillon.Key, unEchantillon.Value + lastValue);
                    } else
                    {
                        lesMedicaments.Add(unEchantillon.Key, unEchantillon.Value);
                    }
                }
            }

            //foreach (KeyValuePair<Medicament, int> unMedicament in lesMedicaments)
            //{
            //    Visite lastVisite = lesMedicaments.ContainsKey(Globale.LeVisiteur.getLesVisites())
            //}

            foreach(KeyValuePair<Medicament, int> unMedicament in lesMedicaments)
            { 
                dgvEchantillons.Rows.Add(
                    unMedicament,
                    unMedicament.Key,
                    unMedicament.Value,
                    currentVisite.DateEtHeure,
                    currentVisite.LePraticien.NomPrenom
                );
            }
            #endregion
        }
    }
}
