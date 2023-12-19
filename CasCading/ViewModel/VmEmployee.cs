using CasCading.Models;

namespace CasCading.ViewModel;

public class VmEmployee
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string Gender { get; set; } = string.Empty;
    public DateTime Joiningdate { get; set; }
    public string Picture { get; set; } = string.Empty;
    public int CountryId { get; set; }
    public int StateId { get; set; }
    public int CityId { get; set; }
   
}