namespace CarExpress.Models.Entities;

public class Repair
{
    public int Id { get; set; }
    public int RepairDataId { get; set; }
    public RepairData RepairData { get; set; } = null!;
    public ICollection<Car> Cars { get; set; } = [];
}