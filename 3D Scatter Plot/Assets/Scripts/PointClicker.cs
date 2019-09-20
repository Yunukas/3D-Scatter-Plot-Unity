using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointClicker : MonoBehaviour
{
    void OnMouseDown()
    {
        // load a new scene
        DataPoint dp = GetComponent<DataPoint>();
        print(dp.toString());
    }
}
