using System.Collections.Generic;
using UnityEngine;


// [System.Serializable]
// public class Cable16bitTruthTable
// {
//     public List<bool> truthTable; 
// }

public class Add16_Gate : MonoBehaviour
{
    public int ID_Gate { get; private set; } 

    public void SetID(int id)
    {
        ID_Gate = id;
    }
    [SerializeField] private CableManager16bit inputA; 
    [SerializeField] private CableManager16bit inputB; 
    public ButtonController Out;
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
    public static List<Cable16bitTruthTable> TestA15()
    {
        List<Cable16bitTruthTable> result = new List<Cable16bitTruthTable>();
        // Row 0
        result.Add(new Cable16bitTruthTable(new List<bool> { false, false,true, true,  false,  false}));
        return result;
    }
    public static List<Cable16bitTruthTable> TestA14()
    {
        List<Cable16bitTruthTable> result = new List<Cable16bitTruthTable>();
        // Row 1
        result.Add(new Cable16bitTruthTable(new List<bool> { false, false,true, false,  false,  false}));
        return result;
    }
    public static List<Cable16bitTruthTable> TestA13()
    {
        List<Cable16bitTruthTable> result = new List<Cable16bitTruthTable>();
        // Row 2
        result.Add(new Cable16bitTruthTable(new List<bool> { false, false,true, true,  true,  false}));
        return result;
    }
    public static List<Cable16bitTruthTable> TestA12()
    {
        List<Cable16bitTruthTable> result = new List<Cable16bitTruthTable>();
        // Row 3
        result.Add(new Cable16bitTruthTable(new List<bool> { false, false,true, false,  true,  true}));
        return result;
    }
    public static List<Cable16bitTruthTable> TestA11()
    {
        List<Cable16bitTruthTable> result = new List<Cable16bitTruthTable>();
        // Row 4
        result.Add(new Cable16bitTruthTable(new List<bool> { false, false,true, true,  true,  false}));
        return result;
    }
    public static List<Cable16bitTruthTable> TestA10()
    {
        List<Cable16bitTruthTable> result = new List<Cable16bitTruthTable>();
        // Row 5
        result.Add(new Cable16bitTruthTable(new List<bool> { false, false,true, false,  true,  false}));
        return result;
    }
    public static List<Cable16bitTruthTable> TestA9()
    {
        List<Cable16bitTruthTable> result = new List<Cable16bitTruthTable>();
        // Row 6
        result.Add(new Cable16bitTruthTable(new List<bool> { false, false,true, true,  false,  true}));
        return result;
    }
    public static List<Cable16bitTruthTable> TestA8()
    {
        List<Cable16bitTruthTable> result = new List<Cable16bitTruthTable>();
        // Row 7
        result.Add(new Cable16bitTruthTable(new List<bool> { false, false,true, false,  false,  false}));
        return result;
    }
    public static List<Cable16bitTruthTable> TestA7()
    {
        List<Cable16bitTruthTable> result = new List<Cable16bitTruthTable>();
        // Row 8
        result.Add(new Cable16bitTruthTable(new List<bool> { false, false,true, true,  true,  false}));
        return result;
    }
    public static List<Cable16bitTruthTable> TestA6()
    {
        List<Cable16bitTruthTable> result = new List<Cable16bitTruthTable>();
        // Row 9
        result.Add(new Cable16bitTruthTable(new List<bool> { false, false,true, false,  true,  false}));
        return result;
    }
    public static List<Cable16bitTruthTable> TestA5()
    {
        List<Cable16bitTruthTable> result = new List<Cable16bitTruthTable>();
        // Row 10
        result.Add(new Cable16bitTruthTable(new List<bool> { false, false,true, true,  false,  true}));
        return result;
    }
    public static List<Cable16bitTruthTable> TestA4()
    {
        List<Cable16bitTruthTable> result = new List<Cable16bitTruthTable>();
        // Row 11
        result.Add(new Cable16bitTruthTable(new List<bool> { false, false,true, false,  false,  true}));
        return result;
    }
    public static List<Cable16bitTruthTable> TestA3()
    {
        List<Cable16bitTruthTable> result = new List<Cable16bitTruthTable>();
        // Row 12
        result.Add(new Cable16bitTruthTable(new List<bool> { false, false,true, true,  false,  false}));
        return result;
    }
    public static List<Cable16bitTruthTable> TestA2()
    {
        List<Cable16bitTruthTable> result = new List<Cable16bitTruthTable>();
        // Row 13
        result.Add(new Cable16bitTruthTable(new List<bool> { false, false,true, false,  false,  true}));
        return result;
    }
    public static List<Cable16bitTruthTable> TestA1()
    {
        List<Cable16bitTruthTable> result = new List<Cable16bitTruthTable>();
        // Row 14
        result.Add(new Cable16bitTruthTable(new List<bool> { false, false,true, true,  true,  false}));
        return result;
    }
    public static List<Cable16bitTruthTable> TestA()
    {
        List<Cable16bitTruthTable> result = new List<Cable16bitTruthTable>();
        // Row 15
        result.Add(new Cable16bitTruthTable(new List<bool> { false, false,true, false,  true,  false}));
        return result;
    }


