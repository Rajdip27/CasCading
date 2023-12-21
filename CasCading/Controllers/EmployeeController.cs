using CasCading.Models;
using CasCading.Repository;
using CasCading.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace CasCading.Controllers;

public class EmployeeController(IEmployeeRepository employeeRepository, ICountryRepository countryRepository, IStateRepository stateRepository, ICityRepository cityRepository) : Controller
{
    
    public async Task<IActionResult> Index( CancellationToken cancellationToken)
    {
        return View(await employeeRepository.GetAllAsync(cancellationToken));
    }
    [HttpGet]
    public async Task<IActionResult> CreateOrUpdate(int id,CancellationToken cancellationToken)
    {
        ViewData["CountryId"] = countryRepository.Dropdown();
        ViewData["StateId"] = stateRepository.Dropdown();
        ViewData["CityId"] = cityRepository.Dropdown();
        if (id == 0)
        {
            return View(new VmEmployee());
        }
        else
        {
            return View(await employeeRepository.GetByIdAsync(id, cancellationToken));
        }
    }

    [HttpPost]
    public async Task<IActionResult> CreateOrUpdate(int id, VmEmployee vmEmployee, CancellationToken cancellationToken, IFormFile pictureFile)
    {
        if (id == 0)
        {
            if (ModelState.IsValid)
            {
                if (pictureFile != null && pictureFile.Length > 0)
                {
                    var path = Path.Combine(
                        Directory.GetCurrentDirectory(),
                        "wwwroot/images/Employees",
                        pictureFile.FileName);
                    await using (var stream = new FileStream(path, FileMode.Create))
                    {
                        pictureFile.CopyTo(stream);
                    }
                    vmEmployee.Picture = $"{pictureFile.FileName}";
                }

                await employeeRepository.InsertAsync(vmEmployee, cancellationToken);
                return RedirectToAction(nameof(Index));
            }
                

            
        }
        else
        {

            if (ModelState.IsValid)
            {
                if (pictureFile != null && pictureFile.Length > 0)
                {
                    var path = Path.Combine(
                        Directory.GetCurrentDirectory(),
                        "wwwroot/images/Employees",
                        pictureFile.FileName);
                    await using (var stream = new FileStream(path, FileMode.Create))
                    {
                        pictureFile.CopyTo(stream);
                    }
                    vmEmployee.Picture = $"{pictureFile.FileName}";
                }

                await employeeRepository.UpdateAsync(id, vmEmployee, cancellationToken);
                return RedirectToAction(nameof(Index));
            }
            
        }

        return View(vmEmployee);
    }









    [HttpGet]
    public IActionResult GetStates(int countryId)
    {
        var states = stateRepository.GetStatesByCountry(countryId);
        return Json(new { states });
    }

    [HttpGet]
    public IActionResult GetCities(int stateId)
    {
        var cities = cityRepository.GetCitiesByState(stateId);
        return Json(new { cities });
    }

}