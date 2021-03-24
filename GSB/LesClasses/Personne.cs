// ------------------------------------------
// Nom du fichier : personne.cs
// Objet : classe Personne
// Auteur : M. Verghote
// ------------------------------------------

using System;

namespace lesClasses
{
    public abstract class Personne : IComparable<Personne>
    {

        // Le tri par défaut d'un conteneur d'objets dérivés de la classe Personne se fera sur le nom et le prénom
        
        public int CompareTo(Personne o)
        {
            int res = Nom.CompareTo(o.Nom);
            if (res == 0)
            {
                res = Prenom.CompareTo(o.Prenom);
            }
            return res;
        }
    
      
        // Constructeur
        public Personne(string nom, string prenom, string rue, string codePostal, string ville)
        {
            Nom = nom;
            Prenom = prenom;
            Rue = rue;
            CodePostal = codePostal;
            Ville = ville;
        }
      
        // Propriétés automatiques
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Rue { get; set; }
        public string CodePostal { get; set; }
        public string Ville { get; set; }
        public string NomPrenom { get { return Nom + " " + Prenom; } }

        public override string ToString() => NomPrenom;

        // Méthodes abstraite qui devrai être défini dans les classes dérivées 
        public abstract string getType();
    }
}
