using Recurso.BulkInsert.Sample.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Recurso.BulkInsert.Sample.Common.Interfaces
{
    public interface ICSVFile
    {
        List<Person> GetPeople(string fileName);
    }
}
