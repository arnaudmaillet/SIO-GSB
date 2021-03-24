// ------------------------------------------
// Nom du fichier : Passerelle.cs
// Objet : classe Passerelle assurant l'alimentation des objets en mémoire
// Auteur : M. Verghote
// Date mise à jour : 11/03/2021
// ------------------------------------------

using System;
using System.Data;   // pour ParameterDirection
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Collections.Generic;
using lesClasses;

namespace GSB
{
    static class Passerelle
    {
        private static readonly ConnectionStringSettings uneChaine = ConfigurationManager.ConnectionStrings["sgbd"];
        private static readonly MySqlConnection cnx = new MySqlConnection(uneChaine.ConnectionString);

        /// <summary>
        /// Vérifier la connexion à la base de données 
        /// </summary>
        /// <param name="message">la raison de l'erreur</param>
        /// <returns>true si la connexion est fonctionnelle false sinon</returns>
        static public bool testConnexion(out string message)
        {
            bool ok = true;
            message = "";
            try
            {
                cnx.Open();
            }
            catch (MySqlException e)
            {
                ok = false;
                message = "Erreur lors de la tentative de connexion à la base de données \n";
                message += "Vérifier si le serveur est bien lancé et accessible \n";
                message += "Vérifier si les paramètres de connexion sont valides \n";
                // message = e.ToString();
                // message += e.ToString().Split('-')[0];
                // message += e.ToString().Split(new string[] { "--->"}, StringSplitOptions.None)[0];
                 message += e.ToString().Split('\n')[0];
            }
            catch (Exception e)
            {
                ok = false;
                message = e.ToString();
            }
            finally
            {
                cnx.Close();
            }
            return ok;
        }
       

        // Vérifier les paramètres de connexion et alimente l'objet globale leVisiteur
        static public bool seConnecter(string nom, string mdp, out string message)
        {
            bool ok;
           
            cnx.Open();
            MySqlCommand cmd = new MySqlCommand()
            {
                Connection = cnx,
                CommandText = "verifierConnexion",
                CommandType = CommandType.StoredProcedure,
            };
            cmd.Parameters.AddWithValue("nom", nom);
            cmd.Parameters.AddWithValue("mdp", mdp);
            try
            {
                MySqlDataReader curseur = cmd.ExecuteReader();
                if (curseur.Read())
                {
                    string id = (string)curseur["id"]; ;
                    string prenom = (string)curseur["prenom"];
                    string rue = (string)curseur["rue"];
                    string codePostal = (string)curseur["codePostal"];
                    string ville = (string)curseur["ville"];
                    // DateTime uneDateEmbauche = (DateTime)curseur["dateEmbauche"];
                    DateTime uneDateEmbauche = curseur.GetDateTime(6);
                    Globale.LeVisiteur = new Visiteur(id, nom, prenom, rue, codePostal, ville, uneDateEmbauche);
                    ok = true;
                    message = "Visiteur authentifié";
                }
                else
                {
                    Globale.LeVisiteur = null;
                    ok = false;
                    message = "Les paramètres de connexion sont incorrects";
                }
            }
            catch(MySqlException e) 
            {
                ok = false;
                message = "La fonction d'identification est absente sur le serveur, contacter la maintenance \n";
                // message += e.ToString();
                message += e.ToString().Split('\n')[0];

            }
            catch (Exception e)  // erreur non prévue 
            {
                ok = false;
                message = e.ToString();

            }
            finally
            {
                cnx.Close();
            }
            return ok;
        }
    
