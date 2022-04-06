using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HealthInfoUI : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI healthText;
    [SerializeField] public TextMeshProUGUI maxHealthText;
    HealthComponent playerHealthComponent;

    private void OnEnable()
    {
        PlayerEvents.OnHealthInitialized += OnHealthInitialized;
    }

    private void OnDisable()
    {
        PlayerEvents.OnHealthInitialized -= OnHealthInitialized;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnHealthInitialized(HealthComponent healthComponent)
    {
        playerHealthComponent = healthComponent;
    }
    public void UpdateHealth()
    {
        healthText.text = playerHealthComponent.CurrentHealth.ToString();
        maxHealthText.text = playerHealthComponent.MaxHealth.ToString();
    }
    void Update()
    {
        UpdateHealth();
    }
}