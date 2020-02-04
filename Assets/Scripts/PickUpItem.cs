using UnityEngine;
using UnityEngine.UI;

public class PickUpItem : MonoBehaviour, IInteractable
{
    public string displaySprite;
    private GameObject inventorySlots;

    public void Interact(DisplayImage currentDisplay)
    {
        ItemPickUp();
    }

    private void Start()
    {
        inventorySlots = GameObject.Find("Slots");
    }

    private void ItemPickUp() 
    {
        foreach (Transform slot in inventorySlots.transform) 
        {
            if (slot.GetChild(0).GetComponent<Image>().sprite.name == "empty_item") 
            {
                slot.GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>("InventoryItems/" + displaySprite);
                DestroyObject(gameObject);
                break;
            }
        }
    }
}
