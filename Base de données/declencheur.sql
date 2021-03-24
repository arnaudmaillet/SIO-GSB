-- -------------------------------------------
-- Programme : declencheur.sql 
-- Objet : déclencheur du projet GSB 
-- Serveur : MySQL Server 
-- Auteur : Guy Verghote 
-- date : 09/03/2021
-- -------------------------------------------

use gsb;

drop trigger if exists avantAjoutVisiteur;
drop trigger if exists avantAjoutVisite;
drop trigger if exists avantAjoutEchantillon;
drop trigger if exists avantSuppressionEchantillon;
drop trigger if exists avantMajVisite;
drop trigger if exists avantSuppressionVisite;
drop trigger if exists avantSuppressionPraticien;


-- ------------------------------------------------------------------------------------------------
-- concernant l'ajout d'un visiteur
-- ------------------------------------------------------------------------------------------------

-- il ne peut y avoir qu'un visiteur en activité (dateDepart is null) par département

delimiter $$
create trigger avantAjoutVisiteur before insert on Visiteur 
for each row
	if exists(select 1 from visiteur where substring(codePostal, 1, 2) = substring(new.codePostal, 1, 2) and dateDepart is null) then
		SIGNAL sqlstate '45000' set message_text = 'Un visiteur en activité gère déjà ce département';
	end if;
$$


-- ------------------------------------------------------------------------------------------------
-- concernant l'ajout d'une visite
-- ------------------------------------------------------------------------------------------------


