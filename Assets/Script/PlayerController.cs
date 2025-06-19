using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    [Header("Sound Effects")]
    public AudioClip jumpSound;
    public AudioClip damageSound;
    private AudioSource audioSource;

    [Header("Game Objects")]
    public GameObject gameOverPanel;

    [Header("Movement")]
    public float jumpForce = 5f;
    private Rigidbody2D rb;
    private Animator animator;

    [Header("Damage System")]
    public int hearts = 3;
    public float damageInterval = 0.2f;
    private float nextDamageTime;

    private bool isDead = false;

    [Header("Visual Effects")]
    public Color flashColor = Color.red;
    public float flashDuration = 0.2f;
    private SpriteRenderer spriteRenderer;
    private Color originalColor;
    public float dieTimer = 0.1f;

    private PlayerInventory inventory;
    private Vector3 startPosition;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
        originalColor = spriteRenderer.color;
        nextDamageTime = Time.time;

        inventory = GetComponent<PlayerInventory>();
        inventory.hearts = hearts;
        inventory.playerController = this;

        startPosition = transform.position;
    }

    void Update()
    {
        if (isDead) return;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            audioSource.PlayOneShot(jumpSound);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            if (Time.time >= nextDamageTime)
            {
                ApplyDamage();
                nextDamageTime = Time.time + damageInterval;
            }
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            ApplyDamage();
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            if (Time.time >= nextDamageTime)
            {
                ApplyDamage();
                nextDamageTime = Time.time + damageInterval;
            }
        }
    }

    private void ApplyDamage()
    {
        if (isDead || hearts <= 0) return;

        audioSource.PlayOneShot(damageSound);
        hearts -= 1;
        inventory.hearts = hearts;
        inventory.UpdateHeartUI();
        Debug.Log("Máu còn lại: " + hearts);
        StartCoroutine(FlashEffect());

        if (hearts <= 0)
        {
            Debug.Log("Chết");
            StartCoroutine(Die());
        }
    }

    private IEnumerator FlashEffect()
    {
        spriteRenderer.color = flashColor;
        yield return new WaitForSeconds(flashDuration);
        spriteRenderer.color = originalColor;
    }

    private IEnumerator Die()
    {
        isDead = true;

        float survivalTime = GameTimer.Instance.GetCurrentTime();
        animator.SetTrigger("Die");
        GameTimer.Instance.StopTimer();

        yield return new WaitForSecondsRealtime(dieTimer);

        Debug.Log($"Thời gian sống: {survivalTime:F2} giây");
        GameTimer.Instance.ResetTimer();

        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
            GameOverPanelScript gameOver = gameOverPanel.GetComponent<GameOverPanelScript>();
            if (gameOver != null)
            {
                gameOver.ShowGameOverPanel(survivalTime);
            }
        }

        Time.timeScale = 0f;
        StartCoroutine(FadeOutAudio(4.5f)); // Thêm fade out âm thanh trong 2 giây
    }

    private IEnumerator FadeOutAudio(float duration)
    {
        float startVolume = AudioListener.volume;
        float t = 0f;

        while (t < duration)
        {
            t += Time.unscaledDeltaTime;
            AudioListener.volume = Mathf.Lerp(startVolume, 0f, t / duration);
            yield return null;
        }

        AudioListener.volume = 0f;
    }

    public void FullReset(Vector3 newStartPos)
    {
        StopAllCoroutines();
        transform.position = newStartPos;
        rb.linearVelocity = Vector2.zero;
        animator.Play("PlayerMove", 0, 0);
        isDead = false;
        hearts = 3;

        if (inventory != null)
        {
            inventory.hearts = hearts;
            inventory.UpdateHeartUI();
        }

        spriteRenderer.color = originalColor;

        Time.timeScale = 1f;
        AudioListener.pause = false;
        AudioListener.volume = 1f;
    }
}
