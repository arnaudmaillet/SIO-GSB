-- -------------------------------------------
-- Programme : insert.sql 
-- Objet : insertion des données initiales dans les tables du projet GSB Fiche visite
-- Serveur : MySQL 
-- Auteur : Guy Verghote 
-- Date : 07/03/2021
-- -------------------------------------------

use gsb;

-- Les triggers doivent être supprimées pour pouvoir supprimer et  recréer les anciennes visites
-- ne pas oublier de relancer le script declencheurs après 

drop trigger if exists avantAjoutVisiteur;
drop trigger if exists avantAjoutVisite;
drop trigger if exists avantSuppressionVisite;
drop trigger if exists avantAjoutEchantillon;
drop trigger if exists avantSuppressionEchantillon;
drop trigger if exists avantMajVisite;
drop trigger if exists avantSuppressionPraticien;



use gsb;

delete from echantillon;
delete from visite;
delete from motif;
delete from medicament;
delete from famille;
delete from praticien;
delete from typepraticien;
delete from specialite;
delete from visiteur;

insert into famille(id,libelle) values 
	('AA','Antalgiques en association'),
	 ('AAA','Antalgiques antipyrétiques en association'),
	 ('AAC','Antidépresseur d''action centrale'),
	 ('AAH','Antivertigineux antihistaminique H1'),
	 ('ABA','Antibiotique antituberculeux'),
	 ('ABC','Antibiotique antiacnéique local'),
	 ('ABP','Antibiotique de la famille des béta-lactamines (pénicilline A)'),
	 ('AFC','Antibiotique de la famille des cyclines'),
	 ('AFM','Antibiotique de la famille des macrolides'),
	 ('AH','Antihistaminique H1 local'),
	 ('AIM','Antidépresseur imipraminique (tricyclique)'),
	 ('AIN','Antidépresseur inhibiteur sélectif de la recapture de la sérotonine'),
	 ('ALO','Antibiotique local (ORL)'),
	 ('ANS','Antidépresseur IMAO non sélectif'),
	 ('AO','Antibiotique ophtalmique'),
	 ('AP','Antipsychotique normothymique'),
	 ('AUM','Antibiotique urinaire minute'),
	 ('CRT','Corticoïde, antibiotique et antifongique à  usage local'),
	 ('HYP','Hypnotique antihistaminique'),
	 ('PSA','Psychostimulant, antiasthénique');

