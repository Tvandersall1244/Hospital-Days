using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class GamblingMinigameEvents : MonoBehaviour
{
    // Reference to Gambling Minigame
    public GameObject gamblingMinigame;

    // Reference to UI Document
    private UIDocument _document;

    // Reference to all buttons

    private List<Button> _gamblingButtons;
    
    private void Awake()
    {
        // Get UI Document
        _document = GetComponent<UIDocument>();

        // Get list of Buttons
        _gamblingButtons = _document.rootVisualElement.Query<Button>().ToList();
        for (int i = 0; i < _gamblingButtons.Count; i++)
        {
            _gamblingButtons[i].RegisterCallback<ClickEvent>(ShowMultiplier);
        }
    }

    private void OnDisable()
    {
        // Unregister callback for all buttons
        for (int i = 0; i < _gamblingButtons.Count; i++)
        {
            _gamblingButtons[i].UnregisterCallback<ClickEvent>(ShowMultiplier);
        }
    }

    void Update()
    {
        // If 'F' is pressed, no more gambling :(
        if (Input.GetKeyDown(KeyCode.F))
        {
            gamblingMinigame.gameObject.SetActive(false);
            UnityEngine.Cursor.visible = false;
            UnityEngine.Cursor.lockState = CursorLockMode.Locked;
        }
    }

    private void ShowMultiplier(ClickEvent evt)
    {
        this.gameObject.SetActive(false);
    }
}
