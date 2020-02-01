using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    float currentTime = 0f;
    public Text textBox;

    public string FormatTime(float time)
    {
        int minutes = (int)time / 60;
        int seconds = (int)time - 60 * minutes;
        return string.Format("{0:00}:{1:00}", minutes, seconds);

    }
    void Start()
    {
        textBox.text = FormatTime(currentTime);
    }
    private void Update()
    {
        currentTime += Time.deltaTime;
        textBox.text = FormatTime(currentTime);
    }
}
