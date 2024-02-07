using System;
using UnityEditor;
using UnityEngine;

public class ObjectView : EditorWindow
{
    #region Parameter

    #region Object

    private static ObjectView self;

    public ObjectViewModel viewModel { get; set; } = null;

    #endregion

    #region Foldout

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

    #region Foldout Object

    #region Foldout Object Main

    private bool openObjectFoldout = false;

    #endregion

    #region Foldout Object Second

    private bool openObjectSecondFoldout = false;

    #endregion

    #region Foldout Object Number

    private bool openObjectNumberFoldout = false;

    #endregion

    #region Foldout Object Density

    private bool openObjectDensityFoldout = false;

    #endregion

    #region Foldout Object Field

    private bool openObjectFieldFoldout = false;

    #endregion

    #endregion

    #endregion

    #region Const

    #region Brush and Stroke

    private const string stroke = "Stroke";
    private const string brush = "Brush Settings";
    private const string brushStrength = "Brush Strength";
    private const string brushSize = "Brush Size";

    #endregion

    #region Object

    private const string objectMain = "Object";
    private const string objectNumber = "Object Amount";
    private const string objectSetting = "Object Settings";
    private const string objectDensity = "Object Density";
    private const string objectField = "Choose Object";

    #endregion

    #region ActiveToogle

    private const string activateCircle = "Activate the Circle";

    #endregion

    #endregion

    #endregion


    //View -> GUILayout
    //ViewModel -> Anbindung zwischen View und Model
    //Model -> Daten Scripts etc

    private void OnGUI()
    {
        BrushSettings();

        Object();

        ActivateToogle();
    }

    private void ActivateToogle()
    {
        EditorGUI.indentLevel++;
        GUILayout.BeginVertical("HelpBox");
        self.viewModel.ActivateCircle = GUILayout.Toggle(self.viewModel.ActivateCircle, activateCircle);
        GUILayout.EndVertical();
    }

    private void Object()
    {
        GUILayout.BeginVertical("HelpBox");
        openObjectFoldout = EditorGUILayout.Foldout(openObjectFoldout, objectMain);
        if (!openObjectFoldout) GUILayout.EndVertical();

        if (openObjectFoldout)
        {
            EditorGUI.indentLevel++;
            GUILayout.BeginVertical("HelpBox");
            openObjectSecondFoldout = EditorGUILayout.Foldout(openObjectSecondFoldout, objectSetting);
            if (!openObjectSecondFoldout) GUILayout.EndVertical();
            EditorGUI.indentLevel--;

            ObjectSettings();

            ChooseObject();
            GUILayout.EndVertical();

        }
    }

    private void ObjectSettings()
    {
        if (openObjectSecondFoldout)
        {
            EditorGUI.indentLevel++;
            EditorGUILayout.BeginHorizontal();
            openObjectNumberFoldout = EditorGUILayout.Foldout(openObjectNumberFoldout, objectNumber);
            self.viewModel.SliderNumber = EditorGUILayout.Slider(self.viewModel.SliderNumber,
                self.viewModel.MinNumber,
                self.viewModel.MaxNumber);
            GUILayout.EndHorizontal();

            if (openObjectNumberFoldout)
            {
                EditorGUILayout.BeginHorizontal();
                self.viewModel.MinNumber = EditorGUILayout.FloatField("Min", self.viewModel.MinNumber);

                self.viewModel.MaxNumber = EditorGUILayout.FloatField("Max", self.viewModel.MaxNumber);
                EditorGUILayout.EndHorizontal();
            }

            GUILayout.BeginHorizontal();
            openObjectDensityFoldout = EditorGUILayout.Foldout(openObjectDensityFoldout, objectDensity);
            self.viewModel.SliderDensity = EditorGUILayout.Slider(self.viewModel.SliderDensity,
                self.viewModel.MinDensity,
                self.viewModel.MaxDensity);
            GUILayout.EndHorizontal();

            if (openObjectDensityFoldout)
            {
                EditorGUILayout.BeginHorizontal();
                self.viewModel.MinDensity = EditorGUILayout.FloatField("Min", self.viewModel.MinDensity);

                self.viewModel.MaxDensity = EditorGUILayout.FloatField("Max", self.viewModel.MaxDensity);
                EditorGUILayout.EndHorizontal();
            }

            if (self.viewModel.MinNumber > self.viewModel.MaxNumber)
                self.viewModel.MinNumber = self.viewModel.MaxNumber;
            if (self.viewModel.MinDensity > self.viewModel.MaxDensity)
                self.viewModel.MaxDensity = self.viewModel.MinDensity;
            EditorGUI.indentLevel--;
            GUILayout.EndVertical();
        }
    }

    private void ChooseObject()
    {
        EditorGUI.indentLevel++;
        GUILayout.BeginVertical("HelpBox");
        openObjectFieldFoldout = EditorGUILayout.Foldout(openObjectFieldFoldout, objectField);
        if (!openObjectFieldFoldout) GUILayout.EndVertical();

        if (openObjectFieldFoldout)
        {
            self.viewModel._Target.GameObject = (GameObject)EditorGUILayout.ObjectField(objectField,
                self.viewModel._Target.GameObject,
                typeof(GameObject),
                true);


            EditorGUI.indentLevel--;
            GUILayout.EndVertical();
        }

    }

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
                self.viewModel.SliderBrush = EditorGUILayout.Slider(self.viewModel.SliderBrush,
                    self.viewModel.MinBrush,
                    self.viewModel.MaxBrush);
                EditorGUILayout.EndHorizontal();

                if (openBrushStrengthFoldout)
                {
                    EditorGUILayout.BeginHorizontal();
                    self.viewModel.MinBrush = EditorGUILayout.FloatField("Min", self.viewModel.MinBrush);

                    self.viewModel.MaxBrush = EditorGUILayout.FloatField("Max", self.viewModel.MaxBrush);
                    EditorGUILayout.EndHorizontal();
                }

                EditorGUILayout.BeginHorizontal();
                openBrushSizeFoldout = EditorGUILayout.Foldout(openBrushSizeFoldout, brushSize);
                self.viewModel.SliderSize = EditorGUILayout.Slider(self.viewModel.SliderSize,
                    self.viewModel.MinSize,
                    self.viewModel.MaxSize);
                EditorGUILayout.EndHorizontal();

                if (openBrushSizeFoldout)
                {
                    EditorGUILayout.BeginHorizontal();
                    self.viewModel.MinSize = EditorGUILayout.FloatField("Min", self.viewModel.MinSize);

                    self.viewModel.MaxSize = EditorGUILayout.FloatField("Max", self.viewModel.MaxSize);
                    EditorGUILayout.EndHorizontal();
                }

                if (self.viewModel.MinBrush > self.viewModel.MaxBrush) self.viewModel.MaxBrush = self.viewModel.MinBrush;
                if (self.viewModel.MinSize > self.viewModel.MaxSize) self.viewModel.MaxSize = self.viewModel.MinSize;
                EditorGUI.indentLevel--;
                GUILayout.EndVertical();
            }
            GUILayout.EndVertical();
        }
    }

    [MenuItem("Tools/ChooseObject/Painter")]
    private static void ShowWindow()
    {
        self = GetWindow<ObjectView>();
        self.titleContent = new GUIContent("ChooseObject Painter");
        self.viewModel = new();
        self.viewModel.PropertyChanged += (sender, e) => { };
        self.minSize = new Vector2(475, 200);
        self.maxSize = new Vector2(500, 500);
    }
}
