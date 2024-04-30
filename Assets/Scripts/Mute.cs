using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mute : MonoBehaviour
{
    [SerializeField] private Button _muteButton;
    [SerializeField] private List<AudioSource> _sounds;

    private void OnEnable()
    {
        _muteButton.onClick.AddListener(OnMute);
    }

    private void OnDestroy()
    {
        _muteButton.onClick.RemoveListener(OnMute);
    }

    private void OnMute()
    {
        if (_sounds != null)
        {
            foreach (AudioSource sound in _sounds)
            {
                sound.mute = !sound.mute;
            }
        }
    }
}
