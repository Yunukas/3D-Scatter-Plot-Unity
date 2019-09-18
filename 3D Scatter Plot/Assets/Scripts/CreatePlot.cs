using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using UnityEngine;

public class CreatePlot : MonoBehaviour
{
    // List for holding data from CSV reader
    private List<Dictionary<string, object>> pointList;
    private DataPoint[] dataPoints;
    public string inputCSV;

    // The prefab for the data points to be instantiated
    public GameObject PointPrefab;

    // Indices for columns to be assigned
    public int columnX = 0;
    public int columnY = 1;
    public int columnZ = 2;
    public int columnSize = 3;
    public int columnColor = 4;

    // Full column names
    public string xName;
    public string yName;
    public string zName;
    public string sizeName;
    public string colorName;
    // Start is called before the first frame update
    void Start()
    {
        // Set pointlist to results of function Reader with argument inputfile
        pointList = CSVReader.Read(inputCSV);
        // initialize the data points array with the correct size
        dataPoints = new DataPoint[pointList.Count - 1];
        //Debug.Log(pointList);
        // Declare list of strings, fill with keys (column names)
        List<string> columnList = new List<string>(pointList[1].Keys);

        // Assign column name from columnList to Name variables
        xName = columnList[columnX];
        yName = columnList[columnY];
        zName = columnList[columnZ];
        sizeName = columnList[columnSize];
        colorName = columnList[columnColor];

        for (var i = 0; i < pointList.Count; i++)
        {
            // Get value in poinList at ith "row", in "column" Name
            float x = System.Convert.ToSingle(pointList[i][xName]);
            float y = System.Convert.ToSingle(pointList[i][yName]);
            float z = System.Convert.ToSingle(pointList[i][zName]);
            float size = System.Convert.ToSingle(pointList[i][sizeName]);
            int color = System.Convert.ToInt32(pointList[i][colorName]);

            // add the point to the array
            dataPoints[i] = new DataPoint(x, y, z, size, color);

            // scale down the sizes of data point spheres by 15
            PointPrefab.transform.localScale = new Vector3(size / 15, size / 15, size / 15);
            
            //instantiate the prefab with coordinates defined above
            GameObject obj =  Instantiate(PointPrefab, new Vector3(x, y, z), Quaternion.identity);
            obj.GetComponent<MeshRenderer>().material.SetColor("_Color", getColor(color));

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

    // Update is called once per frame
    void Update()
    {

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
