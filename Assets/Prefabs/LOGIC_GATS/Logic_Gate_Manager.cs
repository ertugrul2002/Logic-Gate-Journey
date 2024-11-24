using UnityEngine;

public class Logic_Gate_Manager : MonoBehaviour
{
    public Nand_Gate[] nandGates;
    public Not_Gate[] notGates;
    private void Start()
    {
        for (int i = 0; i < nandGates.Length; i++)
        {
            nandGates[i].SetID(i + 1); 
        }
        for (int i = 0; i < notGates.Length; i++)
        {
            notGates[i].SetID(i + 1); 
        }
        
    }
}
