using ExoGestionCommande.Class;
using ExoGestionCommande.Dao;

var ihm = new Ihm();
var executer = true;

do
{
    Console.WriteLine("\n---------- MENU PRINCIPAL ----------");
    Console.WriteLine("1. Afficher les clients");
    Console.WriteLine("2. Créer un client");
    Console.WriteLine("3. Modifier un client");
    Console.WriteLine("4. Supprimer un client");
    Console.WriteLine("5. Afficher les détails d'un client");
    Console.WriteLine("6. Ajouter une commande");
    Console.WriteLine("7. Modifier une commande");
    Console.WriteLine("8. Supprimer une commande");
    Console.WriteLine("0. Quitter");
    Console.WriteLine("------------------------------------\n");

    Console.Write("Saisir une option : ");
    int choix = int.Parse(Console.ReadLine());

    switch (choix)
    {
        case 1:
            ihm.afficherClients();
            break;
        case 2:
            ihm.creerClient();
            break;
        case 3:
            ihm.modifClient();
            break;
        case 4:
            ihm.supprimeClient();
            break;
        case 5:
            ihm.afficherDetailClient();
            break;
        case 6:
            ihm.creerCommande();
            break;
        case 7:
            ihm.modifCommande();
            break;
        case 8:
            ihm.supprimeCommande();
            break;
        case 0:
            Console.WriteLine("Fin du programme");
            executer = false;
            break;
        default:
            Console.WriteLine("Ce choix n'existe pas");
            break;
    }

} while (executer);


//var unClient = new Client("Rayane", "Meyfroot", "51 rue Aurele Guenard", "Leers", "59115", "06.98.69.87.69");
//var unClient2 = new Client("Louis", "Devienne", "42 rue Latel Montar", "Foret", "59152", "06.65.25.54.72");

//dtoClient.Save(unClient);
//dtoClient.Save(unClient2);

//var clients = dtoClient.GetAll();

//foreach (var client in clients)
//{
//    Console.WriteLine(client);
//}

//var unClient = dtoClient.getOneById(1);
//Console.WriteLine(unClient);

//unClient.Prenom = "Erwan";
//unClient.Nom = "Zitoune";

//dtoClient.Update(unClient);

//Console.WriteLine(unClient);

//var unClient = dtoClient.getOneById(1);
//var unClient2 = dtoClient.getOneById(2);

//var uneCommande = new Commande(unClient, new DateOnly(2024, 10, 15),120);
//var uneCommande2 = new Commande(unClient, new DateOnly(2025, 09, 10),50);
//var uneCommande3 = new Commande(unClient2, new DateOnly(2012, 12, 01),300);

//dtoCommande.Save(uneCommande);
//dtoCommande.Save(uneCommande2);
//dtoCommande.Save(uneCommande3);

//var commandes = dtoCommande.GetAll();

//foreach (var commande in commandes)
//{
//    Console.WriteLine(commande);
//}

//var uneCommande = dtoCommande.getOneById(1);
//Console.WriteLine(uneCommande);

//uneCommande.Total = 10000;
//dtoCommande.Update(uneCommande);

//Console.WriteLine(uneCommande);






