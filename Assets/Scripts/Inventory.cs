using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public GameObject CurrentSelectedSlot { get; set; }
    public GameObject PreviousSelectedSlot { get; set; }
    private GameObject slots;
    public GameObject ItemDisplayer { get; private set; }

    private void Start()
    {
        
        InitializeInventory();
    }

    private void Update()
    {
        SelectSlot();
        HideDisplay();
    }

    void InitializeInventory() 
    {
        slots = GameObject.Find("Slots");
        ItemDisplayer = GameObject.Find("ItemDisplayer");
        ItemDisplayer.SetActive(false);

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
            if (slot.gameObject == CurrentSelectedSlot && slot.GetComponent<Slot>().ItemProperty == Slot.Property.Usable)
            {
                slot.GetComponent<Image>().color = new Color(.5f, .2f, .34f, 1);
            }
            else if (slot.gameObject == CurrentSelectedSlot && slot.GetComponent<Slot>().ItemProperty == Slot.Property.Displayable)
            {
                slot.GetComponent<Slot>().DisplayItem();
            }
            else
            {
                slot.GetComponent<Image>().color = new Color(1, 1, 1, 1);
            }
        }
    }

    void HideDisplay() 
    {
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject()) 
        {
            ItemDisplayer.SetActive(false);

            if (CurrentSelectedSlot.GetComponent<Slot>().ItemProperty == Slot.Property.Displayable)
            {
                CurrentSelectedSlot = PreviousSelectedSlot;
                PreviousSelectedSlot = CurrentSelectedSlot;
            }
        }
    }
}
