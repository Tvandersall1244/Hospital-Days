using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayManager : MonoBehaviour
{
    public static DayManager Instance { get; private set;}
    private enum State {
        day1, day2, day3, day4, day5, day6, day7,
    }

    private State day;

    private void Awake() {
        Instance = this;

        day = State.day6;
    }
    
    public bool IsDay7() {
        return day == State.day7;
    }
}
