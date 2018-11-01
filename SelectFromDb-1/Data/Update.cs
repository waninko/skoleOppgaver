using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SelectFromDb.Data
{
   public class Update<TDbModel> where TDbModel : new()
    {
        private PropertyInfo[] _properties;
        private Type _dbModelType;

        public Update()
        {
            var dbModelType = typeof(TDbModel);
            _properties = dbModelType.GetProperties();
        }

        public TDbModel UpdateStudent(SqlConnection connection, string navn)
        {
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "UPDATE Student SET (Navn) = @navn WHERE @navn";
                command.Parameters.AddWithValue("navn", navn);
            }

        }
    }
}
