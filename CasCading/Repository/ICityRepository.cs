using CasCading.Models;
using CasCading.Service;
using CasCading.ViewModel;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CasCading.Repository;

public interface ICityRepository:IRepositoryService<City,VmCity>
{
    public IEnumerable<SelectListItem> Dropdown();
    public IEnumerable<City> GetCitiesByState(int id);
}