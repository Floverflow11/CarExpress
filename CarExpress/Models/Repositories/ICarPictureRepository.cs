using CarExpress.Models.Entities;

namespace CarExpress.Models.Repositories;

public interface ICarPictureRepository
{
    Task AddAsync(Picture picture);
}