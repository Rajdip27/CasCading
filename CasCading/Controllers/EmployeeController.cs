using CasCading.Repository;
using CasCading.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace CasCading.Controllers;

public class EmployeeController(IEmployeeRepository employeeRepository) : Controller
{
    public async Task<IActionResult> Index( CancellationToken cancellationToken)
    {
        return View(await employeeRepository.GetAllAsync(cancellationToken));
    }

    public async Task<IActionResult> CreateOrEdit(int id,CancellationToken cancellationToken)
    {
        if (id == 0)
        {
            return View(new VmEmployee());
        }
        else
        {
            return View(await employeeRepository.GetByIdAsync(id, cancellationToken));
        }

    }
    
}