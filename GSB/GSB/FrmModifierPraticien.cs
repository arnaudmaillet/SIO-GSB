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
    public partial class FrmModifierPraticien : FrmBase
    {
        public FrmModifierPraticien()
        {
            InitializeComponent();
        }

        #region procédures événementielles
        private void FrmModifierPraticien_Load(object sender, EventArgs e)
        {
            parametrerComposant();
            afficher();
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            modifier();
        }

        #endregion

        #region méthodes

        private void parametrerComposant()
        {
            this.lblTitre.Text = "Modifier un Praticien";
            this.lblcbx.Text = "Praticien à mettre à jour :";
            this.lblNom.Text = "Nom :";
            this.lblPrenom.Text = "Prenom :";
            this.lblRue.Text = "Rue :";
            this.lblVille.Text = "Ville :";
            this.lblTel.Text = "Telephone :";
            this.lblType.Text = "Type :";
            this.lblEmail.Text = "Email :";
            this.lblSpe.Text = "Specialite :";

            btnModifier.BackColor = Color.Green;
            btnSupprimer.BackColor = Color.Red;

            btnModifier.Text = "Modifier";
            btnSupprimer.Text = "Supprimer";

            // alimentation de la zone de liste déroulante contenant les praticiens
            cbxPraticien.DataSource = Globale.LeVisiteur.getLesPraticiens();
            cbxPraticien.DisplayMember = "libelle";
            cbxPraticien.DropDownStyle = ComboBoxStyle.DropDownList;

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

        private void modifier()
        {
            if (tbxNom.Text == "" || tbxPrenom.Text == "" || tbxEmail.Text == "" || tbxRue.Text == "" || tbxTel.Text == "" || tbxVille.Text == "")
            {
                MessageBox.Show("Vous devez renseigner les champs Nom, Prenom, Rue, Ville, Telephone et Email !");
            } else
            {
                // récupération du praticien
                Praticien unPraticien = (Praticien)cbxPraticien.SelectedItem;

                // récupération de la spécialité
                Specialite uneSpecialite = (Specialite)cbxSpe.SelectedItem;

                // récupération du type
                TypePraticien unType = (TypePraticien)cbxType.SelectedItem;

                // récupération de la ville (pour le code postal)
                Ville uneVille = Globale.LesVilles.Find(x => x.Nom == tbxVille.Text);

                Passerelle.modifierPraticien(unPraticien.Id, tbxNom.Text, tbxPrenom.Text, tbxRue.Text, uneVille.Code, uneVille.Nom, tbxTel.Text, tbxEmail.Text, unType.Id, uneSpecialite.Id, out string message);
                MessageBox.Show("Praticien modifié");
            }
        }

        #endregion


    }
}
