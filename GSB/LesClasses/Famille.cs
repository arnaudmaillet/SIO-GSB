// ------------------------------------------
// Nom du fichier : famille.cs
// Objet : classe famille
// Auteur : M. Verghote
// ------------------------------------------

using System;
using System.Collections.Generic;

namespace lesClasses
{
    [Serializable]
    public class Famille
    {

        // Constructeur
        public Famille (string id, string libelle) 
            => (Id, Libelle, LesMedicaments) = (id, libelle, new List<Medicament>());
        

        // Propriétés automatiques
        public string Id { get; set; }
        public string Libelle { get; set; }
        public List<Medicament> LesMedicaments { get; }

        // méthode
        public void ajouterMedicament(Medicament unMedicament)
        {
            LesMedicaments.Add(unMedicament);
        }
    
    }
}
