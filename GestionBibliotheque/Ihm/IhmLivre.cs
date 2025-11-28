using GestionBibliotheque.Class;
using GestionBibliotheque.Dao;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestionBibliotheque.Ihm
{
    internal class IhmLivre
    {
        private LivreDao _livreDao;

        public IhmLivre(LivreDao livreDao)
        {
            _livreDao = livreDao;
        }

        public void menu()
        {
            var executer = true;

            do
            {
                Console.WriteLine("\n---------- MENU LIVRE ----------");
                Console.WriteLine("1. Ajouter un livre");
                Console.WriteLine("2. Lister les livres");
                Console.WriteLine("3. Rechercher par auteur");
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
            Console.Write("Saisir le titre : ");
            string titre = Console.ReadLine();

            Console.Write("Saisir l'auteur : ");
            string auteur = Console.ReadLine();

            Console.Write("Saisir l'isbn : ");
            string isbn = Console.ReadLine();

            Console.Write("Saisir le Année de publication : ");
            int anneePublication = int.Parse(Console.ReadLine());

            var unLivre = new Livre(titre, auteur, isbn, anneePublication, false);

            var result = _livreDao.Save(unLivre);

            if (result != null)
            {
                Console.WriteLine($"Livre enregistré avec succès : {result}");
            }
            else
            {
                Console.WriteLine("Erreur lors de l'enregistrement du livre.");
            }

        }

        public void lister() {
            Console.WriteLine("Liste des livres : ");
            List<Livre> livres = _livreDao.GetAll();

            if (livres.Count > 0)
            {
                foreach(var livre in livres)
                {
                    Console.WriteLine(livre+"\n");
                }
            }
            else
            {
                Console.WriteLine("Pas de livre");
            }
        }

        public void rechercher() {
            Console.Write("Saisir l'auteur : ");
            string auteur = Console.ReadLine();

            List<Livre> livres = _livreDao.GetAll();
            List<Livre> livresDeLauteur = new List<Livre>();

            if (livres.Count > 0)
            {
                foreach (var livre in livres)
                {
                    if (livre.Auteur == auteur)
                    {
                        livresDeLauteur.Add(livre);
                    }
                }

                if (livresDeLauteur.Count > 0) {
                    foreach (var livre in livresDeLauteur)
                    {
                        Console.WriteLine(livre+ "\n");
                    }
                }
                else
                {
                    Console.WriteLine("Pas de livre trouvé pour cette auteur");
                }
            }
            else
            {
                Console.WriteLine("Pas de livre");
            }
        }
    }
}
