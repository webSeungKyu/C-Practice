using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UtilyDrag : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    public static Vector2 defaultPos;

    public void OnBeginDrag(PointerEventData eventData)
    {
        defaultPos = transform.position;
        Debug.Log("OnBeginDrag" + defaultPos);
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 currentPos = eventData.position;
        transform.position = currentPos;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //transform.position = defaultPos; 처음 포지션으로 이동하기
        transform.position = eventData.position; // 마지막 놓은 곳으로 이동하기
        Debug.Log("OnEndDrag" + transform.position);
    }
}
