using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class MainStoryGacha : MonoBehaviour
{
    // Start is called before the first frame update
    private GameManager gameManager;
    public int currentDay;
    public bool hasCoin;
    private bool usedCoin;

    
    [SerializeField]
    public GameObject pull1, pull2, pull3, pull4, pull5, pull6;
    [SerializeField]
    private GameObject capsule;

  
    
    void Start()
    {
        print("This should show up too");
        gameManager = GameManager.instance;
        //currentDay = gameManager.currentDay;
        //hasCoin = gameManager.coinMissionComplete;
        currentDay = 3; //to comment out
        hasCoin = true; //to comment out
        usedCoin = false;
    }

    void checkDay(int currentDay, bool hasCoin)
    {

        print("Current day: " + currentDay + ", hasCoin: " + hasCoin);
        if(currentDay == 7)
        {
            //This should call the 7th day function to end the game
        }
        else if(currentDay > 7 || currentDay < 0)
        {
            Debug.Log("Error: Invalid Day. Not within the range 1-7.");
        }
        //Okay, valid day. Now check if they have a coin.
        else if(hasCoin == false)
        {
            //this should display some message saying that Torri needs a coin to use machine
        }
        else if(usedCoin == true)
        {
            //this should display some other message saying that the machine has already been used today.
        }
        else{
            usedCoin = true;
            capsule.transform.localScale = new UnityEngine.Vector3(1, 1, 1);
            capsule.transform.position = new UnityEngine.Vector3(163, .75f, -115);
            switch(currentDay){
                case 1:
                    //boba

                    print("This should print only once");
                    Destroy(pull1);

                    GameObject a = Instantiate(pull1, capsule.transform.position, capsule.transform.rotation);
                    a.transform.localScale = new UnityEngine.Vector3(.5f, .5f, .5f); //this will depend on the object and is tentative to change;

                    Destroy(capsule);
                    break;

                case 2:

                    print("This should print only once");
                    Destroy(pull2);

                    GameObject b = Instantiate(pull2, capsule.transform.position, capsule.transform.rotation);
                    b.transform.localScale = new UnityEngine.Vector3(.5f, .5f, .5f); //this will depend on the object and is tentative to change;

                    Destroy(capsule);
                    break;

                case 3:
                    //syringe

                    print("This should print only once");
                    Destroy(pull3);

                    GameObject c = Instantiate(pull3, capsule.transform.position, capsule.transform.rotation);
                    c.transform.localScale = new UnityEngine.Vector3(10, 10, 10); //this will depend on the object and is tentative to change;

                    Destroy(capsule);
                    break;

                case 4:

                    print("This should print only once");
                    Destroy(pull4);

                    GameObject d = Instantiate(pull4, capsule.transform.position, capsule.transform.rotation);
                    d.transform.localScale = new UnityEngine.Vector3(.5f, .5f, .5f); //this will depend on the object and is tentative to change;

                    Destroy(capsule);
                    break;

                case 5:
                    print("This should print only once");
                    Destroy(pull5);

                    GameObject e = Instantiate(pull5, capsule.transform.position, capsule.transform.rotation);
                    e.transform.localScale = new UnityEngine.Vector3(.5f, .5f, .5f); //this will depend on the object and is tentative to change;

                    Destroy(capsule);
                    break;

                case 6:
                    print("This should print only once");
                    Destroy(pull6);

                    GameObject f = Instantiate(pull6, capsule.transform.position, capsule.transform.rotation);
                    f.transform.localScale = new UnityEngine.Vector3(.5f, .5f, .5f); //this will depend on the object and is tentative to change;

                    Destroy(capsule);
                    break;
                    
            }

        }
    }

    // Update is called once per frame
      void Update()
     {
        if(Input.GetKeyDown(KeyCode.Space)){
            checkDay(currentDay, hasCoin);
        }
     }
}
