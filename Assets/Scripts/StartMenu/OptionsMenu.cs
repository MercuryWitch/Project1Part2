using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using TMPro;

public class OptionsMenu : MonoBehaviour {

    public AudioMixer audioMixer;
    public TMP_Dropdown resolutionDropdown;
    private Resolution[] resolutions;

    private void Start() {
        resolutions = Screen.resolutions;

        resolutionDropdown.ClearOptions();  // Clears the default resolution dropdown options
        int currentResolutionIndex = 0;
        List<string> options = new List<string>();  // A list of strings for storing resolution parameters, for dropdown display.
        for (int i = 0; i < resolutions.Length; i++) {
            string option = resolutions[i].width + "x" + resolutions[i].height; // Format a "Width x Height" string
            options.Add(option);

            // Check if the current screen resolution matches the resolution we're looping past.
            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height) {
                currentResolutionIndex = i; // If so, set currentResolutionIndex = i.
            }
        }

        resolutionDropdown.AddOptions(options); // Adds those strings to the dropdown menu
        resolutionDropdown.value = currentResolutionIndex; // Sets the default dropdown menu value to the current resolution.
        resolutionDropdown.RefreshShownValue(); // Updates the value of the dropdown menu.
    }

    // Options menu volume control.
    public void SetVolume(float volume) {
        audioMixer.SetFloat("MenuVolume", volume);
        //Debug.Log(volume);
    }

    // Options menu graphics quality control.
    public void SetQuality(int qualityIndex) {
        QualitySettings.SetQualityLevel(qualityIndex);
        //Debug.Log(qualityIndex);
    }

    // Options menu fullscreen control.
    public void SetFullscreen(bool isFullscreen) {
        Screen.fullScreen = isFullscreen;
    }

    // Options menu resolution dropdown control.
    public void SetResolution(int resolutionIndex) {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
}
