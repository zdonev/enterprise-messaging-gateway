using System.Data.Entity;
using EnterpriseMessagingGateway.Core.Entities;
//Used to abstract DBContext for unit testing

namespace EnterpriseMessagingGateway.Infrastructure
{
    public interface IApplicationDbContext
    {
        DbSet<Agreement> Agreements { get; set; }
        //DbSet<AgreementLog> AgreementLogs { get; set; }
        DbSet<AgreementResolvers> AgreementLookups { get; set; }
        DbSet<AgreementProperty> AgreementProperties { get; set; }
        DbSet<DocumentType> DocumentTypes { get; set; }
        DbSet<DocumentTypeResolver> AgreementResolutionLookups { get; set; }
        DbSet<AgreementTask> AgreementTasks { get; set; }
        DbSet<AgreementTaskParameter> AgreementTaskParameters { get; set; }
        DbSet<MessageArchive> MessageArchives { get; set; }
        DbSet<Task> Tasks { get; set; }
        DbSet<TaskProperty> TaskProperties { get; set; }
        DbSet<TaskParameter> TaskParameters { get; set; }
        DbSet<TradingPartner> TradingPartners { get; set; }
        DbSet<TradingPartnerContact> Contacts { get; set; }
        DbSet<TradingPartnerIdentifier> TradingPartnerIdentifiers { get; set; }
        DbSet<TradingPartnerProperty> TradingPartnerProperties { get; set; }
        DbSet<TradingPartnerContactProperty> ContactProperties { get; set; }
    }
}
