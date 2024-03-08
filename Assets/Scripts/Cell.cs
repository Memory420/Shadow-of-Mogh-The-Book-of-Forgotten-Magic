using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    public enum CellType
    {
        Regular,
        Door,
        Temporary,
        None
    }
    public bool IsCoridorCell;
    public CellType cellType;
    public float x;
    public float y;
    private void Start()
    {
        CellManager cellManager = GameObject.FindObjectOfType<CellManager>();
        Transform objectTr = GetComponent<Transform>();
        x = Mathf.Round(objectTr.position.x * 10) / 10f;
        y = Mathf.Round(objectTr.position.y * 10) / 10f;
        cellManager.cells.Add(this);
        if (cellType == CellType.Door)
        {
            RoomPrefab parentScript = transform.parent.GetComponent<RoomPrefab>();
            parentScript.doorList.Add(this.gameObject);
        }
    }
}
