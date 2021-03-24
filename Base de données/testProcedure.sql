-- -------------------------------------------
-- Programme : testProcedure.sql 
-- Objet : test des procédures stockées du projet GSB Fiche visite
-- Serveur : MySQL  
-- Auteur : Guy Verghote 
-- Date : 10/03/2021
-- -------------------------------------------

use gsb;

-- liste des visiteurs
call getLesVisiteurs();

-- liste des visites d'un visiteur
call getLesVisites("a17");

-- liste des praticiens sur le département du visiteur
call getLesPraticiens("a17");

-- liste des villes possible pour les praticiens gérés par un visiteur (mêm département)
call getLesVilles("a17");


-- vérifier la connexion
set @mdp = "1991-8-26";
set @nom = "andre";
call verifierConnexion(@nom, @mdp); 


-- ajout d'une rendez-vous  réfusé
set @idVisite = null;
call ajouterRendezVous('a17', 110, 1, curdate() + interval 7 day + interval 8 hour , @idVisite);
select @idVisite;


-- ajout d'une rendez-vous hors période : réfusé
set @idVisite = null;
call ajouterRendezVous('a17', 110, 1, now() , @idVisite);
select @idVisite;



select * from visite;



