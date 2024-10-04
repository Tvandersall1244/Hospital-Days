using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Interface to put on interactable bulletin board items
interface IBBInteractable
{
    public void Interact();
}

public class BBInteractor : MonoBehaviour
{
    public Transform InteractorSource; // Reference to Transform in which interacting Ray will be casted
    public float InteractRange; // Length of interacting Raycast
    public GameObject GambleMinigame; // REMOVE LATER: Gamble Minigame Object

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // If player presses 'E'
        if (Input.GetKeyDown(KeyCode.E))
        {
            Ray r = new Ray(InteractorSource.position, InteractorSource.forward); // Create Raycast with position and direction of InteractorSource (camera)
            // If Raycast detects collider
            if (Physics.Raycast(r, out RaycastHit hitInfo, InteractRange))
            {
                // If collider object is a interactable bulletin board object
                if (hitInfo.collider.gameObject.TryGetComponent(out IBBInteractable interactObj))
                {
                    // Interact with object
                    interactObj.Interact();
                }
            }
        }
    }
}
