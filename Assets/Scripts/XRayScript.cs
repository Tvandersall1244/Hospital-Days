using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XRayScript : MonoBehaviour
{
    // Start is called before the first frame update
    private List<KeyCode> testSequence = new List<KeyCode> {KeyCode.UpArrow, KeyCode.DownArrow, KeyCode.LeftArrow, KeyCode.RightArrow };
    private int step = 0;
    private bool gameStart = false;
    // Update is called once per frame
    
    void Update()
    {
        if (gameStart) {
            if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.LeftArrow)
        || Input.GetKeyDown(KeyCode.RightArrow)) 
        {
            checkInput();
        }
        }
    }
    //testing code
    void OnTriggerEnter(Collider other) 
    {
        if (other.CompareTag("Player")) 
        {
            Debug.Log("Player is close, start the minigame!");
            gameStart = true;
            step = 0;
        }

    }
    void OnTriggerExit(Collider other) 
    {
        if (other.CompareTag("Player")) 
        {
            Debug.Log("Exited the minigame successfully!");
            gameStart = false;
        }
    }
    void checkInput() 
    {
        if (Input.GetKeyDown(testSequence[step]))
        {
            RotateObject(testSequence[step]);
            Debug.Log("Correct!");
            step++;
        }
        if (step >= testSequence.Count) 
        {
            Debug.Log("Sequence Complete!");
            step = 0;
        }
        else
        {
            Debug.Log("Wrong Arrow Key...");

        }
    }

    void RotateObject(KeyCode key) {
        switch (key)
        {
            case KeyCode.UpArrow:
                transform.Rotate(Vector3.left * 90); // Rotate 90 degrees to the left (around the x-axis)
                break;
            case KeyCode.RightArrow:
                transform.Rotate(Vector3.up * 90); // Rotate 90 degrees upwards (around the y-axis)
                break;
            case KeyCode.DownArrow:
                transform.Rotate(Vector3.right * 90); // Rotate 90 degrees to the right (around the x-axis)
                break;
            case KeyCode.LeftArrow:
                transform.Rotate(Vector3.down * 90); // Rotate 90 degrees downwards (around the y-axis)
                break;
        }
    }
}
