using System;
using System.Collections;
using System.Collections.Generic;
using Logic.World;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBar : MonoBehaviour
{
    LevelManager levelManager;

    public Image scoreBarImage;
    //private ScoreChange scoreChange;
    private float scorePercent;
    public const int scoreMax = 100;
    float scoreBarValue = .2f;
    [SerializeField] float treePoints = 1;
    [SerializeField] float rockPoints = 1;
    [SerializeField] float pondPoints = 3;

    private void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();
    }

    private void Awake()
    {
        scoreBarImage.fillAmount = scoreBarValue;
    }

    public void ScoreIncrease(BuildingType type)
    {
        if (type == BuildingType.Tree)
        {
            scorePercent += treePoints;
        }
        else if (type == BuildingType.Rock)
        {
            scorePercent += rockPoints;
        }
        else if (type == BuildingType.Pond)
        {
            scorePercent += pondPoints;
        }
        ScoreCheck();
    }

    public void ScoreDecrease(BuildingType type)
    {
        if (type == BuildingType.Tree)
        {
            scorePercent -= treePoints;
        }
        else if (type == BuildingType.Rock)
        {
            scorePercent -= rockPoints;
        }
        else if (type == BuildingType.Pond)
        {
            scorePercent -= pondPoints;
        }
        Debug.Log("Score decreased!");
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