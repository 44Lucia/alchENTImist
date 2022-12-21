using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragHandler : MonoBehaviour, IDragHandler, IEndDragHandler, IBeginDragHandler
{
    public static GameObject itemDragging;

    private Transform transformCanvas;

    Vector3 startPosition;
    Transform startParent;

    private Canvas canvasItems;

    private void Start()
    {
       transformCanvas = GameObject.FindGameObjectWithTag("PositionCanvas").transform;
    }

    public void OnBeginDrag(PointerEventData eventData) {
            
        itemDragging = gameObject;

        if (itemDragging.CompareTag("Ingredient"))
        {
            itemDragging = Instantiate(this.gameObject, transformCanvas);
            itemDragging.GetComponent<Image>().raycastTarget = false;
        } else {
            itemDragging = gameObject; 
            itemDragging.GetComponent<Image>().raycastTarget = false; 
        }


        startPosition = transform.position;
        startParent = transform.parent;
    }

    public void OnDrag(PointerEventData eventData) {
        itemDragging.transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData) {

        if (itemDragging != null){
            if (gameObject.CompareTag("Ingredient"))
            {
                Destroy(itemDragging);
            }
            else
            {
                itemDragging.transform.position = startPosition;
                itemDragging.transform.SetParent(startParent);
            }            
        }
        itemDragging = null;
    }
}
