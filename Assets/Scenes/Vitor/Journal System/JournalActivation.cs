using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;



public class JournalScript : MonoBehaviour
{
    [SerializeField] 
    public GameObject journalObject;
    public GameObject journalUI;
    public GameObject gameCamera;
    public bool uiActivated = false;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("e")) {
            print(getClickedObject(out RaycastHit hit));
            if (journalObject == getClickedObject(out RaycastHit possibleJournalObject)) {
                //print("We're clicking the journal!");
                journalUI.SetActive(true);
                gameCamera.GetComponent<CameraMovement>().enabled = false;
                Time.timeScale = 0f;
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                //print("Journal UI on!");
            }
        } 
        
        if (journalUI.activeInHierarchy == true) {
            Cursor.visible = true;
        } else {
            Cursor.visible = false;
        }

    }

    GameObject getClickedObject (out RaycastHit hit) {
        GameObject target = null;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast (ray.origin, ray.direction * 10, out hit)) {
            if (isPointerOverUIObject()) {
                //print("getClickedObject is true!");
                target = hit.collider.gameObject;
                //print(target);
            }
        } 
        return target;
    } 

    private bool isPointerOverUIObject() {
        PointerEventData ped = new PointerEventData(EventSystem.current);
        ped.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(ped, results);
        if (results.Count > 0) {
            return true;
        } else {
            return false;
        }
    }
}
