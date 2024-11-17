using System;
using System.Xml.Serialization;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int bulletDamage;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnCollisionEnter(Collision objectWeHit)
    {
        if(objectWeHit.gameObject.CompareTag("Target"))
        {
            print("hit " + objectWeHit.gameObject.name + "!" );
            CreateBulletImpactEffect(objectWeHit);
            Destroy(gameObject);
        }
        if(objectWeHit.gameObject.CompareTag("Wall"))
        {
            print("hit a Wall" );
            CreateBulletImpactEffect(objectWeHit);
            Destroy(gameObject);
        }
        if(objectWeHit.gameObject.CompareTag("Beer"))
        {
            print("hit a Beer bottle" );
            objectWeHit.gameObject.GetComponent<BeerBottle>().Shatter();
            // we will not destroy the bullet on impact , it will get destroyed according to its lifetime
        }
        if(objectWeHit.gameObject.CompareTag("Enemy"))
        {
            print("hit a Zombie" );
            if(objectWeHit.gameObject.GetComponent<Enemy>().isDead == false)
            {
                objectWeHit.gameObject.GetComponent<Enemy>().TakeDamage(bulletDamage);
            }
            CreatBloodSprayEffect(objectWeHit);
            Destroy(gameObject);
          
        }
    }

    private void CreatBloodSprayEffect(Collision objectWeHit)
    {
        ContactPoint contact=objectWeHit.contacts[0];
        GameObject bloodSprayPrefab = Instantiate(
            GlobalRefrencse.Instace.bloodSprayEffect,
            contact.point,
            Quaternion.LookRotation(contact.normal)
        );
        bloodSprayPrefab.transform.SetParent(objectWeHit.gameObject.transform);
    }

    private void CreateBulletImpactEffect(Collision objectWeHit)
    {
        ContactPoint contact=objectWeHit.contacts[0];
        GameObject hole = Instantiate(
            GlobalRefrencse.Instace.bulletImpactEffectPrefab,
            contact.point,
            Quaternion.LookRotation(contact.normal)
        );
        hole.transform.SetParent(objectWeHit.gameObject.transform);
    }
}
