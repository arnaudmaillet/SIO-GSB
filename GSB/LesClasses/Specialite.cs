// ------------------------------------------
// Nom du fichier : specialite.cs
// Objet : Définition de la classe Specialite
// Auteur : M. Verghote
// ------------------------------------------

namespace lesClasses
{
    public class Specialite
    {
        // Constructeur
        public Specialite(string id, string libelle)
         => (Id,  Libelle) = (id, libelle);

        // Propriétés automatiques
        public string Id { get; set; }
        public string Libelle { get; set; }
    }
}