        // chargement des données de la base dans les différentes collections statique de la classe Globale 
        // dans cette méthode pas de bloc try catch car aucune erreur imprévisible en production ne doit se produire
        // en cas d'erreur en développement il faut laisser faire le debogueur de VS qui va signaler la ligne en erreur
        static public void chargerDonnees()
        {
            cnx.Open();

            // Chargement des objets Motifs
            MySqlCommand cmd = new MySqlCommand()
            {
                Connection = cnx,
                CommandText = "getLesMotifs",
                CommandType = CommandType.StoredProcedure
            };
            var curseur = cmd.ExecuteReader();
            while (curseur.Read())
            {
                int id = (Int32)curseur["id"];
                string unLibelle = (string)curseur["libelle"];
                // création de l'objet et ajout dans donnees
                Motif unMotif = new Motif(id, unLibelle);
                Globale.LesMotifs.Add(unMotif);
            }
            curseur.Close();

            // Chargement des objets TypePraticien : on utilise le même objet Command on change juste le nom de la procédure stockée à exécuter
            
            cmd.CommandText = "getLesTypes";
            curseur = cmd.ExecuteReader();
            while (curseur.Read())
            {
                string id = curseur["id"].ToString();
                string unLibelle = curseur["libelle"].ToString();
                // création de l'objet et ajout dans donnees
                TypePraticien unType = new TypePraticien(id, unLibelle);
                Globale.LesTypes.Add(unType);
            }
            curseur.Close();


            // Chargement des objets Specialite
            cmd.CommandText = "getLesSpecialites";
            curseur = cmd.ExecuteReader();
            while (curseur.Read())
            {
                string id = curseur["id"].ToString();
                string unLibelle = curseur["libelle"].ToString();
                // création de l'objet et ajout dans donnees
                Specialite uneSpecialite = new Specialite(id, unLibelle);
                Globale.LesSpecialites.Add(uneSpecialite);
            }
            curseur.Close();

            // Chargement des objets Famille
            cmd.CommandText = "getLesFamilles";
            curseur = cmd.ExecuteReader();
            while (curseur.Read())
            {
                string id = (string)curseur["id"];
                string unLibelle = (string)curseur["libelle"];
                // création de l'objet et ajout dans donnees
                Famille uneFamille = new Famille(id, unLibelle);
                Globale.LesFamilles.Add(id, uneFamille);
            }
            curseur.Close();

            // chargement des objets médicaments
            cmd.CommandText = "getLesMedicaments";
            curseur = cmd.ExecuteReader();
            while (curseur.Read())
            {
                string id = (string)curseur["id"];
                string nom = (string)curseur["nom"];
                string composition = (string)curseur["composition"];
                string effet = (string)curseur["effets"];
                string contreIndication = (string)curseur["contreIndication"];
                string idFamille = (string)curseur["idFamille"];
                // récupération de l'objet Famille
                Famille uneFamille = Globale.LesFamilles[idFamille];
                // création de l'objet et ajout dans donnees
                Medicament unMedicament = new Medicament(id, nom, composition, effet, contreIndication, uneFamille);
                Globale.LesMedicaments.Add(unMedicament);
            }
            curseur.Close();

            // chargement des praticiens
            cmd.CommandText = "getLesPraticiens";
            cmd.Parameters.AddWithValue("idVisiteur", Globale.LeVisiteur.Id);
            curseur = cmd.ExecuteReader();
            while (curseur.Read())
            {
                int id = (Int32)curseur["id"];
                string nom = (string)curseur["nom"];
                string prenom = (string)curseur["prenom"];
                string rue = (string)curseur["rue"];
                string codePostal = (string)curseur["codePostal"];
                string ville = (string)curseur["ville"];
                string email =  (string)curseur["email"];
                string telephone =  (string)curseur["telephone"];
                string idType = (string)curseur["idType"];
                string idSpecialite = curseur.IsDBNull(9) ? null : (string)curseur["idSpecialite"];
                // création de l'objet et ajout dans l'objet db.LeVisiteur
                TypePraticien unType = Globale.LesTypes.Find(x => x.Id == idType);
                Specialite uneSpecialite = null;
                if (idSpecialite != null)
                {
                    uneSpecialite = Globale.LesSpecialites.Find(x => x.Id == idSpecialite);
                }

                Praticien unPraticien = new Praticien(id, nom, prenom, rue, codePostal, ville, email, telephone, unType, uneSpecialite);
                Globale.LeVisiteur.ajouterPraticien(unPraticien);
            }
            curseur.Close();


            // chargement des visites du visiteur connecté
            cmd.CommandText = "getLesVisites";
            // pas de changement au niveau des paramètres à transmettre : on garde l'id du visiteur avec la même valeur
            curseur = cmd.ExecuteReader();
            while (curseur.Read())
            {
                int idVisite = (Int32)curseur["id"];
                int idPraticien = (Int32) curseur["idPraticien"];
                int idMotif = (Int32) curseur["idMotif"];
           
                DateTime dateEtHeure = curseur.GetDateTime(1);
                // récupération des objets liés
                Motif unMotif = Globale.LesMotifs.Find(x => x.Id == idMotif);
                Praticien unPraticien = Globale.LeVisiteur.getPraticien(idPraticien);
                // création de l'objet visite qui est automatiquement ajouté dans la collection des visites du visiteur
                Visite uneVisite = new Visite(idVisite, unPraticien, unMotif, dateEtHeure, Globale.LeVisiteur);
                // si le bilan est enregistré
                if (! curseur.IsDBNull(4))
                {
                    // initialisation du bilan et du premierMedicament
                    string bilan = curseur["bilan"].ToString();
                    string idMedicament = curseur["premierMedicament"].ToString();
                    Medicament premier =  Globale.LesMedicaments.Find(x => x.Id == idMedicament);
                    Medicament second = null;
                    // initialisation éventuelle du second médicament s'il est renseigné
                    if (! curseur.IsDBNull(6))
                    {
                        idMedicament = curseur["secondMedicament"].ToString();
                        second = Globale.LesMedicaments.Find(x => x.Id == idMedicament);
                    }
                    uneVisite.enregistrerBilan(bilan, premier, second);
                    // le chargement des échantillons s'effetue globalement à la fin
                }
            }
            curseur.Close();

            // chargement de la synthèse des échantillons distribués par le visiteur
            cmd.CommandText = "getLesEchantillons";
            // pas de changement au niveau des paramètres à transmettre : on garde l'id du visiteur avec la même valeur
            curseur = cmd.ExecuteReader();
            while (curseur.Read())
            {
                string idMedicament = curseur["idMedicament"].ToString();
                int quantite = (Int32) curseur["quantite"];
                int idVisite = (Int32)curseur["idVisite"];

                Visite uneVisite = Globale.LeVisiteur.getLaVisite(idVisite);

                uneVisite.ajouterEchantillon(Globale.LesMedicaments.Find(x => x.Id == idMedicament), quantite); 
            }

            // chargement des villes du département du visiteur pour la mise en place de l'auto complétion sur l'ajout d'un praticien
            // [ à compléter]
            cnx.Close();
        }


