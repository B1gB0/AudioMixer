using UnityEngine;
using UnityEngine.Audio;

public class PausePanel : MonoBehaviour
{
    [SerializeField] private AudioMixerGroup _mixer;

    public void ChangeMasterVolume(float volume)
    {
        _mixer.audioMixer.SetFloat("MasterVolume", Mathf.Lerp(-80, 0, volume));
    }

    public void ChangeMusicVolume(float volume)
    {
        _mixer.audioMixer.SetFloat("MusicVolume", Mathf.Lerp(-80, 0, volume));
    }

    public void ChangeButtonsVolume(float volume)
    {
        _mixer.audioMixer.SetFloat("UIVolume", Mathf.Lerp(-80, 0, volume));
    }

    public void ToggleAllSounds(bool enabled)
    {
        if(enabled)
            _mixer.audioMixer.SetFloat("MasterVolume", 0);
        else
            _mixer.audioMixer.SetFloat("MasterVolume", -80);
    }
}
