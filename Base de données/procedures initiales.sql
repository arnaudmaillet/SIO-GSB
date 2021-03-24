-- -------------------------------------------
-- Programme : procédure.sql 
-- Objet : procédures stockées du projet GSB 
-- Serveur : MySQL Server 
-- Auteur : Guy Verghote 
-- Date : 04/03/2021
-- -------------------------------------------

use gsb;

drop procedure if exists getLesVisiteurs;
drop procedure if exists verifierConnexion;
drop procedure if exists getLesTypes;
drop procedure if exists getLesSpecialites;
drop procedure if exists getLesPraticiens;
drop procedure if exists getLesMotifs;
drop procedure if exists getLesFamilles;
drop procedure if exists getLesMedicaments;
drop procedure if exists getLesVisites;




-- getLesVisiteurs : retourne le nom et prénom des visiteurs
delimiter  $$
create procedure getLesVisiteurs() 
	select nom, prenom
	from visiteur 
	order by nom;
$$

-- verifierConnexion(nom, mdp) : retourne les coordonnées du visiteur dont le nom et le mot de passe sont passés en paramètre
create procedure verifierConnexion(nom varchar(25), mdp date) 
	select id, nom, prenom, rue, codePostal, ville, dateEmbauche
		from visiteur 
		where visiteur.nom = nom and visiteur.dateEmbauche = mdp
$$

-- retourne les enregistrements de la table TypePraticien
create procedure getLesTypes()
	Select id, libelle from TypePraticien order by libelle;
$$

-- retourne les enregistrements de la table Specialite
create procedure getLesSpecialites()
	Select id, libelle from Specialite order by libelle; 

$$

-- retourne les coordonnées des praticiens résidant dans le même département que le visiteur dont l'id est passé en paramètre
create procedure getLesPraticiens(idVisiteur varchar(3)) 
	  SELECT id, nom, prenom, rue, codePostal, ville, email, telephone, idType, idSpecialite 
      FROM praticien 
	  where substring(codePostal, 1, 2) = (SELECT substring(codePostal, 1, 2) from visiteur WHERE id = idVisiteur)
	  -- order by nom, prenom;
	  order by ville;
$$

-- retourne les enregistrements de la table Motif
create procedure getLesMotifs()
	Select id, libelle 
	from Motif
	order by libelle; 
$$

-- retourne les enregistrements de la table Famille
create procedure getLesFamilles()
	Select id, libelle 
	from Famille 
	order by libelle;
$$

-- retourne les enregistrements de la table Medicament
create procedure getLesMedicaments()
	SELECT id, nom, composition, effets, contreIndication, idFamille 
	FROM medicament
	order by nom;
$$

create procedure getLesVisites(idVisiteur varchar(3)) 
	SELECT id, dateEtHeure,  idMotif, idPraticien, bilan, premierMedicament, secondMedicament
	from visite
	where visite.idVisiteur = idVisiteur
	order by dateEtHeure;
$$ 





SHOW PROCEDURE STATUS where db = 'gsb';