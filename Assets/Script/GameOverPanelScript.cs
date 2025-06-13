using UnityEngine;
using TMPro;
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
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void CanCelButton()
    {

        
        gameoverPanel.SetActive(false);

    }
    public void RestartButton()
    {
        gameoverPanel.SetActive(false);
        // Add logic to restart the game
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);

    }
    public void MainMenuButton()
    {
        gameoverPanel.SetActive(false);
        // Add logic to go to the main menu
        UnityEngine.SceneManagement.SceneManager.LoadScene("Home");
    }
    public void QuitButton()
    {
        gameoverPanel.SetActive(false);
        // Add logic to quit the game
        Application.Quit();
    }
    public void ShowGameOverPanel(float timeSurvived)
    {
        gameoverPanel.SetActive(true);
        time.text = "Time Survived: " + timeSurvived.ToString("F2") + " seconds";
        gameoverText.text = "Game Over";
    }


}
