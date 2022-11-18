using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class dropSlot : MonoBehaviour, IDropHandler
{
    private GameObject item;

    public void OnDrop(PointerEventData enventData) {

        if (!item){
            item = DragHandler.itemDragging;
            item.transform.position = transform.position;
            item.transform.localScale = 0.8f * Vector3.one;
            DragHandler.itemDragging.GetComponent<Image>().raycastTarget = true;
            DragHandler.itemDragging = null;
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
