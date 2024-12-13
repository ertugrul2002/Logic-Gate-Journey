using DoorScript;
using UnityEngine;
using System.Collections.Generic;

public class LogicGate_WorkSpace : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    [SerializeField] private Door door; 
    // public static LogicGate_WorkSpace Instance {get; set;}
    public List<bool>  TruthTableHandler=new List<bool> {};
    public Cable outA; 
    public Cable outB; 
    private bool isSolves =false;
  
    [SerializeField] private CableManager inputOut; 
    public CableManager getCableManager()
    {
        return inputOut;
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
