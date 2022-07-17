using AutoMapper;
using tshreader.core.Domain.Models.Resources;
using tshreader.core.Repository;
using tshreader.services.Models.Resources;

namespace tshreader.services.Services.Resources;

public class TextResourceService : ITextResourceService
{
    #region Ctor

    private readonly IRepository<TextResource> _repository;
    private readonly IMapper _mapper;

    public TextResourceService(IRepository<TextResource> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    #endregion

    public async Task<TextResourceModel> GetResourceAsync(string name)
    {
        var textResource = await _repository.GetAsync((table) => table.Where(r => r.Name == name));
        return _mapper.Map<TextResource, TextResourceModel>(textResource);
    }

    public async Task<TextResourceModel> GetResourceAsync(int id)
    {
        var textResource = await _repository.GetAsync(id);
        return _mapper.Map<TextResource, TextResourceModel>(textResource);
    }

    public async Task AddResourceAsync(TextResourceModel textResourceModel)
    {
        var textResource = _mapper.Map<TextResourceModel, TextResource>(textResourceModel);
        await _repository.AddAsync(textResource);
    }

    public async Task UpdateResourceAsync(TextResourceModel textResourceModel)
    {
        var textResource = _mapper.Map<TextResourceModel, TextResource>(textResourceModel);
        await _repository.UpdateAsync(textResource);
    }

    public async Task DeleteResourceAsync(int id)
    {
        await _repository.DeleteAsync(id);
    }
}
