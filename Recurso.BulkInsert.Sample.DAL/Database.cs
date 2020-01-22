using Microsoft.Extensions.Configuration;
using Recurso.BulkInsert.Sample.Common;
using Recurso.BulkInsert.Sample.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Recurso.BulkInsert.Sample.DAL
{
    public class Database : IDatabase
    {
        readonly IDbConnectionFactory _dbConnectionFactory;

        public Database(IDbConnectionFactory dbConnectionFactory)
        {
            _dbConnectionFactory = dbConnectionFactory;
        }

        public async Task<int> InsertUsingStoredProcedure(List<Person> people)
        {
            // Insert data
            foreach (var person in people)
            {
                InsertPerson(person);
            }

            return people.Count;
        }

        private void InsertPerson(Person person)
        {
            using IDbConnection connection = _dbConnectionFactory.CreateConnection();
            connection.Open();

            using IDbCommand command = connection.CreateCommand();
            command.CommandText = "prc_InsertPerson";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            // Add properties and their values
            foreach(var prop in typeof(Person).GetProperties())
            {
                var parameter = command.CreateParameter();
                parameter.ParameterName = prop.Name;
                parameter.Value = prop.GetValue(person) ?? DBNull.Value;

                command.Parameters.Add(parameter);
            }

            command.ExecuteScalar();
        }
    }
}
