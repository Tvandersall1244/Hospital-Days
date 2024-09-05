using UnityEngine;
using UnityEngine.Events;

public class AreaUnlock : MonoBehaviour
{
    // THIS IS A TEMPORARY SOLUTION!!!
    // Create enum for different hospital days
    private enum HospitalDay
    {
        DayOne,
        DayTwo,
        DayThree,
        DayFour,
        DayFive,
        DaySix,
        DaySeven
    }

    // Store current day
    private HospitalDay currentDay;

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
        // If 'R' was pressed and Day Change event is not null, evoke the event
        if (Input.GetKeyDown(KeyCode.R) && m_dayChange != null)
        {
            m_dayChange.Invoke();
        }
    }

    // DayChange event callback that changes the day and checks if any area should be unlocked
    void DayChange()
    {
        // If we haven't reached the last day, change the current day to the next
        if (currentDay != HospitalDay.DaySeven)
        {
            ++currentDay;
        }
        
        Debug.Log(currentDay);
        // If third day, unlock Library
        if (currentDay == HospitalDay.DayThree)
        {
            Destroy(libraryDoor);
            Debug.Log("Library has been unlocked!");
        }

        // If fourth day, unlock Play Room
        if (currentDay == HospitalDay.DayFour)
        {
            Destroy(playRoomDoor);
            Debug.Log("Play Room has been unlocked!");
        }

        // If fifth day, unlock Waiting Room
        if (currentDay == HospitalDay.DayFive)
        {
            Destroy(waitingRoomDoor);
            Debug.Log("Waiting Room has been unlocked.");
        }
    }
}
