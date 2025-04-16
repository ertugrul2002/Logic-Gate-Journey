using System.Collections.Generic;
using UnityEngine;


// [System.Serializable]
// public class Cable16bitTruthTable
// {
//     public List<bool> truthTable; 
// }

public class AND16_Gate : MonoBehaviour
{
    public int ID_Gate { get; private set; } 

    public void SetID(int id)
    {
        ID_Gate = id;
    }
    [SerializeField] private CableManager16bit inputA; 
    [SerializeField] private CableManager16bit inputB; 
    public ButtonController16bit Out;
    private bool isConnected =false;
    
    public ButtonController16bit getCable()
    {
        return Out;
    }
    public CableManager16bit getInputA()
    {
        return inputA;
    }
    public CableManager16bit getInputB()
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
    private List<Cable16bitTruthTable> Evaluate(List<Cable16bitTruthTable> truthTableA,List<Cable16bitTruthTable> truthTableB)
    {
        List<Cable16bitTruthTable> newTruthTable = new List<Cable16bitTruthTable>(truthTableA);
        for (int i = 0; i < truthTableA.Count; i++)
        {
            for (int j=0;j< truthTableA[i].truthTable.Count ;j++)
            {
                newTruthTable[i].truthTable[j] = (truthTableA[i].truthTable[j] && truthTableB[i].truthTable[j]);
            }
        }
        return newTruthTable;
    }
    private void UpdateTruthTable()
    {
        Out.SetTruthTable(Evaluate(inputA.getConnectedCable().GetTruthTable(),inputB.getConnectedCable().GetTruthTable()));
        List<Cable16bitTruthTable> new11TruthTable=Out.GetTruthTable();
        Debug.Log("Input A ANDGate: ");
        for(int i=0;i<new11TruthTable.Count;i++)
        {
            Debug.Log("  "+i +" "+ string.Join(", ", new11TruthTable[i].truthTable));
        }
        
        
    }
}
