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
    public GameObject videoEmpty;
    public GameObject audioEmpty;

    public AudioSource menuSelect;
    public AudioSource menuBack;

    private GameObject activeMenu;

    private void Start()
    {
        activeMenu = pauseMenu; // Start with the Pause menu as the active menu
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        menuEmpty.SetActive(true);
        settingsEmpty.SetActive(false);
        videoEmpty.SetActive(false);
        audioEmpty.SetActive(false);

        activeMenu.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        Debug.Log("Resumed");
    }

    private void Pause()
    {
        activeMenu.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        Debug.Log("Paused");
    }

    public void LoadMenu()
    {
        Resume();
        SceneManager.LoadScene(0);
        Debug.Log("Loading menu...");
    }

    public void QuitGame()
    {
        menuSelect.Play();
        Application.Quit();
        Debug.Log("Quit");
    }

    public void back()
    {
        menuBack.Play();
        menuEmpty.SetActive(true);
        settingsEmpty.SetActive(false);
        activeMenu = menuEmpty; // Set the active menu to the Pause menu
        Debug.Log("Back");
    }

    public void backSettings()
    {
        menuSelect.Play();
        videoEmpty.SetActive(false);
        audioEmpty.SetActive(false);
        settingsEmpty.SetActive(true);
        activeMenu = settingsEmpty; // Set the active menu to the Settings menu from audioEmpty or videoEmpty
        Debug.Log("Settings");
    }

    public void settings()
    {
        menuSelect.Play();
        menuEmpty.SetActive(false);
        settingsEmpty.SetActive(true);
        activeMenu = settingsEmpty; // Set the active menu to the Settings menu
        Debug.Log("Settings");
    }


    public void audio()
    {
        menuSelect.Play();
        settingsEmpty.SetActive(false);
        audioEmpty.SetActive(true);
        activeMenu = audioEmpty; // Set the active menu to the Audio menu
        Debug.Log("Audio");
    }

    public void video()
    {
        menuSelect.Play();
        settingsEmpty.SetActive(false);
        videoEmpty.SetActive(true);
        activeMenu = videoEmpty; // Set the active menu to the Video menu
        Debug.Log("Video");
    }
}
