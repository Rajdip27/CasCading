using CasCading.Models;

namespace CasCading.ViewModel;

public class VmEmployee
{
    public int Id { get; set; }
    public string Name { get; set; } 
    public string Address { get; set; } 
    public string Gender { get; set; } 
    public DateTime Joiningdate { get; set; }
    public string Picture { get; set; } 

    public int CountryId { get; set; }
    public int StateId { get; set; }
    public int CityId { get; set; }
   
}