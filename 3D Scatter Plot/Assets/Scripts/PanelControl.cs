using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelControl : MonoBehaviour
{
    // reference to the panel object
    private static GameObject panel;
    // current gameObject's datapoint row information
    private static int CurrentRow;
    // last panel position, will be necessary when panel buttons are clicked
    private static Vector3 lastPosition;
    // this will represent the status of the panel
    public static bool active;

    void Start()
    {
        // get the panel object and hide it
        panel = transform.gameObject;
        panel.SetActive(false);
        active = false;
    }
    // this method will hide the panel
    public static void RemovePanel()
    { 
        panel.SetActive(false);
    }
    // update the information on the panel
    public static void UpdatePanel(Vector3 position, GameObject go)
    {
        // update the row info
        CurrentRow = go.GetComponent<DataPoint>().Row - 1;
        // get the datapoint for this gameobject
        DataPoint dp = go.GetComponent<DataPoint>();
        // save the position for later
        lastPosition = position;

        // prepare the info that will be displayed on the panel 
        string pointInfo = "X: " + dp.X +
                                "\nY: " + dp.Y +
                                "\nZ: " + dp.Z +
                                "\nColor: " + dp.Color;
        string rowInfo = "Row: " + dp.Row.ToString();

		// rotate the panel properly
		panel.GetComponent<RectTransform>().rotation = Camera.main.transform.rotation;
        // set the position of panel
        panel.GetComponent<RectTransform>().localPosition = position;
        // apply the information on the panel
        panel.transform.Find("rowInfo").gameObject.GetComponent<UnityEngine.UI.Text>().text = rowInfo;
        panel.transform.Find("pointInfo").gameObject.GetComponent<UnityEngine.UI.Text>().text = pointInfo;

        // activate the panel
        panel.SetActive(true);
        active = true;
    }
    // when left/right buttons on the panel are clicked
    // panel will be updated and the active point will be animated
    public void ButtonClick(string direction)
    {
        // if left arrow button is clicked
        if(direction == "Left")
        {
            // if we are at the first row, go to the end of the array
            if (CurrentRow == 0)
                CurrentRow = ScatterPlot.GameObjects.Length - 1;
            else
                --CurrentRow;
        }
        // otherwise it is the right button
        else
        {
            // if we are at the last row, go to the beginning of the array
            if (CurrentRow == ScatterPlot.GameObjects.Length - 1)
                CurrentRow = 0;
            else
                ++CurrentRow;
        }

        // get the next game object in the array
        GameObject go = ScatterPlot.GameObjects[CurrentRow];
        // and update the panel at the last position
        UpdatePanel(lastPosition, go);
        // animate the point
		PointAnimator.Animate(go);
    }

}