insert into medicament(id,nom,composition,effets,contreIndication,idFamille) values
	 ('3MYC7','TRIMYCINE','Triamcinolone (acétonide) + Néomycine + Nystatine','Ce médicament est un corticoïde à  activité forte ou très forte associé à  un antibiotique et un antifongique, utilisé en application locale dans certaines atteintes cutanées surinfectées.','Ce médicament est contre-indiqué en cas d''allergie à  l''un des constituants, d''infections de la peau ou de parasitisme non traités, d''acné. Ne pas appliquer sur une plaie, ni sous un pansement occlusif.','CRT'),
	 ('ADIMOL9','ADIMOL','Amoxicilline + Acide clavulanique','Ce médicament, plus puissant que les pénicillines simples, est utilisé pour traiter des infections bactériennes spécifiques.','Ce médicament est contre-indiqué en cas d''allergie aux pénicillines ou aux céphalosporines.','ABP'),
	 ('AMOPIL7','AMOPIL','Amoxicilline','Ce médicament, plus puissant que les pénicillines simples, est utilisé pour traiter des infections bactériennes spécifiques.','Ce médicament est contre-indiqué en cas d''allergie aux pénicillines. Il doit être administré avec prudence en cas d''allergie aux céphalosporines.','ABP'),
	 ('AMOX45','AMOXAR','Amoxicilline','Ce médicament, plus puissant que les pénicillines simples, est utilisé pour traiter des infections bactériennes spécifiques.','La prise de ce médicament peut rendre positifs les tests de dépistage du dopage.','ABP'),
	 ('AMOXIG12','AMOXI Gé','Amoxicilline','Ce médicament, plus puissant que les pénicillines simples, est utilisé pour traiter des infections bactériennes spécifiques.','Ce médicament est contre-indiqué en cas d''allergie aux pénicillines. Il doit être administré avec prudence en cas d''allergie aux céphalosporines.','ABP'),
	 ('APATOUX22','APATOUX Vitamine C','Tyrothricine + Tétracaïne + Acide ascorbique (Vitamine C)','Ce médicament est utilisé pour traiter les affections de la bouche et de la gorge.','Ce médicament est contre-indiqué en cas d''allergie à  l''un des constituants, en cas de phénylcétonurie et chez l''enfant de moins de 6 ans.','ALO'),
	 ('BACTIG10','BACTIGEL','Erythromycine','Ce médicament est utilisé en application locale pour traiter l''acné et les infections cutanées bactériennes associées.','Ce médicament est contre-indiqué en cas d''allergie aux antibiotiques de la famille des macrolides ou des lincosanides.','ABC'),
	 ('BACTIV13','BACTIVIL','Erythromycine','Ce médicament est utilisé pour traiter des infections bactériennes spécifiques.','Ce médicament est contre-indiqué en cas d''allergie aux macrolides (dont le chef de file est l''érythromycine).','AFM'),
	 ('BITALV','BIVALIC','Dextropropoxyphène + Paracétamol','Ce médicament est utilisé pour traiter les douleurs d''intensité modérée ou intense.','Ce médicament est contre-indiqué en cas d''allergie aux médicaments de cette famille, d''insuffisance hépatique ou d''insuffisance rénale.','AAA'),
	 ('CARTION6','CARTION','Acide acétylsalicylique (aspirine) + Acide ascorbique (Vitamine C) + Paracétamol','Ce médicament est utilisé dans le traitement symptomatique de la douleur ou de la fièvre.','Ce médicament est contre-indiqué en cas de troubles de la coagulation (tendances aux hémorragies), d''ulcère gastroduodénal, maladies graves du foie.','AAA'),
	 ('CLAZER6','CLAZER','Clarithromycine','Ce médicament est utilisé pour traiter des infections bactériennes spécifiques. Il est également utilisé dans le traitement de l''ulcère gastro-duodénal, en association avec d''autres médicaments.','Ce médicament est contre-indiqué en cas d''allergie aux macrolides (dont le chef de file est l''érythromycine).','AFM'),
	 ('DEPRIL9','DEPRAMIL','Clomipramine','Ce médicament est utilisé pour traiter les épisodes dépressifs sévères, certaines douleurs rebelles, les troubles obsessionnels compulsifs et certaines énurésies chez l''enfant.','Ce médicament est contre-indiqué en cas de glaucome ou d''adénome de la prostate, d''infarctus récent, ou si vous avez reà§u un traitement par IMAO durant les 2 semaines précédentes ou en cas d''allergie aux antidépresseurs imipraminiques.','AIM'),
	 ('DIMIRTAM6','DIMIRTAM','Mirtazapine','Ce médicament est utilisé pour traiter les épisodes dépressifs sévères.','La prise de ce produit est contre-indiquée en cas de d''allergie à  l''un des constituants.','AAC'),
	 ('DOLRIL7','DOLORIL','Acide acétylsalicylique (aspirine) + Acide ascorbique (Vitamine C) + Paracétamol','Ce médicament est utilisé dans le traitement symptomatique de la douleur ou de la fièvre.','Ce médicament est contre-indiqué en cas d''allergie au paracétamol ou aux salicylates.','AAA'),
	 ('DORNOM8','NORMADOR','Doxylamine','Ce médicament est utilisé pour traiter l''insomnie chez l''adulte.','Ce médicament est contre-indiqué en cas de glaucome, de certains troubles urinaires (rétention urinaire) et chez l''enfant de moins de 15 ans.','HYP'),
	 ('EQUILARX6','EQUILAR','Méclozine','Ce médicament est utilisé pour traiter les vertiges et pour prévenir le mal des transports.','Ce médicament ne doit pas être utilisé en cas d''allergie au produit, en cas de glaucome ou de rétention urinaire.','AAH'),
	 ('EVILR7','EVEILLOR','Adrafinil','Ce médicament est utilisé pour traiter les troubles de la vigilance et certains symptomes neurologiques chez le sujet agé.','Ce médicament est contre-indiqué en cas d''allergie à  l''un des constituants.','PSA'),
	 ('INSXT5','INSECTIL','Diphénydramine','Ce médicament est utilisé en application locale sur les piqûres d''insecte et l''urticaire.','Ce médicament est contre-indiqué en cas d''allergie aux antihistaminiques.','AH'),
	 ('JOVAI8','JOVENIL','Josamycine','Ce médicament est utilisé pour traiter des infections bactériennes spécifiques.','Ce médicament est contre-indiqué en cas d''allergie aux macrolides (dont le chef de file est l''érythromycine).','AFM'),
	 ('LIDOXY23','LIDOXYTRACINE','Oxytétracycline +Lidocaïne','Ce médicament est utilisé en injection intramusculaire pour traiter certaines infections spécifiques.','Ce médicament est contre-indiqué en cas d''allergie à  l''un des constituants. Il ne doit pas être associé aux rétinoïdes.','AFC'),
	 ('LITHOR12','LITHORINE','Lithium','Ce médicament est indiqué dans la prévention des psychoses maniaco-dépressives ou pour traiter les états maniaques.','Ce médicament ne doit pas être utilisé si vous êtes allergique au lithium. Avant de prendre ce traitement, signalez à  votre médecin traitant si vous souffrez d''insuffisance rénale, ou si vous avez un régime sans sel.','AP'),
	 ('PARMOL16','PARMOCODEINE','Codéine + Paracétamol','Ce médicament est utilisé pour le traitement des douleurs lorsque des antalgiques simples ne sont pas assez efficaces.','Ce médicament est contre-indiqué en cas d''allergie à  l''un des constituants, chez l''enfant de moins de 15 Kg, en cas d''insuffisance hépatique ou respiratoire, d''asthme, de phénylcétonurie et chez la femme qui allaite.','AA'),
	 ('PHYSOI8','PHYSICOR','Sulbutiamine','Ce médicament est utilisé pour traiter les baisses d''activité physique ou psychique, souvent dans un contexte de dépression.','Ce médicament est contre-indiqué en cas d''allergie à  l''un des constituants.','PSA'),
	 ('PIRIZ8','PIRIZAN','Pyrazinamide','Ce médicament est utilisé, en association à  d''autres antibiotiques, pour traiter la tuberculose.','Ce médicament est contre-indiqué en cas d''allergie à  l''un des constituants, d''insuffisance rénale ou hépatique, d''hyperuricémie ou de porphyrie.','ABA'),
	 ('POMDI20','POMADINE','Bacitracine','Ce médicament est utilisé pour traiter les infections oculaires de la surface de l''oeil.','Ce médicament est contre-indiqué en cas d''allergie aux antibiotiques appliqués localement.','AO'),
	 ('TROXT21','TROXADET','Paroxétine','Ce médicament est utilisé pour traiter la dépression et les troubles obsessionnels compulsifs. Il peut également être utilisé en prévention des crises de panique avec ou sans agoraphobie.','Ce médicament est contre-indiqué en cas d''allergie au produit.','AIN'),
	 ('TXISOL22','TOUXISOL Vitamine C','Tyrothricine + Acide ascorbique (Vitamine C)','Ce médicament est utilisé pour traiter les affections de la bouche et de la gorge.','Ce médicament est contre-indiqué en cas d''allergie à  l''un des constituants et chez l''enfant de moins de 6 ans.','ALO'),
	 ('URIEG6','URIREGUL','Fosfomycine trométamol','Ce médicament est utilisé pour traiter les infections urinaires simples chez la femme de moins de 65 ans.','La prise de ce médicament est contre-indiquée en cas d''allergie à  l''un des constituants et d''insuffisance rénale.','AUM');


