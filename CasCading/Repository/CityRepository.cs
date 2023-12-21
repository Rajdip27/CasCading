using AutoMapper;
using CasCading.ApplicationDb;
using CasCading.Models;
using CasCading.Service;
using CasCading.ViewModel;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CasCading.Repository;

public class CityRepository(IMapper mapper, ApplicationDbContext dbContext)
    : RepositoryService<City, VmCity>(mapper, dbContext), ICityRepository
{
    public IEnumerable<SelectListItem> Dropdown()
    {
        return DbSet.Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() });
    }

    public IEnumerable<City> GetCitiesByState(int id)
    {
        return DbSet.Where(x => x.StateId == id).ToList();
    }
}