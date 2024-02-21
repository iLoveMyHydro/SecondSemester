using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

/// <summary>
/// MVVM MODEL BASE IS FROM MARCUS SCHAAL 
/// MADE WITH HIM IN OCE
/// </summary>
public class BaseViewModel : INotifyPropertyChanged
{
    #region Event PropChangedEventHandler

    /// <summary>
    /// Event "Method" if the Property Value Changed
    /// </summary>
    public event PropertyChangedEventHandler PropertyChanged;

    #endregion

    #region Constructor

    public BaseViewModel()
    {
        PropertyChanged = (sender, e) => { };
    }

    #endregion

    #region Updates

    #region Update<T> 
    /// <summary>
    /// Set the Value of the Property if the Value changed 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="get"></param>
    /// <param name="set"></param>
    /// <param name="value"></param>
    /// <param name="propertyName"></param>
    protected void Update<T>(Func<T> get, Action<T> set, T value, [CallerMemberName] string propertyName = null)
    {
        set.Invoke(value);
        PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    #endregion

    #endregion
}