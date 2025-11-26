using ExoBdd.Class;
using Microsoft.Data.SqlClient;
using System.Data;

string connectionString = "Data Source=(localdb)\\baseEtudiant;Integrated Security=True;Encrypt=True";
var connection = new SqlConnection(connectionString);
connection.Open();

if (connection.State == ConnectionState.Open)
{
    Console.WriteLine("La connexion est ouverte !");
    Etudiant unEtudiant = Etudiant.GetById(connection, 1);

    if(unEtudiant != null)
    {
        unEtudiant.affficher();

        unEtudiant.Nom = "Rayane";
        unEtudiant.Prenom = "Meyfroot";

        Etudiant.EditEtudiant(connection,unEtudiant);

        List<Etudiant> etudiants = Etudiant.GetEtudiants(connection);

        if (etudiants.Count > 0)
        {
            foreach (Etudiant e in etudiants)
            {
                e.affficher();
            }
        }
    }

    

}
else
{
    Console.WriteLine("Problème de connexion !");
}

connection.Close();

