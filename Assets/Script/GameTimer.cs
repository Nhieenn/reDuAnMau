using UnityEngine;
using TMPro;
using System;
public class GameTimer : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public static GameTimer Instance { get; private set; }

    [Header("UI References")]
    public TextMeshProUGUI  timerText; 

    private float _startTime;
    private float _currentTime;
    private bool _isRunning;
    private float _bestTime;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        StartTimer();
    }

    // Update is called once per frame
    void Update()
    {
        if (_isRunning)
        {
            _currentTime = Time.time - _startTime;
            UpdateTimerDisplay();
        }
    }
    public void StopTimer()
    {
        _isRunning = false;
    }
    public void StartTimer()
    {
        _startTime = Time.time;
        _isRunning = true;
    }

    public void ResetTimer()
    {
        _startTime = Time.time;
        _currentTime = 0f;
        UpdateTimerDisplay();
    }

    public float GetCurrentTime()
    {
        return _currentTime;
    }

    void UpdateTimerDisplay()
    {
        if (timerText != null)
        {
            // Định dạng thời gian: 00:00
            TimeSpan timeSpan = TimeSpan.FromSeconds(_currentTime);
            timerText.text = string.Format("{0:D2}:{1:D2}",
                timeSpan.Minutes,
                timeSpan.Seconds);
                //timeSpan.Milliseconds / 10);
        }
    }
    public void CheckBestTime()
    {
        if (_currentTime > _bestTime)
        {
            _bestTime = _currentTime;
            PlayerPrefs.SetFloat("BestTime", _bestTime);
        }
    }
}
