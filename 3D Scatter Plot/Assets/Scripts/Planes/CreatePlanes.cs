using System.Collections;
using UnityEngine;

public class CreatePlanes : MonoBehaviour
{
    // for a square plane, only one dimension will be sufficient
    public int size;

    // material for the plane
    public Material planeMat;

    void Start()
    {
        PlaneXY.CreatePlane(size, size, planeMat);
        PlaneYZ.CreatePlane(size, size, planeMat);
        PlaneXZ.CreatePlane(size, size, planeMat);
    }
}