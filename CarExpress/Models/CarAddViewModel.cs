namespace CarExpress.Models;

public record CarAddViewModel(decimal BoughtPrice, decimal RepairCost, int Year, string Brand, string Model, string Trim, IFormFile Image);