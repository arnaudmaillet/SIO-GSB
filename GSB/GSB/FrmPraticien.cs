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
    public partial class FrmPraticien : FrmBase
    {
        public FrmPraticien()
        {
            InitializeComponent();
        }

        #region procédures événementielles

        // Au chargement du formulaire
        private void FrmPraticien_Load(object sender, EventArgs e)
        {
            this.lblTitre.Text = "Liste des Praticiens";
        }

        #endregion

        #region méthodes

        private void parametrerComposant()
        {

        }

        #endregion


    }
}
