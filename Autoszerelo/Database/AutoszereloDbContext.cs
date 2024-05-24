using Autoszerelo.DataClasses;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace Autoszerelo.Database
{
    public class AutoszereloDbContext : DbContext
    {
        public AutoszereloDbContext(DbContextOptions options)
            : base(options)
        {
            
        }

        public DbSet<Ugyfel> Ugyfelek { get; set;}
        public DbSet<Munka> Munkak { get; set;}
    }
}