        /// <summary>
        ///     Ajout d'une nouvelle visite
        /// </summary>
        /// <param name="idPraticien"></param>
        /// <param name="idMotif"></param>
        /// <param name="uneDate"></param>
        /// <param name="uneHeure"></param>
        /// <param name="message"></param>
        /// <returns>identifiant de la nouvelle visite ou 0 si erreur lors de la création</returns>
        static public int ajouterRendezVous(int idPraticien, int idMotif, DateTime uneDate, out string message)
        {
            int idVisite = 0;
            message = string.Empty;

            // Ouverture de la connection a la base
            cnx.Open();

            // Chargement des objets Motifs
            MySqlCommand cmd = new MySqlCommand()
            {
                Connection = cnx,
                CommandText = "ajouterRendezVous",
                CommandType = CommandType.StoredProcedure
            };
            // Définition des parametres à transmettre
            cmd.Parameters.AddWithValue("idVisiteur", Globale.LeVisiteur.Id);
            cmd.Parameters.AddWithValue("idPraticien", idPraticien);
            cmd.Parameters.AddWithValue("idMotif", idMotif);
            cmd.Parameters.AddWithValue("dateEtHeure", uneDate);

            // Définition d'un parametre en sortie
            cmd.Parameters.Add("idVisite", MySqlDbType.Int32);
            cmd.Parameters["idVisite"].Direction = ParameterDirection.Output;

            try
            {
                cmd.ExecuteNonQuery();
                idVisite = (Int32)cmd.Parameters["idVisite"].Value;
            }
            catch (MySqlException e)
            {
                message = e.Message;
                message += e.ToString().Split('\n')[0];
            }
            cnx.Close();
            return idVisite;
        }

        static public bool supprimerRendezVous(int idVisite, out string message)
        {
            message = string.Empty;
            return false;
        }

        static public bool modifierRendezVous(int idVisite, DateTime uneDateEtHeure, out string message)
        {
            message = string.Empty;
            return false;
        }

        static public bool enregistrerBilan(Visite uneVisite, out string message)
        {
            message = string.Empty;
            return false;
        }


        static public int ajouterPraticien(string nom, string prenom, string rue, string codePostal, string ville, string telephone, string email, string unType, string uneSpecialite, out string message)
        {
            message = string.Empty;
            
            return 0;
        }


        static public bool modifierPraticien(int id, string nom, string rue, string codePostal, string ville, string telephone, string email, out string message)
        {
            message = string.Empty;
            
            return false;
        }

        static public bool supprimerPraticien(int id, out string message)
        {
            message = string.Empty;
            return false;
        }

    }
}
