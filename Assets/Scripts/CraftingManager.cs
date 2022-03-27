using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftingManager : Singleton<CraftingManager>
{
    public ItemInfo[] registeredRecipes;
    private ItemInfo currentItem;
    public Image customCursor;
    public GameObject[] craftingSlots;
    public GameObject inventoryUI;
    public GameObject itemDisplayPrefab;
    public GameObject result;

    private void Update() {
        if(Input.GetMouseButtonUp(0)){
            if(currentItem != null){
                customCursor.gameObject.SetActive(false);
                GameObject nearestSlot = null;
                float shortestDistance = 128f;

                foreach(GameObject slot in craftingSlots){
                    float dist = Vector2.Distance(Input.mousePosition, slot.transform.position);
                    if(dist < shortestDistance){
                        shortestDistance = dist;
                        nearestSlot = slot;
                    }
                }
                if (nearestSlot != null)
                {
                    // Return item to inventory if already in the slot
                    if (nearestSlot.GetComponent<ItemDisplay>().item != null)
                        PlayerManager.Instance.inventory.Add(nearestSlot.GetComponent<ItemDisplay>().item);
                    nearestSlot.GetComponent<ItemDisplay>().SetItem(currentItem);
                    CheckRecipes();
                }
                else
                {
                    PlayerManager.Instance.inventory.Add(currentItem);
                }
                currentItem = null;
                UpdateItems();
            }
        }
    }

    public void UpdateItems()
    {
        inventoryUI.transform.DestroyChildren();
        foreach(ItemInfo item in PlayerManager.Instance.inventory.items)
        {
            GameObject display = Instantiate(itemDisplayPrefab, inventoryUI.transform);
            display.GetComponent<ItemDisplay>().SetItem(item);
        }
    }

    public void CheckRecipes()
    {
        List<ItemInfo> ingredients = new List<ItemInfo>();
        foreach(GameObject slot in craftingSlots)
        {
            if (slot.GetComponent<ItemDisplay>().item != null)
                ingredients.Add(slot.GetComponent<ItemDisplay>().item);
        }
        foreach(ItemInfo recipe in registeredRecipes)
        {
            List<ItemInfo> tempItems = new List<ItemInfo>(ingredients);
            bool matched = false;
            for(int i = 0; i < recipe.recipe.Length; i++)
            {
                if (tempItems.Contains(recipe.recipe[i]))
                    tempItems.Remove(recipe.recipe[i]);
                else
                    break;
                if (i == recipe.recipe.Length - 1 && tempItems.Count == 0)
                    matched = true;
            }
            if(matched)
            {
                result.GetComponent<ItemDisplay>().SetItem(recipe);
                return;
            }
        }
        result.GetComponent<ItemDisplay>().SetItem(null);
    }

    public void Craft(ItemInfo item)
    {
        for(int i = 0; i < craftingSlots.Length; i++)
        {
            craftingSlots[i].GetComponent<ItemDisplay>().SetItem(null);
        }
        UpdateItems();
    }

    public void  OnMouseDownItem(ItemDisplay item) {
        if(currentItem == null && item.item != null){
            currentItem = item.item;
            customCursor.gameObject.SetActive(true);
            customCursor.sprite = item.item.sprite;//currentItem.GetComponent<Image>().sprite;
            item.SetItem(null);
            if(!item.craftingSlot && !item.resultSlot)
                PlayerManager.Instance.inventory.Remove(currentItem);
            CheckRecipes();
            UpdateItems();
        }
    }
}
