using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    float currentTime = 0f;
    public Text textBox;

    GameSession gameSession;

    public string FormatTime(float time)
    {
        int minutes = (int)time / 60;
        int seconds = (int)time - 60 * minutes;
        return string.Format("{0:00}:{1:00}", minutes, seconds);

    }

    void Start()
    {
        textBox = GetComponent<Text>();
        gameSession = FindObjectOfType<GameSession>();
    }

    private void Update()
    {
        currentTime += Time.deltaTime;
        textBox.text = gameSession.FormatTime(currentTime);
    }
}
