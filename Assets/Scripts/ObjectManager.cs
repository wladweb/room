using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    DisplayImage currentDisplay;
    public GameObject[] objectsToManage;

    // Start is called before the first frame update
    void Start()
    {
        currentDisplay = GameObject.Find("displayImage").GetComponent<DisplayImage>();
    }

    // Update is called once per frame
    void Update()
    {
        ManageObjects();   
    }

    void ManageObjects() 
    {
        for (int i = 0, l = objectsToManage.Length; i < l; i++)
        {
            if (objectsToManage[i].name == currentDisplay.GetComponent<SpriteRenderer>().sprite.name)
            {
                objectsToManage[i].SetActive(true);
            }
            else 
            {
                objectsToManage[i].SetActive(false);
            }
        }
    }
}
