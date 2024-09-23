using System.Collections;
using UnityEditor;
using UnityEngine;

public class BedSleep : MonoBehaviour
{
    private bool isPlayerNear = false;
    private FadeScreen fadeController;
    private GameManager gameManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = false;
        }
    }

    void Start()
    {
        fadeController = FindObjectOfType<FadeScreen>(); // Get the FadeScreen component
        gameManager = GameManager.instance;
    }

    void Update()
    {
        if (isPlayerNear && Input.GetKeyDown(KeyCode.E) && gameManager.coinMissionComplete) // If player is near bed and presses E
        {
            StartCoroutine(HandleBedSleep());
        }
    }

    // Coroutine to handle fading and the sleep interaction
    IEnumerator HandleBedSleep()
    {
        // Fade to black
        yield return StartCoroutine(fadeController.FadeIn());

        // Trigger the next day in the game
        gameManager.nextDay();
        yield return new WaitForSeconds(3f);

        // Save the game
        SaveSystem.Save();
        // SaveSystem.Load();

        // Fade back to the game view
        yield return StartCoroutine(fadeController.FadeOut());
    }
}
