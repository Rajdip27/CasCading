using CasCading.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CasCading.EntityConfiguration;

public class StateConfiguration:IEntityTypeConfiguration<State>
{
    public void Configure(EntityTypeBuilder<State> builder)
    {
        builder.ToTable(nameof(State));
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).HasMaxLength(60).IsRequired(true);
        builder.HasOne(x => x.Country).WithMany(x => x.States).HasForeignKey(x => x.CountryId);
    }
}