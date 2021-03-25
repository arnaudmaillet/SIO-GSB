// ------------------------------------------
// Nom du fichier : FrmBase.cs
// Objet : Formulaire de base hérité par tous les formulaires
//         afin de posséder la même ergonomie
// Auteur : M. Verghote
// Date mise à jour : 09/03/2021
// ------------------------------------------

using System;
using System.Drawing;
using System.Windows.Forms;

namespace GSB
{
    public partial class FrmBase : Form
    {
        // La croix de la fenêtre peut fermer le formulaire 
        // cela pose un problème car l'application se sera plus accessible mais elle reste en mémoire (processus)
        // car le formulaire principal (connexion) n'est pas fermé (il est caché)
        // Le formulaire de connexion ne peut pas être fermé avant car c'est le formulaire initial sa fermeture entraine la fermeture de l'application
        // En résumé la croix ferme le formulaire courant mais doit aussi fermet le formulaire parent cela ne peut se faire que sur l'événement formClosing
        // Les options du menu doivent fermer le formulaire courant (ce qui déclenche donc l'événement form closing) et ouvrir un nouveau formulaire
        // l'événement form closing doit donc fermer le formiulaire parent uniquement si l'appel est déclenché par la croix
        // comment le savoir ? on utilise une variable initialisée à 0 et qui passe à un sur chaque option du menu.
        // Ainsi si sa valeur reste à 0 c'est que la fermeture a été demandée en cliquant sur la croix
        
        private int surFermeture = 0; // 1 ne rien faire,  0 : fermer le formulaireParent (connexion donc quitter l'application)
         
        public FrmBase()
        {
            InitializeComponent();
        }

        #region procédures événementielles
        // paramétrer les composants du formulaire au chargement
        private void FrmBase_Load(object sender, EventArgs e)
        {
            parametrerComposant();
           
        }
         
        
        // consultation des médicaments
        private void ficheMédicamentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmMedicaments unFrmConsultationMedicaments = new FrmMedicaments();
            unFrmConsultationMedicaments.Show();
            surFermeture = 1;

            Close();
        }

     
        // sur la fermeture du formulaire, on ferme aussi le formulaire de connexion si l'utilisateur a fermé le formulaire par la croix
        private void FrmBase_FormClosing(object sender, FormClosingEventArgs e)
        {
           // on fermer le formulaire principal (le formulaire de connexion)
           if (surFermeture == 0 )
                Globale.FormulaireParent.Close();
        }
                
        // Le clic sur le bouton déconnecter ferme le formualire et affiche le formulaire de connexion 
        private void btnDeconnecter_Click(object sender, EventArgs e)
        {
            // correctif : il faut vider les objets de la classe globale
            Globale.LesFamilles.Clear();
            Globale.LesMedicaments.Clear();
            Globale.LesMotifs.Clear();
            Globale.LesSpecialites.Clear();
            Globale.LesTypes.Clear();
            Globale.LesVilles.Clear();
            Globale.LeVisiteur = null;

            Globale.FormulaireParent.Show();
            surFermeture = 1;
            Close();
        }

        // ajout d'un rendez-vous
        private void programmerRendezVous_Click(object sender, EventArgs e)
        {
            FrmAjout unFrmSaisieVisite = new FrmAjout();
            unFrmSaisieVisite.Show();
            surFermeture = 1;
            Close();

        }

        // déplacer un rendez vous (changement de date et heure)
        private void modifierRendezVous_Click(object sender, EventArgs e)
        {

            FrmModifierRDV unFrmSaisieVisite = new FrmModifierRDV();
            unFrmSaisieVisite.Show();
            surFermeture = 1;
            Close();
        }

        // imprimer les rendez-vous sur une période donnée
        private void imprimerRendezvous_Click(object sender, EventArgs e)
        {
           
      
            Close();
        }

        // cloturer une visite en enregistrant le bilan, les médicaments présentés et les échantillons fournis
        private void enregistrerBilan_Click(object sender, EventArgs e)
        {
            
            Close();
        }

