// ------------------------------------------
// Nom du fichier : visite.cs
// Objet : Définition de la classe Visite
// Auteur : M. Verghote
// ------------------------------------------

using System;
using System.Collections.Generic;

namespace lesClasses
{
    [Serializable]
    public class Visite : IComparable<Visite>
    {

        // la classe doit implémenter une méthode de comparaison car les objets Visite
        // seront utilisées dans une collection qui sera trié après chaque ajout

        public int CompareTo(Visite o)
        {
            return DateEtHeure.CompareTo(o.DateEtHeure);
        }

        // attribut privé
        private SortedDictionary<Medicament, int> lesEchantillons;

        // Propriétés automatique
        public int Id { get; }

        public Visiteur LeVisiteur { get; private set; }
        public Praticien LePraticien { get; set; }
        public Motif LeMotif { get; set; }
        public DateTime DateEtHeure { get; private set; }
        public string Bilan { get; set; }
        public Medicament PremierMedicament { get; set; }
        public Medicament SecondMedicament { get; set; }

    

        // Constructeur
        
        public Visite(int id, Praticien unPraticien, Motif unMotif, DateTime uneDateEtHeure, Visiteur unVisiteur)
        {
            Id = id;
            LePraticien = unPraticien;
            LeMotif = unMotif;
            DateEtHeure = uneDateEtHeure;
            Bilan = null;
            PremierMedicament = null;
            SecondMedicament = null;
            LeVisiteur = unVisiteur;
            // mise à jour de la relation bidirectionnelle
            LeVisiteur.ajouterVisite(this);

            lesEchantillons = new SortedDictionary<Medicament, int>();
        }

        public void enregistrerBilan(string bilan, Medicament premierMedicament, Medicament secondMedicament)
        {
            (Bilan, PremierMedicament, SecondMedicament) = (bilan, premierMedicament, secondMedicament);
        }

        public void deplacer(DateTime uneDateEtHeure) => DateEtHeure = uneDateEtHeure;


        // ajoute un échantillon
        // si le médicament est déjà dans le dictionnaire on cumule les quantités
        public void ajouterEchantillon(Medicament unMedicament, int uneQuantite)
        {
            if (lesEchantillons.ContainsKey(unMedicament))
            {
                lesEchantillons[unMedicament] += uneQuantite;
            } else
            {
                lesEchantillons.Add(unMedicament, uneQuantite);
            }
        }

        // supprimer un échantillon
        public void supprimerEchantillon(Medicament unMedicament)
        {
            lesEchantillons.Remove(unMedicament);
        }

        // retourne le dictionnaire des échantillons
        public SortedDictionary<Medicament, int> getLesEchantillons() => lesEchantillons;

        // retourne true si le médicament est dans les échantillons de cette visite
        public bool contenir(Medicament unMedicament) => lesEchantillons.ContainsKey(unMedicament);


        public int getQuantite(Medicament unMedicament) => lesEchantillons.ContainsKey(unMedicament) ? lesEchantillons[unMedicament] : 0;

    }
       
}
