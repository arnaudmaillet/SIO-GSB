-- -------------------------------------------
-- Programme : create.sql 
-- Objet : création des tables du projet GSB Fiche visite
-- Serveur : MySQL  
-- Auteur : Guy Verghote 
-- Date : 09/03/2021
-- -------------------------------------------

-- La clause innoDB peut etre paramètré dans preference > modeling > mySql

drop database if exists gsb;

create database gsb;

use gsb;
set names utf8mb4;

create table famille (
	id varchar(3) primary key,
	libelle varchar(80) not null
) engine=innoDb;

create table medicament (
	id varchar(10) PRIMARY KEY,
	nom varchar(25) not null,
	composition varchar(255) not null,
	effets varchar(255),
	contreIndication varchar(255),
	idFamille varchar(3) not null,
	foreign key (idFamille) references famille(id)
) engine=innoDb;

create table specialite (
	id varchar(5) PRIMARY KEY,
	libelle varchar(150) not null
) engine=innoDb;

create table typePraticien (
	id varchar(3) PRIMARY KEY,
	libelle varchar(25) not null,
	lieu varchar(35) not null
) engine=innoDb;

create table praticien (
	id int auto_increment PRIMARY KEY,
	nom varchar(25) not null,
	prenom varchar(30) not null,
	rue varchar(50) not null,
	codePostal varchar(5) not null,
	ville varchar(30) not null,
	telephone varchar(14) null unique,
	email varchar(75) null unique,
	idType varchar(3) not null,
	idSpecialite varchar(5) null,
    foreign key (idType) references typePraticien (id),
	foreign key (idSpecialite) references specialite (id)
) engine=innoDb;

create table visiteur (
	id varchar(3) PRIMARY KEY,
	nom varchar(25) not null,
	prenom varchar(50) not null,
	rue varchar(50) not null,
	codePostal varchar(5) not null,
	ville varchar(45) not null,
	dateEmbauche Date not null,
    dateDepart date null
) engine=innoDb;

create table motif (
	id int auto_increment primary key,
	libelle varchar(60) not null
) engine=innoDb;

create table visite(
	id int auto_increment primary key,
	dateEtHeure datetime not null,
	bilan text null,
	idMotif int not null,
	idVisiteur varchar(3) not null,
	idPraticien int not null,
	premierMedicament varchar(10) null,
	secondMedicament varchar(10) null,
	foreign key (idMotif) references motif(id),
	foreign key (idVisiteur) references visiteur(id),
	foreign key (idPraticien) references praticien(id),
	foreign key (premierMedicament) references medicament(id),
	foreign key (secondMedicament) references medicament(id)
) engine=innoDb;

Create table echantillon (
	idVisite int not null,
	idMedicament varchar(10) not null,
	quantite int not null default 1,
	Primary Key (idVisite, idMedicament),
	foreign key (idVisite) references visite (id),
	foreign key (idMedicament) references medicament (id)
) engine=innoDb;