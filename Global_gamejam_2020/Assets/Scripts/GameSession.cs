using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSession : MonoBehaviour
{

    float currentTime;

    private void Awake()
    {
        SetUpSingleton();
    }

    private void SetUpSingleton()
    {
        int numGameSessions = FindObjectsOfType<GameSession>().Length;
        if (numGameSessions > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public string FormatTime(float time)
    {
        int minutes = (int)time / 60;
        int seconds = (int)time - 60 * minutes;
        //Debug.Log(string.Format("{0:00}:{1:00}", minutes, seconds));
        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void Update()
    {
        currentTime += Time.deltaTime;
        FormatTime(currentTime);
    }

    public void ResetGame()
    {
        Destroy(gameObject);
    }
}
