using UnityEngine;
using UnityEngine.Events;

public class AreaUnlock : MonoBehaviour
{
    // Store Day Change event
    private UnityEvent m_dayChange;

    // Store Library, Play Room, and Waiting Room doors
    public GameObject libraryDoor;
    public GameObject playRoomDoor;
    public GameObject waitingRoomDoor;

    void Start()
    {
        // If Day Change event is null, instantiate it
        if (m_dayChange == null)
        {
            m_dayChange = new UnityEvent();
        }

        // Set Day Change event listener to DayChange function
        m_dayChange.AddListener(DayChange);
    }

    void Update()
    {
        // If 'R' was pressed and Day Change event is not null, invoke the event
        if (Input.GetKeyDown(KeyCode.R) && m_dayChange != null)
        {
            GameManager.instance.nextDay();
            m_dayChange.Invoke();
        }
    }

    // DayChange event callback that changes the day and checks if any area should be unlocked
    void DayChange()
    {
        // If third day, unlock Library
        if (GameManager.instance.currentDay == 2)
        {
            Destroy(libraryDoor);
            Debug.Log("Library has been unlocked!");
        }

        // If fourth day, unlock Play Room
        if (GameManager.instance.currentDay == 3)
        {
            Destroy(playRoomDoor);
            Debug.Log("Play Room has been unlocked!");
        }

        // If fifth day, unlock Waiting Room
        if (GameManager.instance.currentDay == 4)
        {
            Destroy(waitingRoomDoor);
            Debug.Log("Waiting Room has been unlocked.");
        }
    }
}
