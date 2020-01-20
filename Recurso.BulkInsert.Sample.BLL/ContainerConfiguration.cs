using Autofac;
using Recurso.BulkInsert.Sample.Common.Interfaces;
using Recurso.BulkInsert.Sample.DAL;

namespace Recurso.BulkInsert.Sample.BLL
{
    public class ContainerConfiguration
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<CSVFile>().As<ICSVFile>();
            builder.RegisterType<Database>().As<IDatabase>();
            builder.RegisterType<BusinessLogic>().As<IBusinessLogic>();

            return builder.Build();
        }
    }
}
