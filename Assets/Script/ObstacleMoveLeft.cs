using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float moveSpeed = 5f;

    void Update()
    {
        transform.position += Vector3.left * moveSpeed * Time.deltaTime;

        // Nếu chạy quá khỏi màn hình bên trái thì xóa để tránh đầy bộ nhớ
        if (transform.position.x < -30f)
        {
            Destroy(gameObject);
        }
    }
}
