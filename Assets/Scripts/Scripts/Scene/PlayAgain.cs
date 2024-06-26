using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayAgain : MonoBehaviour
{
    // This method will be called when the button is clicked
    public void OnButtonClick(string sceneName)
    {
        // Load the scene with the given name
        SceneManager.LoadScene(1);
    }
}