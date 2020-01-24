using Recurso.BulkInsert.Sample.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Recurso.BulkInsert.Sample.Common.Interfaces
{
    public interface IBusinessLogic
    {
        Task<List<Person>> GetPeople(string fileName);
        Task InsertUsingBulkInsert(List<Person> people);
        int InsertUsingStoredProcedure(List<Person> people);
    }
}