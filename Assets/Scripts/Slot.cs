using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IPointerClickHandler
{
    private Inventory inventory;
    public enum Property { Usable, Displayable, Empty }
    public Property ItemProperty { get; set; }

    private string displayImage;

    public string CombinationItem { get; private set; }

    void Start() 
    {
        inventory = GameObject.Find("Inventory").GetComponent<Inventory>();  
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        inventory.PreviousSelectedSlot = inventory.CurrentSelectedSlot;
        inventory.CurrentSelectedSlot = gameObject;
        Combine();
    }

    public void AssignProperty(int orderNumber, string displayImage)
    {
        ItemProperty = (Property) orderNumber;
        this.displayImage = displayImage;
    }

    public void DisplayItem() 
    {
        inventory.ItemDisplayer.SetActive(true);
        inventory.ItemDisplayer.GetComponent<Image>().sprite = Resources.Load<Sprite>("InventoryItems/" + displayImage);
    }

    void Combine() 
    {
        if (inventory.PreviousSelectedSlot.GetComponent<Slot>().CombinationItem == CombinationItem)
        {
            Debug.Log("combine");
        }
    }
}
