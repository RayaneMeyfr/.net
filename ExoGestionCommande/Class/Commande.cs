using System;
using System.Collections.Generic;
using System.Text;

namespace ExoGestionCommande.Class
{
    internal class Commande
    {
        public int Id { get; set; }
        public Client UnClient { get; set; }
        public DateOnly UneDate { get; set; }
        public int Total { get; set; }

        public Commande(int id, Client client, DateOnly date, int total)
        {
            Id = id;
            UnClient = client;
            UneDate = date;
            Total = total;
        }

        public Commande( Client client, DateOnly date, int total)
        {
            UnClient = client;
            UneDate = date;
            Total = total;
        }

        public override string ToString()
        {
            return $"id: {Id}, Client : {UnClient}, Date : {UneDate}, Total : {Total}";
        }
    }
}
