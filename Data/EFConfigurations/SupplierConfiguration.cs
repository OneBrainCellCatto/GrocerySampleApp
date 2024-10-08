using Grocery.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Grocery.Data.EFConfigurations
{
    public class SupplierConfiguration : IEntityTypeConfiguration<Supplier>
    {
        public void Configure(EntityTypeBuilder<Supplier> builder)
        {
            builder.HasKey(x => x.SupplierId)
                .IsClustered(true);
            builder.Property(x => x.CompanyName)
                .HasColumnType("varchar(200)")
                .IsRequired(true);
            builder.Property(x => x.CompanyEmail)
                .HasColumnType("nvarchar(320)")
                .IsRequired(true);
        }
    }
}
