-- -------------------------------------------
-- Programme : testDeclencheur.sql 
-- Objet : test des déclencheurs du rojet GSB Fiche visite
-- Serveur : MySQL Server 
-- Auteur : Guy Verghote 
-- Date : 10/03/2021
-- -------------------------------------------

use gsb;

select * from visite;

-- ------------------------------------------------------------------------
-- test de la mise à jour d'une visite
-- ------------------------------------------------------------------------

-- l'ajout d'une visite dans moins d'une heure : ce test ne peut être lancé qu'entre 7h et 18 heures
-- réponse: Error Code: 1644. #Une visite doit être programmée à l'avance, pas le jour même

insert into visite (dateEtHeure, idMotif, idVisiteur, idPraticien) values 
  (now() + interval 1 hour, 1, 'a17', 1);

-- l'ajout d'une visite dans plus de deux mois
-- réponse: Error Code: 1644. #Une visite ne peut être programmé plus de 2 mois à l'avance

insert into visite (dateEtHeure, idMotif, idVisiteur, idPraticien) values 
  (curdate() + interval 2 month + interval 1 day + interval 15 hour, 1, 'a17', 1); 

-- l'ajout d'une visite en renseignant les médicaments
-- réponse: Error Code: 1644. #Les médicaments présentés ne peuvent être renseignés lors de la création de La visite

insert into visite (dateEtHeure, idMotif, idVisiteur, idPraticien, premierMedicament, secondMEdicament) values 
  (curdate() + interval 1 day + interval 15 hour, 1, 'a17', 1, 'ADIMOL9', 'DEPRIL9'); 

-- l'ajout d'une visite en renseignant les médicaments
-- réponse: Error Code: 1644. #Les médicaments présentées ne peuvent être renseignés lors de la création de La visite
insert into visite (dateEtHeure, idMotif, idVisiteur, idPraticien, premierMedicament) values 
  (curdate() + interval 1 day+ interval 15 hour, 1, 'a17', 1, 'ADIMOL9'); 

-- l'ajout d'une visite en renseignant les médicaments
-- réponse: Error Code: 1644. #Les médicaments présentées ne peuvent être renseignés lors de la création de La visite
insert into visite (dateEtHeure, idMotif, idVisiteur, idPraticien, secondMedicament) values 
  (curdate() + interval 1 day+ interval 15 hour, 1, 'a17', 1, 'ADIMOL9'); 

  -- l'ajout d'une visite en renseignant le bilan
-- réponse: Error Code: 1644. #Le bilan ne peut être renseigné lors de la programmation d'une visite

insert into visite (dateEtHeure, idMotif, idVisiteur, idPraticien, bilan) values 
  (curdate() + interval 1 day+ interval 15 hour, 1, 'a17', 1, 'Le praticien est convaincu' ); 


-- ajout d'une visite un dimanche 
-- pour tomber sur un dimanche à partir de la date du jour on ajoute 13 (7 + 6) jours  et on retire le numéro du jour (0 : lundi)
-- réponse : Error Code: 1644. #Une visite ne peut pas se dérouler un dimanche

insert into visite (dateEtHeure, idMotif, idVisiteur, idPraticien) values 
  (curdate() + interval 13 day - interval WeekDay(curdate()) day + interval 9 hour, 1 , 'a17', 1);
  
-- ajout d'une visite après 19 heures
-- réponse : Error Code: 1644. #Une visite doit se situer entre 8 et 19 heures

insert into visite (dateEtHeure, idMotif, idVisiteur, idPraticien) values 
  (curdate() + interval 1 day + interval 19 hour + interval 15 minute, 1 , 'a17', 1);

-- ajout d'une visite avant 8 heures
-- reponse : Error Code: 1644. #Une visite doit se situer entre 8 et 19 heures

 insert into visite (dateEtHeure, idMotif, idVisiteur, idPraticien) values 
  (curdate() + interval 1 day + interval 7 hour + interval 45 minute, 1 , 'a17', 1); 
  
 
-- ajout d'un visite avec un écart de moins de deux heures
-- réponse : acceptée

insert into visite (dateEtHeure, idMotif, idVisiteur, idPraticien) values 
  (curdate() + interval 1 day + interval 15 hour, 1, 'a17', 1); 

-- réponse : Error Code: 1644. #Il faut au moins deux heures d'écart entre deux visites
insert into visite (dateEtHeure, idMotif, idVisiteur, idPraticien) values 
  (curdate() + interval 1 day + interval 13 hour + interval 1 minute, 1, 'a17', 2); 

-- reponse : Error Code: 1644. #Il faut au moins deux heures d'écart entre deux visites
insert into visite (dateEtHeure, idMotif, idVisiteur, idPraticien) values 
  (curdate() + interval 1 day + interval 16 hour + interval 59 minute, 1, 'a17', 3); 

