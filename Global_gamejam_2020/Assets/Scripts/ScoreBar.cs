using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBar : MonoBehaviour
{
    LevelManager levelManager;

    private Image scoreBarImage;
    //private ScoreChange scoreChange;
    private float scorePercent;
    public const int scoreMax = 100;
    float scoreBarValue = .2f;
    float treePoints = 2;
    float rockPoints = 2;
    float pondPoints = 5;

    private void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();
    }

    private void Awake()
    {
        scoreBarImage = transform.Find("ScoreBarImg").GetComponent<Image>();
        scoreBarImage.fillAmount = scoreBarValue;
    }

    public void ScoreIncrease(GameObject resource)
    {
        if (resource.name == "Tree")
        {
            scorePercent += treePoints;
        }
        else if (resource.name == "Rock")
        {
            scorePercent += rockPoints;
        }
        else if (resource.name == "Pond")
        {
            scorePercent += pondPoints;
        }
        
        ScoreCheck();
    }

    public void ScoreDecrease(GameObject resource)
    {
        if (resource.name == "Tree")
        {
            scorePercent -= treePoints;
        }
        else if (resource.name == "Rock")
        {
            scorePercent -= rockPoints;
        }
        else if (resource.name == "Pond")
        {
            scorePercent -= pondPoints;
        }
        ScoreCheck();
    }

    private void ScoreCheck()
    {
        if (scorePercent >= scoreMax)
        {
            levelManager.LoadGameWon();
        }
        else if (scorePercent <= 0)
        {
            levelManager.LoadGameOver();
        }

        scoreBarValue = scorePercent / 100;
        scoreBarImage.fillAmount = scoreBarValue;
    }

}