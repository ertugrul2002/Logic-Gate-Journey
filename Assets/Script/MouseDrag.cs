using UnityEngine;

public class MouseDrag : MonoBehaviour
{
    private Vector3 offset;
    private float zCoord;

    void OnMouseDown()
    {
        
        zCoord = Camera.main.WorldToScreenPoint(transform.position).z;
        Vector3 newPosition = GetMouseWorldPos() + offset;
        newPosition.z = transform.position.z;
        transform.position = newPosition;

        
        offset = transform.position - GetMouseWorldPos();
    }

    void OnMouseDrag()
    {
      
        transform.position = GetMouseWorldPos() + offset;
    }

    private Vector3 GetMouseWorldPos()
    {
       
        Vector3 mousePoint = Input.mousePosition;

        
        mousePoint.z = zCoord;

       
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }
}
