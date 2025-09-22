namespace CarExpress.Models.Entities;

public class Sale
{
    public int Id { get; set; }
    public decimal Price { get; set; }
    public DateTime Date { get; set; }
    public int CarId { get; set; }
    public Car Car { get; set; } = null!;
}