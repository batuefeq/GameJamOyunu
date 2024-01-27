using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    // public Dropdown resolutionDropdown;
    // Resolutions[] resolutions;
    Resolution[] resolutions;
    public TMP_Dropdown resolutionDropdown;
    public AudioMixer audioMixer;

    void Start()
    {
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();
        List<string> options = new List<string>();
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);
        }
        resolutionDropdown.AddOptions(options);
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetFullscreen(bool isFull)
    {
        Screen.fullScreen = isFull;
    }


    // void Start ()
    // {
    //     resolutions = Screen.resolutions;
    //     resolutionDropdown.ClearOptions();
    //     List<string> options = new List<string>();
    //     for(int i=0;i<resolutions.Length;i++){
    //         string option= resolutions[i].width + " x " + resolutions[i].height;
    //         options.Add(option);
    //     }
    //     resolutionDropdown.AddOptions(options);
    // }
}

