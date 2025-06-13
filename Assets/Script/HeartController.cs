using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }


    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player")){
            Debug.Log("Da thu thap mau");
            Destroy(gameObject);

        }

    }
}
