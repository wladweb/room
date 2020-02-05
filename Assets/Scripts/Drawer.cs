using UnityEngine;
using UnityEngine.UI;

public class Drawer : MonoBehaviour, IInteractable
{
    public GameObject unlockItem;
    private Inventory inventory;

    void Start() 
    {
        inventory = GameObject.Find("Inventory").GetComponent<Inventory>();
    }

    public void Interact(DisplayImage currentDisplay)
    { 
        Debug.Log("Click");
        if (inventory.CurrentSelectedSlot.transform.GetChild(0).GetComponent<Image>().sprite.name == unlockItem.name) 
        {
            inventory.CurrentSelectedSlot.GetComponent<Slot>().ItemProperty = Slot.Property.Empty;
            inventory.CurrentSelectedSlot.transform.GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>("InventoryItems/empty_item");
            Debug.Log("Unlock");
        }
    }
}
