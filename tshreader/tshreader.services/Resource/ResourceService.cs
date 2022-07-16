using eResource = tshreader.core.Domain.Models.Resource.Resource;
using tshreader.core.Repository;

namespace tshreader.services.Resource;

internal class ResourceService : IResourceService
{
    #region Ctor

    private readonly IRepository<eResource> _repository;

    public ResourceService(IRepository<eResource> repository)
    {
        _repository = repository;
    }

    #endregion

    public async Task<eResource> GetResourceAsync(string name)
    {
        return await _repository.GetAsync((table) => table.Where(r => r.Name == name));
    }

    public async Task<eResource> GetResourceAsync(int id)
    {
        return await _repository.GetAsync(id);
    }

    public async Task AddResourceAsync(eResource resource)
    {
        await _repository.AddAsync(resource);
    }

    public async Task UpdateResourceAsync(eResource resource)
    {
        await _repository.UpdateAsync(resource);
    }

    public async Task DeleteResourceAsync(int id)
    {
        await _repository.DeleteAsync(id);
    }
}
