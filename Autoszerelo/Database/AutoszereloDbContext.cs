using Autoszerelo.DataClasses;
using Castle.Core.Resource;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace Autoszerelo.Database
{
    public class AutoszereloDbContext : DbContext
    {
        public AutoszereloDbContext()
        {
                
        }
        public AutoszereloDbContext(DbContextOptions options)
            : base(options)
        {
            
        }

        public virtual DbSet<Ugyfel> Ugyfelek { get; set;}
        public virtual DbSet<Munka> Munkak { get; set;}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ugyfel>()
                .HasMany(e => e.Munkak)
                .WithOne(e => e.Ugyfelek);
        }
    }
}
