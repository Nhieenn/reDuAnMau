using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("References")]
    public PlayerController playerController;
    public PlayerInventory playerInventory;
    public GameObject gameOverPanel;
    public Transform playerStartPoint;

    public void ResetGame()
    {
        Time.timeScale = 1f;
        Debug.Log("Reset game bắt đầu");
        //ẩn panel game over nếu đang hiển thị
        if (gameOverPanel != null)
            gameOverPanel.SetActive(false);

        //reset máu về mặc định
        if (playerInventory != null)
            playerInventory.ResetHearts();

        //reset lại player
        if (playerController != null && playerStartPoint != null)
            playerController.FullReset(playerStartPoint.position);

        //reset và chạy lại timer
        if (GameTimer.Instance != null)
        {
            GameTimer.Instance.ResetTimer();
            GameTimer.Instance.StartTimer();
        }
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMap");
    }
    private void Start()
    {
        ResetGame();
    }
}
