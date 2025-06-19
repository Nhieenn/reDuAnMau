using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float moveSpeed = 2f;
    private Rigidbody2D rb;
    public float attackRange = 2f;  // khoảng cách để bắt đầu tấn công

    private Animator animator;
    private Transform player;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(-moveSpeed, rb.linearVelocity.y);
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").transform;

        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        //if (distanceToPlayer <= attackRange)
        //{
        //    //Debug.Log("người chơi trong phạm vi");
        //    rb.linearVelocity = Vector2.zero;  // dừng di chuyển khi tấn công
        //    animator.SetBool("IsAttacking", true);
        //}
        //else
        //{
        //    rb.linearVelocity = new Vector2(-moveSpeed, rb.linearVelocity.y);
        //    animator.SetBool("IsAttacking", false);
        //}
    }

    private void Update()
    {
        transform.position += Vector3.left * moveSpeed * Time.deltaTime;

        // Nếu chạy quá khỏi màn hình bên trái thì xóa để tránh đầy bộ nhớ
        if (transform.position.x < -30f)
        {
            Destroy(gameObject);
        }
    }
}
