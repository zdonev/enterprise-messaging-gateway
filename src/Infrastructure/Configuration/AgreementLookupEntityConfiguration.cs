using System.Data.Entity.ModelConfiguration;
using EnterpriseMessagingGateway.Core.Entities;

namespace EnterpriseMessagingGateway.Infrastructure.Configuration
{
    public class AgreementLookupEntityConfiguration : EntityTypeConfiguration<AgreementResolvers>
    {
        public AgreementLookupEntityConfiguration()
        {
            HasKey(s => s.Id);
            //Property(p => p.UserName).HasMaxLength(255);

        }
    }
}
