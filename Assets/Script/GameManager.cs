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
        //ẩn panel game over nếu đang hiển thị
        if (gameOverPanel != null)
            gameOverPanel.SetActive(false);

        //reset máu về mặc định
        if (playerInventory != null)
            playerInventory.ResetHearts();

        //reset lại player
        if (playerController != null && playerStartPoint != null)
            playerController.ResetPlayer(playerStartPoint.position);

        //reset và chạy lại timer
        if (GameTimer.Instance != null)
        {
            GameTimer.Instance.ResetTimer();
            GameTimer.Instance.StartTimer();
        }
        Time.timeScale = 1f; 
    }
    private void Start()
    {
        ResetGame();
    }
}
