namespace CasCading.Models;

public class Country
{
    public int Id { get; set; }
    public string Name { get; set; } 

    public ICollection<State> States=new HashSet<State>();
    public ICollection<Employee> Employees=new HashSet<Employee>();
}