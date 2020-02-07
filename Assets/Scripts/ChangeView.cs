using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeView : MonoBehaviour, IInteractable
{
    public string spriteName;

    private float initialCameraSize;
    private Vector3 initialCameraPosition;

    private void Start()
    {
        initialCameraSize = Camera.main.orthographicSize;
        initialCameraPosition = Camera.main.transform.position;
    }

    public void Interact(DisplayImage currentDisplay)
    {
        currentDisplay.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/" + spriteName);
        currentDisplay.CurrentState = DisplayImage.State.ChangedView;
        
        Camera.main.orthographicSize = initialCameraSize;
        Camera.main.transform.position = initialCameraPosition;
    }
}
