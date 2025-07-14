using AcademyManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AcademyManager.Infra.Mappings
{
    public class ClassGroupMap : IEntityTypeConfiguration<ClassGroup>
    {
        public void Configure(EntityTypeBuilder<ClassGroup> builder)
        {
            builder.ToTable("classes");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

            builder.OwnsOne(x => x.Name, name =>
            {
                name.Property(n => n.Value)
                    .IsRequired()
                    .HasColumnName("Name")
                    .HasColumnType("NVARCHAR")
                    .HasMaxLength(100);
            });

            builder.Property(x => x.Description)
                .IsRequired(false)
                .HasColumnName("Description")
                .HasColumnType("TEXT");

            builder.Property(e => e.CreatedAt)
                .HasColumnType("DATETIME")
                .HasDefaultValueSql("GETDATE()");

            builder.Property(e => e.UpdatedAt)
                .HasColumnType("DATETIME")
                .HasDefaultValueSql("GETDATE()");

            builder.Property(e => e.DeletedAt)
                .HasColumnType("DATETIME")
                .IsRequired(false);

            // Filters

            builder.HasQueryFilter(c => c.DeletedAt == null);
        }
    }
}
