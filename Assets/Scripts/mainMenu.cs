using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class mainMenu : MonoBehaviour
{
    public GameObject mainEmpty;
    public GameObject settingsEmpty;
    public GameObject creditsEmpty;
    public GameObject LoadingScreen;
    public Image LoadingBar;
    public AudioSource menuSelect;
    public AudioSource menuBack;

    private float progress;

    private const string QualityLevelKey = "QualityLevel";

    public void Start()
    {
        progress = 0;
        // Load and apply the quality level from PlayerPrefs
        if (PlayerPrefs.HasKey(QualityLevelKey))
        {
            int savedQualityLevel = PlayerPrefs.GetInt(QualityLevelKey);
            QualitySettings.SetQualityLevel(savedQualityLevel);
        }
    }

    public void playGame()
    {
        menuSelect.Play();
        StartCoroutine(LoadAsyncScene());
    }

    public IEnumerator LoadAsyncScene()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        SceneManager.LoadScene("Level1 New", LoadSceneMode.Additive);

        LoadingScreen.SetActive(true);

        while (!asyncLoad.isDone)
        {
            progress = Mathf.Clamp01(asyncLoad.progress / 0.9f);
            LoadingBar.fillAmount = progress;
            yield return null;
        }
    }

    public void quitGame()
    {
        Debug.Log("Quit");
        menuSelect.Play();
        Application.Quit();
    }

    public void SetUltraQuality() // sets the quality to ultra
    {
        menuSelect.Play();
        QualitySettings.SetQualityLevel(0);
        PlayerPrefs.SetInt(QualityLevelKey, 0); // Save the quality level to PlayerPrefs
        PlayerPrefs.Save();
        Debug.Log("Ultra");
    }

    public void SetHighQuality() // sets the quality to high
    {
        menuSelect.Play();
        QualitySettings.SetQualityLevel(1);
        PlayerPrefs.SetInt(QualityLevelKey, 1); // Save the quality level to PlayerPrefs
        PlayerPrefs.Save();
        Debug.Log("High");
    }

    public void SetMediumQuality() // sets the quality to medium
    {
        menuSelect.Play();
        QualitySettings.SetQualityLevel(2);
        PlayerPrefs.SetInt(QualityLevelKey, 2); // Save the quality level to PlayerPrefs
        PlayerPrefs.Save();
        Debug.Log("Medium");
    }

    public void SetLowQuality() // sets the quality to low
    {
        menuSelect.Play();
        QualitySettings.SetQualityLevel(3);
        PlayerPrefs.SetInt(QualityLevelKey, 3); // Save the quality level to PlayerPrefs
        PlayerPrefs.Save();
        Debug.Log("Low");
    }

    public void settings()
    {
        menuSelect.Play();
        mainEmpty.SetActive(false);
        settingsEmpty.SetActive(true);
        creditsEmpty.SetActive(false);
        Debug.Log("Settings");
    }

    public void credits()
    {
        menuSelect.Play();
        mainEmpty.SetActive(false);
        settingsEmpty.SetActive(false);
        creditsEmpty.SetActive(true);
        Debug.Log("Credits");
    }

    public void back()
    {
        menuBack.Play();
        mainEmpty.SetActive(true);
        settingsEmpty.SetActive(false);
        creditsEmpty.SetActive(false);
        Debug.Log("Back");
    }
}
