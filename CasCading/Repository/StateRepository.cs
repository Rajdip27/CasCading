using AutoMapper;
using CasCading.ApplicationDb;
using CasCading.Models;
using CasCading.Service;
using CasCading.ViewModel;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CasCading.Repository;

public class StateRepository(IMapper mapper, ApplicationDbContext dbContext)
    : RepositoryService<State, VmState>(mapper, dbContext), IStateRepository
{
    public IEnumerable<SelectListItem> Dropdown()
    {
        return  DbSet.Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() });
    }
}