using tshreader.services.Models.Settings;
namespace tshreader.services.Services.Settings;

public interface ISettingService
{
    Task<SettingModel> GetSettingAsync(string name);
    Task<SettingModel> GetSettingAsync(int id);
    Task AddSettingAsync(SettingModel settingModel);
    Task UpdateSettingAsync(SettingModel settingModel);
    Task DeleteSettingAsync(int id);
}
