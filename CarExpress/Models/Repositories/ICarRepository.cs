using CarExpress.Models.Entities;

namespace CarExpress.Models.Repositories;

public interface ICarRepository
{
    Task<Car?> GetCarAsync(int id);
    Task<List<Car>> GetCarsAsync();
    Task<List<Car>> GetVisitorCarsAsync();
    bool CanBeSeenByVisitors(Car car);
    Task DeleteCarAsync(Car car);
    Task AddCarAsync(Car car);
    Task SaveChangesAsync();
}