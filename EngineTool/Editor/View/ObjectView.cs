using UnityEditor;
using UnityEngine;

/// <summary>
/// MVVM MODEL BASE IS FROM MARCUS SCHAAL 
/// MADE WITH HIM IN OCE
/// </summary>
public class ObjectView : EditorWindow
{
    #region Parameter

    #region Object

    /// <summary>
    /// Object from ObjectViewModel/ObjectView and prop from ObjectView 
    /// </summary>
    private static ObjectView self;

    public ObjectViewModel viewModel { get; set; }
    public static ObjectView Self { get => self; set => self = value; }

    #endregion

    #region Foldout

    /// <summary>
    /// Some bools for all the Foldouts -> Same Structure everytime
    /// </summary>

    #region Foldout Stroke

    #region Foldout Stroke Main

    private bool openStrokeFoldout = false;

    #endregion

    #region Foldout Brush Main

    private bool openBrushFoldout = false;

    #endregion

    #region Foldout Brush Strength

    private bool openBrushStrengthFoldout = false;

    #endregion

    #region Foldout Brush Size

    private bool openBrushSizeFoldout = false;

    #endregion

    #endregion

    #endregion

    #region Const

    /// <summary>
    /// Const Strings for the Labels -> Same Structure everytime
    /// </summary>

    #region Brush and Stroke

    private const string stroke = "Stroke";
    private const string brush = "Brush Settings";
    private const string brushStrength = "Brush Density";
    private const string brushSize = "Brush Size";

    #endregion

    #region Material

    private const string material = "MeshRenderer";

    #endregion

    #region ActiveToogle

    private const string activateCircle = "Activate the Circle";

    #endregion

    #region PlaceObjectBool

    private const string placeObjectBool = "Place Objects";

    #endregion

    #region DeleteObjectBool

    private const string deleteObjectBool = "Delete Objects";

    #endregion

    #region Object

    private const string objectField = "Choose Object";

    #endregion

    #region DrawHereField

    private const string drawHereField = "Draw In this Box";

    #endregion

    #region Layer

    private const string layerField = "Layers";

    #endregion

    #endregion

    #region Rect

    /// <summary>
    /// Rect for the Drawing Box 
    /// </summary>
    Rect position = new(3, 280, 470, 215);


    #endregion

    #endregion

    #region Constructor

    /// <summary>
    /// Constructor of the ObjectView
    /// </summary>
    public ObjectView()
    {
        self = this;
        viewModel = new();
    }

    #endregion


    #region Methods

    #region OnGUI

    //View -> GUILayout
    //ViewModel -> Anbindung zwischen View und Model
    //Model -> Daten Scripts etc

    /// <summary>
    /// GUI of the EditorWindow -> All Methods are outsourced in own Methods
    /// </summary>
    private void OnGUI()
    {

        BrushSettings();

        Object();

        GetMaterial();

        //The complete Layermethods are from ChatGPT and from https://discussions.unity.com/t/how-to-create-layermask-field-in-a-custom-editorwindow/13356/6
        self.viewModel.GroundLayer = GetLayerMask(layerField, self.viewModel.GroundLayer);

        ActivateToggle();

        PlaceObject();

        DeleteObject();

        if (self.viewModel.PlaceObjectBool && self.viewModel.ActivateCircle) self.viewModel.PlaceObject();

        if (self.viewModel.DeleteObjectBool && self.viewModel.ActivateCircle) self.viewModel.DeleteObject();

        DrawHereField();

        Repaint();
    }

    #endregion

    #region DrawHereField

    /// <summary>
    /// This is the Rectangle for the Drawing Space
    /// </summary>
    private void DrawHereField()
    {
        EditorGUI.HelpBox(position, drawHereField, MessageType.Info);
    }

    #endregion

    #region LayerMask

    #region GetLayerMask

    /// <summary>
    /// Generates the MaskField for the LayerMask
    /// </summary>
    /// <param name="label"></param>
    /// <param name="layerMask"></param>
    /// <returns></returns>
    private LayerMask GetLayerMask(string label, LayerMask layerMask)
    {
        GUILayout.BeginVertical("HelpBox");
        int layerMaskValue = EditorGUILayout.MaskField(label, LayerMaskToField(layerMask), UnityEditorInternal.InternalEditorUtility.layers);

        layerMask = FieldToLayerMask(layerMaskValue);
        GUILayout.EndVertical();

        return layerMask;
    }

    #endregion

    #region LayerMaskToField

