using System.Data.Entity.ModelConfiguration;
using EnterpriseMessagingGateway.Core.Entities;

namespace EnterpriseMessagingGateway.Infrastructure.Configuration
{
    public class ContactEntityConfiguration : EntityTypeConfiguration<TradingPartnerContact>
    {
        public ContactEntityConfiguration()
        {

            this.HasKey<int>(s => s.Id);
            this.Property(p => p.Name).HasMaxLength(255).IsRequired();
            this.Property(p => p.Country).HasMaxLength(255);
            this.Property(p => p.Email).HasMaxLength(255);
            this.Property(p => p.Phone).HasMaxLength(255);
            this.Property(p => p.PostalCode).HasMaxLength(255);
            this.Property(p => p.Role).HasMaxLength(255);
            this.Property(p => p.State).HasMaxLength(255);
            this.Property(p => p.Street).HasMaxLength(255);
            this.Property(p => p.City).HasMaxLength(255);
            //Property(p => p.UserName).HasMaxLength(255);


            this.HasMany(s => s.Properties)
                .WithRequired(p => p.Contact)
                .WillCascadeOnDelete(true);


        }
    }
}
