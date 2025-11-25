using System;
using System.Collections.Generic;
using System.Text;

namespace banque.Class
{
    internal class Client
    {
        private string _nom;
        private string _prenom;
        private string _identifiant;
        private List<CompteBancaire> compteBancaires;

        public Client(string nom, string prenom, string identifiant, List<CompteBancaire> compteBancaires)
        {
            _nom = nom;
            _prenom = prenom;
            _identifiant = identifiant;
            this.compteBancaires = compteBancaires;
        }

        public Client(string nom, string prenom, string identifiant)
        {
            _nom = nom;
            _prenom = prenom;
            _identifiant = identifiant;
            this.compteBancaires = new List<CompteBancaire>();
        }

        public List<CompteBancaire> ComptesBancaires
        {
            get { return compteBancaires; }
            set { compteBancaires = value; }
        }

        public void AddCompte(CompteBancaire compte)
        {
            this.compteBancaires.Add(compte);
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

        public string Identifiant
        {
            get { return _identifiant; }
            set { _identifiant = value; }
        }

        public void afficher()
        {
            Console.WriteLine("Nom :"+_nom);
            Console.WriteLine("Prenom :"+_prenom);
            Console.WriteLine("Identifiant :"+_identifiant);
        }
    }
}
