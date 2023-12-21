using AutoMapper;
using CasCading.ApplicationDb;
using CasCading.Models;
using CasCading.Service;
using CasCading.ViewModel;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CasCading.Repository;

public class StateRepository(IMapper mapper, ApplicationDbContext dbContext)
    : RepositoryService<State, VmState>(mapper, dbContext), IStateRepository
{
    public IEnumerable<SelectListItem> Dropdown()
    {
        return  DbSet.Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() });
    }

    public IEnumerable<State> GetStatesByCountry(int id)
    {
        return DbSet
            .Where(s => s.CountryId == id)
            .ToList();
    }
}