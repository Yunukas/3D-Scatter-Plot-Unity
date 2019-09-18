using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlaneXY
{

    public static GameObject CreatePlane(float width, float height, Material mat)
    {
        GameObject obj = new GameObject("PlaneXY");
        MeshFilter mf = obj.AddComponent(typeof(MeshFilter)) as MeshFilter;
        MeshRenderer mr = obj.AddComponent(typeof(MeshRenderer)) as MeshRenderer;

        Mesh m = new Mesh();
        m.vertices = new Vector3[]
        {
            new Vector3(0,0,0),
            new Vector3(width,0,0),
            new Vector3(width,height,0),
            new Vector3(0,height,0)
        };

        m.triangles = new int[] { 0, 1, 2, 0, 2, 3 };

        mr.material = mat;
        mf.mesh = m;
        m.RecalculateNormals();

        return obj;
    }
}
