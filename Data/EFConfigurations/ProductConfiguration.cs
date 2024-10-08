using Grocery.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Grocery.Data.EFConfigurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.ProductId)
                .IsClustered(true);
            builder.Property(x => x.ProductName)
                .HasColumnType("varchar(255)")
                .IsRequired(true);
            builder.Property(x => x.InStock)
                .HasColumnType("int")
                .HasDefaultValue(0)
                .IsRequired(true);
            builder.Property(x => x.SRP)
                .HasColumnType("smallmoney")
                .IsRequired(true);  
            builder.Property(x => x.Price)
                .HasColumnType("smallmoney")
                .IsRequired(true);
            builder.Property(x => x.IsActive)
                .HasDefaultValue(true)
                .IsRequired(true);
        }
    }
}
