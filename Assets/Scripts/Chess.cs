using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Chess : MonoBehaviour, IPointerClickHandler
{
    public GameObject screenPanel;
    public GameObject obtainItem;
    private DisplayImage displayImage;
    public string correctPassword;
    private string inputPassword;
    private bool isCorrectPasswor;

    private void Start()
    {
        gameObject.SetActive(false);
        screenPanel.SetActive(false);
        obtainItem.SetActive(false);
        displayImage = GameObject.Find("displayImage").GetComponent<DisplayImage>();
    }

    private void Update()
    {
        VerifyPassword();
        HideDisplay();
    }

    void VerifyPassword() 
    {
        if (isCorrectPasswor) return;
        if (Input.GetKey(KeyCode.Return)) 
        {
            inputPassword = screenPanel.transform.Find("Text").GetComponent<Text>().text;
            screenPanel.transform.Find("Text").GetComponent<Text>().text = "";
            
            if (inputPassword == correctPassword) 
            {
                isCorrectPasswor = true;
                Destroy(GameObject.Find("ScreenActivator"));
                Destroy(screenPanel);
                GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/chess_solved");
                obtainItem.SetActive(true);
            }
        }
    }

    void HideDisplay() 
    {
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            gameObject.SetActive(false);
        }

        if (displayImage.CurrentState == DisplayImage.State.Normal) 
        {
            gameObject.SetActive(false);
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        //screenPanel.SetActive(false);
    }
}
