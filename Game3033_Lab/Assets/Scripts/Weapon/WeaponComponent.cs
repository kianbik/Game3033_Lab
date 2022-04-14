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
    public int totalBullets;
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
    [SerializeField]
    protected ParticleSystem firingEffect;


    // Start is called before the first frame update
    private void Awake()
    {
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Initalize(WeaponHolder _weaponHolder, WeaponScriptable weaponScriptable)
    {
        weaponHolder = _weaponHolder;

        if (weaponScriptable)
            weaponStats = weaponScriptable.weaponStats;
    }
    public virtual void StartFiringWeapon()
    {
        if (!isReloading)
        {
            isFiring = true;
            if (weaponStats.repeating)
            {
                InvokeRepeating(nameof(FireWeapon), weaponStats.fireDelay, weaponStats.fireRate);
                firingEffect.Play();
            }
            else
            {
                FireWeapon();
                if (!firingEffect.isPlaying)
                    firingEffect.Play();
            }
        }
    }
    public virtual void StopFiringWeapon()
    {
        isFiring = false;
        CancelInvoke(nameof(FireWeapon));
        if (firingEffect.isPlaying)
        {
            firingEffect.Stop();
        }
    
    
    }
    protected virtual void FireWeapon()
    {
        weaponStats.bulletsInClip--;
      
         
        
    }
    public virtual void StartReloading()
    {
        isReloading = true;
      
        ReloadWeapon();

    }
    public virtual void StopReloading()
    {
        isReloading = false;
    }

    protected virtual void ReloadWeapon()
    {
        if (firingEffect.isPlaying)
        {
            firingEffect.Stop();
        }
        int bulletsToReload = weaponStats.ammoSize - weaponStats.totalBullets;
        if(bulletsToReload< 0)
        {
            weaponStats.totalBullets -= ( weaponStats.ammoSize - weaponStats.bulletsInClip);
            weaponStats.bulletsInClip = weaponStats.ammoSize;
        }
        else
        {
            weaponStats.bulletsInClip = weaponStats.totalBullets;
            weaponStats.totalBullets = 0;
        }
    }
}
