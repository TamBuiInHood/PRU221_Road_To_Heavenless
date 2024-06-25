using UnityEngine;
using TMPro;

public class ItemManager : MonoBehaviour
{
    public static ItemManager Instance;

    private int items;
    [SerializeField] private TMP_Text itemsDisplay;

    private void Awake()
    {
        if (!Instance)
        {
            Instance = this;
        }
    }

    private void OnGUI()
    {
        itemsDisplay.text = SceneController.Point.ToString();
    }

    public void ChangeItems(int amount)
    {
        SceneController.Point += amount;
        Debug.Log($"item: {SceneController.Point}");
    }

    public int GetTotalItems()
    {
        return SceneController.Point;
    }
}
