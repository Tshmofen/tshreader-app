using AutoMapper;
using tshreader.core.Domain.Models.Settings;
using tshreader.core.Repository;
using tshreader.services.Models.Settings;

namespace tshreader.services.Services.Settings;

public class SettingService : ISettingService
{
    #region Ctor

    private readonly IRepository<Setting> _repository;
    private readonly IMapper _mapper;

    public SettingService(IRepository<Setting> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    #endregion
    public async Task<SettingModel> GetSettingAsync(string name)
    {
        var setting = await _repository.GetAsync((table) => table.Where(s => s.Name == name));
        return _mapper.Map<Setting, SettingModel>(setting);
    }

    public async Task<SettingModel> GetSettingAsync(int id)
    {
        var setting = await _repository.GetAsync(id);
        return _mapper.Map<Setting, SettingModel>(setting);
    }

    public async Task AddSettingAsync(SettingModel settingModel)
    {
        var setting = _mapper.Map<SettingModel, Setting>(settingModel);
        await _repository.AddAsync(setting);
    }

    public async Task UpdateSettingAsync(SettingModel settingModel)
    {
        var setting = _mapper.Map<SettingModel, Setting>(settingModel);
        await _repository.UpdateAsync(setting);
    }

    public async Task DeleteSettingAsync(int id)
    {
        await _repository.DeleteAsync(id);
    }
}
