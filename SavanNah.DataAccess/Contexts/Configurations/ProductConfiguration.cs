using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SavanNah.Models.Models.BrandModel;
using SavanNah.Models.Models.CategoryProductModel;
using SavanNah.Models.Models.ProductModel;

namespace SavanNah.DataAccess.Contexts.Configurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(p => p.Description)
            .HasMaxLength(10000);

        builder.Property(p => p.Price)
            .HasColumnType("decimal(18,2)")
            .IsRequired();

        builder.Property(p => p.Discount)
            .HasColumnType("decimal(18,2)")
            .HasDefaultValue(0);
        builder.Property(p => p.Image)
            .HasDefaultValue("");

        builder.HasMany(p => p.CategoryProducts)
            .WithOne(cp => cp.Products)
            .HasForeignKey(cp => cp.ProductsId);

        builder.HasOne(p => p.Brand)
            .WithMany(b => b.Products)
            .HasForeignKey(p => p.BrandId);
    }
}