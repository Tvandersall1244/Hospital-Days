using UnityEngine;

public class AffectionManager : MonoBehaviour
{
    private int affectionPoints = 0; // Initial affection points, starting at 0
    private int affectionLevel = 0;  // Initial affection level

    public void AddAffection(int points)
    {
        affectionPoints += points;
        CheckAffectionLevel();
    }

    public void DecreaseAffection(int points)
    {
        affectionPoints -= points;
        if (affectionPoints < 0) affectionPoints = 0;
        CheckAffectionLevel();
    }

    public int GetAffectionPoints()
    {
        return affectionPoints;
    }

    public int GetAffectionLevel()
    {
        return affectionLevel;
    }

    public void ResetAffection()
    {
        affectionPoints = 0;
        affectionLevel = 0;
    }

    // Check and update affection level based on the current points
    private void CheckAffectionLevel()
    {
        if (affectionPoints >= 100)
        {
            affectionLevel = 4;
        }
        else if (affectionPoints >= 50)
        {
            affectionLevel = 3;
        }
        else if (affectionPoints >= 20)
        {
            affectionLevel = 2;
        }
        else if (affectionPoints >= 1)
        {
            affectionLevel = 1;
        }
        else
        {
            affectionLevel = 0;
        }

        Debug.Log("Affection Points: " + affectionPoints + ", Affection Level: " + affectionLevel);
    }
}