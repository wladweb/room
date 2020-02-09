using UnityEngine;
using UnityEngine.UI;

public class ExitDoor : MonoBehaviour
{
    public string UnlockItem;
    public GameObject ChangeStateSprite;
    private GameObject inventory;
    public GameObject EscapeMessage;

    public void Interact(DisplayImage currentDisplay)
    {
        if (inventory.GetComponent<Inventory>().CurrentSelectedSlot.gameObject.transform.GetChild(0).GetComponent<Image>().sprite.name == UnlockItem || UnlockItem == "")
        {
            ChangeStateSprite.SetActive(true);
            gameObject.layer = 2;
        }
    }

    private void Start()
    {
        ChangeStateSprite.SetActive(false);
        inventory = GameObject.Find("Inventory");
    }
}
