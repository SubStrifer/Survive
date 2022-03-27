using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemDisplay : MonoBehaviour, IPointerDownHandler
{
    public bool craftingSlot;
    public bool resultSlot;
    public ItemInfo item { get; private set; }

    public void OnPointerDown(PointerEventData eventData)
    {
        if(resultSlot && item != null)
        {
            CraftingManager.Instance.Craft(item);
        }
        CraftingManager.Instance.OnMouseDownItem(this);
        
        SetItem(null);
    }

    public void SetItem(ItemInfo item)
    {
        this.item = item;
        GetComponent<Image>().sprite = item?.sprite ?? null;

    }
}