using UnityEngine;

public class ObjectViewModel : BaseViewModel
{
    public ObjectModel _Target;

    #region Number
    public float MinNumber
    {
        get => _Target.MinNumberValue;
        set => Update(() => _Target.MinNumberValue, val => _Target.MinNumberValue = val, value);
    }

    public float MaxNumber
    {
        get => _Target.MaxNumberValue;
        set => Update(() => _Target.MaxNumberValue, val => _Target.MaxNumberValue = val, value);
    }

    public float SliderNumber
    {
        get => _Target.SliderNumber;
        set => Update(() => _Target.SliderNumber, val => _Target.SliderNumber = val, value);
    }

    #endregion

    #region Density

    public float MinDensity
    {
        get => _Target.MinDensityValue;
        set => Update(() => _Target.MinDensityValue, val => _Target.MinDensityValue = val, value);
    }

    public float MaxDensity
    {
        get => _Target.MaxDensityValue;
        set => Update(() => _Target.MaxDensityValue, val => _Target.MaxDensityValue = val, value);
    }

    public float SliderDensity
    {
        get => _Target.SliderDensity;
        set => Update(() => _Target.SliderDensity, val => _Target.SliderDensity = val, value);
    }

    #endregion

    #region Size

    public float MinSize
    {
        get => _Target.MinSizeValue;
        set => Update(() => _Target.MinSizeValue, val => _Target.MinSizeValue = val, value);
    }

    public float MaxSize
    {
        get => _Target.MaxSizeValue;
        set => Update(() => _Target.MaxSizeValue, val => _Target.MaxSizeValue = val, value);
    }

    public float SliderSize
    {
        get => _Target.SliderSize;
        set => Update(() => _Target.SliderSize, val => _Target.SliderSize = val, value);
    }

    #endregion

    #region Brush

    public float MinBrush
    {
        get => _Target.MinBrushValue;
        set => Update(() => _Target.MinBrushValue, val => _Target.MinBrushValue = val, value);
    }

    public float MaxBrush
    {
        get => _Target.MaxBrushValue;
        set => Update(() => _Target.MaxBrushValue, val => _Target.MaxBrushValue = val, value);
    }

    public float SliderBrush
    {
        get => _Target.SliderBrush;
        set => Update(() => _Target.SliderBrush, val => _Target.SliderBrush = val, value);
    }

    #endregion

    #region Activate Circle

    public bool ActivateCircle
    {
        get => _Target.ActivateCircle;
        set => Update(() => _Target.ActivateCircle, val => _Target.ActivateCircle = val, value);
    }

    #endregion

    #region GameObject

    public object GameObject
    {
        get => _Target.GameObject;
        set => Update(() => _Target.GameObject, val => _Target.GameObject = (GameObject)val, value);
    }

    #endregion

    public void DrawCircle()
    {
        if(_Target.ActivateCircle)
        {
            
        }
    }

    public void SizeCircle()
    {

    }

    public void PlaceObject()
    {

    }

    public void Delete”bject()
    {

    }

    public void CalculateHeight()
    {

    }


    public ObjectViewModel()
    {
        _Target = new();
    }
}