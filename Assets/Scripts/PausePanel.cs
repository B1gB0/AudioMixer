using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class PausePanel : MonoBehaviour
{
    private const string MasterVolume = nameof(MasterVolume);
    private const string MusicVolume = nameof(MusicVolume);
    private const string ButtonsVolume = nameof(ButtonsVolume);
    private const string MasterEnabled = nameof(MasterEnabled);

    [SerializeField] private AudioMixerGroup _mixer;
    [SerializeField] private float _minVolume = -80f;
    [SerializeField] private float _maxVolume = 0f;

    [SerializeField] private Slider _masterVolumeSlider;
    [SerializeField] private Slider _musicVolumeSlider;
    [SerializeField] private Slider _ButtonsVolumeSlider;

    [SerializeField] private Toggle _masterVolumeToggle;

    private float _minValueSlider = 0f;
    private float _maxValueSlider = 1f;

    private void Start()
    {
        if(PlayerPrefs.GetInt(MasterEnabled) == 1)
        {
            _masterVolumeToggle.isOn = true;
        }
        else
        {
            _masterVolumeToggle.isOn = false;
        }

        _masterVolumeSlider.value = PlayerPrefs.GetFloat(MasterVolume);
        _musicVolumeSlider.value = PlayerPrefs.GetFloat(MusicVolume);
        _ButtonsVolumeSlider.value = PlayerPrefs.GetFloat(ButtonsVolume);
    }

    public void ChangeMasterVolume(float volume)
    {
        _mixer.audioMixer.SetFloat(MasterVolume, Mathf.Lerp(_minVolume, _maxVolume, volume));

        PlayerPrefs.SetFloat(MasterVolume, volume);
    }

    public void ChangeMusicVolume(float volume)
    {
        _mixer.audioMixer.SetFloat(MusicVolume, Mathf.Lerp(_minVolume, _maxVolume, volume));

        PlayerPrefs.SetFloat(MusicVolume, volume);
    }

    public void ChangeButtonsVolume(float volume)
    {
        _mixer.audioMixer.SetFloat(ButtonsVolume, Mathf.Lerp(_minVolume, _maxVolume, volume));

        PlayerPrefs.SetFloat(ButtonsVolume, volume);
    }

    public void ToggleAllSounds(bool enabled)
    {
        if (enabled)
        {
            _mixer.audioMixer.SetFloat(MasterVolume, _maxVolume);

            _masterVolumeSlider.value = _maxValueSlider;
        }
        else
        {
            _mixer.audioMixer.SetFloat(MasterVolume, _minVolume);

            _masterVolumeSlider.value = _minValueSlider;
        }

        PlayerPrefs.SetInt(MasterEnabled, enabled ? 1 : 0);
    }
}