insert into typePraticien(id, libelle, lieu) values
	('MH','Médecin Hospitalier','Hopital ou clinique'),
	('MV','Médecine de Ville','Cabinet'),
	('PH','Pharmacien Hospitalier','Hopital ou clinique'),
	('PO','Pharmacien Officine','Pharmacie'),
	('PS','Personnel de santé','Centre paramédical');

insert into specialite(id,libelle) values
	('ACP','anatomie et cytologie pathologiques'),
	('AMV','angéiologie, médecine vasculaire'),
	('ARC','anesthésiologie et réanimation chirurgicale'),
	('BM','biologie médicale'),
	('CAC','cardiologie et affections cardio-vasculaires'),
	('CCT','chirurgie cardio-vasculaire et thoracique'),
	('CG','chirurgie générale'),
	('CMF','chirurgie maxillo-faciale'),
	('COM','cancérologie, oncologie médicale'),
	('COT','chirurgie orthopédique et traumatologie'),
	('CPR','chirurgie plastique reconstructrice et esthétique'),
	('CU','chirurgie urologique'),
	('CV','chirurgie vasculaire'),
	('DN','diabétologie-nutrition, nutrition'),
	('DV','dermatologie et vénéréologie'),
	('EM','endocrinologie et métabolismes'),
	('ETD','évaluation et traitement de la douleur'),
	('GEH','gastro-entérologie et hépatologie (appareil digestif)'),
	('GMO','gynécologie médicale, obstétrique'),
	('GO','gynécologie-obstétrique'),
	('HEM','maladies du sang (hématologie)'),
	('MBS','médecine et biologie du sport'),
	('MDT','médecine du travail'),
	('MMO','médecine manuelle - ostéopathie'),
	('MN','médecine nucléaire'),
	('MPR','médecine physique et de réadaptation'),
	('MTR','médecine tropicale, pathologie infectieuse et tropicale'),
	('NEP','néphrologie'),
	('NRC','neurochirurgie'),
	('NRL','neurologie'),
	('ODM','orthopédie dento maxillo-faciale'),
	('OPH','ophtalmologie'),
	('ORL','oto-rhino-laryngologie'),
	('PEA','psychiatrie de l''enfant et de l''adolescent'),
	('PME','pédiatrie maladies des enfants'),
	('PNM','pneumologie'),
	('PSC','psychiatrie'),
	('RAD','radiologie (radiodiagnostic et imagerie médicale)'),
	('RDT','radiothérapie (oncologie option radiothérapie)'),
	('RGM','reproduction et gynécologie médicale'),
	('RHU','rhumatologie'),
	('STO','stomatologie'),
	('SXL','sexologie'),
	('TXA','toxicomanie et alcoologie');

