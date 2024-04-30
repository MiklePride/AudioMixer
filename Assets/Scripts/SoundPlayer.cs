using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class SoundPlayer : MonoBehaviour
{
    [SerializeField] private Button _playButton;

    private AudioSource _audioSource;
    private bool _isPlaying;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _isPlaying = false;
    }

    private void OnEnable()
    {
        _playButton.onClick.AddListener(OnChengeState);
    }

    private void OnDestroy()
    {
        _playButton.onClick.RemoveListener(OnChengeState);
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
