using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExoBdd.Class
{
    internal class Etudiant
    {
        private int _id;
        private string _nom;
        private string _prenom;
        private Classe _numeroClasse;
        private DateTime _dateDiplome;


        public Etudiant(int id, string nom, string prenom, Classe numeroClasse, DateTime dateDiplome)
        {
            _id = id;
            _nom = nom;
            _prenom = prenom;
            _numeroClasse = numeroClasse;
            _dateDiplome = dateDiplome;
        }

        public void affficher()
        {
            Console.WriteLine("Id etudiant : "+_id);
            Console.WriteLine("Nom etudiant : "+_nom);
            Console.WriteLine("Prenom etudiant : "+_prenom);
            _numeroClasse.afficher();
            Console.WriteLine("Date diplome etudiant : "+_dateDiplome+"\n");
        }

        //bool Save()
        //bool Delete()

        public static List<Etudiant> GetEtudiants(SqlConnection conn)
        {
            List<Etudiant> etudiants = new List<Etudiant>();

            string request = "SELECT e.Id, e.Nom, e.Prenom, e.NumeroClasse, e.DateDiplome, c.Id AS ClasseId, c.Nom AS ClasseNom FROM Etudiant e JOIN Classe c ON e.NumeroClasse = c.Id";
            
            using (SqlCommand cmd = new SqlCommand(request, conn))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Classe classe = new Classe(
                            reader.GetInt32(reader.GetOrdinal("ClasseId")),
                            reader.GetString(reader.GetOrdinal("ClasseNom"))
                        );

                        Etudiant e = new Etudiant(
                            reader.GetInt32(reader.GetOrdinal("Id")),
                            reader.GetString(reader.GetOrdinal("Nom")),
                            reader.GetString(reader.GetOrdinal("Prenom")),
                            classe,
                            reader.GetDateTime(reader.GetOrdinal("DateDiplome"))
                        );

                        etudiants.Add(e);
                    }
                }
            }

            return etudiants;
        }

        public static Etudiant GetById(SqlConnection conn, int id)
        {
            Etudiant etudiant = null;

            string request = "SELECT e.Id, e.Nom, e.Prenom, e.NumeroClasse, e.DateDiplome, c.Id AS ClasseId, c.Nom AS ClasseNom FROM Etudiant e JOIN Classe c ON e.NumeroClasse = c.Id WHERE e.Id = @id";

            using (SqlCommand cmd = new SqlCommand(request, conn))
            {
                cmd.Parameters.AddWithValue("@id", id);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        Classe classe = new Classe(
                            reader.GetInt32(reader.GetOrdinal("ClasseId")),
                            reader.GetString(reader.GetOrdinal("ClasseNom"))
                        );

                        etudiant = new Etudiant(
                            reader.GetInt32(reader.GetOrdinal("Id")),
                            reader.GetString(reader.GetOrdinal("Nom")),
                            reader.GetString(reader.GetOrdinal("Prenom")),
                            classe,
                            reader.GetDateTime(reader.GetOrdinal("DateDiplome"))
                        );
                    }
                }
            }

            return etudiant;
        }


        public static bool EditEtudiant(SqlConnection conn, Etudiant updatedEtudiant)
        {
            string request = "UPDATE Etudiant SET Nom = @Nom, Prenom = @Prenom, NumeroClasse = @NumeroClasse, DateDiplome = @DateDiplome WHERE Id = @Id";

            using (SqlCommand cmd = new SqlCommand(request, conn))
            {
                cmd.Parameters.AddWithValue("@Nom", updatedEtudiant.Nom);
                cmd.Parameters.AddWithValue("@Prenom", updatedEtudiant.Prenom);
                cmd.Parameters.AddWithValue("@NumeroClasse", updatedEtudiant.NumeroClasse?.Id);
                cmd.Parameters.AddWithValue("@DateDiplome", updatedEtudiant.DateDiplome);
                cmd.Parameters.AddWithValue("@Id", updatedEtudiant.Id);

                int rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected > 0; 
            }
        }


        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Nom
        {
            get { return _nom; }
            set { _nom = value; }
        }

        public string Prenom
        {
            get { return _prenom; }
            set { _prenom = value; }
        }

        public Classe NumeroClasse
        {
            get { return _numeroClasse; }
            set { _numeroClasse = value; }
        }

        public DateTime DateDiplome
        {
            get { return _dateDiplome; }
            set { _dateDiplome = value; }
        }
    }
}
