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
create procedure modifierRendezVous (idVisite varchar(3), dateEtHeure datetime, out idVisite int)
begin
	update visite
	set visite.dateEtHeure = dateEtHeure
    set idVisite = (select @@identity);
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
create procedure ajouterPraticien

$$

-- modifier un praticien

drop procedure if exists modifierPraticien;
delimiter $$
create procedure modifierPraticien
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
create procedure getLesVilles 

$$



SHOW PROCEDURE STATUS where db = 'gsb';
