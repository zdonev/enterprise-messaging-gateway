using System.Data.Entity.ModelConfiguration;
using EnterpriseMessagingGateway.Core.Entities;

namespace EnterpriseMessagingGateway.Infrastructure.Configuration
{
    public class AgreementLogEntityConfiguration : EntityTypeConfiguration<AgreementLog>
    {
        public AgreementLogEntityConfiguration()
        {
            HasKey(s => s.Id);
            //Property(p => p.UserName).HasMaxLength(255);

        }
    }
}
