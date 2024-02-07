using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectModel : MonoBehaviour
{
    #region Parameter

    #region Number

    public float MinNumberValue { get; set; } = 0f;
    public float MaxNumberValue { get; set; } = 1f;
    public float SliderNumber { get; set; } = 0f;

    #endregion

    #region Density

    public float MinDensityValue { get; set; } = 0f;
    public float MaxDensityValue { get; set; } = 1f;
    public float SliderDensity { get; set; } = 0f;

    #endregion

    #region Size

    public float MinSizeValue { get; set; } = 0f;
    public float MaxSizeValue { get; set; } = 1f;
    public float SliderSize { get; set; } = 0f;

    #endregion

    #region Brush

    public float MinBrushValue { get; set; } = 0f;
    public float MaxBrushValue { get; set; } = 1f;
    public float SliderBrush { get; set; } = 0f;

    #endregion

    #region GameObject

    public GameObject GameObject { get; set; }

    #endregion

    #region ActivateCircle

    public bool ActivateCircle { get; set; } = false;

    #endregion

    #endregion
}
