using System.ComponentModel.DataAnnotations.Schema;

namespace CasCading.ViewModel;

public class VmState
{
    public int Id { get; set; }
    public string Name { get; set; } = String.Empty;
    public int CountryId { get; set; }
    //public VmCountry Country { get; set; }

    [NotMapped]
    public string? CountryName { get; set; } = String.Empty;
}