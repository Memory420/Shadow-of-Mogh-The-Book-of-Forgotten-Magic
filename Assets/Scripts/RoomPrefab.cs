using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomPrefab : MonoBehaviour
{
    public CellManager manager;
    public List<GameObject> prefabList;
    private void Start()
    {
        manager = FindObjectOfType<CellManager>();
        foreach (Transform childTransform in transform)
        {
            prefabList.Add(childTransform.gameObject);
        }
        manager.roomStack.Push(this);
    }
    public void DeletePrefab()
    {
        foreach (GameObject gameObject in prefabList)
        {
            Destroy(gameObject);
        }
        prefabList.Clear();
        Destroy(gameObject);
    }
}
