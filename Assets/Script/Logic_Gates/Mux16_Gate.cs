using UnityEngine;
using System.Collections.Generic;


public class Mux16_Gate : MonoBehaviour
{
    public int ID_Gate { get; private set; } 

    public void SetID(int id)
    {
        ID_Gate = id;
    }
    [SerializeField] private CableManager16bit inputA; 
    [SerializeField] private CableManager16bit inputB; 
    [SerializeField] private CableManager inputSel; 
    public Cable16bit Out;
    private bool isConnected =false;
    
    public Cable16bit getCable()
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
        if(inputA != null && inputB != null && inputSel!= null)
        {
            if(inputA.getConnectedCable() == null)
            {
                isConnected=true;
            }
            if(inputB.getConnectedCable() == null)
            {
                isConnected=true;
            }
            if(inputSel.getConnectedCable() == null)
            {
                isConnected=true;
            }
        
            if (inputA.getConnectedCable() != null && inputB.getConnectedCable() && inputSel.getConnectedCable() != null && isConnected)
            {
                print("Both inputs are now connected!");
                isConnected=false;
                UpdateTruthTable();
            }
        }
    }
    private List<Cable16bitTruthTable> Evaluate(List<Cable16bitTruthTable> truthTableA,List<Cable16bitTruthTable> truthTableB,List<bool> truthTableSel)
    {
        List<Cable16bitTruthTable> newTruthTable = new List<Cable16bitTruthTable>(truthTableA);
        for (int i = 0; i < truthTableA.Count; i++)
        {
            for (int j=0;j< truthTableA[i].truthTable.Count ;j++)
            {
                if(! truthTableSel[i])
                {
                    newTruthTable[i].truthTable[j]=truthTableA[i].truthTable[j];
                }
                else
                {
                    newTruthTable[i].truthTable[j]=truthTableB[i].truthTable[j];
                }
                // newTruthTable[i].truthTable[j] = ((truthTableB[i].truthTable[j] && truthTableSel[i].truthTable[j]) || (truthTableA[i].truthTable[j] && !(truthTableSel[i].truthTable[j])));
            }
        }
        return newTruthTable;
    }
    private void UpdateTruthTable()
    {
        Out.SetTruthTable(Evaluate(inputA.getConnectedCable().GetTruthTable(),inputB.getConnectedCable().GetTruthTable(),inputSel.getConnectedCable().GetTruthTable()));
        List<Cable16bitTruthTable> newTruthTable=Out.GetTruthTable();
        Debug.Log("Input A MuxGate: ");
        for(int i=0;i<newTruthTable.Count;i++)
        {
            Debug.Log("  "+i +" "+ string.Join(", ", newTruthTable[i].truthTable));
        }
        
    }
}
