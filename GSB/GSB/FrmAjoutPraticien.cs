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
    public partial class FrmAjoutPraticien : FrmBase
    {
        public FrmAjoutPraticien()
        {
            InitializeComponent();
        }

        #region procédures événementielles

        // Au chargement du formulaire

        private void FrmAjoutPraticien_Load(object sender, EventArgs e)
        {
            parametrerComposant();
            afficher();
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
            this.lblTitre.Text = "Ajout d'un Praticien";
            this.lblNom.Text = "Nom :";
            this.lblPrenom.Text = "Prenom :";
            this.lblRue.Text = "Rue :";
            this.lblTel.Text = "Telephone :";
            this.lblType.Text = "Type :";
            this.lblEmail.Text = "Email :";
            this.lblSpe.Text = "Specialite :";
            this.lblVille.Text = "Ville :";

            btnAjouter.BackColor = Color.Red;
            btnAjouter.Text = "Ajouter";

            // alimentation de la zone de liste déroulante contenant les spécialités
            cbxSpe.DataSource = Globale.LesSpecialites;
            cbxSpe.DisplayMember = "Libelle";
            cbxSpe.DropDownStyle = ComboBoxStyle.DropDownList;

            // alimentation de la zone de liste déroulante contenant les types
            cbxType.DataSource = Globale.LesTypes;
            cbxType.DisplayMember = "Libelle";
            cbxType.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void afficher()
        {
            // recuperation des villes
            tbxVille.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            tbxVille.AutoCompleteSource = AutoCompleteSource.CustomSource;
            var source = new AutoCompleteStringCollection();
            foreach (Ville uneVille in Globale.LesVilles)
            {
                source.Add(uneVille.Nom); 
            }
            tbxVille.AutoCompleteCustomSource = source;
        }

        private void ajout()
        {
            // ajout dans la base de données
            if (tbxNom.Text == "" || tbxPrenom.Text == ""  || tbxEmail.Text == "" || tbxRue.Text == "" || tbxTel.Text == "" || tbxVille.Text == "" )
            {
                //MessageBox.Show(message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show("Vous devez renseigner les champs Nom, Prenom, Rue, Ville, Telephone et Email !");
            }
            else
            {
                // récupération d'une spécialité
                Specialite uneSpecialite = (Specialite)cbxSpe.SelectedItem;

                // récupération du type
                TypePraticien unType = (TypePraticien)cbxType.SelectedItem;

                // récupération de la ville (pour le code postal)
                Ville uneVille = Globale.LesVilles.Find(x => x.Nom == tbxVille.Text);

                Passerelle.ajouterPraticien(tbxNom.Text, tbxPrenom.Text, tbxRue.Text, uneVille.Code, tbxVille.Text, tbxTel.Text, tbxEmail.Text, unType.Id, uneSpecialite.Id, out string message);
                MessageBox.Show("Praticien ajouté");
            }
        }

        #endregion


    }
}
