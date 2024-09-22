using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEngine;

// if we don't want saves to be visible to player, use Application.persistentDataPath instead of Application.dataPath (goes to AppData folder)

public class SaveSystem : MonoBehaviour
{

    public class SaveData //SaveData file class
    {
        public int day;
        public bool coinMissionComplete;
    }

    public static SaveData CreateSaveData() { // Create a new SaveData file for saving, returns the SaveData file to the Save method
        SaveData data = new SaveData // add all the data we want to save here (e.g. GameManager data)
        {
            day = GameManager.instance.currentDay,
            coinMissionComplete = GameManager.instance.coinMissionComplete
        };
        return data;
    }

    public static void Save() // Save the SaveData file to the savefile.json file
    {
        SaveData data = CreateSaveData();
        string json = JsonUtility.ToJson(data);
        System.IO.File.WriteAllText(Application.dataPath + "/hospital.sav", json);
        Debug.Log(Application.dataPath);
    }

    public static void Load() // Load the SaveData file from the savefile.json file
    {
        string path = Application.dataPath + "/hospital.sav";
        if (System.IO.File.Exists(path))
        {
            string json = System.IO.File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            GameManager.instance.currentDay = data.day;
            GameManager.instance.coinMissionComplete = data.coinMissionComplete;
            Debug.Log("Game loaded!");
            Debug.Log("Day: " + data.day);
        }
        else
        {
            Debug.Log("Save file not found :(");
        }
    }

    public static void Delete() // Delete the savefile.json file (unused for now) (could be used for like a New Game button)
    {
        string path = Application.dataPath + "/hospital.sav";
        if (System.IO.File.Exists(path))
        {
            System.IO.File.Delete(path);
        }
    }

    public static bool SaveExists()
    {
        string path = Application.dataPath + "/hospital.sav";
        return System.IO.File.Exists(path);
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
