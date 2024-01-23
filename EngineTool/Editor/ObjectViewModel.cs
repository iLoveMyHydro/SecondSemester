using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ObjectViewModel : EditorWindow
{
    private static ObjectViewModel _window;
    private Rect windowRect = new Rect(0,0,250,80);


    public void OnGUI()
    {

    }

    [MenuItem("Tools/Object Painter")]
    private void ShowWindow()
    {
        _window = (ObjectViewModel) EditorWindow.GetWindow(typeof(ObjectViewModel));

        _window.titleContent = new GUIContent("Object Painter");
        _window.minSize = new Vector2(50, 50);
        _window.maxSize = new Vector2(1000, 500);
    }
}
