using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace Recurso.BulkInsert.Sample
{
    public class Database
    {
        public Database(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public string ConnectionString { get; }

        public async Task InsertPerson(Person person)
        {
            using SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();

            using SqlCommand sqlCommand = new SqlCommand("prc_InsertPerson", connection)
            {
                CommandType = System.Data.CommandType.StoredProcedure
            };

            sqlCommand.Parameters.AddWithValue("@FirstName", person.MaritalStatus);
            sqlCommand.Parameters.AddWithValue("@LastName", person.MaritalStatus);
            sqlCommand.Parameters.AddWithValue("@Gender", person.MaritalStatus);
            sqlCommand.Parameters.AddWithValue("@Age", person.MaritalStatus);
            sqlCommand.Parameters.AddWithValue("@Email", person.MaritalStatus);
            sqlCommand.Parameters.AddWithValue("@Phone", person.MaritalStatus);
            sqlCommand.Parameters.AddWithValue("@Education", person.MaritalStatus);
            sqlCommand.Parameters.AddWithValue("@Occupation", person.MaritalStatus);
            sqlCommand.Parameters.AddWithValue("@Experience", person.MaritalStatus);
            sqlCommand.Parameters.AddWithValue("@MaritalStatus", person.MaritalStatus);

            await sqlCommand.ExecuteScalarAsync();
        }
    }
}
