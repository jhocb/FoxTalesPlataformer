using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneLoader : MonoBehaviour
{
    public int loadSceneIndex;       // The index of the scene to load
    public int unloadSceneIndex;     // The index of the scene to unload
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
        AsyncOperation loadOperation = SceneManager.LoadSceneAsync(loadSceneIndex, LoadSceneMode.Additive);
        Debug.Log("Loading scene " + loadSceneIndex);

        // Wait until the loading operation is complete
        while (!loadOperation.isDone)
        {
            yield return null;   // Pause the execution of this coroutine until the next frame
        }

        // Check if the unloadSceneIndex is valid and within the loaded scene count
        if (unloadSceneIndex >= 0 && unloadSceneIndex < SceneManager.sceneCount)
        {
            // Get the reference to the scene to unload
            Scene unloadScene = SceneManager.GetSceneAt(unloadSceneIndex);
            // Unload the scene asynchronously
            SceneManager.UnloadSceneAsync(unloadScene);
            Debug.Log("Unloading scene " + unloadSceneIndex);
            hasLoadedScene = false;     // Reset the flag
        }
        else
        {
            // Display a warning if the unload scene index is invalid or the scene is not loaded
            Debug.LogWarning("Unload scene index is invalid or scene is not loaded.");
        }
    }
}

