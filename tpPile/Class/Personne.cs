using System;
using System.Collections.Generic;
using System.Text;

namespace tpPile.Class
{
    internal class Personne
    {
        private string _nom;
        private string _prenom;
        private int _age;

        public Personne(string nom, string prenom, int age)
        {
            this._nom = nom;
            this._prenom = prenom;
            this._age = age;
        }

        public string Nom
        {
            get { return _nom; }
            set { _nom = value; }
        }

        public string Prenom
        {
            get { return _prenom; }
            set { _prenom = value; }
        }

        public int Age
        {
            get { return _age; }
            set { _age = value; }
        }

        public override string ToString()
        {
            return $"{_prenom} {_nom}, {_age} ans";
        }
    }

}
