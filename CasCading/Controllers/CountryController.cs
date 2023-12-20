using CasCading.Repository;
using CasCading.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace CasCading.Controllers;

public class CountryController(ICountryRepository countryRepository) : Controller
{
    public async Task<IActionResult> Index(CancellationToken cancellationToken)=> View(await countryRepository.GetAllAsync(cancellationToken));
    [HttpGet]
    public async Task<IActionResult> CreateOrUpdate(int id ,CancellationToken cancellationToken)=> id==0 ? View(new VmCountry()) : View(await countryRepository.GetByIdAsync(id, cancellationToken));

    [HttpPost]
    public async Task<IActionResult> CreateOrUpdate(int id,VmCountry country,CancellationToken cancellationToken)
    {
        if (ModelState.IsValid)
        {
            if (id == 0)
            {
                await countryRepository.InsertAsync(country, cancellationToken);
                return RedirectToAction(nameof(Index));
            }

            await countryRepository.UpdateAsync(id, country, cancellationToken);
            return RedirectToAction(nameof(Index));
        }
        else
        {
            return View(new VmCountry());
        }
    }

    public async Task<IActionResult> Delete(int id,CancellationToken cancellationToken)
    {
        if (id != 0)
        {
            await countryRepository.DeleteAsync(id, cancellationToken);
            return RedirectToAction(nameof(Index));
        }
        else
        {
            return RedirectToAction(nameof(Index));
        }
    }
}
