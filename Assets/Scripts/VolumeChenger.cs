using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeChenger : MonoBehaviour
{
    private const string ButtonVolume = nameof(ButtonVolume);
    private const string BackgroundVolume = nameof(BackgroundVolume);
    private const string MasterVolume = nameof(MasterVolume);

    [SerializeField] private Slider _totalVolume;
    [SerializeField] private Slider _buttonVolume;
    [SerializeField] private Slider _backgroundVolume;

    [SerializeField] private AudioMixer _audioMixer;

    private int _logarithmMultiplier = 20;

    private void OnEnable()
    {
        _totalVolume.onValueChanged.AddListener(OnMasterVolumeChenge);
        _buttonVolume.onValueChanged.AddListener(OnButtonVolumeChenge);
        _backgroundVolume.onValueChanged.AddListener(OnBackgroundVolumeChenge);
    }

    private void OnDestroy()
    {
        _totalVolume.onValueChanged.RemoveListener(OnMasterVolumeChenge);
        _buttonVolume.onValueChanged.RemoveListener(OnButtonVolumeChenge);
        _backgroundVolume.onValueChanged.RemoveListener(OnBackgroundVolumeChenge);
    }

    public void OnButtonVolumeChenge(float volume)
    {
        _audioMixer.SetFloat(ButtonVolume, Mathf.Log10(volume) * _logarithmMultiplier);
    }

    public void OnBackgroundVolumeChenge(float volume)
    {
        _audioMixer.SetFloat(BackgroundVolume, Mathf.Log10(volume) * _logarithmMultiplier);
    }

    public void OnMasterVolumeChenge(float volume)
    {
        _audioMixer.SetFloat(MasterVolume, Mathf.Log10(volume) * _logarithmMultiplier);
    }
}
