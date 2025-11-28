using GestionBibliotheque.Class;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestionBibliotheque.Dao
{
    internal class EmpruntDao : BaseDao<Emprunt>
    {
        

        public override List<Emprunt> GetAll()
        {
            List<Emprunt> emprunts = new List<Emprunt>();
            LivreDao livreDao = new LivreDao();
            MembreDao membreDao = new MembreDao();

            string request = "SELECT id, livreId, membreId, dateEmprunt, dateRetour FROM emprunt";

            using SqlConnection connection = DataConnection.GetConnection;
            connection.Open();

            using (SqlCommand cmd = new SqlCommand(request, connection))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Livre unLivre = livreDao.getOneById(1);
                        Membre unMembre = membreDao.getOneById(2);
                        Emprunt unEmprunt;

                        if (reader.IsDBNull(4))
                        {
                             unEmprunt = new Emprunt(
                                reader.GetInt32(0),
                                unLivre,
                                unMembre,
                                DateOnly.FromDateTime(reader.GetDateTime(3))
                            );
                        }
                        else
                        {
                            unEmprunt = new Emprunt(
                                reader.GetInt32(0),
                                unLivre,
                                unMembre,
                                DateOnly.FromDateTime(reader.GetDateTime(3)),
                                DateOnly.FromDateTime(reader.GetDateTime(4))
                            );
                        }
                        emprunts.Add(unEmprunt);
                    }
                }
            }

            return emprunts;
        }

        public override Emprunt? getOneById(int id)
        {
            Emprunt? emprunt = null;

            LivreDao livreDao = new LivreDao();
            MembreDao membreDao = new MembreDao();

            string request = "SELECT id, livreId, membreId, dateEmprunt, dateRetour FROM emprunt WHERE id = @id";

            using SqlConnection connection = DataConnection.GetConnection;
            connection.Open();

            using SqlCommand cmd = new SqlCommand(request, connection);
            cmd.Parameters.AddWithValue("@id", id);

            using SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                Livre unLivre = livreDao.getOneById(1);
                Membre unMembre = membreDao.getOneById(2);

                if (reader.IsDBNull(4))
                {
                    emprunt = new Emprunt(
                       reader.GetInt32(0),
                       unLivre,
                       unMembre,
                       DateOnly.FromDateTime(reader.GetDateTime(3))
                   );
                }
                else
                {
                    emprunt = new Emprunt(
                        reader.GetInt32(0),
                        unLivre,
                        unMembre,
                        DateOnly.FromDateTime(reader.GetDateTime(3)),
                        DateOnly.FromDateTime(reader.GetDateTime(4))
                    );
                }
            }

            return emprunt;
        }

        public override Emprunt Save(Emprunt entity)
        {
            string request = "INSERT INTO emprunt (livreId, membreId, dateEmprunt, dateRetour) "+
                               "VALUES (@livreId, @membreId, @dateEmprunt, @dateRetour); "+
                               "SELECT SCOPE_IDENTITY();";

            using SqlConnection connection = DataConnection.GetConnection;
            using SqlCommand cmd = new SqlCommand(request, connection);

            cmd.Parameters.AddWithValue("@livreId", entity.UnLivre.Id);
            cmd.Parameters.AddWithValue("@membreId", entity.UnMembre.Id);
            cmd.Parameters.AddWithValue("@dateEmprunt", entity.DateEmprunt.ToDateTime(TimeOnly.MinValue));
            cmd.Parameters.AddWithValue("@dateRetour", entity.DateRetour.HasValue ? entity.DateRetour.Value.ToDateTime(TimeOnly.MinValue)
                                                       : (object)DBNull.Value);

            connection.Open();
            object result = cmd.ExecuteScalar();
            entity.Id = Convert.ToInt32(result);

            return entity;
        }

        public override Emprunt Update(Emprunt entity)
        {
            string request = "UPDATE emprunt SET livreId = @livreId, membreId = @membreId, dateEmprunt = @dateEmprunt, "+
                             "dateRetour = @dateRetour " +
                             "WHERE id = @id";

            using SqlConnection connection = DataConnection.GetConnection;
            using SqlCommand cmd = new SqlCommand(request, connection);

            cmd.Parameters.AddWithValue("@id", entity.Id);
            cmd.Parameters.AddWithValue("@livreId", entity.UnLivre.Id);
            cmd.Parameters.AddWithValue("@membreId", entity.UnMembre.Id);
            cmd.Parameters.AddWithValue("@dateEmprunt", entity.DateEmprunt.ToDateTime(TimeOnly.MinValue));
            cmd.Parameters.AddWithValue("@dateRetour", entity.DateRetour.HasValue ? entity.DateRetour.Value.ToDateTime(TimeOnly.MinValue)
                                                       : (object)DBNull.Value);

            connection.Open();
            cmd.ExecuteNonQuery();

            return entity;
        }

        public override Emprunt Delete(Emprunt entity)
        {
            string request = "DELETE FROM emprunt WHERE id = @id";

            using SqlConnection connection = DataConnection.GetConnection;
            using SqlCommand cmd = new SqlCommand(request, connection);
            cmd.Parameters.AddWithValue("@id", entity.Id);

            connection.Open();
            cmd.ExecuteNonQuery();

            return entity;
        }
    }
}
