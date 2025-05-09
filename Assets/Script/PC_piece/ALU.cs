using System.Collections.Generic;
using UnityEngine;

public class ALU : MonoBehaviour
{
    public int ID_Gate { get; private set; } 

    public void SetID(int id)
    {
        ID_Gate = id;
    }
    [SerializeField] private CableManager16bit inputA; 
    [SerializeField] private CableManager16bit inputB; 
    [SerializeField] private CableManager inputZX;
    [SerializeField] private CableManager inputZY;
    [SerializeField] private CableManager inputF;
    [SerializeField] private CableManager inputNo;
    [SerializeField] private CableManager inputNX;
    [SerializeField] private CableManager inputNY;
    public ButtonController Out;
    public ButtonController1bit OutZR;
    public ButtonController1bit OutNG;
    private bool isConnected =false;
    
    public ButtonController getCable()
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
            bool carry = false;
            for (int j=0;j< truthTableA[i].truthTable.Count ;j++)
            {
                newTruthTable[i].truthTable[j] = (truthTableA[i].truthTable[j] ^ truthTableB[i].truthTable[j] ^ carry);
                carry = (truthTableA[i].truthTable[j] && truthTableB[i].truthTable[j]) || (truthTableA[i].truthTable[j] &&  carry) || ( truthTableB[i].truthTable[j] && carry);
            }
        }
        return newTruthTable;
    }
    private void UpdateTruthTable()
    {
        Out.SetTruthTable(Evaluate(inputA.getConnectedCable().GetTruthTable(),inputB.getConnectedCable().GetTruthTable()));
        List<Cable16bitTruthTable> new11TruthTable=Out.GetTruthTable();
        Debug.Log("Input A AddGate: ");
        for(int i=0;i<new11TruthTable.Count;i++)
        {
            Debug.Log("  "+i +" "+ string.Join(", ", new11TruthTable[i].truthTable));
        }
        
        
    }
    public static List<Cable16bitTruthTable> TestIN_X()
    {
        List<Cable16bitTruthTable> result = new List<Cable16bitTruthTable>();
        // Row 1
        result.Add(new Cable16bitTruthTable(new List<bool> { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false }));
        // Row 2
        result.Add(new Cable16bitTruthTable(new List<bool> { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false }));
        // Row 3
        result.Add(new Cable16bitTruthTable(new List<bool> { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false }));
        // Row 4
        result.Add(new Cable16bitTruthTable(new List<bool> { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false }));
        // Row 5
        result.Add(new Cable16bitTruthTable(new List<bool> { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false }));
        // Row 6
        result.Add(new Cable16bitTruthTable(new List<bool> { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false }));
        // Row 7
        result.Add(new Cable16bitTruthTable(new List<bool> { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false }));
        // Row 8
        result.Add(new Cable16bitTruthTable(new List<bool> { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false }));
        // Row 9
        result.Add(new Cable16bitTruthTable(new List<bool> { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false }));
        // Row 10
        result.Add(new Cable16bitTruthTable(new List<bool> { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false }));
        // Row 11
        result.Add(new Cable16bitTruthTable(new List<bool> { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false }));
        // Row 12
        result.Add(new Cable16bitTruthTable(new List<bool> { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false }));
        // Row 13
        result.Add(new Cable16bitTruthTable(new List<bool> { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false }));
        // Row 14
        result.Add(new Cable16bitTruthTable(new List<bool> { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false }));
        // Row 15
        result.Add(new Cable16bitTruthTable(new List<bool> { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false }));
        // Row 16
        result.Add(new Cable16bitTruthTable(new List<bool> { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false }));
        // Row 17
        result.Add(new Cable16bitTruthTable(new List<bool> { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false }));
        // Row 18
        result.Add(new Cable16bitTruthTable(new List<bool> { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false }));
        // Row 19
        result.Add(new Cable16bitTruthTable(new List<bool> { false, false, false, false, false, false, false, false, false, false, false, true, false, false, false, true }));
        // Row 20
        result.Add(new Cable16bitTruthTable(new List<bool> { false, false, false, false, false, false, false, false, false, false, false, true, false, false, false, true }));
        // Row 21
        result.Add(new Cable16bitTruthTable(new List<bool> { false, false, false, false, false, false, false, false, false, false, false, true, false, false, false, true }));
        // Row 22       
        result.Add(new Cable16bitTruthTable(new List<bool> { false, false, false, false, false, false, false, false, false, false, false, true, false, false, false, true }));
        // Row 23
        result.Add(new Cable16bitTruthTable(new List<bool> { false, false, false, false, false, false, false, false, false, false, false, true, false, false, false, true }));
        // Row 24
        result.Add(new Cable16bitTruthTable(new List<bool> { false, false, false, false, false, false, false, false, false, false, false, true, false, false, false, true }));
        // Row 25
        result.Add(new Cable16bitTruthTable(new List<bool> { false, false, false, false, false, false, false, false, false, false, false, true, false, false, false, true }));
        // Row 26
        result.Add(new Cable16bitTruthTable(new List<bool> { false, false, false, false, false, false, false, false, false, false, false, true, false, false, false, true }));
        // Row 27
        result.Add(new Cable16bitTruthTable(new List<bool> { false, false, false, false, false, false, false, false, false, false, false, true, false, false, false, true }));
        // Row 28
        result.Add(new Cable16bitTruthTable(new List<bool> { false, false, false, false, false, false, false, false, false, false, false, true, false, false, false, true }));
        // Row 29
        result.Add(new Cable16bitTruthTable(new List<bool> { false, false, false, false, false, false, false, false, false, false, false, true, false, false, false, true }));
        // Row 30
        result.Add(new Cable16bitTruthTable(new List<bool> { false, false, false, false, false, false, false, false, false, false, false, true, false, false, false, true }));
        // Row 31
        result.Add(new Cable16bitTruthTable(new List<bool> { false, false, false, false, false, false, false, false, false, false, false, true, false, false, false, true }));
        // Row 32
        result.Add(new Cable16bitTruthTable(new List<bool> { false, false, false, false, false, false, false, false, false, false, false, true, false, false, false, true }));
        // Row 33
        result.Add(new Cable16bitTruthTable(new List<bool> { false, false, false, false, false, false, false, false, false, false, false, true, false, false, false, true }));
        // Row 34
        result.Add(new Cable16bitTruthTable(new List<bool> { false, false, false, false, false, false, false, false, false, false, false, true, false, false, false, true }));
        // Row 35
        result.Add(new Cable16bitTruthTable(new List<bool> { false, false, false, false, false, false, false, false, false, false, false, true, false, false, false, true }));
        // Row 36
        result.Add(new Cable16bitTruthTable(new List<bool> { false, false, false, false, false, false, false, false, false, false, false, true, false, false, false, true }));

        return result;
    }

    public static List<Cable16bitTruthTable> TestIN_Y()
    {
        List<Cable16bitTruthTable> result = new List<Cable16bitTruthTable>();
        // Row 1
        result.Add(new Cable16bitTruthTable(new List<bool> { true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true }));
        // Row 2
        result.Add(new Cable16bitTruthTable(new List<bool> { true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true }));
        // Row 3
        result.Add(new Cable16bitTruthTable(new List<bool> { true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true }));
        // Row 4
        result.Add(new Cable16bitTruthTable(new List<bool> { true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true }));
        // Row 5
        result.Add(new Cable16bitTruthTable(new List<bool> { true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true }));
        // Row 6
        result.Add(new Cable16bitTruthTable(new List<bool> { true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true }));
        // Row 7
        result.Add(new Cable16bitTruthTable(new List<bool> { true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true }));
        // Row 8
        result.Add(new Cable16bitTruthTable(new List<bool> { true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true }));
        // Row 9
        result.Add(new Cable16bitTruthTable(new List<bool> { true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true }));
        // Row 10
        result.Add(new Cable16bitTruthTable(new List<bool> { true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true }));
        // Row 11
        result.Add(new Cable16bitTruthTable(new List<bool> { true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true }));
        // Row 12
        result.Add(new Cable16bitTruthTable(new List<bool> { true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true }));
        // Row 13
        result.Add(new Cable16bitTruthTable(new List<bool> { true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true }));
        // Row 14
        result.Add(new Cable16bitTruthTable(new List<bool> { true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true }));
        // Row 15
        result.Add(new Cable16bitTruthTable(new List<bool> { true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true }));
        // Row 16
        result.Add(new Cable16bitTruthTable(new List<bool> { true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true }));
        // Row 17
        result.Add(new Cable16bitTruthTable(new List<bool> { true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true }));
        // Row 18
        result.Add(new Cable16bitTruthTable(new List<bool> { true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true }));
        // Row 19
        result.Add(new Cable16bitTruthTable(new List<bool> { false, false, false, false, false, false, false, false, false, false, false, false, false, false, true, true }));
        // Row 20
        result.Add(new Cable16bitTruthTable(new List<bool> { false, false, false, false, false, false, false, false, false, false, false, false, false, false, true, true }));
        // Row 21
        result.Add(new Cable16bitTruthTable(new List<bool> { false, false, false, false, false, false, false, false, false, false, false, false, false, false, true, true }));
        // Row 22       
        result.Add(new Cable16bitTruthTable(new List<bool> { false, false, false, false, false, false, false, false, false, false, false, false, false, false, true, true }));
        // Row 23
        result.Add(new Cable16bitTruthTable(new List<bool> { false, false, false, false, false, false, false, false, false, false, false, false, false, false, true, true }));
        // Row 24
        result.Add(new Cable16bitTruthTable(new List<bool> { false, false, false, false, false, false, false, false, false, false, false, false, false, false, true, true }));
        // Row 25
        result.Add(new Cable16bitTruthTable(new List<bool> { false, false, false, false, false, false, false, false, false, false, false, false, false, false, true, true }));
        // Row 26
        result.Add(new Cable16bitTruthTable(new List<bool> { false, false, false, false, false, false, false, false, false, false, false, false, false, false, true, true }));
        // Row 27
        result.Add(new Cable16bitTruthTable(new List<bool> { false, false, false, false, false, false, false, false, false, false, false, false, false, false, true, true }));
        // Row 28
        result.Add(new Cable16bitTruthTable(new List<bool> { false, false, false, false, false, false, false, false, false, false, false, false, false, false, true, true }));
        // Row 29
        result.Add(new Cable16bitTruthTable(new List<bool> { false, false, false, false, false, false, false, false, false, false, false, false, false, false, true, true }));
        // Row 30
        result.Add(new Cable16bitTruthTable(new List<bool> { false, false, false, false, false, false, false, false, false, false, false, false, false, false, true, true }));
        // Row 31
        result.Add(new Cable16bitTruthTable(new List<bool> { false, false, false, false, false, false, false, false, false, false, false, false, false, false, true, true }));
        // Row 32
        result.Add(new Cable16bitTruthTable(new List<bool> { false, false, false, false, false, false, false, false, false, false, false, false, false, false, true, true }));
        // Row 33
        result.Add(new Cable16bitTruthTable(new List<bool> { false, false, false, false, false, false, false, false, false, false, false, false, false, false, true, true }));
        // Row 34
        result.Add(new Cable16bitTruthTable(new List<bool> { false, false, false, false, false, false, false, false, false, false, false, false, false, false, true, true }));
        // Row 35
        result.Add(new Cable16bitTruthTable(new List<bool> { false, false, false, false, false, false, false, false, false, false, false, false, false, false, true, true }));
        // Row 36
        result.Add(new Cable16bitTruthTable(new List<bool> { false, false, false, false, false, false, false, false, false, false, false, false, false, false, true, true }));

        return result;
    }
    public static List<Cable16bitTruthTable> TestIN_ZX()
    {
        List<Cable16bitTruthTable> result = new List<Cable16bitTruthTable>();
        // Row 1
        result.Add(new Cable16bitTruthTable(new List<bool> { true }));
        // Row 2
        result.Add(new Cable16bitTruthTable(new List<bool> { true }));
        // Row 3
        result.Add(new Cable16bitTruthTable(new List<bool> { true }));
        // Row 4
        result.Add(new Cable16bitTruthTable(new List<bool> { false }));
        // Row 5
        result.Add(new Cable16bitTruthTable(new List<bool> { true }));
        // Row 6
        result.Add(new Cable16bitTruthTable(new List<bool> { false }));
        // Row 7
        result.Add(new Cable16bitTruthTable(new List<bool> { true }));
        // Row 8
        result.Add(new Cable16bitTruthTable(new List<bool> { false }));
        // Row 9
        result.Add(new Cable16bitTruthTable(new List<bool> { true }));
        // Row 10
        result.Add(new Cable16bitTruthTable(new List<bool> { false }));
        // Row 11
        result.Add(new Cable16bitTruthTable(new List<bool> { true }));
        // Row 12
        result.Add(new Cable16bitTruthTable(new List<bool> { false }));
        // Row 13
        result.Add(new Cable16bitTruthTable(new List<bool> { true }));
        // Row 14
        result.Add(new Cable16bitTruthTable(new List<bool> { false }));
        // Row 15
        result.Add(new Cable16bitTruthTable(new List<bool> { false }));
        // Row 16
        result.Add(new Cable16bitTruthTable(new List<bool> { false }));
        // Row 17
        result.Add(new Cable16bitTruthTable(new List<bool> { false }));
        // Row 18
        result.Add(new Cable16bitTruthTable(new List<bool> { false }));
        // Row 19
        result.Add(new Cable16bitTruthTable(new List<bool> { true }));
        // Row 20
        result.Add(new Cable16bitTruthTable(new List<bool> { true }));
        // Row 21
        result.Add(new Cable16bitTruthTable(new List<bool> { true }));
        // Row 22
        result.Add(new Cable16bitTruthTable(new List<bool> { false }));
        // Row 23
        result.Add(new Cable16bitTruthTable(new List<bool> { true }));
        // Row 24
        result.Add(new Cable16bitTruthTable(new List<bool> { false }));
        // Row 25
        result.Add(new Cable16bitTruthTable(new List<bool> { true }));
        // Row 26
        result.Add(new Cable16bitTruthTable(new List<bool> { false }));
        // Row 27
        result.Add(new Cable16bitTruthTable(new List<bool> { true }));
        // Row 28
        result.Add(new Cable16bitTruthTable(new List<bool> { false }));
        // Row 29
        result.Add(new Cable16bitTruthTable(new List<bool> { true }));
        // Row 30
        result.Add(new Cable16bitTruthTable(new List<bool> { false }));
        // Row 31
        result.Add(new Cable16bitTruthTable(new List<bool> { true }));
        // Row 32
        result.Add(new Cable16bitTruthTable(new List<bool> { false }));
        // Row 33
        result.Add(new Cable16bitTruthTable(new List<bool> { false }));
        // Row 34
        result.Add(new Cable16bitTruthTable(new List<bool> { false }));
        // Row 35
        result.Add(new Cable16bitTruthTable(new List<bool> { false }));
        // Row 36
        result.Add(new Cable16bitTruthTable(new List<bool> { false }));

        return result;
    }
    public static List<Cable16bitTruthTable> TestIN_NX()
    {
        List<Cable16bitTruthTable> result = new List<Cable16bitTruthTable>();
        // Row 1
        result.Add(new Cable16bitTruthTable(new List<bool> { false }));
        // Row 2
        result.Add(new Cable16bitTruthTable(new List<bool> { true }));
        // Row 3
        result.Add(new Cable16bitTruthTable(new List<bool> { true }));
        // Row 4
        result.Add(new Cable16bitTruthTable(new List<bool> { false }));
        // Row 5
        result.Add(new Cable16bitTruthTable(new List<bool> { true }));
        // Row 6
        result.Add(new Cable16bitTruthTable(new List<bool> { false }));
        // Row 7
        result.Add(new Cable16bitTruthTable(new List<bool> { true }));
        // Row 8
        result.Add(new Cable16bitTruthTable(new List<bool> { false }));
        // Row 9
        result.Add(new Cable16bitTruthTable(new List<bool> { true }));
        // Row 10
        result.Add(new Cable16bitTruthTable(new List<bool> { true }));
        // Row 11
        result.Add(new Cable16bitTruthTable(new List<bool> { true }));
        // Row 12
        result.Add(new Cable16bitTruthTable(new List<bool> { false }));
        // Row 13
        result.Add(new Cable16bitTruthTable(new List<bool> { true }));
        // Row 14
        result.Add(new Cable16bitTruthTable(new List<bool> { false }));
        // Row 15
        result.Add(new Cable16bitTruthTable(new List<bool> { true }));
        // Row 16
        result.Add(new Cable16bitTruthTable(new List<bool> { false }));
        // Row 17
        result.Add(new Cable16bitTruthTable(new List<bool> { false }));
        // Row 18
        result.Add(new Cable16bitTruthTable(new List<bool> { true }));
        // Row 19
        result.Add(new Cable16bitTruthTable(new List<bool> { false }));
        // Row 20
        result.Add(new Cable16bitTruthTable(new List<bool> { true }));
        // Row 21
        result.Add(new Cable16bitTruthTable(new List<bool> { true }));
        // Row 22
        result.Add(new Cable16bitTruthTable(new List<bool> { false }));
        // Row 23
        result.Add(new Cable16bitTruthTable(new List<bool> { true }));
        // Row 24
        result.Add(new Cable16bitTruthTable(new List<bool> { false }));
        // Row 25
        result.Add(new Cable16bitTruthTable(new List<bool> { true }));
        // Row 26
        result.Add(new Cable16bitTruthTable(new List<bool> { false }));
        // Row 27
        result.Add(new Cable16bitTruthTable(new List<bool> { true }));
        // Row 28
        result.Add(new Cable16bitTruthTable(new List<bool> { true }));
        // Row 29
        result.Add(new Cable16bitTruthTable(new List<bool> { true }));
        // Row 30
        result.Add(new Cable16bitTruthTable(new List<bool> { false }));
        // Row 31
        result.Add(new Cable16bitTruthTable(new List<bool> { true }));
        // Row 32
        result.Add(new Cable16bitTruthTable(new List<bool> { false }));
        // Row 33
        result.Add(new Cable16bitTruthTable(new List<bool> { true }));
        // Row 34
        result.Add(new Cable16bitTruthTable(new List<bool> { false }));
        // Row 35
        result.Add(new Cable16bitTruthTable(new List<bool> { false }));
        // Row 36
        result.Add(new Cable16bitTruthTable(new List<bool> { true }));

        return result;
    }
    public static List<Cable16bitTruthTable> TestIN_ZY()
    {
        List<Cable16bitTruthTable> result = new List<Cable16bitTruthTable>();
        // Row 1
        result.Add(new Cable16bitTruthTable(new List<bool> { true }));
        // Row 2
        result.Add(new Cable16bitTruthTable(new List<bool> { true }));
        // Row 3
        result.Add(new Cable16bitTruthTable(new List<bool> { true }));
        // Row 4
        result.Add(new Cable16bitTruthTable(new List<bool> { true }));
        // Row 5
        result.Add(new Cable16bitTruthTable(new List<bool> { false }));
        // Row 6
        result.Add(new Cable16bitTruthTable(new List<bool> { true }));
        // Row 7
        result.Add(new Cable16bitTruthTable(new List<bool> { false }));
        // Row 8
        result.Add(new Cable16bitTruthTable(new List<bool> { true }));
        // Row 9
        result.Add(new Cable16bitTruthTable(new List<bool> { false }));
        // Row 10
        result.Add(new Cable16bitTruthTable(new List<bool> { true }));
        // Row 11
        result.Add(new Cable16bitTruthTable(new List<bool> { false }));
        // Row 12
        result.Add(new Cable16bitTruthTable(new List<bool> { true }));
        // Row 13
        result.Add(new Cable16bitTruthTable(new List<bool> { false }));
        // Row 14
        result.Add(new Cable16bitTruthTable(new List<bool> { false }));
        // Row 15
        result.Add(new Cable16bitTruthTable(new List<bool> { false }));
        // Row 16
        result.Add(new Cable16bitTruthTable(new List<bool> { false }));
        // Row 17
        result.Add(new Cable16bitTruthTable(new List<bool> { false }));
        // Row 18
        result.Add(new Cable16bitTruthTable(new List<bool> { false }));
        // Row 19
        result.Add(new Cable16bitTruthTable(new List<bool> { true }));
        // Row 20
        result.Add(new Cable16bitTruthTable(new List<bool> { true }));
        // Row 21
        result.Add(new Cable16bitTruthTable(new List<bool> { true }));
        // Row 22
        result.Add(new Cable16bitTruthTable(new List<bool> { true }));
        // Row 23
        result.Add(new Cable16bitTruthTable(new List<bool> { false }));
        // Row 24
        result.Add(new Cable16bitTruthTable(new List<bool> { true }));
        // Row 25
        result.Add(new Cable16bitTruthTable(new List<bool> { false }));
        // Row 26
        result.Add(new Cable16bitTruthTable(new List<bool> { true }));
        // Row 27
        result.Add(new Cable16bitTruthTable(new List<bool> { false }));
        // Row 28
        result.Add(new Cable16bitTruthTable(new List<bool> { true }));
        // Row 29
        result.Add(new Cable16bitTruthTable(new List<bool> { false }));
        // Row 30
        result.Add(new Cable16bitTruthTable(new List<bool> { true }));
        // Row 31
        result.Add(new Cable16bitTruthTable(new List<bool> { false }));
        // Row 32
        result.Add(new Cable16bitTruthTable(new List<bool> { false }));
        // Row 33
        result.Add(new Cable16bitTruthTable(new List<bool> { false }));
        // Row 34
        result.Add(new Cable16bitTruthTable(new List<bool> { false }));
        // Row 35
        result.Add(new Cable16bitTruthTable(new List<bool> { false }));
        // Row 36
        result.Add(new Cable16bitTruthTable(new List<bool> { false }));

        return result;
    }
    public static List<Cable16bitTruthTable> TestIN_NY()
    {
        List<Cable16bitTruthTable> result = new List<Cable16bitTruthTable>();
        // Row 1
        result.Add(new Cable16bitTruthTable(new List<bool> { false }));
        // Row 2
        result.Add(new Cable16bitTruthTable(new List<bool> { true }));
        // Row 3
        result.Add(new Cable16bitTruthTable(new List<bool> { false }));
        // Row 4
        result.Add(new Cable16bitTruthTable(new List<bool> { true }));
        // Row 5
        result.Add(new Cable16bitTruthTable(new List<bool> { false }));
        // Row 6
        result.Add(new Cable16bitTruthTable(new List<bool> { true }));
        // Row 7
        result.Add(new Cable16bitTruthTable(new List<bool> { false }));
        // Row 8
        result.Add(new Cable16bitTruthTable(new List<bool> { true }));
        // Row 9
        result.Add(new Cable16bitTruthTable(new List<bool> { false }));
        // Row 10
        result.Add(new Cable16bitTruthTable(new List<bool> { true }));
        // Row 11
        result.Add(new Cable16bitTruthTable(new List<bool> { true }));
        // Row 12
        result.Add(new Cable16bitTruthTable(new List<bool> { true }));
        // Row 13
        result.Add(new Cable16bitTruthTable(new List<bool> { false }));
        // Row 14
        result.Add(new Cable16bitTruthTable(new List<bool> { false }));
        // Row 15
        result.Add(new Cable16bitTruthTable(new List<bool> { false }));
        // Row 16
        result.Add(new Cable16bitTruthTable(new List<bool> { true }));
        // Row 17
        result.Add(new Cable16bitTruthTable(new List<bool> { false }));
        // Row 18
        result.Add(new Cable16bitTruthTable(new List<bool> { true }));
        // Row 19
        result.Add(new Cable16bitTruthTable(new List<bool> { false }));
        // Row 20
        result.Add(new Cable16bitTruthTable(new List<bool> { true }));
        // Row 21
        result.Add(new Cable16bitTruthTable(new List<bool> { false }));
        // Row 22
        result.Add(new Cable16bitTruthTable(new List<bool> { true }));
        // Row 23
        result.Add(new Cable16bitTruthTable(new List<bool> { false }));
        // Row 24
        result.Add(new Cable16bitTruthTable(new List<bool> { true }));
        // Row 25
        result.Add(new Cable16bitTruthTable(new List<bool> { false }));
        // Row 26
        result.Add(new Cable16bitTruthTable(new List<bool> { true }));
        // Row 27
        result.Add(new Cable16bitTruthTable(new List<bool> { false }));
        // Row 28
        result.Add(new Cable16bitTruthTable(new List<bool> { true }));
        // Row 29
        result.Add(new Cable16bitTruthTable(new List<bool> { true }));
        // Row 30
        result.Add(new Cable16bitTruthTable(new List<bool> { true }));
        // Row 31
        result.Add(new Cable16bitTruthTable(new List<bool> { false }));
        // Row 32
        result.Add(new Cable16bitTruthTable(new List<bool> { false }));
        // Row 33
        result.Add(new Cable16bitTruthTable(new List<bool> { false }));
        // Row 34
        result.Add(new Cable16bitTruthTable(new List<bool> { true }));
        // Row 35
        result.Add(new Cable16bitTruthTable(new List<bool> { false }));
        // Row 36
        result.Add(new Cable16bitTruthTable(new List<bool> { true }));

        return result;
    }
    public static List<Cable16bitTruthTable> TestIN_F()
    {
        List<Cable16bitTruthTable> result = new List<Cable16bitTruthTable>();
        // Row 1
        result.Add(new Cable16bitTruthTable(new List<bool> { true }));
        // Row 2
        result.Add(new Cable16bitTruthTable(new List<bool> { true }));
        // Row 3
        result.Add(new Cable16bitTruthTable(new List<bool> { true }));
        // Row 4
        result.Add(new Cable16bitTruthTable(new List<bool> { false }));
        // Row 5
        result.Add(new Cable16bitTruthTable(new List<bool> { false }));
        // Row 6
        result.Add(new Cable16bitTruthTable(new List<bool> { false }));
        // Row 7
        result.Add(new Cable16bitTruthTable(new List<bool> { false }));
        // Row 8
        result.Add(new Cable16bitTruthTable(new List<bool> { true }));
        // Row 9
        result.Add(new Cable16bitTruthTable(new List<bool> { true }));
        // Row 10
        result.Add(new Cable16bitTruthTable(new List<bool> { true }));
        // Row 11
        result.Add(new Cable16bitTruthTable(new List<bool> { true }));
        // Row 12
        result.Add(new Cable16bitTruthTable(new List<bool> { true }));
        // Row 13
        result.Add(new Cable16bitTruthTable(new List<bool> { true }));
        // Row 14
        result.Add(new Cable16bitTruthTable(new List<bool> { true }));
        // Row 15
        result.Add(new Cable16bitTruthTable(new List<bool> { true }));
        // Row 16
        result.Add(new Cable16bitTruthTable(new List<bool> { true }));
        // Row 17
        result.Add(new Cable16bitTruthTable(new List<bool> { false }));
        // Row 18
        result.Add(new Cable16bitTruthTable(new List<bool> { false }));
        // Row 19
        result.Add(new Cable16bitTruthTable(new List<bool> { true }));
        // Row 20
        result.Add(new Cable16bitTruthTable(new List<bool> { true }));
        // Row 21
        result.Add(new Cable16bitTruthTable(new List<bool> { true }));
        // Row 22
        result.Add(new Cable16bitTruthTable(new List<bool> { false }));
        // Row 23
        result.Add(new Cable16bitTruthTable(new List<bool> { false }));
        // Row 24
        result.Add(new Cable16bitTruthTable(new List<bool> { false }));
        // Row 25
        result.Add(new Cable16bitTruthTable(new List<bool> { false }));
        // Row 26
        result.Add(new Cable16bitTruthTable(new List<bool> { true }));
        // Row 27
        result.Add(new Cable16bitTruthTable(new List<bool> { true }));
        // Row 28
        result.Add(new Cable16bitTruthTable(new List<bool> { true }));
        // Row 29
        result.Add(new Cable16bitTruthTable(new List<bool> { true }));
        // Row 30
        result.Add(new Cable16bitTruthTable(new List<bool> { true }));
        // Row 31
        result.Add(new Cable16bitTruthTable(new List<bool> { true }));
        // Row 32
        result.Add(new Cable16bitTruthTable(new List<bool> { true }));
        // Row 33
        result.Add(new Cable16bitTruthTable(new List<bool> { true }));
        // Row 34
        result.Add(new Cable16bitTruthTable(new List<bool> { true }));
        // Row 35
        result.Add(new Cable16bitTruthTable(new List<bool> { false }));
        // Row 36
        result.Add(new Cable16bitTruthTable(new List<bool> { false }));

        return result;
    }
    public static List<Cable16bitTruthTable> TestIN_NO()
    {
        List<Cable16bitTruthTable> result = new List<Cable16bitTruthTable>();
        // Row 1
        result.Add(new Cable16bitTruthTable(new List<bool> { false }));
        // Row 2
        result.Add(new Cable16bitTruthTable(new List<bool> { true }));
        // Row 3
        result.Add(new Cable16bitTruthTable(new List<bool> { false }));
        // Row 4
        result.Add(new Cable16bitTruthTable(new List<bool> { false }));
        // Row 5
        result.Add(new Cable16bitTruthTable(new List<bool> { false }));
        // Row 6
        result.Add(new Cable16bitTruthTable(new List<bool> { true }));
        // Row 7
        result.Add(new Cable16bitTruthTable(new List<bool> { true }));
        // Row 8
        result.Add(new Cable16bitTruthTable(new List<bool> { true }));
        // Row 9
        result.Add(new Cable16bitTruthTable(new List<bool> { true }));
        // Row 10
        result.Add(new Cable16bitTruthTable(new List<bool> { true }));
        // Row 11
        result.Add(new Cable16bitTruthTable(new List<bool> { true }));
        // Row 12
        result.Add(new Cable16bitTruthTable(new List<bool> { false }));
        // Row 13
        result.Add(new Cable16bitTruthTable(new List<bool> { false }));
        // Row 14
        result.Add(new Cable16bitTruthTable(new List<bool> { false }));
        // Row 15
        result.Add(new Cable16bitTruthTable(new List<bool> { true }));
        // Row 16
        result.Add(new Cable16bitTruthTable(new List<bool> { true }));
        // Row 17
        result.Add(new Cable16bitTruthTable(new List<bool> { false }));
        // Row 18
        result.Add(new Cable16bitTruthTable(new List<bool> { true }));
        // Row 19
        result.Add(new Cable16bitTruthTable(new List<bool> { false }));
        // Row 20
        result.Add(new Cable16bitTruthTable(new List<bool> { true }));
        // Row 21
        result.Add(new Cable16bitTruthTable(new List<bool> { false }));
        // Row 22
        result.Add(new Cable16bitTruthTable(new List<bool> { false }));
        // Row 23
        result.Add(new Cable16bitTruthTable(new List<bool> { false }));
        // Row 24
        result.Add(new Cable16bitTruthTable(new List<bool> { true }));
        // Row 25
        result.Add(new Cable16bitTruthTable(new List<bool> { true }));
        // Row 26
        result.Add(new Cable16bitTruthTable(new List<bool> { true }));
        // Row 27
        result.Add(new Cable16bitTruthTable(new List<bool> { true }));
        // Row 28
        result.Add(new Cable16bitTruthTable(new List<bool> { true }));
        // Row 29
        result.Add(new Cable16bitTruthTable(new List<bool> { true }));
        // Row 30
        result.Add(new Cable16bitTruthTable(new List<bool> { false }));
        // Row 31
        result.Add(new Cable16bitTruthTable(new List<bool> { false }));
        // Row 32
        result.Add(new Cable16bitTruthTable(new List<bool> { false }));
        // Row 33
        result.Add(new Cable16bitTruthTable(new List<bool> { true }));
        // Row 34
        result.Add(new Cable16bitTruthTable(new List<bool> { true }));
        // Row 35
        result.Add(new Cable16bitTruthTable(new List<bool> { false }));
        // Row 36
        result.Add(new Cable16bitTruthTable(new List<bool> { true }));

        return result;
    }
    public static List<Cable16bitTruthTable> TestOUT()
    {
        List<Cable16bitTruthTable> result = new List<Cable16bitTruthTable>();
        // Row 1
        result.Add(new Cable16bitTruthTable(new List<bool> { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false }));
        // Row 2
        result.Add(new Cable16bitTruthTable(new List<bool> { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, true }));
        // Row 3
        result.Add(new Cable16bitTruthTable(new List<bool> { true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true }));
        // Row 4
        result.Add(new Cable16bitTruthTable(new List<bool> { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false }));
        // Row 5
        result.Add(new Cable16bitTruthTable(new List<bool> { true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true }));
        // Row 6
        result.Add(new Cable16bitTruthTable(new List<bool> { true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true }));
        // Row 7
        result.Add(new Cable16bitTruthTable(new List<bool> { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false }));
        // Row 8
        result.Add(new Cable16bitTruthTable(new List<bool> { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false }));
        // Row 9
        result.Add(new Cable16bitTruthTable(new List<bool> { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, true }));
        // Row 10
        result.Add(new Cable16bitTruthTable(new List<bool> { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, true }));
        // Row 11
        result.Add(new Cable16bitTruthTable(new List<bool> { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false }));
        // Row 12
        result.Add(new Cable16bitTruthTable(new List<bool> { true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true }));
        // Row 13
        result.Add(new Cable16bitTruthTable(new List<bool> { true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, false }));
        // Row 14
        result.Add(new Cable16bitTruthTable(new List<bool> { true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true }));
        // Row 15
        result.Add(new Cable16bitTruthTable(new List<bool> { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, true }));
        // Row 16
        result.Add(new Cable16bitTruthTable(new List<bool> { true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true }));
        // Row 17
        result.Add(new Cable16bitTruthTable(new List<bool> { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false }));
        // Row 18
        result.Add(new Cable16bitTruthTable(new List<bool> { true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true }));
        // Row 19
        result.Add(new Cable16bitTruthTable(new List<bool> { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false }));
        // Row 20
        result.Add(new Cable16bitTruthTable(new List<bool> { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, true }));
        // Row 21
        result.Add(new Cable16bitTruthTable(new List<bool> { true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true }));
        // Row 22       
        result.Add(new Cable16bitTruthTable(new List<bool> { false, false, false, false, false, false, false, false, false, false, false, true, false, false, false, true }));
        // Row 23
        result.Add(new Cable16bitTruthTable(new List<bool> { false, false, false, false, false, false, false, false, false, false, false, false, false, false, true, true }));
        // Row 24
        result.Add(new Cable16bitTruthTable(new List<bool> { true, true, true, true, true, true, true, true, true, true, true, false, true, true, true, false }));
        // Row 25
        result.Add(new Cable16bitTruthTable(new List<bool> { true, true, true, true, true, true, true, true, true, true, true, true, true, true, false, false }));
        // Row 26
        result.Add(new Cable16bitTruthTable(new List<bool> { true, true, true, true, true, true, true, true, true, true, true, false, true, true, true, true }));
        // Row 27
        result.Add(new Cable16bitTruthTable(new List<bool> { true, true, true, true, true, true, true, true, true, true, true, true, true, true, false, true }));
        // Row 28
        result.Add(new Cable16bitTruthTable(new List<bool> { false, false, false, false, false, false, false, false, false, false, false, true, false, false, true, false }));
        // Row 29
        result.Add(new Cable16bitTruthTable(new List<bool> { false, false, false, false, false, false, false, false, false, false, false, false, false, true, false, false }));
        // Row 30
        result.Add(new Cable16bitTruthTable(new List<bool> { false, false, false, false, false, false, false, false, false, false, false, true, false, false, false, false }));
        // Row 31
        result.Add(new Cable16bitTruthTable(new List<bool> { false, false, false, false, false, false, false, false, false, false, false, false, false, false, true, false }));
        // Row 32
        result.Add(new Cable16bitTruthTable(new List<bool> { false, false, false, false, false, false, false, false, false, false, false, true, false, true, false, false }));
        // Row 33
        result.Add(new Cable16bitTruthTable(new List<bool> { false, false, false, false, false, false, false, false, false, false, false, false, true, true, true, false }));
        // Row 34
        result.Add(new Cable16bitTruthTable(new List<bool> { true, true, true, true, true, true, true, true, true, true, true, true, false, false, true, false }));
        // Row 35
        result.Add(new Cable16bitTruthTable(new List<bool> { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, true }));
        // Row 36
        result.Add(new Cable16bitTruthTable(new List<bool> { false, false, false, false, false, false, false, false, false, false, false, true, false, false, true, true }));

        return result;
    }
    public static List<Cable16bitTruthTable> TestIN_ZR()
    {
        List<Cable16bitTruthTable> result = new List<Cable16bitTruthTable>();
        // Row 1
        result.Add(new Cable16bitTruthTable(new List<bool> { true }));
        // Row 2
        result.Add(new Cable16bitTruthTable(new List<bool> { false }));
        // Row 3
        result.Add(new Cable16bitTruthTable(new List<bool> { false }));
        // Row 4
        result.Add(new Cable16bitTruthTable(new List<bool> { true }));
        // Row 5
        result.Add(new Cable16bitTruthTable(new List<bool> { false }));
        // Row 6
        result.Add(new Cable16bitTruthTable(new List<bool> { false }));
        // Row 7
        result.Add(new Cable16bitTruthTable(new List<bool> { true }));
        // Row 8
        result.Add(new Cable16bitTruthTable(new List<bool> { true }));
        // Row 9
        result.Add(new Cable16bitTruthTable(new List<bool> { false }));
        // Row 10
        result.Add(new Cable16bitTruthTable(new List<bool> { false }));
        // Row 11
        result.Add(new Cable16bitTruthTable(new List<bool> { true }));
        // Row 12
        result.Add(new Cable16bitTruthTable(new List<bool> { false }));
        // Row 13
        result.Add(new Cable16bitTruthTable(new List<bool> { false }));
        // Row 14
        result.Add(new Cable16bitTruthTable(new List<bool> { false }));
        // Row 15
        result.Add(new Cable16bitTruthTable(new List<bool> { false }));
        // Row 16
        result.Add(new Cable16bitTruthTable(new List<bool> { false }));
        // Row 17
        result.Add(new Cable16bitTruthTable(new List<bool> { true }));
        // Row 18
        result.Add(new Cable16bitTruthTable(new List<bool> { false }));
        // Row 19
        result.Add(new Cable16bitTruthTable(new List<bool> { true }));
        // Row 20
        result.Add(new Cable16bitTruthTable(new List<bool> { false }));
        // Row 21
        result.Add(new Cable16bitTruthTable(new List<bool> { false }));
        // Row 22
        result.Add(new Cable16bitTruthTable(new List<bool> { false }));
        // Row 23
        result.Add(new Cable16bitTruthTable(new List<bool> { false }));
        // Row 24
        result.Add(new Cable16bitTruthTable(new List<bool> { false }));
        // Row 25
        result.Add(new Cable16bitTruthTable(new List<bool> { false }));
        // Row 26
        result.Add(new Cable16bitTruthTable(new List<bool> { false }));
        // Row 27
        result.Add(new Cable16bitTruthTable(new List<bool> { false }));
        // Row 28
        result.Add(new Cable16bitTruthTable(new List<bool> { false }));
        // Row 29
        result.Add(new Cable16bitTruthTable(new List<bool> { false }));
        // Row 30
        result.Add(new Cable16bitTruthTable(new List<bool> { false }));
        // Row 31
        result.Add(new Cable16bitTruthTable(new List<bool> { false }));
        // Row 32
        result.Add(new Cable16bitTruthTable(new List<bool> { false }));
        // Row 33
        result.Add(new Cable16bitTruthTable(new List<bool> { false }));
        // Row 34
        result.Add(new Cable16bitTruthTable(new List<bool> { false }));
        // Row 35
        result.Add(new Cable16bitTruthTable(new List<bool> { false }));
        // Row 36
        result.Add(new Cable16bitTruthTable(new List<bool> { false }));

        return result;
    }

    public static List<Cable16bitTruthTable> TestIN_NO()
    {
        List<Cable16bitTruthTable> result = new List<Cable16bitTruthTable>();
        // Row 1
        result.Add(new Cable16bitTruthTable(new List<bool> { false }));
        // Row 2
        result.Add(new Cable16bitTruthTable(new List<bool> { false }));
        // Row 3
        result.Add(new Cable16bitTruthTable(new List<bool> { true }));
        // Row 4
        result.Add(new Cable16bitTruthTable(new List<bool> { false }));
        // Row 5
        result.Add(new Cable16bitTruthTable(new List<bool> { true }));
        // Row 6
        result.Add(new Cable16bitTruthTable(new List<bool> { true }));
        // Row 7
        result.Add(new Cable16bitTruthTable(new List<bool> { false }));
        // Row 8
        result.Add(new Cable16bitTruthTable(new List<bool> { false }));
        // Row 9
        result.Add(new Cable16bitTruthTable(new List<bool> { false }));
        // Row 10
        result.Add(new Cable16bitTruthTable(new List<bool> { false }));
        // Row 11
        result.Add(new Cable16bitTruthTable(new List<bool> { false }));
        // Row 12
        result.Add(new Cable16bitTruthTable(new List<bool> { true }));
        // Row 13
        result.Add(new Cable16bitTruthTable(new List<bool> { true }));
        // Row 14
        result.Add(new Cable16bitTruthTable(new List<bool> { true }));
        // Row 15
        result.Add(new Cable16bitTruthTable(new List<bool> { false }));
        // Row 16
        result.Add(new Cable16bitTruthTable(new List<bool> { true }));
        // Row 17
        result.Add(new Cable16bitTruthTable(new List<bool> { false }));
        // Row 18
        result.Add(new Cable16bitTruthTable(new List<bool> { true }));
        // Row 19
        result.Add(new Cable16bitTruthTable(new List<bool> { false }));
        // Row 20
        result.Add(new Cable16bitTruthTable(new List<bool> { false }));
        // Row 21
        result.Add(new Cable16bitTruthTable(new List<bool> { true }));
        // Row 22
        result.Add(new Cable16bitTruthTable(new List<bool> { false }));
        // Row 23
        result.Add(new Cable16bitTruthTable(new List<bool> { false }));
        // Row 24
        result.Add(new Cable16bitTruthTable(new List<bool> { true }));
        // Row 25
        result.Add(new Cable16bitTruthTable(new List<bool> { true }));
        // Row 26
        result.Add(new Cable16bitTruthTable(new List<bool> { true }));
        // Row 27
        result.Add(new Cable16bitTruthTable(new List<bool> { true }));
        // Row 28
        result.Add(new Cable16bitTruthTable(new List<bool> { false }));
        // Row 29
        result.Add(new Cable16bitTruthTable(new List<bool> { false }));
        // Row 30
        result.Add(new Cable16bitTruthTable(new List<bool> { false }));
        // Row 31
        result.Add(new Cable16bitTruthTable(new List<bool> { false }));
        // Row 32
        result.Add(new Cable16bitTruthTable(new List<bool> { false }));
        // Row 33
        result.Add(new Cable16bitTruthTable(new List<bool> { false }));
        // Row 34
        result.Add(new Cable16bitTruthTable(new List<bool> { true }));
        // Row 35
        result.Add(new Cable16bitTruthTable(new List<bool> { false }));
        // Row 36
        result.Add(new Cable16bitTruthTable(new List<bool> { false }));

        return result;
    }
}
