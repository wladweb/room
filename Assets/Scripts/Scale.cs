using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scale : MonoBehaviour
{
    public GameObject[] scaleBoxes;
    private Block[] blocks;
    private DisplayImage currentDisplay;
    private int[] weight = new int[5] { 1, 2, 4, 8, 3 };

    private void Start()
    {
        currentDisplay = GameObject.Find("displayImage").GetComponent<DisplayImage>();
        blocks = FindObjectsOfType<Block>();
    }

    private void Update()
    {
        Display();

        if (VerifySolution()) 
        {
            Debug.Log("scale solved");
        }
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

    bool VerifySolution() 
    {
        bool solved = true;

        for (int i = 0, l = scaleBoxes.Length; i < l; i++)
        {
            if (blocks[i].indexOfBox != blocks[i].correctBoxIndex) 
            {
                solved = false;
            }
        }

        return solved;
    }
}

