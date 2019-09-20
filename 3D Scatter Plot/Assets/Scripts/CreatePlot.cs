using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using System.Threading;
using UnityEngine;

public class CreatePlot : MonoBehaviour
{
    // List for holding data from CSV reader
    private List<Dictionary<string, object>> pointList;
    public DataPoint dataPoint;
    public string inputCSV;

    // The prefab for the data points to be instantiated
    public GameObject PointPrefab;
    // this will be the parent to all point objects
    public GameObject PointParent;

    // Indices for columns to be assigned
    public int columnX = 0;
    public int columnY = 1;
    public int columnZ = 2;
    public int columnSize = 3;
    public int columnColor = 4;

    // Full column names
    private string xName;
    private string yName;
    private string zName;
    private string sizeName;
    private string colorName;

    // scale for the plot
    private float plotScale = 50;

    // min and max values for coordinates
    private float xMin;
    private float yMin;
    private float zMin;

    private float xMax;
    private float yMax;
    private float zMax;

    // Start is called before the first frame update
    void Start()
    {
        // Set pointlist to results of function Reader with argument inputfile
        pointList = CSVReader.Read(inputCSV);
        // initialize the data points array with the correct size
        //dataPoints = new DataPoint[pointList.Count - 1];
        //Debug.Log(pointList);
        // Declare list of strings, fill with keys (column names)
        List<string> columnList = new List<string>(pointList[1].Keys);

        // Assign column name from columnList to Name variables
        xName = columnList[columnX];
        yName = columnList[columnY];
        zName = columnList[columnZ];
        sizeName = columnList[columnSize];
        colorName = columnList[columnColor];

        // calculate min and max values
        xMin = FindMinValue(xName);
        yMin = FindMinValue(yName);
        zMin = FindMinValue(zName);

        xMax = FindMaxValue(xName);
        yMax = FindMaxValue(yName);
        zMax = FindMaxValue(zName);

        // find the max and min sizes to scale the sphere
        float maxSize = FindMaxValue(sizeName);
        float minSize = FindMinValue(sizeName);
        float sizeScale = maxSize / minSize;

        PointPrefab = Resources.Load("PointSphere") as GameObject;

        for (var i = 0; i < pointList.Count - 1; i++)
        {
            // Get value in poinList at ith "row", in "column" Name
            float x = Convert.ToSingle(pointList[i][xName]);
            float y = Convert.ToSingle(pointList[i][yName]);
            float z = Convert.ToSingle(pointList[i][zName]);
            float size = Convert.ToSingle(pointList[i][sizeName]);
            int color = Convert.ToInt32(pointList[i][colorName]);

            // normalize the point
            float scaledX = (x - xMin) / (xMax - xMin);
            float scaledY = (y - yMin) / (yMax - yMin);
            float scaledZ = (z - zMin) / (zMax - zMin);

            //Debug.Log("x : " + x + " y: " + y + " z: " + z + " scaledX : " + scaledX + " scaledY: " + scaledY + " scaledZ: " + scaledZ);

            // set the scaled position of the point
            Vector3 position = new Vector3(scaledX, scaledY, scaledZ) * plotScale;
            
            //instantiate the point prefab with coordinates defined above
            GameObject obj =  Instantiate(PointPrefab, position, Quaternion.identity) as GameObject;
            // attach the object to the parent 
            obj.transform.parent = PointParent.transform;

            // 
            dataPoint = obj.GetComponent<DataPoint>();
            dataPoint.X = x;
            dataPoint.Y = y;
            dataPoint.Z = z;
            dataPoint.Size = size;
            dataPoint.Color = color;
            //new DataPoint(x, y, z, size, color);

            // set the color
            obj.GetComponent<Renderer>().material.SetColor("_Color", getColor(color));
            // set the scale
            obj.transform.localScale = new Vector3(size, size, size) / maxSize;
            // name the object
            obj.transform.name = dataPoint.toString();
            
        }
    }

    private Color getColor(int colorValue)
    {
        switch (colorValue)
        {
            case 0:
                return Color.red;
            case 1:
                return Color.blue;
            case 2:
                return Color.green;
            default:
                return Color.red;
        }
    }

    //Method for finding max value, assumes PointList is generated
    private float FindMaxValue(string columnName)
    {
        //set initial value to first value
        float maxValue = Convert.ToSingle(pointList[0][columnName]);

        //Loop through Dictionary, overwrite existing maxValue if new value is larger
        for (var i = 0; i < pointList.Count; i++)
        {
            if (maxValue < Convert.ToSingle(pointList[i][columnName]))
                maxValue = Convert.ToSingle(pointList[i][columnName]);
        }

        //Spit out the max value
        return maxValue;
    }

    //Method for finding minimum value, assumes PointList is generated
    private float FindMinValue(string columnName)
    {
        //set initial value to first value
        float minValue = Convert.ToSingle(pointList[0][columnName]);

        //Loop through Dictionary, overwrite existing minValue if new value is smaller
        for (var i = 0; i < pointList.Count; i++)
        {
            if (Convert.ToSingle(pointList[i][columnName]) < minValue)
                minValue = Convert.ToSingle(pointList[i][columnName]);
        }

        return minValue;
    }

    //IEnumerator LoadConfig()
    //{
    //    bool done = false;
    //    new Thread(() => {
    //        pointList = CSVReader.Read(csv);
    //        done = true;
    //    }).Start();

    //    // Do nothing on each frame until the thread is done
    //    while (!done)
    //    {
    //        yield return null;
    //    }
    //    //yield return new WaitForThreadedTask(() => {
    //    //    pointList = CSVReader.Read(inputCSV);
    //    //});
    //    Debug.Log(pointList);
    //}
}
