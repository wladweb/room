using UnityEngine;
using UnityEngine.UI;

public class Chess : MonoBehaviour
{
    public GameObject screenPanel;
    public string correctPassword;
    private string inputPassword;
    private bool isCorrectPasswor;

    private void Start()
    {
        gameObject.SetActive(false);
        screenPanel.SetActive(false);
    }

    private void Update()
    {
        VerifyPassword();
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
            }
        }
    }
}
