using System;
using System.Collections.Generic;
using System.Text;

namespace ExoGestionCommande.Class
{
    internal class Client
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Adresse { get; set; }
        public string CodePostal { get; set; }
        public string Ville { get; set; }
        public string Telephone { get; set; }

        public Client(int id, string nom, string prenom, string adresse, string codePostal, string ville, string telephone)
        {
            Id = id;
            Nom = nom;
            Prenom = prenom;
            Adresse = adresse;
            CodePostal = codePostal;
            Ville = ville;
            Telephone = telephone;
        }

        public Client(string nom, string prenom, string adresse, string codePostal, string ville, string telephone)
        {
            Nom = nom;
            Prenom = prenom;
            Adresse = adresse;
            CodePostal = codePostal;
            Ville = ville;
            Telephone = telephone;
        }

        public override string ToString()
        {
            return $"id: {Id}, nom : {Nom}, prénom : {Prenom}, Adresse : {Adresse}, Code Postal : {CodePostal}, Ville : {Ville}, Téléphone : {Telephone}";
        }
    }
}
