using UnityEngine;

public class CalculateWaveHeight : MonoBehaviour
{
    // Calculate wave height
    public static float calculate(float x, float z)
    {
        float time = Time.time;
        float waveAmplifier = 0.3f;
        float speedAmplifier = 0.01f;
        float waveHeight = Mathf.Sin((x + (time * speedAmplifier)) * waveAmplifier) * Mathf.Cos((z + (time * speedAmplifier)) * waveAmplifier);
        return waveHeight;
    }
}