    /// <summary>
    /// Looks which LayerMask is choosen
    /// </summary>
    /// <param name="layerMask"></param>
    /// <returns></returns>
    private int LayerMaskToField(LayerMask layerMask)
    {
        int fieldValue = 0;
        int layer = 0;
        for (int i = 0; i < 32; i++)
        {
            layer = 1 << i;
            if ((layerMask & layer) != 0)
            {
                fieldValue |= 1 << LayerMask.NameToLayer(UnityEditorInternal.InternalEditorUtility.layers[i]);
            }
        }
        return fieldValue;
    }

    #endregion

    #region FieldToLayerMask

    /// <summary>
    /// Looks if the choosen Layer is possible to choose
    /// </summary>
    /// <param name="fieldValue"></param>
    /// <returns></returns>
    private LayerMask FieldToLayerMask(int fieldValue)
    {
        LayerMask layerMask = 0;
        for (int i = 0; i < UnityEditorInternal.InternalEditorUtility.layers.Length; i++)
        {
            if ((fieldValue & (1 << i)) != 0)
            {
                layerMask |= 1 << LayerMask.NameToLayer(UnityEditorInternal.InternalEditorUtility.layers[i]);
            }
        }
        return layerMask;
    }

    #endregion

    #endregion

    #region DeleteObject

    /// <summary>
    /// Toggle -> If PlaceObject is choosen there wont be a DeleteObject Toogle 
    /// If DeleteObject is choosen there wont be a PlaceObject Toggle
    /// </summary>
    private void DeleteObject()
    {
        if (!self.viewModel.PlaceObjectBool)
        {
            GUILayout.BeginVertical("HelpBox");
            self.viewModel.DeleteObjectBool = GUILayout.Toggle(self.viewModel.DeleteObjectBool, deleteObjectBool);
            GUILayout.EndVertical();
        }
    }

    #endregion

    #region PlaceObject

    /// <summary>
    /// Toggle -> If PlaceObject is choosen there wont be a DeleteObject Toogle 
    /// If DeleteObject is choosen there wont be a PlaceObject Toggle
    /// </summary>
    private void PlaceObject()
    {
        if (!self.viewModel.DeleteObjectBool)
        {
            GUILayout.BeginVertical("HelpBox");
            self.viewModel.PlaceObjectBool = GUILayout.Toggle(self.viewModel.PlaceObjectBool, placeObjectBool);
            GUILayout.EndVertical();
        }
    }

    #endregion

    #region GetMaterial

    /// <summary>
    /// Generates a ObjectField where you have to put the MeshRenderer into 
    /// You need a MeshRenderer for the Shader 
    /// </summary>
    private void GetMaterial()
    {
        GUILayout.BeginVertical("HelpBox");
        self.viewModel.MeshRenderer = (MeshRenderer)EditorGUILayout.ObjectField(material,
                self.viewModel.MeshRenderer,
                typeof(MeshRenderer),
                true);
        GUILayout.EndVertical();
    }

    #endregion

    #region GetMousePosition

    /// <summary>
    /// Gets the Mouse Position for the Shader
    /// Is calculated from the scene view top left to the top left from the editor window 
    /// </summary>
    private void GetMousePosition()
    {
        var mousePosition = Event.current.mousePosition;

        mousePosition -= position.position;


        if (position.Contains(mousePosition))
        {
            var ray = HandleUtility.GUIPointToWorldRay(mousePosition);

            if (Physics.Raycast(ray, out var hit))
            {
                Vector3 newPoint = hit.point;

                self.viewModel.MousePos = newPoint;

                if (self.viewModel.MeshRenderer != null)
                {
                    self.viewModel.MeshRenderer.material.SetVector
                        ("_MousePosition",
                        new Vector2(newPoint.x, newPoint.z));
                }
            }
        }
    }

    #endregion

    #region ActivateToggle

    /// <summary>
    /// Generates a Toogle where you can activate the GetMousePostion Method -> If Toggle is not active you cant change your MousePosition
    /// </summary>
    private void ActivateToggle()
    {
        EditorGUI.indentLevel++;
        GUILayout.BeginVertical("HelpBox");
        self.viewModel.ActivateCircle = GUILayout.Toggle(self.viewModel.ActivateCircle, activateCircle);
        if (self.viewModel.ActivateCircle) GetMousePosition();
        GUILayout.EndVertical();
        EditorGUI.indentLevel--;
    }

    #endregion

    #region Object

