using UnityEngine;
using UnityEngine.EventSystems;

public class Puzzle : MonoBehaviour
{
    public bool IsCompleted { get; private set; } = false;

    private DisplayImage currentDisplay;

    private void Start()
    {
        currentDisplay = GameObject.Find("displayImage").GetComponent<DisplayImage>();
    }

    private void Update()
    {
        if (CompletePuzzle())
        {
            Debug.Log("Complete");
        }
        HideDisplay();
    }

    void HideDisplay() 
    {
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            gameObject.SetActive(false);
        }

        if (currentDisplay.CurrentState == DisplayImage.State.Normal) 
        {
            gameObject.SetActive(false);
        }
    }

    bool CompletePuzzle() 
    {
        if (IsCompleted) return true;

        IsCompleted = true;

        PuzzlePiece[] puzzlePieces = FindObjectsOfType<PuzzlePiece>();

        foreach (PuzzlePiece piece in puzzlePieces)
        {
            if (!(piece.pieceNumber == piece.SpriteNumber())) 
            {
                IsCompleted = false;
                break;
            }
        }

        return IsCompleted;
    }
}
