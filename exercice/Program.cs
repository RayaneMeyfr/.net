// See https://aka.ms/new-console-template for more information
using exercice.Class;

//Exo 1 Chaise
//Chaise uneChaise = new Chaise();
//uneChaise.afficher();

//Chaise uneChaiseParam = new Chaise(10, "Métal", "Noir");
//uneChaiseParam.afficher();

// Liste des salariés
List<Salarie> listSalaries = new List<Salarie>();
bool sorti = false;

do
{
    Console.WriteLine("---------- IHM ----------");
    Console.WriteLine("1. Ajouter un salarié");
    Console.WriteLine("2. Supprimer un salarié");
    Console.WriteLine("3. Afficher les salariés");
    Console.WriteLine("4. Afficher les statistiques globales");
    Console.WriteLine("5. Réinitialiser les statistiques globales");
    Console.WriteLine("6. Quitter");
    Console.WriteLine("-------------------------\n");

    Console.Write("Saisir une option : ");
    int choix = int.Parse(Console.ReadLine());
    Console.WriteLine();

    switch (choix){
        case 1:
            Console.Write("Entrez le matricule : ");
            string matricule = Console.ReadLine();

            Console.Write("Entrez le service : ");
            string service = Console.ReadLine();

            Console.Write("Entrez la catégorie : ");
            string categorie = Console.ReadLine();

            Console.Write("Entrez le nom : ");
            string nom = Console.ReadLine();

            Console.Write("Entrez le salaire : ");
            float salaire = float.Parse(Console.ReadLine());

            listSalaries.Add(new Salarie(matricule, service, categorie, nom, salaire));
            Console.WriteLine("Salarié ajouté");
            break;

        case 2:
            Console.Write("Entrez le matricule du salarié à supprimer : ");
            string matSup = Console.ReadLine();
            Salarie salSupp = listSalaries.Find(s => s.matricule == matSup);

            if (salSupp != null){
                listSalaries.Remove(salSupp);
                Console.WriteLine("Salarié supprimé");
            }
            else{
                Console.WriteLine("Aucun salarié trouvé avec ce matricule.");
            }
            break;

        case 3:
            Console.WriteLine("----- Liste des salariés -----");

            if (listSalaries.Count == 0){
                Console.WriteLine("Aucun salarié enregistré.");
            }else{
                foreach (var sal in listSalaries){
                    sal.afficherSalarie();
                }
            }
            break;

        case 4:
            Console.WriteLine("----- Statistiques globales -----");
            Salarie.afficheTotalStat();
            break;

        case 5:
            Salarie.reinitialisationStat();
            break;
        case 6:
            sorti = true; 
            break;

        default:
            Console.WriteLine("Option invalide.");
            break;
    }

} while (!sorti);

Console.WriteLine("\nProgramme terminé");
