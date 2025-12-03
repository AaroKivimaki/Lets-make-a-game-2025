using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public float volumeValue;
    public Slider volumeSlider;
    public Toggle fullscreenToggle;
    public Dropdown resolutionDropdown;
    Resolution[] resolutions;

    void Start(){

        int isFullscreenInt = PlayerPrefs.GetInt("IsFullscreen", 1); 
        bool isFullscreen = (isFullscreenInt == 1);
        
        Screen.fullScreen = isFullscreen;
        if (fullscreenToggle != null)
        {
            fullscreenToggle.isOn = isFullscreen;
        }


        volumeSlider.value = PlayerPrefs.GetFloat("volume");

        
        resolutions = Screen.resolutions;

        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        int currentResolutionIndex = 0;

        int savedResolutionIndex = PlayerPrefs.GetInt("ResolutionIndex", 0);

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = savedResolutionIndex;
        SetResolution(savedResolutionIndex);
        resolutionDropdown.RefreshShownValue();

    }

    public void Update()
    {
        audioMixer.SetFloat("volume", volumeValue);
        PlayerPrefs.SetFloat("volume",volumeValue);
    }

    public void SetResolution(int resolutionIndex){
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);

        PlayerPrefs.SetInt("ResolutionIndex", resolutionIndex);
        PlayerPrefs.Save();
    }

    public void SetVolume(float volume) {

        volumeValue = volume;

    }

    public void SetFullscreen(bool isFullscreen){

        Screen.fullScreen = isFullscreen;

        int isFullscreenInt = isFullscreen ? 1 : 0;
        PlayerPrefs.SetInt("IsFullscreen", isFullscreenInt);
        PlayerPrefs.Save();

    }
}