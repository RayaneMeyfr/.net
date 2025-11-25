using System;
using System.Collections.Generic;
using System.Text;

namespace banque.Class
{
    internal class CompteEpargne : CompteBancaire
    {
        private float _tauxInteret;

        public CompteEpargne(float solde, Client client, float tauxInteret = 0) : base(solde, client)
        {
            _tauxInteret = tauxInteret;
        }

        public override void Depot(string numero, float montant)
        {
            if (montant <= 0)
            {
                Console.WriteLine("Le montant doit être positif.");
            }

            Solde += montant;
            AddOperation(new Operation(numero, montant, Statut.Depot));
        }

        public bool Retrait(string numero, float montant)
        {
            if (montant <= 0)
                throw new ArgumentException("Le montant doit être positif.");

            if (montant > Solde)
            {
                return false; 
            }

            Solde -= montant;
            AddOperation(new Operation(numero, montant, Statut.Retrait));

            return true;
        }

        public void CalculerInterets()
        {
            float interets = Solde * (_tauxInteret / 100);
            Solde += interets;
            AddOperation(new Operation("Interets", interets, Statut.Depot));
        }

        public override void Afficher()
        {
            base.Afficher();
            Console.WriteLine("Taux Interet : " + _tauxInteret);
        }

        public float TauxInteret
        {
            get { return _tauxInteret; }
            set { _tauxInteret = value; }
        }

    }
}
