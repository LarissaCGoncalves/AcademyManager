using AcademyManager.Domain.Entities;
using AcademyManager.Infra.Mappings;
using AcademyManager.Shared.Notifications;
using AcademyManager.Shared.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace AcademyManager.Infra.Context
{
    public class AcademyManagerContext : DbContext, IUnitOfWork
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
            modelBuilder.Ignore<Notification>();
            modelBuilder.Ignore<Notifiable>();
        }

        public async Task<bool> CommitAsync()
        {
            var response = await SaveChangesAsync() > 0;
            return response;
        }

        public void Dispose()
        {
            base.Dispose();
        }
    }
}
