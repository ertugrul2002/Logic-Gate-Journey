using UnityEngine;
using System.Collections.Generic;


public class Dmux_Gate : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public int ID_Gate { get; private set; } 
   
    public void SetID(int id)
    {
        ID_Gate = id;
    }
    [SerializeField] private CableManager inputIn; 

    [SerializeField] private CableManager inputSel; 
    public Cable OutB;
    public Cable OutA;
    private bool isConnected =false;
    
    public Cable getCableA()
    {
        return OutA;
    }
    public Cable getCableB()
    {
        return OutB;
    }
    public CableManager getInputA()
    {
        return inputIn;
    }
    public CableManager getInputB()
    {
        return inputSel;
    }
    void Update()
    {
        if(inputIn != null && inputSel != null )
        {
            if(inputIn.getConnectedCable() == null)
            {
                isConnected=true;
            }
            if(inputSel.getConnectedCable() == null)
            {
                isConnected=true;
            }
        
            if (inputIn.getConnectedCable() != null  && inputSel.getConnectedCable() != null && isConnected)
            {
                print("Both inputs are now connected!");
                isConnected=false;
                UpdateTruthTable();
            }
        }
    }
    private List<bool> EvaluateB(List<bool> truthTableIn,List<bool> truthTableSel)
    {
        List<bool> newTruthTable = new List<bool>(truthTableIn);
        for (int i = 0; i < truthTableIn.Count; i++)
        {
            newTruthTable[i] = (truthTableIn[i] && truthTableSel[i]);
        }
        return newTruthTable;
    }
    private List<bool> EvaluateA(List<bool> truthTableIn,List<bool> truthTableSel)
    {
        List<bool> newTruthTable = new List<bool>(truthTableIn);
        for (int i = 0; i < truthTableIn.Count; i++)
        {
            newTruthTable[i] = (truthTableIn[i] && !truthTableSel[i]);
        }
        return newTruthTable;
    }
    private void UpdateTruthTable()
    {
        OutA.SetTruthTable(EvaluateA(inputIn.getConnectedCable().GetTruthTable(),inputSel.getConnectedCable().GetTruthTable()));
        Debug.Log("OUT A MuxGate: " + string.Join(", ", OutA.GetTruthTable()));
        OutB.SetTruthTable(EvaluateB(inputIn.getConnectedCable().GetTruthTable(),inputSel.getConnectedCable().GetTruthTable()));
        Debug.Log("OUT B MuxGate: " + string.Join(", ", OutA.GetTruthTable()));
        
        
    }
  
}
