using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class PlayerManager : MonoBehaviour
{
    //[SerializeField] private int maxHealth = 1234;
    //private int currentHealth;
    public Text HPText;
    public static PlayerManager Instance { get; private set; }
    //[SerializeField] private List<PlayerUnit> PlayerPrefabs;
    [SerializeField] private PlayerUnit PlayerPrefabs;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        PlayerPrefabs.CurrentHealth = PlayerPrefabs.MaxHealth;
        //PlayerPrefabs[1].CurrentHealth = PlayerPrefabs[1].MaxHealth;
        //PlayerPrefabs[2].CurrentHealth = PlayerPrefabs[2].MaxHealth;
    }
   
    public bool IsPlayerDefeated()
    {
        return PlayerPrefabs.CurrentHealth <= 0;
    }

    public void TakeDamage(int damage)
    {
        PlayerPrefabs.CurrentHealth -= damage;
        UpdateHealthUI();
        if (PlayerPrefabs.CurrentHealth <= 0)
        {
            PlayerPrefabs.CurrentHealth = 0;
            TurnSystem.Instance.LoseBattle();
        }
    }

    private void UpdateHealthUI()
    {
        HPText.text = PlayerPrefabs.CurrentHealth.ToString();
    }

    // Add other player-related methods as needed
}