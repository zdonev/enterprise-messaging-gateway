using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnterpriseMessagingGateway.Core.Entities;

namespace EnterpriseMessagingGateway.Infrastructure.Configuration
{
    public class TradingPartnerIdentityEntityConfiguration : EntityTypeConfiguration<TradingPartnerIdentifier>
    {
        public TradingPartnerIdentityEntityConfiguration()
        {

            this.HasKey<int>(s => s.Id);
            //Property(p => p.UserName).HasMaxLength(255);
            this.Property(p => p.Qualifier).HasMaxLength(50).IsRequired()
                .HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute("TradingPartner_Identity", 1) { IsUnique = true }));
            this.Property(p => p.Identifier).HasMaxLength(100).IsRequired()
                .HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute("TradingPartner_Identity", 2) { IsUnique = true }));

        }
    }
}
