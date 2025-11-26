CREATE DATABASE testsql

CREATE TABLE Classe (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nom VARCHAR(100) NOT NULL
)

CREATE TABLE Etudiant (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nom VARCHAR(100) NOT NULL,
    Prenom VARCHAR(100) NOT NULL,
    NumeroClasse INT NOT NULL,
    DateDiplome DATE NOT NULL,
    CONSTRAINT FK_Etudiant_Classe FOREIGN KEY (NumeroClasse)
        REFERENCES Classe(Id)
)

INSERT INTO Classe (Nom) VALUES
('Informatique'),
('Gestion'),
('Comptabilité'),
('Marketing');

INSERT INTO Etudiant (Nom, Prenom, NumeroClasse, DateDiplome) VALUES
('Dupont', 'Marie', 1, '2024-06-30'),
('Martin', 'Lucas', 1, '2025-06-30'),
('Durand', 'Sophie', 2, '2024-09-15'),
('Bernard', 'Thomas', 3, '2023-06-30'),
('Robert', 'Emma', 4, '2025-01-20'),
('Moreau', 'Julie', 3, '2024-12-10')