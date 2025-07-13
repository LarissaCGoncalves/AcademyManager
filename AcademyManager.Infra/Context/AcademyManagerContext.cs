using AcademyManager.Domain.Entities;
using AcademyManager.Infra.Mappings;
using Microsoft.EntityFrameworkCore;

namespace AcademyManager.Infra.Context
{
    public class AcademyManagerContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<ClassGroup> ClassGroups { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }

        public AcademyManagerContext(DbContextOptions<AcademyManagerContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new StudentMap());
            modelBuilder.ApplyConfiguration(new ClassGroupMap());
            modelBuilder.ApplyConfiguration(new EnrollmentMap());
        }

        public async Task<bool> Commit()
        {
            ChangeTracker.Entries().Where(e => e.State == EntityState.Added).ToList().ForEach(e =>
            {
                e.Property("CreatedAt").CurrentValue = DateTime.Now;
                e.Property("UpdatedAt").CurrentValue = DateTime.Now;
            });

            ChangeTracker.Entries().Where(e => e.State == EntityState.Modified).ToList().ForEach(e =>
            {
                e.Property("CreatedAt").IsModified = false;
                e.Property("UpdatedAt").CurrentValue = DateTime.Now;
            });

            var response = await SaveChangesAsync() > 0;
            return response;
        }
    }
}
