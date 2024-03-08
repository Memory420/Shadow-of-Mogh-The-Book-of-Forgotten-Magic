using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RoomPrefab : MonoBehaviour
{
    public CellManager manager;
    public List<GameObject> prefabList;
    public List<GameObject> doorList;
    public List<Cell> temporaryCells; // Needs to check if cell collides
    public CaveGenerator caveGenerator;

    private void Start()
    {
        caveGenerator = FindObjectOfType<CaveGenerator>();
        manager = FindObjectOfType<CellManager>();
        foreach (Transform childTransform in transform)
        {
            Cell currentCell = childTransform.GetComponent<Cell>();

            if (currentCell.cellType == Cell.CellType.Temporary)
            {
                temporaryCells.Add(currentCell);
                manager.temporaryCells.Add(currentCell);
            }
            prefabList.Add(childTransform.gameObject);
        }
        manager.roomStack.Push(this);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            CheckRoomIntersection();
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            DeleteTemporaryCells();
        }
    }
    public void DeletePrefab()
    {
        Debug.Log("Удаление");
        DeleteTemporaryCells();
        foreach (GameObject gameObject in prefabList)
        {
            Destroy(gameObject);
        }
        prefabList.Clear();
        Destroy(gameObject);
    }
    public void DeleteTemporaryCells()
    {
        if (temporaryCells.Count > 0)
        {
            foreach (Cell cell in temporaryCells)
            {
                Destroy(cell.gameObject);
            }
            temporaryCells.Clear();
        }
        else
        {
            Debug.LogWarning("List empty! (temporaryCells");
        }
    }

    public bool CheckRoomIntersection()
    {
        caveGenerator = FindObjectOfType<CaveGenerator>();

        foreach (Cell currentRoomCell in temporaryCells)
        {
            foreach (Cell containedCell in manager.cells)
            {
                if (containedCell.cellType != Cell.CellType.None && currentRoomCell != containedCell)
                {
                    if (currentRoomCell.x == containedCell.x && currentRoomCell.y == containedCell.y)
                    {
                        Debug.LogWarning("Комнаты пересекаются: x = " + containedCell.x.ToString() + ", y = " + containedCell.y.ToString() + ". Итераций: " + caveGenerator.iterations.ToString());
                        DeletePrefab();
                        return true;
                    }
                    caveGenerator.iterations++;
                }
                caveGenerator.iterations++;
            }
        }
        Debug.Log("Комнаты не пересекаются" + ". Итераций: " + caveGenerator.iterations.ToString());
        caveGenerator.iterations = 0;
        DeleteTemporaryCells();
        return false;
    }
}
