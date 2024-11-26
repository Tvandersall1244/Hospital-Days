using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public string[] inventory = new string[16];
    public Image crossheir;
    public GameObject mainInventoryUIObject;
    private bool open;
    public GameObject ImageList;
    public GameObject emptyItem;
    public GameObject itemBG;
    public TextMeshProUGUI GachaponText;
    public PlayerMovement playerMovement;
    // Start is called before the first frame update
    void Start()
    {
        open = false;
        playerMovement = FindObjectOfType<PlayerMovement>();
        mainInventoryUIObject.SetActive(false);
        for(int i = 0; i < 16; i++) {
            inventory[i] = "";
        }
        foreach (string x in inventory)
        {
        }

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.I)){
            OpenOrCloseMenu();
        }


        /*
        bool isHovering = false;
        if (MouseOverElement.mouseOverItemDropLocation) {
            Debug.Log("Mouse over UI");
        } else {
            Debug.Log("Mouse not over UI");
        }
        */

    }

    void OpenOrCloseMenu() {
        if (open == true) {
            crossheir.enabled = true;
            mainInventoryUIObject.SetActive(false);
            playerMovement.GetComponent<PlayerMovement>().finDialogue();
            playerMovement.GetComponent<PlayerMovement>().moveSpeed = 70;
            Time.timeScale = 1f;
            //re-enable movement, if possible.
            open = false;
        } else {
            crossheir.enabled = false;
            mainInventoryUIObject.SetActive(true);
            playerMovement.GetComponent<PlayerMovement>().moveSpeed = 0;
            playerMovement.GetComponent<PlayerMovement>().inDialogue();
            Time.timeScale = 0f;
            //Update images in inventory
            for(int i = 0; i < inventory.Length; i++) {
                int j = matchStringWithImage(inventory[i]);
                if (j != -1) {
                    Image temp = ImageList.transform.GetChild(j).GetComponent<Image>();
                    itemBG.transform.GetChild(i).GetComponent<Image>().sprite = temp.sprite;
                } else {
                    Image temp = emptyItem.GetComponent<Image>();
                    itemBG.transform.GetChild(i).GetComponent<Image>().sprite = temp.sprite;
                }
            }
            GachaponText.text = "1"; //instead of "1", change to current number of gachapon tokens.
            open = true;
        }
    }

    bool addItem(string newItem) {
        int i = firstAvailableSlot();
        if (i == -1 || !itemIsNotDupe(newItem)) {
            return false; //no item gets added to the inventory
        }
        inventory[i] = newItem;
        return true;
    }

    int firstAvailableSlot() {
        for(int i = 0; i < inventory.Length; i++) {
            if(inventory[i].Equals(null)) {
                return i;
            }
        }
        return -1;
    }

    bool itemIsNotDupe(String otherItem) {
        foreach (String x in inventory)
        {
            if (otherItem.Equals(x)) {
                return false;
            }
        }
        return true;
    }

    public bool remove(string removeItem) {
        for(int i = 0; i < inventory.Length; i++) {
            if(inventory[i].Equals(removeItem)) {
                inventory[i] = "";
                return true;
            }
        }
        return false;
    }

    //This is the tedious work. And I'm trying to make it so that all you'd need to do to add more items
    //is add the image to the empty and add the if statement here.
    //The default is for any objects that are not null, but do not have an existing image.
    int matchStringWithImage(String x) {
        x = x.ToLower();
        if (x.Equals("desk plant")) {
            return 1;
        } //here add as many else ifs as there are possible items.
        else if (x.Equals(null) || x.Equals("")) {
            return -1;
        }
        else {
            return 0; //the default
        }
    }

    public bool contains(string a) {
        foreach(string x in inventory) {
            if (a.Equals(x)) {
                return true;
            }
        }
        return false;
    }
}
