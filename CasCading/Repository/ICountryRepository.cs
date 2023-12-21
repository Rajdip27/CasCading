using CasCading.Models;
using CasCading.Service;
using CasCading.ViewModel;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CasCading.Repository;

public interface ICountryRepository:IRepositoryService<Country,VmCountry>
{
    public IEnumerable<SelectListItem> Dropdown();

}