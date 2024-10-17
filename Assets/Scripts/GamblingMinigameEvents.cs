using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GamblingMinigameEvents : MonoBehaviour
{
    // Reference to Gambling Minigame
    public GameObject gamblingMinigame;

    // Reference to UI Document
    private UIDocument _document;

    // Main container where everything goes
    private VisualElement _container;

    // Grid where all the multipliers go
    private VisualElement _gridContainer;

    // Sidebar where the row sums go
    private VisualElement _sidebar;

    // Footer where the goal and current states go
    private VisualElement _footer;

    // Label that tells player what the max score is
    private Label _goalScore;

    // Label that telss player what their current score is
    private Label _score;

    // Button for cashing out of the gambling minigame
    private Button _cashOut;

    // Map for creating the game with even multipliers
    private Dictionary<int, int> multipliers;

    // Random object for randomized multipliers
    private System.Random rand;

    // Sum of multipliers for each row
    private int rowSum;

    // List of colors to use for UI
    private List<Color> colors;

    private void Awake()
    {
        // Instantiate random object
        rand = new System.Random();

        // Instantiate multipliers dictionary
        multipliers = new Dictionary<int, int>();

        // Instantiate colors
        colors = new List<Color>(4);
        colors.Add(new Color(123.0f / 255, 203.0f / 255, 192.0f / 255));
        colors.Add(new Color(191.0f / 255, 58.0f / 255, 86.0f / 255));
        colors.Add(new Color(134.0f / 255, 168.0f / 255, 79.0f / 255));
        colors.Add(new Color(74.0f / 255, 123.0f / 255, 160.0f / 255));

        // Get UI Document
        _document = GetComponent<UIDocument>();

        // Get Main Container
        _container = _document.rootVisualElement.Q<VisualElement>("Container");

        // Get Footer
        _footer = _document.rootVisualElement.Q<VisualElement>("Footer");

        // Get Grid Container
        _gridContainer = _document.rootVisualElement.Q<VisualElement>("ButtonContainer"); 

        // Get Sidebar
        _sidebar = _document.rootVisualElement.Q<VisualElement>("Sidebar");

        // Get GoalScore
        _goalScore = _document.rootVisualElement.Q<Label>("GoalAmount");

        // Get Score
        _score = _document.rootVisualElement.Q<Label>("ScoreAmount");

        // Get Cash Out button
        _cashOut = _document.rootVisualElement.Q<Button>("CashOut");

        // Set the Cash Out button's callback
        _cashOut.RegisterCallback<ClickEvent>(CashOut);

        // Initialize game
        CreateGamblingGame();
    }

    // Used to first initialize the gambling game upon starting the game
    private void CreateGamblingGame()
    {
        // Populate the multipliers
        ResetMultipliers();

        // Initialize row sum to 0
        rowSum = 0;

        // Initialize column sums to 0
        int colSum1 = 0;
        int colSum2 = 0;
        int colSum3 = 0;
        int colSum4 = 0;

        // Labels to Grid Element
        for (int i = 0; i < 16; i++)
        {
            // Get a random multiplier to put on label
            List<int> keys = new List<int>(multipliers.Keys);
            int size = multipliers.Count;
            int randMult = keys[rand.Next(size)];

            // If we reach the end of the row, add the row sum to the side bar and reset row sum
            // Else, do not add to the side bar
            if (i % 4 == 3)
            {
                _gridContainer.Add(MakeMult(randMult, true, i));
                rowSum = 0;
            }
            else
            {
                _gridContainer.Add(MakeMult(randMult, false, i));
            }

            // Add the multiplier to its respective column
            if (i % 4 == 0)
            {
                colSum1 += randMult;
            }
            else if (i % 4 == 1)
            {
                colSum2 += randMult;
            }
            else if (i % 4 == 2)
            {
                colSum3 += randMult;
            }
            else
            {
                colSum4 += randMult;
            }
        }

        // Make footer for minigame
        MakeFooter(colSum1, colSum2, colSum3, colSum4);

        List<int> tempKeys = new List<int>(multipliers.Keys);
        for (int i = 0; i < tempKeys.Count; i++)
        {
            Debug.Log("Key: " + tempKeys[i] + ", Value: " + multipliers[tempKeys[i]]);
        }

        // Setup GameInfo
        ResetGameInfo();
    }

    // Used to reset the gambling game
    private void ResetGamblingGame()
    {
        // Repopulate the multipliers
        ResetMultipliers();

        // Initialize column sums to 0
        int colSum1 = 0;
        int colSum2 = 0;
        int colSum3 = 0;
        int colSum4 = 0;

        // Remove old multipliers and put in new ones
        for (int i = 0; i < 16; i++)
        {
            // Get a random multiplier to put on label
            List<int> keys = new List<int>(multipliers.Keys);
            int size = multipliers.Count;
            int randMult = keys[rand.Next(size)];

            // Remove old multiplier
            _gridContainer.RemoveAt(0);

            // If we reach the end of the row, add the row sum to the side bar
            // Else, do not add to the side bar
            if (i % 4 == 3)
            {
                _gridContainer.Add(MakeMult(randMult, false, i)); 
                ResetSidebar(i / 4);
                rowSum = 0;
            }
            else
            {
                _gridContainer.Add(MakeMult(randMult, false, i));
            }

            // Add the multiplier to its respective column
            if (i % 4 == 0)
            {
                colSum1 += randMult;
            }
            else if (i % 4 == 1)
            {
                colSum2 += randMult;
            }
            else if (i % 4 == 2)
            {
                colSum3 += randMult;
            }
            else
            {
                colSum4 += randMult;
            }
        }

        // Reset footer
        ResetFooter(colSum1, colSum2, colSum3, colSum4);

        // Reset game info
        ResetGameInfo();
    }

    // Reset multipliers for minigame
    private void ResetMultipliers()
    {
        // Clear the multipliers dictionary
        multipliers.Clear();

        // Add multipliers to dictionary
        multipliers.Add(2, 4);
        multipliers.Add(3, 4);
        multipliers.Add(4, 4);
        multipliers.Add(5, 4);
    }

    // Reset the sidebar for minigame
    private void ResetSidebar(int row)
    {
        // Get the sidebar rows
        List<Label> rows = _sidebar.Query<Label>().ToList();

        // Change the row sum for the sidebar
        rows[row].text = "<b>" + rowSum + "</b>";
    }

    // Reset footer for minigame
    private void ResetFooter(int colSum1, int colSum2, int colSum3, int colSum4)
    {
        // Get the column sums
        List<Label> colSums = _footer.Query<Label>().ToList();

        // Update all the column sum labels

        colSums[0].text = "<b>" + colSum1 + "</b>";
        colSums[1].text = "<b>" + colSum2 + "</b>";
        colSums[2].text = "<b>" + colSum3 + "</b>";
        colSums[3].text = "<b>" + colSum4 + "</b>";
    }

    // Reset game info for minigame
    private void ResetGameInfo()
    {
        // Get random number between 600 and 999 to display for goal score
        int goal = rand.Next(400) + 600;
        _goalScore.text = "" + goal;

        // Set current score to 1
        _score.text = "1";
    }

    // Used to make labels for multipliers
    private Label MakeMult(int randMult, bool sumRow, int i)
    {
        // Put multiplier on label
        Label mult = new Label("x" + randMult.ToString());

        // Add multiplier to row sum
        rowSum += randMult;

        // Decrement the allowed multipliers
        multipliers[randMult] = multipliers[randMult] - 1;

        // Set style for label
        mult.style.color = new Color(170.0f / 255, 206.0f / 255, 236.0f / 255);
        mult.style.fontSize = 50;
        mult.style.width = Length.Percent(24);
        mult.style.height = Length.Percent(24);
        mult.style.borderTopLeftRadius = 10;
        mult.style.borderTopRightRadius = 10;
        mult.style.borderBottomLeftRadius = 10;
        mult.style.borderBottomRightRadius = 10;
        mult.style.unityTextAlign = TextAnchor.MiddleCenter;

        // Button to cover the label
        mult.Add(MakeButton(i));

        // If we reach the end of the row, add the row sum to the side bar
        if (sumRow)
        {
            // Set the color dependent on the row
            if (_sidebar.childCount == 0)
            {
                _sidebar.Add(MakeSidebar(new Color(123.0f / 255, 203.0f / 255, 192.0f / 255)));
            } 
            else if (_sidebar.childCount == 1) 
            {
                _sidebar.Add(MakeSidebar(new Color(191.0f / 255, 58.0f / 255, 86.0f / 255)));
            } 
            else if (_sidebar.childCount == 2) 
            {
                _sidebar.Add(MakeSidebar(new Color(134.0f / 255, 168.0f / 255, 79.0f / 255)));
            } 
            else 
            {
                _sidebar.Add(MakeSidebar(new Color(74.0f / 255, 123.0f / 255, 160.0f / 255)));
            }
        }

        // Remove random multiplier if there are no more available
        if (multipliers[randMult] == 0)
        {
            multipliers.Remove(randMult);
        }

        // Return the label
        return mult;
    }

    // Used to make button that goes on top of multipler
    private Button MakeButton(int i)
    {
        // Instantiate button
        Button cover = new Button();

        // Set style for button
        cover.style.width = Length.Percent(100);
        cover.style.height = Length.Percent(100);
        cover.style.borderTopLeftRadius = Length.Percent(30);
        cover.style.borderTopRightRadius = Length.Percent(30);
        cover.style.borderBottomLeftRadius = Length.Percent(30);
        cover.style.borderBottomRightRadius = Length.Percent(30);
        cover.style.backgroundColor = new Color(0, 0, 0, 0);

        // Set image based on position
        switch (i)
        {
            case 0:
                cover.style.backgroundImage = (StyleBackground) Resources.Load<Texture>("GambaUI_Cap1"); // Position (1,1)
                break;
            case 5:
                cover.style.backgroundImage = (StyleBackground) Resources.Load<Texture>("GambaUI_Cap2"); // Position (2,2)
                break;
            case 10:
                cover.style.backgroundImage = (StyleBackground) Resources.Load<Texture>("GambaUI_Cap3"); // Position (3,3)
                break;
            case 15:
                cover.style.backgroundImage = (StyleBackground) Resources.Load<Texture>("GambaUI_Cap4"); // Position (4,4)
                break;
            default:
                cover.style.backgroundImage = (StyleBackground) Resources.Load<Texture>("GambaUI_Cap5"); // All other positions
                break;
        }

        // Give button a callback
        cover.RegisterCallback<ClickEvent>(ShowMultiplier);

        // Return the button
        return cover;
    }

    // Used to make the side bar with the multiplier sums for each row
    private Label MakeSidebar(Color textColor)
    {
        // Instantiate label for side bar with row sum
        Label sum = new Label("<b>" + rowSum + "</b>");

        // Set style for row sum
        sum.style.width = Length.Percent(100);
        sum.style.height = Length.Percent(18);
        sum.style.marginBottom = Length.Percent(34);
        sum.style.fontSize = 50;
        sum.style.color = textColor;
        sum.style.unityTextOutlineColor = Color.white;
        sum.style.unityTextOutlineWidth = 2;
        sum.style.unityTextAlign = TextAnchor.MiddleCenter;

        // Return label
        return sum;
    }

    private void MakeFooter(int sum1, int sum2, int sum3, int sum4)
    {
        // Instantiate label for side bar with row sum
        Label colSum1 = new Label("<b>" + sum1 + "</b>");

        // Set style for row colSum1
        colSum1.name = "ColSum1";
        colSum1.style.width = Length.Percent(23);
        colSum1.style.height = Length.Percent(100);
        colSum1.style.marginRight = Length.Percent(3);
        colSum1.style.fontSize = 50;
        colSum1.style.color = colors[0];
        colSum1.style.unityTextOutlineColor = Color.white;
        colSum1.style.unityTextOutlineWidth = 2;
        colSum1.style.unityTextAlign = TextAnchor.MiddleCenter;

        // Add the column sum to the footer
        _footer.Add(colSum1);

        // Instantiate label for side bar with row sum
        Label colSum2 = new Label("<b>" + sum2 + "</b>");

        // Set style for row colSum2
        colSum2.name = "ColSum2";
        colSum2.style.width = Length.Percent(23);
        colSum2.style.height = Length.Percent(100);
        colSum2.style.marginRight = Length.Percent(3);
        colSum2.style.fontSize = 50;
        colSum2.style.color = colors[1];
        colSum2.style.unityTextOutlineColor = Color.white;
        colSum2.style.unityTextOutlineWidth = 2;
        colSum2.style.unityTextAlign = TextAnchor.MiddleCenter;

        // Add the column sum to the footer
        _footer.Add(colSum2);

        // Instantiate label for side bar with row sum
        Label colSum3 = new Label("<b>" + sum3 + "</b>");

        // Set style for row colSum3
        colSum3.name = "ColSum3";
        colSum3.style.width = Length.Percent(23);
        colSum3.style.height = Length.Percent(100);
        colSum3.style.marginRight = Length.Percent(3);
        colSum3.style.fontSize = 50;
        colSum3.style.color = colors[2];
        colSum3.style.unityTextOutlineColor = Color.white;
        colSum3.style.unityTextOutlineWidth = 2;
        colSum3.style.unityTextAlign = TextAnchor.MiddleCenter;

        // Add the column sum to the footer
        _footer.Add(colSum3);

        // Instantiate label for side bar with row sum
        Label colSum4 = new Label("<b>" + sum4 + "</b>");

        // Set style for row colSum4
        colSum4.name = "ColSum4";
        colSum4.style.width = Length.Percent(23);
        colSum4.style.height = Length.Percent(100);
        colSum4.style.marginRight = Length.Percent(3);
        colSum4.style.fontSize = 50;
        colSum4.style.color = colors[3];
        colSum4.style.unityTextOutlineColor = Color.white;
        colSum4.style.unityTextOutlineWidth = 2;
        colSum4.style.unityTextAlign = TextAnchor.MiddleCenter;

        // Add the column sum to the footer
        _footer.Add(colSum4);
    }

    private void OnDisable()
    {
        // Get buttons to disable callback for
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

        // Strip the 'x' off and turn them into ints
        int multInt = int.Parse(mult.text.Substring(1));
        int currInt = int.Parse(_score.text);

        // Multiply the two together
        int newCurr = multInt * currInt;

        // Set current multiplier for minigame
        _score.text = "" + newCurr;

        // Check to see if gambler lost the game
        if (newCurr > int.Parse(_goalScore.text))
        {
            Debug.Log("You gambled too hard. :(");
            _container.style.visibility = Visibility.Hidden;
            UnityEngine.Cursor.visible = false;
            UnityEngine.Cursor.lockState = CursorLockMode.Locked;
        }

        // Hide the button
        btn.style.visibility = Visibility.Hidden;
    }

    // Funtionality for when a player wants to cash out
    private void CashOut(ClickEvent evt)
    {
        // Get the current score and the goal score
        int score = int.Parse(_score.text);
        int goal = int.Parse(_goalScore.text);

        // Calculate ratio of score to goal
        float ratio = ((float) score) / goal;

        // Reward player based on how close ratio is to 1
        int reward;
        if (ratio > 0.9)
        {
            reward = 5;
        }
        else if (ratio > 0.8)
        {
            reward = 4;
        }
        else if (ratio > 0.7)
        {
            reward = 3;
        }
        else if (ratio > 0.6)
        {
            reward = 2;
        }
        else if (ratio > 0.5)
        {
            reward = 1;
        }
        else
        {
            reward = 0;
        }
        Debug.Log("Nice gambling! You've won " + reward + " of something!");

        // Hide gambling game
        _container.style.visibility = Visibility.Hidden;
        UnityEngine.Cursor.visible = false;
        UnityEngine.Cursor.lockState = CursorLockMode.Locked;
    }
}
