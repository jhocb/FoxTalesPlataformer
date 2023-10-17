using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class mainMenu : MonoBehaviour
{
    public GameObject mainEmpty; // the main menu
    public GameObject settingsEmpty; // the settings menu
    public GameObject creditsEmpty; // the credits menu

    public GameObject LoadingScreen; // the loading screen
    public Image LoadingBar; // the loading bar

    private float progress; // the progress of the loading bar

    /*public void playGame()//loads the next scene in the build index
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Debug.Log("Play");
    }*/

    public void Start()
    {
        progress = 0;
    }
    public void playGame()
    {
        
        StartCoroutine(LoadAsyncScene());
    }

    public IEnumerator LoadAsyncScene()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);

        LoadingScreen.SetActive(true);

        while (!asyncLoad.isDone)
        {
            Debug.Log("Loading Progress: " + asyncLoad.progress);
            progress = Mathf.Clamp01(asyncLoad.progress / 0.9f);
            LoadingBar.fillAmount = progress;
            yield return null;
            Debug.Log("Loading Progress: " + asyncLoad.progress);
        }
    }

    public void quitGame()//quits the game
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void SetUltraQuality()//sets the quality to ultra
    {
        QualitySettings.SetQualityLevel(0);
        Debug.Log("Ultra");
    }

    public void SetHighQuality()//sets the quality to high
    {
        QualitySettings.SetQualityLevel(1);
        Debug.Log("High");
    }

    public void SetMediumQuality()//sets the quality to medium
    {
        QualitySettings.SetQualityLevel(2);
        Debug.Log("Medium");
    }

    public void SetLowQuality()//sets the quality to low
    {
        QualitySettings.SetQualityLevel(3);
        Debug.Log("Low");
    }

    public void settings()//opens the settings menu
    {
        mainEmpty.SetActive(false);
        settingsEmpty.SetActive(true);
        creditsEmpty.SetActive(false);
        Debug.Log("Settings");
    }

    public void credits()//opens the credits menu
    {
        mainEmpty.SetActive(false);
        settingsEmpty.SetActive(false);
        creditsEmpty.SetActive(true);
        Debug.Log("Credits");
    }

    public void back()//returns to the main menu
    {
        mainEmpty.SetActive(true);
        settingsEmpty.SetActive(false);
        creditsEmpty.SetActive(false);
        Debug.Log("Back");
    }
}

