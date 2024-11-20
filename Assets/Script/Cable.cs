using UnityEngine;

public class Cable : MonoBehaviour
{
    private LineRenderer lineRenderer;
    private bool isDragging = false; 
    private CableMangager CableMangager = null; 
    private CableMangager targetConnector = null; 
    public Transform startPoint; 
    public Transform endPoint;   

    void Start()
    {
       
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 2;
        lineRenderer.SetPosition(0, startPoint.position); 
        lineRenderer.SetPosition(1, endPoint.position); 
    }

    void Update()
    {
       
        if (startPoint != null)
        {
            lineRenderer.SetPosition(0, startPoint.position);
        }

    
        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); 
            if (Physics.Raycast(ray, out RaycastHit hitInfo))
            {
              
                if (hitInfo.collider.gameObject == endPoint.gameObject)
                {
                    isDragging = true; 
                    print("hit end cable");
                }

               if (isDragging)
                {
                    lineRenderer.SetPosition(1, hitInfo.point);

                    CableMangager connector = hitInfo.collider.GetComponent<CableMangager>();
                    if (connector != null && connector.CanConnect(this))
                    {
                        print("hit start cable");
                        targetConnector = connector;
                    }
                    else
                    {
                        targetConnector = null; 
                    }
                }
                
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            if (isDragging && targetConnector != null)
            {
                print("epmty");
              
                if (CableMangager != null)
                {
                    CableMangager.DisconnectCable();
                }


                lineRenderer.SetPosition(1, targetConnector.transform.position);
                targetConnector.ConnectCable(this);
                CableMangager = targetConnector; 
            }

            isDragging = false;
        }
        if (endPoint != null && !isDragging && targetConnector == null)
        {
            if (CableMangager != null)
            {
                CableMangager.DisconnectCable();
            }
            lineRenderer.SetPosition(1, endPoint.position);
        }
    }
}
