using Microsoft.EntityFrameworkCore;
using CasCading.ViewModel;

namespace CasCading.ApplicationDb;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }

public DbSet<CasCading.ViewModel.VmCountry> VmCountry { get; set; } = default!;

public DbSet<CasCading.ViewModel.VmEmployee> VmEmployee { get; set; } = default!;

public DbSet<CasCading.ViewModel.VmState> VmState { get; set; } = default!;
}