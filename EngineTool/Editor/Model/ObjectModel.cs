using UnityEngine;

public class ObjectModel : MonoBehaviour
{
    #region Parameter

    #region Number

    public float MinNumberValue { get; set; } = 0f;
    public float MaxNumberValue { get; set; } = 1f;
    public float SliderNumber { get; set; }

    #endregion

    #region Size

    public float MinSizeValue { get; set; } = 1f;
    public float MaxSizeValue { get; set; } = 5f;
    public float SliderSize { get; set; } = 1f;

    #endregion

    #region Brush

    public float MinBrushValue { get; set; } = 0f;
    public float MaxBrushValue { get; set; } = 1f;
    public float SliderBrush { get; set; }

    #endregion

    #region GameObject

    public GameObject GameObject { get; set; }

    #endregion

    #region ActivateCircle

    public bool ActivateCircle { get; set; } = false;

    #endregion

    #region MeshRenderer

    public MeshRenderer MeshRenderer { get; set; }

    #endregion

    #endregion
}
