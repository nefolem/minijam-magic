using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{
    [SerializeField] private int _maxHealth;
    [SerializeField] private int _currentHealth;
    [SerializeField] private List<GameObject> _lives;
    [SerializeField] private GameObject _deathPanel;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private float _blinkDuration = 1.5f;

    private Animator _heart;
    public bool _isDamaged = false;
    public bool _isWon;
    public bool _isDead;

    public static HealthController Instance;

    private void Awake()
    {
        Instance = this;
        if (_deathPanel != null)
            _deathPanel.SetActive(false);
        _currentHealth = _maxHealth;
        _isWon = false;
        _isDead = false;

    }

    public void GetDamaged()
    {
        if (_currentHealth == 0)
        {
            _deathPanel.SetActive(true);
            AudioManager.Instance.PlayDeathSound();
            _isDead = true;
            return;
        }
        else if (!_isDead && !_isWon && !_isDamaged && _currentHealth > 0)
        {
            _lives[_currentHealth - 1].SetActive(false);
            _lives.RemoveAt(_currentHealth - 1);
            _currentHealth--;
            AudioManager.Instance.PlayHitSound();
            StartCoroutine(Blinking());
            
        }
        else return;
    }

    IEnumerator Blinking()
    {
        _isDamaged = true;
        for (int i = 0; i < 4; i++)
        {
            _spriteRenderer.enabled = false;
            yield return new WaitForSeconds(_blinkDuration);
            _spriteRenderer.enabled = true;
            yield return new WaitForSeconds(_blinkDuration);
        }
        _isDamaged = false;

    }

}
