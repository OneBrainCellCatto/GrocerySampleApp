using Grocery.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Grocery.Data.EFConfigurations
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.UseTphMappingStrategy();
            builder.HasKey(x => x.EmployeeId)
                .IsClustered(true);
            builder.Property(x => x.FirstName)
                .HasColumnType("varchar(200)")
                .IsRequired(true);
            builder.Property(x => x.MiddleName)
                .HasColumnType("varchar(100)")
                .IsRequired(false);
            builder.Property(x => x.LastName)
                .HasColumnType("varchar(100)")
                .IsRequired(true);
            builder.Property(x => x.BirthDate)
                .HasColumnType("date")
                .IsRequired(true);
            builder.Property(x => x.DateHired)
                .HasColumnType("date")
                .IsRequired(true);
            builder.Property(x => x.DateResigned)
                .HasColumnType("date");
            builder.Property(x => x.CurrentlyEmployed)
                .HasColumnType("bit")
                .IsRequired(true);
            builder.HasOne(x => x.Gender)
                .WithMany()
                .HasForeignKey(x => x.GenderId)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.CivilStatus)
                .WithMany()
                .HasForeignKey(x => x.CivilStatusId)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.Position)
                .WithMany()
                .HasForeignKey(x => x.PositionId)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
