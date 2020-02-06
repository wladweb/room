using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberLock : MonoBehaviour
{
    private string password;
    public Sprite[] numberSprites;
    public int[] currentIndividualIndex = new int[4] { 0, 0, 0, 0 };

    private void Start()
    {
        LoadAllNumberSprites();
    }

    void LoadAllNumberSprites() 
    {
        numberSprites = Resources.LoadAll<Sprite>("Sprites/numbers");
    }
}
