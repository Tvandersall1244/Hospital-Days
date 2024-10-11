using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public Vector2 moveVal;

    [SerializeField]
    public float moveSpeed;

    //public Transform target;

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
        if (DayManager.Instance.IsDay7()) {
            rb.velocity = transform.forward * moveSpeed * 0.5f;
            return;
        }
        Vector3 playerVelocity = new Vector3(moveVal.x * moveSpeed, rb.velocity.y, moveVal.y * moveSpeed);
        rb.velocity = transform.TransformDirection(playerVelocity);
    }

    void OnMove(InputValue value) {
        moveVal = value.Get<Vector2>();
    }

    public Vector3 getPlayerPosition() {
        return rb.position;
    }

    void OnTriggerEnter(Collider col) {
        if(col.gameObject.tag == "GachaMachine" && DayManager.Instance.IsDay7()) {
            Debug.Log("hit");
            SceneManager.LoadScene(1);
        }
        Debug.Log(col.gameObject.name);
    }
}
