using GestionBibliotheque.Class;
using GestionBibliotheque.Dao;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestionBibliotheque.Ihm
{
    internal class IhmEmprunt
    {
        private EmpruntDao _empruntDao;
        private LivreDao _livreDao;
        private MembreDao _membreDao;
        private Membre _membre;

        public IhmEmprunt(EmpruntDao empruntDao, LivreDao livreDao, MembreDao membreDao)
        {
            _empruntDao = empruntDao;
            _livreDao = livreDao;
            _membreDao = membreDao;
        }

        public void menu()
        {
            this.selectionMembre();
            var executer = true;

            do
            {
                Console.WriteLine("\n---------- Membre Sélectioner ----------\n");
                Console.WriteLine(_membre);
                Console.WriteLine("------------------------------------\n");


                Console.WriteLine("---------- MENU MEMBRE ----------");
                Console.WriteLine("1. Emprunter un livre");
                Console.WriteLine("2. Retourner un livre");
                Console.WriteLine("3. Voir les emprunt en cours");
                Console.WriteLine("4. Changer de membre");
                Console.WriteLine("0. retour");
                Console.WriteLine("------------------------------------\n");

                Console.Write("Saisir une option : ");
                int choix = int.Parse(Console.ReadLine());

                switch (choix)
                {
                    case 1:
                        this.emprunterLivre();
                        break;
                    case 2:
                        this.retournerLivre();
                        break;
                    case 3:
                        this.listeDesEmprunts();
                        break;
                    case 4:
                        this.selectionMembre();
                        break;
                    case 0:
                        Console.WriteLine("Retour");
                        executer = false;
                        break;
                }

            } while (executer);
        }


        public void emprunterLivre()
        {
            Console.WriteLine("Liste des livres : ");
            List<Livre> livres = _livreDao.GetAll();
            var livreEmpruntable = false;
            if (livres.Count > 0)
            {
                for (int i = 0; i < livres.Count; i++)
                {
                    if (livres[i].EstDisponible)
                    {
                        livreEmpruntable = true;
                        int index = i + 1;
                        Console.WriteLine(index + " - " + livres[i]);
                    }
                }

                if (livreEmpruntable)
                {
                    Console.Write("Saisir le numero : ");
                    int choix = int.Parse(Console.ReadLine());

                    var livreGet = livres[choix];

                    livreGet.EstDisponible = false;

                    Emprunt unEmprunt = new Emprunt(livreGet, _membre,DateOnly.FromDateTime(DateTime.Today));
                    
                    _empruntDao.Save(unEmprunt);
                    _livreDao.Update(livreGet);
                }
                else
                {
                    Console.WriteLine("Pas de livre empruntable");
                }
            }
            else
            {
                Console.WriteLine("Pas de livre");
            }
        }

        public void retournerLivre()
        {
            List<Emprunt> emprunts = _empruntDao.GetAll();
            List<Emprunt> empruntsMembre = new List<Emprunt>();

            if (emprunts.Count > 0)
            {
                foreach(var empr in emprunts)
                {
                    if (empr.UnMembre.Id == _membre.Id && !empr.UnLivre.EstDisponible) { 
                        empruntsMembre.Add(empr);
                    }
                }

                if (empruntsMembre.Count > 0)
                {
                    for (int i = 0; i < empruntsMembre.Count; i++)
                    {
                        int index = i+1;
                        Console.WriteLine(index+" - "+ empruntsMembre[i] + empruntsMembre[i].UnLivre);
                    }

                    Console.Write("Saisir le numero : ");
                    int choix = int.Parse(Console.ReadLine());

                    var empruntGet = empruntsMembre[choix - 1];
                    empruntGet.DateRetour = DateOnly.FromDateTime(DateTime.Today);

                    var result = _empruntDao.Update(empruntGet);

                    var livreGet = empruntGet.UnLivre;
                    livreGet.EstDisponible = true;

                    _livreDao.Update(livreGet);

                    if (result != null)
                    {
                        Console.WriteLine("Le retoure a bien etait enregistrer : "+result);
                    }
                    else
                    {
                        Console.WriteLine("Le retoure n'a pas pus être fait");
                    }
                }
                else
                {
                    Console.WriteLine("Aucun livre emprunter");
                }
            }
            else
            {
                Console.WriteLine("Aucun livre emprunter");
            }

        }

        public void listeDesEmprunts()
        {
            List<Emprunt> emprunts = _empruntDao.GetAll();
            List<Emprunt> empruntsMembre = new List<Emprunt>();

            if (emprunts.Count > 0)
            {
                foreach (var empr in emprunts)
                {
                    if (empr.UnMembre.Id == _membre.Id && !empr.UnLivre.EstDisponible)
                    {
                        empruntsMembre.Add(empr);
                    }
                }

                if (empruntsMembre.Count > 0)
                {
                   foreach(var empr in empruntsMembre)
                    {
                        Console.WriteLine(empr+" "+empr.UnLivre);
                    }
                }
                else
                {
                    Console.WriteLine("Aucun livre emprunter");
                }
            }
            else
            {
                Console.WriteLine("Aucun livre emprunter");
            }
        }

        public void selectionMembre()
        {
            Console.WriteLine("Choisir le membre dans le liste");

            List<Membre> membres = _membreDao.GetAll();

            for(int i = 0; i < membres.Count; i++)
            {
                int index = i + 1;
                Console.WriteLine(index + " - " + membres[i]);
            }

            Console.Write("Saisir le numero : ");
            int choix = int.Parse(Console.ReadLine());

            _membre = membres[choix-1];
        }
    }
}
