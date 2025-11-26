using System;
using System.Collections.Generic;
using System.Text;

namespace ExoBdd.Class
{
    internal class Classe
    {
        private int _id;
        private string _nom;

        public Classe(int id, string nom)
        {
            _id = id;
            _nom = nom;
        }

        public void afficher()
        {
            Console.WriteLine("Id Classe : "+_id);
            Console.WriteLine("Nom classe :"+_nom);
        }

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Nom
        {
            get { return _nom; }
            set { _nom = value; }
        }
    }
}
