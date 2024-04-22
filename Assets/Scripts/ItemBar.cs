using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemBar : MonoBehaviour
{
    [SerializeField] private List<Image> _itemIcons;
    [SerializeField] private GameObject _winPanel;
    private bool _isComplete;
    private void Awake()
    {
        if (_winPanel != null )
        _winPanel.SetActive(false);
        _isComplete = false;
    }
    

    private void Update()
    {
        foreach (var icon in _itemIcons)
        {
            if (icon.color == new Color32(255, 255, 225, 255))
            {
                _isComplete = true;
            }
            else
            {
                _isComplete = false;
                break;
            }
        }
        if (_isComplete)
        {
            HealthController.Instance._isWon = true;
            AudioManager.Instance.PlayWinSound();
            _winPanel.SetActive(true);
        }
    }

    public void AddItem(string itemTag)
    {
        switch (itemTag)
        {
            case "Blue":
                _itemIcons[0].color = new Color32(255, 255, 225, 255);
                break;
            case "Green":
                _itemIcons[1].color = new Color32(255, 255, 225, 255);
                break;
            case "Orange":
                _itemIcons[2].color = new Color32(255, 255, 225, 255);
                break;
            case "Red":
                _itemIcons[3].color = new Color32(255, 255, 225, 255);
                break;
            case "Purple":
                _itemIcons[4].color = new Color32(255, 255, 225, 255);
                break;
        }
    }
}
