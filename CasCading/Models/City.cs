namespace CasCading.Models;

public class City
{
    public int Id { get; set; }
    public string Name { get; set; } = String.Empty;
    public int StateId { get; set; }
    public State State { get; set; } 
    public ICollection<Employee> Employees = new HashSet<Employee>();

}