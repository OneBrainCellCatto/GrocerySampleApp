using Grocery.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Grocery.Data.EFConfigurations
{
    public class GenderConfiguration : IEntityTypeConfiguration<Gender>
    {
        public void Configure(EntityTypeBuilder<Gender> builder)
        {
            builder.HasKey(x => x.GenderId)
                .IsClustered(true);
            builder.Property(x => x.GenderName)
                .HasColumnType("varchar(50)")
                .IsRequired(true);
            builder.HasData(
                new Gender
                {
                    GenderId = 1,
                    GenderName = "Male"
                },
                new Gender
                {
                    GenderId = 2,
                    GenderName = "Female"
                },
                new Gender
                {
                    GenderId = 3,
                    GenderName = "Prefer not to say"
                }
                );
        }
    }
}
