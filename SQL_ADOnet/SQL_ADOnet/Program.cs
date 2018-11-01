using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Dynamic;

namespace SQL_ADOnet
{
    class Program
    {
        static void Main(string[] args)
        {   //ADO.NET
            

            using (var connection = new SqlConnection(GetConnectionString()))
            {
                connection.Open();
                Select(connection, 3,  " ");
                /*Insert(connection);
                Select(connection, "etter insert");
                Update(connection);
                Select(connection, "Etter Update");
                Delete(connection);
                Select(connection, "etter delete");
                SelectRowCount(connection);*/
            }
          
            Console.ReadLine();
        }

        private static void Insert (SqlConnection connection)
        {
            using (var command = connection.CreateCommand())
            {
                command.CommandText = " INSERT INTO Student (Navn) VALUES ('MesterT')";
                var rowsAffected = command.ExecuteNonQuery();
                Console.WriteLine("rowsAffected = " + rowsAffected);
            }
        }

        private static void Update (SqlConnection connection)
        {
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "UPDATE Student SET Navn = 'Tøff' WHERE Navn = 'MesterT'";
                var rowsAffected = command.ExecuteNonQuery();
                Console.WriteLine("rowsAffected = " + rowsAffected);
            }
        }
        private static void Delete (SqlConnection connection)
        {
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "DELETE FROM Student WHERE Navn = 'Tøff'";
                var rowsAffected = command.ExecuteNonQuery();
                Console.WriteLine("rowsAffected = " + rowsAffected);
            }
        }
        private static void Select(SqlConnection connection, int id, string label)
        {
            using (var command = connection.CreateCommand())
            {
                command.CommandText = " SELECT ID, Navn FROM Student WHERE ID =  @id";
                command.Parameters.AddWithValue("id", id);
                using (var reader = command.ExecuteReader())
                {
                    Console.WriteLine("SELECT ->" + label);
                    while (reader.Read())
                    {
                        //dette er en SELECT//
                        Console.Write("Id =" + reader["Id"] + " Navn=" + reader["Navn"]);
                        Console.WriteLine();
                    }
                }
            }
        }

        private static void Select(SqlConnection connection, string label)
        {
            using (var command = connection.CreateCommand())
            {
                command.CommandText = " SELECT ID, Navn FROM Student";
                using (var reader = command.ExecuteReader()) 
                {
                    Console.WriteLine("SELECT ->" + label);
                    while (reader.Read())
                    {
                        //dette er en SELECT//
                        Console.Write("Id =" + reader["Id"] + " Navn=" + reader["Navn"]);
                        Console.WriteLine();
                    }
                }
            }
        }

        private static void SelectRowCount(SqlConnection connection)
        {
            using (var command = connection.CreateCommand())
            {
                command.CommandText = " SELECT count(ID) FROM Student";
                var rowCount = command.ExecuteScalar();
                Console.WriteLine("rowCount = " + rowCount);
               
               
            }
        }

        private static string GetConnectionString()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["sKursDB"].ConnectionString;
            return connectionString;
        }
    }
}
