using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeTerrain : MonoBehaviour
{

    void Start()
    {

        Perlin surface = new Perlin();

        Mesh mesh = GetComponent<MeshFilter>().mesh;
        Vector3[] vertices = mesh.vertices;

        for (int v = 0; v < vertices.Length; v++)
        {
            vertices[v].y = surface.Noise( vertices[v].x * 2 + 0.1365143f, vertices[v].z * 2 + 1.21688f) * 10;

        }

        mesh.vertices = vertices;
        mesh.RecalculateBounds(); // we call this to ensure bounding volume is correct (as recommended by APIs)
        mesh.RecalculateNormals(); // again, recommended by APIs

        gameObject.AddComponent<MeshCollider>();
    }
}
