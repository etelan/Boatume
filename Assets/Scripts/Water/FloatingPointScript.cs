using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicFloat : MonoBehaviour
{
    private Transform[] floatPoints; // To store the "FloatingPoint" child objects
    public float buoyancyStrength = 10f; // Force strength for buoyancy
    public float waterDensity = 1f;      // Controls how easily it floats
    public float floatingSpeed = 2.0f;   // For smoothing the floating movement

    private Rigidbody rb;

    void Start()
    {
        // Find all child objects with the name "FloatingPoint"
        var children = GetComponentsInChildren<Transform>();
        floatPoints = System.Array.FindAll(children, child => child.name == "FloatingPoint");

        // Get the Rigidbody component of the parent object
        rb = GetComponent<Rigidbody>();

        // Ensure Rigidbody is set to interpolate for smooth movement
        if (rb)
        {
            rb.interpolation = RigidbodyInterpolation.Interpolate;
        }
    }

    void FixedUpdate()
    {
        if (floatPoints.Length == 0 || rb == null) return;

        foreach (var point in floatPoints)
        {
            // Get the water height at the (X, Z) position of the FloatingPoint
            float waveHeight = CalculateWaveHeight.calculate(point.position.x, point.position.z);

            // Calculate how far the point is submerged (if it's underwater)
            float submersionDepth = waveHeight - point.position.y;

            if (submersionDepth > 0)
            {
                // Apply an upward force proportional to how deep the point is submerged
                float forceMagnitude = submersionDepth * buoyancyStrength * waterDensity;

                // Apply the force at the point's position
                rb.AddForceAtPosition(Vector3.up * forceMagnitude, point.position, ForceMode.Force);
            }
        }
    }
}
