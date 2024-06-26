using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [Header("Component")]
    public TextMeshProUGUI timerText;

    [Header("Timer Settings")]
    public float currentTime;
    public bool countDown;

    void Start()
    {
        // Optionally initialize currentTime
    }

    void Update()
    {
        // Update the timer based on countDown flag
        if (countDown)
        {
            currentTime -= Time.deltaTime;
        }
        else
        {
            currentTime += Time.deltaTime;
        }

        // Format the time to display two decimal places
        timerText.text = currentTime.ToString("F2");
    }

    public float GetCurrentTime()
    {
        return currentTime;
    }
}
