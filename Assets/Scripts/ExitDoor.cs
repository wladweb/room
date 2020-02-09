using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ExitDoor : MonoBehaviour,IInteractable
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
            Instantiate(EscapeMessage, GameObject.Find("Canvas").transform);
            StartCoroutine(LoadMenu());
        }
    }

    private void Start()
    {
        ChangeStateSprite.SetActive(false);
        inventory = GameObject.Find("Inventory");
    }

    public IEnumerator LoadMenu() 
    {
        yield return new WaitForSeconds(4);
        SceneManager.LoadScene("menu");
    }
}
