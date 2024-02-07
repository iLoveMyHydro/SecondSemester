using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

public class BaseViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;

    public BaseViewModel()
    {
        PropertyChanged = (sender, e) => { };
    }

    protected void Update<T>(ref T source, T value, [CallerMemberName] string propertyName = null)
    {
        if (source.Equals(value)) return;

        source = value;
        PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    protected void Update<T>(Func<T> get, Action<T> set, T value, [CallerMemberName] string propertyName = null)
    {
        set.Invoke(value);
        PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    protected void Update(Func<bool> get, Action<bool> set, bool value, [CallerMemberName] string propertyName = null)
    {
        set.Invoke(value);
        PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    protected void Update(Func<object> get, Action<object> set, object value, [CallerMemberName] string propertyName = null)
    {
        set.Invoke(value);
        PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}