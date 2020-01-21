using System.Collections.Generic;
using System.Threading.Tasks;

namespace Recurso.BulkInsert.Sample.Common.Interfaces
{
    public interface IDatabase
    {
        Task<int> InsertUsingStoredProcedure(List<Person> people);

    }
}