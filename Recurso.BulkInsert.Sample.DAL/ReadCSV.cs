using Recurso.BulkInsert.Sample.Common.Interfaces;
using System.IO;
using System.Threading.Tasks;

namespace Recurso.BulkInsert.Sample.DAL
{
    public class ReadCSV : IReadCSV
    {
        public async Task<string[]> GetCSVLines(string path)
        {
            return await File.ReadAllLinesAsync(path);
        }
    }
}
