using CasCading.Repository;
using CasCading.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace CasCading.Controllers;

public class CityController(IStateRepository stateRepository, ICityRepository cityRepository)
    : Controller
{
    public async Task<IActionResult> Index()
    {
        var data = await cityRepository.GetAllAsync(x => x.State);
        return View(data);
    }
    [HttpGet]
    public async Task<IActionResult> CreateOrUpdate(int id, CancellationToken cancellationToken)
    {
        ViewData["StateId"] = stateRepository.Dropdown();
        if (id==0)
        {
            return View(new VmCity());
        }
        else
        {
            var data = await cityRepository.GetByIdAsync(id, cancellationToken);
            return View(data);
        }
    }

    [HttpPost]
    public async Task<IActionResult> CreateOrUpdate(int id, VmCity city, CancellationToken cancellationToken)
    {
        if (id==0)
        {
            if (ModelState.IsValid)
            {
                await cityRepository.InsertAsync(city, cancellationToken);
                return RedirectToAction(nameof(Index));
            }
        }
        else
        {
            if (ModelState.IsValid)
            {
                await cityRepository.UpdateAsync(id,city, cancellationToken);
                return RedirectToAction(nameof(Index));
            }
        }

        return View(city);
    }

    public async Task<IActionResult> Delete(int id)
    {
        if (id != 0)
        {
            await cityRepository.DeleteAsync(id, CancellationToken.None);
            return RedirectToAction(nameof(Index));
        }
        return RedirectToAction(nameof(Index));
    }

}