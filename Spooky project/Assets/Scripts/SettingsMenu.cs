using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using System.Linq;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public float volumeValue;
    public Slider volumeSlider;
    public Toggle fullscreenToggle;
    public Dropdown resolutionDropdown;

    [Tooltip("Aseta tähän listaan ne resoluutiot, jotka haluat pelaajalle tarjota.")]
    public List<Vector2> allowedResolutions = new List<Vector2>()
    {
        new Vector2(2560, 1440),
        new Vector2(1920, 1080),
        new Vector2(1280, 720),  
        new Vector2(800, 600)
    };


    void Start(){

        int isFullscreenInt = PlayerPrefs.GetInt("IsFullscreen", 1); 
        bool isFullscreen = (isFullscreenInt == 1);
        
        Screen.fullScreen = isFullscreen;
        if (fullscreenToggle != null)
        {
            fullscreenToggle.isOn = isFullscreen;
        }


        volumeSlider.value = PlayerPrefs.GetFloat("volume");

        
        resolutionDropdown.ClearOptions();
        List<string> options = new List<string>();
        int currentResolutionIndex = 0;

        for (int i = 0; i < allowedResolutions.Count; i++)
        {
            int width = (int)allowedResolutions[i].x;
            int height = (int)allowedResolutions[i].y;
            
            string option = width + " x " + height;
            options.Add(option);

            if (width == Screen.width && height == Screen.height)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        int savedResolutionIndex = PlayerPrefs.GetInt("ResolutionIndex", currentResolutionIndex);
        
        if (savedResolutionIndex >= allowedResolutions.Count || savedResolutionIndex < 0)
        {
            savedResolutionIndex = currentResolutionIndex;
            PlayerPrefs.SetInt("ResolutionIndex", savedResolutionIndex); 
            PlayerPrefs.Save();
        }
        
        resolutionDropdown.value = savedResolutionIndex;
        resolutionDropdown.RefreshShownValue();

        SetResolution(savedResolutionIndex);
    }


    public void Update()
    {
        audioMixer.SetFloat("volume", volumeValue);
        PlayerPrefs.SetFloat("volume",volumeValue);
    }

    public void SetResolution(int resolutionIndex){

        if (resolutionIndex >= 0 && resolutionIndex < allowedResolutions.Count)
        {
            int width = (int)allowedResolutions[resolutionIndex].x;
            int height = (int)allowedResolutions[resolutionIndex].y;

            Screen.SetResolution(width, height, Screen.fullScreen);

            PlayerPrefs.SetInt("ResolutionIndex", resolutionIndex);
            PlayerPrefs.Save();
        }
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