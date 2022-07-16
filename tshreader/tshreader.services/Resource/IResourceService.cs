using eResource = tshreader.core.Domain.Models.Resource.Resource;
namespace tshreader.services.Resource;

public interface IResourceService
{
    Task<eResource> GetResourceAsync(string name);
    Task<eResource> GetResourceAsync(int id);
    Task AddResourceAsync(eResource resource);
    Task UpdateResourceAsync(eResource resource);
    Task DeleteResourceAsync(int id);
}
