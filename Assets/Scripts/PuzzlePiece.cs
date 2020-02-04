using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PuzzlePiece : MonoBehaviour, IPointerClickHandler
{
    private Puzzle puzzle;
    public int pieceNumber { get; private set; }
    private const string emptySpriteName = "empty_item8";

    void Start() 
    {
        puzzle = GameObject.Find("Puzzle").GetComponent<Puzzle>();
        string name = gameObject.name;
        pieceNumber = int.Parse(name.Substring(name.Length - 1));
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (puzzle.IsCompleted) return;
        

        PuzzlePiece[] puzzlePieces = FindObjectsOfType<PuzzlePiece>();

        foreach (PuzzlePiece piece in puzzlePieces)
        {
            if (IsItPossibleTurn(piece.pieceNumber))
            {
                if (piece.IsItEmptyPiece(piece.GetComponent<Image>().sprite.name)) 
                {
                    ChangeSparites(GetComponent<Image>(), piece.GetComponent<Image>());
                }
            }
        }   
    }

    private bool IsItEmptyPiece(string spriteName)
    {
        return spriteName == emptySpriteName;
    }

    private bool IsItPossibleTurn(int pieceNumber)
    {
        return this.pieceNumber == pieceNumber + 1
            || this.pieceNumber == pieceNumber - 1
            || this.pieceNumber == pieceNumber + 3
            || this.pieceNumber == pieceNumber - 3;
    }

    private void ChangeSparites(Image img1, Image img2)
    {
        Sprite temp = img1.sprite;
        img1.sprite = img2.sprite;
        img2.sprite = temp;
        Debug.Log("Change");
    }

    public int SpriteNumber() 
    {
        string name = GetComponent<Image>().sprite.name;
        return int.Parse(GetComponent<Image>().sprite.name.Substring(name.Length - 1));
    }
}
