using System;
using System.Collections;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public bool isActiveWeapon;
    public int WeaponDamage;
    //shooting
    [Header("shooting")]
    public bool isShooting,readyToShoot;
    bool allowReset =true;
    public float shootingDelay = 2f;
    // Brust
    [Header("Brust")]
    public int bulletsPerBurst = 3;
    public int burstBullerLeft;
    //Spread
    [Header("Spread")]
    public float spreadIntensity;
    public float hibspreadIntensity;
    public float adspreadIntensity;
    // Bullet
    [Header("Bullet")]
    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public float bulletPrefabLifeTime = 3f;
    public float bulletVelocity =30;
    public GameObject muzzleEffect;
    internal Animator animator;

    //loading
    [Header("loading")]
    public float reloadTime;
    public int magazineSize, bulletsLeft;
    public bool isReloading;
    
    public Vector3 spawnPosition;
    public Vector3 spawnRotation;
    
    bool isADS;

    public enum WeaponModel
    {
        Pistol,
        AK,
    }
    public WeaponModel thisWeaponModle;

    public enum ShootingMode
    {
        Single,
        Burst,
        Auto,
    }
    public ShootingMode currentShootingMode;
    private void Awake()
    {
        readyToShoot =true;
        burstBullerLeft=bulletsPerBurst;
        animator = GetComponent<Animator>();

        bulletsLeft =magazineSize;
        spreadIntensity =hibspreadIntensity;
    }

    // Update is called once per frame
    void Update()
    {
        if(isActiveWeapon)
        {
            foreach (Transform child in transform)
            {
                child.gameObject.layer =LayerMask.NameToLayer("WeaponRender");
            }

            if(Input.GetMouseButtonDown(1))
            {
                EnterADS();
            }
            if(Input.GetMouseButtonUp(1))
            {
                ExitADS();
            }
            
            GetComponent<Outline>().enabled = false;
            
            if(bulletsLeft == 0 && isShooting)
            {
                SoundManager.Instace.emptyMagazineSoundpistol1.Play();
            }

            if(currentShootingMode == ShootingMode.Auto)
            {
                isShooting=Input.GetKey(KeyCode.Mouse0);
            }
            else if(currentShootingMode == ShootingMode.Single ||
                currentShootingMode == ShootingMode.Burst)
            {
                isShooting=Input.GetKeyDown(KeyCode.Mouse0);
            }
            if(Input.GetKeyDown(KeyCode.R) && bulletsLeft <magazineSize && !isReloading && WeaponManager.Instace.CheckAmmoLeftFor(thisWeaponModle) > 0 )
            {
                Reload();
            }

            if (readyToShoot && !isShooting && !isReloading && bulletsLeft <=0)
            {
                // Reload();
            }

            if (readyToShoot && isShooting && bulletsLeft > 0)
            {
                burstBullerLeft=bulletsPerBurst;
                FireWeapon();
            }
            
        }
        else
        {
            foreach (Transform child in transform)
            {
                child.gameObject.layer =LayerMask.NameToLayer("Default");
            }
        }
        
    }

    private void EnterADS()
    {
        animator.SetTrigger("enterADS");
        spreadIntensity =adspreadIntensity;
        HUDManager.Instace.middlDot.SetActive(false);
        isADS=true;
    }
    private void ExitADS()
    {
        animator.SetTrigger("exitADS");
        spreadIntensity =hibspreadIntensity;
        HUDManager.Instace.middlDot.SetActive(true);
        isADS=false;
    }

    private void FireWeapon()
    {
        bulletsLeft--;
        muzzleEffect.GetComponent<ParticleSystem>().Play();
        if(isADS)
        {
            animator.SetTrigger("RECOIL_ADS");
        }
        else
        {
            animator.SetTrigger("RECOIL");
        }

        SoundManager.Instace.PlayShootingSound(thisWeaponModle);

        readyToShoot =false;
        Vector3 shootingDirection =CalculateDirectionAndSpread().normalized;
        // Instantiate the bullet
        GameObject bullet =Instantiate(bulletPrefab,bulletSpawn.position,Quaternion.identity);
        Bullet bul = bullet.GetComponent<Bullet>();
        bul.bulletDamage = WeaponDamage;
        // Point the bullet to face the shooting direction
        bullet.transform.forward =shootingDirection;
        //Shooting the bullet
        bullet.GetComponent<Rigidbody>().AddForce(shootingDirection *bulletVelocity,ForceMode.Impulse);
        //Destroy the bullet after some time
        StartCoroutine(DestroyBulletAfterTime(bullet, bulletPrefabLifeTime));
        //checking if we are done shooting
        if( allowReset)
        {
            Invoke("ReserShot",shootingDelay);
            allowReset =false;
        }
        // we aleady shoot once befor this chech
        if (currentShootingMode == ShootingMode.Burst && burstBullerLeft > 1)
        {
            burstBullerLeft--;
            Invoke("FireWeapon",shootingDelay);
        }
    }

    private void Reload()
    {
        if(WeaponManager.Instace.CheckAmmoLeftFor(thisWeaponModle) > magazineSize)
        {
            bulletsLeft = magazineSize;
            WeaponManager.Instace.DecreaseTotalAmmo(bulletsLeft,thisWeaponModle);
        }
        else
        {
            bulletsLeft = WeaponManager.Instace.CheckAmmoLeftFor(thisWeaponModle);
            WeaponManager.Instace.DecreaseTotalAmmo(bulletsLeft,thisWeaponModle);
        }
        SoundManager.Instace.PlayReloadSound(thisWeaponModle);
        animator.SetTrigger("RELOAD");
        isReloading =true;
        Invoke("ReloadCompleted",reloadTime);
    }

    private void ReloadCompleted()
    {
        bulletsLeft =magazineSize;
        isReloading=false;
    }

    private void ReserShot()
    {
        readyToShoot =true;
        allowReset =true;
    }

    private Vector3 CalculateDirectionAndSpread()
    {
        //Shooting from the middle of the screen to check where are we pointing at
        Ray ray=Camera.main.ViewportPointToRay(new Vector3(0.5f,0.5f,0));
        RaycastHit hit;

        Vector3 targetPoint;
        if(Physics.Raycast(ray,out hit))
        {
            //Hitting something
            targetPoint = hit.point;
        }
        else
        {
            //Shooting at the air
            targetPoint = ray.GetPoint(100);
        }

        Vector3 direction = targetPoint -bulletSpawn.position;

        float z=UnityEngine.Random.Range(-spreadIntensity,spreadIntensity);
        float y=UnityEngine.Random.Range(-spreadIntensity,spreadIntensity);
        // Returning the shooting direction and spread
        return direction +new Vector3(0,y,z);
    }

    private IEnumerator DestroyBulletAfterTime(GameObject bullet,float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(bullet);
    }
    
}
