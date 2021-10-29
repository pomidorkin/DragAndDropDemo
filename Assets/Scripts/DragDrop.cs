using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField] private Canvas canvas;
    [SerializeField] private CanvasGroup canvasGroup;
    private RectTransform rectTransform;
    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = .6f;
        canvasGroup.blocksRaycasts = false;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 1.0f;
        canvasGroup.blocksRaycasts = true;
    }

    // Getts called on every frame
    public void OnDrag(PointerEventData eventData)
    {
        // delta contains an amout the mouse moved since the previous frame
        // The reason is why we divide the value by the canvas scale factor is becase
        // in a case if the ration of the canvas is not equal 1, the movement of the
        // item will be distorted
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }


    // This function will be called when the mouse is pressed whilst on top of this object
    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("OnPointerDown");
    }

}
