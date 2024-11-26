using UnityEngine;

public class Book : MonoBehaviour
{
    private bool isSelected;

    public void SetisSelected(bool isSelected)
    {
        this.isSelected = isSelected;
    }

    public bool GetisSelected()
    {
        return isSelected;
    }
}