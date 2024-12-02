using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TEMPObjectMover : MonoBehaviour
{

    public GameObject day1Spot;
    public GameObject pull;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F)){
            print("E");
            pull.transform.position = day1Spot.transform.position;
            pull.transform.localScale = new UnityEngine.Vector3(1.5f, 1.5f, 1.5f);
        }
    }
}
