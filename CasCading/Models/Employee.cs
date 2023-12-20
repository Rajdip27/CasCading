namespace CasCading.Models;

public class Employee
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public string Address { get; set; }=string.Empty;
    public string Gender { get; set; } = string.Empty;
    public DateTime Joiningdate { get; set; }
    public string Picture { get; set; }= string.Empty;
    public int CountryId { get; set; }
    public Country Country { get; set; }=new();
    public int StateId { get; set; }
    public State State { get; set; } = new();
    public int CityId { get; set; }
    public City City { get; set; } = new();
   
}
