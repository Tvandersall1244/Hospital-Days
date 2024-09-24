using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public Vector2 moveVal;

    [SerializeField]
    public float moveSpeed;

    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Walk();
    }

    void Walk() {
        Vector3 playerVelocity = new Vector3(moveVal.x * moveSpeed, rb.velocity.y, moveVal.y * moveSpeed);
        rb.velocity = transform.TransformDirection(playerVelocity);
    }

    void OnMove(InputValue value) {
        moveVal = value.Get<Vector2>();
    }

    public Vector3 getPlayerPosition() {
        return rb.position;
    }
}
