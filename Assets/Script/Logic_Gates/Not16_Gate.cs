using UnityEngine;
using System.Collections.Generic;
public class Not16_Gate : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public int ID_Gate { get; private set; } 

    public void SetID(int id)
    {
        ID_Gate = id;
    }
    [SerializeField] private CableManager16bit input; 
    public ButtonController16bit Out;
    public ButtonController16bit getCable()
    {
        return Out;
    }
    public CableManager16bit getInput()
    {
        return input;
    }
    private bool isConnected = false;
    public bool Evaluate(bool value)
    {
        return !value;
    }
    void Update()
    {
        if (input != null  )
        {
            if(input.getConnectedCable() != null && isConnected)
            {
                UpdateTruthTable();
                isConnected =false;
            }
            if(input.getConnectedCable() == null )
            {
                isConnected =true;
            }
            
            
        }
    }
    private List<Cable16bitTruthTable> Evaluate(List<Cable16bitTruthTable> truthTable)
    {
        List<Cable16bitTruthTable> newTruthTable = new List<Cable16bitTruthTable>(truthTable);
        for (int i = 0; i < truthTable.Count; i++)
        {
            for (int j=0;j< truthTable[i].truthTable.Count ;j++)
            {
                newTruthTable[i].truthTable[j] = !(truthTable[i].truthTable[j]);
            }
        }
        return newTruthTable;
    }
    private void UpdateTruthTable()
    {
        // if (isConnected)
        // {
            Out.SetTruthTable(Evaluate(input.getConnectedCable().GetTruthTable()));
            Debug.Log("Input A notGate: " + string.Join(", ", Out.GetTruthTable()));
            
        // }
        
    }
}
