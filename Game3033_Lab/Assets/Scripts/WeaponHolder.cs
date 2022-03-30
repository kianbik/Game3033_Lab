using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class WeaponHolder : MonoBehaviour
{
    [Header("WeaponToSpawn"), SerializeField]
    GameObject weaponToSpawn;

    public Sprite Crosshair;

    [SerializeField]
    GameObject weaponSocketLocation;
    [SerializeField]
    Transform gripSocketLocation;

    public readonly int isReloadingHash = Animator.StringToHash("IsReloading");
    public readonly int isFiringHash = Animator.StringToHash("IsFiring");

    public PlayerController playerController;
    Animator playerAnimator;
    WeaponComponent equippedWeapon;
    bool firingPressed = false;
    // Start is called before the first frame update
    void Start()
    {
        GameObject spawnedWeapon = Instantiate(weaponToSpawn, weaponSocketLocation.transform.position, weaponSocketLocation.transform.rotation, weaponSocketLocation.transform);
        playerController = GetComponent<PlayerController>();
        playerAnimator = GetComponent<Animator>();
        equippedWeapon = spawnedWeapon.GetComponent<WeaponComponent>();
        equippedWeapon.Initialize(this);
        gripSocketLocation = equippedWeapon.gripLocation;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnAnimatorIK(int layerIndex)
    {
        if (playerController.isAiming)
        {
            playerAnimator.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1);
            playerAnimator.SetIKPosition(AvatarIKGoal.LeftHand, gripSocketLocation.transform.position);
        }
    }
    public void OnReload(InputValue value)
    {

        playerController.isReloading = value.isPressed;
        playerAnimator.SetBool(isReloadingHash, playerController.isReloading);
        playerAnimator.SetIKPositionWeight(AvatarIKGoal.LeftHand, 0);


    }
    public void OnFire(InputValue value)
    {

        firingPressed = value.isPressed;
        if (firingPressed)
        {
            StartFiring();
        }
        else
            StopFiring();
    }
    void StartFiring()
    {
        if (equippedWeapon.weaponStats.bulletsInClip > 0)
        {
            //playerAnimator.SetBool(isReloadingHash, true);
            playerController.isFiring = true;
            equippedWeapon.StartFiringWeapon();
        }
    }
    void StopFiring()
    {
        playerController.isFiring = false;
        equippedWeapon.StopFiringWeapon();
    }
}