    public static List<Cable16bitTruthTable> TestB15()
    {
        List<Cable16bitTruthTable> result = new List<Cable16bitTruthTable>();
        // Row 0
        result.Add(new Cable16bitTruthTable(new List<bool> { false, true,true, false,  false,  true}));

        return result;
    }
    public static List<Cable16bitTruthTable> TestB14()
    {
        List<Cable16bitTruthTable> result = new List<Cable16bitTruthTable>();
        // Row 1
        result.Add(new Cable16bitTruthTable(new List<bool> { false, true,true, true,  false,  false}));

        return result;
    }
    public static List<Cable16bitTruthTable> TestB13()
    {
        List<Cable16bitTruthTable> result = new List<Cable16bitTruthTable>();
        // Row 2
        result.Add(new Cable16bitTruthTable(new List<bool> { false, true,true, false,  false,  false}));

        return result;
    }
    public static List<Cable16bitTruthTable> TestB12()
    {
        List<Cable16bitTruthTable> result = new List<Cable16bitTruthTable>();
        // Row 3
        result.Add(new Cable16bitTruthTable(new List<bool> { false, true,true, true,  false,  true}));

        return result;
    }
    public static List<Cable16bitTruthTable> TestB11()
    {
        List<Cable16bitTruthTable> result = new List<Cable16bitTruthTable>();
        // Row 4
        result.Add(new Cable16bitTruthTable(new List<bool> { false, true,true, false,  true,  true}));

        return result;
    }
    public static List<Cable16bitTruthTable> TestB10()
    {
        List<Cable16bitTruthTable> result = new List<Cable16bitTruthTable>();
        // Row 5
        result.Add(new Cable16bitTruthTable(new List<bool> { false, true,true, true,  true,  false}));

        return result;
    }
    public static List<Cable16bitTruthTable> TestB9()
    {
        List<Cable16bitTruthTable> result = new List<Cable16bitTruthTable>();
        // Row 6
        result.Add(new Cable16bitTruthTable(new List<bool> { false, true,true, false,  true,  false}));

        return result;
    }
    public static List<Cable16bitTruthTable> TestB8()
    {
        List<Cable16bitTruthTable> result = new List<Cable16bitTruthTable>();
        // Row 7
        result.Add(new Cable16bitTruthTable(new List<bool> { false, true,true, true,  true,  false}));

        return result;
    }
    public static List<Cable16bitTruthTable> TestB7()
    {
        List<Cable16bitTruthTable> result = new List<Cable16bitTruthTable>();
        // Row 8
        result.Add(new Cable16bitTruthTable(new List<bool> { false, true,true, false,  true,  false}));

        return result;
    }
    public static List<Cable16bitTruthTable> TestB6()
    {
        List<Cable16bitTruthTable> result = new List<Cable16bitTruthTable>();
        // Row 9
        result.Add(new Cable16bitTruthTable(new List<bool> { false, true,true, true,  true,  true}));

        return result;
    }
    public static List<Cable16bitTruthTable> TestB5()
    {
        List<Cable16bitTruthTable> result = new List<Cable16bitTruthTable>();
        // Row 10
        result.Add(new Cable16bitTruthTable(new List<bool> { false, true,true, false,  true,  true}));

        return result;
    }
    public static List<Cable16bitTruthTable> TestB4()
    {
        List<Cable16bitTruthTable> result = new List<Cable16bitTruthTable>();
        // Row 11
        result.Add(new Cable16bitTruthTable(new List<bool> { false, true,true, true,  true,  true}));

        return result;
    }
    public static List<Cable16bitTruthTable> TestB3()
    {
        List<Cable16bitTruthTable> result = new List<Cable16bitTruthTable>();
        // Row 12
        result.Add(new Cable16bitTruthTable(new List<bool> { false, true,true, false,  false,  false}));

        return result;
    }
    public static List<Cable16bitTruthTable> TestB2()
    {
        List<Cable16bitTruthTable> result = new List<Cable16bitTruthTable>();
        // Row 13
        result.Add(new Cable16bitTruthTable(new List<bool> { false, true,true, true,  false,  true}));

        return result;
    }
    public static List<Cable16bitTruthTable> TestB1()
    {
        List<Cable16bitTruthTable> result = new List<Cable16bitTruthTable>();
        // Row 14
        result.Add(new Cable16bitTruthTable(new List<bool> { false, true,true, false,  false,  true}));

        return result;
    }
    public static List<Cable16bitTruthTable> TestB()
    {
        List<Cable16bitTruthTable> result = new List<Cable16bitTruthTable>();
        // Row 15
        result.Add(new Cable16bitTruthTable(new List<bool> { false, true,true, true,  false,  false})); 

        return result;
    }

