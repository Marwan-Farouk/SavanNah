using Microsoft.EntityFrameworkCore;
using SavanNah.Models.Models;

namespace SavanNah.DataAccess.Contexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }

        /*
         OnConfiguring method is a fallback that's called when:
            •	The DbContext is created without dependency injection
            •	No configuration has been provided yet
        */
        /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.;Database=Savanah_DB;Trusted_Connection=True;TrustServerCertificate=True;")
                    .LogTo(Console.WriteLine, LogLevel.Information);

            }
            base.OnConfiguring(optionsBuilder);
        }*/

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //This automatically discovers and applies all IEntityTypeConfiguration<T> implementations in the project.
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }

    }
}
