using UnityEngine;
using System;

public class Interact : MonoBehaviour
{
    private DisplayImage currentDisplay;

    void Start()
    {
        currentDisplay = GameObject.Find("displayImage").GetComponent<DisplayImage>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 rayStartPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(rayStartPosition, Vector2.zero, 100);

            if (hit && hit.transform.CompareTag("Interactable"))
            {
                hit.transform.GetComponent<IInteractable>().Interact(currentDisplay);
            }
        }
    }
}
