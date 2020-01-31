using UnityEngine;

public class CameraBounds : MonoBehaviour
{
    float boundPositionX;
    float boundPositionY;

    float cameraPositionX;
    float cameraPositionY;

    float topBoundCoord;
    float rightBoundCoord;
    float bottomBoundCoord;
    float leftBoundCoord;

    float topCameraCoord;
    float rightCameraCoord;
    float bottomCameraCoord;
    float leftCameraCoord;

    BoxCollider2D boundCollider;

    private void SetUp() 
    {
        boundCollider = GetComponent<BoxCollider2D>();

        float height = Camera.main.orthographicSize;
        float width = Camera.main.aspect * height;

        cameraPositionX = Camera.main.transform.position.x;
        cameraPositionY = Camera.main.transform.position.y;

        topCameraCoord = cameraPositionY + height;
        bottomCameraCoord = cameraPositionY - height;
        rightCameraCoord = cameraPositionX + width;
        leftCameraCoord = cameraPositionX - width;

        boundPositionX = transform.position.x;
        boundPositionY = transform.position.y;

        topBoundCoord = boundPositionY + boundCollider.size.y / 2;
        bottomBoundCoord = boundPositionY - boundCollider.size.y / 2;
        rightBoundCoord = boundPositionX + boundCollider.size.x / 2;
        leftBoundCoord = boundPositionX - boundCollider.size.x / 2;
    }

    public void CheckConstraint() 
    {
        SetUp();

        if (CrossTopConstraint(out float diffTop)) 
        {
            MoveCamera(new Vector3(0, diffTop, 0));
        }

        if (CrossRightConstraint(out float diffRight))
        {
            MoveCamera(new Vector3(diffRight, 0, 0));
        }

        if (CrossBottomConstraint(out float diffBottom))
        {
            MoveCamera(new Vector3(0, diffBottom, 0));
        }

        if (CrossLeftConstraint(out float diffLeft))
        {
            MoveCamera(new Vector3(diffLeft, 0, 0));
        }
    }

    private bool CrossTopConstraint(out float diff)
    {
        diff = topBoundCoord - topCameraCoord;

        if (topCameraCoord > topBoundCoord)
        {
            return true;
        }
        else
        { 
            return false;
        }
    }
    private bool CrossRightConstraint(out float diff)
    {
        diff = rightBoundCoord - rightCameraCoord;

        if (rightCameraCoord > rightBoundCoord)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    private bool CrossBottomConstraint(out float diff) 
    {
        diff = bottomBoundCoord - bottomCameraCoord;

        if (bottomCameraCoord < bottomBoundCoord)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    private bool CrossLeftConstraint(out float diff) 
    {
        diff = leftBoundCoord - leftCameraCoord;

        if (leftCameraCoord < leftBoundCoord)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void MoveCamera(Vector3 vector) 
    {
        Camera.main.transform.position += vector;
    }
}
