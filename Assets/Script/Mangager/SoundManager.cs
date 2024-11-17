using UnityEngine;

public class SoundManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public AudioSource emptyMagazineSoundpistol1;
    public static SoundManager Instace {get; set;}
    public AudioSource shootingChannel; 

    public AudioClip AKShot;
    public AudioClip pistolShot;

    public AudioSource reloadingSoundpistol1;

    public AudioSource reloadingSoundAK;

    public AudioSource throwablesChannel;
    public AudioClip grenadeSound;
    public AudioClip zombieWalking;
    public AudioClip zombieChase;
    public AudioClip zombieAttack;
    public AudioClip zombieHurt;
    public AudioClip zombieDeath;
    public AudioSource zombieChannel1;
    public AudioSource zombieChannel2;
    public AudioSource playerChannel;
    public AudioClip playerHurt;
    public AudioClip playerDie;
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
    public void PlayShootingSound(Weapon.WeaponModel weapon)
    {
        switch(weapon)
        {
            case Weapon.WeaponModel.Pistol:
                shootingChannel.PlayOneShot(pistolShot);
                break;
            case Weapon.WeaponModel.AK:
                shootingChannel.PlayOneShot(AKShot);
                break;
            

        }
    }
    public void PlayReloadSound(Weapon.WeaponModel weapon)
    {
        switch(weapon)
        {
            case Weapon.WeaponModel.Pistol:
                reloadingSoundpistol1.Play();
                break;
            case Weapon.WeaponModel.AK:
                reloadingSoundAK.Play();
                break;
            

        }
    }


}
