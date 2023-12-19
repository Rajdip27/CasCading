using CasCading.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CasCading.EntityConfiguration;

public class EmployeeConfiguration:IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.ToTable(nameof(Employee));
        builder.HasKey(x => x.Id);
        builder.HasOne(x => x.Country).WithMany(x => x.Employees).HasForeignKey(x => x.CountryId);
        builder.HasOne(x => x.State).WithMany(x => x.Employees).HasForeignKey(x => x.StateId);
        builder.HasOne(x => x.City).WithMany(x => x.Employees).HasForeignKey(x => x.CityId);
    }
}
