using System;
using System.Configuration;
using System.Data.SqlClient;
using SelectFromDb.Data;

namespace SelectFromDb
{
    class Program
    {
        static string ConnectionString => ConfigurationManager.ConnectionStrings["TestDb"].ConnectionString;

        static void Main(string[] args)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                RunDemo(connection);
                Console.ReadKey();
            }
        }

        private static void RunDemo(SqlConnection connection)
        {
            var selectStudent = new SelectStudent();
            Console.WriteLine("Kjører GetStudent");
            Console.WriteLine(selectStudent.GetStudent(connection, 2));
            Console.WriteLine("Kjører GetAllStudents");
            var allStudents = selectStudent.GetAllStudent(connection);
            foreach (var student in allStudents)
            {
                Console.WriteLine(student);
            }
            
        }
    }
}
