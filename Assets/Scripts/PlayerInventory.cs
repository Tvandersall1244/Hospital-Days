using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public Inventory inventory;
    public Transform playerTransform;
    public float spawnDistance = 2f;   // Distance in front of the player to spawn the item

    void Update()
    {
        HandleInventoryInput();
    }

    void HandleInventoryInput()
    {
        for (int i = 1; i <= inventory.items.Count; i++)
        {
            if (Input.GetKeyDown(i.ToString()))
            {
                InventoryItem selectedItem = inventory.GetItem(i - 1);
                if (selectedItem != null)
                {
                    Debug.Log("Selected item: " + selectedItem.name);
                    SpawnItemInFrontOfPlayer(selectedItem);

                    // Remove the item after use
                    inventory.items.RemoveAt(i - 1);
                    Debug.Log(selectedItem.name + " has been used and removed from the inventory.");
                    break;
                }
            }
        }
    }

    void SpawnItemInFrontOfPlayer(InventoryItem item)
    {
        if (item.prefab != null)
        {
            // Calculate the spawn position in front of the player
            Vector3 spawnPosition = playerTransform.position + playerTransform.forward * spawnDistance;

            float itemHeight = item.prefab.GetComponent<Renderer>().bounds.size.y;
            spawnPosition.y += itemHeight / 2;

            // Instantiate the item at the spawn position
            GameObject spawnedItem = Instantiate(item.prefab, spawnPosition, Quaternion.identity);

            Debug.Log(item.name + " has been spawned in front of the player.");
        }
        else
        {
            Debug.LogWarning("No prefab assigned for " + item.name);
        }
    }
}
