using AcademyManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AcademyManager.Infra.Mappings
{
    public class StudentMap : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.ToTable("students");

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

            builder.Property(x => x.BirthDate)
                .IsRequired()
                .HasColumnName("BirthDate")
                .HasColumnType("DATE");

            builder.OwnsOne(x => x.Cpf, cpf =>
            {
                cpf.Property(c => c.CpfNumber)
                    .IsRequired()
                    .HasColumnName("Cpf")
                    .HasColumnType("NVARCHAR")
                    .HasMaxLength(11);

                cpf.HasIndex(c => c.CpfNumber).IsUnique();
            });

            builder.OwnsOne(x => x.Email, email =>
            {
                email.Property(e => e.Address)
                    .IsRequired()
                    .HasColumnName("Email")
                    .HasColumnType("NVARCHAR")
                    .HasMaxLength(50);

                email.HasIndex(e => e.Address).IsUnique();
            });

            builder.OwnsOne(x => x.Password, password =>
            {
                password.Property(e => e.Hash)
                    .IsRequired()
                    .HasColumnName("Password")
                    .HasColumnType("NVARCHAR")
                    .HasMaxLength(100);
            });

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
