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
        itemsDisplay.text = items.ToString();
    }

    public void ChangeItems(int amount)
    {
        items += amount;
    }
}