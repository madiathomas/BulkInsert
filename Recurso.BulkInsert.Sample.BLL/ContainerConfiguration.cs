using Autofac;
using Microsoft.Extensions.Configuration;
using Recurso.BulkInsert.Sample.Common.Interfaces;
using Recurso.BulkInsert.Sample.DAL;
using System.Data;
using System.Data.Common;

namespace Recurso.BulkInsert.Sample.BLL
{
    public class ContainerConfiguration
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<CSVFile>().As<ICSVFile>();
            builder.RegisterType<QuickInsert>().As<IQuickInsert>();
            builder.RegisterType<DbConnection>().As<IDbConnection>();
            builder.RegisterType<AppSettings>().As<IAppSettings>();            
            builder.RegisterType<SqlConnectionFactory>().As<IDbConnectionFactory>();
            builder.RegisterType<Database>().As<IDatabase>();
            builder.RegisterType<SQLServerBulkInsert>().As<IBulkInsert>();
            builder.RegisterType<BusinessLogic>().As<IBusinessLogic>();
            builder.RegisterType<Application>().As<IApplication>();

            return builder.Build();
        }
    }
}
