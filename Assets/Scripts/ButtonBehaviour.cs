using UnityEngine;
using UnityEngine.UI;

public class ButtonBehaviour : MonoBehaviour
{
    public enum ButtonType { RoomChangeButton, ReturnButton }
    public ButtonType ThisButtonType;
    private DisplayImage currentDisplay;
    private Image image;
    private Button button;

    private void Start()
    {
        currentDisplay = GameObject.Find("displayImage").GetComponent<DisplayImage>();
        image = GetComponent<Image>();
        button = GetComponent<Button>();
    }

    private void Update()
    {
        DoBehaviour();
    }

    private void DoBehaviour() 
    {
        if (currentDisplay.CurrentState == DisplayImage.State.Normal)
        {
            if (ThisButtonType == ButtonType.ReturnButton)
            {
                Hide();
                this.transform.SetSiblingIndex(0);
            }
            else if (ThisButtonType == ButtonType.RoomChangeButton)
            {
                Display();
            }
        }
        else if (currentDisplay.CurrentState == DisplayImage.State.Zoomed) 
        {
            if (ThisButtonType == ButtonType.ReturnButton)
            {
                Display();
            }
            else if (ThisButtonType == ButtonType.RoomChangeButton)
            {
                Hide();
            }
        }
    }

    void Hide() 
    {
        image.color = new Color(image.color.r, image.color.r, image.color.r, 0);
        button.enabled = false;
    }

    void Display() 
    {
        image.color = new Color(image.color.r, image.color.r, image.color.r, 1);
        button.enabled = true;
    }
}
