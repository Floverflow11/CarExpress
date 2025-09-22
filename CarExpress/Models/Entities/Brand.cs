namespace CarExpress.Models.Entities;

public class Brand
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public ICollection<Model> Models { get; set; } = [];
}