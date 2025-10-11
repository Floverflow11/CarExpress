using CarExpress.Models;
using CarExpress.Models.Repositories;
using Microsoft.AspNetCore.Authorization;
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

    [Authorize]
    [ValidateAntiForgeryToken]
    [HttpPost]
    public async Task<IActionResult> Delete(int id)
    {
        var car = await _carRepository.GetCarAsync(id);

        if (car == null)
        {
            return NotFound();
        }

        TempData["DeletedCarId"] = id;
        TempData["DeletedCarYear"] = car.Year;
        TempData["DeletedCarBrand"] = car.Trim.Model.Brand.Name;
        TempData["DeletedCarModel"] = car.Trim.Model.Name;
        TempData["DeletedCarTrim"] = car.Trim.Name;

        await _carRepository.DeleteCarAsync(car);

        return RedirectToAction("Deleted");
    }

    public IActionResult Deleted()
    {
        var id = TempData["DeletedCarId"];
        var year = TempData["DeletedCarYear"];
        var brand = TempData["DeletedCarBrand"];
        var model = TempData["DeletedCarModel"];
        var trim = TempData["DeletedCarTrim"];

        if (id == null || year == null || brand == null || model == null || trim == null)
        {
            return RedirectToAction("Index", "Home");
        }

        var vm = new CarDeletedViewModel((int)year, brand.ToString()!, model.ToString()!, trim.ToString()!);

        return View(vm);
    }
}