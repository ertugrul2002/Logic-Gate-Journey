using System;
using System.Diagnostics;
using Microsoft.Unity.VisualStudio.Editor;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public static HUDManager Instace {get; set;}
    [Header("Ammo")]
    public TextMeshProUGUI magazineAmmoUI;
    public TextMeshProUGUI totalAmmoUI;
    public UnityEngine.UI.Image ammoTypeUI;
    [Header("Weapon")]
    public UnityEngine.UI.Image activeWeaponUI;
    public UnityEngine.UI.Image unactiveWeaponUI;
    [Header("Throwables")]
    public UnityEngine.UI.Image lethalUI;
    public TextMeshProUGUI lethalAmountUI;

    public UnityEngine.UI.Image tactialUI;
    public TextMeshProUGUI tactialAmountUI;

    public Sprite emptySlot;
    public Sprite gerySlot;

    public GameObject middlDot;
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
    private void Update()
    {
        Weapon activeWeapon =WeaponManager.Instace.activeWeaponSlote.GetComponentInChildren<Weapon>();
        Weapon unActiveWeapon = GetunActiveWeaponSlot().GetComponentInChildren<Weapon>();

        if (activeWeapon)
        {
            magazineAmmoUI.text =$"{activeWeapon.bulletsLeft / activeWeapon.bulletsPerBurst}";
            totalAmmoUI.text = $"{WeaponManager.Instace.CheckAmmoLeftFor(activeWeapon.thisWeaponModle)}";

            Weapon.WeaponModel model =activeWeapon.thisWeaponModle;
            ammoTypeUI.sprite =GetAmmoSprite(model);

            activeWeaponUI.sprite = GetWeaponSprite(model);

            if(unActiveWeapon)
            {
                unactiveWeaponUI.sprite = GetWeaponSprite(unActiveWeapon.thisWeaponModle);
            }
        }
        else
        {
            magazineAmmoUI.text ="";
            totalAmmoUI.text = "";
            ammoTypeUI.sprite = emptySlot;
            activeWeaponUI.sprite = emptySlot;
            unactiveWeaponUI.sprite = emptySlot;
        }
        if( WeaponManager.Instace.lethalsCount <= 0)
        {
            lethalUI.sprite = gerySlot;
        }
        if( WeaponManager.Instace.tacticalsCount <= 0)
        {
            tactialUI.sprite = gerySlot;
        }
    }

    private GameObject GetunActiveWeaponSlot()
    {
        foreach (GameObject weaponSlot in WeaponManager.Instace.weaponSlots)
        {
            if (weaponSlot != WeaponManager.Instace.activeWeaponSlote )
            {
                return weaponSlot;
            }
        }
        return null;
    }

    private Sprite GetWeaponSprite(Weapon.WeaponModel model)
    {
        switch (model)
        {
            case Weapon.WeaponModel.Pistol:
                return Resources.Load<GameObject>("Pistol_Weapon").GetComponent<SpriteRenderer>().sprite;

            case Weapon.WeaponModel.AK:
                return Resources.Load<GameObject>("AK_weapon").GetComponent<SpriteRenderer>().sprite;
            
            default:
                return null;
        }
    }

    private Sprite GetAmmoSprite(Weapon.WeaponModel model)
    {
        switch (model)
        {
            case Weapon.WeaponModel.Pistol:
                return Resources.Load<GameObject>("Pistol_Ammo").GetComponent<SpriteRenderer>().sprite;

            case Weapon.WeaponModel.AK:
                return Resources.Load<GameObject>("Rifle_Ammo").GetComponent<SpriteRenderer>().sprite;
            
            default:
                return null;
        }
    }

    internal void UpdateThrowablesUI()
    {
        lethalAmountUI.text =$"{WeaponManager.Instace.lethalsCount}";
        tactialAmountUI.text =$"{WeaponManager.Instace.tacticalsCount}";
        switch (WeaponManager.Instace.eqippedLethalType)
        {
            case Throwable.ThrowableType.Grenade:
                lethalUI.sprite = Resources.Load<GameObject>("Grenade").GetComponent<SpriteRenderer>().sprite;
                break;
            
        }
        switch (WeaponManager.Instace.eqippedTacticalsType)
        {
            case Throwable.ThrowableType.Smoke_Grenade:
                tactialUI.sprite = Resources.Load<GameObject>("Smoke_Grenade").GetComponent<SpriteRenderer>().sprite;
                break;
            
        }
    }
}
