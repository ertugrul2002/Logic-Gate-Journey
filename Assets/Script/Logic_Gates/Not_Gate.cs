using UnityEngine;

public class Not_Gate  : MonoBehaviour
{
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
   
}
