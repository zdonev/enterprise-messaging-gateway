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
    public class DocumentTypeEntityConfiguration : EntityTypeConfiguration<DocumentType>
    {
        public DocumentTypeEntityConfiguration()
        {

            this.HasKey<int>(s => s.Id);
            this.Property(p => p.Name).HasMaxLength(255).IsRequired();
            //Property(p => p.UserName).HasMaxLength(255);
            this.Property(p => p.Description).HasMaxLength(4000).IsRequired();
            this.Property(p => p.DocType).HasMaxLength(255).IsRequired()
                .HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute("DocumentType_Channel", 1) { IsUnique = true }));
            this.Property(p => p.Channel).HasMaxLength(255).IsRequired()
                .HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute("DocumentType_Channel", 2) { IsUnique = true }));
        }
    }
}
