using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity.ModelConfiguration;
using EnterpriseMessagingGateway.Core.Entities;
using System.Data.Entity.Infrastructure.Annotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnterpriseMessagingGateway.Infrastructure.Configuration 
{
    public class TaskEntityConfiguration : EntityTypeConfiguration<Task>
    {
        public TaskEntityConfiguration()
        {
            
            this.HasKey<int>(s => s.Id)
            .HasMany(p => p.TaskParameters)
            .WithRequired(p => p.Task)
            .WillCascadeOnDelete(true);

            this.HasMany(s => s.Properties)
                .WithRequired(s => s.Task)
                .WillCascadeOnDelete(true);

            this.HasMany(s => s.AgreementTasks)
                .WithRequired(s => s.Task)
                .WillCascadeOnDelete(false);

            

            this.Property(p => p.Name).HasMaxLength(255).IsRequired()
                .HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute("Task_Name", 1) { IsUnique = true }));
            this.Property(p => p.Description).HasMaxLength(4000).IsRequired();
            this.Property(p => p.Type).IsRequired();
            //Property(p => p.UserName).HasMaxLength(255);


            //modelBuilder.Entity<AgreementTask>().Property(t => t.Description).HasMaxLength(4096);

        }
    }
}
