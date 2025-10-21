using CarExpress.Models.Entities;

namespace CarExpress.Models.Repositories;

public interface ICarCatalogRepository
{
    Task<Brand> GetOrCreateBrandAsync(string name);
    Task<Model> GetOrCreateModelAsync(string name, int brandId);
    Task<Trim> GetOrCreateTrimAsync(string name, int modelId);
    Task<List<Brand>> GetBrandsAsync();
    Task<List<Model>> GetModelsAsync();
    Task<List<Trim>> GetTrimsAsync();
}