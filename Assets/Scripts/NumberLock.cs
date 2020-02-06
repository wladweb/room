using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberLock : MonoBehaviour
{
    public string password;

    [HideInInspector]
    public Sprite[] numberSprites;
    [HideInInspector]
    public int[] currentIndividualIndex = new int[4] { 0, 0, 0, 0 };

    public GameObject OpenLockerSprite;

    private bool isOpen;

    private void Start()
    {
        OpenLockerSprite.SetActive(false);
        isOpen = false;
        LoadAllNumberSprites();
    }

    private void Update()
    {
        OpenLocker();
    }

    void LoadAllNumberSprites() 
    {
        numberSprites = Resources.LoadAll<Sprite>("Sprites/numbers");
    }

    bool VerifyCorrectCode() 
    {
        bool correct = true;
        
        for (int i = 0; i < 4; i++)
        {
            string num = transform.GetChild(i).GetComponent<SpriteRenderer>().sprite.name.Substring(transform.GetChild(i).GetComponent<SpriteRenderer>().sprite.name.Length - 1);

            if (password[i].ToString() != num)
            {
                correct = false;
            }
        }

        return correct;
    }

    void OpenLocker() 
    {
        
        if (isOpen) return;

        if (VerifyCorrectCode()) 
        {
            isOpen = true;
            OpenLockerSprite.SetActive(true);
        }
    }
}
