using Recurso.BulkInsert.Sample.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Recurso.BulkInsert.Sample.Common.Interfaces
{
    public interface IBusinessLogic
    {
        Task<int> InsertUsingStoredProcedure(string fileName, int numberOfRecords);
        Task InsertUsingBulkInsert(string fileName, int numberOfRecords);
    }
}