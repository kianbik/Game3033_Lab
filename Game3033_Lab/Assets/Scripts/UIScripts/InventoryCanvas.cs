using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using UnityEngine;

public class InventoryCanvas : GameHUDWidget
{
    private ItemDisplayPanel ItemDisplayPanel;
    private List<CategorySelectButton> CategoryButtons;
    private PlayerController playerController;

    private void Awake()
    {
        playerController = FindObjectOfType<PlayerController>();
        CategoryButtons = GetComponentsInChildren<CategorySelectButton>().ToList();
        ItemDisplayPanel = GetComponentInChildren<ItemDisplayPanel>();
        foreach (CategorySelectButton button in CategoryButtons)
        {
            button.Initialize(this);
        }
    }

    private void OnEnable()
    {
        if (!playerController || !playerController.inventory) return;
        if (playerController.inventory.GetItemCount() <= 0) return;

        ItemDisplayPanel.PopulatePanel(playerController.inventory.GetItemsOfCategory(ItemCategory.NONE));
    }

    public void SelectCategory(ItemCategory category)
    {
        if (!playerController || !playerController.inventory) return;
        if (playerController.inventory.GetItemCount() <= 0) return;

        ItemDisplayPanel.PopulatePanel(playerController.inventory.GetItemsOfCategory(category));
    }
}