    public static List<bool>  TestOUT15()
    {
        // Row 0
        return  new List<bool> { false, true,true, true,  false,  true} ;
    }
    public static List<bool>  TestOUT14()
    {
        // Row 1
        return  new List<bool> { false, true,true, true,  true,  false};
    }
    public static List<bool>  TestOUT13()
    {
        // Row 2
        return new List<bool> { false, true,true, true,  false,  true};
    }
    public static List<bool>  TestOUT12()
    {
        // Row 3
        return new List<bool> { false, true,true, true,  false,  false};
    }
    public static List<bool>  TestOUT11()
    {
        // Row 4
        return  new List<bool> { false, true,true, true,  true,  true};
    }
    public static List<bool>  TestOUT10()
    {
        // Row 5
        return new List<bool> { false, true,true, true,  true,  false};
    }
    public static List<bool>  TestOUT9()
    {
        // Row 6
        return new List<bool> { false, true,true, true,  false,  true};
    }
    public static List<bool>  TestOUT8()
    {
        // Row 7
        return new List<bool> { false, true,true, true,  false,  false};
    }
    public static List<bool>  TestOUT7()
    {
        // Row 8
        return new List<bool> { false, true,true, true,  true,  true};
    }
    public static List<bool>  TestOUT6()
    {
        // Row 9
        return new List<bool> { false, true,true, true,  false,  false};
    }
    public static List<bool>  TestOUT5()
    {
        // Row 10
        return new List<bool> { false, true,true, true,  true,  true};
    }
    public static List<bool> TestOUT4()
    {
        // Row 11
        return new List<bool> { false, true,true, true,  true,  false};
    }
    public static List<bool>  TestOUT3()
    {
        // Row 12
        return new List<bool> { false, true,true, true,  false,  true};
    }
    public static List<bool>  TestOUT2()
    {
        // Row 13
        return new List<bool> { false, true,true, true,  false,  false};
    }
    public static List<bool>  TestOUT1()
    {
        // Row 14
        return new List<bool> { false, true,true, true,  true,  true};
    }
    public static List<bool>  TestOUT()
    {
        // Row 15
        return new List<bool> { false, true,false, true,  true,  false};
    }

}
