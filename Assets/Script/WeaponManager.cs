using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public static WeaponManager Instace {get; set;}
    public List<GameObject> weaponSlots;
    public GameObject activeWeaponSlote;
    [Header("Ammo")]
    public int totalRifleAmmo = 0;
    public int totalPistolAmmo = 0;
    [Header("Throwable General")]
    public float throwForce =10f;
    public GameObject throwableSpawn;
    public float forceMuliplier=0;
    public float forceMuliplierLimit=2f;
    [Header("Lethals")]
    public int maxLethals=2;
    public int lethalsCount =0;
    public Throwable.ThrowableType eqippedLethalType;
    public GameObject grenadePrefab;
    [Header("Tacticals")]
    public int maxTacticals=2;
    public int tacticalsCount =0;
    public Throwable.ThrowableType eqippedTacticalsType;
    public GameObject smokeGrenadePrefab;
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

    private void Start()
    {
        activeWeaponSlote = weaponSlots[0];
        eqippedLethalType = Throwable.ThrowableType.None;
        eqippedTacticalsType = Throwable.ThrowableType.None;
    }

    private void Update()
    {
        foreach (GameObject weaponSlot in weaponSlots)
        {
            if(weaponSlot == activeWeaponSlote)
            {
                weaponSlot.SetActive(true);
            }
            else
            {
                 weaponSlot.SetActive(false);
            }
        }
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            switchAchtiveSlot(0);
        }
        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            switchAchtiveSlot(1);
        }
        if(Input.GetKey(KeyCode.G) || Input.GetKey(KeyCode.T))
        {
            forceMuliplier +=Time.deltaTime;
            if(forceMuliplier > forceMuliplierLimit)
            {
                forceMuliplier = forceMuliplierLimit;
            }
        }
        if(Input.GetKeyUp(KeyCode.G))
        {
            forceMuliplier +=Time.deltaTime;
            if(lethalsCount > 0)
            {
                ThrowLethal();
            }
            forceMuliplier = 0;
        }
        
        if(Input.GetKeyUp(KeyCode.T))
        {
            forceMuliplier +=Time.deltaTime;
            if(tacticalsCount > 0)
            {
                ThrowTactical();
            }
            forceMuliplier = 0;
        }
    }

    

    public void PickupWeapon(GameObject pickedupWeapon)
    {
        AddWeaponIntoActiveSlot(pickedupWeapon);
    }

    private void AddWeaponIntoActiveSlot(GameObject pickedupWeapon)
    {
        DropCurrentWeapon(pickedupWeapon);
        pickedupWeapon.transform.SetParent(activeWeaponSlote.transform,false);
        Weapon weapon =pickedupWeapon.GetComponent<Weapon>();
        pickedupWeapon.transform.localPosition =new Vector3(weapon.spawnPosition.x,weapon.spawnPosition.y,weapon.spawnPosition.z);
        pickedupWeapon.transform.localRotation =Quaternion.Euler(weapon.spawnRotation.x,weapon.spawnRotation.y,weapon.spawnRotation.z);
        weapon.isActiveWeapon=true;
        weapon.animator.enabled = true;
    }

    private void DropCurrentWeapon(GameObject pickedupWeapon)
    {
        if(activeWeaponSlote.transform.childCount > 0)
        {
            var weaponToDrop =activeWeaponSlote.transform.GetChild(0).gameObject;
            weaponToDrop.GetComponent<Weapon>().isActiveWeapon=false;
            weaponToDrop.GetComponent<Weapon>().animator.enabled = false;
            weaponToDrop.transform.SetParent(pickedupWeapon.transform.parent);
            weaponToDrop.transform.localPosition=pickedupWeapon.transform.localPosition;
            weaponToDrop.transform.localRotation=pickedupWeapon.transform.localRotation;
        }
    }

    public void switchAchtiveSlot(int slotNumber)
    {
        if(activeWeaponSlote.transform.childCount > 0)
        {
            Weapon currentWeapon = activeWeaponSlote.transform.GetChild(0).GetComponent<Weapon>();
            currentWeapon.isActiveWeapon = false;
        }
        activeWeaponSlote =weaponSlots[slotNumber];
        if(activeWeaponSlote.transform.childCount > 0)
        {
            Weapon newWeapon = activeWeaponSlote.transform.GetChild(0).GetComponent<Weapon>();
            newWeapon.isActiveWeapon = true;
        }
    }

    internal void PickupAmmo(AmmoBox ammo)
    {
        switch(ammo.ammoType)
        {
            case AmmoBox.AmmoType.PistolAmmo:
                totalPistolAmmo+=ammo.ammoAmount;
                break;
            case AmmoBox.AmmoType.RifleAmmo:
                totalRifleAmmo+=ammo.ammoAmount;
                break;
        }
    }

    internal void DecreaseTotalAmmo(int bulletsToDecrease, Weapon.WeaponModel thisWeaponModle)
    {
        switch (thisWeaponModle)
        {
            case Weapon.WeaponModel.AK:
                totalRifleAmmo-=bulletsToDecrease;
                break;
            case Weapon.WeaponModel.Pistol:
                totalPistolAmmo-=bulletsToDecrease;
                break;   
        }
    }

    public int CheckAmmoLeftFor(Weapon.WeaponModel thisWeaponModle)
    {
        switch (thisWeaponModle)
        {
            case Weapon.WeaponModel.AK:
                return totalRifleAmmo;

            case Weapon.WeaponModel.Pistol:
                return totalPistolAmmo;

            default:
                return 0;
        }
    }

    public void PickupThrowable(Throwable throwable)
    {
        switch (throwable.throwableType)
        {
            case Throwable.ThrowableType.Grenade:
                PickupThrowableAslethal(Throwable.ThrowableType.Grenade);
                break;
            case Throwable.ThrowableType.Smoke_Grenade:
                PickupThrowableAsTactical(Throwable.ThrowableType.Smoke_Grenade);
                break;
        }
    }

    private void PickupThrowableAsTactical(Throwable.ThrowableType tactial)
    {
        if(eqippedTacticalsType == tactial || eqippedTacticalsType == Throwable.ThrowableType.None)
        {
            eqippedTacticalsType = tactial;
            if (tacticalsCount < maxTacticals)
            {
                tacticalsCount +=1;
                Destroy(InteractionManatgere.Instace.hoveredThrowable.gameObject);
                HUDManager.Instace.UpdateThrowablesUI();
            }
            else
            {
                print("tactical limit reached");
            }
        }
        else
        {
            //cannot pickup deffrenet lethal
            //
        }
    }

    private void PickupThrowableAslethal(Throwable.ThrowableType lethal)
    {
        if(eqippedLethalType == lethal || eqippedLethalType == Throwable.ThrowableType.None)
        {
            eqippedLethalType = lethal;
            if (lethalsCount < maxLethals)
            {
                lethalsCount +=1;
                Destroy(InteractionManatgere.Instace.hoveredThrowable.gameObject);
                HUDManager.Instace.UpdateThrowablesUI();
            }
            else
            {
                print("Lethals limit reached");
            }
        }
        else
        {
            //cannot pickup deffrenet lethal
            //
        }
    }

    private void ThrowLethal()
    {
        GameObject lethalPrefab = GetThrowablePrefab(eqippedLethalType);
        GameObject throwable = Instantiate(lethalPrefab, throwableSpawn.transform.position, Camera.main.transform.rotation);
        Rigidbody rb = throwable.GetComponent<Rigidbody>();
        rb.AddForce(Camera.main.transform.forward * (throwForce * forceMuliplier), ForceMode.Impulse);
        throwable.GetComponent<Throwable>().hasBeenThrown = true;
        lethalsCount -= 1;
        if( lethalsCount <= 0)
        {
            eqippedLethalType = Throwable.ThrowableType.None;
        }
        HUDManager.Instace.UpdateThrowablesUI();
    }

    private void ThrowTactical()
    {
        GameObject tacticalPrefab = GetThrowablePrefab(eqippedTacticalsType);
        GameObject throwable = Instantiate(tacticalPrefab, throwableSpawn.transform.position, Camera.main.transform.rotation);
        Rigidbody rb = throwable.GetComponent<Rigidbody>();
        rb.AddForce(Camera.main.transform.forward * (throwForce * forceMuliplier), ForceMode.Impulse);
        throwable.GetComponent<Throwable>().hasBeenThrown = true;
        tacticalsCount -= 1;
        if( tacticalsCount <= 0)
        {
            eqippedTacticalsType = Throwable.ThrowableType.None;
        }
        HUDManager.Instace.UpdateThrowablesUI();
    }
    private GameObject GetThrowablePrefab(Throwable.ThrowableType throwableType)
    {
        switch (throwableType)
        {
            case Throwable.ThrowableType.Grenade:
                return grenadePrefab;
            case Throwable.ThrowableType.Smoke_Grenade:
                return smokeGrenadePrefab;
        }
        return new();
    }
}
