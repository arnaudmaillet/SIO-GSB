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
    public partial class FrmAjoutPraticien : Form
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
        }

        //sur le clic du bouton ajouter
        private void btnAjouter_MouseClick(object sender, MouseEventArgs e)
        {

        }

        #endregion

        #region méthodes

        private void parametrerComposant()
        {
            this.lblNom.Text = "Nom :";
            this.lblPrenom.Text = "Prenom :";
            this.lblRue.Text = "Rue :";
            this.lblVille.Text = "Ville :";
            this.lblTel.Text = "Telephone :";
            this.lblType.Text = "Type :";
            this.lblEmail.Text = "Email :";
            this.lblSpe.Text = "Specialite :";

            btnAjouter.BackColor = Color.Red;

        }

        #endregion
    }
}
