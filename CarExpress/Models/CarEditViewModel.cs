using System.ComponentModel.DataAnnotations;

namespace CarExpress.Models;

public record CarEditViewModel(int Id,
    [Required(ErrorMessage = "*")] decimal BoughtPrice,
    [Required(ErrorMessage = "*")] decimal RepairCost,
    [Required(ErrorMessage = "*")]
    [Range(1990, 2025, ErrorMessage = "L'année doit être comprise entre 1990 et 2025.")]
    int Year,
    bool IsAvailable, [MaxLength(3000, ErrorMessage = "Limite de caractères atteinte.")] string? Description, IFormFile? Image, string? CurrentImagePath);