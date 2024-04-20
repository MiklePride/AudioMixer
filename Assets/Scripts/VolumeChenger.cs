using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class VolumeChenger : MonoBehaviour
{
    private const string ButtonVolume = nameof(ButtonVolume);
    private const string BackgroundVolume = nameof(BackgroundVolume);
    private const string MasterVolume = nameof(MasterVolume);

    [SerializeField] private AudioMixer _audioMixer;
    [SerializeField] private AudioMixerSnapshot _mute;
    [SerializeField] private AudioMixerSnapshot _unmute;

    private bool _isMuted = false;

    public void OnButtonVolumeChenge(float volume)
    {
        _audioMixer.SetFloat(ButtonVolume, Mathf.Log10(volume) * 20);
    }

    public void OnBackgroundVolumeChenge(float volume)
    {
        _audioMixer.SetFloat(BackgroundVolume, Mathf.Log10(volume) * 20);
    }

    public void OnMasterVolumeChenge(float volume)
    {
        _audioMixer.SetFloat(MasterVolume, Mathf.Log10(volume) * 20);
    }

    public void OnMuteAll()
    {
        _isMuted = !_isMuted;

        if (_isMuted)
        {
            _mute.TransitionTo(0);
        }
        else
        {
            _unmute.TransitionTo(0);
        }
    }
}
