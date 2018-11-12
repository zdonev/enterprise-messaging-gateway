using System.Data.Entity.ModelConfiguration;
using EnterpriseMessagingGateway.Core.Entities;
using System.Data.Entity.Infrastructure.Annotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnterpriseMessagingGateway.Infrastructure.Configuration
{
    public class TaskParameterEntityConfiguration : EntityTypeConfiguration<TaskParameter>
    {
        public TaskParameterEntityConfiguration()
        {

            this.HasKey<int>(s => s.Id);
            this.Property(p => p.Description).HasMaxLength(4000).IsRequired();
            this.Property(p => p.Key).HasMaxLength(255).IsRequired();
            
            this.Property(p => p.Type).IsRequired();
            //Property(p => p.UserName).HasMaxLength(255);

        }
    }
}
