using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    public float x;
    public float y;
    private void Start()
    {
        CellManager cellManager = GameObject.FindObjectOfType<CellManager>();
        Transform objectTr = GetComponent<Transform>();
        x = objectTr.position.x;
        y = objectTr.position.y;
        cellManager.cells.Add(this);
    }
}
