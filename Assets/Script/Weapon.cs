using System;
using System.Collections;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Camera playerCamera;
    //shooting
    public bool isShooting,readyToShoot;
    bool allowReset =true;
    public float shootingDelay = 2f;
    // Brust
    public int bulletsPerBurst = 3;
    public int burstBullerLeft;
    //Spread
    public float speadIntensity;
    // Bullet
    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public float bulletPrefabLifeTime = 3f;
    public float bulletVelocity =30;

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
    }

    // Update is called once per frame
    void Update()
    {
        if(currentShootingMode == ShootingMode.Auto)
        {
            isShooting=Input.GetKey(KeyCode.Mouse0);
        }
        else if(currentShootingMode == ShootingMode.Single ||
            currentShootingMode == ShootingMode.Burst)
        {
            isShooting=Input.GetKeyDown(KeyCode.Mouse0);
        }
        if (readyToShoot && isShooting)
        {
            burstBullerLeft=bulletsPerBurst;
            FireWeapon();
        }
        
        
    }

    private void FireWeapon()
    {
        readyToShoot =false;
        Vector3 shootingDirection =CalculateDirectionAndSpread().normalized;
        // Instantiate the bullet
        GameObject bullet =Instantiate(bulletPrefab,bulletSpawn.position,Quaternion.identity);
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

    private void ReserShot()
    {
        readyToShoot =true;
        allowReset =true;
    }

    private Vector3 CalculateDirectionAndSpread()
    {
        //Shooting from the middle of the screen to check where are we pointing at
        Ray ray=playerCamera.ViewportPointToRay(new Vector3(0.5f,0.5f,0));
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

        float x=UnityEngine.Random.Range(-speadIntensity,speadIntensity);
        float y=UnityEngine.Random.Range(-speadIntensity,speadIntensity);
        // Returning the shooting direction and spread
        return direction +new Vector3(x,y,0);
    }

    private IEnumerator DestroyBulletAfterTime(GameObject bullet,float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(bullet);
    }
    
}
