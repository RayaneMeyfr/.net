using ExoGestionCommande.Dao;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExoGestionCommande.Class
{
    internal class Ihm
    {
        private ClientDto _dtoClient;
        private CommandeDto _dtoCommande;

        public Ihm() { 
            _dtoClient = new ClientDto();
            _dtoCommande = new CommandeDto();
        }

        public void afficherClients()
        {
            List<Client> clients = _dtoClient.GetAll();

            if (clients.Count > 0)
            {
                foreach (Client client in clients)
                {
                    Console.WriteLine(client);
                }
            }
            else
            {
                Console.WriteLine("Aucun client trouvé");
            }
        }

        public void creerClient()
        {
            Console.Write("Saisir le nom : ");
            string nom = Console.ReadLine();

            Console.Write("Saisir le prénom : ");
            string prenom = Console.ReadLine();

            Console.Write("Saisir l'adresse : ");
            string adresse = Console.ReadLine();

            Console.Write("Saisir le code postal : ");
            string codePostal = Console.ReadLine();

            Console.Write("Saisir la ville : ");
            string ville = Console.ReadLine();

            Console.Write("Saisir le numéro de téléphone : ");
            string telephone = Console.ReadLine();

            Client unClient = new Client(nom,prenom,adresse, codePostal,ville,telephone);
            var result = _dtoClient.Save(unClient);

            if ( result != null)
            {
                Console.WriteLine("\nLe client a bien etait enregistrer :\n\n" + unClient);
            }else
            {
                Console.WriteLine("\nLe client n'a pas pus être enregister.");
            }
        }

        public void modifClient()
        {
            Console.WriteLine("\nChoisir le client a modifier : ");

            List<Client> clients = _dtoClient.GetAll();
            int index = 0;

            if (clients.Count > 0)
            {
                foreach (Client client in clients)
                {
                    index++;
                    Console.WriteLine(index + " - " + client);
                }

                Console.Write("\nSaisir le numéro du client : ");
                int choix = int.Parse(Console.ReadLine());

                Client unClient = clients[choix - 1];

                Console.Write("Saisir le nom : ");
                string nom = Console.ReadLine();
                if (!string.IsNullOrEmpty(nom))
                {
                    unClient.Nom = nom;
                }

                Console.Write("Saisir le prénom : ");
                string prenom = Console.ReadLine();
                if (!string.IsNullOrEmpty(prenom))
                {
                    unClient.Prenom = prenom;
                }

                Console.Write("Saisir l'adresse : ");
                string adresse = Console.ReadLine();
                if (!string.IsNullOrEmpty(adresse))
                {
                    unClient.Adresse = adresse;
                }

                Console.Write("Saisir le code postal : ");
                string codePostal = Console.ReadLine();
                if (!string.IsNullOrEmpty(codePostal))
                {
                    unClient.CodePostal = codePostal;
                }

                Console.Write("Saisir la ville : ");
                string ville = Console.ReadLine();
                if (!string.IsNullOrEmpty(ville))
                {
                    unClient.Ville = ville;
                }

                Console.Write("Saisir le numéro de téléphone : ");
                string telephone = Console.ReadLine();
                if (!string.IsNullOrEmpty(telephone))
                {
                    unClient.Telephone = telephone;
                }

                var result = _dtoClient.Update(unClient);

                if (result != null)
                {
                    Console.WriteLine("\nLe client a bien été modifié :\n" + unClient);
                }
                else
                {
                    Console.WriteLine("\nLe client n'a pas pu être modifié.");
                }
            }
            else
            {
                Console.WriteLine("Aucun client trouvé");
            }
        }


        public void supprimeClient()
        {
            List<Client> clients = _dtoClient.GetAll();
            int index = 0;

            if (clients.Count > 0)
            {
                Console.WriteLine("\nChoisir le client à supprimer :");
                foreach (Client client in clients)
                {
                    index++;
                    Console.WriteLine(index + " - " + client);
                }

                Console.Write("\nSaisir le numéro du client : ");
                int choix = int.Parse(Console.ReadLine());

                Client unClient = clients[choix - 1];
                _dtoClient.Delete(unClient);

                Console.WriteLine("\nLe client a bien été supprimé : " + unClient);
            }
            else
            {
                Console.WriteLine("\nAucun client trouvé");
            }
        }

        public void afficherDetailClient()
        {
            Console.WriteLine("Choisir le client : ");

            List<Commande> commandes = _dtoCommande.GetAll();
            List<Client> clients = _dtoClient.GetAll();
            int index = 0;

            if (clients.Count > 0)
            {
                foreach (Client client in clients)
                {
                    index++;
                    Console.WriteLine(index + " - " + client);
                }

                Console.Write("\nSaisir le numéro du client : ");
                int choix = int.Parse(Console.ReadLine());

                Client unClient = clients[choix-1];

                if (commandes.Count > 0)
                {
                    foreach(var commande in commandes)
                    {
                        if(commande.UnClient.Id == unClient.Id)
                        {
                            Console.WriteLine(commande);
                        }
                    }
                }
                else
                {
                    Console.WriteLine("\nAucune commande trouver");
                }

            }
            else
            {
                Console.WriteLine("\nAucun client trouvé");
            }
        }

        public void creerCommande()
        {
            List<Client> clients = _dtoClient.GetAll();
            int index = 0;

            if (clients.Count > 0)
            {
                Console.WriteLine("Choisir le client pour la commande :");
                foreach (Client client in clients)
                {
                    Console.WriteLine(index + " - " + client);
                    index++;
                }

                Console.Write("Saisir le numéro du client : ");
                int choix = int.Parse(Console.ReadLine());

                Client unClient = clients[choix];

                Console.Write("Saisir la date de la commande (aaaa-mm-jj) : ");
                DateOnly date = DateOnly.Parse(Console.ReadLine());

                Console.Write("Saisir le total : ");
                int total = int.Parse(Console.ReadLine());

                Commande uneCommande = new Commande(unClient, date, total);
                var result = _dtoCommande.Save(uneCommande);

                if (result != null)
                {
                    Console.WriteLine("\nCommande créée : " + uneCommande);
                }
                else
                {
                    Console.WriteLine("\nLa commande n'a pas pus être créer.");
                }

            }
            else
            {
                Console.WriteLine("\nAucun client disponible pour créer une commande.");
            }
        }

        public void modifCommande()
        {
            Console.WriteLine("Choisir la commande à modifier : ");

            List<Commande> commandes = _dtoCommande.GetAll();
            int index = 0;

            if (commandes.Count > 0)
            {
                foreach (Commande commande in commandes)
                {
                    index++;
                    Console.WriteLine(index + " - " + commande);
                }

                Console.Write("\nSaisir le numéro de la commande : ");
                int choix = int.Parse(Console.ReadLine());

                Commande uneCommande = commandes[choix-1];

                Console.Write("Saisir la nouvelle date (aaaa-mm-jj) [" + uneCommande.UneDate + "] : ");
                string inputDate = Console.ReadLine();
                if (!string.IsNullOrEmpty(inputDate))
                {
                    uneCommande.UneDate = DateOnly.Parse(inputDate);
                }

                Console.Write("Saisir le nouveau total [" + uneCommande.Total + "] : ");
                string inputTotal = Console.ReadLine();
                if (!string.IsNullOrEmpty(inputTotal))
                {
                    uneCommande.Total = int.Parse(inputTotal);
                }

                _dtoCommande.Update(uneCommande);

                Console.WriteLine("\nLa commande a bien été modifiée :\n" + uneCommande);
            }
            else
            {
                Console.WriteLine("\nAucune commande trouvée.");
            }
        }

        public void supprimeCommande()
        {
            List<Commande> commandes = _dtoCommande.GetAll();
            int index = 0;

            if (commandes.Count > 0)
            {
                Console.WriteLine("\nChoisir la commande à supprimer :");
                foreach (Commande commande in commandes)
                {
                    index++;
                    Console.WriteLine(index + " - " + commande);
                }

                Console.Write("\nSaisir le numéro de la commande : ");
                int choix = int.Parse(Console.ReadLine());

                Commande uneCommande = commandes[choix - 1];
                _dtoCommande.Delete(uneCommande);

                Console.WriteLine("\nLa commande a bien été supprimée : " + uneCommande);
            }
            else
            {
                Console.WriteLine("\nAucune commande trouvée");
            }
        }

    }
}
