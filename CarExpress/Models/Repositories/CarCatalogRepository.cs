using CarExpress.Data;
using CarExpress.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarExpress.Models.Repositories;

public class CarCatalogRepository : ICarCatalogRepository
{
    private readonly ApplicationDbContext _context;

    public CarCatalogRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Brand> GetOrCreateBrandAsync(string name)
    {
        var brand = await _context.Brands.SingleOrDefaultAsync(brand => brand.Name == name);

        if (brand != null)
        {
            return brand;
        }

        brand = new Brand { Name = name };
        await AddBrandAsync(brand);

        return brand;
    }

    public async Task<Model> GetOrCreateModelAsync(string name, int brandId)
    {
        var model = await _context.Models.SingleOrDefaultAsync(model => model.Name == name && model.BrandId == brandId);

        if (model != null)
        {
            return model;
        }

        model = new Model { Name = name, BrandId = brandId };
        await AddModelAsync(model);

        return model;
    }

    public async Task<Trim> GetOrCreateTrimAsync(string name, int modelId)
    {
        var trim = await _context.Trims.SingleOrDefaultAsync(trim => trim.Name == name && trim.ModelId == modelId);

        if (trim != null)
        {
            return trim;
        }

        trim = new Trim { Name = name, ModelId = modelId };
        await AddTrimAsync(trim);

        return trim;
    }

    public async Task<List<Brand>> GetBrandsAsync()
    {
        return await _context.Brands.ToListAsync();
    }
    
    public async Task<List<Model>> GetModelsAsync()
    {
        return await _context.Models.ToListAsync();
    }
    
    public async Task<List<Trim>> GetTrimsAsync()
    {
        return await _context.Trims.ToListAsync();
    }

    private async Task AddBrandAsync(Brand brand)
    {
        _context.Brands.Add(brand);
        await _context.SaveChangesAsync();
    }

    private async Task AddModelAsync(Model model)
    {
        _context.Models.Add(model);
        await _context.SaveChangesAsync();
    }

    private async Task AddTrimAsync(Trim trim)
    {
        _context.Trims.Add(trim);
        await _context.SaveChangesAsync();
    }
}