namespace CarExpress.Models.Entities;

public class Picture
{
    public int Id { get; set; }
    public required string FileName { get; set; }
    public required string FilePath { get; set; }
    public int CarId { get; set; }
}