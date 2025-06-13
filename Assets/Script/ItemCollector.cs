// ItemCollector.cs
using UnityEngine;

public class ItemCollector : MonoBehaviour
{
    public enum ItemType { Gold, Heart }
    public ItemType type;
    public int value = 1;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerInventory inventory = other.GetComponent<PlayerInventory>();
            if (inventory != null)
            {
                inventory.AddItem(type, value);
                Destroy(gameObject);
            }
        }
    }
}