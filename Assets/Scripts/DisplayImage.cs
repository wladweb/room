using UnityEngine;

public class DisplayImage : MonoBehaviour
{
    private int _currentWall;
    private int _previousWall;

    public enum State 
    {
        Normal,
        Zoomed
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
        _previousWall = 0;
    }

    private void Update()
    {
        if (_currentWall != _previousWall)
        {
            GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/wall" + CurrentWall);
        }
    }
}
