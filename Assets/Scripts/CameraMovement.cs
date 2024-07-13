using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CameraMovement : MonoBehaviour
{
    public float xSensitivity = 2f;
    public float ySensitivity = 2f;
    float rotationY = -90f;

    float rotationX = 0f;


    public Transform orientation;

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
        // rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * xSensitivity;
        // rotationY += Input.GetAxis("Mouse Y") * ySensitivity;
        // rotationY = Mathf.Clamp(rotationY, -90f, 90f);

        // transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0f);
        // orientation.Rotate(Vector3.up * rotationX);

        float mouseX = Input.GetAxis("Mouse X") * xSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * ySensitivity;

        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, -90f, 90f);

        transform.localRotation = Quaternion.Euler(rotationX, 0f, 0f);
        orientation.Rotate(Vector3.up * mouseX);
    }
}
