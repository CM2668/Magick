using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderConfig : MonoBehaviour
{
    void Start()
    {
        Mesh mesh = GetComponent<MeshFilter>().mesh;
        mesh.bounds = new Bounds(Vector3.zero, Vector3.one * 2000);

    }

}
