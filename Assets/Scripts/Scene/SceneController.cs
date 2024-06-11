using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public static SceneController instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void NextLevel()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // Load a scene by its index
    public void LoadScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    // Load a scene by its name
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    // Load a scene by its name or index based on input type
    public void LoadSceneByNameOrIndex(object sceneIdentifier)
    {
        if (sceneIdentifier is int)
        {
            LoadScene((int)sceneIdentifier);
        }
        else if (sceneIdentifier is string)
        {
            LoadScene((string)sceneIdentifier);
        }
        else
        {
            Debug.LogError("Invalid scene identifier type. Use a string or an int.");
        }
    }
}
