using System;
using DataAccess.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DataAccess.Context;

public class ApplicationDBContext : IdentityDbContext<User, Role, Guid>
{
    public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
    { }
    public ApplicationDBContext() : base()
    { }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {   //^ To make The App Log SQL Queries to the Console 
        if (!optionsBuilder.IsConfigured)
        {
            var connectionString = "Server=.;Database=SavanNah;Integrated Security = SSPI;TrustServerCertificate=True";

            optionsBuilder
            .UseSqlServer(connectionString)
            .LogTo(Console.WriteLine, LogLevel.Information);
        }

        base.OnConfiguring(optionsBuilder);
    }

    public DbSet<Category> Categories { get; set; }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.Entity<Category>().HasData([
            new Category {id = 1 , Name = "Tech" , imageLoc = "tech.webp"},
            new Category {id = 2 , Name = "Food" , imageLoc = "food.jpg"},
            new Category {id = 3 , Name = "Fashion" , imageLoc = "fashion.jpeg"}
        ]);
    }
}
