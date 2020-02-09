using UnityEngine;
using UnityEngine.SceneManagement;

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

    public void OnClickReturn() 
    {
        if (currentDisplay.CurrentState == DisplayImage.State.Zoomed)
        {
            GameObject.Find("displayImage").GetComponent<DisplayImage>().CurrentState = DisplayImage.State.Normal;
            ZoomInObject[] zoomedObjects = FindObjectsOfType<ZoomInObject>();

            foreach (ZoomInObject obj in zoomedObjects)
            {
                obj.gameObject.layer = 0;
            }

            Camera.main.orthographicSize = initialCameraSize;
            Camera.main.transform.position = initialCameraPosition;
        }
        else if (currentDisplay.CurrentState == DisplayImage.State.ChangedView)
        {
            currentDisplay.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/wall" + currentDisplay.CurrentWall);
        }

        currentDisplay.CurrentState = DisplayImage.State.Normal;
    }

    public void OnClickPlay() 
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void OnClickExit() 
    {
        Application.Quit();
    }
}