-- une visite peut se trouver dans trois états : 
--    programmée (seule la date , le praticien et le visiteur sont renseignés et la date n'est pas dépasée) 
--    réalisée  : la date est maintenant dépassée elle peut être cloturée en renseignant le bilan, les médicaments et les échantillons
--    cloturée  : plus rien n'est modifiable

-- lors de la programmation d'une viste (création) d'une visite il faut vérifier les contraintes suivantes :
-- un visiteur ne peut visiter que les praticiens qui résident dans le même département
-- le bilan et les médicaments qui seront présentés ne peuvent pas être renseignés lors de la création de la visite
-- il ne peut y avoir qu'une visite programmée par praticien (hors visite clôturée : avec bilan enregistré)
-- une visite doit être programmée au moins une heure à l'avance 
-- une visite ne peut être programmée plus de deux mois à l'avance
-- une visite ne peut se faire le dimanche
-- la plage horaire de prise de rendez-vous est fixée entre 8 heures et 19 heures compris
-- il doit y avoir au moins deux heures d'écart entre deux visites

 
delimiter $$
create trigger avantAjoutVisite before insert on Visite 
for each row
begin
   -- afin de permettre de ne pas faire les contrôles
   	if @triggerOff is null then
		# même département
		if (select substring(codePostal, 1, 2) from visiteur where id = new.idVisiteur) 
			!= (select substring(codePostal, 1, 2) from praticien where id = new.idPraticien) then
				SIGNAL sqlstate '45000' set message_text = 'Ce visiteur ne peut visiter ce praticien car il ne se trouve pas dans son département';
		end if;
		# dateEtHeure comprise entre aujourd'hui + 1 heure et dans 2 mois
		if new.dateEtHeure < now() + interval 1 hour  then
			SIGNAL sqlstate '45000' set message_text = 'Il n''est pas possible de programmer un rendez-vous dans moins d''une heure';
		end if;
		if new.dateEtHeure > curdate() + interval 2 month + interval 19 hour then
			SIGNAL sqlstate '45000' set message_text = 'Une visite ne peut être programmée plus de 2 mois à l''avance';
		end if;
		# pas le dimanche
		if WeekDay(new.dateEtHeure) = 6 then
			SIGNAL sqlstate '45000' set message_text = 'Une visite ne peut pas se dérouler un dimanche';
		end if;
		# entre 8 et 19 heures	
		if time(new.dateEtHeure) not between time('08:00:00') and time('19:00:00') then
			SIGNAL sqlstate '45000' set message_text = 'Une visite doit se situer entre 8 et 19 heures';
		end if;
		# pas de médicaments présentés ni de bilan à la création
		if new.premierMedicament is not null or  new.secondMedicament is not null or new.bilan is not null then
        	SIGNAL sqlstate '45000' set message_text = 'le bilan et les médicaments présentés ne peuvent être renseignés lors de la programmation d''une visite';
		end if;
		# au moins deux heures entre chaque visite
		if exists  (select 1 from visite where idVisiteur = new.idVisiteur 
					and dateEtHeure between new.dateEtHeure - interval 2 hour + interval 1 minute 
                                    and new.dateEtHeure + interval 2 hour - interval 1 minute)  then
			SIGNAL sqlstate '45000' set message_text = 'Il faut au moins deux heures d''écart entre deux visites';
		end if;    
		# une seule visite programmée par praticien
		if exists  (select 1 from visite where idVisiteur = new.idVisiteur
					and idPraticien = new.idPraticien 
					and  bilan is null) then
			SIGNAL sqlstate '45000' set message_text = 'Une visite non clôturée existe déjà pour ce praticien';
		end if;    
    end if;
end
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
create trigger avantMajVisite before update on Visite 
for each row
begin
	-- Les champs non modifiables
    if new.id != old.id then
		SIGNAL sqlstate '45000' set message_text = 'L''identifiant d''une visite n''est pas modifiable ';
	end if;
    if new.idPraticien != old.idPraticien then
		SIGNAL sqlstate '45000' set message_text = 'Le praticien visité n''est pas modifiable ';
	end if;
	if new.idVisiteur != old.idVisiteur then
		SIGNAL sqlstate '45000' set message_text = 'Le visiteur n''est pas modifiable ';
	end if;
    -- Si la visite est close (bilan déjà renseigné) plus aucun champ ne doit être modifiable 
    if old.bilan is not null then
  		SIGNAL sqlstate '45000' set message_text = 'Aucune modification n''est possible sur une visite cloturée ';
	end if;  
    -- si la date est modifiée elle doit respecter les 4 règles : entre 8 et 19 heures hors dimanche, dans les deux mois et séparée d'au moins deux heures de la suivante ou de la précédente

    if new.dateEtHeure != old.dateEtHeure then
           # dateEtHeure comprise entre aujourd'hui + 1 heure et dans 2 mois
		   if new.dateEtHeure < now() + interval 1 hour  then
				SIGNAL sqlstate '45000' set message_text = 'Il n''espt pas possible de reprogrammer un rendez-vous dans moins d''une heure';
			end if;
           if new.dateEtHeure > now() + interval 2 month then
				SIGNAL sqlstate '45000' set message_text = 'Une visite ne peut être remise à plus de deux mois';
			end if;
			# pas le dimanche
			if WeekDay(new.dateEtHeure) = 6 then
				SIGNAL sqlstate '45000' set message_text = 'La nouvelle date proposée tombe un dimanche';
			end if;
			# entre 8 et 19 heures
			if hour(new.dateEtHeure) not between 8 and 19  or (hour(new.dateEtHeure) = 19 and minute(new.dateEtHeure) > 0) then
				SIGNAL sqlstate '45000' set message_text = 'Une visite doit se situer entre 8 et 19 heures';
			end if; 
             # au moins deux heures entre chaque visite
			if exists  (select 1 from visite where idVisiteur = new.idVisiteur and dateEtHeure between new.dateEtHeure - interval 2 hour + interval 1 minute and new.dateEtHeure + interval 2 hour - interval 1 minute)  then
				SIGNAL sqlstate '45000' set message_text = 'Il faut au moins deux heures d''écart entre deux visites';
			end if;  
    end if;
    
    
    -- si la visite n'est pas encore réalisée  (DateEtHeure > Now) 
    if new.dateEtheure > now() then
         -- les champs bilan, premierMedicament et SecondMedicament ne sont pas modifiables (ils doivent rester non renseignés)
		 if new.bilan is not null or new.premierMedicament is not null or new.secondMedicament is not null then
			SIGNAL sqlstate '45000' set message_text = 'Une visite qui n''est pas encore réalisée ne peut être complétée ';
		end if;
	else
		-- la visite peut être clôturée (date échue)
		 if new.bilan is null then
            -- premierMedicament et secondMEdicament ne doivent pas être renseignés 
			if new.premierMedicament is not null or new.secondMedicament is not null then
				SIGNAL sqlstate '45000' set message_text = 'La visite ne peut être cloturée car le bilan n''est pas renseigné ';
			end if;
            -- dateEtHeure est modifiable en respectant l'écrart des deux
         else
			if new.premierMedicament is null then
				SIGNAL sqlstate '45000' set message_text = 'La visite ne peut être cloturée car le premier médicament présentée n''est pas renseigné ';
			end if;
 		   -- bilan et premier médicament sont renseignés la clotûre peut être réalisée sauf si le second médicament est identique au premier 
           if new.premierMedicament = new.secondMedicament then
				SIGNAL sqlstate '45000' set message_text = 'Le second médicament présenté ne peut être identique au premier ';
			end if;
        end if;
    end if;
end
$$

-- ------------------------------------------------------------------------------------------------
-- concernant la suppression d'une visite
-- ------------------------------------------------------------------------------------------------


-- la suppression d'une visite (d'un rendez-vous)  n'est possible que si elle n'est pas cloturée (bilan non renseigné)
delimiter $$
create trigger avantSuppressionVisite before delete on Visite 
for each row
	if @triggerOff is null then
		if old.bilan is not null then
			SIGNAL sqlstate '45000' set message_text = 'Une visite cloturée ne peut être supprimée ';
		end if;
    end if;
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
create trigger avantAjoutEchantillon before insert on Echantillon 
for each row
begin
    set @bilan = null;
	select bilan into @bilan from visite where id = new.idVisite;
     if @bilan is null then
		SIGNAL sqlstate '45000' set message_text = 'La bilan de la visite doit être renseigné pour pouvoir ajouter des échantillons';
	end if; 
	if (select count(*) from echantillon where idVisite = new.idVisite) = 10 then 
		SIGNAL sqlstate '45000' set message_text = 'Il n''est pas possible de distribuer plus de 10 médicaments';
	end if;
end
$$

-- ------------------------------------------------------------------------------------------------
-- concernant la suppression des échantillons
-- ------------------------------------------------------------------------------------------------


-- La suppression d'échantillon n'est pas autorisée
create trigger avantSuppressionEchantillon before delete on Echantillon
for each row
	if @triggerOff is null then
		SIGNAL sqlstate '45000' set message_text = 'La suppression d''echantillon n''est pas autorisé';
	end if;
$$


-- ------------------------------------------------------------------------------------------------
-- concernant les praticiens
-- ------------------------------------------------------------------------------------------------

-- les contraintes d'intégrité sont vérifiées par déclencheur afin de pour voir retourner un message en français de l'erreur


-- Un praticien ne peut être supprimé si des visites le concernent

create trigger avantSuppressionPraticien before delete on Praticien 
for each row
	if @triggerOff is null then
		if exists (select 1 from visite where idPraticien = old.id) then 
			SIGNAL sqlstate '45000' set message_text = 'Ce praticien ne peut être supprimé';
		end if;
    end if;
$$




