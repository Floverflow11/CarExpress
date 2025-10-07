using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CarExpress.Models;
using CarExpress.Models.Repositories;

namespace CarExpress.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    private readonly ICarRepository _carRepository;

    public HomeController(ILogger<HomeController> logger, ICarRepository carRepository)
    {
        _logger = logger;
        _carRepository = carRepository;
    }

    public async Task<IActionResult> Index()
    {
        var cars = await _carRepository.GetCarsAsync();

        var model = cars.Select(car => new CarViewModel(car.Id, car.BoughtPrice + car.RepairCost + 500, car.Year,
            car.Trim.Model.Brand.Name, car.Trim.Model.Name, car.Trim.Name));

        return View(model);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}