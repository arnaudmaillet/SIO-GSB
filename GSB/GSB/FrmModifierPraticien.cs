using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
        }

        #endregion
    }
}
