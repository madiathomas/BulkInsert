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
        // Run CreatePeopleDatabase.sql, which is under Recurso.BulkInsert.Sample.DAL project, to create the database and table required for this sample
        static IBusinessLogic businessLogic;

        static async Task Main()
        {
            var container = ContainerConfiguration.Configure();

            using (var scope = container.BeginLifetimeScope())
            {
                var app = scope.Resolve<IApplication>();
                await app.Run();
            }
        }
    }
}
