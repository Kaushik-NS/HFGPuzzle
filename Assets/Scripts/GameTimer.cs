using UnityEngine;
using TMPro;

public class GameTimer : MonoBehaviour
{
    public TextMeshProUGUI timerText;

    private float timeElapsed = 0f;
    private bool isRunning = false;

    void Update()
    {
        if (!isRunning) return;

        timeElapsed += Time.deltaTime;

        UpdateTimerUI();
    }

    void UpdateTimerUI()
    {
        int minutes = Mathf.FloorToInt(timeElapsed / 60);
        int seconds = Mathf.FloorToInt(timeElapsed % 60);

        timerText.text = minutes.ToString("00") + ":" + seconds.ToString("00");
    }

    public void StartTimer()
    {
        timeElapsed = 0f;
        isRunning = true;
    }

    public void StopTimer()
    {
        isRunning = false;
    }
}
