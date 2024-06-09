using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class QuestionManager : MonoBehaviour
{
    public static QuestionManager Instance;

    public GameObject panelQuestion;
    public TMP_Text questionText;
    public TMP_Text[] answerTexts;
    public Button[] answerButtons;
    [SerializeField] private int value;

    private int correctAnswerIndex;
    private Vector3 playerStartPosition;
    private ItemManager itemManager;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        // Assuming the player has a tag "Player" and its initial position is the respawn position
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            playerStartPosition = player.transform.position;
        }
        else
        {
            Debug.LogError("Player GameObject not found.");
        }

        //item manager
        itemManager = ItemManager.Instance;
        if (itemManager == null)
        {
            Debug.LogError("ItemManager instance not found.");
        }
    }

    public void ShowQuestion(string question, string[] answers, int correctAnswer)
    {
        if (panelQuestion != null)
        {
            panelQuestion.SetActive(true);
            questionText.text = question;
            correctAnswerIndex = correctAnswer;

            for (int i = 0; i < answerTexts.Length; i++)
            {
                if (i < answers.Length)
                {
                    answerTexts[i].text = answers[i];
                    answerButtons[i].gameObject.SetActive(true);
                    int answerIndex = i; // Capture the index for the lambda closure
                    answerButtons[i].onClick.RemoveAllListeners(); // Remove previous listeners
                    answerButtons[i].onClick.AddListener(() => OnClickAnswer(answerIndex));
                }
                else
                {
                    answerButtons[i].gameObject.SetActive(false);
                }
            }
        }
        else
        {
            Debug.LogError("PanelQuestion GameObject not assigned.");
        }
    }

    public void OnClickAnswer(int answerIndex)
    {
        if (answerIndex == correctAnswerIndex)
        {
            Debug.Log("Correct answer!");
            // Make the "Monster" tagged GameObject disappear
            GameObject monster = GameObject.FindGameObjectWithTag("Monster");
            if (monster != null)
            {
                monster.SetActive(false);
            }

            // Add reward value to the item manager
            if (itemManager != null)
            {
                itemManager.ChangeItems(value);
            }
        }
        else
        {
            Debug.Log("Wrong answer!");
            // Respawn the player at the start position
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
            {
                player.transform.position = playerStartPosition;
            }

            GameObject monster = GameObject.FindGameObjectWithTag("Monster");
            if (monster != null)
            {
                monster.SetActive(false);
            }
        }
        panelQuestion.SetActive(false); // Hide the panel after an answer is selected
    }
}


