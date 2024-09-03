using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    // Create a list to hold the inventory items
    public List<InventoryItem> items = new List<InventoryItem>();

    // Add an item to the inventory
    public void AddItem(InventoryItem newItem)
    {
        items.Add(newItem);
        Debug.Log("Added item: " + newItem.name);
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
}
