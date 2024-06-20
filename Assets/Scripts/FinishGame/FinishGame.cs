using UnityEngine;
using TMPro;

public class FinishGame : MonoBehaviour
{
    public GameObject finishPanel; // Reference to the finish panel
    public TMP_Text scoreText; // Reference to the score text UI
    public TMP_Text timeText; // Reference to the time text UI
    private Timer timer; // Reference to the Timer script

    void Start()
    {
        finishPanel.SetActive(false); // Initially hide the finish panel
        FindTimer();
    }

    void FindTimer()
    {
        timer = FindObjectOfType<Timer>(); // Find the Timer script in the scene

        if (timer == null)
        {
            Debug.LogError("Timer script not found in the scene.");
        }
        else
        {
            Debug.Log("Timer script found successfully.");
        }
    }

    public void FinishValue()
    {
        if (timer == null)
        {
            FindTimer();
        }

        if (timer != null)
        {
            finishPanel.SetActive(true); // Show the finish panel
            scoreText.text = ItemManager.Instance.GetTotalItems().ToString(); // Display the total score
            Debug.Log("Score: " + scoreText.text);

            timer.StopTimer(); // Ensure the timer is stopped
            timeText.text = timer.GetCurrentTime().ToString("F2"); // Display the total time
            Debug.Log("Time: " + timeText.text);
        }
        else
        {
            Debug.LogError("Timer reference is null in FinishValue method.");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Assuming the player has the tag "Player"
        {
            FinishValue();
        }
    }
}
