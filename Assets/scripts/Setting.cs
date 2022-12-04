using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class Setting : MonoBehaviour
{
    // public bool isOpened = false;
    //
    // public float volume = 0;
    //
    public bool isFullScreen = false;
    //
    // public AudioMixer audioMixer;
    //
    // public Dropdown resolutionDropdown;
    //
    // private Resolution[] resolutions;
    //
    // private int currResolutionIndex = 0;
    Resolution[] rsl;
    List<string> resolutions;
    public Dropdown dropdown;

    void Awake()
    {
        resolutions = new List<string>();
        rsl = Screen.resolutions;
        foreach (var i in rsl)
        {
            resolutions.Add(i.width +"x" + i.height);
        }
        dropdown.ClearOptions();
        dropdown.AddOptions(resolutions);
        
    }

    public void GoToMain()
    {
        SceneManager.LoadScene("MainMenu");
    }
    //
    //
    // public void ChangeVolume(float val)
    // {
    //     // volume = val;
    //     audioMixer.SetFloat("Exp", volume);
    // }
    //
    //
    // public void ChangeResolution(int index)
    // {
    //     currResolutionIndex = index;
    // }
    //
    public void FullScreenToggle()
    {
        isFullScreen = !isFullScreen;
        Screen.fullScreen = isFullScreen;
    }
    
    public void Resolution(int r)
    {
        Screen.SetResolution(rsl[r].width, rsl[r].height, isFullScreen);
    }
    
    //
    // public void SaveSettings()
    // {
    //     audioMixer.SetFloat("MasterVolume", volume);
    //     Screen.SetResolution(Screen.resolutions[currResolutionIndex].width, Screen.resolutions[currResolutionIndex].height, isFullScreen);
    // }
}
