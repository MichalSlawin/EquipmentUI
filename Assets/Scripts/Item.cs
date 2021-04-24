using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Item : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    private Canvas canvas;
    private RectTransform rectTransform;
    private Image image;
    private CanvasGroup canvasGroup;

    private Vector2 startDragPosition;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        if (rectTransform == null) throw new System.Exception("Rect Transform not found");

        GameObject canvasObj = GameObject.FindGameObjectWithTag("Canvas");
        if (canvasObj == null) throw new System.Exception("Canvas Object not found");
        canvas = canvasObj.GetComponent<Canvas>();
        if (canvas == null) throw new System.Exception("Canvas not found");

        image = GetComponent<Image>();
        if (image == null) throw new System.Exception("Image not found");

        canvasGroup = GetComponent<CanvasGroup>();
        if (canvasGroup == null) throw new System.Exception("Canvas Group not found");
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        image.maskable = false;
        canvasGroup.blocksRaycasts = false;
        startDragPosition = rectTransform.anchoredPosition;
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        image.maskable = true;
        canvasGroup.blocksRaycasts = true;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("Pointer down");
    }

    public void ResetPosition()
    {
        rectTransform.anchoredPosition = startDragPosition;
    }
}
