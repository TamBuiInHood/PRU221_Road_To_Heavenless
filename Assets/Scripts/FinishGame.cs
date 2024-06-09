using UnityEngine;
using TMPro;

public class FinishGame : MonoBehaviour
{
    public GameObject finishPanel; // Reference to the finish panel
    public TMP_Text scoreText; // Reference to the score text UI
    private int totalScore; // Variable to keep track of the total score

    void Start()
    {
        finishPanel.SetActive(false); // Initially hide the finish panel
    }

    public void FinishValue()
    {
        finishPanel.SetActive(true); // Show the finish panel
        scoreText.text = totalScore.ToString(); // Display the total score
    }

    public void UpdateScore(int score)
    {
        totalScore += score; // Update the total score
    }
}