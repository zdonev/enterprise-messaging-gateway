using Autofac;
using Autofac.Integration.WebApi;
using System.Reflection;
using System.Web;
using System.Web.Http;
using EnterpriseMessagingGateway.Core.Entities;
using EnterpriseMessagingGateway.Core.Interfaces;
using EnterpriseMessagingGateway.Infrastructure;
using EnterpriseMessagingGateway.Infrastructure.Repositories;
using EnterpriseMessagingGateway.Services;
using EnterpriseMessagingGateway.Services.Interfaces;

namespace EnterpriseMessagingGateway.Api
{
    public static class AutoFacConfig
    {
        public static void RegisterDependencyResolver()
        {
            var builder = new ContainerBuilder();
            var config = GlobalConfiguration.Configuration;
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            builder.RegisterType<ApplicationDbContext>();
            builder.RegisterType<TaskRepository>().As<IRepository<Task>>();
            builder.RegisterType<TaskReadRepository>().As<IReadRepository<Task>>();
            builder.RegisterType<TradingPartnerContactRepository>().As<ITradingPartnerContactRepository>();
            builder.RegisterType<TradingPartnerRepository>().As<ITradingPartnerRepository>();
            builder.RegisterType<TradingPartnerReadRepository>().As<IReadRepository<TradingPartner>>();
            builder.RegisterType<PropertyMappingService>().As<IPropertyMappingService>();
            builder.RegisterType<Repository<TradingPartnerContact>>().As<IRepository<TradingPartnerContact>>();
            builder.RegisterType<Repository<TradingPartnerContactProperty>>().As<IRepository<TradingPartnerContactProperty>>();


            //Services
            builder.RegisterType<TaskService>().As<ITaskService>();
            builder.RegisterType<TradingPartnerService>().As<ITradingPartnerService>();

            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}