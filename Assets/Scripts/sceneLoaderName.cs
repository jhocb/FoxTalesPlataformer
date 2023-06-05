using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneLoaderName : MonoBehaviour
{
    public string loadSceneName;       // The name of the scene to load
    public string unloadSceneName;     // The name of the scene to unload
    private bool hasLoadedScene = false;

    // Called when the collider attached to this object exits another collider
    private void OnTriggerExit(Collider other)
    {
        if (!hasLoadedScene)     // Check if the scene has already been loaded
        {
            hasLoadedScene = true;      // Set the flag to true to prevent loading the scene multiple times
            StartCoroutine(LoadAndUnloadScenes());    // Start the coroutine for loading and unloading scenes
        }
    }

    // Coroutine that loads the specified scene and unloads another scene
    private IEnumerator LoadAndUnloadScenes()
    {
        // Start loading the specified scene in the background
        AsyncOperation loadOperation = SceneManager.LoadSceneAsync(loadSceneName, LoadSceneMode.Additive);
        Debug.Log("Loading scene " + loadSceneName);

        // Wait until the loading operation is complete
        while (!loadOperation.isDone)
        {
            yield return null;   // Pause the execution of this coroutine until the next frame
        }

        // Check if the unloadSceneName is valid and loaded in the scene list
        if (!string.IsNullOrEmpty(unloadSceneName) && SceneManager.GetSceneByName(unloadSceneName).isLoaded)
        {
            // Unload the scene asynchronously
            SceneManager.UnloadSceneAsync(unloadSceneName);
            Debug.Log("Unloading scene " + unloadSceneName);
            hasLoadedScene = false;     // Reset the flag
        }
        else
        {
            // Display a warning if the unload scene name is invalid or the scene is not loaded
            Debug.LogWarning("Unload scene name is invalid or scene is not loaded.");
        }
    }
}
