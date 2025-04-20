using DoorScript;
using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class Cable16bitTruthTable
{
    public List<bool> truthTable; 
    
    public Cable16bitTruthTable(List<bool> values)
    {
        this.truthTable = new List<bool>(values);
    }
}


[System.Serializable]
public class CableManagerTruthTableT
{
    public CableManager cableManager; 
    public List<Cable16bitTruthTable> truthTable = new List<Cable16bitTruthTable>(){}; 
}

[System.Serializable]
public class CableTruthTable
{
    public Cable cable; 
    public ButtonController1bit cables;
    // public Cable16bit cable16bit;
    public List<Cable16bitTruthTable> truthTable = new List<Cable16bitTruthTable>(){}; 
}


[System.Serializable]
public class CableManagerTruthTable16bit
{
    public CableManager16bit cableManager; 
    // public CableManager16bit cableManager16bit;
    public List<Cable16bitTruthTable> truthTable = new List<Cable16bitTruthTable>(){}; 
}
[System.Serializable]
public class CableTruthTable16bit
{
    public Cable16bit cable; 
    // public Cable16bit cable16bit;
    public List<Cable16bitTruthTable> truthTable = new List<Cable16bitTruthTable>(){}; 
}

public class Test_WorkSpace : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private LogicGates_Type Name; 
    [SerializeField] private Door door; 
    [SerializeField] private List<CableTruthTable> cableTruthTables = new List<CableTruthTable>(){};
    [SerializeField] private List<CableManagerTruthTableT> cableManagaerTruthTables = new List<CableManagerTruthTableT>(){};
    [SerializeField] private List<CableTruthTable16bit> cable16TruthTables = new List<CableTruthTable16bit>(){};
    [SerializeField] private List<CableManagerTruthTable16bit> cableManagaer16TruthTables = new List<CableManagerTruthTable16bit>(){};
    private bool isSolves =false;
    private bool isSolves16 =false;
    private bool isAllCorrect16 =false;
    private bool isAllCorrect =false;

    private void Not_Gate_tests()
    {
        SearchAndPrintCable(ConnectorType.InA,Not_Gate.TestIN(),CableTypes.c1);
    }
    private void And_Gate_tests()
    {
        SearchAndPrintCable(ConnectorType.InA,AND_Gate.TestIN_A(),CableTypes.c1);
        SearchAndPrintCable(ConnectorType.InB,AND_Gate.TestIN_B(),CableTypes.c1);
    }

    private void Or_Gate_tests()
    {
        SearchAndPrintCable(ConnectorType.InA,OR_Gate.TestIN_A(),CableTypes.c1);
        SearchAndPrintCable(ConnectorType.InB,OR_Gate.TestIN_B(),CableTypes.c1);
    }

    private void Mux4Way16_Gate_tests()
    {
        SearchAndPrintCable(ConnectorType.InA,Mux4Way16_Gate.TestIN_A(),CableTypes.c16);
        SearchAndPrintCable(ConnectorType.InB,Mux4Way16_Gate.TestIN_B(),CableTypes.c16);
        SearchAndPrintCable(ConnectorType.InC,Mux4Way16_Gate.TestIN_C(),CableTypes.c16);
        SearchAndPrintCable(ConnectorType.InD,Mux4Way16_Gate.TestIN_D(),CableTypes.c16);
        SearchAndPrintCable(ConnectorType.InSel,Mux4Way16_Gate.TestIN_SEL(),CableTypes.c16);
        // SearchAndPrintCable(ConnectorType.InSel0n1,Mux4Way16_Gate.TestIN_SEL0(),CableTypes.c1);
        // SearchAndPrintCable(ConnectorType.InSel0n2,Mux4Way16_Gate.TestIN_SEL0(),CableTypes.c1);
        // SearchAndPrintCable(ConnectorType.InSel1n1,Mux4Way16_Gate.TestIN_SEL1(),CableTypes.c1);
        // SearchAndPrintCable(ConnectorType.InSel1n2,Mux4Way16_Gate.TestIN_SEL1(),CableTypes.c1);
    }

    private void Mux8Way16_Gate_tests()
    {
        SearchAndPrintCable(ConnectorType.InA,Mux8Way16_Gate.TestIN_A(),CableTypes.c16);
        SearchAndPrintCable(ConnectorType.InB,Mux8Way16_Gate.TestIN_B(),CableTypes.c16);
        SearchAndPrintCable(ConnectorType.InC,Mux8Way16_Gate.TestIN_C(),CableTypes.c16);
        SearchAndPrintCable(ConnectorType.InD,Mux8Way16_Gate.TestIN_D(),CableTypes.c16);
        SearchAndPrintCable(ConnectorType.InE,Mux8Way16_Gate.TestIN_E(),CableTypes.c16);
        SearchAndPrintCable(ConnectorType.InF,Mux8Way16_Gate.TestIN_F(),CableTypes.c16);
        SearchAndPrintCable(ConnectorType.InG,Mux8Way16_Gate.TestIN_G(),CableTypes.c16);
        SearchAndPrintCable(ConnectorType.InH,Mux8Way16_Gate.TestIN_H(),CableTypes.c16);
        SearchAndPrintCable(ConnectorType.InSel,Mux8Way16_Gate.TestIN_SEL(),CableTypes.c16);
        // SearchAndPrintCable(ConnectorType.InSeln2,Mux8Way16_Gate.TestIN_SEL(),CableTypes.c16);
        // SearchAndPrintCable(ConnectorType.InSel0n1,Mux8Way16_Gate.TestIN_SEL0(),CableTypes.c1);
        // SearchAndPrintCable(ConnectorType.InSel0n2,Mux8Way16_Gate.TestIN_SEL0(),CableTypes.c1);
        // SearchAndPrintCable(ConnectorType.InSel1n1,Mux8Way16_Gate.TestIN_SEL1(),CableTypes.c1);
        // SearchAndPrintCable(ConnectorType.InSel1n2,Mux8Way16_Gate.TestIN_SEL1(),CableTypes.c1);
        // SearchAndPrintCable(ConnectorType.InSel2n1,Mux8Way16_Gate.TestIN_SEL2(),CableTypes.c1);
        // SearchAndPrintCable(ConnectorType.InSel2n2,Mux8Way16_Gate.TestIN_SEL2(),CableTypes.c1);
        // SearchAndPrintCable(ConnectorType.InSel1n0_1,Mux8Way16_Gate.TestIN_SEL0_1(),CableTypes.c16);
        // SearchAndPrintCable(ConnectorType.InSel2n0_1,Mux8Way16_Gate.TestIN_SEL0_1(),CableTypes.c16);
        // SearchAndPrintCable(ConnectorType.InSel1n1_2,Mux8Way16_Gate.TestIN_SEL1_2(),CableTypes.c16);
        // SearchAndPrintCable(ConnectorType.InSel2n1_2,Mux8Way16_Gate.TestIN_SEL1_2(),CableTypes.c16);
    }

    private void Dmux4Way_Gate_tests()
    {
        //IN
        // SearchAndPrintCable(ConnectorType.In1,Dmux4Way_Gate.TestIN(),CableTypes.c1);
        // SearchAndPrintCable(ConnectorType.In2,Dmux4Way_Gate.TestIN(),CableTypes.c1);
        // SearchAndPrintCable(ConnectorType.In3,Dmux4Way_Gate.TestIN(),CableTypes.c1);
        // SearchAndPrintCable(ConnectorType.In4,Dmux4Way_Gate.TestIN(),CableTypes.c1);
        //SEL0
        // SearchAndPrintCable(ConnectorType.InSel0n1,Dmux4Way_Gate.TestIN_SEL0(),CableTypes.c1);
        // SearchAndPrintCable(ConnectorType.InSel0n2,Dmux4Way_Gate.TestIN_SEL0(),CableTypes.c1);
        // SearchAndPrintCable(ConnectorType.InSel0n3,Dmux4Way_Gate.TestIN_SEL0(),CableTypes.c1);
        // SearchAndPrintCable(ConnectorType.InSel0n4,Dmux4Way_Gate.TestIN_SEL0(),CableTypes.c1);
        // //SEL1
        // SearchAndPrintCable(ConnectorType.InSel1n1,Dmux4Way_Gate.TestIN_SEL1(),CableTypes.c1);
        // SearchAndPrintCable(ConnectorType.InSel1n2,Dmux4Way_Gate.TestIN_SEL1(),CableTypes.c1);
        // SearchAndPrintCable(ConnectorType.InSel1n3,Dmux4Way_Gate.TestIN_SEL1(),CableTypes.c1);
        // SearchAndPrintCable(ConnectorType.InSel1n4,Dmux4Way_Gate.TestIN_SEL1(),CableTypes.c1);
    }
    private void HalfAdder_Gate_tests()
    {
        // A
        SearchAndPrintCable(ConnectorType.InA,HalfAdder_Gate.TestA(),CableTypes.c1);
        // SearchAndPrintCable(ConnectorType.InA1,HalfAdder_Gate.TestA(),CableTypes.c1);
        // B
        SearchAndPrintCable(ConnectorType.InB,HalfAdder_Gate.TestB(),CableTypes.c1);
        // SearchAndPrintCable(ConnectorType.InB1,HalfAdder_Gate.TestB(),CableTypes.c1);
        
    }
    private void FullAdder_Gate_tests()
    {
        // A
        SearchAndPrintCable(ConnectorType.InA,FullAdder_Gate.TestA(),CableTypes.c1);
        // SearchAndPrintCable(ConnectorType.InA1,FullAdder_Gate.TestA(),CableTypes.c1);
        // SearchAndPrintCable(ConnectorType.InA2,FullAdder_Gate.TestA(),CableTypes.c1);
        // B
        SearchAndPrintCable(ConnectorType.InB,FullAdder_Gate.TestB(),CableTypes.c1);
        // SearchAndPrintCable(ConnectorType.InB1,FullAdder_Gate.TestB(),CableTypes.c1);
        // SearchAndPrintCable(ConnectorType.InB2,FullAdder_Gate.TestB(),CableTypes.c1);
        // C
        SearchAndPrintCable(ConnectorType.InC,FullAdder_Gate.TestC(),CableTypes.c1);
        // SearchAndPrintCable(ConnectorType.InC1,FullAdder_Gate.TestC(),CableTypes.c1);
        // SearchAndPrintCable(ConnectorType.InC2,FullAdder_Gate.TestC(),CableTypes.c1);
    }
    private void Add16_Gate_tests()
    {
        // A
        SearchAndPrintCable(ConnectorType.InA,Add16_Gate.TestA(),CableTypes.c1);
        // SearchAndPrintCable(ConnectorType.InA1,Add16_Gate.TestA1(),CableTypes.c1);
        // SearchAndPrintCable(ConnectorType.InA2,Add16_Gate.TestA2(),CableTypes.c1);
        // SearchAndPrintCable(ConnectorType.InA3,Add16_Gate.TestA3(),CableTypes.c1);
        // SearchAndPrintCable(ConnectorType.InA4,Add16_Gate.TestA4(),CableTypes.c1);
        // SearchAndPrintCable(ConnectorType.InA5,Add16_Gate.TestA5(),CableTypes.c1);
        // SearchAndPrintCable(ConnectorType.InA6,Add16_Gate.TestA6(),CableTypes.c1);
        // SearchAndPrintCable(ConnectorType.InA7,Add16_Gate.TestA7(),CableTypes.c1);
        // SearchAndPrintCable(ConnectorType.InA8,Add16_Gate.TestA8(),CableTypes.c1);
        // SearchAndPrintCable(ConnectorType.InA9,Add16_Gate.TestA9(),CableTypes.c1);
        // SearchAndPrintCable(ConnectorType.InA10,Add16_Gate.TestA10(),CableTypes.c1);
        // SearchAndPrintCable(ConnectorType.InA11,Add16_Gate.TestA11(),CableTypes.c1);
        // SearchAndPrintCable(ConnectorType.InA12,Add16_Gate.TestA12(),CableTypes.c1);
        // SearchAndPrintCable(ConnectorType.InA13,Add16_Gate.TestA13(),CableTypes.c1);
        // SearchAndPrintCable(ConnectorType.InA14,Add16_Gate.TestA14(),CableTypes.c1);
        // SearchAndPrintCable(ConnectorType.InA15,Add16_Gate.TestA15(),CableTypes.c1);
        // B
        SearchAndPrintCable(ConnectorType.InB,Add16_Gate.TestB(),CableTypes.c1);
        // SearchAndPrintCable(ConnectorType.InB1,Add16_Gate.TestB1(),CableTypes.c1);
        // SearchAndPrintCable(ConnectorType.InB2,Add16_Gate.TestB2(),CableTypes.c1);
        // SearchAndPrintCable(ConnectorType.InB3,Add16_Gate.TestB3(),CableTypes.c1);
        // SearchAndPrintCable(ConnectorType.InB4,Add16_Gate.TestB4(),CableTypes.c1);
        // SearchAndPrintCable(ConnectorType.InB5,Add16_Gate.TestB5(),CableTypes.c1);
        // SearchAndPrintCable(ConnectorType.InB6,Add16_Gate.TestB6(),CableTypes.c1);
        // SearchAndPrintCable(ConnectorType.InB7,Add16_Gate.TestB7(),CableTypes.c1);
        // SearchAndPrintCable(ConnectorType.InB8,Add16_Gate.TestB8(),CableTypes.c1);
        // SearchAndPrintCable(ConnectorType.InB9,Add16_Gate.TestB9(),CableTypes.c1);
        // SearchAndPrintCable(ConnectorType.InB10,Add16_Gate.TestB10(),CableTypes.c1);
        // SearchAndPrintCable(ConnectorType.InB11,Add16_Gate.TestB11(),CableTypes.c1);
        // SearchAndPrintCable(ConnectorType.InB12,Add16_Gate.TestB12(),CableTypes.c1);
        // SearchAndPrintCable(ConnectorType.InB13,Add16_Gate.TestB13(),CableTypes.c1);
        // SearchAndPrintCable(ConnectorType.InB14,Add16_Gate.TestB14(),CableTypes.c1);
        // SearchAndPrintCable(ConnectorType.InB15,Add16_Gate.TestB15(),CableTypes.c1);
    }

    void Start()
    {
        if(Name == LogicGates_Type.Not)
        {
            Not_Gate_tests();
        }
        else if(Name == LogicGates_Type.And)
        {
            And_Gate_tests();
        }
        else if(Name == LogicGates_Type.Or)
        {
            Or_Gate_tests();
        }
        else if (Name == LogicGates_Type.Mux4Way16)
        {
            Mux4Way16_Gate_tests();
        }
        else if (Name == LogicGates_Type.Mux8Way16)
        {
            Mux8Way16_Gate_tests();
        }
        else if (Name == LogicGates_Type.Dmux4Way)
        {
            Dmux4Way_Gate_tests();
        }
        else if (Name == LogicGates_Type.HalfAdder)
        {

            HalfAdder_Gate_tests();
        }
        else if (Name == LogicGates_Type.FullAdder)
        {

            FullAdder_Gate_tests();
        }
        else if (Name == LogicGates_Type.Add16)
        {

            Add16_Gate_tests();
        }
        else 
        {

        }
        // Debug.Log(" ana mosa bafham fe alhaker");
        // foreach (var entry in cable16TruthTables)
        // {
        //     List<Cable16bitTruthTable> new11TruthTable=entry.cable.GetTruthTable();
        //     Debug.Log($"Input {entry.cable.Name}: ");
        //     for(int i=0;i<new11TruthTable.Count;i++)
        //     {
        //         Debug.Log("  "+i +" "+ string.Join(", ", new11TruthTable[i].truthTable));
        //     }
        // }

    }

    void Update()
    {
        
        if(isSolves16 && isAllCorrect16)
        {
            if (cableManagaerTruthTables.Count == 0)
            {
                return;
            }
        }
        if (isSolves && isAllCorrect)
        {
            if (cableManagaer16TruthTables.Count == 0 )
            {
               return; 
            }
        }
        if (isSolves16 && isSolves && isAllCorrect && isAllCorrect16)
        {
            return;
        }
        int count16=0;
        int count =0;
        for (int i=0; i<cableManagaer16TruthTables.Count ;i++)
        {
            if (cableManagaer16TruthTables[i] != null && cableManagaer16TruthTables[i].cableManager.getConnectedCable() != null )
            {
                var actualTruthTable = cableManagaer16TruthTables[i].cableManager.getConnectedCable().GetTruthTable();
                var cableManagerName= cableManagaer16TruthTables[i].cableManager.Name;
                if(Name == LogicGates_Type.Mux4Way16 )
                {
                    if(cableManagerName == ConnectorType.Out)
                    {
                        if (!CheckTruth16Table(actualTruthTable, Mux4Way16_Gate.TestOUT()))
                        {
                            isSolves16=false;
                            break;
                        }
                        count16++;
                        isSolves16=true;
                        // Debug.Log($"i find {cableManagerName}  cableTruthTables.");
                    }
                }
                else if (Name == LogicGates_Type.Mux8Way16)
                {
                    if(cableManagerName == ConnectorType.Out)
                    {
                        if (!CheckTruth16Table(actualTruthTable, Mux8Way16_Gate.TestOUT()))
                        {
                            isSolves16=false;
                            break;
                        }
                        count16++;
                        isSolves16=true;
                        // Debug.Log($"i find {cableManagerName}  cableTruthTables.");
                    }
                }
                else
                {
                    Debug.Log($"i dont find {Name}  work space.");
                } 
            }
        }

        for (int i=0; i<cableManagaerTruthTables.Count ;i++)
        {
            if (cableManagaerTruthTables[i] != null && cableManagaerTruthTables[i].cableManager.getConnectedCable() != null )
            {
                var actualTruthTable = cableManagaerTruthTables[i].cableManager.getConnectedCable().GetTruthTable();
                var cableManagerName= cableManagaerTruthTables[i].cableManager.Name;
                if (Name == LogicGates_Type.Dmux4Way)
                {
                    if(cableManagerName == ConnectorType.InA)
                    {
                        if (!CheckTruthTable(actualTruthTable, Dmux4Way_Gate.TestA()))
                        {
                            isSolves=false;
                            break;
                        }
                        count++;
                        isSolves=true;
                        // Debug.Log($"i find {cableManagerName}  cableTruthTables.");
                    }
                    else if(cableManagerName == ConnectorType.InB)
                    {
                        if (!CheckTruthTable(actualTruthTable, Dmux4Way_Gate.TestB()))
                        {
                            isSolves=false;
                            break;
                        }
                        count++;
                        isSolves=true;
                        // Debug.Log($"i find {cableManagerName}  cableTruthTables.");
                    }
                    else if(cableManagerName == ConnectorType.InC)
                    {
                        if (!CheckTruthTable(actualTruthTable, Dmux4Way_Gate.TestC()))
                        {
                            isSolves=false;
                            break;
                        }
                        count++;
                        isSolves=true;
                        // Debug.Log($"i find {cableManagerName}  cableTruthTables.");
                    }
                    else if(cableManagerName == ConnectorType.InD)
                    {
                        if (!CheckTruthTable(actualTruthTable, Dmux4Way_Gate.TestD()))
                        {
                            isSolves=false;
                            break;
                        }
                        count++;
                        isSolves=true;
                        // Debug.Log($"i find {cableManagerName}  cableTruthTables.");
                    }
                    else
                    {
                        Debug.Log($"i find {cableManagerName}  cableTruthTables.");
                    }
                }
                else if (Name == LogicGates_Type.HalfAdder)
                {
                    if(cableManagerName == ConnectorType.sum)
                    {
                        if (!CheckTruthTable(actualTruthTable, HalfAdder_Gate.TestSum()))
                        {
                            isSolves=false;
                            break;
                        }
                        count++;
                        isSolves=true;
                        // Debug.Log($"i find {cableManagerName}  cableTruthTables.");
                    }
                    else if(cableManagerName == ConnectorType.carry)
                    {
                        if (!CheckTruthTable(actualTruthTable, HalfAdder_Gate.TestCarry()))
                        {
                            isSolves=false;
                            break;
                        }
                        count++;
                        isSolves=true;
                        // Debug.Log($"i find {cableManagerName}  cableTruthTables.");
                    }
                    else
                    {
                        Debug.Log($"i do not find {cableManagerName}  cableTruthTables.");
                    }
                }
                else if (Name == LogicGates_Type.FullAdder)
                {
                    if(cableManagerName == ConnectorType.sum)
                    {
                        if (!CheckTruthTable(actualTruthTable, FullAdder_Gate.TestSum()))
                        {
                            isSolves=false;
                            break;
                        }
                        count++;
                        isSolves=true;
                        // Debug.Log($"i find {cableManagerName}  cableTruthTables.");
                    }
                    else if(cableManagerName == ConnectorType.carry)
                    {
                        if (!CheckTruthTable(actualTruthTable, FullAdder_Gate.TestCarry()))
                        {
                            isSolves=false;
                            break;
                        }
                        count++;
                        isSolves=true;
                        // Debug.Log($"i find {cableManagerName}  cableTruthTables.");
                    }
                    else
                    {
                        Debug.Log($"i find {cableManagerName}  cableTruthTables.");
                    }
                }
                else if (Name == LogicGates_Type.Add16)
                {
                    if(cableManagerName == ConnectorType.Out)
                    {
                        if (!CheckTruthTable(actualTruthTable, Add16_Gate.TestOUT()))
                        {
                            isSolves=false;
                            break;
                        }
                        count++;
                        isSolves=true;
                        // Debug.Log($"i find {cableManagerName}  cableTruthTables.");
                    }
                    // else if(cableManagerName == ConnectorType.Out1)
                    // {
                    //     if (!CheckTruthTable(actualTruthTable, Add16_Gate.TestOUT1()))
                    //     {
                    //         isSolves=false;
                    //         break;
                    //     }
                    //     count++;
                    //     isSolves=true;
                    //     // Debug.Log($"i find {cableManagerName}  cableTruthTables.");
                    // }
                    // if(cableManagerName == ConnectorType.Out2)
                    // {
                    //     if (!CheckTruthTable(actualTruthTable, Add16_Gate.TestOUT2()))
                    //     {
                    //         isSolves=false;
                    //         break;
                    //     }
                    //     count++;
                    //     isSolves=true;
                    //     // Debug.Log($"i find {cableManagerName}  cableTruthTables.");
                    // }
                    // else if(cableManagerName == ConnectorType.Out3)
                    // {
                    //     if (!CheckTruthTable(actualTruthTable, Add16_Gate.TestOUT3()))
                    //     {
                    //         isSolves=false;
                    //         break;
                    //     }
                    //     count++;
                    //     isSolves=true;
                    //     isSolves=true;
                    //     // Debug.Log($"i find {cableManagerName}  cableTruthTables.");
                    // }
                    // if(cableManagerName == ConnectorType.Out4)
                    // {
                    //     if (!CheckTruthTable(actualTruthTable, Add16_Gate.TestOUT4()))
                    //     {
                    //         isSolves=false;
                    //         break;
                    //     }
                    //     count++;
                    //     isSolves=true;
                    //     // Debug.Log($"i find {cableManagerName}  cableTruthTables.");
                    // }
                    // else if(cableManagerName == ConnectorType.Out5)
                    // {
                    //     if (!CheckTruthTable(actualTruthTable, Add16_Gate.TestOUT5()))
                    //     {
                    //         isSolves=false;
                    //         break;
                    //     }
                    //     count++;
                    //     isSolves=true;
                    //     isSolves=true;
                    //     // Debug.Log($"i find {cableManagerName}  cableTruthTables.");
                    // }
                    // if(cableManagerName == ConnectorType.Out6)
                    // {
                    //     if (!CheckTruthTable(actualTruthTable, Add16_Gate.TestOUT6()))
                    //     {
                    //         isSolves=false;
                    //         break;
                    //     }
                    //     count++;
                    //     isSolves=true;
                    //     // Debug.Log($"i find {cableManagerName}  cableTruthTables.");
                    // }
                    // else if(cableManagerName == ConnectorType.Out7)
                    // {
                    //     if (!CheckTruthTable(actualTruthTable, Add16_Gate.TestOUT7()))
                    //     {
                    //         isSolves=false;
                    //         break;
                    //     }
                    //     count++;
                    //     isSolves=true;
                    //     isSolves=true;
                    //     // Debug.Log($"i find {cableManagerName}  cableTruthTables.");
                    // }
                    // if(cableManagerName == ConnectorType.Out8)
                    // {
                    //     if (!CheckTruthTable(actualTruthTable, Add16_Gate.TestOUT8()))
                    //     {
                    //         isSolves=false;
                    //         break;
                    //     }
                    //     count++;
                    //     isSolves=true;
                    //     // Debug.Log($"i find {cableManagerName}  cableTruthTables.");
                    // }
                    // else if(cableManagerName == ConnectorType.Out9)
                    // {
                    //     if (!CheckTruthTable(actualTruthTable, Add16_Gate.TestOUT9()))
                    //     {
                    //         isSolves=false;
                    //         break;
                    //     }
                    //     count++;
                    //     isSolves=true;
                    //     isSolves=true;
                    //     // Debug.Log($"i find {cableManagerName}  cableTruthTables.");
                    // }
                    // if(cableManagerName == ConnectorType.Out10)
                    // {
                    //     if (!CheckTruthTable(actualTruthTable, Add16_Gate.TestOUT10()))
                    //     {
                    //         isSolves=false;
                    //         break;
                    //     }
                    //     count++;
                    //     isSolves=true;
                    //     // Debug.Log($"i find {cableManagerName}  cableTruthTables.");
                    // }
                    // else if(cableManagerName == ConnectorType.Out11)
                    // {
                    //     if (!CheckTruthTable(actualTruthTable, Add16_Gate.TestOUT11()))
                    //     {
                    //         isSolves=false;
                    //         break;
                    //     }
                    //     count++;
                    //     isSolves=true;
                    //     isSolves=true;
                    //     // Debug.Log($"i find {cableManagerName}  cableTruthTables.");
                    // }
                    // else if(cableManagerName == ConnectorType.Out12)
                    // {
                    //     if (!CheckTruthTable(actualTruthTable, Add16_Gate.TestOUT12()))
                    //     {
                    //         isSolves=false;
                    //         break;
                    //     }
                    //     count++;
                    //     isSolves=true;
                    //     isSolves=true;
                    //     // Debug.Log($"i find {cableManagerName}  cableTruthTables.");
                    // }
                    // else if(cableManagerName == ConnectorType.Out13)
                    // {
                    //     if (!CheckTruthTable(actualTruthTable, Add16_Gate.TestOUT13()))
                    //     {
                    //         isSolves=false;
                    //         break;
                    //     }
                    //     count++;
                    //     isSolves=true;
                    //     isSolves=true;
                    //     // Debug.Log($"i find {cableManagerName}  cableTruthTables.");
                    // }
                    // else if(cableManagerName == ConnectorType.Out14)
                    // {
                    //     if (!CheckTruthTable(actualTruthTable, Add16_Gate.TestOUT14()))
                    //     {
                    //         isSolves=false;
                    //         break;
                    //     }
                    //     count++;
                    //     isSolves=true;
                    //     isSolves=true;
                    //     // Debug.Log($"i find {cableManagerName}  cableTruthTables.");
                    // }
                    // else if(cableManagerName == ConnectorType.Out15)
                    // {
                    //     if (!CheckTruthTable(actualTruthTable, Add16_Gate.TestOUT15()))
                    //     {
                    //         isSolves=false;
                    //         break;
                    //     }
                    //     count++;
                    //     isSolves=true;
                    //     isSolves=true;
                    //     // Debug.Log($"i find {cableManagerName}  cableTruthTables.");
                    // }
                    else
                    {
                        Debug.Log($"i do not find {cableManagerName}  cableTruthTables.");
                    }
                }
                else if (Name == LogicGates_Type.Inc16)
                {
                    if(cableManagerName == ConnectorType.Out)
                    {
                        if (!CheckTruthTable(actualTruthTable, Inc16_Gate.TestOUT()))
                        {
                            isSolves=false;
                            break;
                        }
                        count++;
                        isSolves=true;
                        // Debug.Log($"i find {cableManagerName}  cableTruthTables.");
                    }
                    // else if(cableManagerName == ConnectorType.Out1)
                    // {
                    //     if (!CheckTruthTable(actualTruthTable, Inc16_Gate.TestOUT1()))
                    //     {
                    //         isSolves=false;
                    //         break;
                    //     }
                    //     count++;
                    //     isSolves=true;
                    //     // Debug.Log($"i find {cableManagerName}  cableTruthTables.");
                    // }
                    // if(cableManagerName == ConnectorType.Out2)
                    // {
                    //     if (!CheckTruthTable(actualTruthTable, Inc16_Gate.TestOUT2()))
                    //     {
                    //         isSolves=false;
                    //         break;
                    //     }
                    //     count++;
                    //     isSolves=true;
                    //     // Debug.Log($"i find {cableManagerName}  cableTruthTables.");
                    // }
                    // else if(cableManagerName == ConnectorType.Out3)
                    // {
                    //     if (!CheckTruthTable(actualTruthTable, Inc16_Gate.TestOUT3()))
                    //     {
                    //         isSolves=false;
                    //         break;
                    //     }
                    //     count++;
                    //     isSolves=true;
                    //     isSolves=true;
                    //     // Debug.Log($"i find {cableManagerName}  cableTruthTables.");
                    // }
                    // if(cableManagerName == ConnectorType.Out4)
                    // {
                    //     if (!CheckTruthTable(actualTruthTable, Inc16_Gate.TestOUT4()))
                    //     {
                    //         isSolves=false;
                    //         break;
                    //     }
                    //     count++;
                    //     isSolves=true;
                    //     // Debug.Log($"i find {cableManagerName}  cableTruthTables.");
                    // }
                    // else if(cableManagerName == ConnectorType.Out5)
                    // {
                    //     if (!CheckTruthTable(actualTruthTable, Inc16_Gate.TestOUT5()))
                    //     {
                    //         isSolves=false;
                    //         break;
                    //     }
                    //     count++;
                    //     isSolves=true;
                    //     isSolves=true;
                    //     // Debug.Log($"i find {cableManagerName}  cableTruthTables.");
                    // }
                    // if(cableManagerName == ConnectorType.Out6)
                    // {
                    //     if (!CheckTruthTable(actualTruthTable, Inc16_Gate.TestOUT6()))
                    //     {
                    //         isSolves=false;
                    //         break;
                    //     }
                    //     count++;
                    //     isSolves=true;
                    //     // Debug.Log($"i find {cableManagerName}  cableTruthTables.");
                    // }
                    // else if(cableManagerName == ConnectorType.Out7)
                    // {
                    //     if (!CheckTruthTable(actualTruthTable, Inc16_Gate.TestOUT7()))
                    //     {
                    //         isSolves=false;
                    //         break;
                    //     }
                    //     count++;
                    //     isSolves=true;
                    //     isSolves=true;
                    //     // Debug.Log($"i find {cableManagerName}  cableTruthTables.");
                    // }
                    // if(cableManagerName == ConnectorType.Out8)
                    // {
                    //     if (!CheckTruthTable(actualTruthTable, Inc16_Gate.TestOUT8()))
                    //     {
                    //         isSolves=false;
                    //         break;
                    //     }
                    //     count++;
                    //     isSolves=true;
                    //     // Debug.Log($"i find {cableManagerName}  cableTruthTables.");
                    // }
                    // else if(cableManagerName == ConnectorType.Out9)
                    // {
                    //     if (!CheckTruthTable(actualTruthTable, Inc16_Gate.TestOUT9()))
                    //     {
                    //         isSolves=false;
                    //         break;
                    //     }
                    //     count++;
                    //     isSolves=true;
                    //     isSolves=true;
                    //     // Debug.Log($"i find {cableManagerName}  cableTruthTables.");
                    // }
                    // if(cableManagerName == ConnectorType.Out10)
                    // {
                    //     if (!CheckTruthTable(actualTruthTable, Inc16_Gate.TestOUT10()))
                    //     {
                    //         isSolves=false;
                    //         break;
                    //     }
                    //     count++;
                    //     isSolves=true;
                    //     // Debug.Log($"i find {cableManagerName}  cableTruthTables.");
                    // }
                    // else if(cableManagerName == ConnectorType.Out11)
                    // {
                    //     if (!CheckTruthTable(actualTruthTable, Inc16_Gate.TestOUT11()))
                    //     {
                    //         isSolves=false;
                    //         break;
                    //     }
                    //     count++;
                    //     isSolves=true;
                    //     isSolves=true;
                    //     // Debug.Log($"i find {cableManagerName}  cableTruthTables.");
                    // }
                    // else if(cableManagerName == ConnectorType.Out12)
                    // {
                    //     if (!CheckTruthTable(actualTruthTable, Inc16_Gate.TestOUT12()))
                    //     {
                    //         isSolves=false;
                    //         break;
                    //     }
                    //     count++;
                    //     isSolves=true;
                    //     isSolves=true;
                    //     // Debug.Log($"i find {cableManagerName}  cableTruthTables.");
                    // }
                    // else if(cableManagerName == ConnectorType.Out13)
                    // {
                    //     if (!CheckTruthTable(actualTruthTable, Inc16_Gate.TestOUT13()))
                    //     {
                    //         isSolves=false;
                    //         break;
                    //     }
                    //     count++;
                    //     isSolves=true;
                    //     isSolves=true;
                    //     // Debug.Log($"i find {cableManagerName}  cableTruthTables.");
                    // }
                    // else if(cableManagerName == ConnectorType.Out14)
                    // {
                    //     if (!CheckTruthTable(actualTruthTable, Inc16_Gate.TestOUT14()))
                    //     {
                    //         isSolves=false;
                    //         break;
                    //     }
                    //     count++;
                    //     isSolves=true;
                    //     isSolves=true;
                    //     // Debug.Log($"i find {cableManagerName}  cableTruthTables.");
                    // }
                    // else if(cableManagerName == ConnectorType.Out15)
                    // {
                    //     if (!CheckTruthTable(actualTruthTable, Inc16_Gate.TestOUT15()))
                    //     {
                    //         isSolves=false;
                    //         break;
                    //     }
                    //     count++;
                    //     isSolves=true;
                    //     isSolves=true;
                    //     // Debug.Log($"i find {cableManagerName}  cableTruthTables.");
                    // }
                    else
                    {
                        Debug.Log($"i do not find {cableManagerName}  cableTruthTables.");
                    }
                }
                else if (Name == LogicGates_Type.Not)
                {
                    if(cableManagerName == ConnectorType.Out)
                    {
                        if (!CheckTruthTable(actualTruthTable, Not_Gate.TestOut()[0].truthTable))
                        {
                            isSolves=false;
                            break;
                        }
                        count++;
                        isSolves=true;
                        // Debug.Log($"i find {cableManagerName}  cableTruthTables.");
                    }
                    else
                    {
                        Debug.Log($"i do not find {cableManagerName}  cableTruthTables.");
                    }
                }
                else if (Name == LogicGates_Type.And)
                {
                    if(cableManagerName == ConnectorType.Out)
                    {
                        if (!CheckTruthTable(actualTruthTable, AND_Gate.TestOut()[0].truthTable))
                        {
                            isSolves=false;
                            break;
                        }
                        count++;
                        isSolves=true;
                        // Debug.Log($"i find {cableManagerName}  cableTruthTables.");
                    }
                    else
                    {
                        Debug.Log($"i do not find {cableManagerName}  cableTruthTables.");
                    }
                }
                else if (Name == LogicGates_Type.Or)
                {
                    if(cableManagerName == ConnectorType.Out)
                    {
                        if (!CheckTruthTable(actualTruthTable, OR_Gate.TestOut()[0].truthTable))
                        {
                            isSolves=false;
                            break;
                        }
                        count++;
                        isSolves=true;
                        // Debug.Log($"i find {cableManagerName}  cableTruthTables.");
                    }
                    else
                    {
                        Debug.Log($"i do not find {cableManagerName}  cableTruthTables.");
                    }
                }
                else
                {
                    Debug.Log($"i dont find {Name}  work space.");
                } 
            }
        }


        if(isSolves16 && count16 == cableManagaer16TruthTables.Count)
        {
            isAllCorrect16=true;
            if (cableManagaerTruthTables.Count == 0)
            {
                door.OpenDoor();
            }
        }
        if (isSolves && count == cableManagaerTruthTables.Count)
        {
            isAllCorrect=true;
            if (cableManagaer16TruthTables.Count == 0 )
            {
               door.OpenDoor(); 
            }
        }
        if (isSolves16 && isSolves && isAllCorrect && isAllCorrect16)
        {
            door.OpenDoor();
        }

    }

    private bool CheckTruth16Table(List<Cable16bitTruthTable> truthTable,List<Cable16bitTruthTable> actualTruthTable)
    {
        if(truthTable.Count == actualTruthTable.Count)
        {   
            for(int i=0;i<actualTruthTable.Count;i++)
            {
                for (int j=0;j< actualTruthTable[i].truthTable.Count ;j++)
                {
                    if(actualTruthTable[i].truthTable[j] != truthTable[i].truthTable[j])
                    {
                        return false;
                    }  
                }
            }
            return true;  
        }
        return false;
    }
    private bool CheckTruthTable(List<bool> truthTable,List<bool> actualTruthTable)
    {
        if(truthTable.Count == actualTruthTable.Count)
        {
            for(int i=0;i<actualTruthTable.Count;i++)
            {
                if(actualTruthTable[i] != truthTable[i])
                {
                    return false;
                }  
            }
            return true;  
        }
        return false;
    }


    void SearchAndPrintCable(ConnectorType Name,List<Cable16bitTruthTable> truthTable,CableTypes type)
    {
        // Debug.Log($"i find  cableTruthTables. {truthTable[0].truthTable}");
        if (type == CableTypes.c1)
        {
            for (int i=0; i<cableTruthTables.Count ;i++)
            {
                if (cableTruthTables[i].cables != null)
                {
                    if (Name == cableTruthTables[i].cables.Name)
                    {
                        // Debug.Log("Input A notGate: " + string.Join(", ", truthTable[0].truthTable));
                        // Debug.Log($"i find {cableTruthTables[i].cable}  cableTruthTables. {truthTable[0].truthTable}");
                        // cableTruthTables[i].cable.SetTruthTable(truthTable[0].truthTable); 
                        cableTruthTables[i].cables.SetTruthTable(truthTable[0].truthTable);
                        // Debug.Log($"i find {Name}  cableTruthTables.");
                        break;
                    }        
                }
            }

        }
        
        else if (type == CableTypes.c16)
        {
            for (int i=0; i<cable16TruthTables.Count ;i++)
            {
                if (cable16TruthTables[i].cable != null)
                {
                    if (Name == cable16TruthTables[i].cable.Name)
                    {
                        // cable16TruthTables[i].cable.SetTruthTable(truthTable); 
                        break;
                    }
                }
            }
        }
        else
        {
            //it is for ather cables for future
        }
    }



}
