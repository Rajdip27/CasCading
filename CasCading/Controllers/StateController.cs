using CasCading.Repository;
using CasCading.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace CasCading.Controllers;

public class StateController(IStateRepository stateRepository, ICountryRepository countryRepository) : Controller
{
    
    public async Task<IActionResult> Index()
    
    {
        var data = await stateRepository.GetAllAsync(x=>x.Country);
        return View(data);
    }
    [HttpGet]
    public async Task<IActionResult> CreateOrUpdate(int id, CancellationToken cancellationToken)
    {
        ViewData["CountryId"] =  countryRepository.Dropdown();
        if (id==0)
        {
            return View(new VmState());
        }
        else
        {
            var data = await stateRepository.GetByIdAsync(id, cancellationToken);
            return View(data);
        }
    }

    [HttpPost]
    public async Task<IActionResult> CreateOrUpdate(int id, VmState state, CancellationToken cancellationToken)
    {
        if (id==0)
        {
            if (ModelState.IsValid)
            {
                await stateRepository.InsertAsync(state, cancellationToken);
                return RedirectToAction(nameof(Index));
            }
        }
        else
        {
            if (ModelState.IsValid)
            {
                await stateRepository.UpdateAsync(id,state, cancellationToken);
                return RedirectToAction(nameof(Index));
            }
        }
        return View(state);
    }
}