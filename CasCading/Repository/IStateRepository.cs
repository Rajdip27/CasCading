using CasCading.Models;
using CasCading.Service;
using CasCading.ViewModel;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CasCading.Repository;

public interface IStateRepository:IRepositoryService<State,VmState>
{ 
   IEnumerable<SelectListItem>  Dropdown();
}