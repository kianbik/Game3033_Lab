using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolComponent : WeaponComponent
{
    protected override void FireWeapon()
    {
        Vector3 hitlocation;
        if(weaponStats.bulletsInClip > 0 && !isReloading && !weaponHolder.playerController.isRunning)
        {

         base.FireWeapon();
            Ray screenRay = mainCamera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
            if(Physics.Raycast(screenRay, out RaycastHit hit, weaponStats.fireDistance, weaponStats.weaponhitLayerMask))
            {
                hitlocation = hit.point;
                DealDamage(hit);
                Vector3 hitDirection = hit.point - mainCamera.transform.position;
                Debug.DrawRay(mainCamera.transform.position, hitDirection.normalized * weaponStats.fireDistance, Color.red, 1);
               
            }
        }
    }
    void DealDamage(RaycastHit hitInfo)
    {
        IDamageable damageable = hitInfo.collider.GetComponent<IDamageable>();
        damageable?.TakeDamage(weaponStats.damage);
    }

}
