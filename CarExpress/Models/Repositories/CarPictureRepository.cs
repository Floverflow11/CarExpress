using CarExpress.Data;
using CarExpress.Models.Entities;

namespace CarExpress.Models.Repositories;

public class CarPictureRepository : ICarPictureRepository
{
    private readonly ApplicationDbContext _context;

    public CarPictureRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Picture picture)
    {
        _context.Pictures.Add(picture);
        await _context.SaveChangesAsync();
    }
}