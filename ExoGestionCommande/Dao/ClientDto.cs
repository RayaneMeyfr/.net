using ExoGestionCommande.Class;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExoGestionCommande.Dao
{
    internal class ClientDto : BaseDao<Client>
    {
        public override List<Client> GetAll()
        {
            List<Client> clients = new List<Client>();
            string request = "SELECT id, nom, prenom, adresse, codepostal, ville, telephone FROM client";

            using SqlConnection connection = DataConnection.GetConnection;
            connection.Open();

            using (SqlCommand cmd = new SqlCommand(request, connection))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Client unClient = new Client(
                                reader.GetInt32(0),
                                reader.GetString(1),
                                reader.GetString(2),
                                reader.GetString(3),
                                reader.GetString(4),
                                reader.GetString(5),
                                reader.GetString(6)
                             );

                        clients.Add(unClient);
                    }
                }
            }

            return clients;
        }

        public override Client? getOneById(int id)
        {
            Client? client = null;

            request = "SELECT id, nom, prenom, adresse, codepostal, ville, telephone FROM client WHERE id=@id";

            using SqlConnection connection = DataConnection.GetConnection;
            using SqlCommand command = new SqlCommand(request, connection);

            command.Parameters.AddWithValue("@id", id);

            connection.Open();
            using SqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                client = new Client(
                                    reader.GetInt32(0), 
                                    reader.GetString(1), 
                                    reader.GetString(2), 
                                    reader.GetString(3),
                                    reader.GetString(4),
                                    reader.GetString(5),
                                    reader.GetString(6)
                                );
            }
            return client;
        }

        public override Client Save(Client entity)
        {
            string request = "INSERT INTO client (nom, prenom, adresse, codepostal, ville, telephone)" +
                             "VALUES (@nom, @prenom, @adresse, @codepostal, @ville, @telephone);";

            using SqlConnection connection = DataConnection.GetConnection;
            using SqlCommand cmd = new SqlCommand(request, connection);

            cmd.Parameters.AddWithValue("@nom", entity.Nom);
            cmd.Parameters.AddWithValue("@prenom", entity.Prenom);
            cmd.Parameters.AddWithValue("@adresse", entity.Adresse);
            cmd.Parameters.AddWithValue("@codepostal", entity.CodePostal);
            cmd.Parameters.AddWithValue("@ville", entity.Ville);
            cmd.Parameters.AddWithValue("@telephone", entity.Telephone);

            connection.Open();
            object result = cmd.ExecuteScalar();

            entity.Id = Convert.ToInt32(result);
            return entity;
        }

        public override Client Update(Client entity)
        {
            string request = "UPDATE client SET nom = @nom, prenom = @prenom, adresse = @adresse," +
                             "codepostal = @codepostal, ville = @ville, telephone = @telephone " +
                             "WHERE id = @id";

            using SqlConnection connection = DataConnection.GetConnection;
            using SqlCommand cmd = new SqlCommand(request, connection);

            cmd.Parameters.AddWithValue("@id", entity.Id);
            cmd.Parameters.AddWithValue("@nom", entity.Nom);
            cmd.Parameters.AddWithValue("@prenom", entity.Prenom);
            cmd.Parameters.AddWithValue("@adresse", entity.Adresse);
            cmd.Parameters.AddWithValue("@codepostal", entity.CodePostal);
            cmd.Parameters.AddWithValue("@ville", entity.Ville);
            cmd.Parameters.AddWithValue("@telephone", entity.Telephone);

            connection.Open();
            cmd.ExecuteNonQuery();

            return entity;
        }

        public override Client Delete(Client entity)
        {
            string request = "DELETE FROM client WHERE id = @id";

            using SqlConnection connection = DataConnection.GetConnection;
            using SqlCommand cmd = new SqlCommand(request, connection);

            cmd.Parameters.AddWithValue("@id", entity.Id);

            connection.Open();
            cmd.ExecuteNonQuery();

            return entity;
        }
    }
}
