-- -------------------------------------------
-- Programme : visite.sql 
-- Objet : insertion des visites
-- Serveur : MySQL 
-- Auteur : Guy Verghote 
-- Date : 10/03/2021
-- -------------------------------------------

set SQL_SAFE_UPDATES = 0;

use gsb;



-- on désactive les tests réalisés dans le triggers qui utilise cette variable  
set @triggerOff = 1;
 
-- suppression des visites : la suppression en cascade n'est pas appliquée entre echantillon et visite, il faut donc supprimer préalablement les échantillon pour pouvoir supprimer les visites
delete from echantillon;
delete from visite; 
 
 -- on rénitialise le compteur à 0
 ALTER TABLE visite AUTO_INCREMENT = 1;
 

-- Récupération du lundi précédent

set @lundi = current_date() - interval weekday(current_date) day - interval 7 day;
select @lundi;

-- création des visites visite 1 et 2 cloturées, 3 et 4 réalisées
-- Elle nécessite de désactiver le trigger avantAjoutVisite
-- il faut russer sur MySQL qui ne permet pas de désactiver un trigger



insert into visite (dateEtHeure, idMotif, idVisiteur, idPraticien) values 
  (@lundi + interval 15 hour, 1, 'a17', 1),
  (@lundi + interval 17 hour, 1, 'a17', 2),
  (@lundi + interval 1 day + interval 09 hour + interval 30 minute, 2, 'a17', 3),
  (@lundi + interval 1 day + interval 11 hour +  interval 30 minute, 1, 'a17', 4),
  (@lundi + interval 12 hour, 1, 'a18', 121),
  (@lundi + interval 17 hour, 1, 'a18', 122);
  
-- création de visites programmées cette semaine (la date deut être dépassé pour certaine donc onlaisse la désactivation au niveau du trigger
  insert into visite (dateEtHeure, idMotif, idVisiteur, idPraticien) values 
  (@lundi + interval 7 day + interval 14 hour, 3, 'a17', 5),
  (@lundi + interval 7 day + interval 17 hour, 4, 'a17', 6),
  (@lundi + interval 8 day  + interval 10 hour, 5, 'a17', 7),
  (@lundi + interval 9 day + interval 10 hour, 1, 'a17', 8),
  (@lundi + interval 10 day + interval 10 hour, 1, 'a17', 9);

 -- on réactive les test réalisés dans le trigger  
set @triggerOff =  null;  
  
-- création de visites programmées la semaine prochaine
  insert into visite (dateEtHeure, idMotif, idVisiteur, idPraticien) values 
  (@lundi + interval 14 day + interval 15 hour, 1, 'a17', 101),
  (@lundi + interval 14 day + interval 17 hour, 1, 'a17', 102),
  (@lundi + interval 15 day + interval 10 hour + interval 30 minute, 2, 'a17', 103),
  (@lundi + interval 15 day + interval 13 hour, 1, 'a17', 104),
  (@lundi + interval 16 day + interval 15 hour, 3, 'a17', 105),
  (@lundi + interval 16 day + interval 17 hour, 4, 'a17', 106),
  (@lundi + interval 17 day + interval 10 hour, 5, 'a17', 107),
  (@lundi + interval 17 day + interval 14 hour, 1, 'a17', 108),
  (@lundi + interval 18 day + interval 09 hour + interval 30 minute, 2, 'a17', 109),
  (@lundi + interval 18 day + interval 09 hour + interval 30 minute, 2, 'a18', 123);


-- enregistrement du bilan et des médiciaments présentés pour les visites 1 et 2

update visite 
   set bilan = "Présentation satisfaisante", premierMedicament = '3MYC7'
where id = 1;


update visite 
   set bilan = "Présentation difficile", premierMedicament = 'JOVAI8', secondMEdicament = 'AMOXIG12'
where id = 2; 


-- enregistrement des médiciaments présentés pour les visites 1 et 2

insert into echantillon(idVisite, idMedicament, quantite) values
	 (1,'AMOXIG12',2),
	 (1,'APATOUX22',5),
	 (2,'BACTIG10',6),
     (2,'AMOXIG12',3),
	 (2,'BACTIV13',3);
     
    
select * from visite;
select * from echantillon;
