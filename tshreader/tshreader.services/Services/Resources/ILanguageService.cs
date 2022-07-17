using tshreader.services.Models.Resources;
namespace tshreader.services.Services.Resources;

public interface ILanguageService
{
    Task<IList<LanguageModel>> GetLanguagesAsync();
    Task<LanguageModel> GetLanguageAsync(int id);
    Task<LanguageModel> GetLanguageAsync(string code2);
}
