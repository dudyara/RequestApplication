using Microsoft.EntityFrameworkCore;
using RequestApplication.Entities;

namespace RequestApplicatioin.DB
{
    public class AppDbContext : DbContext
    {
        public DbSet<Request> Requests { get; set; }
        public DbSet<Application> Applications { get; set; }

        public AppDbContext()
        {
            Database.EnsureCreated();
        }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Application>()
                .HasMany(a => a.Requests)
                .WithOne(r => r.Application)
                .HasForeignKey(r => r.ApplicationId);
        }
    }
}
