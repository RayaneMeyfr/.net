CREATE TABLE client (
    id INT IDENTITY(1,1) PRIMARY KEY,
    nom NVARCHAR(100) NOT NULL,
    prenom NVARCHAR(100) NOT NULL,
    adresse NVARCHAR(255),
    codepostal NVARCHAR(20),
    ville NVARCHAR(100),
    telephone NVARCHAR(20)
);

CREATE TABLE commandes (
    id INT IDENTITY(1,1) PRIMARY KEY,
    clientid INT NOT NULL,
    datecommande DATE NOT NULL,
    total DECIMAL(10,2) NOT NULL,

    CONSTRAINT fk_commandes_client
        FOREIGN KEY (clientid) REFERENCES client(id)
        ON DELETE CASCADE
);
