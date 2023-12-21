namespace CasCading.Models;

public class State
{
    public int Id { get; set; }
    public string Name { get; set; }=String.Empty;
    public int CountryId { get; set; }
    public Country Country { get; set; }

    public ICollection<City> Cities = new HashSet<City>();
    public ICollection<Employee> Employees = new HashSet<Employee>();
}