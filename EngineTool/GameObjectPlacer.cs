using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectPlacer : MonoBehaviour
{
    [SerializeField] private Vector3 startPos = Vector3.zero;
    [SerializeField] private Vector3 endPos = Vector3.zero;
    [SerializeField] private GameObject gameObject = null;
    [SerializeField] private int Count = 0;

    [ContextMenu("Place GameObject")]
    private void PlaceGameObject()
    {
        Clear();
        for (int i = 0; i < Count; i++)
        {
            var pos = new Vector3(Random.Range(startPos.x, endPos.x), Random.Range(startPos.y, endPos.y), Random.Range(startPos.z, endPos.z));
            Instantiate(gameObject, pos, Quaternion.identity,transform);
        }
    }

    [ContextMenu("Delete GameObjects")]
    private void Clear()
    {
        for (int i = transform.childCount - 1; i >= 0; i--)
        {
            DestroyImmediate(transform.GetChild(i).gameObject);
        }
    }
    
}
