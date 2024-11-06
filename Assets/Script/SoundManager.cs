using UnityEngine;

public class SoundManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public static SoundManager Instace {get; set;}
    public AudioSource shootingSoundpistol1;
    public AudioSource reloadingSoundpistol1;
    public AudioSource emptyMagazineSoundpistol1;

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
