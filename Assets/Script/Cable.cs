using UnityEngine;
using UnityEngine.UI;

using System.Collections.Generic;
public class Cable : MonoBehaviour
{
    public  ConnectorType Name;
    public List<bool> truthTable = new List<bool>();
    private LineRenderer lineRenderer;
    private bool isDragging = false; 
    private CableManager CableManager1 = null; 
    private List<CableManager> connectedConnectors = new List<CableManager>();
    private CableManager targetConnector = null; 
    public Transform startPoint; 
    public Transform endPoint;   
    private bool isSelected =false;
    private Button button_cableManager =null;

    public void SetTargetConnector(CableManager value)
    {
        targetConnector = value;
    }

    public void SetButton_cableManager(Button value)
    {
        button_cableManager = value;
    }
    

    public CableManager getCableManager()
    {
        return CableManager1;
    }
    public void SetDragging(bool value)
    {
        isDragging = value;
    }
    public void SetIsSelected(bool value)
    {
        isSelected = value;
    }

    public List<bool> GetTruthTable()
    {
        return truthTable;
    }
    public void SetTruthTable(List<bool> newTruthTable)
    {
        
        if (truthTable.Count != newTruthTable.Count)
        {
            truthTable = new List<bool>(newTruthTable); 
        }
        else
        {
            for (int i = 0; i < newTruthTable.Count; i++)
            {
                truthTable[i] = newTruthTable[i];
            }
        }
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
        // if (Input.GetMouseButton(0))
        // {
        //     Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); 
        //     if (Physics.Raycast(ray, out RaycastHit hitInfo))
        //     {
        //         if (hitInfo.collider.gameObject == endPoint.gameObject)
        //         {
        //             isDragging = true; 
        //         }

        //         // if (isDragging)
        //         // {
        //         //     lineRenderer.SetPosition(1, hitInfo.point);
        //         //     CableManager connector = hitInfo.collider.GetComponent<CableManager>();
                    
        //         //     if (connector != null && connector.CanConnect())
        //         //     {
                        
        //         //         targetConnector = connector;
        //         //     }
        //         //     else
        //         //     {
        //         //         targetConnector = null; 
        //         //     }
        //         // }
                
        //     }
        // }
        if (isDragging && Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hitInfo))
            {
                lineRenderer.SetPosition(1, hitInfo.point);

                CableManager connector = hitInfo.collider.GetComponent<CableManager>();
                ButtonController_CableManager connectorCableManager=hitInfo.collider.GetComponent<ButtonController_CableManager>();
                if (connector != null && connector.CanConnect())
                {
                    targetConnector = connector;
                }
                else if(connectorCableManager != null )
                {
                    connectorCableManager.SetIsSelected(true);
                    connectorCableManager.SetSelectedCable(this);
                    connectorCableManager.ShowBitSelectionUI();
                }
                else
                {
                    targetConnector = null;
                }
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            if (isDragging && targetConnector != null)
            {
                if (CableManager1 != null)
                {
                    CableManager1.DisconnectCable();
                    CableManager1=null;
                }
                lineRenderer.SetPosition(1, targetConnector.transform.position);
                targetConnector.ConnectCable(this);
                CableManager1 = targetConnector; 
                Debug.Log("save cable");
            }
            isDragging = false;
        }
        if (endPoint != null && !isDragging && targetConnector == null)
        {
            if (CableManager1 != null)
            {
                if (button_cableManager != null)
                {
                    button_cableManager.interactable = true;
                }
                CableManager1.DisconnectCable();
                CableManager1=null;
            }
            lineRenderer.SetPosition(1, endPoint.position);
        }
    }
}