        // consulter l'ensemble des visites réalisées
        private void consulterVisite_Click(object sender, EventArgs e)
        {
            FrmConsultation unFrmVoirVisite = new FrmConsultation();
            unFrmVoirVisite.Show();
            surFermeture = 1;
            Close();
        }

        // consulter l'ensemble des échantillons distribués par le visiteur connecté
        private void voirEchantillon_Click(object sender, EventArgs e)
        {
          
  
            Close();
        }

        // consulter la liste des praticiens gérés par le visiteur
        private void listePraticien_Click(object sender, EventArgs e)
        {
            FrmPraticien unFrmPraticien = new FrmPraticien();
            unFrmPraticien.Show();
            surFermeture = 1;
            Close();
        }

        // ajouter un nouveau praticien
        private void nouveauPraticien_Click(object sender, EventArgs e)
        {
            FrmAjoutPraticien unFrmAjoutPraticien = new FrmAjoutPraticien();
            unFrmAjoutPraticien.Show();
            surFermeture = 1;
            Close();
        }

        // Modifier les coordonnées d'un praticien
        private void modifierPraticien_Click(object sender, EventArgs e)
        {
            FrmModifierPraticien unFrmModifierPraticien = new FrmModifierPraticien();
            unFrmModifierPraticien.Show();
            surFermeture = 1;
            Close();
        }


        #endregion

        #region procédure

        private void parametrerComposant()
        {
            if (DesignMode) return;
            Text = "Laboratoire pharmaceutique Galaxy-Swiss Bourdin - Gestion des visites";
            lblVisiteur.Text = "Visiteur : " + Globale.LeVisiteur.NomPrenom;

            // utiliser l'écran le plus petit
            // Recherche de la taille des écrans pour se mettre au dimension de l'écran le plus petit si l'utilisateur possède plusieurs écrans
            Screen[] lesEcrans = Screen.AllScreens;
            int i = 0;
            for (int j = 1; j < lesEcrans.Length; j++)
                if (lesEcrans[j].Bounds.Width < lesEcrans[i].Bounds.Width)
                    i = j;
            // on définit la taille de la fenêtre possible
            Height = lesEcrans[i].WorkingArea.Height;
            Width = lesEcrans[i].WorkingArea.Width;
            // on définit le coin supérieur gauche
            StartPosition = FormStartPosition.Manual;
            Location = new Point(lesEcrans[i].Bounds.X, lesEcrans[i].Bounds.Y);
            /*

            // si on veut toujours utiliser l'écran courant
            Screen monEcran = Screen.FromControl(this); 
            Height = monEcran.WorkingArea.Height;
            Width = monEcran.WorkingArea.Width;
            Location = new Point(monEcran.Bounds.X, monEcran.Bounds.Y);

            // si on veut toujours utiliser l'écran principal  :
            Height = Screen.PrimaryScreen.WorkingArea.Height;
            Width = Screen.PrimaryScreen.WorkingArea.Width;
            Location = new Point(0, 0);

    
            // si on définit une taille fixe adaptée aux formulaires de l'application on centre la fenêtre
            Height = 900;
            Width = 1440;
            Location = new Point((Screen.PrimaryScreen.WorkingArea.Width - this.Width) / 2, (Screen.PrimaryScreen.WorkingArea.Height - this.Height) / 2);
         */

            ControlBox = true;
            MaximizeBox = true;
            MinimizeBox = true;

            // il faut éventuellement desactiver certaines options du menu selon les données 
            // on ne peut déplacer un rendez-vous si le visiteur n'a aucun rendez vous 
            // on ne peut cloturer une visite si le visiteur n'a aucune visite à clôturer (tous les bilans sont déja renseignés
            // on ne peut pas visualiser toutes les visites s'il n'en existe aucune

            modifierRendezVous.Enabled = Globale.LeVisiteur.getNbRendezVous() > 0;
            enregistrerBilan.Enabled = Globale.LeVisiteur.getNbBilanARemplir() > 0;
            consulterVisite.Enabled = Globale.LeVisiteur.getNbVisite() > 0;
        }

        #endregion

    }
}
