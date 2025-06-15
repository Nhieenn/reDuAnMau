using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public GameObject pauseButton;
    public GameObject pauseMenu;
    public GameObject cancelButton;
    public GameManager gameManager;
    public TextMeshProUGUI pauseTimeText;
    void Start()
    {
    }

    void Update()
    {
    }

    public void PauseButton()
    {
        Time.timeScale = 0f;
        pauseButton.SetActive(false);
        pauseMenu.SetActive(true);
        float currentTime = GameTimer.Instance.GetCurrentTime(); // lấy thời gian
        pauseTimeText.text =  currentTime.ToString("F2"); 
    }

    public void ResumeButton()
    {
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
        pauseButton.SetActive(true);
    }

    public void PlayAgainButton()
    {
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);

        if (gameManager != null)
            gameManager.ResetGame();
    }

    public void QuitToMenuButton()
    {
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
        UnityEngine.SceneManagement.SceneManager.LoadScene("Home");
    }

    public void QuitGameButton()
    {
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
        Application.Quit();
    }
}
