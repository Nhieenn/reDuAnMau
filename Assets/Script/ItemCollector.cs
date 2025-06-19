// ItemCollector.cs
using UnityEngine;

public class ItemCollector : MonoBehaviour
{
    public AudioClip collectSound;
    private AudioSource audioSource;
    public enum ItemType { Gold, Heart }
    public ItemType type;
    public int value = 1;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            audioSource.PlayOneShot(collectSound);
            Debug.Log("Nhat do");
          
            PlayerInventory inventory = other.GetComponent<PlayerInventory>();
            if (inventory != null)
            {
                inventory.AddItem(type, value);

                Destroy(gameObject, collectSound.length);
            }
        }
    }
}