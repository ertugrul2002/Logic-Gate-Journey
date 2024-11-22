using UnityEngine;

public class CableManager : MonoBehaviour
{
    private Cable connectedCable = null; 
    public string connectorID;
  
    public bool CanConnect(Cable cable)
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
