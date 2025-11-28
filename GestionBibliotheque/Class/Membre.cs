using System;
using System.Collections.Generic;
using System.Text;

namespace GestionBibliotheque.Class
{
    internal class Membre
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Email { get; set; }
        public DateOnly DateInscription { get; set; }

        public Membre(int id, string nom, string prenom, string email, DateOnly dateInscription)
        {
            Id = id;
            Nom = nom;
            Prenom = prenom;
            Email = email;
            DateInscription = dateInscription;
        }

        public Membre(string nom, string prenom, string email, DateOnly dateInscription)
        {
            Nom = nom;
            Prenom = prenom;
            Email = email;
            DateInscription = dateInscription;
        }

        public override string ToString()
        {
            return $"id: {Id}, nom : {Nom}, prénom : {Prenom}, Email : {Email}, Date Inscription : {DateInscription}";
        }
    }
}
