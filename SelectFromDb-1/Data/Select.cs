using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using SelectFromDb.DbModels;

namespace SelectFromDb.Data
{
   public class Select<TDbModel> where TDbModel : new() //ctor med blanke felter
    {
     
        private PropertyInfo[] _properties;
        private Type _dbModelType;

        public Select()
        {
            var dbModelType = typeof(TDbModel);
            _properties = dbModelType.GetProperties();
        }


        public TDbModel GetStudent(SqlConnection connection, int id)
        {
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "Select Id, Navn From Student Where Id = @id";
                command.Parameters.AddWithValue("id", id);
                return ReadToList(command).FirstOrDefault();
            }

        }

        public List<TDbModel> GetAllStudent(SqlConnection connection)
        {

            using (var command = connection.CreateCommand())
            {
                command.CommandText = "Select Id, Navn From Student";
                return ReadToList(command);
            }

        }

        private List<TDbModel> ReadToList(SqlCommand command)
        {
            var list = new List<TDbModel>();
            using (var reader = command.ExecuteReader())
            {

                while (reader.Read())
                {
                    var rowEntity = new TDbModel();
                    ReadAllFields(reader, rowEntity);
                    list.Add(rowEntity);
                }

            }
            return list;
        }

        private void ReadAllFields(SqlDataReader reader, TDbModel rowEntity)
        {
            foreach (var property in _properties)
            {
                //property.Name
                property.SetValue(rowEntity, reader[property.Name]);
                
            }
        }


    }
}


