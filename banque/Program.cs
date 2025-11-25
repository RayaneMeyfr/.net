using banque.Class;

Client client = new Client("Meyfroot", "Rayane", "FB00827");

CompteCourant unCompteCourrant = new CompteCourant(2000, client, -500);
client.AddCompte(unCompteCourrant);

CompteEpargne unCompteEpargne = new CompteEpargne(5000, client, 5);
client.AddCompte(unCompteEpargne);

ComptePayant unComptePayant = new ComptePayant(3000, client, 3);
client.AddCompte(unComptePayant);

bool sortie = false;

do{
    Console.WriteLine("\n---------- IHM ----------");
    Console.WriteLine("1. Lister les comptes bancaires");
    Console.WriteLine("2. Créer un compte bancaire");
    Console.WriteLine("3. Effectuer un dépot");
    Console.WriteLine("4. Effectuer un retrait");
    Console.WriteLine("5. Afficher les opérations et le solde");
    Console.WriteLine("6. Quitter les programme");
    Console.WriteLine("-------------------------\n");

    Console.Write("Saisir une option : ");
    int choix = int.Parse(Console.ReadLine());
    Console.WriteLine();

    switch (choix)
    {
        case 1:
            Console.WriteLine("Liste des comptes bancaires :");
            if (client.ComptesBancaires.Count < 1)
            {
                Console.WriteLine("Pas de compte bancaire");
            }
            else
            {
                foreach(var compte in client.ComptesBancaires)
                {
                    compte.Afficher();
                }
            }
                break;
        case 2:
            Console.WriteLine("Création de compte");
            break;
        case 3:
            Console.WriteLine("Choix du compte :");

            int nb = 0;
            CompteBancaire compteChoisi = null;
            Dictionary<int, CompteBancaire> listeCompteChoix= new Dictionary<int, CompteBancaire>();

            foreach (var compte in client.ComptesBancaires)
            {
                nb++;
                if (compte is CompteCourant)
                {
                    Console.WriteLine(nb + ". Compte Courant");
                }
                else if (compte is CompteEpargne)
                {
                    Console.WriteLine(nb + ". Compte Épargne");
                }
                else if (compte is ComptePayant)
                {
                    Console.WriteLine(nb + ". Compte Payant");
                }


                listeCompteChoix.Add(nb, compte);
            }

            Console.Write("Saisir une option : ");
            int saisie = int.Parse(Console.ReadLine());

            if (!listeCompteChoix.ContainsKey(saisie))
            {
                Console.WriteLine("Choix inexistant");
            }
            else
            {
                compteChoisi = listeCompteChoix[saisie];

                Console.Write("Saisir l'indentifiant de l'opération : ");
                string identifiant = Console.ReadLine();

                Console.Write("Saisir le montant: ");
                int montant = int.Parse(Console.ReadLine());

                compteChoisi.Depot
            break;
        case 4:
            Console.WriteLine("");
            break;
        case 5:
            Console.WriteLine("");
            break;
        case 6:
            Console.WriteLine("Fin du programme");
            sortie = true;
            break;
        default:
            Console.WriteLine("Ce choix n'existe pas \n");
            break;
    }

    } while (sortie);

