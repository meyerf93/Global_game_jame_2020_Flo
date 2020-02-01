using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBar : MonoBehaviour
{

    private Image scoreBarImage;
    private ScoreChange scoreChange;
    private float scorePercent;
    public const int scoreMax = 100;


    private void Awake()
    {
        scoreBarImage = transform.Find("ScoreBarImg").GetComponent<Image>();
        //scoreBarImage.fillAmount = .2f;
        //scoreChange = new ScoreChange();
        GetScorePercent();
    }

    private void Update()
    {
        scoreBarImage.fillAmount = GetScorePercent();
    }

    public void ScoreIncrease(float scoreIncrease)
    {
        Debug.Log("Increase score");
        scorePercent += scoreIncrease;
    }

    public void ScoreDecrease(float scoreDecrease)
    {
        scorePercent -= scoreDecrease;
    }

    public float GetScorePercent()
    {
        return scorePercent / scoreMax;
    }

}

public class ScoreChange
{
    
    private float scorePercent;

    //public void ScoreIncrease(float scoreIncrease)
    //{
    //    scorePercent += scoreIncrease;
    //}

    

    
}