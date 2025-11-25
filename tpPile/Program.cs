using tpPile.Class;
using tpPile.Class.Generique;

bool sortie = true;

Pile<string> pileString = new Pile<string>();
Pile<decimal> pileDecimal = new Pile<decimal>();
Pile<Personne> pilePersonne = new Pile<Personne>();

do
{
    Console.WriteLine("\n---------- MENU PRINCIPAL ----------");
    Console.WriteLine("1. Pile de STRING");
    Console.WriteLine("2. Pile de DECIMAL");
    Console.WriteLine("3. Pile de PERSONNE");
    Console.WriteLine("4. Quitter");
    Console.WriteLine("------------------------------------\n");

    Console.Write("Saisir une option : ");
    int choix = int.Parse(Console.ReadLine());
    Console.WriteLine();

    switch (choix)
    {
        case 1:
            bool retourString = false;

            while (!retourString)
            {
                Console.WriteLine("\n--- PILE STRING ---");
                Console.WriteLine("1. Empiler");
                Console.WriteLine("2. Dépiler");
                Console.WriteLine("3. Retirer par index");
                Console.WriteLine("4. Afficher la pile");
                Console.WriteLine("5. Retour");
                Console.Write("Choix : ");

                int c = int.Parse(Console.ReadLine());

                switch (c)
                {
                    case 1:
                        Console.Write("Saisir un texte : ");
                        pileString.Empiler(Console.ReadLine());
                        Console.WriteLine("Empilé !");
                        break;

                    case 2:
                        Console.WriteLine("Dépilé : " + pileString.Depiler());
                        break;

                    case 3:
                        Console.Write("Index : ");
                        int idx = int.Parse(Console.ReadLine());
                        Console.WriteLine("Retiré : " + pileString.RetirerParIndex(idx));
                        break;

                    case 4:
                        pileString.Afficher();
                        break;

                    case 5:
                        retourString = true;
                        break;
                }
            }
            break;

        case 2:
            break;

        case 3:
            break;
        case 4:
            sortie = false;
            Console.WriteLine("Fin du programme");
            break;
    }

} while (sortie);
