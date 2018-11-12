using System.Data.Entity;
using EnterpriseMessagingGateway.Core.Entities;
using EnterpriseMessagingGateway.Infrastructure.Configuration;

namespace EnterpriseMessagingGateway.Infrastructure
{
    public class ApplicationDbContext: DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(string connectionString) : base(connectionString)
        { }

        public ApplicationDbContext()
            : base("EnterpriseMessagingGateway.Context")
        { }

        public virtual DbSet<Agreement> Agreements { get; set; }
        //public virtual DbSet<AgreementLog> AgreementLogs { get; set; }
        public virtual DbSet<AgreementResolvers> AgreementLookups { get; set; }
        public virtual DbSet<AgreementProperty> AgreementProperties { get; set; }
        public virtual DbSet<DocumentType> DocumentTypes { get; set; }
        public virtual DbSet<DocumentTypeResolver> AgreementResolutionLookups { get; set; }
        public virtual DbSet<AgreementTask> AgreementTasks { get; set; }
        public DbSet<AgreementTaskParameter> AgreementTaskParameters { get; set; }
        public DbSet<MessageArchive> MessageArchives { get; set; }
        public virtual DbSet<Task> Tasks { get; set; }
        public DbSet<TaskParameter> TaskParameters { get; set; }
        public DbSet<TaskProperty> TaskProperties { get; set; }
        public DbSet<TradingPartner> TradingPartners { get; set; }
        public DbSet<TradingPartnerContact> Contacts { get; set; }

        public DbSet<TradingPartnerContactProperty> ContactProperties { get; set; }
        public DbSet<TradingPartnerIdentifier> TradingPartnerIdentifiers { get; set; }
        public DbSet<TradingPartnerProperty> TradingPartnerProperties { get; set; }


        //public override int SaveChanges()
        //{
        //    ChangeTracker.DetectChanges();

        //    var result = base.SaveChanges();
        //    return result;
        //}

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AgreementEntityConfiguration());
            //modelBuilder.Configurations.Add(new AgreementLogEntityConfiguration());
            modelBuilder.Configurations.Add(new AgreementLookupEntityConfiguration());
            modelBuilder.Configurations.Add(new ContactEntityConfiguration());
            modelBuilder.Configurations.Add(new ContactPropertyEntityConfiguration());

            modelBuilder.Configurations.Add(new DocumentTypeEntityConfiguration());
            modelBuilder.Configurations.Add(new DocumentTypeResolverEntityConfiguration());
            modelBuilder.Configurations.Add(new MessageArchiveEntityConfiguration());
            modelBuilder.Configurations.Add(new TaskEntityConfiguration());
            modelBuilder.Configurations.Add(new TaskParameterEntityConfiguration());
            modelBuilder.Configurations.Add(new TradingPartnerEntityConfiguration());
            modelBuilder.Configurations.Add(new TradingPartnerIdentityEntityConfiguration());
            modelBuilder.Configurations.Add(new TradingPartnerPropertyEntityConfiguration());



            base.OnModelCreating(modelBuilder);
        }

    }
}
