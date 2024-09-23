using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerPickUpDrop : MonoBehaviour
{
    // Todo: Inventory implementation
    [SerializeField] private Transform cameraPosition;
    [SerializeField] private Transform objectGrabPoint;
    [SerializeField] private LayerMask pickUpLayerMask;
    private ObjectGrabbable objectGrabbable;
    private float pickUpDistance = 10f;
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
                    }
                }   
            }
            else
            {
                objectGrabbable.Drop();
            }
        }
        // inventory stuff, check if it is grabbed then put in inventory
    }
}
