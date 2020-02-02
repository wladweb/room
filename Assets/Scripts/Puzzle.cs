using UnityEngine;
using UnityEngine.EventSystems;

public class Puzzle : MonoBehaviour
{
    public bool IsCompleted { get; private set; }

    private DisplayImage currentDisplay;

    private void Start()
    {
        currentDisplay = GameObject.Find("displayImage").GetComponent<DisplayImage>();
    }

    private void Update()
    {
        HideDisplay();
    }

    void HideDisplay() 
    {
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            gameObject.SetActive(false);
        }

        if (currentDisplay.CurrentState == DisplayImage.State.Normal) 
        {
            gameObject.SetActive(false);
        }
    }
}
