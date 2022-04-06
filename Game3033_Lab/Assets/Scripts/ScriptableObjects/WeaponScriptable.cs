using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "Items/Weapon", order = 2)]
public class WeaponScriptable : EquippableScriptable
{
    public WeaponStats weaponStates;

    public override void UseItem(PlayerController playerController)
    {
        if (Equipped)
        {
            // Unequip from Inventory and Controller
        }
        else
        {
            // invvoke on weapon from player events here for inventory
            // equip weapon from weapon holder on player controller
        }

        base.UseItem(playerController);
    }
}