insert into praticien(id, nom, prenom, rue, codePostal, ville, idType, idSpecialite) values 
	 (1,'Notini','Alain','114 r Authie','80000','AMIENS','MH','CPR'),
	 (2,'Gosselin','Albert','13 r Devon','80100','ABBEVILLE','MV',NULL),
	 (3,'Delahaye','André','36 av 6 Juin','80420','FLIXECOURT','PS',NULL),
	 (4,'Leroux','André','47 av Robert Schuman','80600','DOULLENS','PH',NULL),
	 (5,'Desmoulins','Anne','31 r St Jean','80300','ALBERT','PO',NULL),
	 (6,'Mouel','Anne','27 r Auvergne','80000','AMIENS','MH',NULL),
	 (7,'Desgranges-Lentz','Antoine','1 r Albert de Mun','80200','PERONNE','MV','MBS'),
	 (8,'Marcouiller','Arnaud','31 r St Jean','80000','AMIENS','PS',NULL),
	 (9,'Dupuy','Benoit','9 r Demolombe','80100','ABBEVILLE','PH',NULL),
	 (10,'Lerat','Bernard','31 r St Jean','59000','LILLE','PO',NULL),
	 (11,'Marçais-Lefebvre','Bertrand','86Bis r Basse','67000','STRASBOURG','MH',NULL),
	 (12,'Boscher','Bruno','94 r Falaise','10000','TROYES','MV','MBS'),
	 (13,'Morel','Catherine','21 r Chateaubriand','75000','PARIS','PS',NULL),
	 (14,'Guivarch','Chantal','4 av Gén Laperrine','45000','ORLEANS','PH',NULL),
	 (15,'Bessin-Grosdoit','Christophe','92 r Falaise','06000','NICE','PO',NULL),
	 (16,'Rossa','Claire','14 av Thiès','06000','NICE','MH',NULL),
	 (17,'Cauchy','Denis','5 av Ste Thérèse','11000','NARBONNE','MV',NULL),
	 (18,'Gaffé','Dominique','9 av 1ère Armée Française','35000','RENNES','PS',NULL),
	 (19,'Guenon','Dominique','98 bd Mar Lyautey','44000','NANTES','PH',NULL),
	 (20,'Prévot','Dominique','29 r Lucien Nelle','87000','LIMOGES','PO',NULL),
	 (21,'Houchard','Eliane','9 r Demolombe','49100','ANGERS','MH',NULL),
	 (22,'Desmons','Elisabeth','51 r Bernières','29000','QUIMPER','MV',NULL),
	 (23,'Flament','Elisabeth','11 r Pasteur','35000','RENNES','PS',NULL),
	 (24,'Goussard','Emmanuel','9 r Demolombe','41000','BLOIS','PH',NULL),
	 (25,'Desprez','Eric','9 r Vaucelles','33000','BORDEAUX','PO',NULL),
	 (26,'Coste','Evelyne','29 r Lucien Nelle','19000','TULLE','MH',NULL),
	 (27,'Lefebvre','Frédéric','2 pl Wurzburg','55000','VERDUN','MV',NULL),
	 (28,'Lemée','Frédéric','29 av 6 Juin','56000','VANNES','PS',NULL),
	 (29,'Martin','Frédéric','Bât A 90 r Bayeux','70000','VESOUL','PH',NULL),
	 (30,'Marie','Frédérique','172 r Caponière','70000','VESOUL','PO',NULL),
	 (31,'Rosenstech','Geneviève','27 r Auvergne','75000','PARIS','MH',NULL),
	 (32,'Pontavice','Ghislaine','8 r Gaillon','86000','POITIERS','MV',NULL),
	 (33,'Leveneur-Mosquet','Guillaume','47 av Robert Schuman','64000','PAU','PS',NULL),
	 (34,'Blanchais','Guy','30 r Authie','08000','SEDAN','PH',NULL),
	 (35,'Leveneur','Hugues','7 pl St Gilles','62000','ARRAS','PO',NULL),
	 (36,'Mosquet','Isabelle','22 r Jules Verne','76000','ROUEN','MH',NULL),
	 (37,'Giraudon','Jean-Christophe','1 r Albert de Mun','38100','VIENNE','MV',NULL),
	 (38,'Marie','Jean-Claude','26 r Hérouville','69000','LYON','PS',NULL),
	 (39,'Maury','Jean-François','5 r Pierre Girard','71000','CHALON SUR SAONE','PH',NULL),
	 (40,'Dennel','Jean-Louis','7 pl St Gilles','28000','CHARTRES','PO',NULL),
	 (41,'Ain','Jean-Pierre','4 résid Olympia','02000','LAON','MH',NULL),
	 (42,'Chemery','Jean-Pierre','51 pl Ancienne Boucherie','14000','CAEN','MV',NULL),
	 (43,'Comoz','Jean-Pierre','35 r Auguste Lechesne','18000','BOURGES','PS',NULL),
	 (44,'Desfaudais','Jean-Pierre','7 pl St Gilles','29000','BREST','PH',NULL),
	 (45,'Phan','Jérôme','9 r Clos Caillet','79000','NIORT','PO',NULL),
	 (46,'Riou','Line','43 bd Gén Vanier','77000','MARNE LA VALLEE','MH',NULL),
	 (47,'Chubilleau','Louis','46 r Eglise','17000','SAINTES','MV',NULL),
	 (48,'Lebrun','Lucette','178 r Auge','54000','NANCY','PS',NULL),
	 (49,'Goessens','Marc','6 av 6 Juin','39000','DOLE','PH',NULL),
	 (50,'Laforge','Marc','5 résid Prairie','50000','SAINT LO','PO',NULL),
	 (51,'Millereau','Marc','36 av 6 Juin','72000','LA FERTE BERNARD','MH',NULL),
	 (52,'Dauverne','Marie-Christine','69 av Charlemagne','21000','DIJON','MV',NULL),
	 (53,'Vittorio','Myriam','3 pl Champlain','94000','BOISSY SAINT LEGER','PS',NULL),
	 (54,'Lapasset','Nhieu','31 av 6 Juin','52000','CHAUMONT','PH',NULL),
	 (55,'Plantet-Besnier','Nicole','10 av 1ère Armée Française','86000','CHATELLEREAULT','PO',NULL),
	 (56,'Chubilleau','Pascal','3 r Hastings','15000','AURRILLAC','MH',NULL),
	 (57,'Robert','Pascal','31 r St Jean','93000','BOBIGNY','MV',NULL),
	 (58,'Jean','Pascale','114 r Authie','49100','SAUMUR','PS',NULL),
	 (59,'Chanteloube','Patrice','14 av Thiès','13000','MARSEILLE','PH',NULL),
	 (60,'Lecuirot','Patrice','résid St Pères 55 r Pigacière','54000','NANCY','PO',NULL),
	 (61,'Gandon','Patrick','47 av Robert Schuman','37000','TOURS','MH',NULL),
	 (62,'Mirouf','Patrick','22 r Puits Picard','74000','ANNECY','MV',NULL),
	 (63,'Boireaux','Philippe','14 av Thiès','10000','CHALON EN CHAMPAGNE','PS',NULL),
	 (64,'Cendrier','Philippe','7 pl St Gilles','12000','RODEZ','PH',NULL),
	 (65,'Duhamel','Philippe','114 r Authie','34000','MONTPELLIER','PO',NULL),
	 (66,'Grigy','Philippe','15 r Mélingue','44000','CLISSON','MH',NULL),
	 (67,'Linard','Philippe','1 r Albert de Mun','81000','ALBI','MV',NULL),
	 (68,'Lozier','Philippe','8 r Gaillon','31000','TOULOUSE','PS',NULL),
	 (69,'Dechâtre','Pierre','63 av Thiès','23000','MONTLUCON','PH',NULL),
	 (70,'Goessens','Pierre','22 r Jean Romain','40000','MONT DE MARSAN','PO',NULL),
	 (71,'Leménager','Pierre','39 av 6 Juin','57000','METZ','MH',NULL),
	 (72,'Née','Pierre','39 av 6 Juin','82000','MONTAUBAN','MV',NULL),
	 (73,'Guyot','Pierre-Laurent','43 bd Gén Vanier','48000','MENDE','PS',NULL),
	 (74,'Chauchard','Roger','9 r Vaucelles','13000','MARSEILLE','PH',NULL),
	 (75,'Mabire','Roland','11 r Boutiques','67000','STRASBOURG','PO',NULL),
	 (76,'Leroy','Soazig','45 r Boutiques','61000','ALENCON','MH',NULL),
	 (77,'Guyot','Stéphane','26 r Hérouville','46000','FIGEAC','MV',NULL),
	 (78,'Delposen','Sylvain','39 av 6 Juin','27000','DREUX','PS',NULL),
	 (79,'Rault','Sylvie','15 bd Richemond','02000','SOISSON','PH',NULL),
	 (80,'Renouf','Sylvie','98 bd Mar Lyautey','88000','EPINAL','PO',NULL),
	 (81,'Alliet-Grach','Thierry','14 av Thiès','07000','PRIVAS','MH',NULL),
	 (82,'Bayard','Thierry','92 r Falaise','42000','SAINT ETIENNE','MV',NULL),
	 (83,'Gauchet','Thierry','7 r Desmoueux','38100','GRENOBLE','PS',NULL),
	 (84,'Bobichon','Tristan','219 r Caponière','09000','FOIX','PH',NULL),
	 (85,'Duchemin-Laniel','Véronique','130 r St Jean','33000','LIBOURNE','PO',NULL),
	 (86,'Laurent','Younès','34 r Demolombe','53000','MAYENNE','MH',NULL);


