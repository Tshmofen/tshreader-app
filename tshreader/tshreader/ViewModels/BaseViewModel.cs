using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace tshreader.ViewModels;

public abstract class BaseViewModel : INotifyPropertyChanged
{
    private string _title;
    public string Title 
    { 
        get => _title;
        set => SetProperty(ref _title, value);
    }

    #region property change

    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void SetProperty<T>(ref T property, T value, Action changeAction = null, [CallerMemberName] string propertyName = "")
    {
        if (EqualityComparer<T>.Default.Equals(property, value))
        {
            return;
        }

        property = value;
        changeAction?.Invoke();
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    #endregion

    #region Behavior

    public virtual void OnPageAppear() { }

    public virtual void OnPageDisappear() { }

    #endregion
}