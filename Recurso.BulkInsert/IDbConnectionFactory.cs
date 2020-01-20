using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Recurso.BulkInsert
{
    public interface IDbConnectionFactory
    {
        IDbConnection CreateConnection();
    }
}
