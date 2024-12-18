using DoorScript;
using UnityEngine;
using System.Collections.Generic;


[System.Serializable]
public class CableTruthTable
{
    public CableManager cable; // المخرج
    public List<bool> truthTable; // Truth Table الخاصة به
}

public class LogicGate_WorkSpace : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    [SerializeField] private Door door; 
    [SerializeField] private List<CableTruthTable> cableTruthTables = new List<CableTruthTable>(){};

    private bool isSolves =false;
    private bool isAllCorrect =false;

    void Update()
    {
        
        if(isSolves && isAllCorrect)
        {
            return;
        }
        int count=0;
        foreach (var entry in cableTruthTables)
        {
            if (entry.cable != null && entry.cable.getConnectedCable() != null )
            {
                var actualTruthTable = entry.cable.getConnectedCable().GetTruthTable();
                if (!CheckTruthTable(actualTruthTable, entry.truthTable))
                {
                    isSolves=false;
                    break;
                }
                count++;
            }
        }
        if(isSolves && count == cableTruthTables.Count)
        {
            isAllCorrect=true;
            door.OpenDoor();
        }

    }

    private bool CheckTruthTable(List<bool> truthTable,List<bool> actualTruthTable)
    {
        if(truthTable.Count == actualTruthTable.Count)
        {
            
            for(int i=0;i<actualTruthTable.Count;i++)
            {
                if(actualTruthTable[i] != truthTable[i])
                {
                   
                    isSolves=false;
                    return false;
                }  
            }
            isSolves=true;
            return true;  
        }
        isSolves=false;
        return false;
    }
}
