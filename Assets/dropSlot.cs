using UnityEngine;
using UnityEngine.EventSystems;

public class dropSlot : MonoBehaviour, IDropHandler
{
    private GameObject item;
    private DragHandler dragHandler;

    public void OnDrop(PointerEventData enventData) {

        if (!item){
            item = DragHandler.itemDragging;
            item.transform.SetParent(transform);
            item.transform.position = transform.position;
        }
    }

    private void Update()
    {
        if (item != null && item.transform.parent != transform)
        {
            item = null;
        }
    }
}
