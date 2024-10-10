using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using Yarn.Unity;

public class GameManager : MonoBehaviour {
    public static GameManager instance;

    public int currentDay;
    public bool coinMissionComplete;

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


