using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Button : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public void OnPointerDown(PointerEventData pointerEventData)
    {
        transform.position = new Vector2(transform.position.x, transform.position.y + 6f);
    }

    public void OnPointerUp(PointerEventData pointerEventData)
    {
        transform.position = new Vector2(transform.position.x, transform.position.y + -6f);
    }
}
