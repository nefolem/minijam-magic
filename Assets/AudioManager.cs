using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioClip _backGroundMusic;
    [SerializeField] private AudioClip _pickUpSound;
    [SerializeField] private AudioClip _hitSound;
    [SerializeField] private AudioClip _winSound;
    [SerializeField] private AudioClip _deathSound;
    private AudioSource _audioSource;

    public static AudioManager Instance;
    
    private void Awake()
    {
        Instance = this;
        _audioSource = GetComponent<AudioSource>();
        _audioSource.PlayOneShot(_backGroundMusic);
    }

    public void PlayPickUpSound()
    {
        _audioSource.PlayOneShot(_pickUpSound);
    }

    public void PlayHitSound()
    {
        _audioSource.PlayOneShot(_hitSound);
    }

    public void PlayWinSound()
    {
        _audioSource.Stop();
        _audioSource.PlayDelayed(0.5f);
        _audioSource.PlayOneShot(_winSound);
    }
    
    public void PlayDeathSound()
    {
        _audioSource.Stop();
        _audioSource.PlayDelayed(0.5f);
        _audioSource.PlayOneShot(_deathSound);
    }
}
