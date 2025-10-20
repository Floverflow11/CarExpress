using CarExpress.Data;
using CarExpress.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarExpress.Models.Repositories;

public class CarRepository : ICarRepository
{
    private readonly ApplicationDbContext _context;

    public CarRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Car?> GetCarAsync(int id)
    {
        var car = await _context.Cars
            .Include(car => car.Pictures)
            .Include(car => car.Trim)
            .ThenInclude(car => car.Model)
            .ThenInclude(car => car.Brand)
            .SingleOrDefaultAsync(car => car.Id == id);

        return car;
    }

    public async Task<List<Car>> GetCarsAsync()
    {
        var cars = await _context.Cars
            .Include(car => car.Pictures)
            .Include(car => car.Trim)
            .ThenInclude(car => car.Model)
            .ThenInclude(car => car.Brand)
            .ToListAsync();

        return cars;
    }

    public async Task<List<Car>> GetVisitorCarsAsync()
    {
        var today = DateOnly.FromDateTime(DateTime.UtcNow);

        var cars = await _context.Cars.Where(car => !car.IsSold && car.IsAvailable && car.CanBeSoldFromDate <= today)
            .Include(car => car.Pictures)
            .Include(car => car.Trim)
            .ThenInclude(car => car.Model)
            .ThenInclude(car => car.Brand)
            .ToListAsync();

        return cars;
    }

    public bool CanBeSeenByVisitors(Car car)
    {
        var date = DateOnly.FromDateTime(DateTime.UtcNow);
        
        return car is { IsSold: false, IsAvailable: true } && car.CanBeSoldFromDate <= date;
    }

    public async Task DeleteCarAsync(Car car)
    {
        _context.Cars.Remove(car);
        await SaveChangesAsync();
    }

    public async Task AddCarAsync(Car car)
    {
        await _context.Cars.AddAsync(car);
        await SaveChangesAsync();
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}