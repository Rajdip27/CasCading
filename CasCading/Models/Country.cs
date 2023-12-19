namespace CasCading.Models;

public class Country
{
    public int Id { get; set; }
    public string Name { get; set; } = String.Empty;

    public ICollection<State> States=new HashSet<State>();
}