using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PauseScreen : MonoBehaviour
{
    public static bool isPaused = false;
    [SerializeField] public GameObject pauseScreenUI; // Assign this game object to Pause Screen (Not Pause Screen System)
    [SerializeField] public GameObject gameCamera; // Assign this game object to the character's camera!
    //[SerializeField] public Button resume;
    //[SerializeField] public Button options;
    //[SerializeField] public Button titleScreen;
    
    // Update is called once per frame
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (isPaused) {
                ResumeGame();
            } else {
                PauseGame();
            }
        }

    }

    public void ResumeGame() 
    {
        pauseScreenUI.SetActive(false);
        Time.timeScale = 1f;
        gameCamera.GetComponent<CameraMovement>().enabled = true;
        isPaused = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void PauseGame() 
    {
        pauseScreenUI.SetActive(true);
        Time.timeScale = 0f;
        gameCamera.GetComponent<CameraMovement>().enabled = false;
        isPaused = true;
        Cursor.lockState = CursorLockMode.Confined;
    }
}
