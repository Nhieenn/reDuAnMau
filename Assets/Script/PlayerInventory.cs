// PlayerInventory.cs
using UnityEngine;
using TMPro;

public class PlayerInventory : MonoBehaviour
{
    [Header("UI References")]
    public TMP_Text goldText;
    public TMP_Text heartText;

    public int gold = 0;
    public  int hearts = 0;
    PlayerInventory inventory;
    //public int Hearts
    //    {
    //    get => inventory.hearts;
    //    set => inventory.hearts = value;
    //}

    private void Start()
    {
        //inventory = GetComponent<PlayerInventory>();
        //inventory.hearts = hearts;

    }
    public void AddItem(ItemCollector.ItemType type, int amount)
    {
        switch (type)
        {
            case ItemCollector.ItemType.Gold:
                gold += amount;
                goldText.text = gold.ToString();
                break;
            case ItemCollector.ItemType.Heart:
                hearts += amount;
                heartText.text = hearts.ToString();
                break;
        }
    }

    public bool SpendGold(int amount)
    {
        if (gold >= amount)
        {
            gold -= amount;
            goldText.text = gold.ToString();
            return true;
        }
        return false;
    }
    
}