using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BBObject : MonoBehaviour, IBBInteractable
{
    public GameObject bbGameObject; // GameObject of bulletin board item

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Interact()
    {
        Debug.Log(bbGameObject.name + " has been interacted with.");
    }
}
