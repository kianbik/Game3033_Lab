using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeaponType
{
    None, Pistol, Shotgun, Melee, Smg
}
public enum WeaponfiringPatern
{
    SemiAuto, Burst, FullAuto, PumpAction
}
[System.Serializable]
public struct WeaponStats
{
    public WeaponType weapontype;
    public WeaponfiringPatern firePattern;
    public string weaponName;
    public float damage;
    public int ammoSize;
    public int bulletsInClip;
    public float fireDelay;
    public float fireRate;
    public float fireDistance;
    public bool repeating;
    public LayerMask weaponhitLayerMask;

}
public class WeaponComponent : MonoBehaviour
{
    public Transform gripLocation;
    public WeaponStats weaponStats;
    public bool isFiring;
    public bool isReloading;
    protected WeaponHolder weaponHolder;
    protected Camera mainCamera;

    // Start is called before the first frame update
    private void Awake()
    {
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Initialize(WeaponHolder _weaponHolder)
    {
        weaponHolder = _weaponHolder;
    }
    public virtual void StartFiringWeapon()
    {
        isFiring = true;
        if (weaponStats.repeating)
        {
            InvokeRepeating(nameof(FireWeapon), weaponStats.fireDelay, weaponStats.fireRate);
        }
        else
            FireWeapon();
    }
    public virtual void StopFiringWeapon()
    {
        isFiring = false;
        CancelInvoke(nameof(FireWeapon));
    
    
    }
    protected virtual void FireWeapon()
    {
        weaponStats.bulletsInClip--;
    }
}
