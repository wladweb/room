using UnityEngine;
using UnityEngine.EventSystems;

public class Block : MonoBehaviour, IDragHandler, IDropHandler
{
    public void OnDrag(PointerEventData eventData)
    {
        Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(newPosition.x, newPosition.y, transform.position.z);
    }

    public void OnDrop(PointerEventData eventData)
    {
        Scale scale = GameObject.Find("Scale").GetComponent<Scale>();

        for (int i = 0, l = scale.scaleBoxes.Length; i < l; i++) 
        { 
            //
        }
    }
}
