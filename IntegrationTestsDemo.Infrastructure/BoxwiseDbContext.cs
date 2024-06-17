using IntegrationTestsDemo.Domain;
using Microsoft.EntityFrameworkCore;

namespace IntegrationTestsDemo.Infrastructure
{
    public class BoxwiseDbContext(DbContextOptions<BoxwiseDbContext> options) : DbContext(options)
    {
        public DbSet<Zone> Zones { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Zone>().HasKey(p => p.ZonePk);
            modelBuilder.Entity<Zone>().Property(p => p.Name).IsRequired();
            modelBuilder.Entity<Zone>().Property(p => p.Description);
            modelBuilder.Entity<Zone>().Property(p => p.Active).IsRequired();
            modelBuilder.Entity<Zone>().Property(p => p.Rights);
            modelBuilder.Entity<Zone>().Property(p => p.Sys).IsRequired();
            modelBuilder.Entity<Zone>().Property(p => p.CreatedOn).IsRequired();
            modelBuilder.Entity<Zone>().Property(p => p.ModifiedOn).IsRequired();
            modelBuilder.Entity<Zone>().Property(p => p.CreatedBy).IsRequired();
            modelBuilder.Entity<Zone>().Property(p => p.ModifiedBy).IsRequired();

        }
        
       
    }
}
