using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Recurso.BulkInsert.Sample.Common.Interfaces
{
    public interface IQuickInsert
    {
        Task<long> InsertUsingBulkInsert(List<Person> people);

        Task<long> InsertUsingBulkInsert(DataTable dataTable);
    }
}