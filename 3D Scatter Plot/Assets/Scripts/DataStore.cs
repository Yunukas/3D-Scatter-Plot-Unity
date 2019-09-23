using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataStore : MonoBehaviour
{
    // the data structure to hold data read from CSV
    private static List<Dictionary<string, object>> pointList;
    // method to retrieve the data
    public static List<Dictionary<string, object>> GetPointList()
    {
        return pointList;
    }
    public static void setPointList(List<Dictionary<string, object>> pl)
    {
        pointList = pl;
    }
    
}
