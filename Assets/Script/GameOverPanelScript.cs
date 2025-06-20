using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class GameOverPanelScript : MonoBehaviour
{

    [Header("Game Objects")]
    public GameObject cancelButton;
    public GameObject restartButton;
    public GameObject mainMenuButton;
    public GameObject quitButton;
    public TextMeshProUGUI time;
    public TextMeshProUGUI gameoverText;
    public GameObject gameoverPanel;
    public GameObject jumpButton;
    public PlayerController playerController;
    public PlayerInventory playerInventory;
    public GameTimer gameTimer;
    [SerializeField] private GameManager gameManager;

    [Header("Audio")]
    public AudioClip touchSound;
    private AudioSource audioSource;


    [Header("Restart")]
    private Vector3 startPosition;
    void Start()
    {
        startPosition = transform.position;
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void CanCelButton()
    {
        audioSource.PlayOneShot(touchSound);

        gameoverPanel.SetActive(false);
        Time.timeScale = 1f; // Reset time scale to normal
        jumpButton.SetActive(true); 

    }
    public void RestartButton()
    {
        audioSource.PlayOneShot(touchSound);

        Time.timeScale = 1f;
        gameoverPanel.SetActive(false);

        if (gameManager != null)
            gameManager.ResetGame();
        jumpButton.SetActive(true);
    }

    public void MainMenuButton()
    {
        audioSource.PlayOneShot(touchSound);

        Time.timeScale = 1f;
        gameoverPanel.SetActive(false);

        if (gameManager != null)
            gameManager.ResetGame();
        gameoverPanel.SetActive(false);

        UnityEngine.SceneManagement.SceneManager.LoadScene("Home");
    }
    public void QuitButton()
    {
        audioSource.PlayOneShot(touchSound);

        gameoverPanel.SetActive(false);
      
        Application.Quit();
    }
    public void ShowGameOverPanel(float timeSurvived)
    {
       // audioSource.PlayOneShot(touchSound);

        // Debug.Log("ShowGameOverPanel gọi với thời gian: " + timeSurvived);
        gameoverPanel.SetActive(true);
        jumpButton.SetActive(false);
        gameoverText.text = "Game Over";

        time.text =  timeSurvived.ToString("F2");


        float bestScore = PlayerPrefs.GetFloat("BestScore", 0f);
        if (timeSurvived > bestScore)
        {
            PlayerPrefs.SetFloat("BestScore", timeSurvived);
            PlayerPrefs.Save();
        }


       


    }
   
    


}
