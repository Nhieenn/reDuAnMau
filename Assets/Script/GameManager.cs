using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("References")]
    public PlayerController playerController;
    public PlayerInventory playerInventory;
    public GameObject gameOverPanel;
    public Transform playerStartPoint;

    private void Start()
    {
        // Không tự động reset ngay khi Start()
        // Chỉ khởi tạo nếu cần
        Debug.Log("GameManager khởi động xong.");
    }

    // Hàm gọi khi nhấn nút Play mới
    public void StartNewGame()
    {
        Debug.Log("Bắt đầu game mới");
        ResetGame();
    }

    // Hàm reset thông số nội bộ trong scene hiện tại
    public void ResetGame()
    {
        Time.timeScale = 1f;
        Debug.Log("Reset game bắt đầu");

        if (gameOverPanel != null)
            gameOverPanel.SetActive(false);

        if (playerInventory != null)
            playerInventory.ResetHearts();

        if (playerController != null && playerStartPoint != null)
            playerController.FullReset(playerStartPoint.position);

        if (GameTimer.Instance != null)
        {
            GameTimer.Instance.ResetTimer();
            GameTimer.Instance.StartTimer();
        }
    }

    // Hàm gọi khi về menu
    public void ReturnToMenu()
    {
        Time.timeScale = 1f;
        Debug.Log("Quay về MainMenu");
        SceneManager.LoadScene("Home");
    }

    // Hàm quit game
    public void QuitGame()
    {
        Debug.Log("Thoát game");
        Application.Quit();
    }
}
