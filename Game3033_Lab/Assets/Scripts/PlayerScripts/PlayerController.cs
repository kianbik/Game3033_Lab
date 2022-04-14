using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour
{
    public bool isFiring;
    public bool isReloading;
    public bool isJumping;
    public bool isRunning;
    public bool isAiming;



    public bool inInventory;
    public InventoryComponent inventory;
    public GameUIController gameUIController;
    public WeaponHolder weaponHolder;
    public HealthComponent healthComponent;


    public void Awake()
    {
        inventory = GetComponent<InventoryComponent>();
        gameUIController = FindObjectOfType<GameUIController>();
        weaponHolder = GetComponent<WeaponHolder>();
        healthComponent = GetComponent<HealthComponent>();
    }
    public void OnInventory(InputValue value)
    {
        if (inInventory)
        {
            inInventory = false;
        }
        else
        {
            inInventory = true;
        }

        OpenInventory(inInventory);
    }

    private void OpenInventory(bool open)
    {
        if (open)
        {
            gameUIController.EnableInventoryMenu();
            
        }
        else
        {
            gameUIController.EnableGameMenu();
          
        }
    }
}
