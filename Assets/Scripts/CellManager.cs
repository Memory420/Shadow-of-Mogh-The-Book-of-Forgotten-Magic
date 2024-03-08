using System.Collections.Generic;
using UnityEngine;

public class CellManager : MonoBehaviour
{
    public List<Cell> cells;
    public List<Cell> temporaryCells;
    public Stack<RoomPrefab> roomStack;
    private void Start()
    {
        roomStack = new Stack<RoomPrefab>();
    }

    public void CellsCount()
    {
        Debug.Log(cells.Count);
    }
    public bool CellExists(float x, float y)
    {
        foreach (Cell cell in cells)
        {
            if (transform.position.x == cell.x && transform.position.y == cell.y)
            {
                return true;
            }
        }
        return false;
    }
    public void ClearLastRoom()
    {
        if (roomStack.Count > 0)
        {
            RoomPrefab currentRoom = roomStack.Pop();
            currentRoom.DeletePrefab();
            Debug.Log(roomStack.Count);
        }
        else
        {
            Debug.LogWarning("Stack is empty!");
        }
        cells.RemoveAll(cell => cell == null);
        temporaryCells.RemoveAll(cell => cell == null);
    }

}
