using tshreader.core.Domain.Defaults;
using tshreader.services.Services.Settings;

namespace tshreader.ViewModels.Common;

public class SettingsViewModel : BaseViewModel
{
    #region Fields

    private readonly ISettingService _settingService;

    private string _currentFolder;

    public string CurrentFolder
    {
        get => _currentFolder;
        set => SetProperty(ref _currentFolder, value);
    }

    public Command SelectFolderCommand { get; set; }
    public Command SetFolderCommand { get; set; }
    public Command LoadCurrentFolderCommand { get; set; }

    #endregion

    #region Ctor
    public SettingsViewModel(ISettingService settingService)
    {
        _settingService = settingService;
        Title = "Settings";

        LoadCurrentFolderCommand = new Command(async () => await LoadCurrentFolderAsync());
        SelectFolderCommand = new Command(async () => await SelectFolderAsync());
        SetFolderCommand = new Command(async () => await SetFolderAsync());

        LoadCurrentFolderCommand.Execute(null);
    }

    #endregion

    #region Commands 

    private async Task SelectFolderAsync()
    {
        var result = await FilePicker.PickAsync();
        if (result != null)
        {
            CurrentFolder = Path.GetDirectoryName(result.FullPath);
            await _settingService.SetSettingAsync(SettingsDefaults.CurrentBooksFolderSetting, CurrentFolder);
        }
    }

    private async Task SetFolderAsync()
    {
        var invalidChars = Path.GetInvalidPathChars();
        if (CurrentFolder.Any(s => invalidChars.Contains(s)))
        {
            await LoadCurrentFolderAsync();
        }
        else
        {
            await _settingService.SetSettingAsync(SettingsDefaults.CurrentBooksFolderSetting, CurrentFolder);
        }
    }

    private async Task LoadCurrentFolderAsync()
    {
        var folder = await _settingService.GetSettingAsync(SettingsDefaults.CurrentBooksFolderSetting);
        CurrentFolder = folder ?? string.Empty;
    }

    #endregion
}
