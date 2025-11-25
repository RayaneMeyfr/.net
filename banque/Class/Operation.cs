using System;
using System.Collections.Generic;
using System.Text;

namespace banque.Class
{
    internal class Operation
    {
        private string _numero;
        private float _montant;
        private Statut _statut;

        public Operation(string numero, float montant, Statut statut)
        {
            _numero = numero;
            _montant = montant;
            _statut = statut;
        }

        public string numero
        {
            get { return _numero; }
            set { _numero = value; }
        }

        public float montan
        {
            get { return _montant; }
            set { _montant = value; }
        }
        public Statut statut
        {
            get { return _statut; }
            set { _statut = value; }
        }
    }
}
