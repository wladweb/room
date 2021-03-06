﻿using UnityEngine;
using UnityEngine.EventSystems;

public class Block : MonoBehaviour, IDragHandler, IDropHandler
{
    public int correctBoxIndex;
    public int indexOfBox { get; private set; }

    Vector3 initialPosition;

    void Start() 
    {
        indexOfBox = -1;
        initialPosition = transform.position;
        gameObject.SetActive(false);
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (GameObject.Find("Scale").GetComponent<Scale>().isSolved) return;
        Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(newPosition.x, newPosition.y, transform.position.z);
    }

    public void OnDrop(PointerEventData eventData)
    {
        Scale scale = GameObject.Find("Scale").GetComponent<Scale>();
        bool dropInsideOfBox = false;
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        for (int i = 0, l = scale.scaleBoxes.Length; i < l; i++) 
        {
            float currentScaleBoxPositionX = scale.scaleBoxes[i].transform.position.x;
            float currentScaleBoxPositionY = scale.scaleBoxes[i].transform.position.y;
            float currentScaleBoxWidth = scale.scaleBoxes[i].GetComponent<BoxCollider2D>().size.x / 2;
            float currentScaleBoxHeight = scale.scaleBoxes[i].GetComponent<BoxCollider2D>().size.y / 2;

            if (
                mousePosition.x <= currentScaleBoxPositionX + currentScaleBoxWidth &&
                mousePosition.x >= currentScaleBoxPositionX - currentScaleBoxWidth &&
                mousePosition.y <= currentScaleBoxPositionY + currentScaleBoxHeight &&
                mousePosition.y >= currentScaleBoxPositionY - currentScaleBoxHeight
                )
            {
                transform.position = new Vector3(currentScaleBoxPositionX, currentScaleBoxPositionY, transform.position.z);
                indexOfBox = i;
                dropInsideOfBox = true;
            }
        }

        if (!dropInsideOfBox)
        {
            transform.position = initialPosition;
            indexOfBox = -1;
        }
    }
}
