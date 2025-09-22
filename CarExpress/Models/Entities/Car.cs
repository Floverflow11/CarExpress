namespace CarExpress.Models.Entities;

public class Car
{
    public int Id { get; set; }
    public string? Vin { get; set; }
    public int Year { get; set; }
    public string? Description { get; set; }
    public DateOnly BoughtDate { get; set; }
    public decimal BoughtPrice { get; set; }
    public decimal RepairCost { get; set; }
    public DateOnly? CanBeSoldFromDate { get; set; }
    public bool IsSold { get; set; }
    public bool IsAvailable { get; set; }
    public int TrimId { get; set; }
    public Trim Trim { get; set; } = null!;
    public ICollection<Picture> Pictures { get; set; } = [];
    public Sale? Sale { get; set; }
    public ICollection<Repair> Repairs { get; set; } = [];
}