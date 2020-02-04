using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    private void Start()
    {
        InitializeInventory();
    }

    void InitializeInventory() 
    {
        GameObject slots = GameObject.Find("Slots");

        foreach (Transform slot in slots.transform) 
        {
            Transform item = slot.GetChild(0);
            item.GetComponent<Image>().sprite = Resources.Load<Sprite>("InventoryItems/empty_item");
        }
    }
}
