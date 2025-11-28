using GestionBibliotheque.Class;
using GestionBibliotheque.Dao;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestionBibliotheque.Ihm
{
    internal class IhmMembre
    {
        private MembreDao _membreDao;

        public IhmMembre(MembreDao membreDao)
        {
            _membreDao = membreDao;
        }

        public void menu()
        {
            var executer = true;

            do
            {
                Console.WriteLine("\n---------- MENU MEMBRE ----------");
                Console.WriteLine("1. Ajouter un membre");
                Console.WriteLine("2. Lister les membres");
                Console.WriteLine("3. Rechercher par email");
                Console.WriteLine("0. retour");
                Console.WriteLine("------------------------------------\n");

                Console.Write("Saisir une option : ");
                int choix = int.Parse(Console.ReadLine());

                switch (choix)
                {
                    case 1:
                        this.ajouter();
                        break;
                    case 2:
                        this.lister();
                        break;
                    case 3:
                        this.rechercher();
                        break;
                    case 0:
                        Console.WriteLine("Retour");
                        executer = false;
                        break;
                }

            } while (executer);
        }

        public void ajouter()
        {
            Console.Write("Saisir le nom : ");
            string nom = Console.ReadLine();

            Console.Write("Saisir un prénom : ");
            string prenom = Console.ReadLine();

            Console.Write("Saisir un email : ");
            string email = Console.ReadLine();

            var unMembre = new Membre(nom,prenom,email,DateOnly.FromDateTime(DateTime.Today));

            var result = _membreDao.Save(unMembre);

            if (result != null)
            {
                Console.WriteLine($"Membre enregistré avec succès : {result}");
            }
            else
            {
                Console.WriteLine("Erreur lors de l'enregistrement du membre.");
            }

        }

        public void lister()
        {
            Console.WriteLine("Liste des membres : ");
            List<Membre> membres = _membreDao.GetAll();

            if (membres.Count > 0)
            {
                foreach (var membre in membres)
                {
                    Console.WriteLine(membre + "\n");
                }
            }
            else
            {
                Console.WriteLine("Pas de membre");
            }
        }

        public void rechercher()
        {
            Console.Write("Saisir l'email : ");
            string email = Console.ReadLine();

            List<Membre> membres = _membreDao.GetAll();
            Membre? unMembre = null;

            if (membres.Count > 0)
            {
                foreach (var membre in membres)
                {
                    if (membre.Email == email)
                    {
                       unMembre = membre;
                    }
                }

                if (unMembre != null)
                {
                    Console.WriteLine("Voici le membre avec cette email : \n" + unMembre);
                }
                else
                {
                    Console.WriteLine("Pas de membre trouvé");
                }
            }
            else
            {
                Console.WriteLine("Pas de membre");
            }
        }
    }
}
