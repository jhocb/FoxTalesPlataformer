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

    public void Start()
    {
        progress = 0;
    }

    public void playGame()
    {
        menuSelect.Play();
        StartCoroutine(LoadAsyncScene());
    }

    public IEnumerator LoadAsyncScene()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);

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

       public void SetUltraQuality()//sets the quality to ultra
        {
            menuSelect.Play();
            QualitySettings.SetQualityLevel(0);
            Debug.Log("Ultra");
        }

        public void SetHighQuality()//sets the quality to high
        {
            menuSelect.Play();
            QualitySettings.SetQualityLevel(1);
            Debug.Log("High");
        }

        public void SetMediumQuality()//sets the quality to medium
        {
            menuSelect.Play();
            QualitySettings.SetQualityLevel(2);
            Debug.Log("Medium");
        }

        public void SetLowQuality()//sets the quality to low
        {
            menuSelect.Play();
            QualitySettings.SetQualityLevel(3);
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
