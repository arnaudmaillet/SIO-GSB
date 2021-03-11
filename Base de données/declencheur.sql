-- -------------------------------------------
-- Programme : declencheur.sql 
-- Objet : déclencheur du projet GSB 
-- Serveur : MySQL 
-- Auteur : 
-- date : 
-- -------------------------------------------

use gsb;

drop trigger if exists avantAjoutVisiteur;
drop trigger if exists avantAjoutVisite;
drop trigger if exists avantAjoutEchantillon;
drop trigger if exists avantSuppressionEchantillon;
drop trigger if exists avantMajVisite;
drop trigger if exists avantSuppressionVisite;
drop trigger if exists avantSuppressionPraticien;
drop trigger if exists avantAjoutPraticien;
drop trigger if exists avantMajPraticien;


-- ------------------------------------------------------------------------------------------------
-- concernant l'ajout d'un visiteur
-- ------------------------------------------------------------------------------------------------


-- il ne peut y avoir qu'un visiteur en activité (dateDepart is null) par département
delimiter $$




$$


-- ------------------------------------------------------------------------------------------------
-- concernant l'ajout d'une visite
-- ------------------------------------------------------------------------------------------------

-- une visite peut se trouver dans trois états : 
--    programmée (seule la date , le praticien et le visiteur sont renseignés et la date n'est pas dépasée) 
--    réalisée  : la date est maintenant dépassée elle peut être cloturée en renseignant le bilan, les médicaments et les échantillons
--    cloturée  : plus rien n'est modifiable

-- lors de la programmation d'une visite (création) d'une visite il faut vérifier les contraintes suivantes :
-- un visiteur ne peut visiter que les praticiens qui résident dans le même département
-- le bilan et les médicaments qui seront présentés ne peuvent pas être renseignés lors de la création de la visite
-- il ne peut y avoir qu'une visite programmée par praticien (hors visite clôturée : avec bilan enregistré)
-- une visite doit être programmée au moins une heure à l'avance 
-- une visite ne peut être programmée plus de deux mois à l'avance
-- une visite ne peut se faire le dimanche
-- la plage horaire de prise de rendez-vous est fixée entre 8 heures et 19 heures compris
-- il doit y avoir au moins deux heures d'écart entre deux visites

 
delimiter $$







$$


-- ------------------------------------------------------------------------------------------------
-- concernant la modification d'une visite
-- ------------------------------------------------------------------------------------------------

-- première règle
--   trois champs ne sont pas modifiables : id, idPraticien et idVisiteur

-- seconde règle
--    Si la visite est close (bilan déjà renseigné) plus aucun champ ne doit être modifiable  

-- troisième règle : si on arrive ici on sait que la visite n'est pas close dont le bilan non renseigné
--                  Pourquoi ? si c'était le cas la règle deux ne serait pas respectée
-- si la date est modifiée elle doit respecter les 4 règles vues en création :
--    entre 8 et 19 heures hors dimanche, 
--    au plus tard dans les deux mois 
--    séparée d'au moins deux heures de la suivante ou de la précédente
--    au plus tôt dans une heure 

-- 4ème règle

-- si la visite n'est pas encore réalisée  (DateEtHeure > Now) 
--     les champs bilan, premierMedicament et SecondMedicament ne sont pas modifiables (ils doivent rester non renseignés)

-- 
-- sinon (la visite peut être cloturée) 
--     si le bilan n'est pas renseigné les champs premierMedicament et secondMedicament ne doivent pas être renseignés
-- 	   sinon 
--        le premier médicament doit être renseigné, 
--        sa valeur doit être différente du second médicament


delimiter $$

$$


-- ------------------------------------------------------------------------------------------------
-- concernant la suppression d'une visite
-- ------------------------------------------------------------------------------------------------


-- la suppression d'une visite (d'un rendez-vous)  n'est possible que si elle n'est pas cloturée (bilan non renseigné)
delimiter $$



$$

-- ------------------------------------------------------------------------------------------------
-- concernant l'ajout des échantillons
-- ------------------------------------------------------------------------------------------------

-- L'ajout d'échantillon n'est possible que pour une visite dont le bilan est renseigné
-- dans ce cas le nombre de médicaments distribués ne doit pas dépasser 10
-- on récupère les champs bilan de la visite en les stockant dans des varaibles
-- si le bilan est null : erreur
-- si déja 10 échantillons : erreur


delimiter $$

$$

-- ------------------------------------------------------------------------------------------------
-- concernant la suppression des échantillons
-- ------------------------------------------------------------------------------------------------


-- La suppression d'échantillon n'est pas autorisée sauf si on est administrateur
delimiter $$


$$


-- ------------------------------------------------------------------------------------------------
-- concernant les praticiens
-- ------------------------------------------------------------------------------------------------


-- Un praticien ne peut être supprimé si des visites le concernent

delimiter $$



$$




