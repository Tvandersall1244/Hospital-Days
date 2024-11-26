using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    // Create a list to hold the inventory items
    public List<InventoryItem> items = new List<InventoryItem>();
    
    public Image[] slotImages;  // Array to hold references to the slot images
    public PlayerInventory playerInventory;  // Reference to the PlayerInventory script

    void Start()
    {
        UpdateInventoryUI();
    }

    // Add an item to the inventory
    public void AddItem(InventoryItem newItem)
    {
        items.Add(newItem);
        Debug.Log("Added item: " + newItem.name);
        UpdateInventoryUI();
    }

    // Access an item in the inventory by index
    public InventoryItem GetItem(int index)
    {
        if (index >= 0 && index < items.Count)
        {
            return items[index];
        }
        return null;
    }

    // Update the UI when items are added or removed
    void UpdateInventoryUI()
    {
        for (int i = 0; i < slotImages.Length; i++)
        {
            if (i < items.Count && items[i] != null)
            {
                slotImages[i].sprite = items[i].icon;
                slotImages[i].color = Color.white;
            }
            else
            {
                slotImages[i].sprite = null;
                slotImages[i].color = new Color(0, 0, 0, 0);
            }
        }
    }

    // Use an item and update the UI accordingly
    public void UseItem(int index)
    {
        if (index < items.Count && items[index] != null)
        {
            playerInventory.SpawnItemInFrontOfPlayer(items[index]);
            items.RemoveAt(index);
            UpdateInventoryUI();
        }
    }
}
