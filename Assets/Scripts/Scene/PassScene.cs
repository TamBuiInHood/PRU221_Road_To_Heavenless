using UnityEngine;
using UnityEngine.SceneManagement;

public class PassScene : MonoBehaviour
{
    [SerializeField] private string sceneName; // The name of the scene to load when the player touches the sign

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Pass to the specified scene
            SceneController.instance.NextLevel();
        }
    }
}