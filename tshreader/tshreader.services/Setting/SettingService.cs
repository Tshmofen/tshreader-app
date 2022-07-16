using eSetting = tshreader.core.Domain.Models.Setting.Setting;
using tshreader.core.Repository;

namespace tshreader.services.Setting;

internal class SettingService : ISettingService
{
    #region Ctor

    private readonly IRepository<eSetting> _repository;

    public SettingService(IRepository<eSetting> repository)
    {
        _repository = repository;
    }

    #endregion
    public async Task<eSetting> GetSettingAsync(string name)
    {
        return await _repository.GetAsync((table) => table.Where(s => s.Name == name));
    }

    public async Task<eSetting> GetSettingAsync(int id)
    {
        return await _repository.GetAsync(id);
    }

    public async Task AddSettingAsync(eSetting setting)
    {
        await _repository.AddAsync(setting);
    }

    public async Task UpdateSettingAsync(eSetting setting)
    {
        await _repository.UpdateAsync(setting);
    }

    public async Task DeleteSettingAsync(int id)
    {
        await _repository.DeleteAsync(id);
    }
}
