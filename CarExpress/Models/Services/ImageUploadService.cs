using CarExpress.Models.Entities;

namespace CarExpress.Models.Services;

public class ImageUploadService : IImageUploadService
{
    private readonly IWebHostEnvironment _webHostEnvironment;

    private readonly string[] _acceptedExtensions = [".jpeg", ".jpg", ".png"];

    public ImageUploadService(IWebHostEnvironment webHostEnvironment)
    {
        _webHostEnvironment = webHostEnvironment;
    }

    public async Task<Picture> SaveAsync(IFormFile image, int carId)
    {
        var extension = Path.GetExtension(image.FileName);

        if (!_acceptedExtensions.Contains(extension.ToLowerInvariant()))
        {
            throw new NotSupportedException("File extension is not supported.");
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