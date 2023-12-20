using AutoMapper;
using CasCading.Models;

namespace CasCading.ViewModel;
[AutoMap(typeof(Country),ReverseMap = true)]
public class VmCountry
{
    public int Id { get; set; }
    public string Name { get; set; } = String.Empty;
}