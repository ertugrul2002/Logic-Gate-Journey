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
    [SerializeField] private CableManager input; 
    public Cable Out;
    public Cable getCable()
    {
        return Out;
    }
    public CableManager getInput()
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
    private List<bool> Evaluate(List<bool> truthTable)
    {
        List<bool> newTruthTable = new List<bool>(truthTable);
        for (int i = 0; i < truthTable.Count; i++)
        {
            newTruthTable[i] = !truthTable[i];
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
