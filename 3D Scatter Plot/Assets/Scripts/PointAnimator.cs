using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointAnimator : MonoBehaviour
{
    public static void Animate(GameObject go)
    {
        go.GetComponent<Animator>().Play("pointAnim", 0);
    }
}
