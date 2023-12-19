using CasCading.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CasCading.EntityConfiguration;

public class CityConfiguration:IEntityTypeConfiguration<City>
{
    public void Configure(EntityTypeBuilder<City> builder)
    {
        builder.ToTable(nameof(City));
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).HasMaxLength(50).IsRequired(true).IsRequired(true);
        builder.HasOne(x => x.State).WithMany(x => x.Cities).HasForeignKey(x => x.StateId);
    }
}