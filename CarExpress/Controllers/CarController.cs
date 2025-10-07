using CarExpress.Models;
using CarExpress.Models.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CarExpress.Controllers;

public class CarController : Controller
{
    private readonly ICarRepository _carRepository;

    public CarController(ICarRepository carRepository)
    {
        _carRepository = carRepository;
    }

    public async Task<IActionResult> Details(int id)
    {
        var car = await _carRepository.GetCarAsync(id);

        if (car == null)
        {
            return NotFound();
        }

        var model = new CarDetailsViewModel(car.Id, car.BoughtPrice + car.RepairCost + 500, car.Year,
            car.Trim.Model.Brand.Name, car.Trim.Model.Name, car.Trim.Name);

        return View(model);
    }
}