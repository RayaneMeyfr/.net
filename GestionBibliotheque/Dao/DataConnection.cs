using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestionBibliotheque.Dao
{
    internal class DataConnection
    {
        private static readonly string connectionString = "Data Source=(localdb)\\baseEtudiant;Integrated Security=True";

        public static SqlConnection GetConnection => new(connectionString);
    }
}

