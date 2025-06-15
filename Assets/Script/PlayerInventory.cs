// PlayerInventory.cs
using UnityEngine;
using TMPro;

public class PlayerInventory : MonoBehaviour
{
    [Header("UI References")]
    public TMP_Text goldText;
    public TMP_Text heartText;

  //  public int gold = 0;
    public  int hearts = 3;
    PlayerInventory inventory;
    public PlayerController playerController;
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
            //case ItemCollector.ItemType.Gold:
            //    gold += amount;
            //    goldText.text = gold.ToString();
            //    break;
            case ItemCollector.ItemType.Heart:
                if (hearts < 3)
                {
                    hearts += amount;

                    // Đảm bảo không vượt quá 3
                    if (hearts > 3) hearts = 3;

                    heartText.text = hearts.ToString();

                }
                break;
        }


        if (playerController != null)
        {
            playerController.hearts = hearts;
        }

    }

    //public bool SpendGold(int amount)
    //{
    //    if (gold >= amount)
    //    {
    //        gold -= amount;
    //        goldText.text = gold.ToString();
    //        return true;
    //    }
    //    return false;
    //}
    public void UpdateHeartUI()
    {
        heartText.text = hearts.ToString();
    }
    public void ResetHearts(int defaultHearts = 3)
    {
        hearts = defaultHearts; ;
        UpdateHeartUI();
        if (playerController != null)
            playerController.hearts = hearts;
        //UIManager.Instance.UpdateHearts(hearts);
    }


}