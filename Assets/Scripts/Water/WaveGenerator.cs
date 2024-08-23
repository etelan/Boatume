using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveGenerator : MonoBehaviour
{
    private Mesh mesh;
    private Vector3[] vertices;
    private MeshCollider meshCollider;

    // Start is called before the first frame update
    void Start()
    {
        mesh = GetComponent<MeshFilter>().mesh;
        vertices = mesh.vertices;
        meshCollider = GetComponent<MeshCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        // Calculate the new height for each vertex
        // 1 This transforms the point into a world space point, 
        // 2 calculates the new height, 
        // 3 and then transforms it back to local space
        for (int i = 0; i < vertices.Length; i++)
        {
            Vector3 vertex = transform.TransformPoint(vertices[i]);
            vertex.y = CalculateWaveHeight(vertex.x, vertex.z, Time.time);
            vertices[i] = transform.InverseTransformPoint(vertex);
        }

        // Update the mesh with the new vertices and recalculate normals
        mesh.vertices = vertices;
        mesh.RecalculateNormals();
        meshCollider.sharedMesh = mesh;
    }

    // Calculate the Y coordinate based on the given X and Z coordinates using 3D wave function math
    // Time is the offset, which makes the wave move
    float CalculateWaveHeight(float x, float z, float time)
    {
        float waveAmplifier = 0.5f;
        float speedAmplifier = 0.3f;
        float waveHeight = Mathf.Sin((x + (time*speedAmplifier)) * waveAmplifier) * Mathf.Cos((z + (time*speedAmplifier)) * waveAmplifier);
        return waveHeight;
    }
}