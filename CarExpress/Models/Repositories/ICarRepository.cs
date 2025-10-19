using CarExpress.Models.Entities;

namespace CarExpress.Models.Repositories;

public interface ICarRepository
{
    Task<Car?> GetCarAsync(int id);
    Task<IList<Car>> GetCarsAsync();
    Task DeleteCarAsync(Car car);
    Task AddCarAsync(Car car);
    Task SaveChangesAsync();
}