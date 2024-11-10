using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Throwable : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] float delay = 3f;
    [SerializeField] float damageRadius = 20f;
    [SerializeField] float exploisonForce = 1200f;
    float countdown;
    bool hasExploded = false;
    public bool hasBeenThrown = false;
    public enum ThrowableType
    {
        None,
        Grenade,
        Smoke_Grenade,
    }
    public ThrowableType throwableType;

    private void Start()
    {
        countdown =delay;
    }

    private void Update()
    {
        if(hasBeenThrown)
        {
            countdown-= Time.deltaTime;
            if(countdown <= 0f && !hasExploded)
            {
                Exploade();
                hasExploded = true;
            }
        }
    }

    private void Exploade()
    {
        GetThrowableEffect();
        Destroy(gameObject);
    }

    private void GetThrowableEffect()
    {
        switch (throwableType)
        {
            case ThrowableType.Grenade:
                GrenadeEffect();
                break;
            case ThrowableType.Smoke_Grenade:
                SmokeGrenadeEffect();
                break;
        }
    }

    private void SmokeGrenadeEffect()
    {
        // Visual Effect
        GameObject smokeEffect = GlobalRefrencse.Instace.smokeGrenadeEffect;
        Instantiate(smokeEffect,transform.position,transform.rotation);
        // Play Sound
        SoundManager.Instace.throwablesChannel.PlayOneShot(SoundManager.Instace.grenadeSound);
        // Physical Effect
        Collider [] colliders =Physics.OverlapSphere(transform.position,damageRadius);
        foreach (Collider objectInRange in colliders)
        {
            Rigidbody rb = objectInRange.GetComponent<Rigidbody>();
            if (rb != null)
            {
                 //Apply blindess to enemies
            }
           
        }
    }

    private void GrenadeEffect()
    {
        // Visual Effect
        GameObject explosionEffect = GlobalRefrencse.Instace.grenadeExplosionEffect;
        Instantiate(explosionEffect,transform.position,transform.rotation);
        // Play Sound
        SoundManager.Instace.throwablesChannel.PlayOneShot(SoundManager.Instace.grenadeSound);
        // Physical Effect
        Collider [] colliders =Physics.OverlapSphere(transform.position,damageRadius);
        foreach (Collider objectInRange in colliders)
        {
            Rigidbody rb = objectInRange.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(exploisonForce ,transform.position ,damageRadius);
            }
            //Also apply damage to enemy over here
        }
    }
}

