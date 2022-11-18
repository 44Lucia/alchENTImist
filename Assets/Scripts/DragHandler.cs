using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragHandler : MonoBehaviour, IDragHandler, IEndDragHandler, IBeginDragHandler
{
    public static GameObject itemDragging;

    private Transform transformCanvas;

    Vector3 startPosition;
    Transform startParent;
    Transform dragParent;

    private Canvas canvasItems;

    private void Start()
    {
       transformCanvas = GameObject.FindGameObjectWithTag("PositionCanvas").transform;
       dragParent = GameObject.FindGameObjectWithTag("DragParent").transform;
    }

    public void OnBeginDrag(PointerEventData eventData) {
            
        itemDragging = gameObject;
        
        startPosition = transform.position;
        startParent = transform.parent;

        itemDragging = Instantiate(this.gameObject, transformCanvas);

        itemDragging.GetComponent<Image>().raycastTarget = false;
    }

    public void OnDrag(PointerEventData eventData) {
        itemDragging.transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData) {
        if (itemDragging != null){
            Destroy(itemDragging);
            itemDragging = null;
        }
    }
}
