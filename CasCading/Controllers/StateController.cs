using CasCading.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CasCading.Controllers;

public class StateController(IStateRepository stateRepository) : Controller
{
    public async Task<IActionResult> Index(CancellationToken cancellationToken)
    {
        return View(await stateRepository.GetAllAsync(cancellationToken));
    }
}