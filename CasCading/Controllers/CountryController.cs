using CasCading.Repository;
using CasCading.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using System.Text;
using AspNetCore.Reporting;
using CasCading.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CasCading.Controllers;

public class CountryController(ICountryRepository countryRepository , IWebHostEnvironment webHostEnvironment) : Controller
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


    [HttpGet]
    public async Task<ActionResult> Print(CancellationToken cancellationToken)
    {
        var data = await countryRepository.GetAllAsync(cancellationToken);
        string reportName = "TestReport.pdf";
        string reportPath = Path.Combine(webHostEnvironment.ContentRootPath, "Report", "CountryReport.rdlc");
        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        Encoding.GetEncoding("utf-8");
        LocalReport report = new LocalReport(reportPath);
        report.AddDataSource("CountryDataSet", data.ToList());

        Dictionary<string, string> parameters = new Dictionary<string, string>();
        var result = report.Execute(RenderType.Pdf, 2, parameters);
        var content = result.MainStream.ToArray();
        var contentDisposition = new ContentDisposition
        {
            FileName = reportName,
            Inline = true,  
        };
        Response.Headers.Add("Content-Disposition", contentDisposition.ToString());
        return File(content, MediaTypeNames.Application.Pdf);
    }
    [HttpGet]
    public async Task<ActionResult> Print2(int id, CancellationToken cancellationToken)
    {
        var singleData = await countryRepository.GetByIdAsync(id, cancellationToken);
        var data = new List<VmCountry> { singleData }; 

        string reportName = "TestReport.pdf";
        string reportPath = Path.Combine(webHostEnvironment.ContentRootPath, "Report", "CountryReport.rdlc");
        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        Encoding.GetEncoding("utf-8");
        LocalReport report = new LocalReport(reportPath);
        report.AddDataSource("CountryDataSet", data);

        Dictionary<string, string> parameters = new Dictionary<string, string>();
        var result = report.Execute(RenderType.Pdf, 2, parameters);
        var content = result.MainStream.ToArray();
        var contentDisposition = new ContentDisposition
        {
            FileName = reportName,
            Inline = true,
        };
        Response.Headers.Add("Content-Disposition", contentDisposition.ToString());
        return File(content, MediaTypeNames.Application.Pdf);
    }


}
