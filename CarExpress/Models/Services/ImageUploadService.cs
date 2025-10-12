using CarExpress.Models.Entities;

namespace CarExpress.Models.Services;

public class ImageUploadService : IImageUploadService
{
    private readonly IWebHostEnvironment _webHostEnvironment;

    private const string AcceptedExtension = ".jpeg";

    public ImageUploadService(IWebHostEnvironment webHostEnvironment)
    {
        _webHostEnvironment = webHostEnvironment;
    }

    public async Task<Picture> SaveAsync(IFormFile image, int carId)
    {
        var extension = Path.GetExtension(image.FileName);

        if (!string.Equals(extension, AcceptedExtension, StringComparison.InvariantCultureIgnoreCase))
        {
            throw new InvalidOperationException($"Extension doesn't match {nameof(AcceptedExtension)}");
        }

        var imageFolder = Path.Combine(_webHostEnvironment.WebRootPath, "img", "cars");
        Directory.CreateDirectory(imageFolder);
        
        var generatedFileName = $"{carId}_{Guid.NewGuid()}{extension}";

        var path = Path.Combine(imageFolder, generatedFileName);

        await using var stream = new FileStream(path, FileMode.Create);
        await image.CopyToAsync(stream);

        var relativePath = Path.GetRelativePath(_webHostEnvironment.WebRootPath, path);

        return new Picture { FileName = generatedFileName, FilePath = relativePath, CarId = carId };
    }
}