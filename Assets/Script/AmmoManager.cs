using TMPro;
using UnityEngine;

public class AmmoManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public static AmmoManager Instace {get; set;}
    public TextMeshProUGUI ammoDisplay;

    private void Awake()
    {
        if(Instace != null && Instace !=this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instace=this;
        }
    }
}
