using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public static GameManager instance;

    public int currentDay;

    private void Awake() {
        CreateSingleton();
    }

    void CreateSingleton() {
        if (instance == null) {
            instance = this;
        } else {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    public void nextDay() {
        currentDay++;
    }
}


