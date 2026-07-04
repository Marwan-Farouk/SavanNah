using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SavanNah.Models.Models;

namespace SavanNah.DataAccess.Contexts.Configurations
{
    public class BrandConfiguration : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            builder
                .HasKey(b => b.Id);
            builder
                .Property(b => b.Name)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("Name");
            builder
                .Property(b => b.Description)
                .HasMaxLength(300)
                .IsRequired(false);

        }
    }
}
