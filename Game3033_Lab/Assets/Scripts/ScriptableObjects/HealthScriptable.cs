using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Health", menuName = "Items/Consumable", order = 1)]
public class HealthScriptable : ItemScript
{

    public override void UseItem(PlayerController playerController)
    {
        if (playerController.healthComponent.CurrentHealth >= 100) return;

       //heal 
        //base.UseItem(playerController);
    }
}