namespace CarExpress.Models.Entities;

public class RepairData
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public ICollection<Repair> Repairs { get; set; } = [];
}