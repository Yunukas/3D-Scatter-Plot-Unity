using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activePoint : MonoBehaviour
{
    private static GameObject point;

    public static void setActive(GameObject p)
    {
        //if (point)
        //{
        //    point.GetComponent<Animator>().Play("Idle");
        //    point.GetComponent<Animator>().enabled = false;
        //}
            

        point = p;
        //point.GetComponent<Animator>().enabled = true;
        point.GetComponent<Animator>().Play("pointAnim");

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
