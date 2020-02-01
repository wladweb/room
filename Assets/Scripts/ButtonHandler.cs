using UnityEngine;

public class ButtonHandler : MonoBehaviour
{
    private DisplayImage currentDisplay;
    private float initialCameraSize;
    private Vector3 initialCameraPosition;

    private void Start()
    {
        currentDisplay = GameObject.Find("displayImage").GetComponent<DisplayImage>();
        initialCameraSize = Camera.main.orthographicSize;
        initialCameraPosition = Camera.main.transform.position;
    }

    public void OnRightClickArrow()
    {
        currentDisplay.CurrentWall += 1;
    }

    public void OnLeftClickArrow()
    {
        currentDisplay.CurrentWall -= 1;
    }

    public void OnClickZoomReturn() 
    {
        GameObject.Find("displayImage").GetComponent<DisplayImage>().CurrentState = DisplayImage.State.Normal;
        ZoomInObject[] zoomedObjects = FindObjectsOfType<ZoomInObject>();

        foreach (ZoomInObject obj in zoomedObjects) 
        {
            obj.gameObject.layer = 0;
        }

        Camera.main.orthographicSize = initialCameraSize;
        Camera.main.transform.position = initialCameraPosition;
        currentDisplay.CurrentState = DisplayImage.State.Normal;
    }
}
