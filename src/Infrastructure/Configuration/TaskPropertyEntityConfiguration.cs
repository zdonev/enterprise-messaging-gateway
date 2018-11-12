using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnterpriseMessagingGateway.Core.Entities;

namespace EnterpriseMessagingGateway.Infrastructure.Configuration
{
    public class TaskPropertyEntityConfiguration : EntityTypeConfiguration<TaskProperty>
    {
        public TaskPropertyEntityConfiguration()
        {

            this.HasKey<int>(s => s.Id);
            this.Property(p => p.Name).HasMaxLength(255).IsRequired();
            this.Property(p => p.Value).IsRequired();
        }
    }
}
