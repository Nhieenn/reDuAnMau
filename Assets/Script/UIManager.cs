using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public GameObject pauseButton;
    public GameObject pauseMenu;
    public GameObject cancelButton;
    public GameObject jumpButton;

    public TextMeshProUGUI pauseTimeText;
    [SerializeField] private GameManager gameManager;

    private AudioSource audioSource;
    public AudioClip touchSound;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
    }

    public void PauseButton()
    {
        audioSource.PlayOneShot(touchSound);
        Time.timeScale = 0f;
        pauseButton.SetActive(false);
        pauseMenu.SetActive(true);
        float currentTime = GameTimer.Instance.GetCurrentTime(); // lấy thời gian
        pauseTimeText.text =  currentTime.ToString("F2"); 
        jumpButton.SetActive(false); 
    }

    public void ResumeButton()
    {
        audioSource.PlayOneShot(touchSound);
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
        pauseButton.SetActive(true);
        jumpButton.SetActive(true);

    }

    public void PlayAgainButton()
    {
        audioSource.PlayOneShot(touchSound);
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);

        if (gameManager != null)
            gameManager.ResetGame();
        pauseButton.SetActive(true);
        jumpButton.SetActive(true);
    }

    public void QuitToMenuButton()
    {
        audioSource.PlayOneShot(touchSound);
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
        UnityEngine.SceneManagement.SceneManager.LoadScene("Home");

    }

    public void QuitGameButton()
    {
        audioSource.PlayOneShot(touchSound);
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
        Application.Quit();
    }
    
}
