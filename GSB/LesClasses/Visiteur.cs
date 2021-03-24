// ------------------------------------------
// Nom du fichier : visiteur.cs
// Objet : classe Visiteur
// Auteur : M. Verghote
// ------------------------------------------

using System;
using System.Collections.Generic;

namespace lesClasses
{
    [Serializable]
    public class Visiteur : Personne
    {

        private List<Visite> lesVisites;
        private List<Praticien> lesPraticiens;

        // Constructeur
        public Visiteur (string id, string nom, string prenom, string rue, string codePostal, string ville, DateTime dateEmbauche) 
            : base(nom, prenom, rue, codePostal, ville)
        {
            Id = id;
            DateEmbauche = dateEmbauche;
            lesVisites = new List<Visite>();
            lesPraticiens = new List<Praticien>();
        }

        // Propriétés
        public string Id { get; set; }
        public DateTime DateEmbauche { get; set; }

        #region méthodes
        
        // ajouter une visite dans la collection lesVisites et ordonner ceete collection
        public void ajouterVisite(Visite uneVisite)
        {
            lesVisites.Add(uneVisite);
            lesVisites.Sort();
        }

        // retourner la visite dont l'id est transmis en paramètre
        public Visite getLaVisite(int idVisite) => lesVisites.Find(x => x.Id == idVisite);

        // retourne la collection de toutes visites
        public List<Visite> getLesVisites() => lesVisites;  

        // retourne la collection des rendez-vous (visite dont la date n'est pas échue)
        public List<Visite> getLesRendezVous() => lesVisites.FindAll(x => x.DateEtHeure >= DateTime.Now);

        // retourne la collection des visites dont le bilan est à saisir (date échue et bilan non renseigné)
        public List<Visite> getLesBilansARemplir() => lesVisites.FindAll(x => x.DateEtHeure <= DateTime.Now && x.Bilan == null);

        // retourne la collection des visites close (bilan renseigné)
        public List<Visite> getLesVisitesCloses() => lesVisites.FindAll(x => x.Bilan != null);

        // retourne la collection des visites concernant un praticien
        public List<Visite> getLesVisites(Praticien unPraticien) => lesVisites.FindAll(x => x.LePraticien == unPraticien);

        // Supprimer de la collection lesVisites la visite transmise en parmaètre
        public bool supprimerVisite(Visite uneVisite) => lesVisites.Remove(uneVisite);

        // Modifier la date et l'heure d'une visite
        public void deplacerVisite(Visite uneVisite, DateTime uneDateEtHeure)
        {
            uneVisite.deplacer(uneDateEtHeure);
            lesVisites.Sort();
        }

        // retourne le nombre de visites
        public int getNbVisite() => lesVisites.Count;

        // retourne le nombre de rendez-vous
        public int getNbRendezVous() => lesVisites.FindAll(x => x.DateEtHeure >= DateTime.Now).Count;

        // retourne le nombre de visite à clôturer
        public int getNbBilanARemplir() => lesVisites.FindAll(x => x.DateEtHeure <= DateTime.Now && x.Bilan == null).Count;


        // ajouter un praticien dans la collection lesPraticiens
        public void ajouterPraticien(Praticien unPraticien) {
            lesPraticiens.Add(unPraticien);
            lesPraticiens.Sort();
        }

        // supprime un praticien de la collection lesPraticiens
        public void supprimerPraticien(Praticien unPraticien) => lesPraticiens.Remove(unPraticien);

        // retourne le praticien dont l'id est transmis en paramètre
        public Praticien getPraticien(int idPraticien) => lesPraticiens.Find(x => x.Id == idPraticien);

        // retourne les praticiens gérés par le visiteur
        public List<Praticien> getLesPraticiens() => lesPraticiens;
                       

        // Implémentation de la methode abstraite "getType()" qui retourne le type de l'objet.
        public override string getType()
        {
            return "Visiteur";
        }

        #endregion

    }
}
