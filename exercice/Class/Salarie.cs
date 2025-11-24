using System;
using System.Collections.Generic;
using System.Text;

namespace exercice.Class
{
    internal class Salarie
    {
        private static int _nbEmployer = 0;
        private static float _salaireTotal = 0;

        private string _matricule;
        private string _service;
        private string _categorie;
        private string _nom;
        private float _salaire;

        public Salarie(string matricule, string service, string categorie, string nom, float salaire)
        {
            _matricule = matricule;
            _service = service;
            _categorie = categorie;
            _nom = nom;
            _salaire = salaire;
            _nbEmployer++;
            _salaireTotal += _salaire;
        }

        public void afficherSalarie()
        {
            Console.WriteLine("Matricule: " + _matricule);
            Console.WriteLine("Service: "+ _service);
            Console.WriteLine("Categorie: "+_categorie);
            Console.WriteLine("Nom: "+_nom);
            Console.WriteLine("Salaire: "+_salaire+"\n");
        }

        public static void afficheTotalStat()
        {
            Console.WriteLine("Le montant Total des salaires des " +_nbEmployer+" employés est de "+_salaireTotal+" €");
        }

        public static void reinitialisationStat()
        {
            _nbEmployer = 0;
            _salaireTotal = 0;
            Console.WriteLine("Réinitialisation des statistiques globales");
        }

        public string matricule
        {
            get => _matricule;
            set => _matricule = value;
        }

        public string service
        {
            get => _service;
            set => _service = value;
        }

        public string categorie
        {
            get => _categorie;
            set => _categorie = value;
        }

        public string nom
        {
            get => _nom;
            set => _nom = value;
        }

        public float salaire
        {
            get => _salaire;
            set => _salaire = value;
        }
    }
}
