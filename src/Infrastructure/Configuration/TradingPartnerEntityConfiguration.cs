using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using EnterpriseMessagingGateway.Core.Entities;

namespace EnterpriseMessagingGateway.Infrastructure.Configuration
{
    public class TradingPartnerEntityConfiguration : EntityTypeConfiguration<TradingPartner>
    {
        public TradingPartnerEntityConfiguration()
        {

            this.HasKey<int>(s => s.Id);
            this.Property(p => p.Description).HasMaxLength(4000).IsRequired();
            this.Property(p => p.Name).HasMaxLength(255).IsRequired()
                .HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute("TP_Name", 1) { IsUnique = true }));
            //Property(p => p.UserName).HasMaxLength(255);
            this.HasMany(s => s.Contacts)
                .WithRequired(tp => tp.TradingPartner)
                .WillCascadeOnDelete(true);
            //this.HasMany<TradingPartnerContact>(s => s.Contacts)
            //    .WithMany(t => t.TradingPartners);
            //    .Map(tpc =>
            //    {
            //        tpc.m

            //    }
            //    )
            //modelBuilder.Entity<Student>()
            //    .HasMany<Course>(s => s.Courses)
            //    .WithMany(c => c.Students)
            //    .Map(cs =>
            //    {
            //        cs.MapLeftKey("StudentRefId");
            //        cs.MapRightKey("CourseRefId");
            //        cs.ToTable("StudentCourse");
            //    });


            this.HasMany(s => s.Properties)
                .WithRequired(tp => tp.TradingPartner)
                .WillCascadeOnDelete(true);

            this.HasMany(s => s.Identifiers)
                .WithRequired(tp => tp.TradingPartner)
                .WillCascadeOnDelete(true);
        }
    }
}
