using Recurso.BulkInsert.Sample.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Recurso.BulkInsert.Sample.Common.Interfaces
{
    public interface ICSVFile
    {
        Task<List<Person>> GetPeople(string fileName, int numberOfRecords);
    }
}
