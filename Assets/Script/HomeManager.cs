using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class HomeManager : MonoBehaviour
{
    public TextMeshProUGUI bestScoreTime;
    [Header("Button")]
    public GameObject playButton;
    public GameObject quitButton;
    public GameObject guidButton;
    public GameObject creditButton;
    public GameObject cancelButton;
    public GameObject bestScorePanel;
    public GameManager gameManager;
    public GameObject guidPanel;
    public GameObject creditPanel;
    public GameObject cancelGuid;
    public GameObject cancelCredit;
    public GameObject bestScoreButton;
    public GameObject bgMusic;


    // Start is called once before the firt execution of Update after the MonoBehaviour is created
    void Start()
    {
        float bestScore = PlayerPrefs.GetFloat("BestScore", 0f);
        bestScoreTime.text =  bestScore.ToString("F2");
        bgMusic.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayButton()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMap");
        Time.timeScale = 1f;
        bgMusic.SetActive(false);
        // GamgameoverPanel.SetActive(false);

        //if (gameManager != null)
        //    gameManager.ResetGame();
    }
    public void QuitButton()
    {
        Application.Quit();
    }
    public void BestScoreButton()
    {
        bestScorePanel.SetActive(true);
        playButton.SetActive(false);
        quitButton.SetActive(false);
        guidButton.SetActive(false);
        creditButton.SetActive(false);
        cancelButton.SetActive(true);
    }
    public void CancelButton()
    {
        bestScorePanel.SetActive(false);
        playButton.SetActive(true);
        quitButton.SetActive(true);
        guidButton.SetActive(true);
        creditButton.SetActive(true);
        cancelButton.SetActive(false);
    }
    public void GuidButton()
    {//đây là code
        Debug.Log("GuidButton được gọi");
        guidPanel.SetActive(true);
        Debug.Log("GuidPanel đã được kích hoạt");
        cancelGuid.SetActive(true);
        playButton.SetActive(false);
        quitButton.SetActive(false);
        guidButton.SetActive(false);
        creditButton.SetActive(false);
        bestScoreButton.SetActive(false);
        //O de cai panel la con của cái nút nên  cái nút tắt thì tắt luôn cái con của nó


    }
    public void CreditButton()
    {
        guidButton.SetActive(false);
        creditPanel.SetActive(true);
        cancelCredit.SetActive(true);
        playButton.SetActive(false);
        quitButton.SetActive(false);
        bestScoreButton.SetActive(false);
        creditButton.SetActive(false);
    }
    public void CancelGuidButton()
    {
       // guidPanel.SetActive(false);
        playButton.SetActive(true);
        quitButton.SetActive(true);
        guidButton.SetActive(true);
        creditButton.SetActive(true);
        cancelGuid.SetActive(false);
        bestScoreButton.SetActive(true);
        guidPanel.SetActive(false); 
    }
    public void CancelCreditButton()
    {
        creditPanel.SetActive(false);
        playButton.SetActive(true);
        quitButton.SetActive(true);
        guidButton.SetActive(true);
        creditButton.SetActive(true);
        cancelCredit.SetActive(false);
        bestScoreButton.SetActive(true);
    }


}
