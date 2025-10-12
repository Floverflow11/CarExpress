using CarExpress.Models.Entities;

namespace CarExpress.Models.Services;

public interface IImageUploadService
{
    Task<Picture> SaveAsync(IFormFile image, int carId);
}