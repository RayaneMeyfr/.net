using System;
using System.Collections.Generic;
using System.Text;

namespace GestionBibliotheque.Class
{
    internal class Livre
    {
        public int Id { get; set; }
        public string Titre { get; set; }
        public string Auteur { get; set; }
        public string Isbn { get; set; }
        public int AnneePublication { get; set; }
        public bool EstDisponible { get; set; }

        public Livre(int id, string titre, string auteur, string isbn, int anneePublication, bool estDisponible)
        {
            Id = id;
            Titre = titre;
            Auteur = auteur;
            Isbn = isbn;
            AnneePublication = anneePublication;
            EstDisponible = estDisponible;
        }

        public Livre(string titre, string auteur, string isbn, int anneePublication, bool estDisponible)
        {
            Titre = titre;
            Auteur = auteur;
            Isbn = isbn;
            AnneePublication = anneePublication;
            EstDisponible = estDisponible;
        }

        public override string ToString()
        {
            var dispo = "indisponible";
            if (EstDisponible)
            {
                dispo = "disponible";
            }

            return $"id: {Id}, Titre : {Titre}, Auteur : {Auteur}, Isbn : {Isbn}, dispo ? : {dispo},";
        }
    }
}
