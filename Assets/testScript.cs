using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Yarn.Unity;

public class testScript : MonoBehaviour
{
[SerializeField]
    private DialogueRunner dialogueRunner;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other) {
        Debug.Log("Ouch");
        dialogueRunner.StartDialogue("bed");
    }
}
