using Microsoft.EntityFrameworkCore;

namespace SavanNah.Contexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }


    }
}
