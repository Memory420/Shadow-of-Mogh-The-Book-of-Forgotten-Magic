using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MoveExplorer : MonoBehaviour
{
    public Transform Explorer;
    public Vector2 clickPosition;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !IsPointerOverUIObject())
        {
            clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            float roundedX = Mathf.Floor(clickPosition.x) + (clickPosition.x % 1 < 0.5f ? 0 : 1) + 0.5f;
            float roundedY = Mathf.Floor(clickPosition.y) + (clickPosition.y % 1 < 0.5f ? 0 : 1) + 0.5f;

            Explorer.position = new Vector2(roundedX, roundedY);
        }
    }

    private bool IsPointerOverUIObject()
    {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        var results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        return results.Count > 0;
    }
}