    /// <summary>
    /// Activates the ChooseObject Method -> Could be expandable -> therefor there is a Obejct and a ChooseObject Method  
    /// </summary>
    private void Object()
    {
        GUILayout.BeginVertical("HelpBox");
        ChooseObject();
        GUILayout.EndVertical();
    }

    #endregion

    #region ChooseObject

    /// <summary>
    /// Generates a ObjectField where you have to put your Object you wanna place into 
    /// </summary>
    private void ChooseObject()
    {
        self.viewModel.GameObject = (GameObject)EditorGUILayout.ObjectField(objectField,
            self.viewModel.GameObject,
            typeof(GameObject),
            true);
    }

    #endregion

    #region BrushSettings

    /// <summary>
    /// Here there are the Settings of the Brush -> Density and the Circle Size
    /// </summary>
    private void BrushSettings()
    {
        GUILayout.BeginVertical("HelpBox");
        openStrokeFoldout = EditorGUILayout.Foldout(openStrokeFoldout, stroke);
        if (!openStrokeFoldout) GUILayout.EndVertical();

        if (openStrokeFoldout)
        {
            EditorGUI.indentLevel++;
            GUILayout.BeginVertical("HelpBox");
            openBrushFoldout = EditorGUILayout.Foldout(openBrushFoldout, brush);
            if (!openBrushFoldout) GUILayout.EndVertical();
            EditorGUI.indentLevel--;

            if (openBrushFoldout)
            {
                EditorGUI.indentLevel++;
                EditorGUILayout.BeginHorizontal();
                openBrushStrengthFoldout = EditorGUILayout.Foldout(openBrushStrengthFoldout, brushStrength);
                self.viewModel.SliderDensity = EditorGUILayout.Slider(self.viewModel.SliderDensity,
                    self.viewModel.MinDensity,
                    self.viewModel.MaxDensity);
                if (self.viewModel.MeshRenderer != null)
                {
                    self.viewModel.GetObjectToPlaceCount();
                }
                EditorGUILayout.EndHorizontal();

                if (openBrushStrengthFoldout)
                {
                    EditorGUILayout.BeginHorizontal();
                    self.viewModel.MinDensity = EditorGUILayout.FloatField("Min", self.viewModel.MinDensity);

                    self.viewModel.MaxDensity = EditorGUILayout.FloatField("Max", self.viewModel.MaxDensity);
                    EditorGUILayout.EndHorizontal();
                }

                EditorGUILayout.BeginHorizontal();
                openBrushSizeFoldout = EditorGUILayout.Foldout(openBrushSizeFoldout, brushSize);
                self.viewModel.SliderSize = EditorGUILayout.Slider(self.viewModel.SliderSize,
                    self.viewModel.MinSize,
                    self.viewModel.MaxSize);
                if (self.viewModel.MeshRenderer != null)
                {
                    if (self.viewModel.SliderSize != self.viewModel.MeshRenderer.material.GetFloat("_Radius"))
                    {
                        self.viewModel.SizeCircle();
                    }
                }
                EditorGUILayout.EndHorizontal();

                if (openBrushSizeFoldout)
                {
                    EditorGUILayout.BeginHorizontal();
                    self.viewModel.MinSize = EditorGUILayout.FloatField("Min", self.viewModel.MinSize);

                    self.viewModel.MaxSize = EditorGUILayout.FloatField("Max", self.viewModel.MaxSize);
                    EditorGUILayout.EndHorizontal();
                }

                if (self.viewModel.MinDensity > self.viewModel.MaxDensity)
                    self.viewModel.MaxDensity = self.viewModel.MinDensity;
                if (self.viewModel.MinSize > self.viewModel.MaxSize)
                    self.viewModel.MaxSize = self.viewModel.MinSize;
                EditorGUI.indentLevel--;
                GUILayout.EndVertical();
            }
            GUILayout.EndVertical();
        }
    }

    #endregion

    #region ShowWindow

    /// <summary>
    /// Method for the Window Generating -> You can open the Window under -> Tools -> ChooseObject -> Painter
    /// </summary>
    [MenuItem("Tools/ChooseObject/Painter")]
    private static void ShowWindow()
    {
        self = GetWindow<ObjectView>();
        self.titleContent = new GUIContent("Choose Object Painter");
        self.viewModel = new();
        self.viewModel.PropertyChanged += (sender, e) => { };
        self.minSize = new Vector2(475, 500);
        self.maxSize = new Vector2(475, 500);
    }

    #endregion

    #endregion
}
