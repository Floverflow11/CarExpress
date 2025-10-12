namespace CarExpress.Models;

public record CarDetailsViewModel(int Id, decimal Price, int Year, string Brand, string Model, string Trim, IEnumerable<CarPictureViewModel> Pictures);