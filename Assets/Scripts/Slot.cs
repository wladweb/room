using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IPointerClickHandler
{
    private Inventory inventory;
    public enum Property { Usable, Displayable, Empty }
    public Property ItemProperty { get; set; }

    private string displayImage;

    void Start() 
    {
        inventory = GameObject.Find("Inventory").GetComponent<Inventory>();  
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        inventory.PreviousSelectedSlot = inventory.CurrentSelectedSlot;
        inventory.CurrentSelectedSlot = gameObject;
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
}
