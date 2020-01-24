using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Recurso.BulkInsert.Sample.Common.Interfaces
{
    public interface IReadCSV
    {
        Task<string[]> GetCSVLines(string path);
    }
}
