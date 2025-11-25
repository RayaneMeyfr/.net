using System;
using System.Collections.Generic;
using System.Text;

namespace banque.Class
{
    internal class CompteCourant : CompteBancaire
    {
        private float _decouvertAutorise;

        public CompteCourant(float solde, Client client, float decouvertAutorise = 0) : base(solde, client)
        {
            _decouvertAutorise = decouvertAutorise;
        }

        public override void Depot(string numero, float montant)
        {
            if (montant <= 0)
            {
                Console.WriteLine("Le montant doit être positif.");
            }
            else
            {
                Solde += montant;
                AddOperation(new Operation(numero, montant, Statut.Depot));
            }
        }

        public bool Retrait(string numero, float montant)
        {
            if (montant <= 0)
                throw new ArgumentException("Le montant doit être positif.");

            if (Solde - montant < -_decouvertAutorise)
            {
                return false;
            }

            Solde -= montant;

            AddOperation(new Operation(numero, montant, Statut.Retrait));

            return true;
        }

        public override void Afficher()
        {
            base.Afficher();
            Console.WriteLine("Decouver autorisé: " + _decouvertAutorise);
        }

        public float DecouvertAutorise
        {
            get { return _decouvertAutorise; }
            set { _decouvertAutorise = value; }
        }

    }
}
