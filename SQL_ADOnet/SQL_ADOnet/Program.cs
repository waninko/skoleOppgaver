using System;
using System.Configuration;
using System.Data.SqlClient;

namespace SQL_ADOnet
{
    class Program
    {
        static void Main(string[] args)
        {   //ADO.NET
            var connectionString = ConfigurationManager.ConnectionStrings["sKursDB"].ConnectionString;
           using(var connection = new SqlConnection(connectionString))
            { 
               connection.Open();
            var command = connection.CreateCommand();
            command.CommandText = " SELECT ID, Navn FROM Student";
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                Console.Write("reader[0] = " + reader[0]+ " ");
                Console.Write("reader[1] = " + reader[1] + " ");
                Console.Write("reader[\"Id\"] = " + reader["Id"] + " ");
                Console.Write("reader[\"Navn\"] = " + reader["Navn"] + " ");
                Console.WriteLine();
              }
            }
          
            Console.ReadLine();
        }
    }
}
