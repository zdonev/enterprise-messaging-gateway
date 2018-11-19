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

            builder.RegisterType<ApplicationDbContext>().InstancePerRequest();
            builder.RegisterType<PropertyMappingService>().As<IPropertyMappingService>();

            //builder.RegisterType<TradingPartnerRepository>().As<IRepository<TradingPartner>>();            
            //builder.RegisterType<TaskRepository>().As<IRepository<Task>>();

            //Tasks
            builder.RegisterType<Repository<Task>>().As<IRepository<Task>>();
            builder.RegisterType<Repository<TaskParameter>>().As<IRepository<TaskParameter>>();
            builder.RegisterType<Repository<TaskProperty>>().As<IRepository<TaskProperty>>();

            //DocumentType
            builder.RegisterType<Repository<DocumentType>>().As<IRepository<DocumentType>>();
            builder.RegisterType<Repository<DocumentTypeResolver>>().As<IRepository<DocumentTypeResolver>>();

            //TradingPartner
            builder.RegisterType<Repository<TradingPartner>>().As<IRepository<TradingPartner>>();            
            builder.RegisterType<Repository<TradingPartnerProperty>>().As<IRepository<TradingPartnerProperty>>();
            builder.RegisterType<Repository<TradingPartnerIdentifier>>().As<IRepository<TradingPartnerIdentifier>>();
            builder.RegisterType<Repository<TradingPartnerContact>>().As<IRepository<TradingPartnerContact>>();
            builder.RegisterType<Repository<TradingPartnerContactProperty>>().As<IRepository<TradingPartnerContactProperty>>();
            builder.RegisterType<Repository<Agreement>>().As<IRepository<Agreement>>();

            builder.RegisterType<ReadRepository<TradingPartnerContact>>().As<IReadRepository<TradingPartnerContact>>();
            builder.RegisterType<ReadRepository<Task>>().As<IReadRepository<Task>>();
            builder.RegisterType<ReadRepository<TaskParameter>>().As<IReadRepository<TaskParameter>>();
            builder.RegisterType<ReadRepository<TaskProperty>>().As<IReadRepository<TaskProperty>>();
            builder.RegisterType<ReadRepository<TradingPartnerContactProperty>>().As<IReadRepository<TradingPartnerContactProperty>>();
            builder.RegisterType<ReadRepository<TradingPartner>>().As<IReadRepository<TradingPartner>>();
            builder.RegisterType<ReadRepository<TradingPartnerProperty>>().As<IReadRepository<TradingPartnerProperty>>();
            builder.RegisterType<ReadRepository<TradingPartnerIdentifier>>().As<IReadRepository<TradingPartnerIdentifier>>();
            builder.RegisterType<ReadRepository<DocumentType>>().As<IReadRepository<DocumentType>>();
            builder.RegisterType<ReadRepository<DocumentTypeResolver>>().As<IReadRepository<DocumentTypeResolver>>();

            //Services
            builder.RegisterType<TaskService>().As<ITaskService>();
            builder.RegisterType<TradingPartnerService>().As<ITradingPartnerService>();
            builder.RegisterType<DocumentTypeService>().As<IDocumentTypeService>();

            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}