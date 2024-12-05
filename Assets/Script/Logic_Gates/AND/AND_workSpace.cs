using DoorScript;
using UnityEngine;
using System.Collections.Generic;
public class AND_workSpace : MonoBehaviour
{
    [SerializeField] private Door door; 
    public static AND_workSpace Instance {get; set;}
    public List<bool>  TruthTableHandler=new List<bool> {false, false, false, true  };
    public Cable outA; 
    public Cable outB; 
    private bool isSolves =false;
  
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

    
    void Start()
    {
        outA.SetTruthTable(new List<bool> {false, false, true, true  });
        outB.SetTruthTable(new List<bool> { false, true, false, true  });
        
    }
    void Update()
    {
        if(inputOut != null && inputOut.getConnectedCable() != null && !isSolves)
        {
            if(CheckTruthTable(inputOut.getConnectedCable().GetTruthTable()))
            {
                Debug.LogError("open the door the pizzle solved");
                door.OpenDoor();
                isSolves=true;
            }
        }
    }

    private bool CheckTruthTable(List<bool> truthTable)
    {
        if(truthTable.Count == TruthTableHandler.Count)
        {
            for(int i=0;i<TruthTableHandler.Count;i++)
            {
                if(TruthTableHandler[i] != truthTable[i])
                {
                    isSolves=false;
                    return false;
                }  
            }
            return true;  
        }
        isSolves=false;
        return false;
    }
}
