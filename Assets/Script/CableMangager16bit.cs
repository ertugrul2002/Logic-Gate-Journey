using UnityEngine;
using System.Collections.Generic;
public class CableManager16bit : MonoBehaviour
{
    private Cable16bit connectedCable = null; 
    public ConnectorType connectorType;

    public Cable16bit getConnectedCable()
    {
        return connectedCable;
    }
    public bool CanConnect()
    {
        return connectedCable == null ;
    }

    public void ConnectCable(Cable16bit cable)
    {
        connectedCable = cable;
        // Debug.Log("Input"+cable.Name + ":" + string.Join(", ", cable.GetTruthTable()));
    }
    

    public void DisconnectCable()
    {
        connectedCable = null;
    }
}
