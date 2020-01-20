using Recurso.BulkInsert.Sample.Common;
using Recurso.BulkInsert.Sample.Common.Interfaces;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Recurso.BulkInsert.Sample.DAL
{
    public class Database : IDatabase
    {
        public IDbConnectionFactory _dbConnectionFactory { get; set; }
        public string ConnectionString { get; set; }

        public Database(IDbConnectionFactory dbConnectionFactory)
        {
            _dbConnectionFactory = dbConnectionFactory;
        }

        public async Task InsertUsingStoredProcedure(List<Person> people)
        {
            // Insert data
            foreach (var person in people)
            {
                await InsertPerson(person);
            }
        }

        private async Task InsertPerson(Person person)
        {
            using SqlConnection connection = _dbConnectionFactory.CreateConnection(ConnectionString) as SqlConnection;
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
