// ------------------------------------------
// Nom du fichier : FrmMenu.cs
// Objet : Formulaire affichant la page d'accueil qui ne propose que le menu hérité
// Auteur : M. Verghote
// Date mise à jour : 05/03/2021
// ------------------------------------------

using System;
using System.Drawing;
using System.Windows.Forms;

namespace GSB
{
    public partial class FrmMenu : FrmBase
    {
        public FrmMenu()
        {
            InitializeComponent();
        }

        private void FrmMenu_Load(object sender, EventArgs e)
        {
           
            parametrerComposant();
        }

        private void parametrerComposant()
        {
            // paramétrage de la fenêtre
            lblTitre.Text = "Bienvenue sur l'application de gestion des visites";
            imgGsb.Location = new Point(this.Width / 2 - imgGsb.Width / 2, this.Height / 2 - imgGsb.Height / 2);
        }
    }
}
