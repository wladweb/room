using UnityEngine;
using UnityEngine.UI;

public class DynamicObject : MonoBehaviour, IInteractable
{
    public string UnlockItem;
    public GameObject ChangeStateSprite;
    private GameObject inventory;

    public void Interact(DisplayImage currentDisplay)
    {
        if (inventory.GetComponent<Inventory>().CurrentSelectedSlot.gameObject.transform.GetChild(0).GetComponent<Image>().sprite.name == UnlockItem || UnlockItem == "")
        {
            ChangeStateSprite.SetActive(true);
            inventory.GetComponent<Inventory>().CurrentSelectedSlot.GetComponent<Slot>().ClearSlot();
        }
    }

    private void Start()
    {
        ChangeStateSprite.SetActive(false);
        inventory = GameObject.Find("Inventory");
    }
}