insert into praticien(id, nom, prenom, rue, codePostal, ville, telephone, idType) values 
	 (101,'Guyon', 'Pascal', '3 Place des provinces francaises', '80000', 'Amiens',  '03 22 43 11 50', 'PO'),
	 (102,'Pavaut', 'Lucien', '2 Avenue Jules Ferry', '80470', 'Dreuil-lès-Amiens', '03 22 54 11 08', 'PO'),
	 (103,'Fauquet', 'Stéphane', 'Place du Pays d''Auge', '80000', 'Amiens', '03 22 43 11 37', 'PO'),
	 (104,'Legris', 'Pierre', '410 Rue d''Abbeville', '80000', 'Amiens', '03 22 43 14 54', 'PO'),
	 (105,'Demoulin', 'Nenry', '16 Rue d''Abbeville', '80000', 'Amiens', '03 22 43 01 30', 'PO'),
	 (106,'Desmarest', 'Lucie', '6 rue Edouard Lucas', '80000', 'Amiens', '03 22 69 64 50', 'PO'),
	 (107,'Fachon', 'Elodie', '11/13 Rue Jean Catelas', '80000', 'Amiens', '03 22 71 64 15', 'PO'),
	 (108, 'Lafayenne', 'Antoine', '4 Place Gambetta', '80000', 'Amiens', '03 22 97 52 52', 'PO'),
	 (109,'Dumas', 'Alexandre', '45 Rue de Rouen', '80000', 'Amiens', '03 22 95 41 52', 'PO'),
	 (110,'Legrand', 'Pierre', 'Rue Botticelli', '80000', 'Amiens', '03 22 69 69 00', 'PO'),
	 (111,'Paroïelle', 'Lyse', '64 Chaussée du Bois', '80100', 'Abbeville', '03 22 20 69 69', 'PO'),
	 (112,'Ballesdent', 'Joël', '9 Rue Jean de Ponthieu', '80100', 'Abbeville', '03 22 24 00 83', 'PO'),
	 (113,'Lambert', 'Jean', '59 Chaussée Marcadé', '80100', 'Abbeville', '03 22 24 06 51', 'PO'),
	 (114,'Quenot', 'Alain', '68 Rue du Bourg', '80600', 'Doullens', '03 22 36 75 44', 'PO'),
	 (115,'Carpentier', 'Thierry', '15 Porte de Doullens', '80600', 'Beauquesne', '03 22 32 85 84', 'PO'),
	 (116,'Le Nancq', 'Valérie', '22Bis Rue Armand Devillers', '80630', 'Beauval', '03 22 32 91 49', 'PO'),
	 (117,'Le Borne', 'Paul', '7 Rue du Commandement Unique', '80600', 'Doullens', '03 22 77 02 79', 'PO');


