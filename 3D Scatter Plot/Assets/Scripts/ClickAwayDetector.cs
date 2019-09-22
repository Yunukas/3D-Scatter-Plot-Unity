using UnityEngine;
using UnityEngine.EventSystems;

public class ClickAwayDetector : MonoBehaviour, IPointerClickHandler
{
    // get the click event and remove the panel from view
    public void OnPointerClick(PointerEventData eventData)
    {
        PanelControl.RemovePanel();
        PanelControl.active = false;
    }
}
