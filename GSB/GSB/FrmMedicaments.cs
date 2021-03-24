// ------------------------------------------
// Nom du fichier : FrmMedicaments.cs
// Objet : Formulaire de consultation de l'ensemble des médicaments
// Auteur : M. Verghote
// Date mise à jour : 16/03/2021
// ------------------------------------------
using System;
using System.Drawing;
using System.Windows.Forms;
using lesClasses;
using System.Collections.Generic;

namespace GSB
{
    public partial class FrmMedicaments : FrmBase
    {
        public FrmMedicaments()
        {
            InitializeComponent();  
        }

        #region procédures événementielles

        // Au chargement du formulaire
        private void FrmMedicaments_Load(object sender, EventArgs e)
        {
            parametrerComposant();
            afficher();
        }

        private void btnAfficher_Click(object sender, EventArgs e)
        {
            afficher();
        }
        #endregion

        #region méthodes

        // Mise en forme des composants utilisés 
        private void parametrerComposant()
        {
            this.lblTitre.Text = "Consultation des medicaments";
            this.cbxMedicaments.DataSource = Globale.LesMedicaments;
            this.btnAfficher.Text = "";

            // Les labels
            this.lblMedicaments.Text = "Medicament";
            this.lblFamille.Text = "Famille";
            this.lblComposition.Text = "Composition";
            this.lblEffet.Text = "Effets";
            this.lblContreIndication.Text = "Contre Indication";
            

            // L'affichage
            this.lblAffichageFamille.Text = "";
            this.lblAffichageComposition.Text = "";
            this.lblAffichageEffet.Text = "";
            this.lblAffichageContreIndication.Text = "";

        }


        private void afficher()
        {
            Medicament unMedicament = (Medicament)cbxMedicaments.SelectedItem;
            this.lblAffichageFamille.Text = unMedicament.LaFamille.Libelle;
            this.lblAffichageComposition.Text = unMedicament.Composition;
            this.lblAffichageEffet.Text = unMedicament.Effets;
            this.lblAffichageContreIndication.Text = unMedicament.ContreIndication;
        }
        #endregion
    }
}
