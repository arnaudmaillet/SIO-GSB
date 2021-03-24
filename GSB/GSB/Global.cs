// ------------------------------------------
// Nom du fichier : global.cs
// Objet : classe statique Globale regroupant les données globales de l'application
// Auteur : M. Verghote
// Date mise à jour : 03/03/2019
// ------------------------------------------

using lesClasses;
using System.Collections.Generic;
using System.Windows.Forms;


namespace GSB
{
    class Globale
    {
        // données globale de l'application
        // Les collections et le dictionnaire contiennent les données non liées directement au visiteur : les médicaments, les types de praticiens, les spécialites les villes et les familles
        // LeVisiteur : l'objet visiteur connecté
        // FormulaireParent : Pointe le formulaire de connexion qui doit rester ouvert (caché) afin de pouvoir le fermer quand l'utilisateur quitte l'application par le menu

        public static SortedDictionary<string, Famille> LesFamilles = new SortedDictionary<string, Famille>();
        public static List<Medicament> LesMedicaments = new List<Medicament>();
        public static List<Motif> LesMotifs = new List<Motif>();
        public static List<TypePraticien> LesTypes = new List<TypePraticien>();
        public static List<Specialite> LesSpecialites = new List<Specialite>();
        public static List<Ville> LesVilles = new List<Ville>();
        public static Visiteur LeVisiteur = null;
        public static Form FormulaireParent = null;
        
    }


}

