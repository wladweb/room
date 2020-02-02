using UnityEngine;
using System.Collections.Generic;

public class DisplayImage : MonoBehaviour
{
    private int _currentWall;
    private int _previousWall;

    private Dictionary<int, GameObject> walls;

    public enum State 
    {
        Normal,
        Zoomed,
        ChangedView
    }

    public State CurrentState { get; set; }

    public int CurrentWall 
    {
        get 
        {
            return _currentWall;
        }
        set
        {
            if (value == 5)
            {
                _currentWall = 1;
            }
            else if (value == 0)
            {
                _currentWall = 4;
            }
            else
            {
                _currentWall = value;
            }

            
        }
    }

    private void Start()
    {
        _currentWall = 1;
        _previousWall = 4;
        CurrentState = State.Normal;

        Wall[] wallObjects = FindObjectsOfType<Wall>();

        walls = new Dictionary<int, GameObject>();

        foreach (Wall wall in wallObjects) 
        {
            wall.gameObject.SetActive(false);
            walls.Add(wall.wallNumber, wall.gameObject);
        }
    }

    private void Update()
    {
        if (_currentWall != _previousWall)
        {
            GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/wall" + CurrentWall);
            ManageWalls(_previousWall, _currentWall);
            _previousWall = _currentWall;
        }
    }

    private void ManageWalls(int previousWall, int currentWall) 
    {
        walls[previousWall].SetActive(false);
        walls[currentWall].SetActive(true);
    }
}
