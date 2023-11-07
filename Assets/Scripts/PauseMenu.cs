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
        activeMenu = menuEmpty; // Set the active menu to the Main menu
        Debug.Log("Back");
    }

    

    public void settings()
    {
        menuSelect.Play();
        menuEmpty.SetActive(false);
        settingsEmpty.SetActive(true);
        activeMenu = settingsEmpty; // Set the active menu to the Settings menu
        Debug.Log("Settings");
    }
}
