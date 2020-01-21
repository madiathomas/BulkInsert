using System.Data;

namespace Recurso.BulkInsert.Sample.DAL
{
    internal static class DbCommandExtensionMethods
    {
        public static void AddParameter(this IDbCommand command, string name, object value)
        {
            var parameter = command.CreateParameter();
            parameter.ParameterName = name;
            parameter.Value = value;
            command.Parameters.Add(parameter);
        }
    }
}
