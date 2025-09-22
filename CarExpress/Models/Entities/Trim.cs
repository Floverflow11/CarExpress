namespace CarExpress.Models.Entities;

public class Trim
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public int ModelId { get; set; }
    public Model Model { get; set; } = null!;
}