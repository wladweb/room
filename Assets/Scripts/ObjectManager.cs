using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    DisplayImage currentDisplay;
    public GameObject[] objectsToManage;
    public GameObject[] UIRendererObjects;

    // Start is called before the first frame update
    void Start()
    {
        currentDisplay = GameObject.Find("displayImage").GetComponent<DisplayImage>();
        RenderUI();
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

    void RenderUI()
    {
        for (int i = 0, l = UIRendererObjects.Length; i < l; i++)
        {
            UIRendererObjects[i].SetActive(false);
        }
    }
}
