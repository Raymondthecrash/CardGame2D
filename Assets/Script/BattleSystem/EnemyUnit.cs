using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyUnit : MonoBehaviour
{
   public string UnitName;
   public int Damage;
   public int MaxHealth;
   public int CurrentHealth;

    private void Start()
    {
        CurrentHealth = MaxHealth;
    }

    public void TakeDamage(int damage)
    {
        CurrentHealth -= damage;
        if (CurrentHealth <= 0)
        {
            CurrentHealth = 0;
            EnemyManager.Instance.RemoveEnemy(this);
        }
    }
}
