using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointClicker : MonoBehaviour
{
    private GameObject currentObject;

    void OnMouseDown()
    {
        // if panel is already active for another point, add a 
        // slight delay before displaying the panel for this
        // point, because clicking away from the previous point
        // will close the panel, after that we can show
        // the updated panel
        if (PanelControl.active)
            StartCoroutine(ExecuteAfterTime(0.3f));
        else
            ProcessClick();
        
    }
    
    private void ProcessClick()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        // if there's a hit
        if (Physics.Raycast(ray, out hit, 100))
        {
            // get the current game object
            currentObject = hit.transform.gameObject;
            // animate it
            PointAnimator.Animate(currentObject);
            // get the center position in current view
            Vector3 screenCenterPos = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height / 2, 1f));
            // update and show the panel
            PanelControl.UpdatePanel(screenCenterPos, currentObject);
      
        }
    }
    // Coroutine to add some delay before updating the panel
    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        // Code to execute after the delay
        ProcessClick();
    }
}
