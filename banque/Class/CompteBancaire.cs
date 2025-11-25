using System;
using System.Collections.Generic;
using System.Text;

namespace banque.Class
{
    internal abstract class CompteBancaire
    {
        protected float _solde;
        protected Client _client;
        protected List<Operation> _operations;

        protected CompteBancaire(float solde, Client client)
        {
            this._solde = solde;
            this._client = client;
            this._operations = new List<Operation>();
        }

        public IReadOnlyList<Operation> Operations
            => _operations;

        public void AddOperation(Operation operation)
        {
            _operations.Add(operation);
        }

        public float Solde
        {
            get { return _solde; }
            protected set { _solde = value; }
        }

        public Client Client
        {
            get { return _client; }
            protected set { _client = value; }
        }

        public virtual void Afficher()
        {
            Console.WriteLine("Solde : " + _solde);
        }

        public virtual void Depot(string numero, float montant)
        {
        }
    }
}