-- accepté
insert into visite (dateEtHeure, idMotif, idVisiteur, idPraticien) values 
  (curdate() + interval 1 day + interval 17 hour + interval 15 minute, 1, 'a17', 2); 

-- ajout d'un visite chez le même praticien
-- réponse : Error Code: 1644. #Une visite sans bilan enregistré est déjà programmée avec ce praticien
insert into visite (dateEtHeure, idMotif, idVisiteur, idPraticien) values 
  (curdate() + interval 1 day + interval 8 hour, 1, 'a17', 3); 

-- ------------------------------------------------------------------------
-- test de la mise à jour d'une visite
-- ------------------------------------------------------------------------

-- effacer le bilan des visites
-- réponse : refusé Error Code: 1644. Le bilan ne peut être effacé

update visite set bilan = null;

-- effacer le bilan et les médicaments sur toutes les visites
-- reponse :  pas possible si des échantillons ont été distribués  : Error Code: 1644. Le bilan et le premier médicament doivent être renseignés si des échantillons ont été distribué 

update visite set bilan = null, premierMedicament = null, secondMedicament = null;


-- test sur une visite programmée

-- enregistrer le bilan sur une visite programmée 
-- reponse : Error Code: 1644. Une visite qui n'est pas encore réalisée ne peut être complétée 

update visite 
	set bilan = 'test' 
where id = 5;

-- enregistrer le premier médicament sur une visite programmée 
-- reponse : Error Code: 1644. Une visite qui n'est pas encore réalisée ne peut être complétée 

update visite 
	set premierMEdicament = 'AMOXIG12' 
where id = 5;

-- enregistrer le premier médicament sur une visite programmée 
-- reponse : Error Code: 1644. Une visite qui n'est pas encore réalisée ne peut être complétée 

update visite 
	set secondMedicament = 'AMOXIG12' 
where id = 5;

-- ajouter des échantillons
-- réponse : Error Code: 1644. Une visite qui n'est pas encore réalisée ne peut contenir d'échantillon


insert into echantillon(idVisite, idMedicament, quantite) values
	 (5,'AMOXIG12',2),
	 (5,'APATOUX22',5);


-- test sur une visite cloturée

-- enregistrer le bilan sur une visite cloturée
-- reponse : Error Code: 1644. Aucune modification n'est possible sur une visite cloturée 


update visite 
	set bilan = 'test' 
where id = 2;

-- enregistrer le premier médicament sur une visite clôturée 
-- reponse : Error Code: 1644. Aucune modification n'est possible sur une visite cloturée 


update visite 
	set premierMEdicament = 'AMOXIG12' 
where id = 2;

-- enregistrer le second médicament sur une visite clôturée 
-- reponse : Error Code: 1644. Aucune modification n'est possible sur une visite cloturée 

update visite 
	set secondMedicament = 'AMOXIG12' 
where id = 2;

-- ajouter des échantillons
-- réponse : Error Code: 1644. La visite est déjà clôturée

insert into echantillon(idVisite, idMedicament, quantite) values
	 (2,'AMOXIG12',2),
	 (2,'APATOUX22',5);

-- supprimer les échantillons
-- réponse : Error Code: 1644. La suppression d'echantillon n'est pas autorisé

delete from echantillon where idVisite = 2;

-- test sur sur visite réalisée (3 et 4)

-- enregistrer le bilan sur une visite réalisée
-- reponse : Error Code: 1644. La visite ne peut être cloturée car le premier médicament présentée n'est pas renseigné 

update visite 
	set bilan = 'test' 
where id = 3;

-- enregistrer le premier médicament sur une visite réalisée
-- reponse : Error Code: 1644. La visite ne peut être cloturée car le bilan n'est pas renseigné 

update visite 
	set premierMedicament = 'AMOXIG12' 
where id = 3;

-- enregistrer le second médicament sur une visite réalisée
-- reponse : Error Code: 1644. La visite ne peut être cloturée car le bilan n'est pas renseigné 


update visite 
	set secondMedicament = 'AMOXIG12' 
where id = 3;


-- enregistrer le bilan et le premier médicament
-- réponse : Acceptée

update visite 
    set bilan = 'La confiance est de nouveau établi',
	premierMEdicament = 'AMOXIG12' 
where id = 3;


-- ajouter des échantillons
-- réponse : Acceptée

insert into echantillon(idVisite, idMedicament, quantite) values
	 (3,'AMOXIG12',2),
	 (3,'APATOUX22',5);

-- supprimer les échantillons
-- réponse : Error Code: 1644. La suppression d'echantillon n'est pas autorisé

delete from echantillon where idVisite = 3;


-- Suppression d'une visite

-- réponse" : Error Code: 1644. Une visite cloturée ne peut être supprimée 
delete from visite where id = 1;







  

