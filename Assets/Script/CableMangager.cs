using UnityEngine;
using System.Collections.Generic;
public class CableManager : MonoBehaviour
{
    private Cable connectedCable = null; 
    public ConnectorType connectorType;

    public Cable getConnectedCable()
    {
        return connectedCable;
    }
    public bool CanConnect()
    {
        return connectedCable == null ;
    }

    public void ConnectCable(Cable cable)
    {
        connectedCable = cable;
    }
    

    public void DisconnectCable()
    {
        connectedCable = null;
    }
}
