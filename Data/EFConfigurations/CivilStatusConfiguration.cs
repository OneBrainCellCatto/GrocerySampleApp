using Grocery.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Grocery.Data.EFConfigurations
{
    public class CivilStatusConfiguration : IEntityTypeConfiguration<CivilStatus>
    {
        public void Configure(EntityTypeBuilder<CivilStatus> builder)
        {
            builder.HasKey(x => x.CivilStatusId)
                .IsClustered(true);
            builder.Property(x => x.CivilStatusName)
                .HasColumnType("varchar(50)")
                .IsRequired(true);
            builder.HasData(
                new CivilStatus
                {
                    CivilStatusId = 1,
                    CivilStatusName = "Single"
                },
                new CivilStatus
                {
                    CivilStatusId = 2,
                    CivilStatusName = "Married"
                },
                new CivilStatus
                {
                    CivilStatusId = 3,
                    CivilStatusName = "Separated"
                },
                new CivilStatus
                {
                    CivilStatusId = 4,
                    CivilStatusName = "Divorced"
                },
                new CivilStatus
                {
                    CivilStatusId = 5,
                    CivilStatusName = "Widowed"
                }
                );
        }
    }
}
