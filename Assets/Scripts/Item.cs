using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private float _timer = 10;
    [SerializeField] private ItemBar _itemBar;
    [SerializeField] private GameObject _pickUpFX;

    private void Awake()
    {
        _itemBar = FindAnyObjectByType<ItemBar>();
    }
    private void Update()
    {
        
        if (_timer <= 0)
        {
            ItemSpawner.Instance.RemoveItem(gameObject);
        }
        else
        {
            _timer-=Time.deltaTime;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerMovement>())
        {
            ItemSpawner.Instance.RemoveItem(gameObject);
            _itemBar.AddItem(gameObject.tag);
            Instantiate(_pickUpFX, transform.position, Quaternion.identity);

        }
    }

    
}
