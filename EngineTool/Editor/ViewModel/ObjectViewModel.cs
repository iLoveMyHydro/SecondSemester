using UnityEngine;

/// <summary>
/// MVVM MODEL BASE IS FROM MARCUS SCHAAL 
/// MADE WITH HIM IN OCE
/// </summary>
public class ObjectViewModel : BaseViewModel
{
    /// <summary>
    /// Object of the ObjectModel
    /// </summary>
    public ObjectModel _Target;

    #region Parameters

    #region Const

    private const string radiusTXT = "_Radius";

    private const string placedObject = "PlacedObject";

    #endregion

    #region Properties
    /// <summary>
    /// Properties of all Values used in the other Classes -> Same Structure everytime 
    /// 
    /// </summary>

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

    #region Activate Circle

    public bool ActivateCircle
    {
        get => _Target.ActivateCircle;
        set => Update(() => _Target.ActivateCircle, val => _Target.ActivateCircle = val, value);
    }

    #endregion

    #region Place Object (bool)

    public bool PlaceObjectBool
    {
        get => _Target.PlaceObjectBool;
        set => Update(() => _Target.PlaceObjectBool, val => _Target.PlaceObjectBool = val, value);
    }

    #endregion

    #region Delete Object (bool)

    public bool DeleteObjectBool
    {
        get => _Target.DeleteObjectBool;
        set => Update(() => _Target.DeleteObjectBool, val => _Target.DeleteObjectBool = val, value);
    }

    #endregion

    #region GameObject

    public GameObject GameObject
    {
        get => _Target.GameObject;
        set => Update(() => _Target.GameObject, val => _Target.GameObject = (GameObject)val, value);
    }

    #endregion

    #region DrawCircle

    public MeshRenderer MeshRenderer
    {
        get => _Target.MeshRenderer;
        set => Update(() => _Target.MeshRenderer, val => _Target.MeshRenderer = val, value);
    }

    #endregion

    #region MousePos

    public Vector3 MousePos
    {
        get => _Target.MousePos;
        set => Update(() => _Target.MousePos, val => _Target.MousePos = val, value);
    }

    #endregion

    #region LayerMask

    public LayerMask GroundLayer
    {
        get => _Target.LayerMask;
        set => Update(() => _Target.LayerMask, val => _Target.LayerMask = val, value);
    }

    #endregion

    #endregion

    #endregion

    #region Methods

    /// <summary>
    /// Resizes the circle if the value of the radius changed -> Not possible if the painter is in use
    /// </summary>
    #region Size Circle
    public void SizeCircle()
    {
        _Target.MeshRenderer.sharedMaterial.SetFloat(radiusTXT, _Target.SliderSize);
    }

    #endregion

    #region Density Circle

    /// <summary>
    /// Calculates the value of the objects getting spawned in the circle 
    /// </summary>
    /// <returns></returns>
    public float GetObjectToPlaceCount()
    {
        var radius = _Target.MeshRenderer.sharedMaterial.GetFloat(radiusTXT);

        var area = (radius * radius) * Mathf.PI;
        var density = area * _Target.SliderDensity / 100;

        return density;
    }

    #endregion

    #region PlaceObject

    /// <summary>
    /// Places Objects in the Circle if the GameObject is choosen and the ActivateToggle is true and the PlaceObject Toggle is true
    /// </summary>
    public void PlaceObject()
    {
        if (_Target.GameObject != null && _Target.MeshRenderer != null)
        {
            var radius = _Target.MeshRenderer.sharedMaterial.GetFloat(radiusTXT);

            var count = GetObjectToPlaceCount();

            float y = 200f;

            // Im folgenden For-Loop wurde der Code von ChatGPT verwendet
            for (int i = 0; i < count; i++)
            {
                var randomRadius = Mathf.Sqrt(Random.Range(0f, 1f)) * radius;

                var angle = Random.Range(0f, Mathf.PI * 2f);
                var x = Mathf.Cos(angle) * randomRadius;
                var z = Mathf.Sin(angle) * randomRadius;
                //Calculates if the y Axis is 0 or sth different 
                var yCalc = CalculateHeight(x, y, z);

                //Generates a random Position in the circle where the Object gets spawned
                Vector3 randomPosition = new Vector3(x, yCalc, z) + new Vector3(_Target.MousePos.x, _Target.MousePos.y, _Target.MousePos.z);

                GameObject newObject = Object.Instantiate(_Target.GameObject, randomPosition, Quaternion.identity, _Target.MeshRenderer.transform);
                newObject.tag = placedObject;
            }
        }
        else return;
    }

    #endregion

    #region DeleteObject

    /// <summary>
    /// Deletes the Object in the Circle -> Same starting procedure as the PlaceObject Method
    /// -> Checks all the Placed Objects if they are in the circle -> if so they will be deleted 
    /// -> Maybe find a better solution -> If time left
    /// </summary>
    public void DeleteObject()
    {
        if (_Target.GameObject != null && _Target.MeshRenderer != null)
        {
            var radius = _Target.MeshRenderer.sharedMaterial.GetFloat(radiusTXT);

            var placedObjects = GameObject.FindGameObjectsWithTag(placedObject);

            foreach (var placedObject in placedObjects)
            {
                if (Vector3.Distance(placedObject.transform.position, _Target.MousePos) <= radius)
                {
                    Object.DestroyImmediate(placedObject);
                }
            }
        }
        else return;
    }

    #endregion

    #region CalculateHeight

    /// <summary>
    /// Calculates the height where the object gets spawned 
    /// If the y axis is not 0 a reycast will look which value the y axis gets
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <param name="z"></param>
    /// <returns></returns>
    public float CalculateHeight(float x, float y, float z)
    {
        Ray ray = new(new Vector3(x, y, z), Vector3.down);

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, _Target.LayerMask))
        {
            return hit.point.y;
        }
        else
        {
            return 0;
        }
    }

    #endregion

    #endregion

    #region Constructor

    /// <summary>
    /// Constructor of the ObjectViewModel
    /// </summary>
    public ObjectViewModel()
    {
        _Target = new();
    }

    #endregion
}