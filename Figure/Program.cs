using Figure.Class;

bool sortie = true;
List<ClsFigure> listFigures = new List<ClsFigure>();

do
{
    Console.WriteLine("\n---------- IHM ----------");
    Console.WriteLine("1. Afficher les figures");
    Console.WriteLine("2. Créer un carré");
    Console.WriteLine("3. Créer un rectangle");
    Console.WriteLine("4. Créer un triangle");
    Console.WriteLine("5. Déplacer une figure");
    Console.WriteLine("6. Quitter le programme");
    Console.WriteLine("-------------------------\n");

    Console.Write("Saisir une option : ");
    int choix = int.Parse(Console.ReadLine());
    Console.WriteLine();

    switch (choix)
    {
        case 1:
            Console.WriteLine("Liste des Figures :");
            if (listFigures.Count < 1)
            {
                Console.WriteLine("Pas de figure");
            }
            else
            {
                foreach (var f in listFigures)
                {
                    Console.WriteLine(f.ToString());
                }
            }
            break;

        case 2: 
            Console.Write("Saisir la position X : ");
            double xCarre = double.Parse(Console.ReadLine());

            Console.Write("Saisir la position Y : ");
            double yCarre = double.Parse(Console.ReadLine());

            Console.Write("Saisir la longueur du côté : ");
            int cote = int.Parse(Console.ReadLine());

            listFigures.Add(new Carre(xCarre, yCarre, cote));
            Console.WriteLine("Carré créé avec succès !");
            break;

        case 3: 
            Console.Write("Saisir la position X : ");
            double xRect = double.Parse(Console.ReadLine());

            Console.Write("Saisir la position Y : ");
            double yRect = double.Parse(Console.ReadLine());

            Console.Write("Saisir la largeur : ");
            int largeur = int.Parse(Console.ReadLine());

            Console.Write("Saisir la hauteur : ");
            int hauteur = int.Parse(Console.ReadLine());

            listFigures.Add(new Rectangle(xRect, yRect, largeur, hauteur));
            Console.WriteLine("Rectangle créé avec succès !");
            break;

        case 4:
            Console.Write("Saisir la position X : ");
            double xTri = double.Parse(Console.ReadLine());

            Console.Write("Saisir la position Y : ");
            double yTri = double.Parse(Console.ReadLine());

            Console.Write("Saisir la base : ");
            int baseT = int.Parse(Console.ReadLine());

            Console.Write("Saisir la hauteur : ");
            int hauteurT = int.Parse(Console.ReadLine());

            listFigures.Add(new Triangle(xTri, yTri, baseT, hauteurT));
            Console.WriteLine("Triangle créé avec succès !");
            break;

        case 5:
            if (listFigures.Count < 1)
            {
                Console.WriteLine("Pas de figure à déplacer !");
                break;
            }

            Console.WriteLine("Liste des Figures :");
            for (int i = 0; i < listFigures.Count; i++)
            {
                Console.WriteLine($"{i+1} - {listFigures[i].ToString()}");
            }

            Console.Write("Choisir l'index de la figure à déplacer : ");
            int index = int.Parse(Console.ReadLine());
            index -= 1;
            if (index < 0 || index >= listFigures.Count)
            {
                Console.WriteLine("Index invalide !");
                break;
            }

            Console.Write("Saisir le déplacement en X : ");
            double dx = double.Parse(Console.ReadLine());

            Console.Write("Saisir le déplacement en Y : ");
            double dy = double.Parse(Console.ReadLine());

            listFigures[index].Deplacement(dx, dy);
            Console.WriteLine("Figure déplacée avec succès !");
            break;

        case 6:
            Console.WriteLine("Fin du programme");
            sortie = false;
            break;

        default:
            Console.WriteLine("Ce choix n'existe pas \n");
            break;
    }

} while (sortie);
