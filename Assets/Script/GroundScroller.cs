using UnityEngine;

public class GroundScroller : MonoBehaviour
{
    public float moveSpeed = 6f;
    public float groundLength = 500f; // chính xác khoảng cách tâm tới tâm
    public Transform player;

    void Update()
    {
        transform.position += Vector3.left * moveSpeed * Time.deltaTime;

        // Nếu nền đi ra ngoài màn hình bên trái (vượt khỏi player)
        if (transform.position.x < player.position.x - groundLength)
        {
            Reposition();
        }
    }

    void Reposition()
    {
        // Dời nền này sang bên phải, nối tiếp nền cuối cùng
        transform.position += Vector3.right * groundLength * NumberOfGroundTiles();
    }

    int NumberOfGroundTiles()
    {
        return 7; // hoặc 3 tùy số lượng ground bạn tạo
    }
}
