using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaveGenerator : MonoBehaviour
{
    public GameObject prefab;
    public CellManager manager;
    public GameObject spawn;
    private void Start()
    {
        Transform transform = GetComponent<Transform>();
        CellManager manager = GetComponent<CellManager>();
    }

    public void RandomMove()
    {
        int direction = Random.Range(0, 4);
        Vector2 currentPosition = transform.position;

        switch (direction)
        {
            case 0:
                transform.position = new Vector2(currentPosition.x, currentPosition.y + 1);
                break;
            case 1:
                transform.position = new Vector2(currentPosition.x + 1, currentPosition.y);
                break;
            case 2:
                transform.position = new Vector2(currentPosition.x, currentPosition.y - 1);
                break;
            case 3:
                transform.position = new Vector2(currentPosition.x - 1, currentPosition.y);
                break;
            default:
                Debug.LogError("Invalid direction");
                break;
        }
        if (!manager.CellExists(transform.position.x, transform.position.y)){
            GameObject gameObject = Instantiate(prefab, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
        }
    }
    public void GenerateSpawn()
    {
        int rotation = Random.Range(0, 4);

        Quaternion newRotation = Quaternion.identity;

        switch (rotation)
        {
            case 0:
                newRotation = Quaternion.Euler(0, 0, 0); // Поворот на 0 градусов
                break;
            case 1:
                newRotation = Quaternion.Euler(0, 0, 90); // Поворот на 90 градусов
                break;
            case 2:
                newRotation = Quaternion.Euler(0, 0, 180); // Поворот на 180 градусов
                break;
            case 3:
                newRotation = Quaternion.Euler(0, 0, 270); // Поворот на 270 градусов
                break;
            default:
                Debug.LogError("Invalid rotation");
                break;
        }
        Debug.Log(rotation);
        GameObject spawnedObject = Instantiate(spawn, transform.position, newRotation);
    }
    public void ClearList()
    {
        
    }
}
