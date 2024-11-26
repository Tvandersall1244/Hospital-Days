using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.TerrainUtils;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Yarn.Unity;


public class TestOfObjecPlacement : MonoBehaviour
{

    private bool hasItem;
    private bool placedItem;
    private bool inRange = false;
    private string objectName = "Picture Frame";
    public GameObject itemToPlace;
    public Material ShadowMaterial;
    public Material FinalMaterial1; //as many as there needs to be for the actual object
    public Material FinalMaterial2;
    public GameObject imageUI;
    public TextMeshProUGUI textUI;
    InventoryUI test;

    /*
    Pseudocode:
    -On start, inRange should be false, model should not be visible at all.
    -Once the player receives the corresponding item (such as picture frame), hasItem will be true.
    When hasItem is true, the model is always visible but with a transparency and shadow texture.
    -When the player walks through the hitbox object, the GUI will appear, inRange = true (likely on Torri's canvas).
    When the player exits the hitbox object, the GUI will disappear, inRange = false.
    -When the player interacts with the GUI, placedItem will be true, hasItem will be false. Item leaves player's inventory,
    GUI stops appearing, and the item will have 0 transparency and its intended texture. 
    The script should essentially no longer run any functions while it updates.
    */

    // Start is called before the first frame update
    void Start()
    {
        hasItem = false;
        placedItem = false;
        itemToPlace.SetActive(false);
        test = FindObjectOfType<InventoryUI>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F)){
            if(inRange && test.contains("picture frame") && !placedItem) {
                placedItem = true;
                itemToPlace.transform.GetChild(0).gameObject.GetComponent<Renderer>().material = FinalMaterial1;
                itemToPlace.transform.GetChild(1).gameObject.GetComponent<Renderer>().material = FinalMaterial2;
                imageUI.SetActive(false);
                textUI.GetComponent<TMP_Text>().text = "F- Place ";
                test.remove("picture frame");
            }
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        //if(hasItem){
            GameObject o = other.gameObject;
            if (o.CompareTag("Player") || o.CompareTag("MainCamera"))
            {
               // Execute your desired event code here
               inRange = true;
               Debug.Log(test.inventory[0]);
                if( !placedItem && test.contains("picture frame")) {
                    //GUI appears (Press F for now)
                    itemToPlace.SetActive(true);
                    imageUI.SetActive(true);
                    //textUI.SetActive(true);
                    //Text temp = textUI.GetComponent<Text>(); //Null?
                    textUI.GetComponent<TMP_Text>().text += objectName;
                    itemToPlace.transform.GetChild(0).gameObject.GetComponent<Renderer>().material = ShadowMaterial;
                    itemToPlace.transform.GetChild(1).gameObject.GetComponent<Renderer>().material = ShadowMaterial;

                }
            }
        //}
    }

    void OnTriggerExit(Collider other) {
        //if(hasItem && !placedItem){
            GameObject o = other.gameObject;
            if (o.CompareTag("Player") || o.CompareTag("MainCamera"))
            {
              // Execute your desired event code here
               inRange = false;
               if(!placedItem && test.contains("picture frame")) {
                    itemToPlace.SetActive(false);
                    //GUI disappears
                    imageUI.SetActive(false);
                    textUI.GetComponent<TMP_Text>().text = "F- Place ";
                    //textUI.SetActive(false);
               }
            }
        //}

    }
}
