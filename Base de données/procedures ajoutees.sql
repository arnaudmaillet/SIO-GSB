-- -------------------------------------------
-- Programme : procedures ajoutees.sql 
-- Objet : procédures stockées du projet GSB 
-- Serveur : MySQL 
-- Auteur : 
-- Date : 
-- -------------------------------------------

use gsb;

-- ajouter un rendez-vous

drop procedure if exists ajouterRendezVous;
delimiter $$
create procedure ajouterRendezVous(idVisiteur varchar(3), idPraticien int, idMotif int, dateEtHeure datetime, out idVisite int)
begin
	insert into visite(idVisiteur, idPraticien, idMotif, dateEtHeure)
    values (idVisiteur, idPraticien, idMotif, dateEtHeure);
    set idVisite = (select @@identity);
end
$$


-- enregistrer le bilan d'une visite

drop procedure if exists enregistrerBilanVisite;
delimiter $$
create procedure enregistrerBilanVisite
	
$$


-- modifier la planification d'une visite

drop procedure if exists modifierRendezVous;
delimiter $$
create procedure modifierRendezVous (dateEtHeure datetime, idVisite int)
begin
	update visite
	set dateEtHeure = uneDateEtHeure
	where idVisite = idVisite;
end
$$


-- supprimer une visite

drop procedure if exists supprimerRendezVous;
delimiter $$
create procedure supprimerRendezVous 
		
$$


-- ajouter un praticien

drop procedure if exists ajouterPraticien;
delimiter $$
create procedure ajouterPraticien(nom varchar(25), prenom varchar(30), rue varchar(50), codePostal char(5), ville varchar(30), telephone char(14), email varchar(75), idType varchar(3), idSpecialite varchar(5))
insert into praticien (nom, prenom, rue, codePostal, ville, telephone, email, idType, idSpecialite)
values(nom, prenom, rue, codePostal, ville, telephone, email, idType, idSpecialite);

$$

-- modifier un praticien

drop procedure if exists modifierPraticien;
delimiter $$
create procedure modifierPraticien (id int, nom varchar(25), prenom varchar(30), rue varchar(50), codePostal char(5), ville varchar(30), telephone char(14), email varchar(75), idType varchar(3), idSpecialite varchar(5))
update praticien
set nom = nom, prenom = prenom, rue = rue, codePostal = codePostal, ville = ville, telephone = telephone, email = email, idType = idType, idSpecialite = idSpecialite
where id = id;
$$


-- supprimer une praticien

drop procedure if exists supprimerPraticien;
delimiter $$
create procedure supprimerPraticien
	
$$


-- retourne l'ensemble des échantillons d'un visiteur 
-- utilisée pour alimenter les données via la classe passerelle)

use gsb;
drop procedure if exists getLesEchantillons;
delimiter $$
create procedure getLesEchantillons(idVisiteur varchar(3))
	select idVisite, idMedicament, quantite
    from echantillon, visite
    where echantillon.idVisite = visite.id
    and visite.idVisiteur = idVisiteur;
$$

-- Ajoute un échantillon lors d'une visite
drop procedure if exists ajouterEchantillon;
delimiter $$
create procedure ajouterEchantillon
	
$$        




-- retourne le nom et le code postal des villes se situant dans le département du visiteur dont l'id est passé en paramètre

drop procedure if exists getLesVilles;
delimiter $$
create procedure getLesVilles()
	select nom, codePostal
	from ville 
	order by nom;
$$



SHOW PROCEDURE STATUS where db = 'gsb';
