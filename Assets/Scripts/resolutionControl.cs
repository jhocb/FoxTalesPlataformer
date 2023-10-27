using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class resolutionControl : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown resolutionDropdown;

    private Resolution[] resolutions;
    private List<Resolution> filteredResolutions;

    private float currentRefreshRate;

    public AudioSource menuSelect;
    public AudioSource menuBack;

    private int currentResolutionIndex = 0;

    private const string ResolutionWidthKey = "ResolutionWidth";
    private const string ResolutionHeightKey = "ResolutionHeight";
    private const string FullscreenKey = "IsFullscreen";

    // Start is called before the first frame update
    void Start()
    {
        resolutions = Screen.resolutions;
        filteredResolutions = new List<Resolution>();

        resolutionDropdown.ClearOptions();
        currentRefreshRate = Screen.currentResolution.refreshRate;

        for (int i = 0; i < resolutions.Length; i++)
        {
            if (resolutions[i].refreshRate == currentRefreshRate)
            {
                filteredResolutions.Add(resolutions[i]);
            }
        }

        List<string> options = new List<string>();

        for (int i = 0; i < filteredResolutions.Count; i++)
        {
            string option = filteredResolutions[i].width + " x " + filteredResolutions[i].height;
            options.Add(option);

            if (filteredResolutions[i].width == Screen.currentResolution.width && filteredResolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = filteredResolutions[resolutionIndex];
        menuSelect.Play();
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);

        // Store the selected resolution in PlayerPrefs
        PlayerPrefs.SetInt(ResolutionWidthKey, resolution.width);
        PlayerPrefs.SetInt(ResolutionHeightKey, resolution.height);
        PlayerPrefs.Save();
    }

    public void SetFullscreen()
    {
        menuSelect.Play();
        Screen.fullScreen = true;

        // Store the fullscreen mode in PlayerPrefs
        PlayerPrefs.SetInt(FullscreenKey, 1); // 1 represents fullscreen
        PlayerPrefs.Save();
    }

    public void SetWindowed()
    {
        menuSelect.Play();
        Screen.fullScreen = false;

        // Store the windowed mode in PlayerPrefs
        PlayerPrefs.SetInt(FullscreenKey, 0); // 0 represents windowed
        PlayerPrefs.Save();
    }

    // Call this method at the start of the game to apply the stored settings
    public void ApplyStoredSettings()
    {
        int storedWidth = PlayerPrefs.GetInt(ResolutionWidthKey, Screen.currentResolution.width);
        int storedHeight = PlayerPrefs.GetInt(ResolutionHeightKey, Screen.currentResolution.height);
        int storedFullscreen = PlayerPrefs.GetInt(FullscreenKey, Screen.fullScreen ? 1 : 0);

        Resolution storedResolution = new Resolution
        {
            width = storedWidth,
            height = storedHeight
        };

        // Set the resolution and fullscreen/windowed mode based on stored settings
        Screen.SetResolution(storedResolution.width, storedResolution.height, storedFullscreen == 1);
    }
}