insert into praticien(id, nom, prenom, rue, codePostal, ville, telephone, idType) values 
	 (121,'Guyon', 'Paul', '3 Place des provinces francaises', '2A100', 'Bastia',  '04 22 43 11 50', 'PO'),
	 (122,'Pavaut', 'Pierre', '2 Avenue Jules Ferry', '2A100', 'Bastia', '04 22 54 11 08', 'PO'),
	 (123,'Fauquet', 'Stpéphane', 'Place du Pays d''Auge', '2A100', 'Bastia', '04 22 43 11 37', 'PO');


-- génération des attributs non renseignés

-- génération automatique des numéro de téléphone

update praticien 
   set telephone = concat('06 ', 10 + id * 3 % 89, ' ' , 10 + id * 5  % 89 , ' ', 10 + id * 7  % 89, ' ',  10 + id * 11  % 89)
   where telephone is null;

-- génération automatique adresse mail : nom.prenom@laposte.net

update praticien 
   set email = concat(lower(nom), '.', lower(prenom), '@laposte.net');

insert into visiteur(id, nom, prenom, rue, codePostal, ville, dateEmbauche) values
	 ('a17','Andre','David','1 r Aimon de Chissée','80000','AMIENS','1991-08-26'),
	 ('a18','Ansart', 'Alexis', '4 r des buissons', '2A100', 'BASTIA', '1985-09-20'),
	 ('a55','Bedos','Christian','1 r Bénédictins','65000','TARBES','1987-07-17'),
	 ('a93','Tusseau','Louis','22 r Renou','86000','POITIERS','1999-01-02'),
	 ('b13','Bentot','Pascal','11 av 6 Juin','67000','STRASBOURG','1996-03-11'),
	 ('b16','Bioret','Luc','1 r Linne','35000','RENNES','1997-03-21'),
	 ('b19','Bunisset','Francis','10 r Nicolas Chorier','85000','LA ROCHE SUR YON','1999-01-31'),
	 ('b25','Bunisset','Denise','1 r Lionne','49100','ANGERS','1994-07-03'),
	 ('b28','Cacheux','Bernard','114 r Authie','34000','MONTPELLIER','2000-08-02'),
	 ('b34','Cadic','Eric','123 r Caponière','41000','BLOIS','1993-12-06'),
	 ('b4','Charoze','Catherine','100 pl Géants','33000','BORDEAUX','1997-09-25'),
	 ('b50','Clepkens','Christophe','12 r Fédérico Garcia Lorca','13000','MARSEILLE','1998-01-18'),
	 ('b59','Cottin','Vincenne','36 sq Capucins','05000','GAP','1995-10-21'),
	 ('c14','Daburon','François','13 r Champs Elysées','06000','NICE','1989-02-01'),
	 ('c3','Debeauvais','Philippe','13 r Charles Peguy','10000','TROYES','1992-05-05'),
	 ('c54','Debelle','Michel','181 r Caponière','88000','EPINAL','1991-04-09'),
	 ('d13','Debelle','Jeanne','134 r Stalingrad','44000','NANTES','1991-12-05'),
	 ('d51','Debroise','Michel','2 av 6 Juin','70000','VESOUL','1997-11-18'),
	 ('e22','Desmarquest','Nathalie','14 r Fédérico Garcia Lorca','54000','NANCY','1989-03-24'),
	 ('e24','Desnost','Pierre','16 r Barral de Montferrat','55000','VERDUN','1993-05-17'),
	 ('e39','Dudouit','Frédéric','18 quai Xavier Jouvin','75000','PARIS','1988-04-26'),
	 ('e49','Duncombe','Claude','19 av Alsace Lorraine','09000','FOIX','1996-02-19'),
	 ('e5','Enault-Pascreau','Céline','25B r Stalingrad','40000','MONT DE MARSAN','1990-11-27'),
	 ('e52','Eynde','Valérie','3 r Henri Moissan','76000','ROUEN','1991-10-31'),
	 ('f21','Finck','Jacques','rte Montreuil Bellay','74000','ANNECY','1993-06-08'),
	 ('f39','Frémont','Fernande','4 r Jean Giono','69000','LYON','1997-02-15'),
	 ('f4','Gest','Alain','30 r Authie','46000','FIGEAC','1994-05-03'),
	 ('g53','Gombert','Luc','32 r Emile Gueymard','56000','VANNES','1985-10-02'),
	 ('g7','Guindon','Caroline','40 r Mar Montgomery','87000','LIMOGES','1996-01-13'),
	 ('h13','Guindon','François','44 r Picotière','19000','TULLE','1993-05-08'),
	 ('h30','Igigabel','Guy','33 gal Arlequin','94000','CRETEIL','1998-04-26'),
	 ('h35','Jourdren','Pierre','34 av Jean Perrot','15000','AURRILLAC','1993-08-26'),
	 ('h40','Juttard','Pierre-Raoul','34 cours Jean Jaurès','08000','SEDAN','1992-11-01'),
	 ('j45','Labouré-Morel','Saout','38 cours Berriat','52000','CHAUMONT','1998-02-25'),
	 ('j50','Landré','Philippe','4 av Gén Laperrine','59000','LILLE','1992-12-16'),
	 ('j8','Langeard','Hugues','39 av Jean Perrot','93000','BAGNOLET','1998-06-18'),
	 ('k4','Lanne','Bernard','4 r Bayeux','30000','NIMES','1996-11-21'),
	 ('k53','Le','Noël','4 av Beauvert','68000','MULHOUSE','1983-03-23'),
	 ('l14','Le','Jean','39 r Raspail','53000','LAVAL','1995-02-02'),
	 ('l23','Leclercq','Servane','11 r Quinconce','18000','BOURGES','1995-06-05'),
	 ('l46','Lecornu','Jean-Bernard','4 bd Mar Foch','72000','LA FERTE BERNARD','1997-01-24'),
	 ('l56','Lecornu','Ludovic','4 r Abel Servien','25000','BESANCON','1996-02-27'),
	 ('m35','Lejard','Agnès','4 r Anthoard','82000','MONTAUBAN','1987-10-06'),
	 ('m45','Lesaulnier','Pascal','47 r Thiers','57000','METZ','1990-10-13'),
	 ('n42','Letessier','Stéphane','5 chem Capuche','27000','EVREUX','1996-03-06'),
	 ('n58','Loirat','Didier','Les Pêchers cité Bourg la Croix','45000','ORLEANS','1992-08-30'),
	 ('n59','Maffezzoli','Thibaud','5 r Chateaubriand','02000','LAON','1994-12-19'),
	 ('o26','Mancini','Anne','5 r D''Agier','48000','MENDE','1995-01-05'),
	 ('p32','Marcouiller','Gérard','7 pl St Gilles','91000','ISSY LES MOULINEAUX','1992-12-24'),
	 ('p40','Michel','Jean-Claude','5 r Gabriel Péri','61000','FLERS','1992-12-14'),
	 ('p41','Montecot','Françoise','6 r Paul Valéry','17000','SAINTES','1998-07-27'),
	 ('p42','Notini','Veronique','5 r Lieut Chabal','60000','BEAUVAIS','1994-12-12'),
	 ('p49','Onfroy','Den','5 r Sidonie Jacolin','37000','TOURS','1977-10-03'),
	 ('p6','Pascreau','Charles','57 bd Mar Foch','64000','PAU','1997-03-30'),
	 ('p7','Pernot','Claude-Noël','6 r Alexandre 1 de Yougoslavie','11000','NARBONNE','1990-03-01'),
	 ('p8','Perrier','Maître','6 r Aubert Dubayet','71000','CHALON SUR SAONE','1991-06-23'),
	 ('q17','Petit','Jean-Louis','7 r Ernest Renan','50000','SAINT LO','1997-09-06'),
	 ('r24','Piquery','Patrick','9 r Vaucelles','14000','CAEN','1984-07-29'),
	 ('r58','Quiquandon','Joël','7 r Ernest Renan','29000','QUIMPER','1990-06-30'),
	 ('s10','Retailleau','Josselin','88Bis r Saumuroise','39000','DOLE','1995-11-14'),
	 ('s21','Retailleau','Pascal','32 bd Ayrault','23000','MONTLUCON','1992-09-25'),
	 ('t43','Souron','Maryse','7B r Gay Lussac','21000','DIJON','1995-03-09'),
	 ('t47','Tiphagne','Patrick','7B r Gay Lussac','62000','ARRAS','1996-08-29'),
	 ('t55','Tréhet','Alain','7D chem Barral','12000','RODEZ','1994-11-29'),
	 ('t60','Tusseau','Josselin','63 r Bon Repos','28000','CHARTRES','1991-03-29');

