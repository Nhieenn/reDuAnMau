using UnityEngine;

public class BackgroundLooper : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float bgLength = 50f; // chiều dài của ảnh nền
    public Transform player;

    void Update()
    {
        transform.position += Vector3.left * moveSpeed * Time.deltaTime;

        if (transform.position.x < player.position.x - bgLength)
        {
            Reposition();
        }
    }

    void Reposition()
    {
        transform.position += Vector3.right * bgLength * 2; //  dùng 2 ảnh nối nhau
    }
}
