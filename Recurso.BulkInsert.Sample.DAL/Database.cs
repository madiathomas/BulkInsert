using Microsoft.Extensions.Configuration;
using Recurso.BulkInsert.Sample.Common;
using Recurso.BulkInsert.Sample.Common.Interfaces;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Recurso.BulkInsert.Sample.DAL
{
    public class Database : IDatabase
    {
        readonly IDbConnectionFactory _dbConnectionFactory;
        readonly IBulkInsert _bulkInsert;

        public Database(IDbConnectionFactory dbConnectionFactory, IBulkInsert bulkInsert)
        {
            _dbConnectionFactory = dbConnectionFactory;
            _bulkInsert = bulkInsert;
        }

        public async Task InsertUsingStoredProcedure(List<Person> people)
        {
            // Insert data
            foreach (var person in people)
            {
                await InsertPerson(person);
            }
        }

        public async Task InsertPerson(Person person)
        {
            using SqlConnection connection = _dbConnectionFactory.CreateConnection() as SqlConnection;
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

        public async Task InsertUsingBulkInsert(List<Person> people)
        {
            await _bulkInsert.Save<Person>(people);
        }
    }
}
