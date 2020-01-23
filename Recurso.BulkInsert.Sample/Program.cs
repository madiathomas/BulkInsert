using Autofac;
using Recurso.BulkInsert.Sample.Common;
using Recurso.BulkInsert.Sample.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Recurso.BulkInsert.Sample.BLL;
using Microsoft.Extensions.Configuration;

namespace Recurso.BulkInsert.Sample
{
    class Program
    {
        static async Task Main()
        {
            var container = ContainerConfiguration.Configure();

            using var scope = container.BeginLifetimeScope();
            var app = scope.Resolve<IApplication>();
            await app.Run();
        }
    }
}
