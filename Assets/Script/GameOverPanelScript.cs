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
    public PlayerController playerController;
    public PlayerInventory playerInventory;
    public GameTimer gameTimer;
    public GameManager gameManager;
   

    [Header("Restart")]
    private Vector3 startPosition;
    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void CanCelButton()
    {

        
        gameoverPanel.SetActive(false);
        Time.timeScale = 1f; // Reset time scale to normal

    }
    public void RestartButton()
    {
        Time.timeScale = 1f;
        gameoverPanel.SetActive(false);

        if (gameManager != null)
            gameManager.ResetGame();
    }

    public void MainMenuButton()
    {
        Time.timeScale = 1f;
        gameoverPanel.SetActive(false);

        if (gameManager != null)
            gameManager.ResetGame();
        gameoverPanel.SetActive(false);

        UnityEngine.SceneManagement.SceneManager.LoadScene("Home");
    }
    public void QuitButton()
    {
        gameoverPanel.SetActive(false);
      
        Application.Quit();
    }
    public void ShowGameOverPanel(float timeSurvived)
    {
       // Debug.Log("ShowGameOverPanel gọi với thời gian: " + timeSurvived);
        gameoverPanel.SetActive(true);
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
