using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SelectFromDb.Data
{
   public class Insert<TDbModel> where TDbModel : new()
    {
        private PropertyInfo[] _properties;
        private Type _dbModelType;

        public Insert()
        {
             var dbModelType = typeof(TDbModel);
            _properties = dbModelType.GetProperties();
        }


        public TDbModel InsertStudent(SqlConnection connection, string navn)
        {
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "INSERT INTO Student (Navn) VALUES (@navn) ";
                command.Parameters.AddWithValue("navn", navn);
               // return AddToList(command).FirstOrDefault();
            }

        }

      

    }
}
