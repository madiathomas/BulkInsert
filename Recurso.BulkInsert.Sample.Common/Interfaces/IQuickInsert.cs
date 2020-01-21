using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Recurso.BulkInsert.Sample.Common.Interfaces
{
    public interface IQuickInsert
    {
        Task<int> InsertUsingBulkInsert(List<Person> people);

        Task<int> InsertUsingBulkInsert(DataTable dataTable);
    }
}