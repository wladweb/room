using UnityEngine;

public class ButtonHandler : MonoBehaviour
{
    private DisplayImage currentDisplay;

    private void Start()
    {
        currentDisplay = GameObject.Find("displayImage").GetComponent<DisplayImage>();
    }

    public void OnRightClickArrow()
    {
        currentDisplay.CurrentWall += 1;
    }

    public void OnLeftClickArrow()
    {
        currentDisplay.CurrentWall -= 1;
    }
}
