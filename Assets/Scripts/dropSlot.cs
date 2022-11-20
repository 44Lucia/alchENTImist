using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class dropSlot : MonoBehaviour, IDropHandler
{
    private GameObject item;

    public void OnDrop(PointerEventData enventData) {

        if (!item){
            if (DragHandler.itemDragging.CompareTag("Ingredient") && gameObject.CompareTag("IngredientSlot"))
            {
                item = DragHandler.itemDragging;
                item.transform.position = transform.position;
                item.transform.localScale = 0.8f * Vector3.one;
                DragHandler.itemDragging.GetComponent<Image>().raycastTarget = true;
                DragHandler.itemDragging = null;

                Debug.Log("IngredienteListo");
            }
            else if (DragHandler.itemDragging.CompareTag("Potion") && gameObject.CompareTag("PotionSlot")) 
            {
                item = DragHandler.itemDragging;
                item.transform.position = transform.position;
                item.transform.localScale = 0.8f * Vector3.one;
                DragHandler.itemDragging.GetComponent<Image>().raycastTarget = true;
                DragHandler.itemDragging = null;

                Debug.Log("PocionLista");
            }
            
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
