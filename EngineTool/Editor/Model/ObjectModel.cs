using UnityEngine;

/// <summary>
/// MVVM MODEL BASE IS FROM MARCUS SCHAAL 
/// MADE WITH HIM IN OCE
/// </summary>
public class ObjectModel : MonoBehaviour
{
    #region Parameter

    #region Size

    /// <summary>
    /// Properties for the Size of the Circle -> Min- and MaxSizeValue are the least and the highest possible Value for the Size of the Circle 
    /// SliderSize is the current size of the Circle
    /// </summary>
    public float MinSizeValue { get; set; } = 1f;
    public float MaxSizeValue { get; set; } = 5f;
    public float SliderSize { get; set; } = 1f;

    #endregion

    #region Density

    /// <summary>
    /// Properties for the Amount of Object in the Circle -> Min- and MaxDensityValue are the least and the highest possible Value for the Objects in the Circle 
    /// SliderDensity is the current Amount of Objects in the Circle
    /// </summary>
    public float MinDensityValue { get; set; } = 0f;
    public float MaxDensityValue { get; set; } = 5f;
    public float SliderDensity { get; set; } = 1f;

    #endregion

    #region GameObject

    /// <summary>
    /// Property for the GameObject you wanna place
    /// </summary>
    public GameObject GameObject { get; set; }

    #endregion

    #region ActivateCircle

    /// <summary>
    /// Property for the Toggle of the ActivateCircle Method
    /// </summary>
    public bool ActivateCircle { get; set; } = false;

    #endregion

    #region PlaceObject

    /// <summary>
    /// Property for the Toggle of the PlaceObject Method
    /// </summary>
    public bool PlaceObjectBool { get; set; } = false;

    #endregion

    #region DeleteObjectBool

    /// <summary>
    /// Property for the Toggle of the DeleteObject Method
    /// </summary>
    public bool DeleteObjectBool { get; set; } = false;

    #endregion

    #region MeshRenderer

    /// <summary>
    /// Property of the MeshRenderer you wanna use for the Shader
    /// </summary>
    public MeshRenderer MeshRenderer { get; set; }

    #endregion

    #region MousePos

    /// <summary>
    /// Property of the MousePosition for the Shader 
    /// </summary>
    public Vector3 MousePos { get; set; }

    #endregion

    #region LayerMask

    /// <summary>
    /// Property of the LayerMask you wanna use for the CalculateHeight Method
    /// </summary>
    public LayerMask LayerMask { get; set; }

    #endregion

    #endregion
}
