// ------------------------------------------
// Nom du fichier : FrmConnexion.cs
// Objet : Formulaire de connexion
// Auteur : M. Verghote
// ------------------------------------------

using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using lesClasses;

namespace GSB
{
    public partial class FrmConnexion : Form
    {
        public FrmConnexion()
        {
            InitializeComponent();
        }

        #region procédures événementielles

        // au chargement du formulaire, il faut paramètrer ses composants
        // dans le cadre du développement les champs de saisie sont pré remplis
        private void FrmConnexion_Load(object sender, EventArgs e)
        {
            parametrerComposant();
            txtMdp.Text = "19910826";
            txtNom.Text = "andre";
        }

        // Déclenchement du contrôle de la connexion
        private void btnConnecter_Click(object sender, EventArgs e)
        {
            seConnecter(txtNom.Text, txtMdp.Text);
        }

        // Quitter l'application
        private void btnQuitter_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region méthodes

        // Paramètrage des composants de la fenêtre
        private void parametrerComposant()
        {
            this.Text = "Connexion";
            this.ControlBox = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
        }

        // contrôle que le champ txtNom est renseigné
        private bool controlerLogin(string nom)
        {
            if (nom == string.Empty)
            {
                messageNom.Text = "Champ obligatoire";
                messageNom.Visible = true;
                return false;
            }
            txtNom.Text = nom;
            messageNom.Text = "";
            messageNom.Visible = false;
            return true;
        }

        // contr$ôle que le mot de passe est renseigné et qu'il respecte un format sur 8 chiffres (utilisation d'une expression régulière)
        private bool controlerMdp(string mdp)
        {
            if (mdp == string.Empty)
            {
                messageMdp.Text = "Champ obligatoire";
                messageMdp.Visible = true;
                return false;
            }
            Regex uneExpression = new Regex(@"^[0-9]{8}$");
            if (!uneExpression.IsMatch(mdp))
            {
                messageMdp.Text = "Format invalide";
                messageMdp.Visible = true;
                return false;
            }
            messageMdp.Text = "";
            messageMdp.Visible = false;
            return true;
        }

        private void seConnecter(string login, string mdp)
        {
            bool nomOk = controlerLogin(login);
            bool mdpOk = controlerMdp(mdp);
            if (nomOk && mdpOk)
            {

                // constitution du mot de passe : génération de date d'embauche au format aaaa-mm-jj 
                int day = int.Parse(mdp.Substring(6, 2));
                int month = int.Parse(mdp.Substring(4, 2));
                int year = int.Parse(mdp.Substring(0, 4));
                string password = year + "-" + month + "-" + day;

                bool ok = Passerelle.seConnecter(login, password, out string message);
                if (ok)
                {
                    // chargement des données
                    Passerelle.chargerDonnees();
                    // On conserve le lien vers le formulaire atuel afin de pouvoir le fermer quand 
                    Globale.FormulaireParent = this;
                    // on instancie un nouveau formulaire
                    FrmMenu unFrmMenu = new FrmMenu();
                    // on ferme le formulaire actuel 
                    this.Hide();
                    // on affiche le formulaire Menu
                    unFrmMenu.Show();
                }
                else
                {
                    MessageBox.Show("Contactez le service informatique \n" + message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
        #endregion
    }
}
