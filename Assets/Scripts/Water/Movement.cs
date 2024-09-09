using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private float forceAmount = 3f;
    private float rotationAmount = 2f; // Added rotation amount
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Check for A and D key presses
        if (Input.GetKey(KeyCode.A))
        {
            // Rotate left
            rb.AddTorque(Vector3.up * -rotationAmount);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            // Rotate right
            rb.AddTorque(Vector3.up * rotationAmount);
        }
        else
        {
            Vector3 force = transform.forward * verticalInput * forceAmount;
            rb.AddForce(force);
        }
    }
}
