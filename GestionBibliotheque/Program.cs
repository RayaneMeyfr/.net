using GestionBibliotheque.Dao;
using GestionBibliotheque.Ihm;

var livreDao = new LivreDao();
var membreDao = new MembreDao();
var empruntDao = new EmpruntDao();

var ihmLivre = new IhmLivre(livreDao);
var ihmMembre = new IhmMembre(membreDao);
var ihmEmprunt = new IhmEmprunt(empruntDao,livreDao,membreDao);
var executer = true;

do
{
    Console.WriteLine("\n---------- MENU PRINCIPAL ----------");
    Console.WriteLine("1. Gérer les livres");
    Console.WriteLine("2. Gérer les Membre");
    Console.WriteLine("3. Gérer les emprunts");
    Console.WriteLine("0. Quitter");
    Console.WriteLine("------------------------------------\n");

    Console.Write("Saisir une option : ");
    int choix = int.Parse(Console.ReadLine());

    switch (choix)
    {
        case 1:
            ihmLivre.menu();
            break;
        case 2:
            ihmMembre.menu();
            break;
        case 3:
            ihmEmprunt.menu();
            break;
        case 0:
            Console.WriteLine("Fin du programme");
            executer = false;
            break;
    }

} while (executer);