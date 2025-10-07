using CarExpress.Models.Entities;

namespace CarExpress.Models.Repositories;

public interface ICarRepository
{
    Task<Car?> GetCarAsync(int id);
    
    Task <IList<Car>> GetCarsAsync();
}