using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;


internal sealed class SettingsMenu : MonoBehaviour
{
    #region Fields

    [SerializeField] private AudioMixer _audioMixer;
    [SerializeField] private Dropdown _resolutionDropdown;
    private Resolution[] _resolutions;

    #endregion


    #region UnityMethods

    private void Start()
    {
        SetOptions();
    }

    #endregion


    #region Methods

    public void SetVolume(float volume)
    {
        _audioMixer.SetFloat(nameof(volume), volume);
    }

    public void SetQuality(int indexOfQuality)
    {
        QualitySettings.SetQualityLevel(indexOfQuality);
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = _resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    private void SetOptions()
    {
        _resolutions = Screen.resolutions;
        _resolutionDropdown.ClearOptions();
        List<string> options = new List<string>();

        int currentResolutionIndex = 0;

        for (int i = 0; i < _resolutions.Length; i++)
        {
            string option = _resolutions[i].width + " x " + _resolutions[i].height;
            options.Add(option);

            if(_resolutions[i].width == Screen.currentResolution.width
                && _resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }

        _resolutionDropdown.AddOptions(options);
        _resolutionDropdown.value = currentResolutionIndex;
        _resolutionDropdown.RefreshShownValue();
    }

    #endregion
}
