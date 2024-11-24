using UnityEngine;

public class Nand_Gate  : MonoBehaviour
{
   public int ID_Gate { get; private set; } 

    public void SetID(int id)
    {
        ID_Gate = id;
    }
    [SerializeField] private CableManager inputA; 
    [SerializeField] private CableManager inputB; 
    public Cable Out;
    public Cable getCable()
    {
        return Out;
    }

   
}
