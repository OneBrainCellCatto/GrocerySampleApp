using Grocery.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Grocery.Data.EFConfigurations
{
    public class PositionConfiguration : IEntityTypeConfiguration<Position>
    {
        public void Configure(EntityTypeBuilder<Position> builder)
        {
            builder.HasKey(x => x.PositionId);
            builder.Property(x => x.PositionName)
                .HasColumnType("varchar(50)")
                .IsRequired(true);

            // Seeding
            builder.HasData(
                new Position
                {
                    PositionId = 1,
                    PositionName = "Custodian"
                },
                new Position
                {
                    PositionId = 2,
                    PositionName = "Shopping cart attendant"  
                },
                new Position
                {
                    PositionId = 3,
                    PositionName = "Cashier"
                },
                new Position
                {
                    PositionId = 4,
                    PositionName = "Food preparation workers"
                },
                new Position
                {
                    PositionId = 5,
                    PositionName = "Bagger"
                },
                new Position
                {
                    PositionId = 6,
                    PositionName = "Assistant Store Manager"
                },
                new Position
                {
                    PositionId = 7,
                    PositionName = "Stock Clerk"
                },
                new Position
                {
                    PositionId = 8,
                    PositionName = "Pharmacy Technician/Pharmacist"
                },
                new Position
                {
                    PositionId = 9,
                    PositionName = "Butcher"
                },
                new Position
                {
                    PositionId = 10,
                    PositionName = "Inventory control specialist"
                },
                new Position
                {
                    PositionId = 11,
                    PositionName = "Customer service representative"
                },
                new Position
                {
                    PositionId = 12,
                    PositionName = "Security Guard"
                },
                new Position
                {
                    PositionId = 13,
                    PositionName = "Manager"
                }
                );
        }
    }
}
