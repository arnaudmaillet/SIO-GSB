// ------------------------------------------
// Nom du fichier : motif.cs
// Objet : classe Motif
// Auteur : M. Verghote
// ------------------------------------------

namespace lesClasses
{
    public class Motif
    {
        // Constructeur
        public Motif (int id, string libelle)
         => (Id, Libelle)  = (id, libelle);
            

        // Propriétés
        public int Id { get; set; }
        public string Libelle { get; set; }

    }
}
