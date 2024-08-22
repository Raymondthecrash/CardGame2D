using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager Instance { get; private set; }

    [SerializeField] private List<Enemy> enemyPrefabs;
    [SerializeField] private Transform enemySpawnPoint;

    private List<Enemy> activeEnemies = new List<Enemy>();

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
    }

    public void InitializeEnemies()
    {
        // Clear any existing enemies
        foreach (var enemy in activeEnemies)
        {
            Destroy(enemy.gameObject);
        }
        activeEnemies.Clear();

        // Spawn new enemies
        foreach (var enemyPrefab in enemyPrefabs)
        {
            Enemy newEnemy = Instantiate(enemyPrefab, enemySpawnPoint.position, Quaternion.identity);
            activeEnemies.Add(newEnemy);
        }
    }

    public bool AllEnemiesDefeated()
    {
        return activeEnemies.Count == 0;
    }

    public void RemoveEnemy(Enemy enemy)
    {
        activeEnemies.Remove(enemy);
        Destroy(enemy.gameObject);
    }
}