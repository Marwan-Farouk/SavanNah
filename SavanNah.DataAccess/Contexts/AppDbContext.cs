using Microsoft.EntityFrameworkCore;
using SavanNah.Models.Models.BrandModel;
using SavanNah.Models.Models.CategoryModel;
using SavanNah.Models.Models.CategoryProductModel;
using SavanNah.Models.Models.ProductModel;

namespace SavanNah.DataAccess.Contexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<CategoryProduct> CategoryProducts { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

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

            // Seed Categories
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Clothes", Description = "Apparel and fashion items" },
                new Category { Id = 2, Name = "Cars", Description = "Automobiles and automotive accessories" },
                new Category
                    { Id = 3, Name = "Home Appliances", Description = "Essential appliances for the modern home" },
                new Category { Id = 4, Name = "Electronics", Description = "Consumer electronics and gadgets" },
                new Category { Id = 5, Name = "Books", Description = "Books across all genres and disciplines" }
            );

            // Seed Brands
            modelBuilder.Entity<Brand>().HasData(
                new Brand
                {
                    Id = 1,
                    Name = "Samsung",
                    Description = "South Korean multinational electronics and tech corporation"
                },
                new Brand
                {
                    Id = 2,
                    Name = "Apple",
                    Description = "American technology company known for iPhone and Mac"
                },
                new Brand
                {
                    Id = 3,
                    Name = "Sony",
                    Description = "Japanese conglomerate specialising in electronics and entertainment"
                },
                new Brand { Id = 4, Name = "Nike", Description = "American sportswear and athletic footwear brand" },
                new Brand
                {
                    Id = 5, Name = "Adidas", Description = "German multinational sportswear and clothing brand"
                },
                new Brand { Id = 6, Name = "Toyota", Description = "Japanese multinational automotive manufacturer" },
                new Brand { Id = 7, Name = "Penguin", Description = "Leading international book publisher" }
            );

            // Seed Products
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Name = "T-Shirt",
                    Description = "Comfortable cotton T-shirt",
                    Price = 19.99m,
                    Discount = 0m,
                    BrandId = 4,
                    Image = ""
                },
                new Product
                {
                    Id = 2,
                    Name = "Jeans",
                    Description = "Stylish denim jeans",
                    Price = 49.99m,
                    Discount = 0m,
                    BrandId = 5,
                    Image = ""
                },
                new Product
                {
                    Id = 3,
                    Name = "Sports Car",
                    Description = "Fast and luxurious sports car",
                    Price = 75000.00m,
                    Discount = 0m,
                    BrandId = 6,
                    Image = ""
                },
                new Product
                {
                    Id = 4,
                    Name = "Family Sedan",
                    Description = "Reliable family car",
                    Price = 25000.00m,
                    Discount = 0m,
                    BrandId = 6,
                    Image = ""
                },
                new Product
                {
                    Id = 5,
                    Name = "Refrigerator",
                    Description = "Large capacity refrigerator",
                    Price = 899.00m,
                    Discount = 0m,
                    BrandId = 1,
                    Image = ""
                },
                new Product
                {
                    Id = 6,
                    Name = "Washing Machine",
                    Description = "Efficient washing machine",
                    Price = 599.00m,
                    Discount = 0m,
                    BrandId = 1,
                    Image = ""
                },
                new Product
                {
                    Id = 7,
                    Name = "Smartphone",
                    Description = "Latest model smartphone",
                    Price = 999.00m,
                    Discount = 0m,
                    BrandId = 2,
                    Image = ""
                },
                new Product
                {
                    Id = 8,
                    Name = "Laptop",
                    Description = "High performance laptop",
                    Price = 1200.00m,
                    Discount = 0m,
                    BrandId = 3,
                    Image = ""
                },
                new Product
                {
                    Id = 9,
                    Name = "Fiction Book",
                    Description = "Bestselling novel",
                    Price = 15.00m,
                    Discount = 0m,
                    BrandId = 7,
                    Image = ""
                },
                new Product
                {
                    Id = 10,
                    Name = "Science Book",
                    Description = "Educational science book",
                    Price = 25.00m,
                    Discount = 0m,
                    BrandId = 7,
                    Image = ""
                }
            );

            // Seed CategoryProduct join table (Many-to-Many relationships)
            modelBuilder.Entity<CategoryProduct>().HasData(
                // T-Shirt (Product 1) belongs to Clothes (Category 1)
                new CategoryProduct { CategoryId = 1, ProductsId = 1 },
                // Jeans (Product 2) belongs to Clothes (Category 1)
                new CategoryProduct { CategoryId = 1, ProductsId = 2 },
                // Sports Car (Product 3) belongs to Cars (Category 2)
                new CategoryProduct { CategoryId = 2, ProductsId = 3 },
                // Family Sedan (Product 4) belongs to Cars (Category 2)
                new CategoryProduct { CategoryId = 2, ProductsId = 4 },
                // Refrigerator (Product 5) belongs to Home Appliances (Category 3)
                new CategoryProduct { CategoryId = 3, ProductsId = 5 },
                // Washing Machine (Product 6) belongs to Home Appliances (Category 3)
                new CategoryProduct { CategoryId = 3, ProductsId = 6 },
                // Smartphone (Product 7) belongs to Electronics (Category 4)
                new CategoryProduct { CategoryId = 4, ProductsId = 7 },
                // Laptop (Product 8) belongs to Electronics (Category 4)
                new CategoryProduct { CategoryId = 4, ProductsId = 8 },
                // Laptop (Product 8) also belongs to Home Appliances (Category 3) - cross-category relation
                new CategoryProduct { CategoryId = 3, ProductsId = 8 },
                // Fiction Book (Product 9) belongs to Books (Category 5)
                new CategoryProduct { CategoryId = 5, ProductsId = 9 },
                // Science Book (Product 10) belongs to Books (Category 5)
                new CategoryProduct { CategoryId = 5, ProductsId = 10 }
            );

            base.OnModelCreating(modelBuilder);
        }
    }
}
