using UnityEngine;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IPointerClickHandler
{
    private Inventory inventory;
    public enum Property { Usable, Displayable }
    public Property ItemProperty { get; private set; }

    void Start() 
    {
        inventory = GameObject.Find("Inventory").GetComponent<Inventory>();  
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        inventory.PreviousSelectedSlot = inventory.CurrentSelectedSlot;
        inventory.CurrentSelectedSlot = gameObject;
    }

    public void AssignProperty(int orderNumber)
    {
        ItemProperty = (Property) orderNumber;
    }   
}
