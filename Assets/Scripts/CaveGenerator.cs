using System;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class CaveGenerator : MonoBehaviour
{
    public GameObject prefab;
    public CellManager manager;
    public GameObject spawn;
    public int iterations = 0;
    public List<GameObject> RoomPrefabs;
    private void Start()
    {
        Transform transform = GetComponent<Transform>();
        CellManager manager = GetComponent<CellManager>();
    }

    public void RandomMove()
    {
        int direction = UnityEngine.Random.Range(0, 4);
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
        int rotation = UnityEngine.Random.Range(0, 4);

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
        GameObject spawnedObject = Instantiate(spawn, transform.position, newRotation);
    }
    public void GenerateWithRandomRotation(GameObject room)
    {
        int rotation = UnityEngine.Random.Range(0, 4);

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
        GameObject spawnedObject = Instantiate(room, transform.position, newRotation);
        RoomPrefab roomPrefab = spawnedObject.GetComponent<RoomPrefab>();
        yield return null;
        roomPrefab.CheckRoomIntersection();     
    }
    public void GenerateRoom(float x, float y)
    {
        x = Mathf.Round(x * 10) / 10f;
        y = Mathf.Round(y * 10) / 10f;
        int roomIndex = UnityEngine.Random.Range(0, RoomPrefabs.Count);
        Quaternion newRotation = Quaternion.identity;
        GameObject room = RoomPrefabs[roomIndex];
        Vector3 spawnPosition = new Vector3(x, y, 0);
        GameObject spawnedObject = Instantiate(room, spawnPosition, newRotation);
    }
    public void GenerateRoom()
    {
        int roomIndex = UnityEngine.Random.Range(0, RoomPrefabs.Count);
        GameObject room = RoomPrefabs[roomIndex];
        GenerateWithRandomRotation(room);
    }
}
