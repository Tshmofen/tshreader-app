using eSetting = tshreader.core.Domain.Models.Setting.Setting;
namespace tshreader.services.Setting;

public interface ISettingService
{
    Task<eSetting> GetSettingAsync(string name);
    Task<eSetting> GetSettingAsync(int id);
    Task AddSettingAsync(eSetting setting);
    Task UpdateSettingAsync(eSetting setting);
    Task DeleteSettingAsync(int id);
}
