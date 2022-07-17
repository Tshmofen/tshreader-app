using AutoMapper;
using tshreader.core.Domain.Models.Resources;
using tshreader.core.Repository;
using tshreader.services.Models.Resources;

namespace tshreader.services.Services.Resources;

public class LanguageService : ILanguageService
{
    #region Ctor

    private readonly IRepository<Language> _repository;
    private readonly IMapper _mapper;

    public LanguageService(IRepository<Language> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    #endregion

    public async Task<IList<LanguageModel>> GetLanguagesAsync()
    {
        var languages = await _repository.GetAllAsync();
        return languages
            .Select(l => _mapper.Map<Language, LanguageModel>(l))
            .ToList();
    }

    public async Task<LanguageModel> GetLanguageAsync(int id)
    {
        var language = await _repository.GetAsync(id);
        return _mapper.Map<Language, LanguageModel>(language);
    }

    public async Task<LanguageModel> GetLanguageAsync(string code2)
    {
        var language = await _repository.GetAsync((table) => table.Where(l => l.Code2 == code2));
        return _mapper.Map<Language, LanguageModel>(language);
    }
}
