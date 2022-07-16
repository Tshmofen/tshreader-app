using eLanguage = tshreader.core.Domain.Models.Resource.Language;
namespace tshreader.services.Resource;

public interface ILanguageService
{
    Task<IList<eLanguage>> GetLanguagesAsync();
    Task<eLanguage> GetLanguageAsync(int id);
    Task<eLanguage> GetLanguageAsync(string code2);
}
