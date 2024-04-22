using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> _items = new();
    [SerializeField] private List<Transform> _spawnPoints = new();
    [SerializeField] private int _maxItems = 3;    

    public List<Vector2> _usedSpawnPoints = new();

    public int _currentItems;
    public static ItemSpawner Instance;

    private void Awake()
    {
        Instance = this;
    }
   
    void Start()
    {
        _currentItems = 0;
    }


    void Update()
    {
        if (_currentItems < _maxItems)
        {
            //Debug.Log(_currentItems);
            Transform _spawnPoint = _spawnPoints[Random.Range(0, _spawnPoints.Count)];
            if (_usedSpawnPoints == null || !_usedSpawnPoints.Contains(_spawnPoint.position))
            {
                Instantiate(_items[Random.Range(0, _items.Count)], _spawnPoint.position, Quaternion.identity);
                _usedSpawnPoints.Add(_spawnPoint.position);
                _currentItems++;
            }
        }
    }

    public void RemoveItem(GameObject item)
    {
        _currentItems--;
        _usedSpawnPoints.Remove(item.transform.position);

        Destroy(item);

    }


}
