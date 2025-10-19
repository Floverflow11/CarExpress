using System.ComponentModel.DataAnnotations;

namespace CarExpress.Models;

public record CarAddViewModel(
    [Required(ErrorMessage = "*")] decimal BoughtPrice,
    [Required(ErrorMessage = "*")] decimal RepairCost,
    [Required(ErrorMessage = "*")]
    [Range(1990, 2025, ErrorMessage = "L'année doit être comprise entre 1990 et 2025.")]
    int Year,
    [Required(ErrorMessage = "*")] string Brand,
    [Required(ErrorMessage = "*")] string Model,
    [Required(ErrorMessage = "*")] string Trim,
    [Required(ErrorMessage = "*")] IFormFile Image);