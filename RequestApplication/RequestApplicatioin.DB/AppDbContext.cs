using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using RequestApplication.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace RequestApplicatioin.DB
{
    public class AppDbContext : DbContext
    {
        public DbSet<Request> Requests { get; set; }
        public DbSet<Application> Applications { get; set; }

        public AppDbContext()
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        } 

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=MSI\SQLEXPRESS;Database=master;Trusted_Connection=True;Integrated Security=True;MultipleActiveResultSets=True;TrustServerCertificate=True");
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
