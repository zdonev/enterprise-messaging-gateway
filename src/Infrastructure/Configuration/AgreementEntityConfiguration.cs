using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnterpriseMessagingGateway.Core.Entities;

namespace EnterpriseMessagingGateway.Infrastructure.Configuration
{
    public class AgreementEntityConfiguration : EntityTypeConfiguration<Agreement>
    {
        public AgreementEntityConfiguration()
        {

            this.HasKey<int>(s => s.Id);
            //Property(p => p.UserName).HasMaxLength(255);
            //this.Property
            //this.Property(p => p.)
            //        .HasColumnName("DoB")
            //        .HasColumnOrder(3)
            //        .HasColumnType("datetime2");

            //this.Property(p => p.StudentName)
            //        .HasMaxLength(50);

            //this.Property(p => p.StudentName)
            //        .IsConcurrencyToken();

            //this.HasMany<Course>(s => s.Courses)
            //    .WithMany(c => c.Students)
            //    .Map(cs =>
            //    {
            //        cs.MapLeftKey("StudentId");
            //        cs.MapRightKey("CourseId");
            //        cs.ToTable("StudentCourse");
            //    });
        }
    }
}
