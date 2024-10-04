using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GamblingMinigameEvents : MonoBehaviour
{
    // Reference to Gambling Minigame
    public GameObject gamblingMinigame;

    // Image to use for button
    private Texture buttonImage;

    // Reference to UI Document
    private UIDocument _document;

    // Main container where everything goes
    private VisualElement _container;

    // Grid where all the multipliers go
    private VisualElement _gridContainer;

    // Footer where the goal and current states go
    private VisualElement _footer;

    // Map for creating the game with even multipliers
    private Dictionary<int, int> multipliers;

    // Random object for randomized multipliers
    private System.Random rand;

    private void Awake()
    {
        // Get button image
        buttonImage = Resources.Load<Texture>("tempGambleUI");

        // Instantiate random object
        rand = new System.Random();

        // Instantiate multipliers dictionary
        multipliers = new Dictionary<int, int>();

        // Get UI Document
        _document = GetComponent<UIDocument>();

        // Get Main Container
        _container = _document.rootVisualElement.Q<VisualElement>("Container");

        // Get Footer
        _footer = _document.rootVisualElement.Q<VisualElement>("Footer");

        // Get Grid Container
        _gridContainer = _document.rootVisualElement.Q<VisualElement>("ButtonContainer"); 
        
        // Initialize game
        CreateGamblingGame();
    }

    // Used to first initialize the gambling game upon starting the game
    private void CreateGamblingGame()
    {
        // Populate the multipliers
        ResetMultipliers();

        // Labels to Grid Element
        for (int i = 0; i < 16; i++)
        {
            _gridContainer.Add(MakeLabel());
        }

        // Make footer for minigame
        MakeFooter();
    }

    // Used to reset the gambling game
    private void ResetGamblingGame()
    {
        // Repopulate the multipliers
        ResetMultipliers();

        // Remove old multipliers and put in new ones
        for (int i = 0; i < 16; i++)
        {
            // Remove old multiplier
            _gridContainer.RemoveAt(0);

            // Add new multiplier
            _gridContainer.Add(MakeLabel());
        }

        // Reset footer
        ResetFooter();
    }

    // Reset multipliers for minigame
    private void ResetMultipliers()
    {
        // Add multipliers to hashtable
        multipliers.Add(2, 4);
        multipliers.Add(3, 4);
        multipliers.Add(4, 4);
        multipliers.Add(5, 4);
    }

    // Reset footer for minigame
    private void ResetFooter()
    {
        // Make current read '1x'
        _footer.Q<Label>("Current").text = "x1";
    }

    // Used to make labels for multipliers
    private Label MakeLabel()
    {
        // Get a random multiplier to put on label
        List<int> keys = new List<int>(multipliers.Keys);
        int size = multipliers.Count;
        int randMult = keys[rand.Next(size)];

        // Put multiplier on label
        Label mult = new Label("x" + randMult.ToString());

        // Decrement the allowed multipliers
        multipliers[randMult] = multipliers[randMult] - 1;

        // Set style for label
        mult.style.backgroundColor = Color.black;
        mult.style.color = Color.white;
        mult.style.fontSize = 50;
        mult.style.width = Length.Percent(24);
        mult.style.height = Length.Percent(24);
        mult.style.borderTopLeftRadius = 10;
        mult.style.borderTopRightRadius = 10;
        mult.style.borderBottomLeftRadius = 10;
        mult.style.borderBottomRightRadius = 10;
        mult.style.unityTextAlign = TextAnchor.MiddleCenter;

        // Button to cover the label
        mult.Add(MakeButton());

        // Remove random multiplier if there are no more available
        if (multipliers[randMult] == 0)
        {
            multipliers.Remove(randMult);
        }

        // Return the label
        return mult;
    }

    // Used to make button that goes on top of multipler
    private Button MakeButton()
    {
        // Instantiate button
        Button cover = new Button();

        // Set style for button
        cover.style.backgroundImage = (StyleBackground) buttonImage;
        cover.style.width = Length.Percent(100);
        cover.style.height = Length.Percent(100);
        cover.style.borderTopLeftRadius = 10;
        cover.style.borderTopRightRadius = 10;
        cover.style.borderBottomLeftRadius = 10;
        cover.style.borderBottomRightRadius = 10;

        // Give button a callback
        cover.RegisterCallback<ClickEvent>(ShowMultiplier);

        // Return the button
        return cover;
    }

    private void MakeFooter()
    {
        // Instantiate current state
        Label curr = new Label("x1");

        // Set style for current state
        curr.style.width = Length.Percent(50);
        curr.style.height = Length.Percent(100);
        curr.style.fontSize = 40;
        curr.style.color = Color.blue;
        curr.name = "Current";
        
        // Instantiate goal state
        Label goal = new Label("Max: x1000000");

        // Set style for goal state
        goal.style.width = Length.Percent(48);
        goal.style.height = Length.Percent(100);
        goal.style.fontSize = 40;
        goal.style.color = Color.green;

        // Add states to footer
        _footer.Add(curr);
        _footer.Add(goal);
        Debug.Log(_footer.childCount);
    }

    private void OnDisable()
    {
        // Get list of buttons for minigame
        List<Button> buttons = _document.rootVisualElement.Query<Button>().ToList();

        // Unregister callback for each one
        for (int i = 0; i < buttons.Count; i++)
        {
            _gridContainer[i].UnregisterCallback<ClickEvent>(ShowMultiplier);
        }
    }

    void Update()
    {
        // If 'F' is pressed, no more gambling :(
        if (Input.GetKeyDown(KeyCode.F))
        {
            _container.style.visibility = Visibility.Hidden;
            UnityEngine.Cursor.visible = false;
            UnityEngine.Cursor.lockState = CursorLockMode.Locked;
        }
        // If 'C' is pressed, GAMBLING TIME!!!! :D
        if (Input.GetKeyDown(KeyCode.C))
        {
            // Reset the gambling minigame
            ResetGamblingGame();
            _container.style.visibility = Visibility.Visible;
            UnityEngine.Cursor.visible = true;
            UnityEngine.Cursor.lockState = CursorLockMode.None;
        }
    }

    // Callback for when a button gets pressed on minigame
    private void ShowMultiplier(ClickEvent evt)
    {
        // Get button that was clicked
        Button btn = (Button) evt.currentTarget;

        // Get multiplier for that button
        Label mult = (Label) btn.parent;

        // Get current multiplier for minigame
        Label curr = _footer.Q<Label>("Current");

        // Strip the 'x' off and turn them into ints
        int multInt = int.Parse(mult.text.Substring(1));
        int currInt = int.Parse(curr.text.Substring(1));

        // Multiply the two together
        int newCurr = multInt * currInt;

        // Set current multiplier for minigame
        curr.text = "x" + newCurr;

        // Hide the button
        btn.style.visibility = Visibility.Hidden;
    }
}
