using tshreader.core.Domain.Models.Settings;
using tshreader.core.Repository;

namespace tshreader.services.Services.Settings;

public class SettingService : ISettingService
{
    #region Ctor

    private readonly IRepository<Setting> _repository;

    public SettingService(IRepository<Setting> repository)
    {
        _repository = repository;
    }

    #endregion
    public async Task<string> GetSettingAsync(string name)
    {
        if (name == null)
        {
            throw new ArgumentNullException(nameof(name));
        }

        var setting = await _repository.GetAsync((table) => table.Where(s => s.Name == name));
        return setting?.Value;
    }

    public async Task SetSettingAsync(string name, string value)
    {
        if (name == null)
        {
            throw new ArgumentNullException(nameof(name));
        }

        if (value == null)
        {
            throw new ArgumentNullException(nameof(value));
        }

        var existingSetting = await _repository.GetAsync((table) => table.Where(s => s.Name == name));
        if (existingSetting == null)
        {
            await _repository.AddAsync(new Setting
            {
                Name = name,
                Value = value
            });
        }
        else
        {
            existingSetting.Value = value;
            await _repository.UpdateAsync(existingSetting);
        }
    }

    public async Task DeleteSettingAsync(string name)
    {
        if (name == null)
        {
            throw new ArgumentNullException(nameof(name));
        }

        await _repository.DeleteAsync((table) => table.Where(s => s.Name == name));
    }
}
