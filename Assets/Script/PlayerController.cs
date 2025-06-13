using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    [Header("Game Objects")]
    public GameObject gameOverPanel;

    [Header("Movement")]
    public float jumpForce = 5f;
    private Rigidbody2D rb;
    private Animator animator;

    [Header("Damage System")]
    public int hearts = 1;
    public float damageInterval = 0.2f;
    private float _nextDamageTime;
    
    private bool _isDead = false;
    private bool _isOnGround;
    [Header("Visual Effects")]
    public Color flashColor = Color.red;
    public float flashDuration = 0.2f;
    private SpriteRenderer spriteRenderer;
    private Color originalColor;
    public float dieTimer = 1f;

    private PlayerInventory inventory;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;
        _nextDamageTime = Time.time; // Khởi tạo thời gian


        inventory = GetComponent<PlayerInventory>();
        inventory.hearts = hearts;
    }
    public static PlayerController pc;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            //animator.SetTrigger("Jump");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            //_isOnGround = true;
            if (Time.time >= _nextDamageTime)
            {
                ApplyDamage();
                _nextDamageTime = Time.time + damageInterval;
            }
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            if (Time.time >= _nextDamageTime)
            {
                ApplyDamage();
                _nextDamageTime = Time.time + damageInterval;
            }
        }
    }

    private void ApplyDamage()
    {
        if (_isDead || hearts <= 0) return;

        hearts-=1;
        inventory.hearts = hearts;
        Debug.Log("Máu còn lại: " + hearts);
        StartCoroutine(FlashEffect());

        if (hearts <= 0)
        {
            Debug.Log("Chết");
            _isDead = true;
            StartCoroutine(Die());
        }
    }


    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            //_isOnGround = false;
            ResetColor();
        }
    }

    private IEnumerator FlashEffect()
    {
        spriteRenderer.color = flashColor;
        yield return new WaitForSeconds(flashDuration);
        //if (!_isOnGround) spriteRenderer.color = originalColor;
        spriteRenderer.color = originalColor;
    }

    private void ResetColor()
    {
        if (!_isOnGround) spriteRenderer.color = originalColor;
    }

    private IEnumerator Die()
    {
        float survivalTime = GameTimer.Instance.GetCurrentTime();
        animator.SetTrigger("Die");
        GameTimer.Instance.StopTimer();

        yield return new WaitForSeconds(dieTimer);

        Debug.Log($"Thời gian sống: {survivalTime:F2} giây");
        GameTimer.Instance.ResetTimer();
        gameOverPanel.SetActive(true);
    }
}