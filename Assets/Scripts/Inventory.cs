using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public GameObject CurrentSelectedSlot { get; set; }
    public GameObject PreviousSelectedSlot { get; set; }
    private GameObject slots;

    private void Start()
    {
        slots = GameObject.Find("Slots");
        InitializeInventory();
    }

    private void Update()
    {
        SelectSlot();
    }

    void InitializeInventory() 
    {
        foreach (Transform slot in slots.transform) 
        {
            Transform item = slot.GetChild(0);
            item.GetComponent<Image>().sprite = Resources.Load<Sprite>("InventoryItems/empty_item");
        }
    }

    void SelectSlot() 
    {
        
        foreach (Transform slot in slots.transform)
        {
            //Debug.Log(slot.gameObject);
            Debug.Log(CurrentSelectedSlot);
            if (slot.gameObject == CurrentSelectedSlot && slot.GetComponent<Slot>().ItemProperty == Slot.Property.Usable)
            {
                
                slot.GetComponent<Image>().color = new Color(.5f, .2f, .34f, 1);
            }
            else
            {
                slot.GetComponent<Image>().color = new Color(1, 1, 1, 1);
            }
        }
    }
}
