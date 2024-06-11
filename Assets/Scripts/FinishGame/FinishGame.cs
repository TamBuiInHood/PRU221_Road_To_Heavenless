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
        timer = FindObjectOfType<Timer>(); // Find the Timer script in the scene
    }

    public void FinishValue()
    {
        finishPanel.SetActive(true); // Show the finish panel
        scoreText.text = ItemManager.Instance.GetTotalItems().ToString(); // Display the total score
        timeText.text = timer.GetCurrentTime().ToString("F2"); // Display the total time
    }
}
