using System.Collections.Generic;
using System.Threading.Tasks;

namespace Recurso.BulkInsert.Sample.Common.Interfaces
{
    public interface IDatabase
    {
        Task InsertUsingStoredProcedure(List<Person> people);
    }
}