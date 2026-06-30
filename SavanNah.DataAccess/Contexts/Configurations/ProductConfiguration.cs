using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SavanNah.Models.Models;

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

        builder.HasMany(p => p.Categories)
            .WithMany(c => c.Products);

        builder.HasOne(p => p.Brand)
            .WithMany(b => b.Products);
    }
}