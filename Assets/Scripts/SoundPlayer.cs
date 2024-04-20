using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundPlayer : MonoBehaviour
{
    private AudioSource _audioSource;
    private bool _isPlaying;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _isPlaying = false;
    }

    public void OnChengeState()
    {
        if (!_isPlaying)
        {
            Play();
        }
        else
        {
            Stop();
        }
    }

    private void Play()
    {
        _audioSource.Play();
        _isPlaying = true;
    }

    private void Stop()
    {
        _audioSource.Stop();
        _isPlaying = false;
    }
}
