using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerObjectInteraction : MonoBehaviour
{
    // Todo: Inventory implementation
    // logic for methods, reference to class
    [SerializeField] private Transform cameraPosition;
    [SerializeField] private Transform objectGrabPoint;
    [SerializeField] private LayerMask pickUpLayerMask;
    private ObjectGrabbable objectGrabbable;
    private bool holdingObject = false;
    private float pickUpDistance = 10f;
    
    [SerializeField] private Inventory inventory;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (objectGrabbable == null)
            {
                if (Physics.Raycast(cameraPosition.position, cameraPosition.forward, out RaycastHit raycastHit,
                        pickUpDistance, pickUpLayerMask))
                {
                    if (raycastHit.transform.TryGetComponent(out objectGrabbable))
                    {
                        objectGrabbable.Grab(objectGrabPoint);
                        holdingObject = true;
                    }
                }   
            }
            else
            {
                objectGrabbable.Drop();
                holdingObject = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.Q) && holdingObject)
        {
            // null check in case something that is grabbable can't be put in inventory/doesn't have an item reference
            if (objectGrabbable.GetInventoryItem != null)
            {
                inventory.AddItem(objectGrabbable.GetInventoryItem);   
                objectGrabbable.Remove();
                holdingObject = false;
            }
        }
    }
}
