using System;
using System.Collections.Generic;
using System.Text;

namespace banque.Class
{
    internal class ComptePayant : CompteBancaire
    {
        private float _frais; 

        public ComptePayant(float solde, Client client, float frais = 1)
            : base(solde, client)
        {
            _frais = frais;
        }

        public void Depot(string numero, float montant)
        {
            if (montant <= 0)
                throw new ArgumentException("Le montant doit être positif.");

            if (montant <= _frais)
                throw new ArgumentException("Le montant doit être supérieur aux frais.");

            Solde += (montant - _frais);
            AddOperation(new Operation(numero, montant, Statut.Depot));
            AddOperation(new Operation("Frais", _frais, Statut.Retrait));
        }

        public bool Retrait(string numero, float montant)
        {
            if (montant <= 0)
                throw new ArgumentException("Le montant doit être positif.");

            if (Solde < montant + _frais)
                return false; // solde insuffisant

            Solde -= (montant + _frais);
            AddOperation(new Operation(numero, montant, Statut.Retrait));
            AddOperation(new Operation("Frais", _frais, Statut.Retrait));

            return true;
        }

        public override void Afficher()
        {
            base.Afficher()
            Console.WriteLine("Frais : " + _frais);
        }

        public float Frais
        {
            set { _frais = value; }
            get { return _frais; }
        }
    }
}
