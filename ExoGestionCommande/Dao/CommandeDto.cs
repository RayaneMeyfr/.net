using ExoGestionCommande.Class;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExoGestionCommande.Dao
{
    internal class CommandeDto : BaseDao<Commande>
    {
        public override List<Commande> GetAll()
        {
            List<Commande> commandes = new List<Commande>();
            ClientDto clientDto = new ClientDto();

            string request = "SELECT id, clientid, datecommande, total FROM commandes";

            using SqlConnection connection = DataConnection.GetConnection;
            connection.Open();

            using (SqlCommand cmd = new SqlCommand(request, connection))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Client unClient = clientDto.getOneById(reader.GetInt32(1));
                        
                        Commande uneCommande = new Commande(
                            reader.GetInt32(0),   
                            unClient,            
                            DateOnly.FromDateTime(reader.GetDateTime(2)),
                            Convert.ToInt32(reader.GetDecimal(3))
                        );

                        commandes.Add(uneCommande);
                    }
                }
            }

            return commandes;
        }

        public override Commande? getOneById(int id)
        {
            Commande? commande = null;

            request = "SELECT id, clientid, datecommande, total FROM commandes WHERE id=@id";
            ClientDto clientDto = new ClientDto();

            using SqlConnection connection = DataConnection.GetConnection;
            using SqlCommand command = new SqlCommand(request, connection);

            command.Parameters.AddWithValue("@id", id);

            connection.Open();
            using SqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                Client unClient = clientDto.getOneById(reader.GetInt32(1));

                commande = new Commande(
                    reader.GetInt32(0),
                    unClient,
                    DateOnly.FromDateTime(reader.GetDateTime(2)),
                    Convert.ToInt32(reader.GetDecimal(3))
                );
            }
            return commande;
        }

        public override Commande Save(Commande entity)
        {
            string request = "INSERT INTO commandes (clientid, datecommande, total) OUTPUT INSERTED.id " +
                             "VALUES (@clientid, @date, @total);";

            using SqlConnection connection = DataConnection.GetConnection;
            using SqlCommand cmd = new SqlCommand(request, connection);

            cmd.Parameters.AddWithValue("@clientid", entity.UnClient.Id);
            cmd.Parameters.AddWithValue("@date", entity.UneDate.ToDateTime(TimeOnly.MinValue));
            cmd.Parameters.AddWithValue("@total", entity.Total);

            connection.Open();
            entity.Id = Convert.ToInt32(cmd.ExecuteScalar());

            return entity;
        }


        public override Commande Update(Commande entity)
        {
            string request = "UPDATE commandes SET clientid = @clientid, datecommande = @date, total = @total " +
                             "WHERE id = @id";

            using SqlConnection connection = DataConnection.GetConnection;
            using SqlCommand cmd = new SqlCommand(request, connection);

            cmd.Parameters.AddWithValue("@id", entity.Id);
            cmd.Parameters.AddWithValue("@clientid", entity.UnClient.Id);
            cmd.Parameters.AddWithValue("@date", entity.UneDate.ToDateTime(TimeOnly.MinValue));
            cmd.Parameters.AddWithValue("@total", entity.Total);

            connection.Open();
            cmd.ExecuteNonQuery();

            return entity;
        }

        public override Commande Delete(Commande entity)
        {
            string request = "DELETE FROM commandes WHERE id = @id";

            using SqlConnection connection = DataConnection.GetConnection;
            using SqlCommand cmd = new SqlCommand(request, connection);

            cmd.Parameters.AddWithValue("@id", entity.Id);

            connection.Open();
            cmd.ExecuteNonQuery();

            return entity;
        }
    }
}
