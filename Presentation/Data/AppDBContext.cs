using System;
using Microsoft.EntityFrameworkCore;
using Presentation.Models;

namespace Presentation.Data;

public class ApplicationDBContext : DbContext
{
    public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
    {

    }


    public DbSet<Category> Categories { get; set; }
    
}
