using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Rigidbody rb;
    public float moveSpeed = 35f;
    public float sprintSpeedMultiplier = 1.6f;
    public float jumpForce = 35f;

    private Vector3 inputVector;
    private bool isGrounded = true;

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Entered");
        if (collision.gameObject.CompareTag("Terrain"))
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        Debug.Log("Exited");
        if (collision.gameObject.CompareTag("Terrain"))
        {
            isGrounded = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Can use Vector3.up or transform.up
        inputVector = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));

        if (Input.GetKey(KeyCode.LeftShift) && isGrounded)
            inputVector.z *= sprintSpeedMultiplier;

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(jumpForce * 10 * Vector3.up, ForceMode.Acceleration);
        }
    }

    void FixedUpdate()
    {
        Vector3 movement = moveSpeed * 10f * inputVector.z * Time.fixedDeltaTime * transform.forward +
                            moveSpeed * 10f * inputVector.x * Time.fixedDeltaTime * transform.right;

        rb.MovePosition(transform.position + movement * Time.fixedDeltaTime);
    }
}
