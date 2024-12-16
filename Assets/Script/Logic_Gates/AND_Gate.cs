using System.Collections.Generic;
using UnityEngine;


public class AND_Gate : MonoBehaviour
{
    public int ID_Gate { get; private set; } 

    public void SetID(int id)
    {
        ID_Gate = id;
    }
    [SerializeField] private CableManager inputA; 
    [SerializeField] private CableManager inputB; 
    public Cable Out;
    private bool isConnected =false;
    
    public Cable getCable()
    {
        return Out;
    }
    public CableManager getInputA()
    {
        return inputA;
    }
    public CableManager getInputB()
    {
        return inputB;
    }
    void Update()
    {
        if(inputA != null && inputB != null)
        {
            if(inputA.getConnectedCable() == null)
            {
                isConnected=true;
            }
            if(inputB.getConnectedCable() == null)
            {
                isConnected=true;
            }
        
            if (inputA.getConnectedCable() != null && inputB.getConnectedCable() != null && isConnected)
            {
                print("Both inputs are now connected!");
                isConnected=false;
                UpdateTruthTable();
            }
        }
    }
    private List<bool> Evaluate(List<bool> truthTableA,List<bool> truthTableB)
    {
        List<bool> newTruthTable = new List<bool>(truthTableA);
        for (int i = 0; i < truthTableA.Count; i++)
        {
            newTruthTable[i] = (truthTableA[i] && truthTableB[i]);
        }
        return newTruthTable;
    }
    private void UpdateTruthTable()
    {
        Out.SetTruthTable(Evaluate(inputA.getConnectedCable().GetTruthTable(),inputB.getConnectedCable().GetTruthTable()));
        Debug.Log("Input A ANDGate: " + string.Join(", ", Out.GetTruthTable()));
        
        
    }
}
