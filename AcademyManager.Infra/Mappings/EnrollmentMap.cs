using AcademyManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AcademyManager.Infra.Mappings
{
    public class EnrollmentMap : IEntityTypeConfiguration<Enrollment>
    {
        public void Configure(EntityTypeBuilder<Enrollment> builder)
        {
            builder.ToTable("enrollments");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

            builder.Property(e => e.CreatedAt)
                .HasColumnType("DATETIME");

            builder.Property(e => e.UpdatedAt)
                .HasColumnType("DATETIME")
                .HasDefaultValueSql("GETDATE()");

            builder.Property(e => e.DeletedAt)
                .HasColumnType("DATETIME")
                .IsRequired(false);

            //Relationships

            builder.HasOne(x => x.Student)
                .WithMany(x => x.Enrollments)
                .HasForeignKey(x => x.StudentId)
                .HasConstraintName("FK_Enrollment_Student")
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex(x => x.StudentId)
                .HasDatabaseName("IX_Enrollment_StudentId");

            builder.HasOne(x => x.ClassGroup)
                .WithMany(x => x.Enrollments)
                .HasForeignKey(x => x.ClassGroupId)
                .HasConstraintName("FK_Enrollment_Class")
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex(x => x.ClassGroupId)
                .HasDatabaseName("IX_Enrollment_ClassGroupId");
        }
    }
}
