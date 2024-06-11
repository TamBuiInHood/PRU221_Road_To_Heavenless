using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeSceneMenu : MonoBehaviour
{
    // This method will be called when the button is clicked
    public void OnButtonClick(string sceneName)
    {
        // Load the scene with the given name
        SceneManager.LoadScene(1);
    }
}
