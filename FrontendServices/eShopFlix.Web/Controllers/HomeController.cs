using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using eShopFlix.Web.Models;
using eShopFlix.Web.HttpClients;

namespace eShopFlix.Web.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    CatalogServiceClient _catalogServiceClient;
    public HomeController(ILogger<HomeController> logger, CatalogServiceClient catalogServiceClient)
    {
        _logger = logger;
        _catalogServiceClient = catalogServiceClient;
    }

    public IActionResult Index()
    {
        var product = _catalogServiceClient.GetProducts().Result;
        return View(product);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
