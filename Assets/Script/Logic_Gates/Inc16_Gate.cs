using UnityEngine;
using System.Collections.Generic;
public class Inc16_Gate : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private CableManager16bit input; 
    public Cable16bit Out;
    public Cable16bit getCable()
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
    
    public static List<Cable16bitTruthTable> TestA15()
    {
        List<Cable16bitTruthTable> result = new List<Cable16bitTruthTable>();
        // Row 0
        result.Add(new Cable16bitTruthTable(new List<bool> { false, true,false, true}));
        return result;
    }
    public static List<Cable16bitTruthTable> TestA14()
    {
        List<Cable16bitTruthTable> result = new List<Cable16bitTruthTable>();
        // Row 1
        result.Add(new Cable16bitTruthTable(new List<bool> { false, true,false, true}));
        return result;
    }
    public static List<Cable16bitTruthTable> TestA13()
    {
        List<Cable16bitTruthTable> result = new List<Cable16bitTruthTable>();
        // Row 2
        result.Add(new Cable16bitTruthTable(new List<bool> { false, true,false, true}));
        return result;
    }
    public static List<Cable16bitTruthTable> TestA12()
    {
        List<Cable16bitTruthTable> result = new List<Cable16bitTruthTable>();
        // Row 3
        result.Add(new Cable16bitTruthTable(new List<bool> { false, true,false, true}));
        return result;
    }
    public static List<Cable16bitTruthTable> TestA11()
    {
        List<Cable16bitTruthTable> result = new List<Cable16bitTruthTable>();
        // Row 4
        result.Add(new Cable16bitTruthTable(new List<bool> { false, true,false, true}));
        return result;
    }
    public static List<Cable16bitTruthTable> TestA10()
    {
        List<Cable16bitTruthTable> result = new List<Cable16bitTruthTable>();
        // Row 5
        result.Add(new Cable16bitTruthTable(new List<bool> { false, true,false, true}));
        return result;
    }
    public static List<Cable16bitTruthTable> TestA9()
    {
        List<Cable16bitTruthTable> result = new List<Cable16bitTruthTable>();
        // Row 6
        result.Add(new Cable16bitTruthTable(new List<bool> { false, true,false, true}));
        return result;
    }
    public static List<Cable16bitTruthTable> TestA8()
    {
        List<Cable16bitTruthTable> result = new List<Cable16bitTruthTable>();
        // Row 7
        result.Add(new Cable16bitTruthTable(new List<bool> { false, true,false, true}));
        return result;
    }
    public static List<Cable16bitTruthTable> TestA7()
    {
        List<Cable16bitTruthTable> result = new List<Cable16bitTruthTable>();
        // Row 8
        result.Add(new Cable16bitTruthTable(new List<bool> { false, true,false, true}));
        return result;
    }
    public static List<Cable16bitTruthTable> TestA6()
    {
        List<Cable16bitTruthTable> result = new List<Cable16bitTruthTable>();
        // Row 9
        result.Add(new Cable16bitTruthTable(new List<bool> { false, true,false, true}));
        return result;
    }
    public static List<Cable16bitTruthTable> TestA5()
    {
        List<Cable16bitTruthTable> result = new List<Cable16bitTruthTable>();
        // Row 10
        result.Add(new Cable16bitTruthTable(new List<bool> { false, true,false, true}));
        return result;
    }
    public static List<Cable16bitTruthTable> TestA4()
    {
        List<Cable16bitTruthTable> result = new List<Cable16bitTruthTable>();
        // Row 11
        result.Add(new Cable16bitTruthTable(new List<bool> { false, true,false, true}));
        return result;
    }
    public static List<Cable16bitTruthTable> TestA3()
    {
        List<Cable16bitTruthTable> result = new List<Cable16bitTruthTable>();
        // Row 12
        result.Add(new Cable16bitTruthTable(new List<bool> { false, true,false, true}));
        return result;
    }
    public static List<Cable16bitTruthTable> TestA2()
    {
        List<Cable16bitTruthTable> result = new List<Cable16bitTruthTable>();
        // Row 13
        result.Add(new Cable16bitTruthTable(new List<bool> { false, true,true, false}));
        return result;
    }
    public static List<Cable16bitTruthTable> TestA1()
    {
        List<Cable16bitTruthTable> result = new List<Cable16bitTruthTable>();
        // Row 14
        result.Add(new Cable16bitTruthTable(new List<bool> { false, true,false, true}));
        return result;
    }
    public static List<Cable16bitTruthTable> TestA()
    {
        List<Cable16bitTruthTable> result = new List<Cable16bitTruthTable>();
        // Row 15
        result.Add(new Cable16bitTruthTable(new List<bool> { false, true,true, true}));
        return result;
    }


    public static List<Cable16bitTruthTable> TestB15()
    {
        List<Cable16bitTruthTable> result = new List<Cable16bitTruthTable>();
        // Row 0
        result.Add(new Cable16bitTruthTable(new List<bool> { false, false,false, false}));

        return result;
    }
    public static List<Cable16bitTruthTable> TestB14()
    {
        List<Cable16bitTruthTable> result = new List<Cable16bitTruthTable>();
        // Row 1
        result.Add(new Cable16bitTruthTable(new List<bool> { false, false,false, false}));

        return result;
    }
    public static List<Cable16bitTruthTable> TestB13()
    {
        List<Cable16bitTruthTable> result = new List<Cable16bitTruthTable>();
        // Row 2
        result.Add(new Cable16bitTruthTable(new List<bool> { false, false,false, false}));

        return result;
    }
    public static List<Cable16bitTruthTable> TestB12()
    {
        List<Cable16bitTruthTable> result = new List<Cable16bitTruthTable>();
        // Row 3
        result.Add(new Cable16bitTruthTable(new List<bool> { false, false,false, false}));

        return result;
    }
    public static List<Cable16bitTruthTable> TestB11()
    {
        List<Cable16bitTruthTable> result = new List<Cable16bitTruthTable>();
        // Row 4
        result.Add(new Cable16bitTruthTable(new List<bool> { false, false,false, false}));

        return result;
    }
    public static List<Cable16bitTruthTable> TestB10()
    {
        List<Cable16bitTruthTable> result = new List<Cable16bitTruthTable>();
        // Row 5
        result.Add(new Cable16bitTruthTable(new List<bool> { false, false,false, false}));

        return result;
    }
    public static List<Cable16bitTruthTable> TestB9()
    {
        List<Cable16bitTruthTable> result = new List<Cable16bitTruthTable>();
        // Row 6
        result.Add(new Cable16bitTruthTable(new List<bool> { false, false,false, false}));

        return result;
    }
    public static List<Cable16bitTruthTable> TestB8()
    {
        List<Cable16bitTruthTable> result = new List<Cable16bitTruthTable>();
        // Row 7
        result.Add(new Cable16bitTruthTable(new List<bool> { false, false,false, false}));

        return result;
    }
    public static List<Cable16bitTruthTable> TestB7()
    {
        List<Cable16bitTruthTable> result = new List<Cable16bitTruthTable>();
        // Row 8
        result.Add(new Cable16bitTruthTable(new List<bool> { false, false,false, false}));

        return result;
    }
    public static List<Cable16bitTruthTable> TestB6()
    {
        List<Cable16bitTruthTable> result = new List<Cable16bitTruthTable>();
        // Row 9
        result.Add(new Cable16bitTruthTable(new List<bool> { false, false,false, false}));

        return result;
    }
    public static List<Cable16bitTruthTable> TestB5()
    {
        List<Cable16bitTruthTable> result = new List<Cable16bitTruthTable>();
        // Row 10
        result.Add(new Cable16bitTruthTable(new List<bool> { false, false,false, false}));

        return result;
    }
    public static List<Cable16bitTruthTable> TestB4()
    {
        List<Cable16bitTruthTable> result = new List<Cable16bitTruthTable>();
        // Row 11
        result.Add(new Cable16bitTruthTable(new List<bool> { false, false,false, false}));

        return result;
    }
    public static List<Cable16bitTruthTable> TestB3()
    {
        List<Cable16bitTruthTable> result = new List<Cable16bitTruthTable>();
        // Row 12
        result.Add(new Cable16bitTruthTable(new List<bool> { false, false,false, false}));

        return result;
    }
    public static List<Cable16bitTruthTable> TestB2()
    {
        List<Cable16bitTruthTable> result = new List<Cable16bitTruthTable>();
        // Row 13
        result.Add(new Cable16bitTruthTable(new List<bool> { false, false,false, false}));

        return result;
    }
    public static List<Cable16bitTruthTable> TestB1()
    {
        List<Cable16bitTruthTable> result = new List<Cable16bitTruthTable>();
        // Row 14
        result.Add(new Cable16bitTruthTable(new List<bool> { false, false,false, false}));

        return result;
    }
    public static List<Cable16bitTruthTable> TestB()
    {
        List<Cable16bitTruthTable> result = new List<Cable16bitTruthTable>();
        // Row 15
        result.Add(new Cable16bitTruthTable(new List<bool> { true, true,true, true})); 

        return result;
    }

    public static List<bool>  TestOUT15()
    {
        // Row 0
        return  new List<bool> { false, false,false, true} ;
    }
    public static List<bool>  TestOUT14()
    {
        // Row 1
        return  new List<bool> { false, false,false, true};
    }
    public static List<bool>  TestOUT13()
    {
        // Row 2
        return new List<bool> { false, false,false, true};
    }
    public static List<bool>  TestOUT12()
    {
        // Row 3
        return new List<bool> { false, false,false, true};
    }
    public static List<bool>  TestOUT11()
    {
        // Row 4
        return  new List<bool> { false, false,false, true};
    }
    public static List<bool>  TestOUT10()
    {
        // Row 5
        return new List<bool> { false, false,false, true};
    }
    public static List<bool>  TestOUT9()
    {
        // Row 6
        return new List<bool> { false, false,false, true};
    }
    public static List<bool>  TestOUT8()
    {
        // Row 7
        return new List<bool> { false, false,false, true};
    }
    public static List<bool>  TestOUT7()
    {
        // Row 8
        return new List<bool> { false, false,false, true};
    }
    public static List<bool>  TestOUT6()
    {
        // Row 9
        return new List<bool> { false, false,false, true};
    }
    public static List<bool>  TestOUT5()
    {
        // Row 10
        return new List<bool> { false, false,false, true};
    }
    public static List<bool> TestOUT4()
    {
        // Row 11
        return new List<bool> { false, false,false, true};
    }
    public static List<bool>  TestOUT3()
    {
        // Row 12
        return new List<bool> { false, false,false, true};
    }
    public static List<bool>  TestOUT2()
    {
        // Row 13
        return new List<bool> { false, false,true, true};
    }
    public static List<bool>  TestOUT1()
    {
        // Row 14
        return new List<bool> { false, false,true, false};
    }
    public static List<bool>  TestOUT()
    {
        // Row 15
        return new List<bool> { true, false,false, false};
    }


}
