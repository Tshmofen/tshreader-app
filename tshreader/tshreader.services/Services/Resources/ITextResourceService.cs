using tshreader.services.Models.Resources;

namespace tshreader.services.Services.Resources;

public interface ITextResourceService
{
    Task<TextResourceModel> GetResourceAsync(string name);
    Task<TextResourceModel> GetResourceAsync(int id);
    Task AddResourceAsync(TextResourceModel textResourceModel);
    Task UpdateResourceAsync(TextResourceModel textResourceModel);
    Task DeleteResourceAsync(int id);
}
