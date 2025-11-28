using GestionBibliotheque.Class;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestionBibliotheque.Dao
{
    internal class MembreDao : BaseDao<Membre>
    {
        public override List<Membre> GetAll()
        {
            List<Membre> membres = new List<Membre>();
            string request = "SELECT id, nom, prenom, Email, dateInscription FROM membre";

            using SqlConnection connection = DataConnection.GetConnection;
            connection.Open();

            using (SqlCommand cmd = new SqlCommand(request, connection))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Membre unMembre = new Membre(
                                reader.GetInt32(0),
                                reader.GetString(1),
                                reader.GetString(2),
                                reader.GetString(3),
                                DateOnly.FromDateTime(reader.GetDateTime(4))
                             );

                        membres.Add(unMembre);
                    }
                }
            }

            return membres;
        }

        public override Membre? getOneById(int id)
        {
            Membre? membre = null;

            request = "SELECT id, nom, prenom, Email, dateInscription FROM membre WHERE id=@id";

            using SqlConnection connection = DataConnection.GetConnection;
            using SqlCommand command = new SqlCommand(request, connection);

            command.Parameters.AddWithValue("@id", id);

            connection.Open();
            using SqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                membre = new Membre(
                                reader.GetInt32(0),
                                reader.GetString(1),
                                reader.GetString(2),
                                reader.GetString(3),
                                DateOnly.FromDateTime(reader.GetDateTime(4))
                             );
            }
            return membre;
        }

        public override Membre Save(Membre entity)
        {
            string request = "INSERT INTO membre (nom, prenom, Email, dateInscription )" +
                             "VALUES (@nom, @prenom, @Email, @dateInscription);";

            using SqlConnection connection = DataConnection.GetConnection;
            using SqlCommand cmd = new SqlCommand(request, connection);

            cmd.Parameters.AddWithValue("@nom", entity.Nom);
            cmd.Parameters.AddWithValue("@prenom", entity.Prenom);
            cmd.Parameters.AddWithValue("@Email", entity.Email);
            cmd.Parameters.AddWithValue("@dateInscription", entity.DateInscription.ToDateTime(TimeOnly.MinValue));

            connection.Open();
            object result = cmd.ExecuteScalar();

            entity.Id = Convert.ToInt32(result);
            return entity;
        }

        public override Membre Update(Membre entity)
        {
            string request = "UPDATE membre SET nom = @nom, prenom = @prenom, Email = @Email, dateInscription = @dateInscription " +
                             "WHERE id = @id";

            using SqlConnection connection = DataConnection.GetConnection;
            using SqlCommand cmd = new SqlCommand(request, connection);

            cmd.Parameters.AddWithValue("@id", entity.Id);
            cmd.Parameters.AddWithValue("@nom", entity.Nom);
            cmd.Parameters.AddWithValue("@prenom", entity.Prenom);
            cmd.Parameters.AddWithValue("@Email", entity.Email);
            cmd.Parameters.AddWithValue("@dateInscription", entity.DateInscription.ToDateTime(TimeOnly.MinValue));

            connection.Open();
            cmd.ExecuteNonQuery();

            return entity;
        }       
        
        public override Membre Delete(Membre entity)
        {
            string request = "DELETE FROM membre WHERE id = @id";

            using SqlConnection connection = DataConnection.GetConnection;
            using SqlCommand cmd = new SqlCommand(request, connection);

            cmd.Parameters.AddWithValue("@id", entity.Id);

            connection.Open();
            cmd.ExecuteNonQuery();

            return entity;
        }
    }
}
