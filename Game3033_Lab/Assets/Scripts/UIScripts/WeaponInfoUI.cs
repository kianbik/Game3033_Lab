using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class WeaponInfoUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI weaponText;
    [SerializeField] TextMeshProUGUI ammoText;
    [SerializeField] TextMeshProUGUI totalBulletText;

    [SerializeField] WeaponComponent weaponComponent;
    // Start is called before the first frame update
    private void OnEnable()
    {
        PlayerEvents.OnWeaponEquipped += OnWeaponEquippedEvent;
        
    }
    private void OnDisable()
    {
        PlayerEvents.OnWeaponEquipped -= OnWeaponEquippedEvent;

    }
    void OnWeaponEquippedEvent(WeaponComponent _weaponComponent)
    {
        weaponComponent = _weaponComponent;
    }
    void Update()
    {
        if (!weaponComponent)
            return;

        weaponText.text = weaponComponent.weaponStats.weaponName;
        ammoText.text = weaponComponent.weaponStats.bulletsInClip.ToString();
        totalBulletText.text  = weaponComponent.weaponStats.totalBullets.ToString();
    }
}
