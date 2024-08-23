using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Float : MonoBehaviour
{
    // Start is called before the first frame update
    public float multiplier = 3f;
    public float offset = 1f;
    private Rigidbody rigidbody;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // todo: maybe make it use world space instead of local space?
    // this way we can have children of the object impact float
    void Update()
    {
        float x = transform.position.x;
        float z = transform.position.z;
        float time = Time.time;

        float waveHeight = CalculateWaveHeight(x, z, time);
        float waveDiff = waveHeight - transform.position.y + offset;

        Debug.Log(gameObject.name + " waveDiff: " + waveDiff);

        if (waveDiff > 0)
        {
            rigidbody.AddForce(Vector3.up * waveDiff * multiplier);
        }
    }

    // Calculate the Y coordinate based on the given X and Z coordinates using 3D wave function math
    // Time is the offset, which makes the wave move
    public float CalculateWaveHeight(float x, float z, float time)
    {
        float waveAmplifier = 0.5f;
        float speedAmplifier = 0.3f;
        float waveHeight = Mathf.Sin((x + (time * speedAmplifier)) * waveAmplifier) * Mathf.Cos((z + (time * speedAmplifier)) * waveAmplifier);
        return waveHeight;
    }
}
