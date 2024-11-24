using UnityEngine;

public class Cable : MonoBehaviour
{
    public  ConnectorType Name;
    private LineRenderer lineRenderer;
    private bool isDragging = false; 
    private CableManager CableManager = null; 
    private CableManager targetConnector = null; 
    public Transform startPoint; 
    public Transform endPoint;   

    public CableManager getCableManager()
    {
        return CableManager;
    }
    public Transform getendPoint()
    {
        return endPoint;
    }
    void Start()
    {
       
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 2;
        lineRenderer.SetPosition(0, startPoint.position); 
        lineRenderer.SetPosition(1, endPoint.position); 
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); 
            if (Physics.Raycast(ray, out RaycastHit hitInfo))
            {
                if (hitInfo.collider.gameObject == endPoint.gameObject)
                {
                    isDragging = true; 
                }

                if (isDragging)
                {
                    lineRenderer.SetPosition(1, hitInfo.point);
                    CableManager connector = hitInfo.collider.GetComponent<CableManager>();
                    
                    if (connector != null && !connector.CanConnect())
                    {
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
                if (CableManager != null)
                {
                    CableManager.DisconnectCable();
                }
                lineRenderer.SetPosition(1, targetConnector.transform.position);
                targetConnector.ConnectCable(this);
                CableManager = targetConnector; 
            }
            isDragging = false;
        }
        if (endPoint != null && !isDragging && targetConnector == null)
        {
            if (CableManager != null)
            {
                CableManager.DisconnectCable();
            }
            lineRenderer.SetPosition(1, endPoint.position);
        }
    }
}
