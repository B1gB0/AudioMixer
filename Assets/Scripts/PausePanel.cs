using UnityEngine;
using UnityEngine.Audio;

public class PausePanel : MonoBehaviour
{
    private const string MasterVolume = nameof(MasterVolume);
    private const string MusicVolume = nameof(MusicVolume);
    private const string UIVolume = nameof(UIVolume);

    [SerializeField] private AudioMixerGroup _mixer;
    [SerializeField] private float _minVolume = -80f;
    [SerializeField] private float _maxVolume = 0f;

    public void ChangeMasterVolume(float volume)
    {
        _mixer.audioMixer.SetFloat(MasterVolume, Mathf.Lerp(_minVolume, _maxVolume, volume));
    }

    public void ChangeMusicVolume(float volume)
    {
        _mixer.audioMixer.SetFloat(MusicVolume, Mathf.Lerp(_minVolume, _maxVolume, volume));
    }

    public void ChangeButtonsVolume(float volume)
    {
        _mixer.audioMixer.SetFloat(UIVolume, Mathf.Lerp(_minVolume, _maxVolume, volume));
    }

    public void ToggleAllSounds(bool enabled)
    {
        if(enabled)
            _mixer.audioMixer.SetFloat(MasterVolume, _maxVolume);
        else
            _mixer.audioMixer.SetFloat(MasterVolume, _minVolume);
    }
}
