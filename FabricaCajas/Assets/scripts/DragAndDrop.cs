using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragAndDrop : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private RectTransform rectTransform;
    private Image image;


    public void OnBeginDrag(PointerEventData eventData) {
        image.color = new Color32(255, 255, 255, 170);
    }

    public void OnDrag(PointerEventData eventData) {
        //rectTransform.anchoredPosition += eventData.delta;

        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData) {
        image.color = new Color(255, 255, 255, 255);
    }

    void Start(){
        rectTransform = GetComponent<RectTransform>();
        image = GetComponent<Image>();
    }
}
