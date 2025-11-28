using GestionBibliotheque.Class;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestionBibliotheque.Dao
{
    internal class LivreDao : BaseDao<Livre>
    {
        public override List<Livre> GetAll()
        {
            List<Livre> livres = new List<Livre>();
            string request = "SELECT id, titre, auteur, isbn, anneePublication, estDisponible FROM livre";

            using SqlConnection connection = DataConnection.GetConnection;
            connection.Open();

            using (SqlCommand cmd = new SqlCommand(request, connection))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Livre unLivre = new Livre(
                                reader.GetInt32(0),
                                reader.GetString(1),
                                reader.GetString(2),
                                reader.GetString(3),
                                reader.GetInt32(4),
                                reader.GetBoolean(5)
                             );

                        livres.Add(unLivre);
                    }
                }
            }

            return livres;
        }

        public override Livre? getOneById(int id)
        {
            Livre? livre = null;

            request = "SELECT id, titre, auteur, isbn, anneePublication, estDisponible FROM livre WHERE id=@id";

            using SqlConnection connection = DataConnection.GetConnection;
            using SqlCommand command = new SqlCommand(request, connection);

            command.Parameters.AddWithValue("@id", id);

            connection.Open();
            using SqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                livre = new Livre(
                                reader.GetInt32(0),
                                reader.GetString(1),
                                reader.GetString(2),
                                reader.GetString(3),
                                reader.GetInt32(4),
                                reader.GetBoolean(5)
                             );
            }
            return livre;
        }

        public override Livre Save(Livre entity)
        {
            string request = "INSERT INTO livre (titre, auteur, isbn, anneePublication, estDisponible)" +
                             "VALUES (@titre, @auteur, @isbn, @anneePublication, @estDisponible);";

            using SqlConnection connection = DataConnection.GetConnection;
            using SqlCommand cmd = new SqlCommand(request, connection);

            cmd.Parameters.AddWithValue("@titre", entity.Titre);
            cmd.Parameters.AddWithValue("@auteur", entity.Auteur);
            cmd.Parameters.AddWithValue("@isbn", entity.Isbn);
            cmd.Parameters.AddWithValue("@anneePublication", entity.AnneePublication);
            cmd.Parameters.AddWithValue("@estDisponible", entity.EstDisponible);

            connection.Open();
            object result = cmd.ExecuteScalar();

            entity.Id = Convert.ToInt32(result);
            return entity;
        }

        public override Livre Update(Livre entity)
        {
            string request = "UPDATE livre SET titre = @titre, auteur = @auteur, isbn = @isbn," +
                             "anneePublication = @anneePublication, estDisponible = @estDisponible " +
                             "WHERE id = @id";

            using SqlConnection connection = DataConnection.GetConnection;
            using SqlCommand cmd = new SqlCommand(request, connection);

            cmd.Parameters.AddWithValue("@id", entity.Id);
            cmd.Parameters.AddWithValue("@titre", entity.Titre);
            cmd.Parameters.AddWithValue("@auteur", entity.Auteur);
            cmd.Parameters.AddWithValue("@isbn", entity.Isbn);
            cmd.Parameters.AddWithValue("@anneePublication", entity.AnneePublication);
            cmd.Parameters.AddWithValue("@estDisponible", entity.EstDisponible);

            connection.Open();
            cmd.ExecuteNonQuery();

            return entity;
        }

        public override Livre Delete(Livre entity)
        {
            string request = "DELETE FROM livre WHERE id = @id";

            using SqlConnection connection = DataConnection.GetConnection;
            using SqlCommand cmd = new SqlCommand(request, connection);

            cmd.Parameters.AddWithValue("@id", entity.Id);

            connection.Open();
            cmd.ExecuteNonQuery();

            return entity;
        }
    }
}
