using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> _enemyPrefabs;
    [SerializeField] private float _spawnDelay = 50;
    private float _timer = 0;

    void Start()
    {
        
    }

    
    void FixedUpdate()
    {
        foreach (var enemy in _enemyPrefabs)
        {
            if (_timer >= _spawnDelay)
            {
                enemy.SetActive(true);
                _timer = 0;
            }
            else
            {
                _timer += Time.fixedDeltaTime;
            }
        }
    }
}