insert into motif(id, libelle) values
 	(1,'Visite périodique'),
	(2,'Actualisation des produits'),
	(3,'Baisse activité'),
	(4,'Sollication praticien'),
	(5,'Autre');


-- Récupération du lundi précédent

set @lundi = current_date() - interval 7 day - interval weekday(current_date) day;
select @lundi;

-- création des visites visite 1 et2 cloturées, 3 et 4 réalisées, les autres programmées

insert into visite (id, dateEtHeure, idMotif, idVisiteur, idPraticien) values 
  (1, @lundi + interval 15 hour, 1, 'a17', 1),
  (2, @lundi + interval 17 hour, 1, 'a17', 2),
  (3, @lundi + interval 1 day + interval 09 hour + interval 30 minute, 2, 'a17', 3),
  (4, @lundi + interval 1 day + interval 11 hour +  interval 30 minute, 1, 'a17', 4),
  (5, @lundi + interval 7 day + interval 14 hour, 3, 'a17', 5),
  (6, @lundi + interval 7 day + interval 17 hour, 4, 'a17', 6),
  (7, @lundi + interval 8 day  + interval 10 hour, 5, 'a17', 7);

insert into visite (id, dateEtHeure, idMotif, idVisiteur, idPraticien) values 
  (8, @lundi + interval 9 day + interval 10 hour, 1, 'a17', 8),
  (9, @lundi + interval 9 day + interval 15 hour, 1, 'a17', 101),
  (10, @lundi + interval 9 day + interval 17 hour, 1, 'a17', 102),
  (11, @lundi + interval 10 day + interval 10 hour + interval 30 minute, 2, 'a17', 103),
  (12, @lundi + interval 10 day + interval 13 hour, 1, 'a17', 104),
  (13, @lundi + interval 10 day + interval 15 hour, 3, 'a17', 105),
  (14, @lundi + interval 10 day + interval 17 hour, 4, 'a17', 106),
  (15, @lundi + interval 11 day + interval 10 hour, 5, 'a17', 107),
  (16, @lundi + interval 11 day + interval 14 hour, 1, 'a17', 108);


insert into visite (id, dateEtHeure, idMotif, idVisiteur, idPraticien) values 
  (17, @lundi + interval 15 hour, 1, 'a18', 121),
  (18, @lundi + interval 17 hour, 1, 'a18', 122),
  (19, @lundi + interval 1 day + interval 09 hour + interval 30 minute, 2, 'a18', 123);


-- enregistrement du bilan et des médiciaments présentés pour les visites 1 et 2


update visite 
   set bilan = "Présentation satisfaisante", premierMedicament = '3MYC7'
where id = 1;


update visite 
   set bilan = "Présentation difficile", premierMedicament = 'JOVAI8', secondMEdicament = 'AMOXIG12'
where id = 2; 

select * from visite;

-- enregistrement des médiciaments présentés pour les visites 1 et 2

insert into echantillon(idVisite, idMedicament, quantite) values
	 (1,'AMOXIG12',2),
	 (1,'APATOUX22',5),
	 (2,'BACTIG10',6),
     (2,'AMOXIG12',3),
	 (2,'BACTIV13',3);
     
    

select * from visite;
select * from echantillon;
select * from praticien order by nom;