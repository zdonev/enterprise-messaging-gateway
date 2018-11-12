using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnterpriseMessagingGateway.Core.Entities;

namespace EnterpriseMessagingGateway.Infrastructure.Configuration
{
    public class MessageArchiveEntityConfiguration : EntityTypeConfiguration<MessageArchive>
    {
        public MessageArchiveEntityConfiguration()
        {
            this.HasKey<int>(s => s.Id);
            this.Property(p => p.ActivityId).HasMaxLength(255).IsRequired();
            this.Property(p => p.TaskName).HasMaxLength(255).IsRequired();
            //Property(p => p.UserName).HasMaxLength(255);
        }
    }
}
