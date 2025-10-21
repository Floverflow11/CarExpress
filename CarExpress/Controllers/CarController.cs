using CarExpress.Models;
using CarExpress.Models.Entities;
using CarExpress.Models.Repositories;
using CarExpress.Models.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarExpress.Controllers;

public class CarController : Controller
{
    private readonly ICarRepository _carRepository;
    private readonly ICarCatalogRepository _carCatalogRepository;
    private readonly ICarPictureRepository _carPictureRepository;
    private readonly IImageUploadService _imageUploadService;

    public CarController(ICarRepository carRepository, ICarCatalogRepository carCatalogRepository,
        ICarPictureRepository carPictureRepository, IImageUploadService imageUploadService)
    {
        _carRepository = carRepository;
        _carCatalogRepository = carCatalogRepository;
        _carPictureRepository = carPictureRepository;
        _imageUploadService = imageUploadService;
    }

    [HttpGet]
    public async Task<IActionResult> Details(int id)
    {
        var car = await _carRepository.GetCarAsync(id);

        if (car == null)
        {
            return NotFound();
        }

        if (User.Identity?.IsAuthenticated != true && !_carRepository.CanBeSeenByVisitors(car))
        {
            return NotFound();
        }

        var model = new CarDetailsViewModel(car.Id, car.BoughtPrice + car.RepairCost + 500, car.Year,
            car.Trim.Model.Brand.Name, car.Trim.Model.Name, car.Trim.Name,
            car.Pictures.Select(pic => new CarPictureViewModel(pic.FileName, pic.FilePath)));

        return View(model);
    }

    [HttpGet]
    [Authorize]
    public IActionResult Add()
    {
        return View();
    }

    [HttpPost]
    [Authorize]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Add(CarAddViewModel viewModel)
    {
        if (!ModelState.IsValid)
        {
            return View(viewModel);
        }

        var brands = await _carCatalogRepository.GetBrandsAsync();
        var models = await _carCatalogRepository.GetModelsAsync();
        var trims = await _carCatalogRepository.GetTrimsAsync();

        if (models.Any(m => string.Equals(m.Name, viewModel.Brand, StringComparison.OrdinalIgnoreCase)) ||
            trims.Any(t => string.Equals(t.Name, viewModel.Brand, StringComparison.OrdinalIgnoreCase)))
        {
            ModelState.AddModelError(nameof(viewModel.Brand), "Marque invalide.");
        }
        
        if (brands.Any(b => string.Equals(b.Name, viewModel.Model, StringComparison.OrdinalIgnoreCase)) ||
            trims.Any(t => string.Equals(t.Name, viewModel.Model, StringComparison.OrdinalIgnoreCase)))
        {
            ModelState.AddModelError(nameof(viewModel.Model), "Modèle invalide.");
        }
        
        if (brands.Any(b => string.Equals(b.Name, viewModel.Trim, StringComparison.OrdinalIgnoreCase)) ||
            models.Any(m => string.Equals(m.Name, viewModel.Trim, StringComparison.OrdinalIgnoreCase)))
        {
            ModelState.AddModelError(nameof(viewModel.Trim), "Finition invalide.");
        }

        if (!ModelState.IsValid)
        {
            return View(viewModel);
        }

        var brand = await _carCatalogRepository.GetOrCreateBrandAsync(viewModel.Brand);
        var model = await _carCatalogRepository.GetOrCreateModelAsync(viewModel.Model, brand.Id);
        var trim = await _carCatalogRepository.GetOrCreateTrimAsync(viewModel.Trim, model.Id);

        var car = new Car
        {
            Year = viewModel.Year,
            BoughtDate = DateOnly.FromDateTime(DateTime.Now),
            BoughtPrice = viewModel.BoughtPrice,
            RepairCost = viewModel.RepairCost,
            IsAvailable = true,
            TrimId = trim.Id
        };

        await _carRepository.AddCarAsync(car);

        var picture = await _imageUploadService.SaveAsync(viewModel.Image, car.Id);

        await _carPictureRepository.AddAsync(picture);

        TempData["AddedCarId"] = car.Id;

        return RedirectToAction("Added");
    }

    [HttpGet]
    public IActionResult Added()
    {
        if (TempData["AddedCarId"] == null)
        {
            return RedirectToAction("Index", "Home");
        }

        return View();
    }

    [HttpPost]
    [Authorize]
    [ValidateAntiForgeryToken]
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

    [HttpGet]
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

    [HttpGet]
    [Authorize]
    public async Task<IActionResult> Edit(int id)
    {
        var car = await _carRepository.GetCarAsync(id);

        if (car == null)
        {
            return NotFound();
        }

        var picture = car.Pictures.FirstOrDefault();

        var vm = new CarEditViewModel(car.Id, car.BoughtPrice, car.RepairCost, car.Year, car.IsAvailable,
            car.Description, null, picture?.FilePath);

        return View(vm);
    }

    [HttpPost]
    [Authorize]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(CarEditViewModel viewModel)
    {
        if (!ModelState.IsValid)
        {
            return View(viewModel);
        }

        var car = await _carRepository.GetCarAsync(viewModel.Id);

        if (car == null)
        {
            return NotFound();
        }

        car.BoughtPrice = viewModel.BoughtPrice;
        car.RepairCost = viewModel.RepairCost;
        car.Year = viewModel.Year;
        car.IsAvailable = viewModel.IsAvailable;
        car.Description = string.IsNullOrWhiteSpace(viewModel.Description) ? null : viewModel.Description.Trim();

        if (viewModel.Image != null)
        {
            var picture = await _imageUploadService.SaveAsync(viewModel.Image, car.Id);

            await _carPictureRepository.AddAsync(picture);

            car.Pictures = [picture];
        }

        await _carRepository.SaveChangesAsync();

        return RedirectToAction("Details", new { id = car.Id });
    }
}