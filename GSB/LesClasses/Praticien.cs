// ------------------------------------------
// Nom du fichier : praticien.cs
// Objet : classe Praticien
// Auteur : M. Verghote
// ------------------------------------------



using System.Collections.Generic;

namespace lesClasses
{
    public class Praticien : Personne
    {
        // Constructeur
        public Praticien (int id, string nom, string prenom, string rue, string codePostal, string ville, string email, string telephone, TypePraticien type, Specialite specialite) 
            : base (nom, prenom, rue, codePostal, ville)
        {
            Id = id;
            Email = email;
            Telephone = telephone;
            Type = type;
            Specialite = specialite;
        }

        // Propriétés automatiques
        public int Id { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        public TypePraticien Type { get; set;}
        public Specialite Specialite { get; set; }


        // Méthodes 
        public override string getType()  { return "Praticien"; }



       
    }
}
