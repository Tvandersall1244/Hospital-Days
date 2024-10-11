using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class CameraMovement : MonoBehaviour
{
    public float xSensitivity = 2f;
    public float ySensitivity = 2f;
    
    float rotationY = 90f;

    float rotationX = 0f;



    public Transform orientation;
    public Transform gachaMachine;




    // Start is called before the first frame update
    void Start()
    {
        HideAndLockCursor();
    }

    // Update is called once per frame
    void Update()
    {
        LookAround();
    }

    void HideAndLockCursor() {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

     void LookAround() {
        float mouseX = Input.GetAxis("Mouse X") * xSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * ySensitivity;

        if (DayManager.Instance.IsDay7()) {
            orientation.LookAt(gachaMachine);
            return;
        }
        // rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * xSensitivity;
        // rotationY += Input.GetAxis("Mouse Y") * ySensitivity;
        // rotationY = Mathf.Clamp(rotationY, -90f, 90f);

        // transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0f);
        // orientation.Rotate(Vector3.up * rotationX);

        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, -rotationY, rotationY);

        transform.localRotation = Quaternion.Euler(rotationX, 0f, 0f);
        orientation.Rotate(Vector3.up * mouseX);

    }

}
