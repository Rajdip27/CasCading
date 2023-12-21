using System.ComponentModel.DataAnnotations.Schema;

namespace CasCading.ViewModel;

public class VmCity
{
    public int Id { get; set; }
    public string Name { get; set; } = String.Empty;
    public int StateId { get; set; }

    [NotMapped]
    public string StateName { get; set; }=String.Empty;
}