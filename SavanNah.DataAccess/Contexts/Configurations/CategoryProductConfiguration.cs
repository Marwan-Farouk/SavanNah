using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SavanNah.Models.Models.CategoryModel;
using SavanNah.Models.Models.CategoryProductModel;
using SavanNah.Models.Models.ProductModel;

namespace SavanNah.DataAccess.Contexts.Configurations
{
    public class CategoryProductConfiguration : IEntityTypeConfiguration<CategoryProduct>
    {
        public void Configure(EntityTypeBuilder<CategoryProduct> builder)
        {
            builder.HasKey(cp => new { cp.CategoryId, cp.ProductsId });

            builder.HasOne(cp => cp.Category)
                .WithMany(c => c.CategoryProducts)
                .HasForeignKey(cp => cp.CategoryId);

            builder.HasOne(cp => cp.Products)
                .WithMany(p => p.CategoryProducts)
                .HasForeignKey(cp => cp.ProductsId);
        }
    }
}
