using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{

    public void LoadStartMenu()
    {
        SceneManager.LoadScene("Start");
    }

    public void LoadGame()
    {
        Debug.Log("call load game");
        SceneManager.LoadScene("Game");
        //FindObjectOfType<GameSession>().ResetGame();
    }

    public void LoadGameWon()
    {
        SceneManager.LoadScene("Victory");
    }

    public void LoadGameOver()
    {
        StartCoroutine(WaitAndLoad());
    }

    IEnumerator WaitAndLoad()
    {
        yield return new WaitForSeconds(.8f);
        SceneManager.LoadScene("Game Over");

    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
