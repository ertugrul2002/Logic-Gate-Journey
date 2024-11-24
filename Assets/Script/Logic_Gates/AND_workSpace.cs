using DoorScript;
using Unity.VisualScripting;
using UnityEngine;

public class AND_workSpace : MonoBehaviour
{
    [SerializeField] private Door door; 
    public static AND_workSpace Instance {get; set;}
    public Cable outA; 
    public Cable outB; 
    private bool x= false;
    [SerializeField] private CableManager inputOut; 
    public CableManager getCableManager()
    {
        return inputOut;
    }
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    void Update()
    {
        if(outA != null && outB != null && inputOut != null)
        {
            if(outA.getCableManager() != null && outB.getCableManager() != null &&  inputOut.getConnectedCable() !=null)
            {
                GameObject parentGate1 = outA.getCableManager().transform.parent.gameObject;
                Nand_Gate nandGate1 = parentGate1.GetComponent<Nand_Gate>();
                GameObject parentGate2 = outB.getCableManager().transform.parent.gameObject;
                Nand_Gate nandGate2 = parentGate2.GetComponent<Nand_Gate>();
                GameObject parentGate3 = inputOut.getConnectedCable().getendPoint().transform.parent.gameObject;
                Not_Gate notGate2 = parentGate3.GetComponent<Not_Gate>();
                if( nandGate1 != null && nandGate2 != null  && nandGate1.ID_Gate == nandGate2.ID_Gate )
                {
                    if(nandGate1.getCable().getCableManager() != null)
                    {
                        GameObject parentGate4 = nandGate1.getCable().getCableManager().transform.parent.gameObject;
                        Not_Gate notGate1 = parentGate4.GetComponent<Not_Gate>();
                        if(notGate2 != null && notGate1 != null && notGate1.ID_Gate == notGate2.ID_Gate && !x)
                        {
                            Debug.LogError("open the door the pizzle solved");
                            door.OpenDoor();
                        }
                    } 
                }
            }
        }
    }
}
