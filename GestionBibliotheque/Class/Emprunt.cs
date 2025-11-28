using System;
using System.Collections.Generic;
using System.Text;

namespace GestionBibliotheque.Class
{
    internal class Emprunt
    {
        public int Id { get; set; }
        public Livre UnLivre { get; set; }
        public Membre UnMembre { get; set; }
        public DateOnly DateEmprunt { get; set; }
        public DateOnly? DateRetour { get; set; }

        public Emprunt(int id, Livre unLivre, Membre unMembre, DateOnly dateEmprunt, DateOnly dateRetour)
        {
            Id = id;
            UnLivre = unLivre;
            UnMembre = unMembre;
            DateEmprunt = dateEmprunt;
            DateRetour = dateRetour;
        }

        public Emprunt(Livre unLivre, Membre unMembre, DateOnly dateEmprunt, DateOnly dateRetour)
        {
            UnLivre = unLivre;
            UnMembre = unMembre;
            DateEmprunt = dateEmprunt;
            DateRetour = dateRetour;
        }
        public Emprunt(int id, Livre unLivre, Membre unMembre, DateOnly dateEmprunt)
        {
            Id = id;
            UnLivre = unLivre;
            UnMembre = unMembre;
            DateEmprunt = dateEmprunt;
        }
        public Emprunt(Livre unLivre, Membre unMembre, DateOnly dateEmprunt)
        {
            UnLivre = unLivre;
            UnMembre = unMembre;
            DateEmprunt = dateEmprunt;
        }

        public override string ToString()
        {
            if (DateRetour.HasValue)
            {
                return $"id: {Id}, Date Emprunt : {DateEmprunt}, Date Retour : {DateRetour}";
            }
            
            return $"id: {Id}, Date Emprunt : {DateEmprunt}, Date Retour : Pas encore rendu";

        }

    }
}
