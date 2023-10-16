using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject pauseMenu;
    public GameObject settingsEmpty;
    public GameObject menuEmpty;

    public AudioSource menuSelect; // the audio source for the select button

    public AudioSource menuBack; // the audio source for the back button

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))//if the escape key is pressed
        {
            if (GameIsPaused)
                Resume();
            else
                Pause();
        }
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        menuSelect.Play();
        settingsEmpty.SetActive(false);
        menuEmpty.SetActive(true);
        Time.timeScale = 1f; // Set the time scale back to normal
        GameIsPaused = false;
        Debug.Log("Resumed");
    }

    private void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f; // Pause the game
        GameIsPaused = true;
        Debug.Log("Paused");
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f; // Set the time scale back to normal
        menuSelect.Play();
        SceneManager.LoadScene(0); // Load the main menu scene synchronously
        Debug.Log("Loading menu...");
    }

    public void QuitGame()//quits the game
    {
        menuSelect.Play();
        Application.Quit();
        Debug.Log("Quit");
    }

    public void back()//returns to the main menu
    {
        menuBack.Play();
        menuEmpty.SetActive(true);
        settingsEmpty.SetActive(false);
        Debug.Log("Back");
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

    public void settings()//opens the settings menu
    {
        menuSelect.Play();
        menuEmpty.SetActive(false);
        settingsEmpty.SetActive(true);
        Debug.Log("Settings");
    }
}
