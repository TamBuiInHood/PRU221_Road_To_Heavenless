/*using UnityEngine;
using TMPro;
using UnityEditor;

public class Timer : MonoBehaviour
{
    [Header("Component")]
    public TextMeshProUGUI timerText;

    [Header("Timer Settings")]
    public float currentTime;
    public bool countDown;

    void Start()
    {

    }

    private void OnEnable()
    {
        // Optionally initialize currentTime
        //if check null get scene
        Debug.Log($"currenttime: {currentTime}");
        if (currentTime == null)
        {
            currentTime = EditorPrefs.GetFloat("time");
            timerText.text = currentTime.ToString("F2");
        }
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

        //session set Time.deltaTime;
        EditorPrefs.SetFloat("time", currentTime);

    }

    public float GetCurrentTime()
    {
        return currentTime;
    }
}*/


using UnityEngine;
using TMPro;
using UnityEditor;

public class Timer : MonoBehaviour
{
    [Header("Component")]
    public TextMeshProUGUI timerText;

    [Header("Timer Settings")]
    public float currentTime;
    public bool countDown;

    private bool isRunning;

    void Start()
    {
        // Reset the timer when the scene starts
        currentTime = 0f;
        if (timerText != null)
        {
            timerText.text = currentTime.ToString("F2");
        }
        isRunning = true;
    }

    private void OnEnable()
    {
        // Initialize currentTime from EditorPrefs if it's still 0 after Start
        if (currentTime == 0)
        {
            currentTime = EditorPrefs.GetFloat("time", 0f); // Default to 0 if no saved value
        }
        if (timerText != null)
        {
            timerText.text = currentTime.ToString("F2");
        }
        isRunning = true;
    }

    void Update()
    {
        if (isRunning)
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
            if (timerText != null)
            {
                timerText.text = currentTime.ToString("F2");
            }

            // Save the current time to EditorPrefs
            EditorPrefs.SetFloat("time", currentTime);
        }
    }

    public void StopTimer()
    {
        isRunning = false;
    }

    public float GetCurrentTime()
    {
        return currentTime;
    }
}


