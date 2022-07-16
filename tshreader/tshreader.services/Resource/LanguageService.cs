using tshreader.core.Repository;
using eLanguage = tshreader.core.Domain.Models.Resource.Language;

namespace tshreader.services.Resource;

internal class LanguageService : ILanguageService
{
    #region Ctor

    private readonly IRepository<eLanguage> _repository;

    public LanguageService(IRepository<eLanguage> repository)
    {
        _repository = repository;
    }

    #endregion

    public async Task<IList<eLanguage>> GetLanguagesAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<eLanguage> GetLanguageAsync(int id)
    {
        return await _repository.GetAsync(id);
    }

    public async Task<eLanguage> GetLanguageAsync(string code2)
    {
        return await _repository.GetAsync((table) => table.Where(l => l.Code2 == code2));
    }
}
