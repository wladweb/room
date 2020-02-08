using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scale : MonoBehaviour
{
    public GameObject[] scaleBoxes;
    private Block[] blocks;
    private DisplayImage currentDisplay;

    private void Start()
    {
        currentDisplay = GameObject.Find("displayImage").GetComponent<DisplayImage>();
        blocks = FindObjectsOfType<Block>();
    }

    private void Update()
    {
        Display();
    }

    void Display() 
    {
        for (int i = 0, l = blocks.Length; i < l; i++)
        {
            if (currentDisplay.GetComponent<SpriteRenderer>().sprite.name == "scale")
            {
                blocks[i].gameObject.SetActive(true);
            }
            else 
            {
                blocks[i].gameObject.SetActive(false);
            }
        }
    }
}

