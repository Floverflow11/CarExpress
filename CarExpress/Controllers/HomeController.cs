using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CarExpress.Models;
using CarExpress.Models.Entities;
using CarExpress.Models.Repositories;

namespace CarExpress.Controllers;

public class HomeController : Controller
{
    private readonly ICarRepository _carRepository;

    public HomeController(ICarRepository carRepository)
    {
        _carRepository = carRepository;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        List<Car> cars;
        
        if (User.Identity?.IsAuthenticated == true)
        {
            cars = await _carRepository.GetCarsAsync();
        }
        else
        {
            cars = await _carRepository.GetVisitorCarsAsync();
        }
        
        var model = cars.Select(car => new CarViewModel(car.Id, car.BoughtPrice + car.RepairCost + 500,
            car.Year,
            car.Trim.Model.Brand.Name, car.Trim.Model.Name, car.Trim.Name,
            car.Pictures.Select(pic => new CarPictureViewModel(pic.FileName, pic.FilePath))));

        return View(model);
    }

    [HttpGet]
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}