using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    private AudioSource _audioSource = default;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void SetAudioClip(AudioClip clip, float volume)
    {
        _audioSource.PlayOneShot(clip, volume);
    }
}
