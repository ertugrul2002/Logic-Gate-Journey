using UnityEngine;

public class CableMangager : MonoBehaviour
{
    private Cable connectedCable = null; 

  
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
