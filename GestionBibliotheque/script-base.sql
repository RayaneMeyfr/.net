create table livre (
    id int identity(1,1) primary key,
    titre nvarchar(255) not null,
    auteur nvarchar(255) not null,
    isbn nvarchar(50) not null unique,
    anneePublication int not null,
    estDisponible bit not null default 1
);

create table membre (
    id int identity(1,1) primary key,
    nom nvarchar(255) not null,
    prenom nvarchar(255) not null,
    email nvarchar(255) not null unique,
    dateInscription date not null
);

create table emprunt (
    id int identity(1,1) primary key,
    livreId int not null,
    membreId int not null,
    dateEmprunt date not null,
    dateRetour date null,

    constraint fk_emprunt_livre foreign key (livreId)
        references livre(id) on delete cascade,

    constraint fk_emprunt_membre foreign key (membreId)
        references membre(id) on delete cascade
);
