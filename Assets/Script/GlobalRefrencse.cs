using UnityEngine;

public class GlobalRefrencse :MonoBehaviour
{
    public static GlobalRefrencse Instace {get; set;}
    public GameObject bulletImpactEffectPrefab;
    public GameObject grenadeExplosionEffect;
    public GameObject smokeGrenadeEffect;

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
