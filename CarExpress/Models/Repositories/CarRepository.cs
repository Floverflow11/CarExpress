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
            .Include(car => car.Trim)
            .ThenInclude(car => car.Model)
            .ThenInclude(car => car.Brand)
            .SingleOrDefaultAsync(car => car.Id == id);

        return car;
    }

    public async Task<IList<Car>> GetCarsAsync()
    {
        var cars = await _context.Cars
            .Include(car => car.Trim)
            .ThenInclude(car => car.Model)
            .ThenInclude(car => car.Brand)
            .ToListAsync();

        return cars;
    }
    
    public async Task DeleteCarAsync(Car car)
    {
        _context.Cars.Remove(car);
        await _context.SaveChangesAsync();
    }
}