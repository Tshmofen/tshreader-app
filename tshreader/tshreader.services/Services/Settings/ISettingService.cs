namespace tshreader.services.Services.Settings;

public interface ISettingService
{
    Task<string> GetSettingAsync(string name);
    Task SetSettingAsync(string name, string value);
    Task DeleteSettingAsync(string name);
}
