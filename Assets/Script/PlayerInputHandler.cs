using UnityEngine;
using UnityEngine.EventSystems;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance { get; private set; }

    [Header("Touch Area Settings")]
    [Range(0f, 1f)]
    public float touchAreaHeight = 0.6f;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject); // Giữ input manager khi chuyển scene
    }

    public bool IsJumpPressed()
    {
        // 1️⃣ PC: Bấm phím Space
        if (Input.GetKeyDown(KeyCode.Space))
            return true;

        // 2️⃣ PC: Click chuột
        if (Input.GetMouseButtonDown(0))
        {
            if (!EventSystem.current.IsPointerOverGameObject())
            {
                Vector2 mousePos = Input.mousePosition;
                if (mousePos.y < Screen.height * touchAreaHeight)
                    return true;
            }
        }

        // 3️⃣ Mobile: Touch
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                if (!EventSystem.current.IsPointerOverGameObject(touch.fingerId))
                {
                    Vector2 touchPos = touch.position;
                    if (touchPos.y < Screen.height * touchAreaHeight)
                        return true;
                }
            }
        }

        return false;
    }
}
